using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CyberValetGrocery.Class;

namespace CyberValetGrocery.Admin
{
    public partial class ViewClientZipReport : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        DropdownProvider dbzip = new DropdownProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                changeLinks();
                getCompanyName();
                if (!IsPostBack)
                {
                    pnlClient.Visible = false;
                    dbzip.bindZipDropdown(drpZip);

                }



            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminCustomers.Tables[0].Rows.Count > 0)
            {
                if (dsAdminCustomers != null && dsAdminCustomers.Tables.Count > 0 && dsAdminCustomers.Tables[0].Rows.Count > 0)
                {
                    MyDataListCustomers.DataSource = dsAdminCustomers;
                    MyDataListCustomers.DataBind();
                }

            }
            //for Site Functions

            DataList MyDataListSiteFunctions = (DataList)Page.Master.FindControl("dtlsitefunctions");
            sideType = 2;
            DataSet dsAdminSiteFunctions = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
            {
                if (dsAdminSiteFunctions != null && dsAdminSiteFunctions.Tables.Count > 0 && dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
                {
                    MyDataListSiteFunctions.DataSource = dsAdminSiteFunctions;
                    MyDataListSiteFunctions.DataBind();
                }

            }

            //for reports

            DataList MyDataListReports = (DataList)Page.Master.FindControl("dtlreports");
            sideType = 3;
            DataSet dsAdminReports = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

            }


            foreach (DataListItem row1 in MyDataListReports.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbreports");
                string name = MyLinkButton.Text;
                if (name == "User Report")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbListInfo.dispose();


        }


        //Function for get short company name for page title
        public void getCompanyName()
        {

            DbProvider dbGetCompanyName = new DbProvider();
            DataSet dsGetCompanyName = new DataSet();

            dsGetCompanyName = dbGetCompanyName.getShortCompanyName();

            if (dsGetCompanyName.Tables.Count > 0)
            {
                if (dsGetCompanyName != null && dsGetCompanyName.Tables.Count > 0 && dsGetCompanyName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetCompanyName.Tables[0].Rows)
                    {
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.UserReport;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            string strZipCode = string.Empty;
            strZipCode = Convert.ToString(drpZip.SelectedValue);
            BindUSerGrid(strZipCode);
        }



        public void BindUSerGrid(string strZipCode)
        {
            lblMsg.Text = "";
            pnlClient.Visible = true;
            DataSet dsUserList = new DataSet();
            DataSet dsState = new DataSet();
            string strStateNm = string.Empty;
            lblZipNm.Text = drpZip.SelectedItem.Text;
            dsUserList = dbListInfo.GetUserReportClientZipDetailInfo(Convert.ToString(drpZip.SelectedItem.Text));

            if (dsUserList.Tables.Count > 0)
            {
                if (dsUserList != null && dsUserList.Tables.Count > 0 && dsUserList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drr in dsUserList.Tables[0].Rows)
                    {
                        dsState = dbListInfo.GetStateInfo(Convert.ToString(drr["users_state"]));
                        strStateNm = Convert.ToString(drr["users_state"]) + " - " + Convert.ToString(dsState.Tables[0].Rows[0]["state_long_name"]);
                        drr["users_state"] = Convert.ToString(strStateNm);
                    }
                    griduserList.Visible = true;
                    griduserList.DataSource = dsUserList;
                    griduserList.DataBind();
                    btnExcel.Visible = true;
                }
                else
                {

                    griduserList.Visible = false;
                    btnExcel.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noClientRec;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                griduserList.Visible = false;
                btnExcel.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noClientRec;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }




        }




        protected void griduserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            griduserList.PageIndex = e.NewPageIndex;
            if (Convert.ToString(ViewState["UserSortExpression"]) == "" && Convert.ToString(ViewState["UserDirection"]) == "")
            {
                string strZipCode = string.Empty;
                strZipCode = Convert.ToString(drpZip.SelectedValue);
                BindUSerGrid(strZipCode);
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["UserSortExpression"]), Convert.ToString(ViewState["UserDirection"]));

            }
        }


        protected void griduserList_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            try
            {
                if (GridViewSortDirection == SortDirection.Descending)
                {
                    lblMsg.Visible = false;
                    GridViewSortDirection = SortDirection.Ascending;
                    SortGridView(sortExpression, ASCENDING);
                }
                else
                {
                    lblMsg.Visible = false;
                    GridViewSortDirection = SortDirection.Descending;
                    SortGridView(sortExpression, DESCENDING);
                }
            }
            catch (Exception Addadvert_grid_Sortinge)
            {
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.adminSorry + Addadvert_grid_Sortinge.Message;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        private void SortGridView(string sortExpression, string direction)
        {
            //  You can cache the DataTable for improving performance

            DataSet dsState = new DataSet();
            string strStateNm = string.Empty;
            string strZipCode = string.Empty;
            strZipCode = Convert.ToString(drpZip.SelectedValue);
            DataSet dsUserList = new DataSet();
            dsUserList = dbListInfo.GetUserReportClientZipDetailInfo(strZipCode);
            if (dsUserList.Tables.Count > 0)
            {
                if (dsUserList != null && dsUserList.Tables.Count > 0 && dsUserList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drr in dsUserList.Tables[0].Rows)
                    {
                        dsState = dbListInfo.GetStateInfo(Convert.ToString(drr["users_state"]));
                        strStateNm = Convert.ToString(drr["users_state"]) + " - " + Convert.ToString(dsState.Tables[0].Rows[0]["state_long_name"]);
                        drr["users_state"] = Convert.ToString(strStateNm);
                    }
                    DataTable dtSorting = dsUserList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    griduserList.DataSource = dvSorting;
                    griduserList.DataBind();

                }
            }
            ViewState["UserSortExpression"] = sortExpression;
            ViewState["UserDirection"] = direction;
            dbListInfo.dispose();
        }





        protected void btnExcel_Click(object sender, EventArgs e)
        {
            string strZipCode = string.Empty;
            string strStateNm = string.Empty;
            strZipCode = Convert.ToString(drpZip.SelectedItem.Text);
            DataSet dsUserList = new DataSet();
            DataSet dsState = new DataSet();
            dsUserList = dbListInfo.GetUserReportClientZipDetailInfo(Convert.ToString(strZipCode));
            if (dsUserList.Tables.Count > 0)
            {
                if (dsUserList != null && dsUserList.Tables.Count > 0 && dsUserList.Tables[0].Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Charset = "";
                    string strDate = string.Empty;
                    strDate = Convert.ToString(DateTime.Now.Month) + "/" + Convert.ToString(DateTime.Now.Day) + "/" + Convert.ToString(DateTime.Now.Year);

                    string strFileName = "ClientReportForZip(" + strZipCode + ")On_" + strDate + ".xls";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("content-disposition", "attachment;filename=" + strFileName);
                    //string tempStream = "<table border='1' cellpadding='0' cellspacing='0' class='MsoTableGrid' style='border-collapse:collapse;border:none;mso-border-alt:solid black .5pt; mso-border-themecolor:text1;mso-yfti-tbllook:1184;mso-padding-alt:0cm 5.4pt 0cm 5.4pt'> <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes'>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='123px'>                    <b style='mso-bidi-font-weight:normal'>User Name</b></td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='190px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Email<o:p></o:p></b></p>            </td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='140px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Address <o:p></o:p></b>                </p>            </td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='110px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Phone<o:p></o:p></b></p>            </td>            <td style='width:92.45pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='123px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>City<o:p></o:p></b></p>            </td>            <td style='width:92.45pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='123px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>State<o:p></o:p></b></p> </td><td style='width: 92.4pt; border: solid black 1.0pt; mso-border-themecolor: text1; mso-border-alt: solid black .5pt; mso-border-themecolor: text1; padding: 0cm 5.4pt 0cm 5.4pt'  valign='top' width='50px'> <b style='mso-bidi-font-weight: normal'>Zip</b> </td><td style='width: 92.4pt; border: solid black 1.0pt; mso-border-themecolor: text1; mso-border-alt: solid black .5pt; mso-border-themecolor: text1; padding: 0cm 5.4pt 0cm 5.4pt'  valign='top' width='90px'> <b style='mso-bidi-font-weight: normal'>Registered Date</b> </td></tr>";

                    string tempStream = "<table border='1' cellpadding='0' cellspacing='0' class='MsoTableGrid' style='border-collapse:collapse;border:none;mso-border-alt:solid black .5pt; mso-border-themecolor:text1;mso-yfti-tbllook:1184;mso-padding-alt:0cm 5.4pt 0cm 5.4pt'>";

                    tempStream = tempStream + "<tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes'><td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top'  colspan='8' align='center'><b style='mso-bidi-font-weight:normal'>All Users Detail For Zip Code/Area(" + strZipCode + ")</b></td></tr>";

                    tempStream = tempStream + "<tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes'>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='123px' >                    <b style='mso-bidi-font-weight:normal'>User Name</b></td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='190px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Email<o:p></o:p></b></p>            </td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='140px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Address <o:p></o:p></b>                </p>            </td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='110px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Phone<o:p></o:p></b></p>            </td>            <td style='width:92.45pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='110px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>City<o:p></o:p></b></p>            </td>            <td style='width:92.45pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='100px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>State<o:p></o:p></b></p>            </td><td style='width: 92.4pt; border: solid black 1.0pt; mso-border-themecolor: text1; mso-border-alt: solid black .5pt; mso-border-themecolor: text1; padding: 0cm 5.4pt 0cm 5.4pt'  valign='top' width='100px'> <b style='mso-bidi-font-weight: normal'>Zip/Area</b> </td><td style='width: 92.4pt; border: solid black 1.0pt; mso-border-themecolor: text1; mso-border-alt: solid black .5pt; mso-border-themecolor: text1; padding: 0cm 5.4pt 0cm 5.4pt'  valign='top' width='123px'> <b style='mso-bidi-font-weight: normal'>Registered Date</b> </td></tr>";



                    Response.Write(tempStream);


                    if (dsUserList.Tables.Count > 0)
                    {
                        string enxportstr = string.Empty;
                        foreach (DataRow drr in dsUserList.Tables[0].Rows)
                        {
                            enxportstr = "<tr><td valign='top' align='left'>" + Convert.ToString(drr["userName"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["users_email"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["users_address1"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["users_phone"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["users_city"]) + "</td>";
                            Response.Write(enxportstr);


                            dsState = dbListInfo.GetStateInfo(Convert.ToString(drr["users_state"]));
                            strStateNm = Convert.ToString(drr["users_state"]) + " - " + Convert.ToString(dsState.Tables[0].Rows[0]["state_long_name"]);

                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(strStateNm) + "</td>";
                            Response.Write(enxportstr);

                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["users_zip"]) + "</td>";
                            Response.Write(enxportstr);

                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["date1"]) + "</td></tr>";
                            Response.Write(enxportstr);


                        }
                    }
                    Response.Write("</table>");

                    Response.End();
                    Response.Close();
                    lblMsg.Text = "File export";
                }
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_UserReport.aspx?type=1", false);
        }







    }
}

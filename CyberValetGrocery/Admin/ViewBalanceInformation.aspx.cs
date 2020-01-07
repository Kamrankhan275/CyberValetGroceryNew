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
    public partial class ViewBalanceInformation : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        protected void Page_Load(object sender, EventArgs e)
        {
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                try
                {
                    BindGrid();
                   

                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

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
                if (name == "Balance Report")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.BalanceReportList;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

       

        public void BindGrid()
        {
            int locId = 0;
            int intBalAmt = 0;
            int orderBy = 0;
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            intBalAmt = Convert.ToInt32(Request.QueryString["intBalAmt"]);
            orderBy = Convert.ToInt32(Request.QueryString["orderBy"]);
            lblMsg.Text = "";
            double amt = 0;
            DataSet dsBalanceList = new DataSet();
            dsBalanceList = dbListInfo.GetBalanceReportsDeatils(locId, intBalAmt, orderBy);
            if (dsBalanceList.Tables.Count > 0)
            {
                if (dsBalanceList != null && dsBalanceList.Tables.Count > 0 && dsBalanceList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsBalanceList.Tables[0].Rows)
                    {
                        amt = Math.Round(Convert.ToDouble(dtrow["users_accountvalue"]), 2);
                        dtrow["users_accountvalue"] = Convert.ToString(amt);
                    }
                    gridBalanceInfo.DataSource = dsBalanceList;
                    gridBalanceInfo.DataBind();
                    foreach (DataRow dtrow in dsBalanceList.Tables[0].Rows)
                    {
                        int userId = Convert.ToInt32(dtrow["users_id"]);                       
                        DataSet dsBalanceListNew = new DataSet();
                        dsBalanceListNew = dbListInfo.GetBalanceReportsDeatilsInfo(userId);
                        if (dsBalanceListNew.Tables.Count > 0)
                        {
                            if (dsBalanceListNew != null && dsBalanceListNew.Tables.Count > 0 && dsBalanceListNew.Tables[0].Rows.Count > 0)
                            {
                            }
                            else
                            {
                                for (int i = 0; i < gridBalanceInfo.Rows.Count; i++)
                                {

                                    GridViewRow item = gridBalanceInfo.Rows[i];
                                    Panel pnlView;
                                    Label lblUserId;
                                    pnlView = (Panel)item.FindControl("pnlView");
                                    lblUserId = (Label)item.FindControl("lblUserId");
                                    if (userId == Convert.ToInt32(lblUserId.Text))
                                    {
                                        pnlView.Visible = false;
                                    }

                                }

                            }
                        }
                        else
                        {
                            for (int i = 0; i < gridBalanceInfo.Rows.Count; i++)
                            {

                                GridViewRow item = gridBalanceInfo.Rows[i];
                                Panel pnlView;
                                Label lblUserId;
                                pnlView = (Panel)item.FindControl("pnlView");
                                lblUserId = (Label)item.FindControl("lblUserId");
                                if (userId == Convert.ToInt32(lblUserId.Text))
                                {
                                    pnlView.Visible = false;
                                }

                            }

                        }
                    }

                }
                else
                {
                    gridBalanceInfo.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gridBalanceInfo.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }




           
        }

       


        protected void gridBalanceInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridBalanceInfo.PageIndex = e.NewPageIndex;           
            if (Convert.ToString(ViewState["BalanceSortExpression"]) == "" && Convert.ToString(ViewState["BalanceDirection"]) == "")
            {
                BindGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["BalanceSortExpression"]), Convert.ToString(ViewState["BalanceDirection"]));


            }
        }



        protected void gridBalanceInfo_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            try
            {
                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    lblMsg.Visible = false;
                    GridViewSortDirection = SortDirection.Descending;
                    SortGridView(sortExpression, DESCENDING);
                }
                else
                {
                    lblMsg.Visible = false;
                    GridViewSortDirection = SortDirection.Ascending;
                    SortGridView(sortExpression, ASCENDING);
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

            int locId = 0;
            int intBalAmt = 0;
            int orderBy = 0;
            double amt = 0;
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            intBalAmt = Convert.ToInt32(Request.QueryString["intBalAmt"]);
            orderBy = Convert.ToInt32(Request.QueryString["orderBy"]);         
            DataSet dsBalanceList = new DataSet();
            dsBalanceList = dbListInfo.GetBalanceReportsDeatils(locId, intBalAmt, orderBy);
            if (dsBalanceList.Tables.Count > 0)
            {
                if (dsBalanceList != null && dsBalanceList.Tables.Count > 0 && dsBalanceList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsBalanceList.Tables[0].Rows)
                    {
                        amt = Math.Round(Convert.ToDouble(dtrow["users_accountvalue"]), 2);
                        dtrow["users_accountvalue"] = Convert.ToString(amt);
                    }

                    DataTable dtSorting = dsBalanceList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridBalanceInfo.DataSource = dvSorting;
                    gridBalanceInfo.DataBind();

                    foreach (DataRow dtrow in dsBalanceList.Tables[0].Rows)
                    {
                        int userId = Convert.ToInt32(dtrow["users_id"]);
                        DataSet dsBalanceListNew = new DataSet();
                        dsBalanceListNew = dbListInfo.GetBalanceReportsDeatilsInfo(userId);
                        if (dsBalanceListNew.Tables.Count > 0)
                        {
                            if (dsBalanceListNew != null && dsBalanceListNew.Tables.Count > 0 && dsBalanceListNew.Tables[0].Rows.Count > 0)
                            {
                            }
                            else
                            {
                                for (int i = 0; i < gridBalanceInfo.Rows.Count; i++)
                                {

                                    GridViewRow item = gridBalanceInfo.Rows[i];
                                    Panel pnlView;
                                    Label lblUserId;
                                    pnlView = (Panel)item.FindControl("pnlView");
                                    lblUserId = (Label)item.FindControl("lblUserId");
                                    if (userId == Convert.ToInt32(lblUserId.Text))
                                    {
                                        pnlView.Visible = false;
                                    }

                                }

                            }
                        }
                        else
                        {
                            for (int i = 0; i < gridBalanceInfo.Rows.Count; i++)
                            {

                                GridViewRow item = gridBalanceInfo.Rows[i];
                                Panel pnlView;
                                Label lblUserId;
                                pnlView = (Panel)item.FindControl("pnlView");
                                lblUserId = (Label)item.FindControl("lblUserId");
                                if (userId == Convert.ToInt32(lblUserId.Text))
                                {
                                    pnlView.Visible = false;
                                }

                            }

                        }
                    }


                }
            }
            ViewState["BalanceSortExpression"] = sortExpression;
            ViewState["BalanceDirection"] = direction;
            dbListInfo.dispose();
        }



        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            int locId = 0;
            int intBalAmt = 0;
            int orderBy = 0;
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            intBalAmt = Convert.ToInt32(Request.QueryString["intBalAmt"]);
            orderBy = Convert.ToInt32(Request.QueryString["orderBy"]);
            Response.Redirect("admin_balance.aspx?check=1&locId=" + locId + "&intBalAmt=" + intBalAmt + "&orderBy=" + orderBy, false);

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            int locId = 0;
            int intBalAmt = 0;
            int orderBy = 0;
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            intBalAmt = Convert.ToInt32(Request.QueryString["intBalAmt"]);
            orderBy = Convert.ToInt32(Request.QueryString["orderBy"]);
            Response.Redirect("admin_balance.aspx?check=1&locId=" + locId + "&intBalAmt=" + intBalAmt + "&orderBy=" + orderBy, false);

        }
    }
}

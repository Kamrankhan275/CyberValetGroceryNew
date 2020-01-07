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
    public partial class admin_product_report : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        DropdownProvider dropLocation = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                changeLinks();
                getCompanyName();
                if (!IsPostBack)
                {
                    dropLocation.bindLocationDropdown(drpLocation);//Bind location  into dropdown
                    dropLocation.bindShelfDropdownNew(drpShelves);//Bind location  into dropdown   
                    int check = 0;
                    check = Convert.ToInt32(Request.QueryString["check"]);
                    if (check == 1)
                    {
                        string strStartDate = string.Empty;
                        string strToDate = string.Empty;
                        int intshelfid = 0;
                        int perPage = 0;
                        string strPopular = string.Empty;                        
                        strStartDate = Convert.ToString(Request.QueryString["sDate"]);
                        strToDate = Convert.ToString(Request.QueryString["eDate"]);
                        intshelfid = Convert.ToInt32(Request.QueryString["shelfId"]);
                        strPopular = Convert.ToString(Request.QueryString["strPopular"]);
                        perPage = Convert.ToInt32(Request.QueryString["perPage"]);
                        drpShelves.SelectedValue = Convert.ToString(intshelfid);
                        drpLocation.SelectedValue = Convert.ToString(Request.QueryString["locId"]);
                        if (perPage == 0)
                        {
                            drpTotalPages.SelectedValue = "Select";
                        }
                        else
                        {
                            drpTotalPages.SelectedValue = Convert.ToString(perPage);
                        }
                        drpProdcutPopular.SelectedValue = strPopular;
                        txtFromDate.Text = strStartDate;
                        DateTime dtToday = DateTime.Today;
                       string strToday = Convert.ToString(dtToday.Year) + "/" + Convert.ToString(dtToday.Day) + "/" + Convert.ToString(dtToday.Month);
                       if (strToday != strToDate)
                       {
                           txtToDate.Text = strToDate;
                       }
                        
                    }

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
                if (name == "Product Report")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.ProductReport;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            int intshelfid = 0;
            int perPage = 0;
            string strPopular = string.Empty;
            int intDate = 0;
            DateTime dtToday = DateTime.Today;
            string strToday = string.Empty;
            string strTodayNew = string.Empty;
            string locId = string.Empty;
            strToday = Convert.ToString(dtToday.Year) + "/" + Convert.ToString(dtToday.Day) + "/" + Convert.ToString(dtToday.Month);
            strTodayNew = Convert.ToString(dtToday.Month) + "/" + Convert.ToString(dtToday.Day) + "/" + Convert.ToString(dtToday.Year);
            strPopular = drpProdcutPopular.SelectedValue;
            strStartDate = txtFromDate.Text;
            strToDate = txtToDate.Text;
            if (strToDate == "")
            {                
                if (strStartDate != "")
                {
                    intDate = CheckDate(strStartDate, strToDate, strTodayNew);
                    strToDate = strToday;
                }
                else
                {
                    strToDate = strToday;
                    intDate = 0;

                }
            }
            else
            {
                intDate = CheckDate(strStartDate, strToDate, strTodayNew);
            }

            if (drpShelves.SelectedValue == "Select")
            {
                intshelfid = 0;

            }
            else
            {
                intshelfid = Convert.ToInt32(drpShelves.SelectedValue);

            }
            if (drpTotalPages.SelectedValue == "Select")
            {
                perPage = 10;

            }
            else
            {
                perPage = Convert.ToInt32(drpTotalPages.SelectedValue);

            }
            locId = drpLocation.SelectedValue;
          
            if (intDate == 0)
            {
                Response.Redirect("ViewProdcutReport.aspx?shelfId=" + intshelfid + "&perPage=" + perPage + "&strPopular=" + strPopular + "&sDate=" + strStartDate + "&eDate=" + strToDate + "&locId=" + locId);
            }
        }


        public int CheckDate(string strStartDate, string strToDate,string strToday)
        {
            int returnDate = 0;


            DataValidator dataValidator = new DataValidator();
            if (strToDate != "")
            {
                returnDate = DataValidator.IsValidTodaysDate(strToDate);
            }
            else
            {
                returnDate = 0;

            }
            if (returnDate == 1)
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.invalidOrderReportEndDate;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                returnDate = 1;

            }
            else
            {
                if (strStartDate != "" && strToDate != "")
                {
                    returnDate = DataValidator.IsValidDate(strStartDate,strToDate);
                    if (returnDate == 2)
                    {

                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.invalidOrderReportStartDate;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        returnDate = 2;

                    }
                    else
                    {
                        lblMsg.Text = "";
                        returnDate = 0;


                    }
                }
                else if (strStartDate != "" && strToDate == "")
                {
                    returnDate = DataValidator.IsValidDate(strStartDate, strToday);
                    if (returnDate == 2)
                    {

                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.invalidProductReportStartDate;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        returnDate = 2;

                    }
                    else
                    {
                        lblMsg.Text = "";
                        returnDate = 0;


                    }



                }
                else
                {
                    lblMsg.Text = "";
                    returnDate = 0;


                }

            }

            return returnDate;

        }
    }
}

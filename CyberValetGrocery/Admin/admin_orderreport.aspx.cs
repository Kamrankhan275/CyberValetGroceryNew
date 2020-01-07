﻿using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CyberValetGrocery.Class;
using System;





namespace CyberValetGrocery.Admin
{
    public partial class admin_orderreport1 : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        DropdownProvider dropLocation = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
             changeLinks();
             getCompanyName();
            if (!IsPostBack)
            {
                dropLocation.bindLocationDropdown(drpLocationName);//Bind location  into dropdown
                lblMsg.Text = "";
                int check = 0;
                check = Convert.ToInt32(Request.QueryString["check"]);
                if (check == 1)
                {
                    txtFromDate.Text = Request.QueryString["startDate"];
                    txtToDate.Text = Request.QueryString["endDate"];
                    drpLocationName.SelectedValue = Request.QueryString["locId"];
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
                if (name == "Order Report")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.OrderReport;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        protected void btnBegin_Click(object sender, EventArgs e)
        {
            try
            {
                int intDate = CheckDate();
                if (intDate == 0)
                {
                    Response.Redirect("ViewOrderReportDetail.aspx?startDate=" +txtFromDate.Text + "&endDate=" + txtToDate.Text+"&locId="+drpLocationName.SelectedValue, false);
                }
                else
                {


                }
            }
            catch (Exception ex)
            {
               Response.Write(ex.Message);
            }





        }

        public int CheckDate()
        {
            int returnDate = 0;


            DataValidator dataValidator = new DataValidator();
            returnDate = DataValidator.IsValidTodaysDate(txtToDate.Text);
            if (returnDate == 1)
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.invalidOrderReportEndDate;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                returnDate = 1;

            }
            else
            {
                returnDate = DataValidator.IsValidDate(txtFromDate.Text,txtToDate.Text);
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

            return returnDate;

        }
    }
}

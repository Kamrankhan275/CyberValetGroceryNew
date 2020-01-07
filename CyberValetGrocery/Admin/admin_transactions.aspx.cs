using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CyberValetGrocery.Class;

namespace CyberValetGrocery.Admin
{
    public partial class admin_transactions : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        DropdownProvider dropLocation = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                try
                {
                    dropLocation.bindLocationDropdown(drpLocation);//Bind location  into dropdown
                    dropLocation.bindLocation(drpLoc);
                    int check = 0;
                    check = Convert.ToInt32(Request.QueryString["check"]);
                    if (check != 0)
                    {
                        if (check == 1)
                        {
                            drpLoc.SelectedValue = Convert.ToString(Request.QueryString["locId"]);
                            drpShow.SelectedValue = Convert.ToString(Request.QueryString["perPage"]);
                        }
                        else
                        {
                            if (Convert.ToInt32(Request.QueryString["locId"]) == 0)
                            {
                                drpLocation.SelectedValue = "Select";
                            }
                            else
                            {
                                drpLocation.SelectedValue = Convert.ToString(Request.QueryString["locId"]);
                            }
                        }
                    }

                           
                   


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


            foreach (DataListItem row1 in MyDataListCustomers.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbCustomers");
                string name = MyLinkButton.Text;
                if (name == "Transactions")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.TransactionsList;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnCredit_Click(object sender, EventArgs e)
        {
            int locId = 0;
            if (Convert.ToString(drpLocation.SelectedValue) == "Select")
            {
                locId = 0;
            }
            else
            {
                locId = Convert.ToInt32(drpLocation.SelectedValue);
            }

            Response.Redirect("EditTransactions.aspx?locId=" + locId, false);

        }

        protected void btnBegin_Click(object sender, EventArgs e)
        {

            int locId=Convert.ToInt32(drpLoc.SelectedValue);
            int perPage = Convert.ToInt32(drpShow.SelectedValue);
            Response.Redirect("ViewCustomerTransactions.aspx?locId=" + locId + "&perPage=" + perPage, false);

        }
    }
}

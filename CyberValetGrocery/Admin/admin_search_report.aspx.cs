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
    public partial class admin_search_report : System.Web.UI.Page
    {

        DbProvider dbSearchReport = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                DropdownProvider ddpLocation = new DropdownProvider();
                changeLinks();
                getCompanyName();
                if (!IsPostBack)
                {

                    ddpLocation.bindLocation(drpLocation);
                    int check = 0;
                    check = Convert.ToInt32(Request.QueryString["check"]);
                    if (check == 1)
                    {                        
                        drpSearchPopular.SelectedValue = Convert.ToString(Request.QueryString["popular"]);
                        drpTotalPages.SelectedValue = Convert.ToString(Request.QueryString["pages"]);
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.searchReportPageTitle;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }
        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbSearchReport.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbSearchReport.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbSearchReport.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
                if (name == "Searched Report")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbSearchReport.dispose();


        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            string popular = "";
            string pages = "";
            pages = drpTotalPages.SelectedValue;
            popular = drpSearchPopular.SelectedValue;
            Response.Redirect("ViewSearchReport.aspx?popular=" + popular + "&pages=" + pages);
        }
    }
}

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
    public partial class admin_list_report : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        DropdownProvider dropLocation = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            changeLinks();
            getCompanyName();

            if (!IsPostBack)
            {
                dropLocation.bindLocation(drpLocation);//Bind location  into dropdown
                dropLocation.bindLocation(drpLoc);
                int check = 0;
                check = Convert.ToInt32(Request.QueryString["check"]);
                if (check != 0)
                {
                    if (check == 1)
                    {
                        drpNumber.SelectedValue = Convert.ToString(Request.QueryString["intProduct"]);
                        drpProductType.SelectedValue = Convert.ToString(Request.QueryString["intPopular"]);
                        drpLocation.SelectedValue = Convert.ToString(Request.QueryString["intLoc"]);
                    }
                    else
                    {
                        drpLoc.SelectedValue = Convert.ToString(Request.QueryString["intLoc"]);
                        drpUser.SelectedValue = Convert.ToString(Request.QueryString["intList"]);
                    }
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
                if (name == "Saved List Report")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.SavedListReport;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            int intProduct = 0;
            int intPopular = 0;
            int intLoc = 0;
            intProduct = Convert.ToInt32(drpNumber.SelectedValue);
            intPopular = Convert.ToInt32(drpProductType.SelectedValue);
            intLoc = Convert.ToInt32(drpLocation.SelectedValue);

            Response.Redirect("ViewSavedListProductInfo.aspx?intProduct=" + intProduct + "&intPopular=" + intPopular + "&intLoc=" + intLoc, false);

        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            int intList = 0;
            int intLoc = 0;
            intList = Convert.ToInt32(drpUser.SelectedValue);
            intLoc = Convert.ToInt32(drpLoc.SelectedValue);
            Response.Redirect("ViewSavedListUserInfo.aspx?intLoc=" + intLoc + "&intList=" + intList, false);

        }
    }
}

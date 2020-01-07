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
    public partial class admin_users : System.Web.UI.Page
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
                    int check = 0;
                    check = Convert.ToInt32(Request.QueryString["check"]);
                    if (check == 1)
                    {
                        
                        txtSearch.Text = Convert.ToString(Request.QueryString["strKey"]);
                        drpSearchField.SelectedValue = Convert.ToString(Request.QueryString["intIn"]);
                        drpLocation.SelectedValue = Convert.ToString(Request.QueryString["locId"]);
                        drpSortBy.SelectedValue = Convert.ToString(Request.QueryString["SortBy"]);
                      if(Convert.ToInt32(Request.QueryString["perPage"])==10)
                      {
                         drpPagingNmber.SelectedValue="0";

                      }
                      else
                      {
                        drpPagingNmber.SelectedValue=Convert.ToString(Request.QueryString["perPage"]);
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


            foreach (DataListItem row1 in MyDataListCustomers.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbCustomers");
                string name = MyLinkButton.Text;
                if (name == "Users")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.User;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnBegin_Click(object sender, EventArgs e)
        {
            try
            {
                string strKey = string.Empty;
                int intIn = 0;
                int intSortBy = 0;
                int perPage = 0;
                int locId = 0;
                strKey = txtSearch.Text;
                intIn = Convert.ToInt32(drpSearchField.SelectedValue);
                locId = Convert.ToInt32(drpLocation.SelectedValue);
             
                intSortBy = Convert.ToInt32(drpSortBy.SelectedValue);
                if (Convert.ToInt32(drpPagingNmber.SelectedValue) == 0)
                {
                    perPage = 10;
                }
                else
                {
                    perPage = Convert.ToInt32(drpPagingNmber.SelectedValue);
                }
                Response.Redirect("ViewUserInformation.aspx?strKey=" + strKey + "&intIn=" + intIn + "&SortBy=" + intSortBy + "&locId=" + locId + "&perPage=" + perPage, false);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
    }
}

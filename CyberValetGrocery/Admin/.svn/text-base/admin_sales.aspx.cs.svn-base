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
    public partial class admin_sales : System.Web.UI.Page
    {
        DbProvider dbAddInfo = new DbProvider();
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
                    BindHomeText();
                    
                   


                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);


                }

                
            }
        }

        public void BindHomeText()
        {
            DataSet dsHomePageInfoList = new DataSet();
            dsHomePageInfoList = dbAddInfo.GetdsHomePageInfo(Convert.ToInt32(AppConstants.locationId));
            if (dsHomePageInfoList.Tables.Count > 0)
            {
                if (dsHomePageInfoList != null && dsHomePageInfoList.Tables.Count > 0 && dsHomePageInfoList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsHomePageInfoList.Tables[0].Rows)
                    {

                        txtHome.Text = Convert.ToString(dtrow["sale_text"]);
                        if (Convert.ToInt32(dtrow["sale_price"]) != 0)
                        {
                           // txtPrice.Text = Convert.ToString(dtrow["sale_price"]);
                            txtPrice.Text = Convert.ToDecimal(dtrow["sale_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            txtPrice.Text = "";
                        }
                        txtVal.Text = Convert.ToString(dtrow["sale_limit"]);
                        FCKeditor1.Value = Convert.ToString(dtrow["homepage_text"]);
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
            DataSet dsAdminCustomers = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

            }


            foreach (DataListItem row1 in MyDataListSiteFunctions.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbSitefunctions");
                string name = MyLinkButton.Text;
                if (name == "Sale Items")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbAddInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.SaleItems;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        protected void btncontinue_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ViewSalesInformation.aspx", false);


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }

        }

        protected void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                string strHomePage = string.Empty;
                int check = 0;
                double Price = 0;
                string strLimit = string.Empty;
                string strWelcomeTxt = string.Empty;
                int intInsert = 0;
                if (txtPrice.Text != "")
                {
                    Price = Convert.ToDouble(txtPrice.Text);
                }
                strHomePage = txtHome.Text;
                strLimit = txtVal.Text;
                strWelcomeTxt = FCKeditor1.Value;
                DataSet dsHomePageInfoList = new DataSet();
                 dsHomePageInfoList = dbAddInfo.GetdsHomePageInfo(Convert.ToInt32(AppConstants.locationId));
                 if (dsHomePageInfoList.Tables.Count > 0)
                 {
                     if (dsHomePageInfoList != null && dsHomePageInfoList.Tables.Count > 0 && dsHomePageInfoList.Tables[0].Rows.Count > 0)
                     {
                         check = 1;
                         intInsert = dbAddInfo.InsertHomePageInfo(strHomePage, strLimit, strWelcomeTxt, Convert.ToInt32(AppConstants.locationId), Price, check);
                     }
                     else
                     {
                         check = 0;
                         intInsert = dbAddInfo.InsertHomePageInfo(strHomePage, strLimit, strWelcomeTxt, Convert.ToInt32(AppConstants.locationId), Price, check);


                     }
                 }
               


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }

        }
    }
}
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
    public partial class AddZip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropdownProvider ddpLocation = new DropdownProvider();
            btnAdd.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
               
                lblMsg.Text = "";
                ddpLocation.bindLocationDropdown(drpLocation);
               
            }
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.addZipCode;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void changeLinks()
        {
            DbProvider dbSelectZip = new DbProvider();
            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbSelectZip.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbSelectZip.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbSelectZip.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
                if (name == "Zip Codes")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbSelectZip.dispose();


        }

        // Code for add new zip code
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DbProvider dbInsertZip = new DbProvider();
            int intInsertZip = 0;
            int intZipCodeReturn = 0;
            try
            {
                //Code for check zip code is already exists

                intZipCodeReturn = dbInsertZip.checkZipAddCode(txtZipCode.Text);
                if (intZipCodeReturn == 0)
                {

                    //Code for insert new zip code

                    intInsertZip = dbInsertZip.addNewZipCode1(Convert.ToString(txtZipCode.Text), Convert.ToInt32(drpLocation.SelectedValue), Convert.ToString(drpLocation.SelectedItem.Text),Convert.ToInt32(txtMinimumOrderAmt.Text));

                    if (intInsertZip == 1)
                    {
                        lblMsg.Text = AppConstants.zipAddSuccess;
                        lblMsg.ForeColor = System.Drawing.Color.Black;
                        txtZipCode.Text = "";
                        //txtOrderSize.Text = "";
                        drpLocation.SelectedValue = "Select";
                     
                        
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.zipAddFailed;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                       
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.zipAlreadyExists;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                   

                }
                dbInsertZip.dispose();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            Response.Redirect("admin_zipcodes.aspx", false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {

            lblMsg.Text = "";
            Response.Redirect("admin_zipcodes.aspx", false);
        }
    }
}

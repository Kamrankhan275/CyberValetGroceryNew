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
    public partial class EditZip : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                btnUpdate.Attributes.Add("onclick", "clcontent();");
                DropdownProvider ddpLocation = new DropdownProvider();
                changeLinks();
                getCompanyName();
                if (!IsPostBack)
                {
                   
                    ddpLocation.bindLocationDropdown(drpLocation);
                    getZipCode();
                    
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.updateZipCode;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        //Function for get zip code data

        public void getZipCode()
        {
            DbProvider dbGetZipCode = new DbProvider();
            DataSet dsGetZipCode = new DataSet();
            int zipCodeId = 0;
            zipCodeId = Convert.ToInt32(Request.QueryString["zipId"]);
            dsGetZipCode = dbGetZipCode.GetZipCodeDetails(zipCodeId);


            if (dsGetZipCode.Tables.Count > 0)
            {
                if (dsGetZipCode != null && dsGetZipCode.Tables.Count > 0 && dsGetZipCode.Tables[0].Rows.Count > 0)
                {

                    txtZipCode.Text = Convert.ToString(dsGetZipCode.Tables[0].Rows[0]["zipcode_zipcode"]);
                        if (Convert.ToString(dsGetZipCode.Tables[0].Rows[0]["ZipOrderSize"]) != "")
                        {
                            txtOrderSize.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsGetZipCode.Tables[0].Rows[0]["ZipOrderSize"]), 2));
                       }
                        drpLocation.SelectedValue =Convert.ToString(dsGetZipCode.Tables[0].Rows[0]["location_id"]);
                   //     txtMinimumOrderAmt.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsGetZipCode.Tables[0].Rows[0]["ZipOrderSize"]), 2));
                   
                }
            }
            dbGetZipCode.dispose();
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

        // Code for updeate zip code
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DbProvider dbUpdateZip = new DbProvider();
                int intUpdateZip = 0;
                int intZipCodeReturn = 0;
                int zipCodeId = 0;
                zipCodeId = Convert.ToInt32(Request.QueryString["zipId"]);
                try
                {
                    //Code for check zip code is already exists

                    intZipCodeReturn = dbUpdateZip.checkZipCode(txtZipCode.Text, zipCodeId);
                    if (intZipCodeReturn == 0)
                    {

                        //Code for update zip code
                        //intUpdateZip = dbUpdateZip.updateZipCode(zipCodeId, Convert.ToString(txtZipCode.Text), Convert.ToInt32(drpLocation.SelectedItem.Value), Convert.ToString(drpLocation.SelectedItem.Text), Convert.ToInt32(txtOrderSize.Text), Convert.ToInt32(txtMinimumOrderAmt.Text));
                        intUpdateZip = dbUpdateZip.updateZipCode1(zipCodeId, Convert.ToString(txtZipCode.Text), Convert.ToInt32(drpLocation.SelectedItem.Value), Convert.ToString(drpLocation.SelectedItem.Text), Convert.ToDouble(txtOrderSize.Text));
                        if (intUpdateZip == 1)
                        {
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.zipUpdateSuccess;
                            lblMsg.ForeColor = System.Drawing.Color.Black;
                            
                        }
                        else
                        {
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.zipUpdateFailed;
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            
                        }
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.zipAlreadyExists;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        

                    }
                    dbUpdateZip.dispose();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
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
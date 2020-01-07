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
using System.Text;
using System.IO;
using CyberValetGrocery.Class;

namespace CyberValetGrocery
{
    public partial class confirmaddress : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        DropdownProvider dropState = new DropdownProvider();
        DropdownProvider dropZip = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["userId"] == null)
                {
                    Response.Redirect("LoginPage.aspx", false);
                }
                else
                {

                    getCompanyName();
                    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();
                    if (!IsPostBack)
                    {
                        //dropState.bindStateDropdown(drpState);//Bind state  into dropdown
                       // dropState.bindStateDropdownNew(drpState, Convert.ToString(ViewState["StateShortName"]));//Bind state  into dropdown
                       dropZip.bindZipDropdown(drpZip);//Bind zip  into dropdown
                        DataSet dsUserInfo = new DataSet();

                        dsUserInfo = dbInfo.GetUserDetailsInfo(Convert.ToInt32(Request.Cookies["userId"].Value));

                        if (dsUserInfo.Tables.Count > 0)
                        {
                            if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                            {
                                txtAddress1.Text = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_address1"]);

                                txtAddress2.Text = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_address2"]);

                                txtCity.Text = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_city"]);

                                drpState.SelectedValue = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_state"]);


                                drpZip.SelectedValue = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_zip"]);
                              // txtZipCode.Text = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_zip"]);
                            }
                        }
                    }
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgConfirmDelivery;
                        ViewState["StateShortName"] = Convert.ToString(dtrow["StateShortName"]);

                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {

                int insertAddressInfo = 0;
                string strSpecialInfo = string.Empty;
                DataSet dsDeleteInfo = new DataSet();
                strSpecialInfo = txtSpecial.Text;
                dsDeleteInfo = dbInfo.DeleteAddressInfo(Convert.ToInt32(Request.Cookies["userId"].Value));
                insertAddressInfo = dbInfo.AddressInfo(txtAddress1.Text, txtAddress2.Text, txtCity.Text, Convert.ToString(drpState.SelectedValue), Convert.ToString(drpZip.SelectedItem.Text), strSpecialInfo, Convert.ToInt32(Request.Cookies["userId"].Value),txtCompanyName.Text,txtPhone.Text);

               // insertAddressInfo = dbInfo.AddressInfo(txtAddress1.Text, txtAddress2.Text, txtCity.Text, Convert.ToString(drpState.SelectedValue), Convert.ToString(txtZipCode.Text), strSpecialInfo, Convert.ToInt32(Request.Cookies["userId"].Value));
                
                Response.Redirect("picktime.aspx", false);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

      
    }
}

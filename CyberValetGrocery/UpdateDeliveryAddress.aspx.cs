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

namespace CyberValetGrocery
{
    public partial class UpdateDeliveryAddress : System.Web.UI.Page
    {
        DropdownProvider dropState = new DropdownProvider();
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["userId"] == null)
                {
                    Response.Redirect("My_Account.aspx", false);
                }
                else
                {
                btnUpdate.Attributes.Add("onclick", "clcontent();");
                BindSideLink();
                getCompanyName();
                if (!IsPostBack)
                {
                   // dropState.bindStateDropdown(drpState);//Bind state  into dropdown
                    dropState.bindStateDropdownNew(drpState, Convert.ToString(ViewState["StateShortName"]));//Bind state  into dropdown
                    //dropState.bindZipDropdown(drpZip);
                    int userId = 0;
                    userId = Convert.ToInt32(Request.Cookies["userId"].Value);
                    DataSet dsUserDetailsInfo = new DataSet();
                    dsUserDetailsInfo = dbInfo.GetUserDetailsInfo(userId);
                    if (dsUserDetailsInfo.Tables.Count > 0)
                        {
                            if (dsUserDetailsInfo != null && dsUserDetailsInfo.Tables.Count > 0 && dsUserDetailsInfo.Tables[0].Rows.Count > 0)
                            {
                                txtAddress1.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_address1"]);
                                txtAddress2.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_address2"]);
                                txtCity.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_city"]);
                                drpState.SelectedValue = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_state"]);
                                //drpZip.SelectedItem.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_zip"]);
                                txtZipCode.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_zip"]);
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
        public void BindSideLink()
        {
            Panel pnlHow = (Panel)Page.Master.FindControl("pnlHow");
            pnlHow.Visible = false;
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = false;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = true;
            Panel pnlAccNoLogin = (Panel)Page.Master.FindControl("pnlAccNoLogin");
            pnlAccNoLogin.Visible = false;
            Panel pnlAccLog = (Panel)Page.Master.FindControl("pnlAccLog");
            pnlAccLog.Visible = true;


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgMyAccount;
                        ViewState["StateShortName"] = Convert.ToString(dtrow["StateShortName"]);

                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = 0;
                int intUpdate = 0;
                userId = Convert.ToInt32(Request.Cookies["userId"].Value);
                intUpdate = dbInfo.UpdateUserDeliveryAddressDetails(txtAddress1.Text, txtAddress2.Text, txtCity.Text, drpState.SelectedValue, txtZipCode.Text, userId);
                if (intUpdate == 1)
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.userUpdateDeliveryAddressInfoSuccuss;
                    lblMsg.ForeColor = System.Drawing.Color.Black;
                    
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.userUpdateDeliveryAddressInfoFailed;
                    lblMsg.ForeColor = System.Drawing.Color.Red;

                }

                dbInfo.dispose();


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

    }
}

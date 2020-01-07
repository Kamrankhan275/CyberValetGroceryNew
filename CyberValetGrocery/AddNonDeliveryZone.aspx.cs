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
    public partial class AddNonDeliveryZone : System.Web.UI.Page
    {
         DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindSideLink();
                getCompanyName();
                if (!IsPostBack)
                {
                    lblMsg.Text = "";
                    string Zip = string.Empty;
                    Zip = Convert.ToString(Request.QueryString["zip"]);
                    txtZipCode.Text = Zip;


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
            pnlHow.Visible = true;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = false;

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgSignUp;

                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                int intChkValidation = 0;
                int insertData = 0;
                intChkValidation = checkValidation();
                if (intChkValidation == 0)
                {
                    DataSet dsZip = new DataSet();
                     dsZip = dbInfo.GetUserZipInfo(txtZipCode.Text);
                     if (dsZip.Tables.Count > 0)
                     {
                         if (dsZip != null && dsZip.Tables.Count > 0 && dsZip.Tables[0].Rows.Count > 0)
                         {
                             Response.Redirect("Registration.aspx?zip=" + txtZipCode.Text, false);

                         }
                         else
                         {
                             insertData = dbInfo.InsertNonDeliveryZoneInfo(txtZipCode.Text, txtEmail.Text, txtName.Text, DateTime.Now);
                             if (insertData == 1)
                             {
                                 lblMsg.Text = "";
                                 lblMsg.Text = AppConstants.userEmailSendSuccuss;
                                 lblMsg.ForeColor = System.Drawing.Color.Black;
                                 Response.Redirect("Shop.aspx", false);
                             }
                             else
                             {
                                 lblMsg.Text = "";
                                 lblMsg.Text = AppConstants.userEmailSendFailed;
                                 lblMsg.ForeColor = System.Drawing.Color.Red;

                             }
                         }
                     }
                     else
                     {
                         insertData = dbInfo.InsertNonDeliveryZoneInfo(txtZipCode.Text, txtEmail.Text, txtName.Text, DateTime.Now);
                         if (insertData == 1)
                         {
                             lblMsg.Text = "";
                             lblMsg.Text = AppConstants.userEmailSendSuccuss;
                             lblMsg.ForeColor = System.Drawing.Color.Black;
                             Response.Redirect("Shop.aspx", false);
                         }
                         else
                         {
                             lblMsg.Text = "";
                             lblMsg.Text = AppConstants.userEmailSendFailed;
                             lblMsg.ForeColor = System.Drawing.Color.Red;

                         }
                     }
                }


                dbInfo.dispose();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }

        }
        public int checkValidation()
        {
            DataValidator dataValidator = new DataValidator();
            bool returnEmail;
            int intReturn = 0;
            returnEmail = DataValidator.IsValidEmail(Convert.ToString(txtEmail.Text));

            if (returnEmail == false)
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.invalidUserEmail;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;

            }

            return intReturn;


        }
    }
}

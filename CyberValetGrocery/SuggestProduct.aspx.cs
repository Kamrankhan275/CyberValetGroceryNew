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
using System.Security.Cryptography;
using System.Net.Mail;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;
using CyberValetGrocery.Class;

namespace CyberValetGrocery
{
    public partial class SuggestProduct : System.Web.UI.Page
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
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = true;

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgSuggestProduct;
                        ViewState["CompanyShortName"] = Convert.ToString(dtrow["CompanyShortName"]);
                        ViewState["ContactEmail"] = Convert.ToString(dtrow["ContactEmail"]);
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
              
                int intStatus = 0;
                int intChkValidation = 0;
                intChkValidation = checkValidation();
                if (intChkValidation == 0)
                {
                    intStatus = check();
                    if (intStatus == 1)
                    {

                        //lblMsg.Text = "";
                        //lblMsg.Text = AppConstants.userSuggestProductSuccuss;
                        //lblMsg.ForeColor = System.Drawing.Color.Black;
                        pnlSuggest.Visible = false;
                        pnlSuggestSuccuss.Visible = true;
                        txtEmail.Text = "";
                        txtName.Text = "";
                        txtItem.Text = "";
                    }


                    else
                    {
                        pnlSuggest.Visible = true;
                        pnlSuggestSuccuss.Visible = false;
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.userContactEmailFailed;
                        lblMsg.ForeColor = System.Drawing.Color.Red;


                    }
                }
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
            string strMsg = string.Empty;
            returnEmail = DataValidator.IsValidEmail(Convert.ToString(txtEmail.Text));


            if (returnEmail == false)
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.invalidUserRegEmail;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;
            }






            return intReturn;


        }





        public int check()
        {


            int status = 0;
            try
            {
                SmtpClient smtp = new SmtpClient();
                string strEmailContent = string.Empty;
                string strPwd = string.Empty;
                string strCompanyName = string.Empty;


                DataTable dtCheckUser = new DataTable();
                MailMessage emailToUser = new MailMessage(txtEmail.Text, Convert.ToString(ViewState["ContactEmail"]));
                //Create random password


                strCompanyName = Convert.ToString(ViewState["CompanyShortName"]);

                //Fetch file name from AppConstants class file
                string strAdminEmailFileName = AppConstants.strUserSuggestProductEmailFileName;

                //object created for NameValueCollection
                NameValueCollection emailVariable = new NameValueCollection();

                //Store values in NameValueCollection from database, for now it is fetch from datatable 
                //which is hardcoded.


                emailVariable["$Name$"] = txtName.Text;
                emailVariable["$emailId$"] = txtEmail.Text;
                emailVariable["$Product$"] = txtItem.Text;
              

                //object created for EmailGenerator class file 

                EmailGenerator getEmailContent = new EmailGenerator();
                string strChkEmailFromDatabaseorFile = string.Empty;
                strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];
                if (strChkEmailFromDatabaseorFile == "fromtextfile")
                {
                    strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
                }

                string strsubject = strCompanyName + " " + AppConstants.strSuggestProductMailSubject;
                emailToUser.Subject = strsubject;
                emailToUser.Body = strEmailContent;
                emailToUser.IsBodyHtml = true;

                SmtpClient smtpServer = new SmtpClient();

                smtpServer.Send(emailToUser);
                status = 1;

            }

            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
            return status;
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shop.aspx", false);
        }

    }
}

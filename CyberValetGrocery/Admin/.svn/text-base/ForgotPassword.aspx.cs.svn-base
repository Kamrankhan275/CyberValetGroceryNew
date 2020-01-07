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



namespace CyberValetGrocery.Admin
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        DbProvider dbloginInfo = new DbProvider();
        PasswordRestrictions EncryptDecrypt = new PasswordRestrictions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                }


            }
            catch (Exception ex)
            {
               Response.Write(ex.Message);

            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string strpassword = string.Empty;
                string strEncrypt = string.Empty;
                string usernm = string.Empty;
                int intStatus = 0;
                int UpdateForgotPass = 0;
                DataSet dsAdminLogin = dbloginInfo.GetLoginEmailInfo(txtAdminEmail.Text);//To fetch admin id from database with the username and  password provided by user.
                if (dsAdminLogin.Tables[0].Rows.Count > 0)
                {
                    if (dsAdminLogin != null && dsAdminLogin.Tables.Count > 0 && dsAdminLogin.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drLogin in dsAdminLogin.Tables[0].Rows)
                        {   
                                                     
                           
                            intStatus = check();
                            if (intStatus == 1)
                            {
                                strpassword = Convert.ToString(ViewState["Password"]);
                                strEncrypt = EncryptDecrypt.encryptPassword(strpassword);
                                UpdateForgotPass = dbloginInfo.UpdateAdminForgotPassword(txtAdminEmail.Text, strEncrypt);
                                lblMsg.Text = "";
                                lblMsg.Text = AppConstants.forgotPasswordSuccess;
                                lblMsg.ForeColor = System.Drawing.Color.Black;
                                txtAdminEmail.Text = "";                                

                            }
                            else
                            {
                                lblMsg.Text = "";
                                lblMsg.Text = AppConstants.forgotPasswordFailed;
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                                txtAdminEmail.Text = "";

                            }


                        }
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.noEmailExist;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    txtAdminEmail.Text = "";
                  

                }


               
               
               

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

        }


        public string GetRandomPasswordUsingGUID(int length)
        {
            //Function to create random password

            // Get the GUID
            string strGuidResult = Convert.ToString(System.Guid.NewGuid());
            // Remove the hyphens
            strGuidResult = strGuidResult.Replace("-", string.Empty);
            // Make sure length is valid
            if (length <= 6 || length > strGuidResult.Length)
                throw new ArgumentException(AppConstants.adminLength + strGuidResult.Length);
            // Return the first length bytes
            return strGuidResult.Substring(6, length);
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
                DataSet dsSelectConstantVariables = null;           

                DataTable dtCheckUser = new DataTable();
                MailMessage emailToUser = new MailMessage(AppConstants.strAdminEmailAddress, txtAdminEmail.Text);
                //Create random password

                strPwd = GetRandomPasswordUsingGUID(7);
                ViewState["Password"] = strPwd;               
                dsSelectConstantVariables = dbloginInfo.GetConstantVaraibleInfo();
              //  dtCheckUser = dsSelectAdminForgotpass.Tables[0];            
               // strCompanyName =Convert.ToString(dsSelectConstantVariables.Tables[0].Rows[0]["CompanyName"]);
                strCompanyName = "Custom Grocery";
                
                    //Fetch file name from AppConstants class file
                    string strAdminEmailFileName = AppConstants.strForgotPasswordFileName;

                    //object created for NameValueCollection
                    NameValueCollection emailVariable = new NameValueCollection();
                
                    //Store values in NameValueCollection from database, for now it is fetch from datatable 
                    //which is hardcoded.
                    string emailText = txtAdminEmail.Text;
                    emailVariable["$emailId$"] = emailText;
                    emailVariable["$password$"] = strPwd;
                    emailVariable["$companyName$"] = strCompanyName;

                    //object created for EmailGenerator class file 

                    EmailGenerator getEmailContent = new EmailGenerator();
                    string strChkEmailFromDatabaseorFile = string.Empty;
                    strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];
                    if (strChkEmailFromDatabaseorFile == "fromtextfile")
                    {
                        strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
                    }


                    emailToUser.Subject = AppConstants.strMailSubject;
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

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("index.aspx", false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("index.aspx", false);

        }




    }
}

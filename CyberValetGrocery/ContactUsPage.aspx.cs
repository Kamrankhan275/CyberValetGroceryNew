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
using RestSharp;
using RestSharp.Authenticators;
namespace CyberValetGrocery
{
    public partial class ContactUsPage : System.Web.UI.Page
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
                    
                    //litContactEmail1.Text = "<a href='" + ViewState["ContactEmail"] + "' class='Userlink1'>" + ViewState["ContactEmail"] + "</a>";
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgContact;
                        ViewState["ContactEmail"] = Convert.ToString(dtrow["ContactEmail"]);
                        ViewState["CompanyShortName"] = Convert.ToString(dtrow["CompanyShortName"]);
                     
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            try
            {
                int intCheck = 0;
                int intStatus = 0;
                intCheck = checkValidation();
                if (intCheck == 0)
                {
                    intStatus = check();
                    if (intStatus == 1)
                    {

                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.userContactEmailSuccuss;
                        lblMsg.ForeColor = System.Drawing.Color.Black;
                        txtEmail.Text = "";
                        txtName.Text = "";
                        txtQuestion.Text = "";
                    }


                    else
                    {
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
                strMsg = AppConstants.invalidUserRegEmail;
                lblMsg.Text = "";
                lblMsg.Text = strMsg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;               

            }        
            return intReturn;


        }
        public int check_OLD()
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
                string strAdminEmailFileName = AppConstants.strUserContactEmailFileName;

                //object created for NameValueCollection
                NameValueCollection emailVariable = new NameValueCollection();

                //Store values in NameValueCollection from database, for now it is fetch from datatable 
                //which is hardcoded.


                emailVariable["$Name$"] = txtName.Text;
                emailVariable["$emailId$"] = txtEmail.Text;
                emailVariable["$Comments$"] = txtQuestion.Text;
                emailVariable["$companyName$"] = strCompanyName;

                //object created for EmailGenerator class file 

                EmailGenerator getEmailContent = new EmailGenerator();
                string strChkEmailFromDatabaseorFile = string.Empty;
                strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];
                if (strChkEmailFromDatabaseorFile == "fromtextfile")
                {
                    strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
                }

                string strsubject = strCompanyName + " " + AppConstants.strContactUsMailSubject;
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
                string strAdminEmailFileName = AppConstants.strUserContactEmailFileName;

                //object created for NameValueCollection
                NameValueCollection emailVariable = new NameValueCollection();

                //Store values in NameValueCollection from database, for now it is fetch from datatable 
                //which is hardcoded.


                emailVariable["$Name$"] = txtName.Text;
                emailVariable["$emailId$"] = txtEmail.Text;
                emailVariable["$Comments$"] = txtQuestion.Text;
                emailVariable["$companyName$"] = strCompanyName;

                //object created for EmailGenerator class file 

                EmailGenerator getEmailContent = new EmailGenerator();
                string strChkEmailFromDatabaseorFile = string.Empty;
                strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];
                if (strChkEmailFromDatabaseorFile == "fromtextfile")
                {
                    strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
                }

                string strsubject = strCompanyName + " " + AppConstants.strContactUsMailSubject;


                RestClient client = new RestClient();
                client.BaseUrl = new Uri("https://api.mailgun.net/v3");
                client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                                "e5efdd7db6b16e82f92d48443ad2b87c-09001d55-530d5a9a");
                RestRequest request = new RestRequest();
                request.AddParameter("domain", "mg.cybervaletgrocery.com", ParameterType.UrlSegment);
                request.Resource = "{domain}/messages";
                request.AddParameter("from", "<keri@lowcountrygroceryrunner.com>");
                //Test credential//


                //Live Credential



                request.AddParameter("to", "" + Convert.ToString(ViewState["ContactEmail"]) + ";" + txtEmail.Text + "");
              
                request.AddParameter("subject", strsubject);


                request.AddParameter("html",
                             "<html>" + strEmailContent + "</html>");
                // request.AddFile("attachment", Path.Combine("files", "test.jpg"));
                //  request.AddFile("attachment", Path.Combine(fileName, fileName1));
                request.Method = Method.POST;


                var reuslt = client.Execute(request);

                status = 1;

            }

            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
            return status;
        }

    }
}

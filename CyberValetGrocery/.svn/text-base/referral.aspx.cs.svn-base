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
    public partial class referral : System.Web.UI.Page
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
                    lblCmpNm.Text = Convert.ToString(ViewState["CompanyShortName"]);

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
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = false;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
           
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgReferFriend;
                        ViewState["CompanyShortName"] = Convert.ToString(dtrow["CompanyShortName"]);
                        ViewState["InfoEmail"] = Convert.ToString(dtrow["InfoEmail"]);
                        ViewState["ShortURL"] = Convert.ToString(dtrow["ShortURL"]);
                        ViewState["DeliveryFee"] = Convert.ToString(dtrow["DeliveryFee"]);
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
                    if (txtName1.Text != "" && txtEmail1.Text != "")
                    {
                        intStatus = check(txtName1.Text,txtEmail1.Text);
                    }
                    if (txtName2.Text != "" && txtEmail2.Text != "")
                    {
                        intStatus = check(txtName2.Text, txtEmail2.Text);
                    }
                    if (txtName3.Text != "" && txtEmail3.Text != "")
                    {
                        intStatus = check(txtName3.Text, txtEmail3.Text);
                    }
                    
                    if (intStatus == 1)
                    {
                        string strMsg = AppConstants.strReferEmailSuccuss1 + " " + txtYourName.Text + " " + AppConstants.strReferEmailSuccuss2 + "<br/> " +  AppConstants.strReferEmailSuccuss3+" "+ ViewState["CompanyShortName"];
                        lblMsg.Text = "";
                        lblMsg.Text = strMsg;
                        lblMsg.ForeColor = System.Drawing.Color.Black;
                        clearValue();
                     
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
            bool returnYourEmail;
            bool returnEmail1;
            bool returnEmail2;
            bool returnEmail3;

            int intReturn = 0;
            int intChk = 0;
            string strMsg = string.Empty;
            returnYourEmail = DataValidator.IsValidEmail(Convert.ToString(txtYourEmail.Text));
            if (returnYourEmail == false)
            {
                intChk = 1;

            }
            returnEmail1 = DataValidator.IsValidEmail(Convert.ToString(txtEmail1.Text));
            if (returnEmail1 == false)
            {               
                intChk=1;                

            }
            if (txtEmail2.Text != "")
            {
                returnEmail2 = DataValidator.IsValidEmail(Convert.ToString(txtEmail2.Text));

                if (returnEmail2 == false)
                {
                    
                    intChk = 1;

                }
            }

            if (txtEmail3.Text != "")
            {
                returnEmail3 = DataValidator.IsValidEmail(Convert.ToString(txtEmail3.Text));

                if (returnEmail3 == false)
                {
                    
                    intChk = 1;

                }
            }

            if (intChk == 1)
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.invalidUserRegEmail;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;
            }
            
            return intReturn;


        }



        public int check(string name,string email)
        {


            int status = 0;
            try
            {
                SmtpClient smtp = new SmtpClient();
                string strEmailContent = string.Empty;
                string strPwd = string.Empty;
                string strCompanyName = string.Empty;


                DataTable dtCheckUser = new DataTable();

                MailMessage emailToUser = new MailMessage(Convert.ToString(ViewState["InfoEmail"]),email);
                //Create random password


                strCompanyName = Convert.ToString(ViewState["CompanyShortName"]);

                //Fetch file name from AppConstants class file
                string strAdminEmailFileName = AppConstants.strUserReferAFriendFileName;

                //object created for NameValueCollection
                NameValueCollection emailVariable = new NameValueCollection();

                //Store values in NameValueCollection from database, for now it is fetch from datatable 
                //which is hardcoded.
                string strMessage = string.Empty;
                if (txtPerMsg.Text!="")
                {
                strMessage = txtYourName.Text + " also asked us to send this personal message:" + "<br/>" + txtPerMsg.Text;
                }
                emailVariable["$Friendname$"] = name;
                emailVariable["$Username$"] = txtYourName.Text;
                emailVariable["$Message$"] = strMessage;               
                emailVariable["$companyName$"] = strCompanyName;
                emailVariable["$WebsitName$"] =Convert.ToString(ViewState["ShortURL"]);
                emailVariable["$DeliveryFee$"] = Convert.ToString(ViewState["DeliveryFee"]);
                //object created for EmailGenerator class file 

                EmailGenerator getEmailContent = new EmailGenerator();
                string strChkEmailFromDatabaseorFile = string.Empty;
                strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];
                if (strChkEmailFromDatabaseorFile == "fromtextfile")
                {
                    strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
                }

                string strsubject = AppConstants.strRefferalMailSubject + " " + strCompanyName+" "+AppConstants.strRefferalMailSubject1;
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





        public void clearValue()
        {
            txtEmail1.Text = "";
            txtEmail2.Text = "";
            txtEmail3.Text = "";
            txtName1.Text = "";
            txtName2.Text = "";
            txtName3.Text = "";
            txtPerMsg.Text = "";
            txtYourEmail.Text = "";
            txtYourName.Text = ""; ;
        }
    }
}

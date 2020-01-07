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
    public partial class AccountFunds : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                Page.Form.DefaultButton = btnSubmit.UniqueID;
                btnSubmit.Attributes.Add("onkeypress", "clcontent();");

                BindSideLink();
                getCompanyName();
                if (!IsPostBack)
                {
                    int checkDep = 0;
                    checkDep = Convert.ToInt32(Request.QueryString["checkDep"]);
                    if (checkDep == 1)
                    {
                        string strTransId = string.Empty;
                        lblMsg.Text = "";
                        lblMsg.Visible = true;
                        lblMsg.Text = AppConstants.strAccountFundSuccuss;
                        lblMsg.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        lblMsg.Text = "";
                    }
                    pnlForm.Visible = true;
                    pnlSuccuss.Visible = false;
                    pnlFailed.Visible = false;
                    lblCompanyName.Text = Convert.ToString(ViewState["CompanyName"]);
                    lblCompanyName1.Text = Convert.ToString(ViewState["CompanyName"]);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgAccountFund;
                        ViewState["CompanyName"] = Convert.ToString(dtrow["CompanyShortName"]);
                        ViewState["WebSiteLongUrl"] = Convert.ToString(dtrow["LongURL"]);
                        ViewState["WebshortSiteURl"] = Convert.ToString(dtrow["ShortURL"]);
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
                string strUserNm = string.Empty;
                int intChkValidation = 0;
                int intInsertData = 0;
                int intUserId = 0;
                intChkValidation = checkValidation();
                if (intChkValidation == 0)
                {

                    DataSet dsEmail = new DataSet();
                    dsEmail = dbInfo.GetUserEmailInfo(txtRecipientEmail.Text);
                    if (dsEmail.Tables.Count > 0)
                    {
                        if (dsEmail != null && dsEmail.Tables.Count > 0 && dsEmail.Tables[0].Rows.Count > 0)
                        {
                            strUserNm = dsEmail.Tables[0].Rows[0]["users_fname"] + " " + dsEmail.Tables[0].Rows[0]["users_lname"];

                            intUserId = Convert.ToInt32(dsEmail.Tables[0].Rows[0]["users_id"]);
                            ViewState["UserId"] = Convert.ToString(intUserId);
                            DataSet dsParentEmail = new DataSet();
                            dsParentEmail = dbInfo.GetUserParentEmailInfo(txtEmail.Text);
                            if (dsParentEmail.Tables.Count > 0)
                            {
                                if (dsParentEmail != null && dsParentEmail.Tables.Count > 0 && dsParentEmail.Tables[0].Rows.Count > 0)
                                {
                                    lblUserName.Text = strUserNm;
                                    pnlForm.Visible = false;
                                    pnlSuccuss.Visible = true;
                                    pnlFailed.Visible = false;

                                }
                                else
                                {
                                    intInsertData = dbInfo.InsertAccFundParentInfo(txtFName.Text, txtLName.Text, txtEmail.Text, intUserId);
                                    if (intInsertData == 1)
                                    {
                                        lblUserName.Text = strUserNm;
                                        pnlForm.Visible = false;
                                        pnlSuccuss.Visible = true;
                                        pnlFailed.Visible = false;
                                    }
                                }
                            }
                            else
                            {
                                intInsertData = dbInfo.InsertAccFundParentInfo(txtFName.Text, txtLName.Text, txtEmail.Text, intUserId);
                                if (intInsertData == 1)
                                {
                                    lblUserName.Text = strUserNm;
                                    pnlForm.Visible = false;
                                    pnlSuccuss.Visible = true;
                                    pnlFailed.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            int intCheck = check();
                            if (intCheck == 1)
                            {
                                pnlForm.Visible = false;
                                pnlSuccuss.Visible = false;
                                pnlFailed.Visible = true;
                            }

                        }
                    }
                    else
                    {
                        int intCheck = check();
                        if (intCheck == 1)
                        {
                            pnlForm.Visible = false;
                            pnlSuccuss.Visible = false;
                            pnlFailed.Visible = true;
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
            bool returnRecipentEmail;
            bool returnEmail;
            int intCheck = 0;
            int intReturn = 0;
            string strMsg = string.Empty;
            returnRecipentEmail = DataValidator.IsValidEmail(Convert.ToString(txtRecipientEmail.Text));
            returnEmail = DataValidator.IsValidEmail(Convert.ToString(txtEmail.Text));
            if (returnRecipentEmail == false)
            {
                strMsg = AppConstants.invalidRecipentEmail;
                intCheck = 1;
            }

            if (returnEmail == false)
            {
                strMsg = strMsg + "<br>" + AppConstants.invalidFundUserEmail;
                intCheck = 1;
            }

            if (intCheck != 0)
            {
                lblMsg.Text = "";
                lblMsg.Text = strMsg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;
            }
            else
            {
                lblMsg.Text = "";

            }
            return intReturn;
        }

        protected void imgNext_Click(object sender, ImageClickEventArgs e)
        {
            int intUserId = 0;
            int intParentId = 0;
            DataSet dsParentEmail = new DataSet();
            dsParentEmail = dbInfo.GetUserParentEmailInfo(txtEmail.Text);
            if (dsParentEmail.Tables.Count > 0)
            {

                if (dsParentEmail != null && dsParentEmail.Tables.Count > 0 && dsParentEmail.Tables[0].Rows.Count > 0)
                {
                    if (ViewState["UserId"] != "")
                    {
                        intUserId = Convert.ToInt32(ViewState["UserId"]);
                    }
                    if (dsParentEmail.Tables[0].Rows[0]["parent_id"] != "")
                    {
                        intParentId = Convert.ToInt32(dsParentEmail.Tables[0].Rows[0]["parent_id"]);
                    }
                    lblMsg.Text = "";
                    txtEmail.Text = "";
                    txtFName.Text = "";
                    txtRecipientEmail.Text = "";
                    txtLName.Text = "";
                  // Response.Redirect("deposit.aspx?userId=" + intUserId + "&parentId=" + intParentId, false);
                  //   Response.Redirect("https://www.CyberValetGrocery.com/deposit.aspx?userId=" + intUserId + "&parentId=" + intParentId, false);
                    Response.Redirect("deposit.aspx?userId=" + intUserId + "&parentId=" + intParentId, false);
                }
            }
            dbInfo.dispose();
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            pnlForm.Visible = true;
            pnlSuccuss.Visible = false;
            pnlFailed.Visible = false;
        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            pnlForm.Visible = true;
            pnlSuccuss.Visible = false;
            pnlFailed.Visible = false;
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
                MailMessage emailToUser = new MailMessage(txtEmail.Text, txtRecipientEmail.Text);
                //Create random password


                strCompanyName = Convert.ToString(ViewState["CompanyName"]);

                //Fetch file name from AppConstants class file
                string strAdminEmailFileName = AppConstants.strUserAccFundParentEmailFileName;

                //object created for NameValueCollection
                NameValueCollection emailVariable = new NameValueCollection();

                //Store values in NameValueCollection from database, for now it is fetch from datatable 
                //which is hardcoded.

                string strParentNm = txtFName.Text + " " + txtLName.Text;
                emailVariable["$parentName$"] = strParentNm;
                emailVariable["$webSiteLongUrl$"] = Convert.ToString(ViewState["WebSiteLongUrl"]);
                emailVariable["$companyName$"] = strCompanyName;

                //object created for EmailGenerator class file 

                EmailGenerator getEmailContent = new EmailGenerator();
                string strChkEmailFromDatabaseorFile = string.Empty;
                strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];
                if (strChkEmailFromDatabaseorFile == "fromtextfile")
                {
                    strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
                }

                string strsubject = strParentNm + " " + AppConstants.strAccountFundParentMailSubject + " " + strCompanyName + AppConstants.strAccountFundParentMailSubject1;
                emailToUser.Subject = strsubject;
                emailToUser.Body = strEmailContent;
                emailToUser.IsBodyHtml = true;

                SmtpClient smtpServer = new SmtpClient();

                smtpServer.Send(emailToUser);
                status = 1;
            }

            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            return status;
        }
    }
}

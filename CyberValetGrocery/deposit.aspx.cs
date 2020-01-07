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
using webresponce.CyberValetGrocery;
using System.Net;
using System.IO;
using System.Security.Authentication;
using RestSharp;
using RestSharp.Authenticators;
namespace CyberValetGrocery
{
    public partial class deposit : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        DropdownProvider dropState = new DropdownProvider();

        public const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
        public const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindSideLink();
                getCompanyName();
                
                if (!IsPostBack)
                {
                    int intUserId = 0;
                    int intParentId = 0;
                    string strUserFNM = string.Empty;
                    string strUserLNM = string.Empty;
                    string strUserEmail = string.Empty;
                    string strParentEmail = string.Empty;
                    dropState.bindStateDropdown(drpState);
                    GetPaymentOptionInformation();
                    lblMinAmt.Text = Convert.ToString(ViewState["MinimumDeposit"]);
                    intUserId = Convert.ToInt32(Request.QueryString["userId"]);
                    DataSet dsUserInfo = new DataSet();
                    dsUserInfo = dbInfo.GetUserDetailsInfo(intUserId);
                    if (dsUserInfo.Tables.Count > 0)
                    {
                        if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                        {
                            strUserFNM = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_fname"]);
                            ViewState["strUserNM"] = strUserFNM;
                            strUserLNM = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_lname"]);
                            ViewState["strUserLastNM"] = strUserLNM;
                            strUserEmail = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_email"]);
                            ViewState["strUserEmail"] = strUserEmail;
                            ViewState["UserAccountValue"] = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_accountvalue"]);
                        }
                    }
                    intParentId = Convert.ToInt32(Request.QueryString["parentId"]);
                    DataSet dsParentInfo = new DataSet();
                    dsParentInfo = dbInfo.GetParentDetailsInfo(intParentId);
                    if (dsParentInfo.Tables.Count > 0)
                    {
                        if (dsParentInfo != null && dsParentInfo.Tables.Count > 0 && dsParentInfo.Tables[0].Rows.Count > 0)
                        {
                            strParentEmail = Convert.ToString(dsParentInfo.Tables[0].Rows[0]["parent_email"]);
                            ViewState["strParentEmail"] = strParentEmail;
                           
                        }
                    }
                   
                   
                    if (Convert.ToString(ViewState["PaymentOption"]) == "1")
                    {
                        pnlAuthorize.Visible = true;
                        pnlAuto.Visible = true;
                        pnlPayPal.Visible = false;
                      
                       

                    }
                    else if (Convert.ToString(ViewState["PaymentOption"]) == "2")
                    {
                        pnlAuthorize.Visible = false;
                        pnlAuto.Visible = false;
                        pnlPayPal.Visible = false;



                    }

                    dbInfo.dispose();

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgAccountFund;
                        ViewState["CompanyName"] = Convert.ToString(dtrow["CompanyShortName"]);
                        ViewState["MinimumDeposit"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["MinimumDeposit"]), 2));
                        ViewState["ContactEmail"] = Convert.ToString(dtrow["ContactEmail"]);
                        ViewState["WebSiteURl"] = Convert.ToString(dtrow["ShortURL"]);
                        ViewState["LongURL"] = Convert.ToString(dtrow["LongURL"]);
                        lblCompanyNameTitle.Text = Convert.ToString(dtrow["CompanyShortName"]);
                        lblWebsiteLong.Text = Convert.ToString(ViewState["LongURL"]);

                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void GetPaymentOptionInformation()
        {
            DataSet dsGetPaymentOption = new DataSet();

            dsGetPaymentOption = dbInfo.GetPaymentOptionDetails();

            if (dsGetPaymentOption.Tables.Count > 0)
            {
                if (dsGetPaymentOption != null && dsGetPaymentOption.Tables.Count > 0 && dsGetPaymentOption.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetPaymentOption.Tables[0].Rows)
                    {
                        ViewState["PaymentOption"] = Convert.ToString(dtrow["payment_Id"]);
                        //PayPal

                        ViewState["USER"] = Convert.ToString(dtrow["API_PayPalUserName"]);
                        ViewState["PWD"] = Convert.ToString(dtrow["API_PayPalPassword"]);
                        ViewState["SIGNATURE"] = Convert.ToString(dtrow["API_PayPalSignature"]);
                        ViewState["strNVPSandboxServer"] = Convert.ToString(dtrow["API_PayPalEndPoint"]);

                        //Authorize

                        ViewState["API_Login"] = Convert.ToString(dtrow["API_Login"]);
                        ViewState["API_TransKey"] = Convert.ToString(dtrow["API_TransKey"]);
                        ViewState["API_PostUrl"] = Convert.ToString(dtrow["API_PostUrl"]);


                        //PayPalIpn
                        ViewState["PayPalUrl"] = Convert.ToString(dtrow["PaypalUrl"]);
                        lblPayPalUrl.Text = Convert.ToString(ViewState["PayPalUrl"]);
                        ViewState["BusinessEmail"] = Convert.ToString(dtrow["PaypalEmail"]);
                        lblPayEmail.Text = Convert.ToString(dtrow["PaypalEmail"]);

                        ViewState["PayPalSubmitUrl"] = Convert.ToString(dtrow["PaypalSubUrl"]);
                        ViewState["PDTToken"] = Convert.ToString(dtrow["PDTToken"]);
                       
                       

                    }
                }
            }

            dbInfo.dispose();

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            int chkValid = 0;
            chkValid = checkValidation();
            if (chkValid == 0)
            {

                if (Convert.ToString(ViewState["PaymentOption"]) == "1")
                {
                    pnlAuthorize.Visible = true;
                    pnlAuto.Visible = true;
                    pnlPayPal.Visible = false;
                    AuthorizePayment();

                    //pnlAuto.Visible = false;
                    //pnlPayPal.Visible = true;
                    //PayPalPayment();

                }
                else if (Convert.ToString(ViewState["PaymentOption"]) == "2")
                {
                    pnlAuthorize.Visible = false;
                    pnlAuto.Visible = false;
                    pnlPayPal.Visible = false;
                    PayPalPayment();
                }


            }

        }






        public int checkValidation()
        {

            DataValidator dataValidator = new DataValidator();           
            bool returnPhone1;            
            int intReturn = 0;
            int intCheck = 0;
            string strMsg = string.Empty;
            returnPhone1 = DataValidator.IsValidPhone(Convert.ToString(txtPhone.Text));           
                   
            if (Convert.ToDouble(txtDepositAmt.Text) < Convert.ToDouble(ViewState["MinimumDeposit"]))
            {
                intCheck = 1;
                strMsg = AppConstants.invalidAccountFundAmt + Convert.ToString(ViewState["MinimumDeposit"]);

            }
            if (returnPhone1 == false)
            {
                strMsg =strMsg+"<br>"+AppConstants.invalidPhoneNumber;
                intCheck = 1;
               
            }

            if (intCheck == 1)
            {
               
                lblMsg.Text = "";
                lblMsg.Text = strMsg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;


            }
           



            return intReturn;


        }

      

        public void AuthorizePayment()
        {
           

            string Gtotal1 = string.Empty;
            string strpay= string.Empty;
            string expdate = string.Empty;
            bool status;          
            //authorizenet authorize = new authorizenet();

            authorizenet authorize = new authorizenet();

           

            //tls 1.2 added
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = Tls12; //SecurityProtocolType.Ssl3;

            expdate = txtAutoExpMM.Text + "/" + txtAutoExpYY.Text;          
            Gtotal1 = Convert.ToString(txtDepositAmt.Text);

            strpay += Convert.ToString(ViewState["API_Login"]) + "," + Convert.ToString(ViewState["API_TransKey"]) + "," + Convert.ToString(ViewState["API_PostUrl"]) + "," + ttxPayCCNm.Text + "," + expdate + "," + "Cyber Valet Grocery Account Deposit" + "," + Gtotal1 + "," + txtFName.Text + "," + txtLName.Text + "," + "" + "," + txtAddress1.Text + "," + txtCity.Text.Trim() + "," + drpState.SelectedValue + "," + txtZip.Text + "," + txtPhone.Text + "," + Convert.ToString(ViewState["strUserEmail"]) + "," + "US";
            authorize.Initialize(strpay);

            status = authorize.transmit();        
            if (status == false)
            {

                lblMsg.Visible = true;
                lblMsg.Text = "";
                lblMsg.Text = "Please check Credit card number and Expiration date you have entered";
                lblMsg.ForeColor = System.Drawing.Color.Red;


            }
            else
            {
                string valTid = authorize.get_Tid;
                AddTransaction(valTid);

            }

        }



       public void PayPalPayment()
        {


            int orderNum = 0;
            //DataSet dsUserOrderInfo = new DataSet();
            //dsUserOrderInfo = dbInfo.selectAllTransacInfo();
            //if (dsUserOrderInfo.Tables.Count > 0)
            //{
            //    if (dsUserOrderInfo != null && dsUserOrderInfo.Tables.Count > 0 && dsUserOrderInfo.Tables[0].Rows.Count > 0)
            //    {
            //        orderNum = Convert.ToInt32(dsUserOrderInfo.Tables[0].Rows[0]["transactions_id"]) + 1;

            //    }
            //    else
            //    {
            //        orderNum = Convert.ToInt32(AppConstants.strTranNm);
            //    }

            //}     
            Random randomVal = new Random();
            orderNum = randomVal.Next(1,100000);

           string  UserId = Convert.ToString(Request.QueryString["userId"]);
           string ParentId = Convert.ToString(Request.QueryString["parentId"]);

           double userAmt = Convert.ToDouble(ViewState["UserAccountValue"]) + Convert.ToDouble(txtDepositAmt.Text);
            string strFund = string.Empty;
            string Msg = string.Empty;
            string add2 = string.Empty;
            add2 = txtAddress2.Text;
            if (add2 == "")
            {
                add2 = "NoAdd2";
            }
            Msg = txtPerMsg.Text;
            if (Msg == "")
            {
                Msg = "NoMsg";
            }
            strFund = UserId + "|@|" + ParentId + "|@|" + txtFName.Text + "|@|" + txtLName.Text + "|@|" + txtAddress1.Text + "|@|" + add2 + "|@|" + txtCity.Text + "|@|" + drpState.SelectedValue + "|@|" + txtZip.Text + "|@|" + txtPhone.Text + "|@|" + txtDepositAmt.Text + "|@|" + Msg + "|@|" + Convert.ToString(userAmt) + "|@|" + Convert.ToString(ViewState["strUserNM"]) + "|@|" + Convert.ToString(ViewState["strUserEmail"]) + "|@|" + Convert.ToString(ViewState["strParentEmail"]) + "|@|" +Convert.ToString(ViewState["strUserLastNM"]);
            System.Web.HttpCookie DepositFund = new System.Web.HttpCookie("DepositFund", strFund);
            Response.Cookies.Add(DepositFund);

           
           

            string redirect = string.Empty;
            redirect += lblPayPalUrl.Text + "&business=" + lblPayEmail.Text;
            redirect += "&item_name=" + "Item Name";
            redirect += "&amount=" + String.Format("{0:0.00} ", txtDepositAmt.Text);
            redirect += "&item_number=" + Convert.ToInt32(orderNum);
            redirect += "&currency_code=USD";
            //redirect += "&add =1";
            redirect += "&return=" + lblWebsiteLong.Text + "/Success.aspx";
            redirect += "&cancel_return=" + lblWebsiteLong.Text + "/payPalCancel.aspx";
            redirect += "&notify_url=" + lblWebsiteLong.Text + "/WebForm1.aspx";
            redirect += "&custom=" + Convert.ToInt32(orderNum);
            Response.Redirect(redirect);

            

        }



      




       public void AddTransaction(string strTransactionID)
       {
           try
           {
               int intsertTrans = 0;
               int updateUser = 0;
               int intUserId = 0;
               int intParentId = 0;
               double userAmt = 0;

               DateTime dateToday = DateTime.Now;
               intUserId = Convert.ToInt32(Request.QueryString["userId"]);
               intParentId = Convert.ToInt32(Request.QueryString["parentId"]);
               ViewState["dateToday"] = Convert.ToString(dateToday);
               intsertTrans = dbInfo.InsertAccFundTransactionInformation(txtFName.Text, txtLName.Text, txtAddress1.Text, txtAddress2.Text, txtCity.Text, drpState.SelectedValue, txtZip.Text, txtPhone.Text, Convert.ToDouble(txtDepositAmt.Text), intUserId, intParentId, Convert.ToDateTime(dateToday), strTransactionID);
               userAmt = Convert.ToDouble(ViewState["UserAccountValue"]) + Convert.ToDouble(txtDepositAmt.Text);
               if (intsertTrans == 1)
               {
                   updateUser = dbInfo.UpdateUserAccInfo(intUserId, userAmt);
                   int intsend = sendMailToUser();
                   int intsend1 = sendMailToParents();
                   Response.Redirect("AccountFunds.aspx?checkDep=1", false);

               }

               dbInfo.dispose();

           }
           catch (Exception ex)
           {
               Response.Write(ex.Message);
           }


       }

       public int sendMailToUser_OLD()
       {


           int status = 0;
           try
           {
               SmtpClient smtp = new SmtpClient();
               string strEmailContent = string.Empty;
               string strPwd = string.Empty;
               string strCompanyName = string.Empty;

               DataTable dtCheckUser = new DataTable();
               MailMessage emailToUser = new MailMessage(Convert.ToString(ViewState["ContactEmail"]), Convert.ToString(ViewState["strUserEmail"]));
               //Create random password              


               //Fetch file name from AppConstants class file
               string strAdminEmailFileName = AppConstants.strAccFundUserFileName;

               //object created for NameValueCollection
               NameValueCollection emailVariable = new NameValueCollection();

               //Store values in NameValueCollection from database, for now it is fetch from datatable 
               //which is hardcoded.
               string strParentName = txtFName.Text + " " + txtLName.Text;
               emailVariable["$UserName$"] = Convert.ToString(ViewState["strUserNM"]);
               emailVariable["$companyName$"] = Convert.ToString(ViewState["CompanyName"]);
               emailVariable["$parentName$"] = strParentName;
               emailVariable["$WebSiteURl$"] = Convert.ToString(ViewState["WebSiteURl"]);
               emailVariable["$DepositAmt$"] = Convert.ToString(txtDepositAmt.Text);
               if (txtPerMsg.Text != "")
               {
                   emailVariable["$Message$"] = "PERSONAL MESSAGE: " + Convert.ToString(txtPerMsg.Text);

               }
               else
               {
                   emailVariable["$Message$"] = "";

               }


               //object created for EmailGenerator class file 

               EmailGenerator getEmailContent = new EmailGenerator();
               string strChkEmailFromDatabaseorFile = string.Empty;
               strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];
               if (strChkEmailFromDatabaseorFile == "fromtextfile")
               {
                   strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
               }

               string strsubject = AppConstants.strAccountFundUserMailSubject + " " + Convert.ToString(ViewState["CompanyName"]) + " " + AppConstants.strAccountFundUserMailSubject1;
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



       public int sendMailToUser()
       {


           int status = 0;
           try
           {
             
               string strEmailContent = string.Empty;
               string strPwd = string.Empty;
               string strCompanyName = string.Empty;

               DataTable dtCheckUser = new DataTable();
             
               //Create random password              


               //Fetch file name from AppConstants class file
               string strAdminEmailFileName = AppConstants.strAccFundUserFileName;

               //object created for NameValueCollection
               NameValueCollection emailVariable = new NameValueCollection();

               //Store values in NameValueCollection from database, for now it is fetch from datatable 
               //which is hardcoded.
               string strParentName = txtFName.Text + " " + txtLName.Text;
               emailVariable["$UserName$"] = Convert.ToString(ViewState["strUserNM"]);
               emailVariable["$companyName$"] = Convert.ToString(ViewState["CompanyName"]);
               emailVariable["$parentName$"] = strParentName;
               emailVariable["$WebSiteURl$"] = Convert.ToString(ViewState["WebSiteURl"]);
               emailVariable["$DepositAmt$"] = Convert.ToString(txtDepositAmt.Text);
               if (txtPerMsg.Text != "")
               {
                   emailVariable["$Message$"] = "PERSONAL MESSAGE: " + Convert.ToString(txtPerMsg.Text);

               }
               else
               {
                   emailVariable["$Message$"] = "";

               }


               //object created for EmailGenerator class file 

               EmailGenerator getEmailContent = new EmailGenerator();
               string strChkEmailFromDatabaseorFile = string.Empty;
               strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];
               if (strChkEmailFromDatabaseorFile == "fromtextfile")
               {
                   strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
               }

               string strsubject = AppConstants.strAccountFundUserMailSubject + " " + Convert.ToString(ViewState["CompanyName"]) + " " + AppConstants.strAccountFundUserMailSubject1;


               RestClient client = new RestClient();
               client.BaseUrl = new Uri("https://api.mailgun.net/v3");
               client.Authenticator =
                   new HttpBasicAuthenticator("api",
                                               "e5efdd7db6b16e82f92d48443ad2b87c-09001d55-530d5a9a");
               RestRequest request = new RestRequest();
               request.AddParameter("domain", "mg.cybervaletgrocery.com", ParameterType.UrlSegment);
               request.Resource = "{domain}/messages";
               request.AddParameter("from", "<keri@lowcountrygroceryrunner.com>");

               request.AddParameter("to", "" + Convert.ToString(ViewState["ContactEmail"]) + ";" + Convert.ToString(ViewState["strUserEmail"]) + "");

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




       public int sendMailToParents_OLD()
       {


           int status = 0;
           try
           {
               SmtpClient smtp = new SmtpClient();
               string strEmailContent = string.Empty;
               string strPwd = string.Empty;
               string strCompanyName = string.Empty;

               DataTable dtCheckUser = new DataTable();
               MailMessage emailToUser = new MailMessage(Convert.ToString(ViewState["ContactEmail"]), Convert.ToString(ViewState["strParentEmail"]));
               //Create random password              


               //Fetch file name from AppConstants class file
               string strAdminEmailFileName = AppConstants.strAccFundUserParentFileName;

               //object created for NameValueCollection
               NameValueCollection emailVariable = new NameValueCollection();

               //Store values in NameValueCollection from database, for now it is fetch from datatable 
               //which is hardcoded.
               string strUserName = ViewState["strUserNM"] + " " + ViewState["strUserLastNM"];
               emailVariable["$UserName$"] = strUserName;
               emailVariable["$companyName$"] = Convert.ToString(ViewState["CompanyName"]);
               emailVariable["$UserFirstNM$"] = Convert.ToString(ViewState["strUserNM"]);
               emailVariable["$UserEmail$"] = Convert.ToString(ViewState["strUserEmail"]);


               emailVariable["$TransactionDate$"] = Convert.ToString(ViewState["dateToday"]);
               emailVariable["$TransactionAmount$"] = Convert.ToString(txtDepositAmt.Text);



               //object created for EmailGenerator class file 

               EmailGenerator getEmailContent = new EmailGenerator();
               string strChkEmailFromDatabaseorFile = string.Empty;
               strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];
               if (strChkEmailFromDatabaseorFile == "fromtextfile")
               {
                   strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
               }

               string strsubject = AppConstants.strAccountFundUserParentMailSubject;
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


       public int sendMailToParents()
       {


           int status = 0;
           try
           {
              
               string strEmailContent = string.Empty;
               string strPwd = string.Empty;
               string strCompanyName = string.Empty;

               DataTable dtCheckUser = new DataTable();
            
               //Create random password              


               //Fetch file name from AppConstants class file
               string strAdminEmailFileName = AppConstants.strAccFundUserParentFileName;

               //object created for NameValueCollection
               NameValueCollection emailVariable = new NameValueCollection();

               //Store values in NameValueCollection from database, for now it is fetch from datatable 
               //which is hardcoded.
               string strUserName = ViewState["strUserNM"] + " " + ViewState["strUserLastNM"];
               emailVariable["$UserName$"] = strUserName;
               emailVariable["$companyName$"] = Convert.ToString(ViewState["CompanyName"]);
               emailVariable["$UserFirstNM$"] = Convert.ToString(ViewState["strUserNM"]);
               emailVariable["$UserEmail$"] = Convert.ToString(ViewState["strUserEmail"]);


               emailVariable["$TransactionDate$"] = Convert.ToString(ViewState["dateToday"]);
               emailVariable["$TransactionAmount$"] = Convert.ToString(txtDepositAmt.Text);



               //object created for EmailGenerator class file 

               EmailGenerator getEmailContent = new EmailGenerator();
               string strChkEmailFromDatabaseorFile = string.Empty;
               strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];
               if (strChkEmailFromDatabaseorFile == "fromtextfile")
               {
                   strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
               }

               string strsubject = AppConstants.strAccountFundUserParentMailSubject;


               RestClient client = new RestClient();
               client.BaseUrl = new Uri("https://api.mailgun.net/v3");
               client.Authenticator =
                   new HttpBasicAuthenticator("api",
                                               "e5efdd7db6b16e82f92d48443ad2b87c-09001d55-530d5a9a");
               RestRequest request = new RestRequest();
               request.AddParameter("domain", "mg.cybervaletgrocery.com", ParameterType.UrlSegment);
               request.Resource = "{domain}/messages";
               request.AddParameter("from", "<keri@lowcountrygroceryrunner.com>");

               request.AddParameter("to", "" + Convert.ToString(ViewState["ContactEmail"]) + ";" + Convert.ToString(ViewState["strParentEmail"]) + "");
              
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

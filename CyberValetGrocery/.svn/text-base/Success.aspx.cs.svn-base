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
using System.Globalization;
using System.Configuration;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Collections;
using System.Collections.Specialized;
using webresponce.CyberValetGrocery;






namespace CyberValetGrocery
{
    public partial class Success : System.Web.UI.Page
    {
        string authToken, txToken, query;
        string strResponse;
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            getCompanyName();
            if (!Page.IsPostBack)
            {
                string strToken = string.Empty;
                string strSubmitUrl = string.Empty;                

                DataSet dsGetPaymentOption = new DataSet();

                dsGetPaymentOption = dbInfo.GetPaymentOptionDetails();

                if (dsGetPaymentOption.Tables.Count > 0)
                {
                    if (dsGetPaymentOption != null && dsGetPaymentOption.Tables.Count > 0 && dsGetPaymentOption.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dtrow in dsGetPaymentOption.Tables[0].Rows)
                        {
                            ViewState["PaymentOption"] = Convert.ToString(dtrow["payment_Id"]);

                            //PayPalIpn
                            //ViewState["PayPalUrl"] = Convert.ToString(dtrow["PaypalUrl"]);
                            //ViewState["BusinessEmail"] = Convert.ToString(dtrow["PaypalEmail"]);

                            strSubmitUrl = Convert.ToString(dtrow["PaypalSubUrl"]);
                            strToken = Convert.ToString(dtrow["PDTToken"]);


                        }
                    }
                }




               
               // authToken = ConfigurationManager.AppSettings["PDTToken"];

                authToken = strToken;
                //EmailGenerator _emailGenerator = new EmailGenerator();
                //bool mailStatus = _emailGenerator.userForgotPasswordEmail("Ritu", "", "ritu@maxnet-tech.com");

                //read in txn token from querystring
                txToken = Request.QueryString.Get("tx");


                query = string.Format("cmd=_notify-synch&tx={0}&at={1}", txToken, authToken);

                // Create the request back
                string url =strSubmitUrl;
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                // Set values for the request back
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = query.Length;

                // Write the request back IPN strings
                StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                stOut.Write(query);
                stOut.Close();

                // Do the request to PayPal and get the response
                StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
                strResponse = stIn.ReadToEnd();
                stIn.Close();

                // sanity check
               // Label2.Text = strResponse;

                // If response was SUCCESS, parse response string and output details
                if (strResponse.StartsWith("SUCCESS"))
                {
                    int orderNum=0;
                    string strTransId = string.Empty;
                   
                    int insertOrder = 0;
                    string strOrdPayType = string.Empty;
                    PDTHolder pdt = PDTHolder.Parse(strResponse);
                    lblResponse.Text = string.Format("Thank you {0} {1} [{2}] for your payment of {3} {4}!",
                    pdt.PayerFirstName, pdt.PayerLastName, pdt.PayerEmail, pdt.GrossTotal, pdt.Custom);





                    orderNum = Convert.ToInt32(pdt.Custom);
                    strTransId = Convert.ToString(pdt.TransactionId);

                    if (Request.Cookies["DepositFund"] != null && Request.Cookies["DepositFund"].Value != "")
                    {
                       string  StrFund = Convert.ToString(Request.Cookies["DepositFund"].Value);

                        string[] splitter = { "|@|" };
                        string[] dateInfo = StrFund.Split(splitter, StringSplitOptions.None);
                        int i= 0;
                        string strfirst = dateInfo[i];
                        if (Convert.ToString(strfirst) == "NoFund")
                        {


                            string StrShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                            SplitShopString(StrShop);
                            string StrShipping = Convert.ToString(Request.Cookies["UserShopAddInfo"].Value);
                            SplitUserShopAddInfo(StrShipping);
                            getPaymentDropDown();
                            double totFinal = Convert.ToDouble(ViewState["intGroceryTot"]) + Convert.ToDouble(ViewState["strTippingAmt"]);
                            ViewState["TotalFinal"] = Convert.ToString(totFinal);

                            if (Request.Cookies["PaypalShopping"] != null && Request.Cookies["PaypalShopping"].Value != "")
                            {
                                strOrdPayType = Convert.ToString(Request.Cookies["PaypalShopping"].Value);

                                insertOrder = dbInfo.InsertOrderInformation(Convert.ToInt32(Request.Cookies["userId"].Value), Convert.ToString(ViewState["strAddress1"]), Convert.ToString(ViewState["strAddress2"]), Convert.ToString(ViewState["strCity"]), Convert.ToString(ViewState["strState"]), Convert.ToString(ViewState["strZip"]), Convert.ToString(ViewState["strSpecial"]), DateTime.Now, Convert.ToDateTime(ViewState["strDelDate"]), Convert.ToString(ViewState["strTimeValue"]), Convert.ToDouble(ViewState["TotalFinal"]), Convert.ToDouble(ViewState["grocerytotal"]), Convert.ToDouble(ViewState["strTippingAmt"]), Convert.ToDouble(ViewState["OrdSoda"]), Convert.ToDouble(ViewState["OrdDelFee"]), Convert.ToDouble(ViewState["CompCost"]), orderNum, Convert.ToString(strOrdPayType), Convert.ToDouble(ViewState["OrdTax"]), 1, 1, 1, 1,1);
                                if (insertOrder > 0)
                                {
                                    //Insert order product Information               
                                    InsertProductOrderInfo(insertOrder);
                                    //Insert Transaction Information  
                                    if (strOrdPayType == Convert.ToString(AppConstants.strAFCC))
                                    {

                                        InsertTransactionDetails(strOrdPayType, insertOrder, strTransId);

                                    }
                                    //Insert Loyality Fund Information  
                                    //InsertLoyalityFund(insertOrder);
                                    //update delivery capacity information
                                    UpdateDeliveryTime();
                                    HttpCookie DepositFund = new HttpCookie("DepositFund", null);
                                    Response.Cookies.Add(DepositFund);
                                    Response.Redirect("OrderConfirmation.aspx?orderId=" + insertOrder, false);


                                }




                            }
                            else
                            {
                                 int intAdd=AddTransaction(strTransId, Convert.ToString(Request.Cookies["DepositFund"].Value));
                                 if (intAdd == 1)
                                 {
                                     HttpCookie DepositFund = new HttpCookie("DepositFund", null);
                                     Response.Cookies.Add(DepositFund);
                                     Response.Redirect("AccountFunds.aspx?checkDep=1", false);
                                 }

                              //  Response.Redirect("AccountFunds.aspx?checkDep=1&id=" + strTransId, false);


                            }
                        }
                        else
                        {
                            int intAdd = AddTransaction(strTransId, Convert.ToString(Request.Cookies["DepositFund"].Value));
                            if (intAdd == 1)
                            {
                                HttpCookie DepositFund = new HttpCookie("DepositFund", null);
                                Response.Cookies.Add(DepositFund);
                                Response.Redirect("AccountFunds.aspx?checkDep=1", false);
                            }

                           // Response.Redirect("AccountFunds.aspx?checkDep=1&id=" + strTransId, false);
                          

                        }


                    }
                    
                   


                   
                }
            }
        }


        public int AddTransaction(string strTransactionID, string StrFund)
        {
            int intReturn = 0;
            string UserId = string.Empty;
            string ParentId = string.Empty;
            string FName = string.Empty;
            string LName = string.Empty;
            string add1 = string.Empty;
            string add2 = string.Empty;
            string city = string.Empty;
            string state = string.Empty;
            string zip = string.Empty;
            string phone = string.Empty;
            string deposit = string.Empty;
            string msg = string.Empty;
            string userAmt = string.Empty;
            string strUserNM = string.Empty;
            string strUserEmail = string.Empty;
            string strParentEmail = string.Empty;
            string strUserLName = string.Empty;
            string[] splitter = { "|@|" };
            string[] dateInfo = StrFund.Split(splitter, StringSplitOptions.None);
            int i = 0;
            UserId = dateInfo[i];
            ParentId = dateInfo[i + 1];
            FName = dateInfo[i + 2];
            LName = dateInfo[i + 3];
            add1 = dateInfo[i + 4];
            add2 = dateInfo[i + 5];
            if (add2 == "NoAdd2")
            {
                add2 = "";
            }
            city = dateInfo[i + 6];
            state = dateInfo[i + 7];
            zip = dateInfo[i + 8];
            phone = dateInfo[i + 9];
            deposit = dateInfo[i + 10];
            msg = dateInfo[i + 11];
            userAmt = dateInfo[i + 12];
            strUserNM = dateInfo[i + 13];
            strUserEmail = dateInfo[i + 14];
            strParentEmail = dateInfo[i + 15];
            strUserLName = dateInfo[i + 16];

            DateTime dateToday = DateTime.Now;
            ViewState["dateToday"] = Convert.ToString(dateToday);

            int intsertTrans = 0;
            int updateUser = 0;

            //double userAmt = 0;

            intsertTrans = dbInfo.InsertAccFundTransactionInformation(FName, LName, add1, add2, city, state, zip, phone, Convert.ToDouble(deposit), Convert.ToInt32(UserId), Convert.ToInt32(ParentId), Convert.ToDateTime(dateToday), strTransactionID);

            if (intsertTrans == 1)
            {
                updateUser = dbInfo.UpdateUserAccInfo(Convert.ToInt32(UserId), Convert.ToDouble(userAmt));
                string strParentName = FName + " " + LName;
                string UserName = strUserNM + " " + strUserLName;
                int intsend = sendMailToUser(deposit, strParentName, msg, UserName, strUserEmail);
                int intsend1 = sendMailToParents(strParentEmail, strUserNM, strUserEmail, dateToday, deposit, UserName);
                HttpCookie DepositFund = new HttpCookie("DepositFund", null);
                Response.Cookies.Add(DepositFund);
                intReturn = 1;


            }


            dbInfo.dispose();

            return intReturn;


        }

        public int sendMailToUser(string depAmt, string strParentName, string Msg, string userNm, string userEmail)
        {


            int status = 0;
            try
            {
                SmtpClient smtp = new SmtpClient();
                string strEmailContent = string.Empty;
                string strPwd = string.Empty;
                string strCompanyName = string.Empty;

                DataTable dtCheckUser = new DataTable();
                MailMessage emailToUser = new MailMessage(Convert.ToString(lblContactEmail.Text), Convert.ToString(userEmail));
                //Create random password              


                //Fetch file name from AppConstants class file
                string strAdminEmailFileName = AppConstants.strAccFundUserFileName;

                //object created for NameValueCollection
                NameValueCollection emailVariable = new NameValueCollection();

                //Store values in NameValueCollection from database, for now it is fetch from datatable 
                //which is hardcoded.

                emailVariable["$UserName$"] = Convert.ToString(userNm);
                emailVariable["$companyName$"] = Convert.ToString(lblCmpNm.Text);
                emailVariable["$parentName$"] = strParentName;
                emailVariable["$WebSiteURl$"] = Convert.ToString(lblWeb.Text);
                emailVariable["$DepositAmt$"] = Convert.ToString(depAmt);
                if (Msg != "NoMsg")
                {
                    emailVariable["$Message$"] = "PERSONAL MESSAGE: " + Convert.ToString(Msg);

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

                string strsubject = AppConstants.strAccountFundUserMailSubject + " " + Convert.ToString(lblCmpNm.Text) + " " + AppConstants.strAccountFundUserMailSubject1;
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








        public int sendMailToParents(string parentEmail, string userNm, string userEmail, DateTime dateToday, string deposit, string UserName)
        {


            int status = 0;
            try
            {
                SmtpClient smtp = new SmtpClient();
                string strEmailContent = string.Empty;
                string strPwd = string.Empty;
                string strCompanyName = string.Empty;

                DataTable dtCheckUser = new DataTable();
                MailMessage emailToUser = new MailMessage(Convert.ToString(lblContactEmail.Text), Convert.ToString(parentEmail));
                //Create random password              


                //Fetch file name from AppConstants class file
                string strAdminEmailFileName = AppConstants.strAccFundUserParentFileName;

                //object created for NameValueCollection
                NameValueCollection emailVariable = new NameValueCollection();

                //Store values in NameValueCollection from database, for now it is fetch from datatable 
                //which is hardcoded.

                emailVariable["$UserName$"] = Convert.ToString(UserName);
                emailVariable["$companyName$"] = Convert.ToString(lblCmpNm.Text);
                emailVariable["$UserFirstNM$"] = Convert.ToString(userNm);
                emailVariable["$UserEmail$"] = Convert.ToString(userEmail);


                emailVariable["$TransactionDate$"] = Convert.ToString(dateToday);
                emailVariable["$TransactionAmount$"] = Convert.ToString(deposit);



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

                        //PayPalIpn
                        ViewState["PayPalUrl"] = Convert.ToString(dtrow["PaypalUrl"]);                       
                        ViewState["BusinessEmail"] = Convert.ToString(dtrow["PaypalEmail"]);              

                        ViewState["PayPalSubmitUrl"] = Convert.ToString(dtrow["PaypalSubUrl"]);
                        ViewState["PDTToken"] = Convert.ToString(dtrow["PDTToken"]);


                    }
                }
            }

            dbInfo.dispose();

        }






        public void getPaymentDropDown()
        {
            string ComplimentaryCost = string.Empty;
            DataSet dsAccount = new DataSet();
            double drpValue = 0;
            dsAccount = dbInfo.GetAccountInformation(Convert.ToInt32(Request.Cookies["userId"].Value));
            if (dsAccount.Tables.Count > 0)
            {
                if (dsAccount != null && dsAccount.Tables.Count > 0 && dsAccount.Tables[0].Rows.Count > 0)
                {
                    drpValue = Math.Round(Convert.ToDouble(dsAccount.Tables[0].Rows[0]["users_accountvalue"]), 2);

                }
                else
                {
                    drpValue = 0;

                }
            }
            else
            {
                drpValue = 0;

            }
            
           if (drpValue != 0)
            {
                double amt = Convert.ToDouble(ViewState["intGroceryTot"]) + Convert.ToDouble(ViewState["strTippingAmt"]);

                if (drpValue < amt)
                {
                    ComplimentaryCost = Convert.ToString(amt - drpValue);
                }
                else
                {                   


                }
            }
            ViewState["AccountFundAmt"] = drpValue;
            if (ComplimentaryCost != "")
            {
                ViewState["CompCost"] = ComplimentaryCost;
            }
            else
            {
                ViewState["CompCost"] = "0";

            }
        }



        public void SplitShopString(string StrShop)
        {
            int intProdId = 0;
            string strProdNm = string.Empty;
            string strQty = string.Empty;
            string strPrice = string.Empty;
            double intGroceryTot = 0;
            string strTax = string.Empty;
            string strOrderVal = string.Empty;
            string strSoda = string.Empty;
            double intTotTax = 0.00;
            double rate = 0;
            double deliveryFee = 0;
            string image = string.Empty;
            DataSet dsShop = new DataSet();
            double price = 0;
            double Amt = 0;
            double TotAmt = 0;
            double sodaAmt = 0;
            double intTotsodaAmt = 0;
            //char[] splitter = { '@' };
            //string[] dateInfo = StrShop.Split(splitter);
            string[] splitter = { "|@|" };
            string[] dateInfo = StrShop.Split(splitter, StringSplitOptions.None);
            for (int i = 0; i < dateInfo.Length; i++)
            {

                if (i % 2 == 0)
                {
                    strQty = dateInfo[i];
                    strProdNm = Convert.ToString(dateInfo[i + 1]);
                    intProdId = Convert.ToInt32(dateInfo[i + 2]);
                    dsShop = dbInfo.ProductPriceAmount(strProdNm, intProdId);
                    if (dsShop.Tables.Count > 0)
                    {
                        if (dsShop != null && dsShop.Tables.Count > 0 && dsShop.Tables[0].Rows.Count > 0)
                        {
                            strTax = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_tax"]);
                            strPrice = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_price"]);
                            strSoda = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_soda"]);

                            price = Math.Round(Convert.ToDouble(strPrice), 2);
                            Amt = Convert.ToDouble(strQty) * price;
                            TotAmt = TotAmt + Amt;
                            if (strTax != "")
                            {
                                if (Convert.ToInt32(strTax) == 0)
                                {
                                    rate = Amt * (Convert.ToDouble(ViewState["TaxRate_Food"]) / 100);
                                    intTotTax = intTotTax + Math.Round(Convert.ToDouble(rate), 2);

                                }
                                else if (Convert.ToInt32(strTax) == 1)
                                {
                                    rate = Amt * (Convert.ToDouble(ViewState["TaxRate_NonFood"]) / 100);
                                    intTotTax = intTotTax + Math.Round(Convert.ToDouble(rate), 2);

                                }
                                else
                                {
                                    rate = 0.00;
                                    intTotTax = intTotTax + Math.Round(Convert.ToDouble(rate), 2);

                                }
                            }
                            if (strSoda != "" && strSoda != null)
                            {
                                sodaAmt = Convert.ToDouble(strQty) * Convert.ToDouble(strSoda);
                                intTotsodaAmt = intTotsodaAmt + Math.Round(Convert.ToDouble(sodaAmt), 2);

                            }
                            i = i + 1;

                        }

                    }
                }


            }


            if (TotAmt < Convert.ToDouble(ViewState["DeliveryFeeCutOff"]))
            {
                deliveryFee = Convert.ToDouble(ViewState["DeliveryFee"]);

            }
            else
            {
                deliveryFee = 0.00;


            }

            intGroceryTot = TotAmt + intTotTax + deliveryFee + intTotsodaAmt;
            ViewState["intGroceryTot"] = intGroceryTot;
            // lblTotal.Text = Convert.ToString(ViewState["intGroceryTot"]);

            ViewState["OrdTax"] = Convert.ToString(intTotTax);
            ViewState["OrdDelFee"] = Convert.ToString(deliveryFee);
            ViewState["OrdSoda"] = Convert.ToString(intTotsodaAmt);
            ViewState["grocerytotal"] = Convert.ToString(TotAmt); ;

        }



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
                       // Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgPayment;
                        ViewState["DeliveryFeeCutOff"] = Convert.ToString(dtrow["DeliveryFeeCutOff"]);
                        ViewState["DeliveryFee"] = Convert.ToString(dtrow["DeliveryFee"]);
                        ViewState["TaxRate_Food"] = Convert.ToString(dtrow["TaxRate_Food"]);
                        ViewState["TaxRate_NonFood"] = Convert.ToString(dtrow["TaxRate_NonFood"]);
                        
                        ViewState["LongURL"] = Convert.ToString(dtrow["LongURL"]);
                        lblWebsiteUrl.Text = Convert.ToString(dtrow["LongURL"]);
                        
                        ViewState["CompanyName"] = Convert.ToString(dtrow["CompanyShortName"]);
                        lblCmpNm.Text = Convert.ToString(dtrow["CompanyShortName"]);

                        ViewState["WebSiteURl"] = Convert.ToString(dtrow["ShortURL"]);
                        lblWeb.Text = Convert.ToString(dtrow["ShortURL"]);
                       

                        lblContactEmail.Text = Convert.ToString(dtrow["ContactEmail"]);
                        ViewState["ContactEmail"] = Convert.ToString(dtrow["ContactEmail"]);

                    }
                }
            }
            dbGetCompanyName.dispose();
        }





        public void SplitUserShopAddInfo(string StrShopAddInfo)
        {
            string strAddress1 = string.Empty;
            string strAddress2 = string.Empty;
            string strCity = string.Empty;
            string strState = string.Empty;
            string strZip = string.Empty;
            string strSpecial = string.Empty;
            string strDelDate = string.Empty;
            string strTime = string.Empty;
            string strTimeValue = string.Empty;
            string strTippingAmt = string.Empty;
            int i = 0;
            string[] splitter = { "!*@!" };
            string[] shopInfo = StrShopAddInfo.Split(splitter, StringSplitOptions.None);
            int intLen = Convert.ToInt32(shopInfo.Length);
            if (intLen > 0)
            {

                strAddress1 = Convert.ToString(shopInfo[i]);
                ViewState["strAddress1"] = strAddress1;
                strAddress2 = Convert.ToString(shopInfo[i + 1]);
                if (strAddress2 == "NoAdress2")
                {
                    ViewState["strAddress2"] = "";

                }
                else
                {
                    ViewState["strAddress2"] = strAddress2;


                }
                strCity = Convert.ToString(shopInfo[i + 2]);
                ViewState["strCity"] = strCity;


                strState = Convert.ToString(shopInfo[i + 3]);
                ViewState["strState"] = strState;

                strZip = Convert.ToString(shopInfo[i + 4]);
                ViewState["strZip"] = strZip;

                strSpecial = Convert.ToString(shopInfo[i + 5]);
                if (strSpecial == "NoSpecial")
                {
                    ViewState["strSpecial"] = "";

                }
                else
                {
                    ViewState["strSpecial"] = strSpecial;


                }
                strDelDate = Convert.ToString(shopInfo[i + 6]);
                ViewState["strDelDate"] = strDelDate;



                strTime = Convert.ToString(shopInfo[i + 7]);

                if (strTime != "")
                {
                    DataSet dsDeliveryTimeValue = new DataSet();

                    dsDeliveryTimeValue = dbInfo.GetDelveryTime(Convert.ToInt32(strTime));

                    if (dsDeliveryTimeValue.Tables.Count > 0)
                    {
                        if (dsDeliveryTimeValue != null && dsDeliveryTimeValue.Tables.Count > 0 && dsDeliveryTimeValue.Tables[0].Rows.Count > 0)
                        {
                            strTimeValue = Convert.ToString(dsDeliveryTimeValue.Tables[0].Rows[0]["deliverytime_time"]);


                        }
                    }



                }
                ViewState["strTime"] = strTime;
                ViewState["strTimeValue"] = strTimeValue;


                strTippingAmt = Convert.ToString(shopInfo[i + 8]);
                ViewState["strTippingAmt"] = strTippingAmt;
            }



        }







        public void InsertProductOrderInfo(int OrderId)
        {
            int insertProdInfo = 0;
            int intProdId = 0;
            int intQty = 0;
            double intProdPrice = 0;
            string strProdNm = string.Empty;
            string strQty = string.Empty;
            string strPrice = string.Empty;
            DataTable dtShop = new DataTable();
            DataRow rowShop;
            dtShop.Columns.Add("productId");
            dtShop.Columns.Add("Qty");
            dtShop.Columns.Add("price");
            dtShop.Columns.Add("title");

            //char[] splitter = { '@' };
            //string[] dateInfo = StrShop.Split(splitter);
            string StrShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
            string[] splitter = { "|@|" };
            string[] dateInfo = StrShop.Split(splitter, StringSplitOptions.None);
            for (int i = 0; i < dateInfo.Length; i++)
            {
                if (i % 2 == 0)
                {
                    strQty = dateInfo[i];
                    strProdNm = Convert.ToString(dateInfo[i + 1]);
                    intProdId = Convert.ToInt32(dateInfo[i + 2]);
                    intProdPrice = Convert.ToDouble(dateInfo[i + 3]);
                    if (dtShop.Rows.Count > 0)
                    {
                        foreach (DataRow dtrow in dtShop.Rows)
                        {
                            if (Convert.ToString(dtrow["title"]) == strProdNm && Convert.ToInt32(dtrow["productId"]) == intProdId)
                            {
                                dtrow["Qty"] = Convert.ToString(Convert.ToInt32(dtrow["Qty"]) + Convert.ToInt32(strQty));
                                intQty = 1;
                            }


                        }
                    }
                    if (intQty == 0)
                    {
                        rowShop = dtShop.NewRow();
                        rowShop["Qty"] = strQty;
                        rowShop["productId"] = intProdId;
                        rowShop["price"] = intProdPrice;
                        rowShop["title"] = strProdNm;

                        dtShop.Rows.Add(rowShop);
                    }


                    i = i + 1;
                }
            }
            foreach (DataRow dtrow in dtShop.Rows)
            {
                insertProdInfo = dbInfo.InsertOrderProductInfo(OrderId, Convert.ToInt32(dtrow["productId"]), Convert.ToInt32(dtrow["Qty"]), Convert.ToDouble(dtrow["price"]));


            }




        }


        public void InsertTransactionDetails(string strOrdPayType, int insertOrder, string strTransId)
        {
            string debitAccount = string.Empty;
            string accountFund = string.Empty;
            string strComm = string.Empty;
            int intUpdateUser = 0;
            int intTransaction = 0;
            string strAccFundVal = Convert.ToString(ViewState["AccountFundAmt"]);
            if (strOrdPayType == Convert.ToString(AppConstants.strAFCOD) || strOrdPayType == Convert.ToString(AppConstants.strAFCC))
            {
                debitAccount = "0";
                accountFund = Convert.ToString(0 - Convert.ToDouble(ViewState["AccountFundAmt"]));

            }
            if (strOrdPayType == Convert.ToString(AppConstants.strAF))
            {

                debitAccount = Convert.ToString(Convert.ToDouble(ViewState["AccountFundAmt"]) - Convert.ToDouble(ViewState["TotalFinal"]));
                accountFund = debitAccount;
            }
            intUpdateUser = dbInfo.UpdateUserAccInfo(Convert.ToInt32(Request.Cookies["userId"].Value), Convert.ToDouble(debitAccount));
            if (intUpdateUser > 0)
            {
                intTransaction = dbInfo.InsertTransactionInfo(DateTime.Today, Convert.ToDouble(accountFund), insertOrder, strComm, Convert.ToInt32(Request.Cookies["userId"].Value), strTransId);

            }


        }


        //public void InsertLoyalityFund(int insertOrder)
        //{
        //    double totalCost = Convert.ToDouble(ViewState["TotalFinal"]);
        //    int intUnder100 = 0;
        //    int intOver100 = 0;
        //    int intUnder100New = 0;
        //    int intOver100New = 0;
        //    int intUpdateAcc = 0;
        //    int intInsertTrans = 0;
        //    int intUserAccVal = 0;
        //    int intUpdateUser = 0;
        //    string strComm = string.Empty;
        //    DataSet dsUserInfo = new DataSet();
        //    dsUserInfo = dbInfo.GetUserDetailsInfo(Convert.ToInt32(Request.Cookies["userId"].Value));

        //    if (dsUserInfo.Tables.Count > 0)
        //    {
        //        if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
        //        {
        //            intUnder100 = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["users_under100"]);
        //            intOver100 = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["users_over100"]);
        //            intUserAccVal = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["users_accountvalue"]);
        //            if (totalCost >= 100)
        //            {
        //                int amtVal = intUserAccVal + 10;
        //                if (intOver100 == 4)
        //                {
        //                    intUpdateAcc = dbInfo.UpdateUserAccInfo(Convert.ToInt32(Request.Cookies["userId"].Value), amtVal);
        //                    if (intUpdateAcc > 0)
        //                    {
        //                        strComm = AppConstants.strLoyalOver;
        //                        intInsertTrans = dbInfo.InsertTransactionInformation(DateTime.Today, Convert.ToDouble(10), insertOrder, strComm, Convert.ToInt32(Request.Cookies["userId"].Value));
        //                        intOver100New = intOver100 + 1;
        //                        intUpdateUser = dbInfo.UpdateUserLoyalityInfo(Convert.ToInt32(Request.Cookies["userId"].Value), intOver100New, intUnder100New);
        //                    }

        //                }
        //                else if (intOver100 == 5)
        //                {
        //                    intOver100New = 1;
        //                    intUpdateUser = dbInfo.UpdateUserLoyalityInfo(Convert.ToInt32(Request.Cookies["userId"].Value), intOver100New, intUnder100New);

        //                }
        //                else
        //                {
        //                    intOver100New = intOver100 + 1;
        //                    intUpdateUser = dbInfo.UpdateUserLoyalityInfo(Convert.ToInt32(Request.Cookies["userId"].Value), intOver100New, intUnder100New);

        //                }


        //            }


        //            else if (totalCost >= 50 && totalCost <= 99.99)
        //            {
        //                int amtVal = intUserAccVal + 5;
        //                if (intUnder100 == 4)
        //                {
        //                    intUpdateAcc = dbInfo.UpdateUserAccInfo(Convert.ToInt32(Request.Cookies["userId"].Value), amtVal);
        //                    if (intUpdateAcc > 0)
        //                    {
        //                        strComm = AppConstants.strLoyalUnder;
        //                        intInsertTrans = dbInfo.InsertTransactionInformation(DateTime.Today, Convert.ToDouble(5), insertOrder, strComm, Convert.ToInt32(Request.Cookies["userId"].Value));
        //                        intUnder100New = intUnder100 + 1;
        //                        intUpdateUser = dbInfo.UpdateUserLoyalityInfo(Convert.ToInt32(Request.Cookies["userId"].Value), intOver100New, intUnder100New);
        //                    }

        //                }
        //                else if (intUnder100 == 5)
        //                {
        //                    intUnder100New = 1;
        //                    intUpdateUser = dbInfo.UpdateUserLoyalityInfo(Convert.ToInt32(Request.Cookies["userId"].Value), intOver100New, intUnder100New);

        //                }
        //                else
        //                {
        //                    intUnder100New = intUnder100 + 1;
        //                    intUpdateUser = dbInfo.UpdateUserLoyalityInfo(Convert.ToInt32(Request.Cookies["userId"].Value), intOver100New, intUnder100New);

        //                }


        //            }



        //        }
        //    }

        //}

        public void UpdateDeliveryTime()
        {
            DataSet dsDeliveryInfo = new DataSet();
            string strDelDate = string.Empty;
            string strTime = string.Empty;
            string deliverydatetimeId = string.Empty;
            string deliveryCapacity = string.Empty;
            int intDeliveryCap = 0;
            int intTime = 0;
            int updateCapacity = 0;
            strDelDate = Convert.ToString(ViewState["strDelDate"]);
            strTime = Convert.ToString(ViewState["strTime"]);
            if (strTime != "")
            {
                intTime = Convert.ToInt32(strTime);

            }
            dsDeliveryInfo = dbInfo.SelectDeliveryInfo(Convert.ToDateTime(strDelDate), intTime);
            if (dsDeliveryInfo.Tables.Count > 0)
            {
                if (dsDeliveryInfo != null && dsDeliveryInfo.Tables.Count > 0 && dsDeliveryInfo.Tables[0].Rows.Count > 0)
                {
                    deliverydatetimeId = Convert.ToString(dsDeliveryInfo.Tables[0].Rows[0]["deliverydatetime_id"]);
                    deliveryCapacity = Convert.ToString(dsDeliveryInfo.Tables[0].Rows[0]["deliverydatetime_capacity"]);
                    if (deliveryCapacity != "" && deliverydatetimeId != "")
                    {
                        if (Convert.ToInt32(deliveryCapacity) > 0)
                        {
                            intDeliveryCap = Convert.ToInt32(deliveryCapacity) - 1;
                            updateCapacity = dbInfo.UpdateDeliveryInfo(intDeliveryCap, Convert.ToInt32(deliverydatetimeId));

                        }

                    }

                }
            }




        }



    }
}
                   

                                       
                                   



        



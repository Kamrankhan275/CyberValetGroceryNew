﻿using System;
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
using System.Security.Cryptography;
using System.Net.Mail;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;
using webresponce.CyberValetGrocery;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using CyberValetGrocery.FDSertvice;

using System.Security.Authentication;


namespace CyberValetGrocery
{
    public partial class payment : System.Web.UI.Page
    {
        DropdownProvider dropState = new DropdownProvider();
        DbProvider dbInfo = new DbProvider();
        public const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
        public const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
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
                    GetPaymentOptionInformation();
                    getCompanyName();
                    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();

                    if (!IsPostBack)
                    {
                        if (Request.Cookies["ShoppingCart"] == null || Request.Cookies["ShoppingCart"].Value == "")
                        {
                            if (lblTotal.Text == null || lblTotal.Text == "")
                            {
                                btnPay.Visible = false;
                                lblTotal.Text = "0.00";
                            }
                        }
                        else
                        {
                            btnPay.Visible = true;
                            string StrShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                            string StrShipping = Convert.ToString(Request.Cookies["UserShopAddInfo"].Value);

                            AddressInfo();

                            DataSet ds = dbInfo.GetShoppingCartConstant(1);

                            ViewState["DeliveryFee"] = ds.Tables[0].Rows[0]["DeliveryFee"].ToString();
                            ViewState["MemberDeliveryFee"] = ds.Tables[0].Rows[0]["MemberDeliveryFee"].ToString();

                            if (StrShipping != "")
                            {
                                splitPickTime();
                            }

                            SplitShopString(StrShop);
                            splitTipping();

                            getPaymentDropDown();
                            double totFinal;
                            if (Convert.ToString(ViewState["strTippingAmt"]) != "")
                            {
                                totFinal = Convert.ToDouble(ViewState["strTippingAmt"]);
                            }
                            else
                            {
                                totFinal = 0;
                            }
                            totFinal += Convert.ToDouble(ViewState["intGroceryTot"]);
                            lblTotal.Text = Convert.ToDecimal(totFinal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            ViewState["TotalFinal"] = Convert.ToString(totFinal);
                            BindUserBillingInformation();
                            checkMinimumAmountOfTotal();
                            lblCompTot.Text = Convert.ToDecimal(ViewState["CompCost"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            btnPay.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        //ToCheck Minimum order
        public void checkMinimumAmountOfTotal()
        {

            DataSet dsZipVal = new DataSet();
            string strOrderVal = "";
            dsZipVal = dbInfo.GetMinOrderAmt(Convert.ToInt32(Request.Cookies["userId"].Value));
            if (dsZipVal.Tables.Count > 0)
            {
                if (dsZipVal != null && dsZipVal.Tables.Count > 0 && dsZipVal.Tables[0].Rows.Count > 0)
                {
                    strOrderVal = Convert.ToString(dsZipVal.Tables[0].Rows[0]["ZipOrderSize"]);
                }
            }
            dbInfo.dispose();
            if (strOrderVal != "")
            {
                if ((Convert.ToDouble(ViewState["sutotalMinimum"]) < Convert.ToDouble(strOrderVal)))
                {
                    pnlMinOrder.Visible = false;
                    pnlMin1.Visible = false;
                    pnlMin2.Visible = false;
                    lblMsg.Visible = true;
                    string strMsg = AppConstants.pgMinimumOrderPayment + " $" + Convert.ToDecimal(strOrderVal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    lblMsg.Text = strMsg;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblMsg.Visible = false;
                    pnlMin1.Visible = true;
                    pnlMin2.Visible = true;
                    pnlMinOrder.Visible = true;
                }
            }
            else
            {
                lblMsg.Visible = false;
                pnlMin1.Visible = true;
                pnlMin2.Visible = true;
                pnlMinOrder.Visible = true;
            }
        }
        public void BindUserBillingInformation()
        {
            string fName = string.Empty;
            string lName = string.Empty;
            string phone = string.Empty;
            string emailUser = string.Empty;
            DataSet dsUserInfo = new DataSet();
            dsUserInfo = dbInfo.GetUserDetailsInfo(Convert.ToInt32(Request.Cookies["userId"].Value));
            if (dsUserInfo.Tables.Count > 0)
            {
                if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                {
                    fName = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_fname"]);
                    ViewState["fName"] = fName;
                    lName = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_lname"]);
                    ViewState["lName"] = lName;
                    phone = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_phone"]);
                    ViewState["phone"] = phone;
                    emailUser = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_email"]);
                    ViewState["userEmail"] = emailUser;
                    txtAddress1.Text = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_baddress1"]);
                    txtAddress2.Text = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_baddress2"]);
                    txtCity.Text = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_bcity"]);
                    if (Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_bstate"]) != "")
                    {
                        drpState.SelectedValue = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_bstate"]);
                    }
                    else
                    {
                        drpState.SelectedValue = "Select";
                    }
                    txtZipCode.Text = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_bzip"]);
                }
            }
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
            //if (drpValue == 0 || drpValue <= 0)
            //{
            //    drpPayment.Items.Clear();

            //    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
            //    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Credit Card Charge ", "1"));
            //    //drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Cash On Delivery", "2"));
            //}
            //else if (drpValue != 0)
            //{
            //    double amt = Convert.ToDouble(ViewState["intGroceryTot"]) + Convert.ToDouble(ViewState["strTippingAmt"]);
            //    if (drpValue < amt)
            //    {
            //        ComplimentaryCost = Convert.ToString(amt - drpValue);
            //        drpPayment.Items.Clear();
            //        drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
            //        drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Credit Card Charge ", "1"));
            //        //drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Cash On Delivery", "2"));
            //        drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Account Fund ($" + Convert.ToDecimal(drpValue).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ")+ Credit Card Charge", "3"));
            //        //drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Account Fund ($" + drpValue + ")+ Cash On Delivery", "4"));
            //    }
            //    else
            //    {
            //        drpPayment.Items.Clear();
            //        drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
            //        drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Credit Card Charge ", "1"));
            //        // drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Cash On Delivery", "2"));
            //        drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Account Fund ($" + Convert.ToDecimal(drpValue).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ")", "5"));
            //    }
            //}
            //ViewState["AccountFundAmt"] = drpValue;
            //if (ComplimentaryCost != "")
            //{
            //    ViewState["CompCost"] = ComplimentaryCost;
            //}
            //else
            //{
            //    ViewState["CompCost"] = "0";
            //}

            if (drpValue == 0)
            {
                drpPayment.Items.Clear();

                drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Credit Card Charge ", "1"));
                //Cash On Delivery commented on 18June2013
                //drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Cash On Delivery", "2")); 
                //drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("UK Plus Account ", "6"));
            }
            else if (drpValue != 0)
            {

                double amt = Convert.ToDouble(ViewState["intGroceryTot"]) + Convert.ToDouble(ViewState["strTippingAmt"]);

                if (drpValue < amt)
                {
                    ComplimentaryCost = Convert.ToString(amt - drpValue);
                    drpPayment.Items.Clear();
                    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Credit Card Charge ", "1"));
                    //Cash On Delivery commented on 18June2013
                    //drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Cash On Delivery", "2"));
                    //drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("UK Plus Account ", "6"));
                    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Account Fund ($" + Convert.ToDecimal(drpValue).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ")+ Credit Card Charge", "3"));
                    //drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Account Fund ($" + drpValue + ")+ Cash On Delivery", "4"));
                }
                else
                {
                    drpPayment.Items.Clear();
                    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Credit Card Charge ", "1"));
                    //Cash On Delivery commented on 18June2013
                    // drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Cash On Delivery", "2"));
                    //drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("UK Plus Account ", "6"));
                    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Account Fund ($" + Convert.ToDecimal(drpValue).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ")", "5"));


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
                        //Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgPayment;
                        //ViewState["DeliveryFeeCutOff"] = Convert.ToString(dtrow["DeliveryFeeCutOff"]);
                        //ViewState["DeliveryFeeSameDay"] = Convert.ToString(dtrow["DeliveryFee"]);
                        //ViewState["TaxRate_Food"] = Convert.ToString(dtrow["TaxRate_Food"]);
                        //ViewState["TaxRate_NonFood"] = Convert.ToString(dtrow["TaxRate_NonFood"]);
                        //ViewState["LongURL"] = Convert.ToString(dtrow["LongURL"]);
                        //lblWebsiteLong.Text = Convert.ToString(ViewState["LongURL"]);
                        //ViewState["HourDeliveryFee"] = Convert.ToString(dtrow["OneHrDeliveryFee"]);
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgPayment;
                        ViewState["DeliveryFeeCutOff"] = Convert.ToString(dtrow["DeliveryFeeCutOff"]);
                        ViewState["DeliveryFee"] = Convert.ToString(dtrow["DeliveryFee"]);
                        ViewState["TaxRate_Food"] = Convert.ToString(dtrow["TaxRate_Food"]);
                        ViewState["TaxRate_NonFood"] = Convert.ToString(dtrow["TaxRate_NonFood"]);
                        ViewState["LongURL"] = Convert.ToString(dtrow["LongURL"]);
                        lblWebsiteLong.Text = Convert.ToString(ViewState["LongURL"]);
                        ViewState["PickUpDeliveryFee"] = dtrow["PickUpDeliveryFee"].ToString();
                    }
                }
            }
            dbGetCompanyName.dispose();
        }
        public void GetUserDetailsInfoForDeliveryFee()
        {
            DbProvider dbInfo = new DbProvider();
            DataSet dsUserInfo = new DataSet();
            dsUserInfo = dbInfo.GetUserDetailsInfoForDeliveryFee(Convert.ToInt32(Request.Cookies["userId"].Value));
            if (dsUserInfo.Tables.Count > 0)
            {
                if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                {
                    ViewState["DeliveryFee"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["DeliveryFee"]);
                    ViewState["MemberDeliveryFee"] = dsUserInfo.Tables[0].Rows[0]["MemberDeliveryFee"].ToString();
                }
            }
        }
        protected void drpPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strPayment = string.Empty;
            strPayment = drpPayment.SelectedValue;
            if (strPayment == "1" || strPayment == "3")
            {
                if (ViewState["PaymentOption"] != "")
                {
                    if (strPayment == "1" || strPayment == "3")
                    {
                        pnlAutoCreditCard.Visible = true;
                        btnPay.Visible = true;
                    }
                    if (Convert.ToInt32(ViewState["PaymentOption"]) == 2)
                    {
                        pnlAutoCreditCard.Visible = false;
                        btnPay.Visible = true;
                    }
                }
            }
            else
            {
                pnlAutoCreditCard.Visible = false;
                btnPay.Visible = true;
            }
        }
        protected void btnPay_Click(object sender, EventArgs e)
        {
            string strPayment = string.Empty;
            string strOrdPayType = string.Empty;
            string strAccFundVal = string.Empty;
            int intUpdate = 0;
            strPayment = drpPayment.SelectedValue;
            string strState = string.Empty;
            strState = drpState.SelectedValue;
            if (strState == "Select")
            {
                strState = "";

            }
            if (chkAgree.Checked == true)
            {
                intUpdate = dbInfo.UpdateUserBillingInfo(txtAddress1.Text, txtAddress2.Text, txtCity.Text, strState, txtZipCode.Text, Convert.ToInt32(Request.Cookies["userId"].Value));

            }


            if (strPayment == "2" || strPayment == "4" || strPayment == "5" || strPayment == "6")
            {

                if (strPayment == "2")
                {
                    strOrdPayType = Convert.ToString(AppConstants.strCOD);

                }
                if (strPayment == "4")
                {
                    strOrdPayType = Convert.ToString(AppConstants.strAFCOD);


                }
                if (strPayment == "5")
                {
                    strOrdPayType = Convert.ToString(AppConstants.strAF);

                }
                if (strPayment == "6")
                {
                    strOrdPayType = Convert.ToString(AppConstants.strUK);

                }

                //Insert Order Details

                InsertOrderDetails(strOrdPayType);
            }
            else
            {
                if (strPayment == "1")
                {
                    strOrdPayType = Convert.ToString(AppConstants.strCC);
                    if (Convert.ToString(ViewState["PaymentOption"]) != "")
                    {
                        if (Convert.ToInt32(ViewState["PaymentOption"]) == 1)
                        {
                            AuthorizePayment(strOrdPayType);
                            //WebServiceAPI(strOrdPayType);

                        }
                        if (Convert.ToInt32(ViewState["PaymentOption"]) == 2)
                        {
                            PayPayment(strOrdPayType);

                        }
                    }
                }
                if (strPayment == "3")
                {
                    strOrdPayType = Convert.ToString(AppConstants.strAFCC);
                    if (Convert.ToString(ViewState["PaymentOption"]) != "")
                    {
                        if (Convert.ToInt32(ViewState["PaymentOption"]) == 1)
                        {
                            AuthorizePayment(strOrdPayType);
                            // WebServiceAPI(strOrdPayType);
                        }
                        if (Convert.ToInt32(ViewState["PaymentOption"]) == 2)
                        {

                            PayPayment(strOrdPayType);


                        }
                    }
                }
            }
        }
        public void AuthorizePayment(string strOrdPayType)
        {
            try
            {
                string fName = string.Empty;
                string lName = string.Empty;
                string phone = string.Empty;
                string Gtotal1 = string.Empty;
                string strpay = string.Empty;
                string expdate = string.Empty;
                bool status;


                fName = Convert.ToString(ViewState["fName"]);

                lName = Convert.ToString(ViewState["lName"]);

                phone = Convert.ToString(ViewState["phone"]);


                //authorizenet authorize = new authorizenet();

                authorizenet authorize = new authorizenet();

                //tls 1.2 added
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = Tls12; //SecurityProtocolType.Ssl3;

                expdate = txtAutoExpMM.Text + "/" + txtAutoExpYY.Text;

                if (strOrdPayType == Convert.ToString(AppConstants.strCC))
                {
                    Gtotal1 = Convert.ToString(ViewState["TotalFinal"]);
                }
                else if (strOrdPayType == Convert.ToString(AppConstants.strAFCC))
                {
                    Gtotal1 = Convert.ToString(ViewState["CompCost"]);
                }

                //strpay += Convert.ToString(ViewState["API_Login"]) + "," + Convert.ToString(ViewState["API_TransKey"]) + "," + Convert.ToString(ViewState["API_PostUrl"]) + "," + ttxPayCCNm.Text + "," + expdate + "," + "CyberValetGrocery" + "," + Gtotal1 + "," + fName + "," + lName + "," + "" + "," + txtAddress1.Text + "," + txtCity.Text.Trim() + "," + drpState.SelectedValue + "," + txtZipCode.Text + "," + phone + "," + "" + "," + "";
                strpay += Convert.ToString(ViewState["API_Login"]) + "," + Convert.ToString(ViewState["API_TransKey"]) + "," + Convert.ToString(ViewState["API_PostUrl"]) + "," + ttxPayCCNm.Text + "," + expdate + "," + "CyberValetGrocery" + "," + Gtotal1 + "," + fName + "," + lName + "," + "" + "," + txtAddress1.Text + "," + txtCity.Text.Trim() + "," + drpState.SelectedValue + "," + txtZipCode.Text + "," + phone + "," + "" + "," + drpCountry.SelectedValue;
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
                    ViewState["TransactionId"] = valTid;
                    InsertOrderDetails(strOrdPayType);

                }
            }
            catch (Exception ex)
            {
                using (FileStream fs = new FileStream(Server.MapPath("~/ErrorFile.txt"), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine("*************************************");
                        writer.WriteLine(DateTime.Now);
                        writer.WriteLine(ex.Message);
                        writer.WriteLine(ex.StackTrace);
                        writer.WriteLine("*************************************");
                    }
                }
            }
        }
        public void PayPayment(string strOrdPayType)
        {
            string strPaypal = string.Empty;
            int orderNum = 0;
            string Gtotal1 = string.Empty;
            DataSet dsUserOrderInfo = new DataSet();
            dsUserOrderInfo = dbInfo.selectAllOrderInfo();
            if (dsUserOrderInfo.Tables.Count > 0)
            {
                if (dsUserOrderInfo != null && dsUserOrderInfo.Tables.Count > 0 && dsUserOrderInfo.Tables[0].Rows.Count > 0)
                {
                    orderNum = Convert.ToInt32(dsUserOrderInfo.Tables[0].Rows[0]["orders_number"]) + 1;
                }
                else
                {
                    orderNum = Convert.ToInt32(AppConstants.strOrderNm);
                }
            }
            if (strOrdPayType == Convert.ToString(AppConstants.strCC))
            {
                Gtotal1 = lblTotal.Text;
            }
            else if (strOrdPayType == Convert.ToString(AppConstants.strAFCC))
            {
                Gtotal1 = lblCompTot.Text;
            }
            strPaypal = strOrdPayType;
            HttpCookie PaypalShopping = new HttpCookie("PaypalShopping", strOrdPayType);
            Response.Cookies.Add(PaypalShopping);
            string strFund = "NoFund" + "|@|" + "Val";
            HttpCookie DepositFund = new HttpCookie("DepositFund", strFund);
            Response.Cookies.Add(DepositFund);
            string redirect = string.Empty;
            redirect += lblPayPalUrl.Text + "&business=" + lblPayEmail.Text;
            redirect += "&item_name=" + "Item Name";
            redirect += "&amount=" + String.Format("{0:0.00} ", Gtotal1);
            redirect += "&item_number=" + Convert.ToInt32(orderNum);
            redirect += "&currency_code=USD";
            redirect += "&return=" + lblWebsiteLong.Text + "/Success.aspx";
            redirect += "&cancel_return=" + lblWebsiteLong.Text + "/payPalCancel.aspx";
            redirect += "&notify_url=" + lblWebsiteLong.Text + "/WebForm1.aspx";
            redirect += "&custom=" + Convert.ToInt32(orderNum);
            Response.Redirect(redirect);
        }

        public void SplitShopString(string StrShop)
        {
            int intProdId = 0;
            int intProdQty = 0;
            string strProdNm = string.Empty;
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
            //double intTotsodaAmt = 5;
            double intTotsodaAmt = 7.95;
            string[] splitter = { "|@|" };
            string[] prodInfo = StrShop.Split(splitter, StringSplitOptions.None);
            for (int i = 0; i < prodInfo.Length; i++)
            {

                if (i % 2 == 0)
                {
                    intProdId = Convert.ToInt32(prodInfo[i]);
                    intProdQty = Convert.ToInt32(prodInfo[i + 1]);
                    dsShop = dbInfo.GetProductDetails(intProdId);
                    if (dsShop.Tables.Count > 0)
                    {
                        if (dsShop != null && dsShop.Tables.Count > 0 && dsShop.Tables[0].Rows.Count > 0)
                        {
                            strTax = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_tax"]);
                            strPrice = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_price"]);
                            //strSoda = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_soda"]);
                            strProdNm = Convert.ToString(dsShop.Tables[0].Rows[0]["product_title"]);

                            price = Math.Round(Convert.ToDouble(strPrice), 2);
                            Amt = Convert.ToDouble(intProdQty) * price;
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
                            //if (strSoda != "" && strSoda != null)
                            //{
                            //    sodaAmt = Convert.ToDouble(intProdQty) * Convert.ToDouble(strSoda);
                            //    intTotsodaAmt = intTotsodaAmt + Math.Round(Convert.ToDouble(sodaAmt), 2);
                            //}
                            i = i + 1;
                        }
                    }
                }
            }

            bool isMember = false;

            DataSet ds = dbInfo.GetUserDetailsInfo(Convert.ToInt32(Request.Cookies["userId"].Value));

            if (TotAmt < Convert.ToDouble(ViewState["DeliveryFeeCutOff"]))
            {
                isMember = Convert.ToBoolean(ds.Tables[0].Rows[0]["Users_Membership"]);

                if (ViewState["TodayDel"] != null)
                {
                    if (ViewState["TodayDel"].ToString() == "2")
                    {
                        Double.TryParse(ViewState["PickUpDeliveryFee"].ToString(), out deliveryFee);
                    }
                    else
                    {
                        if (isMember)
                        {
                            deliveryFee = Convert.ToDouble(ViewState["MemberDeliveryFee"]);
                        }
                        else
                        {
                            deliveryFee = Convert.ToDouble(ViewState["DeliveryFee"]);
                        }
                    }
                }
                else
                {
                    if (isMember)
                    {
                        deliveryFee = Convert.ToDouble(ViewState["MemberDeliveryFee"]);
                    }
                    else
                    {
                        deliveryFee = Convert.ToDouble(ViewState["DeliveryFee"]);
                    }
                }
            }
            else
            {
                deliveryFee = 0.00;
            }

            // ViewState["strTippingAmt"];
            intGroceryTot = TotAmt + intTotTax + deliveryFee + intTotsodaAmt;
            ViewState["intGroceryTot"] = intGroceryTot;
            ViewState["sutotalMinimum"] = TotAmt;
            ViewState["OrdTax"] = Convert.ToString(intTotTax);
            ViewState["OrdDelFee"] = Convert.ToString(deliveryFee);
            ViewState["OrdSoda"] = Convert.ToString(intTotsodaAmt);
            ViewState["grocerytotal"] = Convert.ToString(TotAmt); ;
        }
        public void AddressInfo()
        {
            string strAddress1 = string.Empty;
            string strAddress2 = string.Empty;
            string strCity = string.Empty;
            string strState = string.Empty;
            string strZip = string.Empty;
            string strSpecial = string.Empty;
            DataSet dsAddressInfo = new DataSet();
            DataSet dsDeleteInfo = new DataSet();
            dsAddressInfo = dbInfo.GetAddressInfo(Convert.ToInt32(Request.Cookies["userId"].Value));
            strAddress1 = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["address"]);
            ViewState["strAddress1"] = strAddress1;
            strAddress2 = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["address2"]);
            ViewState["strAddress2"] = "";
            strCity = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["City"]);
            ViewState["strCity"] = strCity;
            strState = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["State"]);
            ViewState["strState"] = strState;
            strZip = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["Zip"]);
            ViewState["strZip"] = strZip;
            strSpecial = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["instruction"]);
            ViewState["strSpecial"] = ReplaceNewLines(Convert.ToString(strSpecial), true);
            ViewState["strCompany"] = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["CompanyName"]);
            ViewState["CompanyPhone"] = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["Phone"]);
        }


        public void splitTipping()
        {
            string[] splitter = { "!*@!" };
            int intVal = 0;
            string strTippingAmt = string.Empty;

            string StrShipping = Convert.ToString(Request.Cookies["strUserTipping"].Value);
            string[] shopInfo = StrShipping.Split(splitter, StringSplitOptions.None);
            int intLen = Convert.ToInt32(shopInfo.Length);
            string strTip = string.Empty;
            string groceryTotAmt = string.Empty;
            if (intLen > 0)
            {
                groceryTotAmt = Convert.ToString(ViewState["intGroceryTot"]);
                if (groceryTotAmt != "")
                {
                    strTippingAmt = Convert.ToString(shopInfo[intVal]);
                    double selectTipVal = 0.00;
                    if (strTippingAmt == "0")
                    {
                        //strTip = "0.00";
                        if (Convert.ToString(shopInfo[intVal + 1]) == "")
                        {
                            strTip = "0.00";
                        }
                        else
                        {
                            strTip = Convert.ToString(shopInfo[intVal + 1]);
                        }
                    }

                    if (strTippingAmt == "1")
                    {

                        strTip = "0.00";
                    }
                    if (strTippingAmt == "2")
                    {
                        selectTipVal = Math.Round((Convert.ToDouble(groceryTotAmt) * 0.05), 2);
                        strTip = Convert.ToString(selectTipVal);
                    }
                    if (strTippingAmt == "3")
                    {
                        selectTipVal = Math.Round((Convert.ToDouble(groceryTotAmt) * 0.10), 2);
                        strTip = Convert.ToString(selectTipVal);
                    }
                    if (strTippingAmt == "4")
                    {
                        selectTipVal = Math.Round((Convert.ToDouble(groceryTotAmt) * 0.15), 2);
                        strTip = Convert.ToString(selectTipVal);
                    }
                    if (strTippingAmt == "5")
                    {
                        selectTipVal = Math.Round((Convert.ToDouble(groceryTotAmt) * 0.20), 2);
                        strTip = Convert.ToString(selectTipVal);
                    }
                    if (strTippingAmt == "6")
                    {
                        if (Convert.ToString(shopInfo[1]) == "")
                        {
                            strTip = "0.00";
                        }
                        else
                        {
                            strTip = Convert.ToString(shopInfo[1]);

                        }
                    }

                    if (strTip == null || strTip == "" || strTip.Trim().Length == 0)
                    {
                        strTip = "0.00";
                    }

                    ViewState["strTippingAmt"] = strTip;
                }
                else
                {
                    ViewState["strTippingAmt"] = "0.00";

                }

            }
        }
        //public void splitPickTime()
        //{
        //    string strAddress1 = string.Empty;
        //    string strAddress2 = string.Empty;
        //    string strCity = string.Empty;
        //    string strState = string.Empty;
        //    string strZip = string.Empty;
        //    string strSpecial = string.Empty;
        //    string strDelDate = string.Empty;
        //    string strTime = string.Empty;
        //    string strTimeValue = string.Empty;
        //    string strTodaysDate = string.Empty;
        //    string strTodaysTime = string.Empty;
        //    string strTodaysTimeValue = string.Empty;
        //    string strTippingAmt = string.Empty;
        //    string strDate = string.Empty;
        //    int intStartTime = 0;
        //    int intEndTime = 0;
        //    string strStartTime = string.Empty;
        //    string strAMPM = string.Empty;
        //    string strEndTime = string.Empty;
        //    string strPMAM = string.Empty;
        //    string strTodaysDelivery = string.Empty;
        //    int intTimeId = 0;
        //    string[] splitter = { "!*@!" };
        //    string StrShipping = Convert.ToString(Request.Cookies["UserShopAddInfo"].Value);
        //    string[] shopInfo = StrShipping.Split(splitter, StringSplitOptions.None);
        //    int intLen = Convert.ToInt32(shopInfo.Length);
        //    int i = 0;
        //    if (intLen > 0)
        //    {
        //        strDelDate = Convert.ToString(shopInfo[i]);
        //        ViewState["strDelDate"] = strDelDate;
        //        strDate = strDelDate.Substring(0, 10);
        //        strTodaysDate = strDate.ToString();
        //        ViewState["TodaysDate"] = strTodaysDate;
        //        strTime = Convert.ToString(shopInfo[i + 1]);
        //        SplitUserDeliveryShopAddInfo();
        //        if (Convert.ToInt32(ViewState["TodayDel"]) == 1)
        //        {
        //            ViewState["strTodaysTime"] = strTime;
        //            ViewState["strTodaysTimeValue"] = strTime;
        //        }
        //        else if (Convert.ToInt32(ViewState["TodayDel"]) == 2)
        //        {
        //            if (strTime != "")
        //            {
        //                DataSet dsTodaysDeliveryTimeValue = new DataSet();
        //                dsTodaysDeliveryTimeValue = dbInfo.GetTodayDeliveryTime(Convert.ToInt32(strTime));
        //                if (dsTodaysDeliveryTimeValue.Tables.Count > 0)
        //                {
        //                    if (dsTodaysDeliveryTimeValue != null && dsTodaysDeliveryTimeValue.Tables.Count > 0 && dsTodaysDeliveryTimeValue.Tables[0].Rows.Count > 0)
        //                    {
        //                        intTimeId = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["TimeId"]);
        //                        intStartTime = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["StartTime"]);
        //                        if (Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["StartTime"]) > 12)
        //                        {
        //                            intStartTime = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["StartTime"]) - 12;
        //                        }
        //                        else
        //                        {
        //                            intStartTime = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["StartTime"]);
        //                        }
        //                        strAMPM = Convert.ToString(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["AM_PM"]);
        //                        intEndTime = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["EndTime"]);
        //                        if (Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["EndTime"]) > 12)
        //                        {
        //                            intEndTime = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["EndTime"]) - 12;
        //                        }
        //                        else
        //                        {
        //                            intEndTime = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["EndTime"]);
        //                        }
        //                        strPMAM = Convert.ToString(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["PM_AM"]);
        //                        strTodaysTimeValue = intStartTime + " " + strAMPM + " - " + intEndTime + " " + strPMAM;
        //                    }
        //                }
        //            }
        //            ViewState["strTodaysTime"] = strTime;
        //            ViewState["strTodaysTimeValue"] = strTodaysTimeValue;
        //        }
        //        else
        //        {
        //            if (strTime != "")
        //            {
        //                DataSet dsDeliveryTimeValue = new DataSet();
        //                dsDeliveryTimeValue = dbInfo.GetDelveryTime(Convert.ToInt32(strTime));
        //                if (dsDeliveryTimeValue.Tables.Count > 0)
        //                {
        //                    if (dsDeliveryTimeValue != null && dsDeliveryTimeValue.Tables.Count > 0 && dsDeliveryTimeValue.Tables[0].Rows.Count > 0)
        //                    {
        //                        strTimeValue = Convert.ToString(dsDeliveryTimeValue.Tables[0].Rows[0]["deliverytime_time"]);
        //                    }
        //                }
        //            }
        //            ViewState["strTime"] = strTime;
        //            ViewState["strTimeValue"] = strTimeValue;
        //        }
        //        strTodaysDelivery = Convert.ToString(shopInfo[i + 2]);
        //        ViewState["strTodayDelivery"] = strTodaysDelivery;
        //    }
        //}


        public void splitPickTime()
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
            string strTodaysDate = string.Empty;
            string strTodaysTime = string.Empty;
            string strTodaysTimeValue = string.Empty;
            string strTippingAmt = string.Empty;
            string strDate = string.Empty;
            int intStartTime = 0;
            int intEndTime = 0;
            string strStartTime = string.Empty;
            string strAMPM = string.Empty;
            string strEndTime = string.Empty;
            string strPMAM = string.Empty;
            string strTodaysDelivery = string.Empty;
            int intTimeId = 0;
            string[] splitter = { "!*@!" };
            string StrShipping = Convert.ToString(Request.Cookies["UserShopAddInfo"].Value);
            string[] shopInfo = StrShipping.Split(splitter, StringSplitOptions.None);
            int intLen = Convert.ToInt32(shopInfo.Length);
            int i = 0;
            if (intLen > 0)
            {
                strDelDate = Convert.ToString(shopInfo[i]);
                ViewState["strDelDate"] = strDelDate;
                strDate = strDelDate.Substring(0, 10);
                strTodaysDate = strDate.ToString();
                ViewState["TodaysDate"] = strTodaysDate;
                strTime = Convert.ToString(shopInfo[i + 1]);
                SplitUserDeliveryShopAddInfo();

                if (Convert.ToInt32(ViewState["TodayDel"]) == 1)
                {
                    ViewState["strTime"] = strTime;
                    ViewState["strTimeValue"] = strTime;
                }
                else if (Convert.ToInt32(ViewState["TodayDel"]) == 2)
                {
                    if (strTime != "")
                    {
                        DataSet dsTodaysDeliveryTimeValue = new DataSet();
                        dsTodaysDeliveryTimeValue = dbInfo.GetTodayDeliveryTime(Convert.ToInt32(strTime));
                        if (dsTodaysDeliveryTimeValue.Tables.Count > 0)
                        {
                            if (dsTodaysDeliveryTimeValue != null && dsTodaysDeliveryTimeValue.Tables.Count > 0 && dsTodaysDeliveryTimeValue.Tables[0].Rows.Count > 0)
                            {
                                ViewState["strTimeValue"] = dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["DeliveryTime_Time"].ToString();
                            }
                        }
                    }

                    ViewState["strTime"] = strTime;
                }
                else
                {
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
                }

                if (strTime != null || strTime.Trim().Length > 0)
                {
                    if (Request.Cookies["IsSameDay"] != null)
                    {
                        if (Convert.ToBoolean(Request.Cookies["IsSameDay"].Value))
                        {
                            DataSet ds = new DataSet();
                            ds = dbInfo.SelectTimeDeatils(Convert.ToInt32(strTime));

                            if (ds.Tables.Count > 0)
                            {
                                ViewState["strTimeValue"] = GetTime(ds);
                            }
                        }
                    }
                }
            }
        }

        private string GetTime(DataSet dsTodaysDeliveryTimeValue)
        {
            int intTimeId, intStartTime, intEndTime;
            intTimeId = intStartTime = intEndTime = 0;
            intTimeId = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["TimeId"]);
            intStartTime = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["StartTime"]);

            if (Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["StartTime"]) > 12)
            {
                intStartTime = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["StartTime"]) - 12;
            }
            else
            {
                intStartTime = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["StartTime"]);
            }

            string strAMPM, strPMAM, strTodaysTimeValue;
            strAMPM = strPMAM = strTodaysTimeValue = String.Empty;
            strAMPM = Convert.ToString(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["AM_PM"]);
            intEndTime = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["EndTime"]);

            if (Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["EndTime"]) > 12)
            {
                intEndTime = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["EndTime"]) - 12;
            }
            else
            {
                intEndTime = Convert.ToInt32(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["EndTime"]);
            }

            strPMAM = Convert.ToString(dsTodaysDeliveryTimeValue.Tables[0].Rows[0]["PM_AM"]);
            strTodaysTimeValue = intStartTime + " " + strAMPM + " - " + intEndTime + " " + strPMAM;

            return strTodaysTimeValue;
        }

        public void SplitUserDeliveryShopAddInfo()
        {
            string strTodaysDelivery = string.Empty;
            string strTippingAmt = string.Empty;
            string StrShopAddInfo = Convert.ToString(Request.Cookies["UserShopAddInfo"].Value);
            int i = 0;
            string[] splitter = { "!*@!" };
            string[] shopInfo = StrShopAddInfo.Split(splitter, StringSplitOptions.None);
            int intLen = Convert.ToInt32(shopInfo.Length);
            if (intLen > 0)
            {
                if (shopInfo.Length > 2)
                {
                    strTodaysDelivery = Convert.ToString(shopInfo[i + 2]);
                    ViewState["TodayDel"] = strTodaysDelivery;
                }
                else
                {
                    strTodaysDelivery = Convert.ToString(shopInfo[i]);
                    ViewState["TodayDel"] = 3;
                }

                if (strTippingAmt == "")
                {
                    ViewState["check"] = 0;
                }
                else
                {
                    ViewState["check"] = 1;
                    string strUserDeliveryFeeNew = strTodaysDelivery;
                    HttpCookie UserDeliveryFeeTip = new HttpCookie("UserDeliveryInfoTip", strUserDeliveryFeeNew);
                    Response.Cookies.Add(UserDeliveryFeeTip);
                }
            }
        }
        //Function for the replace the \r\n value for multiline text box
        public static String ReplaceNewLines(String source, bool allowNewLines)
        {
            if (allowNewLines)
            {
                source = source.Replace("%0d%0a", "<br/>");
            }
            else
            {
                source = source.Replace("%0a", " ");
            }
            return source;
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
                        lblPayPalUrl.Text = Convert.ToString(ViewState["PayPalUrl"]);
                        ViewState["BusinessEmail"] = Convert.ToString(dtrow["PaypalEmail"]);
                        lblPayEmail.Text = Convert.ToString(dtrow["PaypalEmail"]);
                        ViewState["PayPalSubmitUrl"] = Convert.ToString(dtrow["PaypalSubUrl"]);
                        ViewState["PDTToken"] = Convert.ToString(dtrow["PDTToken"]);

                        //Authorize
                        ViewState["API_Login"] = Convert.ToString(dtrow["API_Login"]);
                        ViewState["API_TransKey"] = Convert.ToString(dtrow["API_TransKey"]);
                        ViewState["API_PostUrl"] = Convert.ToString(dtrow["API_PostUrl"]);
                        //ViewState["API_PostUrl"] = Server.MapPath("~/1001329474.pem");
                    }
                }
            }

            dbInfo.dispose();
        }

        public void InsertOrderDetails(string strOrdPayType)
        {
            string strTransId = string.Empty;
            string strRefTransid = string.Empty;
            int insertOrder = 0;
            int orderNum = 0;


            strTransId = Convert.ToString(ViewState["TransactionId"]);//new

            int StoreLocationId = 0;

            if (Request.Cookies["StoreLocationId"] != null)
            {
                if (Request.Cookies["StoreLocationId"].Value.Trim().Length > 0 && Request.Cookies["StoreLocationId"].Value != "")
                    StoreLocationId = Convert.ToInt32(Request.Cookies["StoreLocationId"].Value);
            }

            DataSet dsUserOrderInfo = new DataSet();
            dsUserOrderInfo = dbInfo.selectAllOrderInfo();
            if (dsUserOrderInfo.Tables.Count > 0)
            {
                if (dsUserOrderInfo != null && dsUserOrderInfo.Tables.Count > 0 && dsUserOrderInfo.Tables[0].Rows.Count > 0)
                {
                    orderNum = Convert.ToInt32(dsUserOrderInfo.Tables[0].Rows[0]["orders_number"]) + 1;

                }
                else
                {
                    orderNum = Convert.ToInt32(AppConstants.strOrderNm);
                }
            }

            if (strOrdPayType == Convert.ToString(AppConstants.strUK))
            {
                insertOrder = dbInfo.InsertOrderInformation1(Convert.ToInt32(Request.Cookies["userId"].Value), Convert.ToString(ViewState["strAddress1"]), Convert.ToString(ViewState["strAddress2"]), Convert.ToString(ViewState["strCity"]), Convert.ToString(ViewState["strState"]), Convert.ToString(ViewState["strZip"]), Convert.ToString(ViewState["strSpecial"]), DateTime.Now, Convert.ToDateTime(ViewState["strDelDate"]), Convert.ToString(ViewState["strTimeValue"]), Convert.ToDouble(ViewState["TotalFinal"]), Convert.ToDouble(ViewState["grocerytotal"]), Convert.ToDouble(ViewState["strTippingAmt"]), Convert.ToDouble(ViewState["OrdSoda"]), Convert.ToDouble(ViewState["OrdDelFee"]), Convert.ToDouble(ViewState["CompCost"]), orderNum, Convert.ToString(strOrdPayType), Convert.ToDouble(ViewState["OrdTax"]), Convert.ToString(TxtUkAcctName.Text), Convert.ToInt32(TxtUkAcctNo.Text), strTransId, strRefTransid, Convert.ToString(ViewState["strCompany"]), Convert.ToString(ViewState["CompanyPhone"]), Convert.ToInt32(ViewState["TodayDel"]), StoreLocationId);

            }
            else
            {
                insertOrder = dbInfo.InsertOrderInformation(Convert.ToInt32(Request.Cookies["userId"].Value), Convert.ToString(ViewState["strAddress1"]), Convert.ToString(ViewState["strAddress2"]), Convert.ToString(ViewState["strCity"]), Convert.ToString(ViewState["strState"]), Convert.ToString(ViewState["strZip"]), Convert.ToString(ViewState["strSpecial"]), DateTime.Now, Convert.ToDateTime(ViewState["strDelDate"]), Convert.ToString(ViewState["strTimeValue"]), Convert.ToDouble(ViewState["TotalFinal"]), Convert.ToDouble(ViewState["grocerytotal"]), Convert.ToDouble(ViewState["strTippingAmt"]), Convert.ToDouble(ViewState["OrdSoda"]), Convert.ToDouble(ViewState["OrdDelFee"]), Convert.ToDouble(ViewState["CompCost"]), orderNum, Convert.ToString(strOrdPayType), Convert.ToDouble(ViewState["OrdTax"]), strTransId, strRefTransid, Convert.ToString(ViewState["strCompany"]), Convert.ToString(ViewState["CompanyPhone"]), Convert.ToInt32(ViewState["TodayDel"]), StoreLocationId);
            }


            if (insertOrder > 0)
            {
                //Insert order product Information               
                InsertProductOrderInfo(insertOrder);
                //Insert Transaction Information  
                if (strOrdPayType == Convert.ToString(AppConstants.strAFCOD) || strOrdPayType == Convert.ToString(AppConstants.strAF) || strOrdPayType == Convert.ToString(AppConstants.strAFCC))
                {
                    if (Convert.ToString(ViewState["TransactionId"]) != "")
                    {
                        strTransId = Convert.ToString(ViewState["TransactionId"]);
                    }
                    InsertTransactionDetails(strOrdPayType, insertOrder, strTransId);

                }
                //Insert Loyality Fund Information  
                // InsertLoyalityFund(insertOrder);
                //update delivery capacity information
                UpdateDeliveryTime();
                Response.Redirect("OrderConfirmation.aspx?orderId=" + insertOrder, false);


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


        //            else if (totalCost >= 30 && totalCost <= 99.99)
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


        public void InsertProductOrderInfo(int OrderId)
        {
            int insertProdInfo = 0;
            int intProdId = 0;
            int intProdQty = 0;
            int intCheck = 0;
            string strProdNm = string.Empty;
            string strQty = string.Empty;
            string strPrice = string.Empty;
            DataTable dtShop = new DataTable();
            DataRow rowShop;
            DataSet dsShop = new DataSet();
            dtShop.Columns.Add("productId");
            dtShop.Columns.Add("Qty");
            dtShop.Columns.Add("price");
            dtShop.Columns.Add("title");
            string StrShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
            string[] splitter = { "|@|" };
            string[] prodInfo = StrShop.Split(splitter, StringSplitOptions.None);
            for (int i = 0; i < prodInfo.Length; i++)
            {
                if (i % 2 == 0)
                {
                    intProdId = Convert.ToInt32(prodInfo[i]);
                    intProdQty = Convert.ToInt32(prodInfo[i + 1]);
                    dsShop = dbInfo.GetProductDetails(intProdId);
                    if (dsShop.Tables.Count > 0)
                    {
                        if (dsShop != null && dsShop.Tables.Count > 0 && dsShop.Tables[0].Rows.Count > 0)
                        {
                            strProdNm = Convert.ToString(dsShop.Tables[0].Rows[0]["product_title"]);
                            strPrice = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_price"]);
                            if (dtShop.Rows.Count > 0)
                            {
                                foreach (DataRow dtrow in dtShop.Rows)
                                {
                                    if (Convert.ToString(dtrow["title"]) == strProdNm && Convert.ToInt32(dtrow["productId"]) == intProdId)
                                    {
                                        dtrow["Qty"] = Convert.ToString(Convert.ToInt32(dtrow["Qty"]) + Convert.ToInt32(intProdQty));
                                        intCheck = 1;
                                    }
                                }
                            }
                            if (intCheck == 0)
                            {
                                rowShop = dtShop.NewRow();
                                rowShop["Qty"] = Convert.ToString(intProdQty);
                                rowShop["productId"] = Convert.ToString(intProdId);
                                rowShop["price"] = Convert.ToString(Math.Round(Convert.ToDouble(strPrice), 2));
                                rowShop["title"] = strProdNm;
                                dtShop.Rows.Add(rowShop);
                            }
                            intCheck = 0;
                        }
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
        //Loyality Fund code
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
        //    dsUserInfo = dbInfo.GetUserDetailsInfoForLoyolity(Convert.ToInt32(Request.Cookies["userId"].Value));
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

        public void SplitUserDeliveryFeeAddInfo(string StrDeliveryFeeAddInfo)
        {
            string strDeliveryFee = string.Empty;
            int i = 0;
            string[] splitter = { "!*@!" };
            string[] shopInfo = StrDeliveryFeeAddInfo.Split(splitter, StringSplitOptions.None);
            int intLen = Convert.ToInt32(shopInfo.Length);
            if (intLen > 0)
            {
                ViewState["strDeliveryFee"] = strDeliveryFee;
            }
        }

        public void UpdateDeliveryTime()
        {
            try
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
            catch (Exception exc)
            {

            }

        }


        private void WebServiceAPI(string strOrdPayType)
        {
            try
            {
                string CreditCardNo = ttxPayCCNm.Text;
                string ExpMonth = txtAutoExpMM.Text;
                string EXpYear = txtAutoExpYY.Text;
                string Gtotal1 = String.Empty;
                ServicePointManager.Expect100Continue = false;

                //initialise Service Object

                FDGGWSApiOrderService oFDGGWSApiOrderService = new FDGGWSApiOrderService();

                //Set the WSDL URL

                oFDGGWSApiOrderService.Url = @"https://ws.firstdataglobalgateway.com/fdggwsapi/services/order.wsdl";

                //configure client certificate

                string path = Server.MapPath("~//WS1001329474._.1.pem");

                oFDGGWSApiOrderService.ClientCertificates.Add(X509Certificate.CreateFromCertFile(path));

                //set the Authentication Credentials

                NetworkCredential nc = new NetworkCredential("WS1001329474._.1", "SmqEYGXf");
                oFDGGWSApiOrderService.Credentials = nc;

                //Create Sale transaction request
                FDGGWSApiOrderRequest oOrderRequest = new FDGGWSApiOrderRequest();
                Transaction oTransaction = new Transaction();
                CreditCardTxType oCreditCardTxType = new CreditCardTxType();
                oCreditCardTxType.Type = CreditCardTxTypeType.sale;
                CreditCardData oCreditCardData = new CreditCardData();
                oCreditCardData.ItemsElementName = new ItemsChoiceType[] { ItemsChoiceType.CardNumber, ItemsChoiceType.ExpMonth, ItemsChoiceType.ExpYear };
                oCreditCardData.Items = new string[] { CreditCardNo, ExpMonth, EXpYear };
                oTransaction.Items = new object[] { oCreditCardTxType, oCreditCardData };

                Payment oPayment = new Payment();

                if (strOrdPayType == Convert.ToString(AppConstants.strCC))
                {
                    Gtotal1 = lblTotal.Text;
                }
                else
                {
                    Gtotal1 = lblCompTot.Text;
                }
                oPayment.ChargeTotal = Convert.ToDecimal(Gtotal1);
                oTransaction.Payment = oPayment;
                oOrderRequest.Item = oTransaction;

                //get the response

                FDGGWSApiOrderResponse oResponse = null;

                //try
                //{

                oResponse = oFDGGWSApiOrderService.FDGGWSApiOrder(oOrderRequest);
                string sApprovalCode = oResponse.TransactionResult + "::" + oResponse.ErrorMessage;
                lblMsg.Text = sApprovalCode;
                if (oResponse.TransactionResult != "APPROVED")
                {
                    lblMsg.Visible = true;
                    // lblMsg.Text = "";
                    // lblMsg.Text = "Please check Credit Card Number, Address, and Expiration Date you have entered";
                    lblMsg.Text = sApprovalCode;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    string valTid = oResponse.TransactionID;
                    ViewState["TransactionId"] = valTid;
                    InsertOrderDetails(strOrdPayType);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }



        }





        public string ParseResponse(string rsp)
        {

            //R_Time = ParseTag("r_time", rsp);
            //R_Ref = ParseTag("r_ref", rsp);
            //R_Approved = ParseTag("r_approved", rsp);
            //R_Code = ParseTag("r_code", rsp);
            //R_Authresr = ParseTag("r_authresronse", rsp);
            //R_Error = ParseTag("r_error", rsp);
            //R_OrderNum = ParseTag("r_ordernum", rsp);
            //R_Message = ParseTag("r_message", rsp);
            //R_Score = ParseTag("r_score", rsp);
            //R_TDate = ParseTag("r_tdate", rsp);
            //R_AVS = ParseTag("r_avs", rsp);
            //R_Tax = ParseTag("r_tax", rsp);
            //R_Shipping = ParseTag("r_shipping", rsp);
            //R_FraudCode = ParseTag("r_fraudCode", rsp);
            //R_ESD = ParseTag("esd", rsp);
            return "";
        }


        //Function for the replace the \r\n value for multiline text box


        protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string country = drpCountry.SelectedValue;

            dropState.bindStateDropdownCountry(drpState, country);




        }

    }
}

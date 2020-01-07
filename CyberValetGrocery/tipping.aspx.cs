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
using System.Configuration;
using System.Collections;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Globalization;
using System.Collections.Specialized;
using System.Drawing.Drawing2D;
using System.IO;


namespace CyberValetGrocery
{
    public partial class tipping : System.Web.UI.Page
    {
        DbProvider dbAddInfo = new DbProvider();
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
                    getCompanyName();
                    if (!IsPostBack)
                    {
                        if (Request.Cookies["ShoppingCart"] == null || Request.Cookies["ShoppingCart"].Value == "")
                        {

                        }
                        else
                        {
                            string StrShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);

                            DataSet ds = dbAddInfo.GetShoppingCartConstant(1);

                            ViewState["DeliveryFee"] = ds.Tables[0].Rows[0]["DeliveryFee"].ToString();
                            ViewState["MemberDeliveryFee"] = ds.Tables[0].Rows[0]["MemberDeliveryFee"].ToString();

                            SplitShopString(StrShop);
                        }
                        txtAmt.Text = "0";
                    }
                }
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
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
                    dsShop = dbAddInfo.GetProductDetails(intProdId);
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
                                if (Convert.ToInt32(strTax) == 1)
                                {
                                    rate = Amt * (Convert.ToDouble(ViewState["TaxRate_Food"]) / 100);
                                    intTotTax = intTotTax + Math.Round(Convert.ToDouble(rate), 2);
                                }
                                else if (Convert.ToInt32(strTax) == 2)
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

            if (TotAmt < Convert.ToDouble(ViewState["DeliveryFeeCutOff"]))
            {
                DataSet ds = dbAddInfo.GetUserDetailsInfo(Convert.ToInt32(Request.Cookies["userId"].Value));

                isMember = Convert.ToBoolean(ds.Tables[0].Rows[0]["Users_Membership"]);

                if (isMember)
                {
                    deliveryFee = Convert.ToDouble(ViewState["MemberDeliveryFee"]);
                }
                else
                {
                    deliveryFee = Convert.ToDouble(ViewState["DeliveryFee"]);
                }
            }
            else
            {
                deliveryFee = 0.00;
            }
            intGroceryTot = TotAmt + intTotTax + deliveryFee + intTotsodaAmt;
            lblTotal.Text = Convert.ToDecimal(intGroceryTot).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);


        }

        protected void rdTips_SelectedIndexChanged(object sender, EventArgs e)
        {
            double selectTipVal = 0.00;
            if (rdTips.SelectedValue == "1")
            {
                txtAmt.Text = "0";
            }
            if (rdTips.SelectedValue == "2")
            {
                selectTipVal = Math.Round((Convert.ToDouble(lblTotal.Text) * 0.05), 2);
                txtAmt.Text = Convert.ToString(selectTipVal);
            }
            if (rdTips.SelectedValue == "3")
            {
                selectTipVal = Math.Round((Convert.ToDouble(lblTotal.Text) * 0.10), 2);
                txtAmt.Text = Convert.ToString(selectTipVal);
            }
            if (rdTips.SelectedValue == "4")
            {
                selectTipVal = Math.Round((Convert.ToDouble(lblTotal.Text) * 0.15), 2);
                txtAmt.Text = Convert.ToString(selectTipVal);
            }
            if (rdTips.SelectedValue == "5")
            {
                selectTipVal = Math.Round((Convert.ToDouble(lblTotal.Text) * 0.20), 2);
                txtAmt.Text = Convert.ToString(selectTipVal);
            }
            if (rdTips.SelectedValue == "6")
            {
                txtAmt.Text = "0.00";
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgTip;
                        ViewState["DeliveryFeeCutOff"] = Convert.ToString(dtrow["DeliveryFeeCutOff"]);
                        ViewState["DeliveryFeeSameDay"] = Convert.ToString(dtrow["DeliveryFee"]);
                        ViewState["TaxRate_Food"] = Convert.ToString(dtrow["TaxRate_Food"]);
                        ViewState["TaxRate_NonFood"] = Convert.ToString(dtrow["TaxRate_NonFood"]);
                        //ViewState["HourDeliveryFee"] = Convert.ToString(dtrow["OneHrDeliveryFee"]);
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
        protected void btnAddTips_Click(object sender, EventArgs e)
        {
            //  int cnt = 0;

            //  string strUserTippingInfo = string.Empty;
            //  for (int i = 0; i < rdTips.Items.Count; i++)
            //  {
            //      if (rdTips.Items[i].Selected == true)
            //      {
            //          cnt = 1;
            //      }
            //  }
            //  if (cnt == 0)
            //  {
            //      strUserTippingInfo = Convert.ToString(cnt) + "!*@!" + txtAmt.Text;
            //  }
            //  else
            //  {
            //      strUserTippingInfo = rdTips.SelectedValue + "!*@!" + txtAmt.Text;
            //  }
            //  HttpCookie strUserTipping = new HttpCookie("strUserTipping", strUserTippingInfo);
            //  Response.Cookies.Add(strUserTipping);
            // Response.Redirect("payment.aspx", false);
            ////Response.Redirect(ConfigurationSettings.AppSettings["strHTTPSLinkPayment"], false);
            int cnt = 0;
            bool returnNuber;
            string strUserTippingInfo = string.Empty;
            int intCheck = 0;
            string strMsg = string.Empty;
            //   int intReturn = 0;

            returnNuber = DataValidator.IsValidNumberAndDot(Convert.ToString(txtAmt.Text));


            if (returnNuber == true)
            {

                lblMsg1.Visible = false;


                for (int i = 0; i < rdTips.Items.Count; i++)
                {
                    if (rdTips.Items[i].Selected == true)
                    {
                        cnt = 1;
                    }
                }
                if (cnt == 0)
                {
                    strUserTippingInfo = Convert.ToString(cnt) + "!*@!" + txtAmt.Text;
                }
                else
                {
                    strUserTippingInfo = rdTips.SelectedValue + "!*@!" + txtAmt.Text;
                }
                HttpCookie strUserTipping = new HttpCookie("strUserTipping", strUserTippingInfo);
                Response.Cookies.Add(strUserTipping);
                Response.Redirect("payment.aspx", false);
            }
            else
            {
                lblMsg1.Visible = true;
                strMsg = AppConstants.invalidUserRegEmail;
                lblMsg1.Text = "";
                lblMsg1.Text = strMsg;
                lblMsg1.ForeColor = System.Drawing.Color.Red;

            }
        }


    }
}


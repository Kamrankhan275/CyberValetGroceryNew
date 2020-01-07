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

namespace CyberValetGrocery
{
    public partial class orderdetails : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["userId"] == null)
                {
                    Response.Redirect("My_Account.aspx", false);
                }
                else
                {
                    BindSideLink();
                    getCompanyName();
                    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();
                    if (!IsPostBack)
                    {
                        BindOrderInformation();
                        
                    }
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
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = false;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = true;
            Panel pnlAccNoLogin = (Panel)Page.Master.FindControl("pnlAccNoLogin");
            pnlAccNoLogin.Visible = false;
            Panel pnlAccLog = (Panel)Page.Master.FindControl("pnlAccLog");
            pnlAccLog.Visible = true;


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgPastOrder;
                        ViewState["CompanyNm"] = Convert.ToString(dtrow["CompanyShortName"]);

                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void BindOrderInformation()
        {
            try
            {

                int orderId = 0;
                int userId = 0;
                orderId = Convert.ToInt32(Request.QueryString["orderId"]);
                userId = Convert.ToInt32(Request.Cookies["userId"].Value);
                string strPaymentType = string.Empty;
                string strText = string.Empty;
                double accountdebit = 0;
                int picktype = 0;
                DataSet dsUserItemList = new DataSet();
                dsUserItemList = dbInfo.GetUserDetailsInfo(userId);
                 if (dsUserItemList.Tables.Count > 0)
                 {
                     if (dsUserItemList != null && dsUserItemList.Tables.Count > 0 && dsUserItemList.Tables[0].Rows.Count > 0)
                     {


                         lblFName.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_fname"]);
                         lblLName.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_lname"]);
                         lblPhone.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_phone"]);
                         lblPhone2.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_cell"]);                                           
                     }
                 }

                   DataSet dsUserOrderList = new DataSet();
                   dsUserOrderList = dbInfo.GetUserOrderInfo(userId, orderId);
                    if (dsUserOrderList.Tables.Count > 0)
                    {
                        if (dsUserOrderList != null && dsUserOrderList.Tables.Count > 0 && dsUserOrderList.Tables[0].Rows.Count > 0)
                        {
                            lblAddress.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_address"]);
                            lblAddress2.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_address2"]);
                            lblCity.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_city"]);
                            lblState.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_state"]);
                            lblZip.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_zip"]);
                            lblOrderNumber.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_number"]);
                            lblOrederDate.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["ordered"]);

                           picktype = Convert.ToInt32(dsUserOrderList.Tables[0].Rows[0]["orders_picktype"]);

                            BindPicktype(picktype);
                            
                            
                     //lblDeliveryDateTime.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["delivery"]);
                     lblStoreLocation.Text = dbInfo.GetStoreLocationName(Convert.ToInt32(dsUserOrderList.Tables[0].Rows[0]["orders_storelocationid"]));
                          lblDeliveryDateTime.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["delivery"]) + "(" + ViewState["Picktype"] + ")";
                            lblSpecialOrInfo.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_instructions"]);        
                            lblSubtotal.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_grocerytotal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            lblTax.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_tax"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            lblSodaDeposit.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_sodadeposit"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            lblDeliveryFee.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_deliveryfee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            lblTips.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_tip"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            lblOrderTotal.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                            strPaymentType = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_paymenttype"]);
                            if (strPaymentType == Convert.ToString(AppConstants.strCOD))
                            {
                                lblPaymentMethod.Text = Convert.ToString(AppConstants.strCODDetail);

                            }
                            else if (strPaymentType == Convert.ToString(AppConstants.strCC))
                            {
                                lblPaymentMethod.Text = Convert.ToString(AppConstants.strCCDetail);

                            }
                            else if (strPaymentType == Convert.ToString(AppConstants.strAF))
                            {
                                lblPaymentMethod.Text = Convert.ToString(AppConstants.strAFDetail);

                            }
                            else if (strPaymentType == Convert.ToString(AppConstants.strAFCOD))
                            {

                                accountdebit = Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]), 2) - Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2);
                                strText = Convert.ToString(accountdebit) +" " + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2)) +" " +Convert.ToString(AppConstants.strCODDetail);
                                lblPaymentMethod.Text = strText;


                            }
                            else if (strPaymentType == Convert.ToString(AppConstants.strAFCC))
                            {

                                accountdebit = Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]), 2) - Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2);
                                //strText = Convert.ToString(accountdebit) + " " + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2)) + " " + Convert.ToString(AppConstants.strCCDetail);
                                strText = Convert.ToDecimal(accountdebit).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strCCDetail);
                                lblPaymentMethod.Text = strText;


                            }
                            else
                            {
                                lblPaymentMethod.Text = "";
                            }




                        }
                    }

                BindProductGrid();
                dbInfo.dispose();

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }

        }

        public void BindPicktype(int picktype)
        {
            int orderId = 0;
            int intpicktype = 0;
            intpicktype = picktype;
            DataSet dsUserProductList = new DataSet();
            //dsUserProductList = dbInfo.GetUserOrderProductDetail(orderId, userId);
            dsUserProductList = dbInfo.GetPickupInfo(intpicktype);

            if (dsUserProductList.Tables.Count > 0)
            {
                if (dsUserProductList != null && dsUserProductList.Tables.Count > 0 && dsUserProductList.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dtrow in dsUserProductList.Tables[0].Rows)
                    {

                        //dtrow["orderproduct_price"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orderproduct_price"]), 2));


                        ViewState["Picktype"] = Convert.ToString(dsUserProductList.Tables[0].Rows[0]["DeliveryName"]);
                    }

                }
                else
                {

                }
            }
            dbInfo.dispose();
        }
        public void BindProductGrid()
        {
            int orderId = 0;
            int userId = 0;
            orderId = Convert.ToInt32(Request.QueryString["orderId"]);
            userId = Convert.ToInt32(Request.Cookies["userId"].Value);
            DataSet dsUserProductList = new DataSet();
            dsUserProductList = dbInfo.GetUserOrderProductDetail(orderId, userId);
            if (dsUserProductList.Tables.Count > 0)
            {
                if (dsUserProductList != null && dsUserProductList.Tables.Count > 0 && dsUserProductList.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dtrow in dsUserProductList.Tables[0].Rows)
                    {

                        dtrow["orderproduct_price"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orderproduct_price"]), 2));
                        dtrow["orderproduct_quantity"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orderproduct_quantity"]), 2));


                    }
                    gridUserProductList.DataSource = dsUserProductList;
                    gridUserProductList.DataBind();
                   
                }
                else
                {
                    gridUserProductList.Visible = false;
                    lblMsg1.Text = "";
                    lblMsg1.Visible = true;
                    lblMsg1.Text = AppConstants.noRecord;
                    lblMsg1.ForeColor = System.Drawing.Color.Red;
                }
            }
            dbInfo.dispose();
        }

       

        protected void btnProd_Click(object sender, EventArgs e)
        {
            try
            {
            int intCheck=0;
            string strShopProduct = string.Empty;
            for(int i=0;i<gridUserProductList.Rows.Count;i++)
            {
                 CheckBox chkProd;                  
                 GridViewRow item = gridUserProductList.Rows[i];
                 chkProd = (CheckBox)item.FindControl("chkProd");
                 if(chkProd.Checked==true)
                 {
                     intCheck=1;

                 }
            }
                if(intCheck==0)
                {
                    lbErrlMsg.Visible=true;
                    lbErrlMsg.Text="";
                    lbErrlMsg.Text=AppConstants.pgSelectProd;


                }
                else
                {
                    for (int i = 0; i < gridUserProductList.Rows.Count; i++)
                    {
                        CheckBox chkProd;                     
                        Label lblTotalProductQty;
                        Label lblProdId;
                        GridViewRow item = gridUserProductList.Rows[i];
                        chkProd = (CheckBox)item.FindControl("chkProd");
                        lblTotalProductQty = (Label)item.FindControl("lblTotalProductQty");
                        lblProdId = (Label)item.FindControl("lblProdId");


                        if (chkProd.Checked == true)
                        {

                            if (strShopProduct == "")
                            {
                                strShopProduct = lblProdId.Text + "|@|" + lblTotalProductQty.Text;
                            }
                            else
                            {
                                strShopProduct = strShopProduct + "|@|" + lblProdId.Text + "|@|" + lblTotalProductQty.Text;
                            }
                        }
                    }
                    lbErrlMsg.Visible=false;
                    lbErrlMsg.Text="";
                    string strShopping = string.Empty;
                    string strShop = string.Empty;
                    if (Request.Cookies["ShoppingCart"] == null || Request.Cookies["ShoppingCart"].Value == "")
                    {
                        strShopping = strShopProduct;
                        HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                        Response.Cookies.Add(ShoppingCart);

                    }
                    else
                    {
                        strShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                        strShopping = strShop + "|@|"+ strShopProduct;
                        HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                        Response.Cookies.Add(ShoppingCart);

                    }
                    strShopProduct = "";
                    Response.Redirect("product_order.aspx",false);


                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }


        }

        protected void btnCheckAll_Click(object sender, EventArgs e)
        {
            lbErrlMsg.Visible = false;
            lbErrlMsg.Text = "";
            for(int i=0;i<gridUserProductList.Rows.Count;i++)
            {
                 CheckBox chkProd;                  
                 GridViewRow item = gridUserProductList.Rows[i];
                 chkProd = (CheckBox)item.FindControl("chkProd");
                 chkProd.Checked=true;
            }

        }

        protected void imgBtn_Click(object sender, ImageClickEventArgs e)
        {
           
            int intchk = 0;
            intchk = Convert.ToInt32(Request.QueryString["chk"]);
            if (intchk == 1)
            {
                Response.Redirect("viewallpast.aspx", false);

            }
            else if (intchk == 2)
            {
                Response.Redirect("MyAccount.aspx", false);

            }
        }
    }
}

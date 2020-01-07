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

namespace CyberValetGrocery
{
    public partial class SaveListAddAllPopup : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                getCompanyName();  
                BindSavedList();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

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
                        ViewState["DeliveryFeeCutOff"] = Convert.ToString(dtrow["DeliveryFeeCutOff"]);
                        ViewState["DeliveryFee"] = Convert.ToString(dtrow["DeliveryFee"]);
                        ViewState["TaxRate_Food"] = Convert.ToString(dtrow["TaxRate_Food"]);
                        ViewState["TaxRate_NonFood"] = Convert.ToString(dtrow["TaxRate_NonFood"]);

                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        public string Thumbnail(string imgName)
        {
            string urlThumbnail = string.Empty;
            if (imgName != "")
            {

                urlThumbnail = "Admin/thumbnailmainimage.aspx?imgName=" + imgName;

            }
            return urlThumbnail;
        }

        public void BindSavedList()
        {
            int intListId = 0;
            intListId = Convert.ToInt32(Request.QueryString["listId"]);
            string strListNm = string.Empty;
            string strTax = string.Empty;
            string strPrice = string.Empty;
            string strSoda = string.Empty;
            int intProdId = 0;
            string strQty = string.Empty;
            double price = 0;
            double Amt = 0;
            double TotAmt = 0;
            double sodaAmt = 0;
            double intTotsodaAmt = 0;
            double rate = 0;
            double intTotTax = 0.00;
            double intGroceryTot = 0.00;
            double deliveryFee = 0.00;
            DataTable dtShopList = new DataTable();
            DataRow rowShop;
            dtShopList.Columns.Add("product_id");
            dtShopList.Columns.Add("product_title");
            dtShopList.Columns.Add("product_image");
            dtShopList.Columns.Add("productlink_price");
            dtShopList.Columns.Add("product_size");
            dtShopList.Columns.Add("Qty");

            DataSet dsListInfo = new DataSet();
            DataSet dsShop = new DataSet();

            dsListInfo = dbInfo.GetUserSavedListDetails(intListId,Convert.ToInt32(Request.Cookies["userId"].Value));


            //if (dsListInfo.Tables.Count == null  || dsListInfo.Tables.Count == 0)
            //{



                if (dsListInfo.Tables.Count > 0)
                {
                    if (dsListInfo != null && dsListInfo.Tables.Count > 0 && dsListInfo.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dtrow in dsListInfo.Tables[0].Rows)
                        {
                            strListNm = Convert.ToString(dtrow["list_name"]);
                            strQty = Convert.ToString(dtrow["listlink_qty"]);
                            intProdId = Convert.ToInt32(dtrow["product_id"]);
                            dsShop = dbInfo.SavedListProductInfo(intProdId);
                            if (dsShop.Tables.Count > 0)
                            {
                                if (dsShop != null && dsShop.Tables.Count > 0 && dsShop.Tables[0].Rows.Count > 0)
                                {
                                    strTax = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_tax"]);
                                    strPrice = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_price"]);
                                    strSoda = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_soda"]);
                                    rowShop = dtShopList.NewRow();
                                    rowShop["Qty"] = Convert.ToString(strQty);
                                    rowShop["product_title"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_title"]);
                                    rowShop["product_size"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_size"]);
                                    rowShop["productlink_price"] = Convert.ToString(Math.Round(Convert.ToDouble(strPrice), 2));
                                    rowShop["product_id"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_id"]);
                                    if (Convert.ToString(dsShop.Tables[0].Rows[0]["product_image"]) != "")
                                    {
                                        rowShop["product_image"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_image"]);
                                    }
                                    else
                                    {
                                        rowShop["product_image"] = "no_image.gif";

                                    }
                                    dtShopList.Rows.Add(rowShop);
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



                                }
                            }




                        }
                        gridShopList.DataSource = dtShopList;
                        gridShopList.DataBind();
                        lblListNm.Text = strListNm;
                        lblSubTotVal.Text = Convert.ToString(TotAmt);
                        if (TotAmt < Convert.ToDouble(ViewState["DeliveryFeeCutOff"]))
                        {
                            deliveryFee = Convert.ToDouble(ViewState["DeliveryFee"]);

                        }
                        else
                        {
                            deliveryFee = 0.00;


                        }
                        if (intTotsodaAmt == 0)
                        {
                            lblSodaFee.Visible = false;
                            lblSodaSign.Visible = false;
                            lblSodaDepFeeTot.Visible = false;
                        }
                        else
                        {
                            lblSodaFee.Visible = true;
                            lblSodaSign.Visible = true;
                            lblSodaDepFeeTot.Visible = true;
                            lblSodaDepFeeTot.Text = "";
                            // lblSodaDepFeeTot.Text = Convert.ToString(intTotsodaAmt);
                            lblSodaDepFeeTot.Text = Convert.ToDecimal(intTotsodaAmt).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        }


                        // lblDeliveryFeeTot.Text = Convert.ToString(deliveryFee);
                        // lblTaxVal.Text = Convert.ToString(intTotTax);

                        lblDeliveryFeeTot.Text = Convert.ToDecimal(deliveryFee).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        lblTaxVal.Text = Convert.ToDecimal(intTotTax).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        intGroceryTot = TotAmt + intTotTax + deliveryFee + intTotsodaAmt;
                        //lblTotVal.Text = Convert.ToString(intGroceryTot);
                        lblTotVal.Text = Convert.ToDecimal(intGroceryTot).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                    }
                    else
                    {
                        lblCartEmpty.Visible = true;
                        lblCartEmpty.Text = "Your shopping list is currently empty.";
                        Panel1.Visible = false;

                    }

                }
                //else
                //{
                //    lblCartEmpty.Visible = true;
                //    lblCartEmpty.Text = "Your shopping list is empty.";
                //    Panel1.Visible = false;

                //}
            }
            //else
            //{
            //    lblCartEmpty.Visible = true;
            //    lblCartEmpty.Text = "Your shopping list is empty.";
            //    Panel1.Visible = false;

            //}

        
       // }

        protected void gridShopList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridShopList.PageIndex = e.NewPageIndex;
            BindSavedList();
        }
    }
}

using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using CyberValetGrocery.Class;

namespace CyberValetGrocery
{
    public partial class cart : System.Web.UI.UserControl
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                bindCart();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
                  
        }
        public void bindCart()
        {
            if (Request.Cookies["ShoppingCart"] == null)
            {
                pnlProduct.Visible = false;
                pnlNoProd.Visible = true;
               
            }
            else
            {
                pnlProduct.Visible = true;
                pnlNoProd.Visible = false;
                string strShopVal = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                if (strShopVal == "")
                {
                    pnlProduct.Visible = false;
                    pnlNoProd.Visible = true;

                }
                else
                {                   
                    SplitShopString(strShopVal);
                }


            }
        }




        public void SplitShopString(string StrShop)
        {
            int intProdId = 0;
            int intProdQty = 0;
            string strProdNm = string.Empty;
            string strPrice = string.Empty;
            int intCheck = 0;
            DataSet dsShop = new DataSet();
            DataTable dtShop = new DataTable();
            DataRow rowShop;
            dtShop.Columns.Add("Qty");
            dtShop.Columns.Add("ProdNm");
            dtShop.Columns.Add("Price");
            dtShop.Columns.Add("productId");
            double price = 0;
            double Amt = 0;
            double TotAmt = 0;

            if (StrShop != "")
            {
                string[] splitter = { "|@|" };
                string[] productInfo = StrShop.Split(splitter, StringSplitOptions.None);
                for (int i = 0; i < productInfo.Length; i++)
                {
                    rowShop = dtShop.NewRow();
                    if (i % 2 == 0)
                    {
                        intProdId = Convert.ToInt32(productInfo[i]);
                        intProdQty = Convert.ToInt32(productInfo[i + 1]);
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
                                        if (Convert.ToString(dtrow["ProdNm"]) == strProdNm && Convert.ToInt32(dtrow["productId"]) == intProdId)
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
                                    rowShop["ProdNm"] = strProdNm;
                                    rowShop["Price"] = Convert.ToString(Math.Round(Convert.ToDouble(strPrice), 2));
                                    rowShop["productId"] = Convert.ToString(intProdId);
                                    dtShop.Rows.Add(rowShop);
                                }
                                intCheck = 0;

                                price = Math.Round(Convert.ToDouble(strPrice), 2);
                                Amt = Convert.ToDouble(intProdQty) * price;
                                TotAmt = TotAmt + Amt;
                                i = i + 1;

                            }

                        }
                    }

                }
                dtlShopList.DataSource = dtShop;
                dtlShopList.DataBind();
                lblTot.Text = Convert.ToDecimal(TotAmt).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            }
            dbInfo.dispose();
        }




        public void Update(string strShopping)
        {


            SplitShopString(strShopping);
        }
          

          
        }

        


    }

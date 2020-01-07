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
    public partial class savelist : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
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
                btnSave.Attributes.Add("onclick", "clcontent();");
                BindSideLink();
                getCompanyName();
                if (!IsPostBack)
                {
                        
                        pnlSave.Visible = true;
                        pnlSuccuss.Visible = false;
                        if (Request.Cookies["ShoppingCart"] == null)
                        {
                            Response.Redirect("product_order.aspx",false);
                        }
                        else
                        {
                            
                            string strShopVal = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                            if (strShopVal != "")
                            {
                                SplitShopString(strShopVal);
                            }
                            else
                            {
                                Response.Redirect("product_order.aspx", false);
                            }


                        }
                        
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgSaveShopping;
                       

                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        public void SplitShopString(string StrShop)
        {
            int intProdId = 0;
            int intProdQty = 0;
            string strProdNm = string.Empty;
            string strPrice = string.Empty;
            int intCheck = 0;
            DataTable dtShop = new DataTable();
            DataRow rowShop;
            dtShop.Columns.Add("Qty");
            dtShop.Columns.Add("ProdNm");
            dtShop.Columns.Add("Price");
            dtShop.Columns.Add("prodId");
            DataSet dsShop = new DataSet();
            string[] splitter = { "|@|" };
            string[] prodInfo = StrShop.Split(splitter, StringSplitOptions.None);
            for (int i = 0; i < prodInfo.Length; i++)
            {
                rowShop = dtShop.NewRow();
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
                                    if (Convert.ToString(dtrow["ProdNm"]) == strProdNm && Convert.ToInt32(dtrow["prodId"]) == intProdId)
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
                                string strPriceval = "$" + Convert.ToDecimal(strPrice).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                rowShop["Price"] = Convert.ToString(strPriceval);
                                rowShop["prodId"] = intProdId;
                                dtShop.Rows.Add(rowShop);
                            }
                            intCheck = 0;


                        }

                    }
                    i = i + 1;
                }
            }
            dtlShopList.DataSource = dtShop;
            dtlShopList.DataBind();

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int intInsertList = 0;
            DataSet dsListName = new DataSet();

            dsListName = dbInfo.CheckListNameAlreadyExist(txtListNm.Text, Convert.ToInt32(Request.Cookies["userId"].Value));

            if (dsListName.Tables.Count > 0)
            {
                if (dsListName != null && dsListName.Tables.Count > 0 && dsListName.Tables[0].Rows.Count > 0)
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.strSaveListNmAlreadyExist;

                }
                else
                {
                    string strShopVal = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                    if (strShopVal == "")
                    {
                        Response.Redirect("product_order.aspx", false);

                    }
                    else
                    {
                        lblMsg.Text = "";
                        intInsertList = dbInfo.InsertSavedListInfo(txtListNm.Text, Convert.ToInt32(Request.Cookies["userId"].Value), Convert.ToInt32(AppConstants.locationId), Convert.ToInt32(AppConstants.savedListType));
                        if (intInsertList > 0)
                        {

                            int intReturn = AddListProdInfo(strShopVal, intInsertList);
                            if (intReturn == 0)
                            {
                                pnlSave.Visible = false;
                                pnlSuccuss.Visible = true;
                            }
                        }

                        else
                        {
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.strSaveListFailed;

                        }
                    }


                }

            }

              
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }


        public int AddListProdInfo(string StrShop, int intListId)
        {
            int intReturn = 0;
            int intListMap = 0;
            int intCheck = 0;
            string strProdNm = string.Empty;
            string strPrice = string.Empty;

            int intProdId = 0;
            int intProdQty = 0;
            string strQtyNew = string.Empty;
            string strProdIdNew = string.Empty;
            DataTable dtShop = new DataTable();
            DataRow rowShop;
            dtShop.Columns.Add("Qty");
            dtShop.Columns.Add("ProdNm");
            dtShop.Columns.Add("Price");
            dtShop.Columns.Add("ProdId");
            DataSet dsShop = new DataSet();
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
                                    if (Convert.ToString(dtrow["ProdNm"]) == strProdNm && Convert.ToInt32(dtrow["ProdId"]) == intProdId)
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
                                string strPriceval = "$" + Convert.ToString(Math.Round(Convert.ToDouble(strPrice), 2));
                                rowShop["Price"] = strPriceval;
                                rowShop["ProdId"] = Convert.ToString(intProdId);
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
                strProdIdNew = Convert.ToString(dtrow["ProdId"]);
                strQtyNew = Convert.ToString(dtrow["Qty"]);

                intListMap = dbInfo.InsertSavedListMappingInfo(intListId, Convert.ToInt32(strProdIdNew), Convert.ToInt32(strQtyNew));

            }
            return intReturn;

        }
        
    }
}

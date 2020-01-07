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
    public partial class product_order : System.Web.UI.Page
    {
        DbProvider dbAddInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HtmlGenericControl liItem = (HtmlGenericControl)Master.FindControl("viewcart");
                liItem.Attributes.Add("class", "selected");

                if (Request.Cookies["userId"] == null)
                {
                    Response.Redirect("LoginPage.aspx", false);
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

                        lblCartEmpty.Visible = false;
                        if (Request.Cookies["ShoppingCart"] == null)
                        {
                            lblCartEmpty.Visible = true;
                            lblCartEmpty.Text = AppConstants.pgCartEmpty;
                            pnlCart.Visible = false;
                        }
                        else
                        {
                            lblCartEmpty.Visible = false;
                            lblCartEmpty.Text = "";
                            pnlCart.Visible = true;
                            bindShoppingList();
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgShopping;
                        ViewState["DeliveryFeeCutOff"] = Convert.ToString(dtrow["DeliveryFeeCutOff"]);
                        ViewState["DeliveryFee"] = Convert.ToString(dtrow["DeliveryFee"]);
                        ViewState["TaxRate_Food"] = Convert.ToString(dtrow["TaxRate_Food"]);
                        ViewState["TaxRate_NonFood"] = Convert.ToString(dtrow["TaxRate_NonFood"]);
                        ViewState["MemberDeliveryFee"] = dtrow["MemberDeliveryFee"].ToString();
                    }
                }
            }

            dbGetCompanyName.dispose();
        }

        public void bindShoppingList()
        {
            string strShopVal = Convert.ToString(Request.Cookies["ShoppingCart"].Value);

            if (strShopVal == "")
            {
                lblCartEmpty.Visible = true;
                lblCartEmpty.Text = AppConstants.pgCartEmpty;
                pnlCart.Visible = false;
            }
            else
            {
                SplitShopString(strShopVal);
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
            double priceNew = 0;
            string image = string.Empty;
            int intCheck = 0;
            DataTable dtShop = new DataTable();
            DataRow rowShop;
            dtShop.Columns.Add("product_id");
            dtShop.Columns.Add("Qty");
            dtShop.Columns.Add("product_title");
            dtShop.Columns.Add("productlink_price");
            dtShop.Columns.Add("product_image");
            dtShop.Columns.Add("product_size");
            dtShop.Columns.Add("product_image2");
            dtShop.Columns.Add("product_description");
            DataSet dsShop = new DataSet();
            double price = 0;
            double Amt = 0;
            double TotAmt = 0;
            double sodaAmt = 0;
              //double intTotsodaAmt = 5;
              double intTotsodaAmt = 7.95;
            string[] splitter = { "|@|" };
            string[] prodInfo = StrShop.Split(splitter, StringSplitOptions.None);
            lblCartEmpty.Text = "";
            bool isMember = false;

            for (int i = 0; i < prodInfo.Length; i++)
            {
                rowShop = dtShop.NewRow();

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
                            strProdNm = Convert.ToString(dsShop.Tables[0].Rows[0]["product_title"]);
                            strPrice = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_price"]);
                            //strSoda = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_soda"]);

                            if (dtShop.Rows.Count > 0)
                            {
                                foreach (DataRow dtrow in dtShop.Rows)
                                {
                                    if (Convert.ToString(dtrow["product_title"]) == strProdNm && Convert.ToInt32(dtrow["product_id"]) == intProdId)
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
                                rowShop["product_title"] = strProdNm;
                                rowShop["product_size"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_size"]);
                                rowShop["productlink_price"] = Convert.ToString(Math.Round(Convert.ToDouble(strPrice), 2));
                                rowShop["product_id"] = Convert.ToString(intProdId);
                                rowShop["product_image2"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_image2"]);
                                rowShop["product_description"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_description"]);

                                if (Convert.ToString(dsShop.Tables[0].Rows[0]["product_image"]) != "")
                                {
                                    rowShop["product_image"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_image"]);
                                }
                                else
                                {
                                    rowShop["product_image"] = "no_image.gif";
                                }

                                dtShop.Rows.Add(rowShop);
                            }

                            intCheck = 0;
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
                        }

                        i = i + 1;
                    }
                }
            }

            dbAddInfo.dispose();
            gridShopList.DataSource = dtShop;
            gridShopList.DataBind();

            for (int i = 0; i < gridShopList.Rows.Count; i++)
            {
                Label lblProductImage2;
                Label lblProdDesc;
                Panel pnlImg2;
                Panel pnlNoImg;
                Panel pnlDescImg2;
                Panel PnlNoDescImg;
                
                GridViewRow item = gridShopList.Rows[i];
                lblProductImage2 = (Label)item.FindControl("lblProductImage2");
                lblProdDesc = (Label)item.FindControl("lblProdDesc");
                pnlImg2 = (Panel)item.FindControl("pnlImg2");
                pnlNoImg = (Panel)item.FindControl("pnlNoImg");
                pnlDescImg2 = (Panel)item.FindControl("pnlDescImg2");
                PnlNoDescImg = (Panel)item.FindControl("PnlNoDescImg");

                if ((lblProductImage2.Text == "" || lblProductImage2.Text == null) && (lblProdDesc.Text == "" || lblProdDesc.Text == null))
                {
                    PnlNoDescImg.Visible = true;
                    pnlDescImg2.Visible = false;

                    pnlImg2.Visible = false;
                    pnlNoImg.Visible = true;
                }
                else
                {
                    PnlNoDescImg.Visible = false;
                    pnlDescImg2.Visible = true;

                    pnlImg2.Visible = true;
                    pnlNoImg.Visible = false;
                }
            }            

            lblSubTotVal.Text = Convert.ToDecimal(TotAmt).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

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

                lblSodaDepFeeTot.Text = Convert.ToDecimal(intTotsodaAmt).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            }

            lblDeliveryFeeTot.Text = Convert.ToDecimal(deliveryFee).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

            lblTaxVal.Text = Convert.ToDecimal(intTotTax).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

            intGroceryTot = TotAmt + intTotTax + deliveryFee + intTotsodaAmt;
            
            lblTotVal.Text = Convert.ToDecimal(intGroceryTot).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

            DataSet dsZipVal = new DataSet();
            dsZipVal = dbAddInfo.GetMinOrderAmt(Convert.ToInt32(Request.Cookies["userId"].Value));

            if (dsZipVal.Tables.Count > 0)
            {
                if (dsZipVal != null && dsZipVal.Tables.Count > 0 && dsZipVal.Tables[0].Rows.Count > 0)
                {
                    strOrderVal = Convert.ToString(dsZipVal.Tables[0].Rows[0]["ZipOrderSize"]);
                }
            }

            dbAddInfo.dispose();

            if (strOrderVal != "")
            {
                if (TotAmt < Convert.ToDouble(strOrderVal))
                {
                    imgCheck.Visible = false;
                    pnlSuggestProd.Visible = false;
                    lblMsg.Visible = true;

                    string strMsg = AppConstants.pgMinimumOrder + " $" + Convert.ToDecimal(strOrderVal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    lblMsg.Text = strMsg;
                }
                else
                {
                    lblMsg.Visible = false;
                    lblMsg.Text = "";
                    imgCheck.Visible = true;
                    pnlSuggestProd.Visible = true;
                    DataSet dsSuggestProd = new DataSet();
                    dsSuggestProd = dbAddInfo.GetSuggestProdInfo(Convert.ToInt32(AppConstants.locationId));
                    if (dsSuggestProd.Tables.Count > 0)
                    {
                        if (dsSuggestProd != null && dsSuggestProd.Tables.Count > 0 && dsSuggestProd.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dtrow in dsSuggestProd.Tables[0].Rows)
                            {
                                if (Convert.ToString(dtrow["productlink_price"]) != "")
                                {
                                    priceNew = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                                    dtrow["productlink_price"] = Convert.ToString(priceNew);
                                }
                                image = Convert.ToString(dtrow["product_image"]);
                                if (image == "")
                                {
                                    dtrow["product_image"] = "no_image.gif";
                                }

                            }
                            gridProductList.DataSource = dsSuggestProd;
                            gridProductList.DataBind();
                            for (int i = 0; i < gridProductList.Rows.Count; i++)
                            {

                                Label lblSuggestProdDesc;
                                Panel pnlSugestDescImg2;
                                Panel PnlSugestNoDescImg;

                                Panel pnlSuggestImg2;
                                Panel pnlNoSuggestImg;

                                GridViewRow item = gridProductList.Rows[i];

                                lblSuggestProdDesc = (Label)item.FindControl("lblSuggestProdDesc");
                                pnlSugestDescImg2 = (Panel)item.FindControl("pnlSugestDescImg2");
                                PnlSugestNoDescImg = (Panel)item.FindControl("PnlSugestNoDescImg");

                                pnlSuggestImg2 = (Panel)item.FindControl("pnlSuggestImg2");
                                pnlNoSuggestImg = (Panel)item.FindControl("pnlNoSuggestImg");

                                if (lblSuggestProdDesc.Text == "" || lblSuggestProdDesc.Text == null)
                                {
                                    PnlSugestNoDescImg.Visible = true;
                                    pnlSugestDescImg2.Visible = false;

                                    pnlNoSuggestImg.Visible = true;
                                    pnlSuggestImg2.Visible = false;
                                }
                                else
                                {
                                    PnlSugestNoDescImg.Visible = false;
                                    pnlSugestDescImg2.Visible = true;


                                    pnlNoSuggestImg.Visible = false;
                                    pnlSuggestImg2.Visible = true;
                                }



                            }


                        }
                        else
                        {
                            pnlSuggestProd.Visible = false;

                        }
                    }
                    else
                    {
                        pnlSuggestProd.Visible = false;

                    }
                    dbAddInfo.dispose();

                }
            }

            ViewState["stringShoppingVal"] = StrShop;



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


        protected void gridProductList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                string strShopping = string.Empty;
                string strShop = string.Empty;


                DataValidator dataValidator = new DataValidator();
                if (e.CommandName == "AddQty")
                {

                    int intProductID = Convert.ToInt32(e.CommandArgument);
                    int prodID = 0;
                    int intErr = 0;
                    bool returnText;
                    string strFun = string.Empty;
                    for (int i = 0; i < gridProductList.Rows.Count; i++)
                    {
                        Panel pnlSuggQtyErr;
                        TextBox txtQty;
                        ImageButton btnAdd;
                        Label lblErrQty;
                        GridViewRow item = gridProductList.Rows[i];
                        txtQty = (TextBox)item.FindControl("txtQty");
                        btnAdd = (ImageButton)item.FindControl("btnAdd");
                        prodID = Convert.ToInt32(btnAdd.CommandArgument);
                        lblErrQty = (Label)item.FindControl("lblErrMsg");
                        pnlSuggQtyErr = (Panel)item.FindControl("pnlSuggQtyErr");

                        if (intProductID == prodID)
                        {
                            if (txtQty.Text != "")
                            {
                                returnText = DataValidator.IsValidNumber(Convert.ToString(txtQty.Text));
                                if (returnText == false)
                                {

                                    pnlSuggQtyErr.Visible = true;
                                    lblErrQty.Visible = true;
                                    lblErrQty.Text = AppConstants.pgOnlyNumber;
                                    intErr = 1;

                                }
                                else
                                {
                                    HideErrorBox();
                                    pnlSuggQtyErr.Visible = false;
                                    intErr = 0;
                                    lblErrQty.Visible = false;
                                    lblErrQty.Text = "";
                                    if (Request.Cookies["ShoppingCart"] == null || Request.Cookies["ShoppingCart"].Value == "")
                                    {
                                        strShopping = prodID + "|@|" + txtQty.Text;
                                        HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                                        ShoppingCart.Expires = DateTime.Now.AddDays(4);
                                        Response.Cookies.Add(ShoppingCart);

                                    }
                                    else
                                    {
                                        strShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                                        strShopping = strShop + "|@|" + prodID + "|@|" + txtQty.Text;
                                        HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                                        ShoppingCart.Expires = DateTime.Now.AddDays(4);
                                        Response.Cookies.Add(ShoppingCart);

                                    }


                                }

                            }
                        }


                    }
                    if (intErr == 0)
                    {
                        clearTxt();
                        SplitShopString(strShopping);
                    }

                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }
        public void HideErrorBox()
        {
            for (int i = 0; i < gridProductList.Rows.Count; i++)
            {

                GridViewRow item = gridProductList.Rows[i];
                Panel pnlQtyErr;
                Label lblErrQty;
                pnlQtyErr = (Panel)item.FindControl("pnlSuggQtyErr");
                lblErrQty = (Label)item.FindControl("lblErrMsg");
                pnlQtyErr.Visible = false;
                lblErrQty.Visible = false;
                lblErrQty.Text = "";
            }


        }


        public void clearTxt()
        {

            for (int i = 0; i < gridProductList.Rows.Count; i++)
            {
                GridViewRow item = gridProductList.Rows[i];
                TextBox txtQty;
                txtQty = (TextBox)item.FindControl("txtQty");
                txtQty.Text = "1";
            }

        }


        protected void gridProductList_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            try
            {
                if (GridViewSortDirection1 == SortDirection.Descending)
                {
                    lblMsg1.Visible = false;
                    GridViewSortDirection1 = SortDirection.Ascending;
                    SortGridView1(sortExpression, ASCENDING);
                }
                else
                {
                    lblMsg1.Visible = false;
                    GridViewSortDirection1 = SortDirection.Descending;
                    SortGridView1(sortExpression, DESCENDING);
                }
            }
            catch (Exception Addadvert_grid_Sortinge)
            {
                lblMsg1.Visible = true;
                lblMsg1.Text = AppConstants.adminSorry + Addadvert_grid_Sortinge.Message;
                lblMsg1.ForeColor = System.Drawing.Color.Red;
            }
        }


        public SortDirection GridViewSortDirection1
        {
            get
            {
                if (ViewState["sortDirection1"] == null)
                    ViewState["sortDirection1"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection1"];
            }
            set { ViewState["sortDirection1"] = value; }
        }

        private void SortGridView1(string sortExpression, string direction)
        {
            //  You can cache the DataTable for improving performance
            double priceNew = 0;
            string image = string.Empty;
            DataSet dsSuggestProd = new DataSet();
            dsSuggestProd = dbAddInfo.GetSuggestProdInfo(Convert.ToInt32(AppConstants.locationId));
            if (dsSuggestProd.Tables.Count > 0)
            {
                if (dsSuggestProd != null && dsSuggestProd.Tables.Count > 0 && dsSuggestProd.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsSuggestProd.Tables[0].Rows)
                    {
                        if (Convert.ToString(dtrow["productlink_price"]) != "")
                        {
                            priceNew = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                            dtrow["productlink_price"] = Convert.ToString(priceNew);
                        }
                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }

                    }
                    DataTable dtSorting = dsSuggestProd.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridProductList.DataSource = dvSorting;
                    gridProductList.DataBind();

                    for (int i = 0; i < gridProductList.Rows.Count; i++)
                    {

                        Label lblSuggestProdDesc;
                        Panel pnlSugestDescImg2;
                        Panel PnlSugestNoDescImg;


                        Panel pnlSuggestImg2;
                        Panel pnlNoSuggestImg;
                        GridViewRow item = gridProductList.Rows[i];

                        lblSuggestProdDesc = (Label)item.FindControl("lblSuggestProdDesc");
                        pnlSugestDescImg2 = (Panel)item.FindControl("pnlSugestDescImg2");
                        PnlSugestNoDescImg = (Panel)item.FindControl("PnlSugestNoDescImg");

                        pnlSuggestImg2 = (Panel)item.FindControl("pnlSuggestImg2");
                        pnlNoSuggestImg = (Panel)item.FindControl("pnlNoSuggestImg");


                        if (lblSuggestProdDesc.Text == "" || lblSuggestProdDesc.Text == null)
                        {
                            PnlSugestNoDescImg.Visible = true;
                            pnlSugestDescImg2.Visible = false;

                            pnlNoSuggestImg.Visible = true;
                            pnlSuggestImg2.Visible = false;
                        }
                        else
                        {
                            PnlSugestNoDescImg.Visible = false;
                            pnlSugestDescImg2.Visible = true;


                            pnlNoSuggestImg.Visible = false;
                            pnlSuggestImg2.Visible = true;
                        }
                    }
                }
            }
            ViewState["pagingsortExpression"] = sortExpression;
            ViewState["pagingsortdirection"] = direction;
            dbAddInfo.dispose();
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            lblCartEmpty.Text = "";
            Response.Redirect("Shop.aspx", false);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string strShopping = string.Empty;
                string strShop = string.Empty;
                DataValidator dataValidator = new DataValidator();
                bool returnText;
                int intErr = 0;
                lblCartEmpty.Text = "";
                for (int i = 0; i < gridShopList.Rows.Count; i++)
                {
                    Panel pnlShopQtyErr;
                    TextBox txtQty;
                    Label lblErrQty;
                    Label lblShopProductId;
                    GridViewRow item = gridShopList.Rows[i];
                    txtQty = (TextBox)item.FindControl("txtShopQty");
                    lblErrQty = (Label)item.FindControl("lblErrQty");
                    lblShopProductId = (Label)item.FindControl("lblShopProductId");

                    pnlShopQtyErr = (Panel)item.FindControl("pnlShopQtyErr");
                    if (txtQty.Text != "")
                    {
                        returnText = DataValidator.IsValidNumber(Convert.ToString(txtQty.Text));
                        if (returnText == false)
                        {
                            pnlShopQtyErr.Visible = true;
                            intErr = 1;
                            lblErrQty.Visible = true;
                            lblErrQty.Text = AppConstants.pgOnlyNumber;

                        }
                        else
                        {
                            pnlShopQtyErr.Visible = false;
                            intErr = 0;
                            lblErrQty.Visible = false;
                            lblErrQty.Text = "";
                            if (strShopping == "")
                            {
                                strShopping = lblShopProductId.Text + "|@|" + txtQty.Text;
                            }
                            else
                            {
                                strShopping = strShopping + "|@|" + lblShopProductId.Text + "|@|" + txtQty.Text;

                            }
                            HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                            ShoppingCart.Expires = DateTime.Now.AddDays(4);
                            Response.Cookies.Add(ShoppingCart);
                        }
                    }
                }
                if (intErr == 0)
                {
                    HideErrorBox1();
                    SplitShopString(strShopping);

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        public void HideErrorBox1()
        {
            for (int i = 0; i < gridShopList.Rows.Count; i++)
            {

                GridViewRow item = gridShopList.Rows[i];
                Panel pnlQtyErr;
                Label lblErrQty;
                pnlQtyErr = (Panel)item.FindControl("pnlShopQtyErr");
                lblErrQty = (Label)item.FindControl("lblErrQty");
                pnlQtyErr.Visible = false;
                lblErrQty.Visible = false;
                lblErrQty.Text = "";
            }
        }
        public void shopShoppping()
        {
            try
            {

                string strShopping = string.Empty;
                string strShop = string.Empty;
                DataValidator dataValidator = new DataValidator();
                int intErr = 0;
                bool returnText;
                string strFun = string.Empty;
                int id = gridProductList.Rows.Count;
                for (int i = 0; i < gridProductList.Rows.Count; i++)
                {
                    TextBox txtQty;
                    Label lblErrQty;
                    Label lblProductId;

                    GridViewRow item = gridProductList.Rows[i];
                    txtQty = (TextBox)item.FindControl("txtQty");
                    lblErrQty = (Label)item.FindControl("lblErrMsg");
                    lblProductId = (Label)item.FindControl("lblProductId");

                    if (txtQty.Text != "")
                    {
                        returnText = DataValidator.IsValidNumber(Convert.ToString(txtQty.Text));
                        if (returnText == false)
                        {
                            intErr = 1;
                            lblErrQty.Visible = true;
                            lblErrQty.Text = AppConstants.pgOnlyNumber;

                        }
                        else
                        {
                            intErr = 0;
                            lblErrQty.Visible = false;
                            lblErrQty.Text = "";
                            if (strShopping == "")
                            {
                                strShopping = lblProductId.Text + "|@|" + txtQty.Text;
                            }
                            else
                            {
                                strShopping = strShopping + "|@|" + lblProductId.Text + "|@|" + txtQty.Text;

                            }
                            HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                            Response.Cookies.Add(ShoppingCart);
                        }
                    }

                }

                SplitShopString(strShopping);
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                string strShopping = string.Empty;
                string strShop = string.Empty;
                DataValidator dataValidator = new DataValidator();
                bool returnText;
                int intErr = 0;
                int intCnt = 0;
                for (int i = 0; i < gridShopList.Rows.Count; i++)
                {
                    CheckBox chkId;
                    GridViewRow item = gridShopList.Rows[i];
                    chkId = (CheckBox)item.FindControl("chkId");
                    if (chkId.Checked == true)
                    {
                        intCnt = 1;
                    }

                }


                if (intCnt == 1)
                {
                    intCnt = 0;
                    lblCartEmpty.Visible = false;
                    lblCartEmpty.Text = "";
                    for (int i = 0; i < gridShopList.Rows.Count; i++)
                    {
                        CheckBox chkId;
                        TextBox txtQty;
                        Label lblErrQty;
                        Label lblShopProductId;
                        GridViewRow item = gridShopList.Rows[i];
                        txtQty = (TextBox)item.FindControl("txtShopQty");
                        lblErrQty = (Label)item.FindControl("lblErrQty");
                        chkId = (CheckBox)item.FindControl("chkId");
                        lblShopProductId = (Label)item.FindControl("lblShopProductId");
                        if (txtQty.Text != "")
                        {
                            returnText = DataValidator.IsValidNumber(Convert.ToString(txtQty.Text));
                            if (returnText == false)
                            {
                                intErr = 1;
                                lblErrQty.Visible = true;
                                lblErrQty.Text = AppConstants.pgOnlyNumber;

                            }
                            else
                            {
                                intErr = 0;
                                lblErrQty.Visible = false;
                                lblErrQty.Text = "";
                                if (chkId.Checked == false)
                                {
                                    if (strShopping == "")
                                    {
                                        strShopping = lblShopProductId.Text + "|@|" + txtQty.Text;
                                    }
                                    else
                                    {
                                        strShopping = strShopping + "|@|" + lblShopProductId.Text + "|@|" + txtQty.Text;

                                    }

                                }

                            }
                        }


                    }
                    if (intErr == 0)
                    {
                        if (strShopping == "")
                        {
                            HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", null);
                            ShoppingCart.Expires = DateTime.Now.AddDays(4);
                            Response.Cookies.Add(ShoppingCart);


                            lblCartEmpty.Visible = true;
                            lblCartEmpty.Text = "";
                            lblCartEmpty.Text = AppConstants.pgCartEmpty;
                            pnlCart.Visible = false;

                        }
                        else
                        {
                            HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                            ShoppingCart.Expires = DateTime.Now.AddDays(4);
                            Response.Cookies.Add(ShoppingCart);
                            SplitShopString(strShopping);
                        }

                    }
                    intErr = 0;

                }
                else
                {
                    lblCartEmpty.Visible = true;
                    lblCartEmpty.Text = "";
                    lblCartEmpty.Text = AppConstants.pgSelectProdDel;


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }



        }

        protected void imgSaveList_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("savelist.aspx", false);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            lblCartEmpty.Text = "";
            string strCoupon = string.Empty;
            strCoupon = txtCouponCode.Text;

            ScriptManager.RegisterStartupScript(this, typeof(string), "Coupon", "dhtmlmodal1.open('UserInfoCoupon', 'iframe', 'CouponPop.aspx?coupon=" + strCoupon + "', '', 'width=410px,height=240px,center=1,resize=0,scrolling=0');", true);

        }

        protected void imgCheck_Click(object sender, ImageClickEventArgs e)
        {
            lblCartEmpty.Text = "";
            Response.Redirect("confirmaddress.aspx", false);
        }




    }
}
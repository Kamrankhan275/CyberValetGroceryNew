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
using System.Drawing;
using CyberValetGrocery.Class;

namespace CyberValetGrocery
{
    public partial class products : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindSideLink();
                getCompanyName();
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                if (!IsPostBack)
                {

                    int intAisle = 0;
                    int intShelf = 0;
                    int intAisleTopId = 0;
                    intAisle = Convert.ToInt32(Request.QueryString["aisle"]);
                    intShelf = Convert.ToInt32(Request.QueryString["shelf"]);
                    intAisleTopId = Convert.ToInt32(Request.QueryString["aisletop"]);
                    // litShopping.Text = "<uc1:UserScript ID='UserScript1' runat='server' />"; 
                    DataSet dsProduct = new DataSet();
                    dsProduct = dbInfo.GetAisleInfo(intAisle, intShelf, intAisleTopId);
                    if (dsProduct.Tables.Count > 0)
                    {
                        if (dsProduct != null && dsProduct.Tables.Count > 0 && dsProduct.Tables[0].Rows.Count > 0)
                        {
                            lblAisleName.Text = Convert.ToString(dsProduct.Tables[0].Rows[0]["aisle_name"]);
                            lblShelfName.Text = Convert.ToString(dsProduct.Tables[0].Rows[0]["shelf_name"]);
                            lblShelfName1.Text = Convert.ToString(dsProduct.Tables[0].Rows[0]["shelf_name"]);
                        }
                    }
                    int intPop = BindPopularProdGrid();
                    int intProp = BindProductGrid();
                    if (intPop == 1 && intProp == 1)
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.noProd;
                        lblMsg.Visible = true;


                    }
                    else
                    {
                        lblMsg.Visible = false;

                    }

                }
                dbInfo.dispose();
            }
            catch (Exception ex)
            {
               // Response.Write(ex.Message);
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgProduct;

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

        /********** Popular  Products **************/
        public int BindPopularProdGrid()
        {
            int intRetPop = 0;
            int intAisle = 0;
            int intShelf = 0;
            double price = 0;
            double saleprice = 0;
            
            string image = string.Empty;
            intAisle = Convert.ToInt32(Request.QueryString["aisle"]);
            intShelf = Convert.ToInt32(Request.QueryString["shelf"]);

            DataSet dsProduct = new DataSet();
            dsProduct = dbInfo.GetShopPopularProductInfo(intAisle, intShelf, Convert.ToInt32(AppConstants.locationId));
            if (dsProduct.Tables.Count > 0)
            {
                if (dsProduct != null && dsProduct.Tables.Count > 0 && dsProduct.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsProduct.Tables[0].Rows)
                    {

                        if (Convert.ToString(dtrow["productlink_price"]) != "")
                        {
                            price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                            dtrow["productlink_price"] = Convert.ToString(price);
                        }
                        

                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }
                        if (Convert.ToString(dtrow["productlink_presale"]) != "")
                        {
                            saleprice = Math.Round(Convert.ToDouble(dtrow["productlink_presale"]), 2);
                            dtrow["productlink_presale"] = Convert.ToString(saleprice);
                        }

                    }
                    gridPopProdList.DataSource = dsProduct;
                    gridPopProdList.DataBind();
                    for (int i = 0; i < gridPopProdList.Rows.Count; i++)
                    {
                        Label lblPopProductImage2;
                        Label lblPopProdDesc;
                        Panel pnlPopImg2;
                        Panel pnlPopNoImg;
                        Panel pnlPopDescImg2;
                        Panel PnlPopNoDescImg;
                        GridViewRow item = gridPopProdList.Rows[i];
                        lblPopProductImage2 = (Label)item.FindControl("lblPopProductImage2");
                        lblPopProdDesc = (Label)item.FindControl("lblPopProdDesc");
                        pnlPopImg2 = (Panel)item.FindControl("pnlPopImg2");
                        pnlPopNoImg = (Panel)item.FindControl("pnlPopNoImg");
                        pnlPopDescImg2 = (Panel)item.FindControl("pnlPopDescImg2");
                        PnlPopNoDescImg = (Panel)item.FindControl("PnlPopNoDescImg");

                        Panel pnlPopPrice;
                        Label lblPopPrice;
                        Label lblPopPreSalePrice;
                        lblPopPrice = (Label)item.FindControl("lblPopPrice");
                        lblPopPreSalePrice = (Label)item.FindControl("lblPopPreSalePrice");
                        pnlPopPrice = (Panel)item.FindControl("pnlPopPrice");

                        if (lblPopPreSalePrice.Text == "" || lblPopPreSalePrice.Text == null)
                        {
                            lblPopPrice.Visible = true;
                            lblPopPreSalePrice.Visible = false;
                            pnlPopPrice.Visible = false;
                        }
                        else
                        {
                            lblPopPrice.Visible = true;
                            lblPopPreSalePrice.Visible = true;
                            pnlPopPrice.Visible = true;

                        }

                        if ((lblPopProductImage2.Text == "" || lblPopProductImage2.Text == null) && (lblPopProdDesc.Text == "" || lblPopProdDesc.Text == null))
                        {
                            PnlPopNoDescImg.Visible = true;
                            pnlPopDescImg2.Visible = false;


                            pnlPopImg2.Visible = false;
                            pnlPopNoImg.Visible = true;
                        }
                        else
                        {
                            PnlPopNoDescImg.Visible = false;
                            pnlPopDescImg2.Visible = true;

                            pnlPopImg2.Visible = true;
                            pnlPopNoImg.Visible = false;
                        }



                    }
                    intRetPop = 0;

                }
                else
                {
                    intRetPop = 1;
                    pnlPopProd.Visible = false;


                }

            }
            else
            {
                intRetPop = 1;
                pnlPopProd.Visible = false;

            }

            dbInfo.dispose();

            return intRetPop;

        }



        protected void gridPopProdList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                string strShopping = string.Empty;
                string strShop = string.Empty;


                DataValidator dataValidator = new DataValidator();
                if (e.CommandName == "AddPopQty")
                {

                    int intProductID = Convert.ToInt32(e.CommandArgument);
                    int prodID = 0;
                    int intErr = 0;
                    bool returnText;
                    string strFun = string.Empty;
                    for (int i = 0; i < gridPopProdList.Rows.Count; i++)
                    {

                        TextBox txtQty;
                        ImageButton btnAdd;
                        Label lblErrQty;
                        GridViewRow item = gridPopProdList.Rows[i];
                        txtQty = (TextBox)item.FindControl("txtPopQty");
                        btnAdd = (ImageButton)item.FindControl("btnPopAdd");
                        prodID = Convert.ToInt32(btnAdd.CommandArgument);
                        lblErrQty = (Label)item.FindControl("lblErrQty");
                        Panel pnlPopQtyErr;
                        pnlPopQtyErr = (Panel)item.FindControl("pnlPopQtyErr");

                        if (intProductID == prodID)
                        {
                            if (txtQty.Text != "")
                            {
                                returnText = DataValidator.IsValidNumber(Convert.ToString(txtQty.Text));
                                if (returnText == false)
                                {
                                    pnlPopQtyErr.Visible = true;
                                    intErr = 1;
                                    lblErrQty.Visible = true;
                                    lblErrQty.Text = AppConstants.pgOnlyNumber;
                                }
                                else
                                {
                                    HideErrorBox1();
                                    pnlPopQtyErr.Visible = false;
                                    intErr = 0;
                                    lblErrQty.Text = "";
                                    lblErrQty.Visible = false;
                                    if (Request.Cookies["ShoppingCart"] == null || Request.Cookies["ShoppingCart"].Value == "")
                                    {


                                        strShopping = prodID + "|@|" + txtQty.Text;
                                        HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                                        Response.Cookies.Add(ShoppingCart);
                                        UserScript1.bindCart();

                                    }
                                    else
                                    {
                                        strShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                                        strShopping = strShop + "|@|" + prodID + "|@|" + txtQty.Text;
                                        HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                                        Response.Cookies.Add(ShoppingCart);

                                    }


                                }

                            }
                        }


                    } 


                    if (intErr == 0)
                    {

                        UserScript1.Update(strShopping);
                        clearTxt(1);
                    }



                }

                if (e.CommandName == "SavePopAddQty")
                {
                    int intProductID = Convert.ToInt32(e.CommandArgument);
                    int prodID = 0;
                    string qty = string.Empty;
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "openSavedListProductPopUp(2695);", true);
                    for (int i = 0; i < gridPopProdList.Rows.Count; i++)
                    {
                        // qty = string.Empty;
                        TextBox txtQty;
                        GridViewRow item = gridPopProdList.Rows[i];
                        ImageButton btnSaveAdd;
                        txtQty = (TextBox)item.FindControl("txtPopQty");
                        btnSaveAdd = (ImageButton)item.FindControl("btnSavePopAdd");

                        prodID = Convert.ToInt32(btnSaveAdd.CommandArgument);
                        if (intProductID == prodID)
                        {
                            if (txtQty.Text != "")
                            {
                                qty = Convert.ToString(txtQty.Text);

                            }

                        }
                    }
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "openSavedListProductPopUp(" + intProductID + "," + qty + ");", true);

                }



            }


            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }


        public void HideErrorBox1()
        {
            for (int i = 0; i < gridPopProdList.Rows.Count; i++)
            {

                GridViewRow item = gridPopProdList.Rows[i];
                Label lblErrQty;
                Panel pnlPopQtyErr;
                lblErrQty = (Label)item.FindControl("lblErrQty");
                pnlPopQtyErr = (Panel)item.FindControl("pnlPopQtyErr");
                pnlPopQtyErr.Visible = false;
                lblErrQty.Visible = false;
                lblErrQty.Text = "";
            }


        }

        protected void gridPopProdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridPopProdList.PageIndex = e.NewPageIndex;

            if (Convert.ToString(ViewState["pagingPopsortExpression"]) == "" && Convert.ToString(ViewState["pagingPoosortdirection"]) == "")
            {
                BindPopularProdGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["pagingPopsortExpression"]), Convert.ToString(ViewState["pagingPopsortdirection"]));

            }
        }

        protected void gridPopProdList_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            try
            {
                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    lblMsg.Visible = false;
                    GridViewSortDirection = SortDirection.Descending;
                    SortGridView(sortExpression, DESCENDING);
                }
                else
                {
                    lblMsg.Visible = false;
                    GridViewSortDirection = SortDirection.Ascending;
                    SortGridView(sortExpression, ASCENDING);
                }
            }
            catch (Exception Addadvert_grid_Sortinge)
            {
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.adminSorry + Addadvert_grid_Sortinge.Message;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        private void SortGridView(string sortExpression, string direction)
        {
            int intAisle = 0;
            int intShelf = 0;
            double price = 0;
            double saleprice = 0;
            string image = string.Empty;
            intAisle = Convert.ToInt32(Request.QueryString["aisle"]);
            intShelf = Convert.ToInt32(Request.QueryString["shelf"]);

           
            DataSet dsProduct = new DataSet();
            dsProduct = dbInfo.GetShopPopularProductInfo(intAisle, intShelf, Convert.ToInt32(AppConstants.locationId));
            if (dsProduct.Tables.Count > 0)
            {
                if (dsProduct != null && dsProduct.Tables.Count > 0 && dsProduct.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsProduct.Tables[0].Rows)
                    {
                        if (Convert.ToString(dtrow["productlink_price"]) != "")
                        {
                            price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                            dtrow["productlink_price"] = Convert.ToString(price);
                        }

                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }
                        if (Convert.ToString(dtrow["productlink_presale"]) != "")
                        {
                            saleprice = Math.Round(Convert.ToDouble(dtrow["productlink_presale"]), 2);
                            dtrow["productlink_presale"] = Convert.ToString(saleprice);
                        }

                    }
                    DataTable dtSorting = dsProduct.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridPopProdList.DataSource = dvSorting;
                    gridPopProdList.DataBind();

                    for (int i = 0; i < gridPopProdList.Rows.Count; i++)
                    {
                        Label lblPopProductImage2;
                        Label lblPopProdDesc;
                        Panel pnlPopImg2;
                        Panel pnlPopNoImg;
                        Panel pnlPopDescImg2;
                        Panel PnlPopNoDescImg;
                        GridViewRow item = gridPopProdList.Rows[i];
                        lblPopProductImage2 = (Label)item.FindControl("lblPopProductImage2");
                        lblPopProdDesc = (Label)item.FindControl("lblPopProdDesc");
                        pnlPopImg2 = (Panel)item.FindControl("pnlPopImg2");
                        pnlPopNoImg = (Panel)item.FindControl("pnlPopNoImg");
                        pnlPopDescImg2 = (Panel)item.FindControl("pnlPopDescImg2");
                        PnlPopNoDescImg = (Panel)item.FindControl("PnlPopNoDescImg");

                        Panel pnlPopPrice;
                        Label lblPopPrice;
                        Label lblPopPreSalePrice;
                        lblPopPrice = (Label)item.FindControl("lblPopPrice");
                        lblPopPreSalePrice = (Label)item.FindControl("lblPopPreSalePrice");
                        pnlPopPrice = (Panel)item.FindControl("pnlPopPrice");

                        if (lblPopPreSalePrice.Text == "" || lblPopPreSalePrice.Text == null)
                        {
                            lblPopPrice.Visible = true;
                            lblPopPreSalePrice.Visible = false;
                            pnlPopPrice.Visible = false;
                        }
                        else
                        {
                            lblPopPrice.Visible = true;
                            lblPopPreSalePrice.Visible = true;
                            pnlPopPrice.Visible = true;

                        }


                        if ((lblPopProductImage2.Text == "" || lblPopProductImage2.Text == null) && (lblPopProdDesc.Text == "" || lblPopProdDesc.Text == null))
                        {
                            PnlPopNoDescImg.Visible = true;
                            pnlPopDescImg2.Visible = false;


                            pnlPopImg2.Visible = false;
                            pnlPopNoImg.Visible = true;
                        }
                        else
                        {
                            PnlPopNoDescImg.Visible = false;
                            pnlPopDescImg2.Visible = true;

                            pnlPopImg2.Visible = true;
                            pnlPopNoImg.Visible = false;
                        }


                    }
                }
            }
            ViewState["pagingPopsortExpression"] = sortExpression;
            ViewState["pagingPopsortdirection"] = direction;

            dbInfo.dispose();
        }




        /********** All Products **************/


        public int BindProductGrid()
        {
            int intRetProd = 0;
            int intAisle = 0;
            int intShelf = 0;
            double price = 0;
            double sales = 0;           
            string image = string.Empty;            
            intAisle = Convert.ToInt32(Request.QueryString["aisletop"]);
            intShelf = Convert.ToInt32(Request.QueryString["shelf"]);

            DataSet dsProduct = new DataSet();
            dsProduct = dbInfo.GetShopProductInfo(intAisle, intShelf, Convert.ToInt32(AppConstants.locationId));
            if (dsProduct.Tables.Count > 0)
            {
                if (dsProduct != null && dsProduct.Tables.Count > 0 && dsProduct.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsProduct.Tables[0].Rows)
                    {
                        if (Convert.ToString(dtrow["productlink_price"]) != "")
                        {
                            price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                            dtrow["productlink_price"] = Convert.ToString(price);
                        }

                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }
                        if (Convert.ToString(dtrow["productlink_presale"]) != "")
                        {
                            sales = Math.Round(Convert.ToDouble(dtrow["productlink_presale"]), 2);
                            dtrow["productlink_presale"] = Convert.ToString(sales);
                        }
                    }
                    gridProductList.DataSource = dsProduct;
                    gridProductList.DataBind();
                    for (int i = 0; i < gridProductList.Rows.Count; i++)
                    {
                        Label lblProductImage2;
                        Label lblProdDesc;
                        Panel pnlImg2;
                        Panel pnlNoImg;
                        Panel pnlDescImg2;
                        Panel PnlNoDescImg;


                        GridViewRow item = gridProductList.Rows[i];
                        lblProductImage2 = (Label)item.FindControl("lblProductImage2");
                        lblProdDesc = (Label)item.FindControl("lblProdDesc");
                        pnlImg2 = (Panel)item.FindControl("pnlImg2");
                        pnlNoImg = (Panel)item.FindControl("pnlNoImg");
                        pnlDescImg2 = (Panel)item.FindControl("pnlDescImg2");
                        PnlNoDescImg = (Panel)item.FindControl("PnlNoDescImg");


                        Panel pnlPrice;
                        Label lblPrice;
                        Label lblPreSalePrice;
                        lblPrice = (Label)item.FindControl("lblPrice");
                        lblPreSalePrice = (Label)item.FindControl("lblPreSalePrice");
                        pnlPrice = (Panel)item.FindControl("pnlPrice");

                        if (lblPreSalePrice.Text == "" || lblPreSalePrice.Text == null)
                        {
                            lblPrice.Visible = true;
                            lblPreSalePrice.Visible = false;
                            pnlPrice.Visible = false;
                        }
                        else
                        {
                            lblPrice.Visible = true;
                            lblPreSalePrice.Visible = true;
                            pnlPrice.Visible = true;

                        }
                       
                        

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
                    intRetProd = 0;

                }
                else
                {
                    intRetProd = 1;
                    pnlAllProd.Visible = false;
                }
            }
            else
            {
                intRetProd = 1;
                pnlAllProd.Visible = false;

            }

            dbInfo.dispose();
            return intRetProd;
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

                    //if (Request.Cookies["userId"] == null)
                    //{
                    //    Response.Redirect("LoginPage.aspx", false);

                    //}
                    //else
                    //{

                        int intProductID = Convert.ToInt32(e.CommandArgument);
                        int prodID = 0;
                        int intErr = 0;
                        bool returnText;
                        string strFun = string.Empty;
                        for (int i = 0; i < gridProductList.Rows.Count; i++)
                        {
                            TextBox txtQty;
                            ImageButton btnAdd;
                            Label lblErrQty;
                            GridViewRow item = gridProductList.Rows[i];
                            txtQty = (TextBox)item.FindControl("txtQty");
                            btnAdd = (ImageButton)item.FindControl("btnAdd");
                            lblErrQty = (Label)item.FindControl("lblErrQty1");
                            Panel pnlQtyErr;
                            pnlQtyErr = (Panel)item.FindControl("pnlQtyErr");
                            prodID = Convert.ToInt32(btnAdd.CommandArgument);
                            if (intProductID == prodID)
                            {
                                if (txtQty.Text != "")
                                {
                                    returnText = DataValidator.IsValidNumber(Convert.ToString(txtQty.Text));
                                    if (returnText == false)
                                    {
                                        pnlQtyErr.Visible = true;
                                        intErr = 1;
                                        lblErrQty.Visible = true;
                                        lblErrQty.Text = AppConstants.pgOnlyNumber;

                                    }
                                    else
                                    {
                                        pnlQtyErr.Visible = false;
                                        intErr = 0;
                                        lblErrQty.Visible = false;
                                        HideErrorBox();
                                        if (Request.Cookies["ShoppingCart"] == null || Request.Cookies["ShoppingCart"].Value == "")
                                        {


                                            strShopping = prodID + "|@|" + txtQty.Text;
                                            HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                                            Response.Cookies.Add(ShoppingCart);
                                            UserScript1.bindCart();

                                        }
                                        else
                                        {
                                            strShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                                            strShopping = strShop + "|@|" + prodID + "|@|" + txtQty.Text;
                                            HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                                            Response.Cookies.Add(ShoppingCart);

                                        }


                                    }

                                }
                            }


                        }
                        if (intErr == 0)
                        {
                            UserScript1.Update(strShopping);
                            clearTxt(2);
                        }




                   // }

                }

                if (e.CommandName == "SavePopAddQty")
                {
                    int intProductID = Convert.ToInt32(e.CommandArgument);
                    int prodID = 0;
                    string qty = string.Empty;
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "openSavedListProductPopUp(2695);", true);
                    for (int i = 0; i < gridProductList.Rows.Count; i++)
                    {
                        // qty = string.Empty;
                        TextBox txtQty;
                        GridViewRow item = gridProductList.Rows[i];
                        ImageButton btnSaveAdd;
                        txtQty = (TextBox)item.FindControl("txtQty");
                        btnSaveAdd = (ImageButton)item.FindControl("btnSavePopAdd");

                        prodID = Convert.ToInt32(btnSaveAdd.CommandArgument);
                        if (intProductID == prodID)
                        {
                            if (txtQty.Text != "")
                            {
                                qty = Convert.ToString(txtQty.Text);

                            }

                        }
                    }
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "openSavedListProductPopUp(" + intProductID + "," + qty + ");", true);

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
                pnlQtyErr = (Panel)item.FindControl("pnlQtyErr");
                lblErrQty = (Label)item.FindControl("lblErrQty1");
                pnlQtyErr.Visible = false;
                lblErrQty.Visible = false;
                lblErrQty.Text = "";
            }


        }

        public void clearTxt(int intCheck)
        {
            if (intCheck == 2)
            {
                for (int i = 0; i < gridProductList.Rows.Count; i++)
                {
                    GridViewRow item = gridProductList.Rows[i];
                    TextBox txtQty;
                    txtQty = (TextBox)item.FindControl("txtQty");
                    txtQty.Text = "1";
                }
            }
            else if (intCheck == 1)
            {
                for (int i = 0; i < gridPopProdList.Rows.Count; i++)
                {
                    TextBox txtQty;
                    GridViewRow item = gridPopProdList.Rows[i];
                    txtQty = (TextBox)item.FindControl("txtPopQty");
                    txtQty.Text = "1";
                }
            }
        }
        protected void gridProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridProductList.PageIndex = e.NewPageIndex;
            if (Convert.ToString(ViewState["pagingsortExpression"]) == "" && Convert.ToString(ViewState["pagingsortdirection"]) == "")
            {
                BindProductGrid();
            }
            else
            {
                SortGridView1(Convert.ToString(ViewState["pagingsortExpression"]), Convert.ToString(ViewState["pagingsortdirection"]));
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

            int intAisle = 0;
            int intShelf = 0;
            double price = 0;
            double sale = 0;
            
            string image = string.Empty;
            intAisle = Convert.ToInt32(Request.QueryString["aisle"]);
            intShelf = Convert.ToInt32(Request.QueryString["shelf"]);

            DataSet dsProduct = new DataSet();
            dsProduct = dbInfo.GetShopProductInfo(intAisle, intShelf, Convert.ToInt32(AppConstants.locationId));
            if (dsProduct.Tables.Count > 0)
            {
                if (dsProduct != null && dsProduct.Tables.Count > 0 && dsProduct.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsProduct.Tables[0].Rows)
                    {
                        if (Convert.ToString(dtrow["productlink_price"]) != "")
                        {
                            price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                            dtrow["productlink_price"] = Convert.ToString(price);
                        }
                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }
                        if (Convert.ToString(dtrow["productlink_presale"]) != "")
                        {
                            sale = Math.Round(Convert.ToDouble(dtrow["productlink_presale"]), 2);
                            dtrow["productlink_presale"] = Convert.ToString(sale);
                        }


                    }
                    DataTable dtSorting = dsProduct.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridProductList.DataSource = dvSorting;
                    gridProductList.DataBind();

                    for (int i = 0; i < gridProductList.Rows.Count; i++)
                    {
                        Label lblProductImage2;
                        Label lblProdDesc;
                        Panel pnlImg2;
                        Panel pnlNoImg;
                        Panel pnlDescImg2;
                        Panel PnlNoDescImg;
                        GridViewRow item = gridProductList.Rows[i];
                        lblProductImage2 = (Label)item.FindControl("lblProductImage2");
                        lblProdDesc = (Label)item.FindControl("lblProdDesc");
                        pnlImg2 = (Panel)item.FindControl("pnlImg2");
                        pnlNoImg = (Panel)item.FindControl("pnlNoImg");
                        pnlDescImg2 = (Panel)item.FindControl("pnlDescImg2");
                        PnlNoDescImg = (Panel)item.FindControl("PnlNoDescImg");


                        Panel pnlPrice;
                        Label lblPrice;
                        Label lblPreSalePrice;
                        lblPrice = (Label)item.FindControl("lblPrice");
                        lblPreSalePrice = (Label)item.FindControl("lblPreSalePrice");
                        pnlPrice = (Panel)item.FindControl("pnlPrice");

                        if (lblPreSalePrice.Text == "" || lblPreSalePrice.Text == null)
                        {
                            lblPrice.Visible = true;
                            lblPreSalePrice.Visible = false;
                            pnlPrice.Visible = false;
                        }
                        else
                        {
                            lblPrice.Visible = true;
                            lblPreSalePrice.Visible = true;
                            pnlPrice.Visible = true;

                        }

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
                }
            }
            ViewState["pagingsortExpression"] = sortExpression;
            ViewState["pagingsortdirection"] = direction;
            dbInfo.dispose();

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shop.aspx", false);
        }



       

    }
}
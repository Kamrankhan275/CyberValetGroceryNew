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
    public partial class searchresults : System.Web.UI.Page
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
                    int intChk = 0;
                    string strKey = string.Empty;
                    strKey = Convert.ToString(Request.QueryString["keyword"]);
                    intChk = Convert.ToInt32(Request.QueryString["intChk"]);
                    if (intChk == 1)
                    {
                        strKey = "#";

                    }
                    else if (intChk == 2)
                    {
                        strKey = "&";
                    }

                    ViewState["searchKeyword"] = strKey;
                    DisplaySearchResult(strKey);
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
            pnlCategory.Visible = true;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgSearchResult;


                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void DisplaySearchResult(string strKey)
        {
            int intSrc1 = BindSearchGrid1(strKey);
            int intSrc2 = BindSearchGrid2(strKey);
            int intTot = 0;
            int intUserId = 0;
            int intInsert = 0;
            if (intSrc1 == 0 || intSrc2 == 0)
            {

                if (intSrc1 == 0 && intSrc2 == 0)
                {
                    intTot = Convert.ToInt32(ViewState["SearchResultCnt1"]) + Convert.ToInt32(ViewState["SearchResultCnt2"]);

                }
                else if (intSrc1 == 0)
                {
                    intTot = Convert.ToInt32(ViewState["SearchResultCnt1"]);

                }
                else if (intSrc2 == 0)
                {
                    intTot = Convert.ToInt32(ViewState["SearchResultCnt2"]);

                }
                if (Request.Cookies["userId"] == null)
                {
                    intUserId = 0;
                    intInsert = dbInfo.InsertSearchResultInfo(strKey, DateTime.Now, Convert.ToInt32(AppConstants.locationId), intTot, intUserId);

                }
                else
                {
                    intUserId = Convert.ToInt32(Request.Cookies["userId"].Value);
                    intInsert = dbInfo.InsertSearchResultInfo(strKey, DateTime.Now, Convert.ToInt32(AppConstants.locationId), intTot, intUserId);

                }



            }
            if (intSrc1 == 1 && intSrc2 == 1)
            {
                if (Request.Cookies["userId"] == null)
                {
                    intUserId = 0;
                    intInsert = dbInfo.InsertSearchResultInfo(strKey, DateTime.Now, Convert.ToInt32(AppConstants.locationId), intTot, intUserId);

                }
                else
                {
                    intUserId = Convert.ToInt32(Request.Cookies["userId"].Value);
                    intInsert = dbInfo.InsertSearchResultInfo(strKey, DateTime.Now, Convert.ToInt32(AppConstants.locationId), intTot, intUserId);

                }
                pnlSearchRes.Visible = false;
                pnlSearchResult1.Visible = false;
                pnlNoresult.Visible = true;
                lblKey.Text = strKey;

            }

        }

        public int BindSearchGrid1(string strKey)
        {
            int intRet = 0;
            int intSearch = 0;
            DataSet dsSearchResult = new DataSet();
            dsSearchResult = dbInfo.GetSearchDetails1(strKey, Convert.ToInt32(AppConstants.locationId), intSearch);
            if (dsSearchResult.Tables.Count > 0)
            {
                if (dsSearchResult != null && dsSearchResult.Tables.Count > 0 && dsSearchResult.Tables[0].Rows.Count > 0)
                {
                    pnlSearchResult1.Visible = true;
                    lblSearch.Text = strKey;
                    gridSearchResult.DataSource = dsSearchResult;
                    gridSearchResult.DataBind();
                    intRet = 0;
                    pnlNoresult.Visible = false;
                    ViewState["SearchResultCnt1"] = dsSearchResult.Tables[0].Rows.Count;
                }
                else
                {
                    intRet = 1;
                    pnlSearchResult1.Visible = false;

                }

            }
            else
            {
                intRet = 1;
                pnlSearchResult1.Visible = false;
            }
            return intRet;




        }


        protected void gridSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridSearchResult.PageIndex = e.NewPageIndex;


            if (Convert.ToString(ViewState["pagingSearchsortExpression"]) == "" && Convert.ToString(ViewState["pagingSearchsortdirection"]) == "")
            {
                string strKey = string.Empty;
                strKey = Convert.ToString(ViewState["searchKeyword"]);
                BindSearchGrid1(strKey);
            }
            else
            {
                SortGridView1(Convert.ToString(ViewState["pagingSearchsortExpression"]), Convert.ToString(ViewState["pagingSearchsortdirection"]));

            }
        }



        protected void gridSearchResult_Sorting(object sender, GridViewSortEventArgs e)
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
            //  You can cache the DataTable for improving performance
            string strKey = string.Empty;
            strKey = Convert.ToString(ViewState["searchKeyword"]);
            int intSearch = 0;
            DataSet dsSearchResult = new DataSet();
            dsSearchResult = dbInfo.GetSearchDetails1(strKey, Convert.ToInt32(AppConstants.locationId), intSearch);
            if (dsSearchResult.Tables.Count > 0)
            {
                if (dsSearchResult != null && dsSearchResult.Tables.Count > 0 && dsSearchResult.Tables[0].Rows.Count > 0)
                {
                    pnlSearchResult1.Visible = true;
                    lblSearch.Text = strKey;
                    DataTable dtSorting = dsSearchResult.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridSearchResult.DataSource = dvSorting;
                    gridSearchResult.DataBind();
                }
            }
            ViewState["pagingSearchsortExpression"] = sortExpression;
            ViewState["pagingSearchsortdirection"] = direction;

            dbInfo.dispose();
        }


        //Product List 

        public int BindSearchGrid2(string strKey)
        {

            int intSearch = 1;
            int intRet = 0;
            double price = 0;
            double saleprice = 0;
            string image = string.Empty;

            DataSet dsSearchResult = new DataSet();
            dsSearchResult = dbInfo.GetSearchDetails1(strKey, Convert.ToInt32(AppConstants.locationId), intSearch);
            if (dsSearchResult.Tables.Count > 0)
            {
                if (dsSearchResult != null && dsSearchResult.Tables.Count > 0 && dsSearchResult.Tables[0].Rows.Count > 0)
                {
                    pnlSearchRes.Visible = true;
                    lblSerKey.Text = strKey;
                    foreach (DataRow dtrow in dsSearchResult.Tables[0].Rows)
                    {
                        if (Convert.ToString(dtrow["productlink_price"]) != "")
                        {
                            price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                            dtrow["productlink_price"] = Convert.ToString(price);
                        }
                        if (Convert.ToString(dtrow["productlink_presale"]) != "")
                        {
                            saleprice = Math.Round(Convert.ToDouble(dtrow["productlink_presale"]), 2);
                            dtrow["productlink_presale"] = Convert.ToString(saleprice);
                        }
                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }


                    }
                    gridProductList.DataSource = dsSearchResult;
                    gridProductList.DataBind();
                    intRet = 0;
                    pnlNoresult.Visible = false;
                    ViewState["SearchResultCnt2"] = dsSearchResult.Tables[0].Rows.Count;

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
                else
                {
                    intRet = 1;
                    pnlSearchRes.Visible = false;

                }

            }
            else
            {
                intRet = 1;
                pnlSearchRes.Visible = false;
            }
            return intRet;

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


        protected void gridProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridProductList.PageIndex = e.NewPageIndex;


            if (Convert.ToString(ViewState["pagingsortExpression"]) == "" && Convert.ToString(ViewState["pagingsortdirection"]) == "")
            {
                string strKey = string.Empty;
                strKey = Convert.ToString(ViewState["searchKeyword"]);
                BindSearchGrid2(strKey);
            }
            else
            {
                SortGridView1(Convert.ToString(ViewState["pagingsortExpression"]), Convert.ToString(ViewState["pagingsortdirection"]));

            }
        }


        protected void gridProductList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                string strShopping = string.Empty;
                string strShop = string.Empty;
                string codeJavaScript = string.Empty;

                DataValidator dataValidator = new DataValidator();
                if (e.CommandName == "AddQty")
                {

                    int intProductID = Convert.ToInt32(e.CommandArgument);
                    int prodID = 0;
                    int intQty = 0;
                    int intErr = 0;
                    bool returnText;
                    string strFun = string.Empty;
                    for (int i = 0; i < gridProductList.Rows.Count; i++)
                    {
                        Panel pnlSearchQtyErr;
                        TextBox txtQty;
                        ImageButton btnAdd;
                        Label lblErrQty;
                        GridViewRow item = gridProductList.Rows[i];
                        txtQty = (TextBox)item.FindControl("txtQty");
                        btnAdd = (ImageButton)item.FindControl("btnAdd");
                        prodID = Convert.ToInt32(btnAdd.CommandArgument);
                        lblErrQty = (Label)item.FindControl("lblErrQty");
                        pnlSearchQtyErr = (Panel)item.FindControl("pnlSearchQtyErr");


                        if (intProductID == prodID)
                        {
                            if (txtQty.Text != "")
                            {
                                returnText = DataValidator.IsValidNumber(Convert.ToString(txtQty.Text));
                                if (returnText == false)
                                {
                                    pnlSearchQtyErr.Visible = true;
                                    intErr = 1;
                                    lblErrQty.Visible = true;
                                    lblErrQty.Text = AppConstants.pgOnlyNumber;

                                }
                                else
                                {
                                    HideErrorBox();
                                    pnlSearchQtyErr.Visible = false;
                                    intErr = 0;
                                    intQty = Convert.ToInt32(txtQty.Text);
                                    if (Request.Cookies["ShoppingCart"] == null || Request.Cookies["ShoppingCart"].Value == "")
                                    {
                                        strShopping = prodID + "|@|" + txtQty.Text;
                                        HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                                        Response.Cookies.Add(ShoppingCart);
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
                        Response.Redirect("product_order.aspx?prodId=" + intProductID + "&qty=" + intQty, false);
                    }
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
                pnlQtyErr = (Panel)item.FindControl("pnlSearchQtyErr");
                lblErrQty = (Label)item.FindControl("lblErrQty");
                pnlQtyErr.Visible = false;
                lblErrQty.Visible = false;
                lblErrQty.Text = "";
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

            string strKey = string.Empty;
            strKey = Convert.ToString(ViewState["searchKeyword"]);
            int intSearch = 1;
            double price = 0;
            double saleprice = 0;
            string image = string.Empty;
            DataSet dsSearchResult = new DataSet();
            dsSearchResult = dbInfo.GetSearchDetails1(strKey, Convert.ToInt32(AppConstants.locationId), intSearch);
            if (dsSearchResult.Tables.Count > 0)
            {
                if (dsSearchResult != null && dsSearchResult.Tables.Count > 0 && dsSearchResult.Tables[0].Rows.Count > 0)
                {
                    pnlSearchRes.Visible = true;
                    lblSerKey.Text = strKey;
                    foreach (DataRow dtrow in dsSearchResult.Tables[0].Rows)
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
                    DataTable dtSorting = dsSearchResult.Tables[0];
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
            dbInfo.dispose();
            ViewState["pagingsortExpression"] = sortExpression;
            ViewState["pagingsortdirection"] = direction;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewSearch.Text == "")
                {
                    txtNewSearch.Text = "";
                    lblErrMsg.Text = "";
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = AppConstants.pgSearchError;
                }
                else
                {
                    ViewState["searchKeyword"] = "";
                    lblErrMsg.Text = "";
                    lblErrMsg.Visible = false;
                    string strKey = string.Empty;
                    strKey = txtNewSearch.Text.Trim();
                    ViewState["searchKeyword"] = strKey;
                    DisplaySearchResult(strKey);
                    txtNewSearch.Text = "";
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}

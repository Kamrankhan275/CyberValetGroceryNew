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

namespace CyberValetGrocery
{
    public partial class sales : System.Web.UI.Page
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
                    lblMsg.Visible = false;
                    lblMsg.Text = "";
                    BindProductGrid();
                }
            }
            catch (Exception ex)
            {
                lblMsg1.Text = ex.Message;
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgSales;
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


        public void BindProductGrid()
        {
            double price = 0;
            double presaleprice = 0;
            string image = string.Empty;

            DataSet dsProduct = new DataSet();
            dsProduct = dbInfo.GetSalesProductInfo(Convert.ToInt32(AppConstants.locationId));
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
                        if (Convert.ToString(dtrow["productlink_presale"]) != "")
                        {
                            presaleprice = Math.Round(Convert.ToDouble(dtrow["productlink_presale"]), 2);
                            dtrow["productlink_presale"] = Convert.ToString(presaleprice);
                        }

                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }
                    }
                    gridProductList.DataSource = dsProduct;
                    gridProductList.DataBind();


                    for (int i = 0; i < gridProductList.Rows.Count; i++)
                    {
                        Label lblProdDesc;
                        Panel pnlDescImg2;
                        Panel PnlNoDescImg;

                        Panel pnlImg;
                        Panel pnlNoImg;

                        GridViewRow item = gridProductList.Rows[i];

                        lblProdDesc = (Label)item.FindControl("lblProdDesc");
                        pnlDescImg2 = (Panel)item.FindControl("pnlDescImg2");
                        PnlNoDescImg = (Panel)item.FindControl("PnlNoDescImg");

                        pnlImg = (Panel)item.FindControl("pnlImg");
                        pnlNoImg = (Panel)item.FindControl("pnlNoImg");
                        Label lblProductImage2;
                        lblProductImage2 = (Label)item.FindControl("lblProductImage2");


                      if ((lblProductImage2.Text == "" || lblProductImage2.Text == null) && (lblProdDesc.Text == "" || lblProdDesc.Text == null))
                        {
                            PnlNoDescImg.Visible = true;
                            pnlDescImg2.Visible = false;

                            pnlNoImg.Visible = true;
                            pnlImg.Visible = false;
                        }
                        else
                        {
                            PnlNoDescImg.Visible = false;
                            pnlDescImg2.Visible = true;


                            pnlNoImg.Visible = false;
                            pnlImg.Visible = true;
                        }
                    }
                }
                else
                {
                    pnlAllProd.Visible = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.pgSalesErr;

                }
            }
            else
            {

                pnlAllProd.Visible = false;
                lblMsg.Visible = true;
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.pgSalesErr;

            }

            dbInfo.dispose();
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
                        Panel pnlSaleQtyErr;
                        TextBox txtQty;
                        ImageButton btnAdd;
                        Label lblErrQty;
                        GridViewRow item = gridProductList.Rows[i];
                        txtQty = (TextBox)item.FindControl("txtQty");
                        btnAdd = (ImageButton)item.FindControl("btnAdd");
                        lblErrQty = (Label)item.FindControl("lblErrQty1");
                        pnlSaleQtyErr = (Panel)item.FindControl("pnlSaleQtyErr");
                        prodID = Convert.ToInt32(btnAdd.CommandArgument);
                        if (intProductID == prodID)
                        {
                            if (txtQty.Text != "")
                            {
                                returnText = DataValidator.IsValidNumber(Convert.ToString(txtQty.Text));
                                if (returnText == false)
                                {
                                    pnlSaleQtyErr.Visible = true;
                                    intErr = 1;
                                    lblErrQty.Visible = true;
                                    lblErrQty.Text = AppConstants.pgOnlyNumber;
                                }
                                else
                                {


                                    HideErrorBox();
                                    pnlSaleQtyErr.Visible = false;
                                    intErr = 0;
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
                        clearTxt(2);
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

                lblMsg1.Text = ex.Message;
            }
        }




        public void HideErrorBox()
        {
            for (int i = 0; i < gridProductList.Rows.Count; i++)
            {

                GridViewRow item = gridProductList.Rows[i];
                Panel pnlQtyErr;
                Label lblErrQty;
                pnlQtyErr = (Panel)item.FindControl("pnlSaleQtyErr");
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


            double price = 0;
            double presaleprice = 0;
            string image = string.Empty;


            DataSet dsProduct = new DataSet();
            dsProduct = dbInfo.GetSalesProductInfo(Convert.ToInt32(AppConstants.locationId));
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

                        if (Convert.ToString(dtrow["productlink_presale"]) != "")
                        {
                            presaleprice = Math.Round(Convert.ToDouble(dtrow["productlink_presale"]), 2);
                            dtrow["productlink_presale"] = Convert.ToString(presaleprice);
                        }

                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }


                    }
                    DataTable dtSorting = dsProduct.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridProductList.DataSource = dvSorting;
                    gridProductList.DataBind();
                    for (int i = 0; i < gridProductList.Rows.Count; i++)
                    {
                        Label lblProdDesc;
                        Panel pnlDescImg2;
                        Panel PnlNoDescImg;

                        Panel pnlImg;
                        Panel pnlNoImg;

                        GridViewRow item = gridProductList.Rows[i];

                        lblProdDesc = (Label)item.FindControl("lblProdDesc");
                        pnlDescImg2 = (Panel)item.FindControl("pnlDescImg2");
                        PnlNoDescImg = (Panel)item.FindControl("PnlNoDescImg");

                        pnlImg = (Panel)item.FindControl("pnlImg");
                        pnlNoImg = (Panel)item.FindControl("pnlNoImg");

                        if (lblProdDesc.Text == "" || lblProdDesc.Text == null)
                        {
                            PnlNoDescImg.Visible = true;
                            pnlDescImg2.Visible = false;

                            pnlNoImg.Visible = true;
                            pnlImg.Visible = false;
                        }
                        else
                        {
                            PnlNoDescImg.Visible = false;
                            pnlDescImg2.Visible = true;

                            pnlNoImg.Visible = false;
                            pnlImg.Visible = true;
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

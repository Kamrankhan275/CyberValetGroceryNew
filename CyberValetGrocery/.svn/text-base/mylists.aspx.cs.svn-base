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
    public partial class mylists : System.Web.UI.Page
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
                    BindSideLink();
                    getCompanyName();
                    if (!IsPostBack)
                    {

                        BindSideLink();
                        getCompanyName();
                        if (!IsPostBack)
                        {
                            lblMsg.Text = "";
                            lblMsg.Visible = false;                          
                            BindSaveList();
                            
                        }


                    }
                }

      
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void btnStartShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("shop.aspx", false);
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgMyShoppingList;


                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void BindSaveList()
        {
            lblMsg.Text = "";
            lblMsg.Visible = false;
            DataSet dsListInfo = new DataSet();

            dsListInfo = dbInfo.GetUserSavedListInformation(Convert.ToInt32(Request.Cookies["userId"].Value));

            if (dsListInfo.Tables.Count > 0)
            {
                if (dsListInfo != null && dsListInfo.Tables.Count > 0 && dsListInfo.Tables[0].Rows.Count > 0)
                {
                    pnlSaveList.Visible = true;
                    pnlNoSaveList.Visible = false;
                    dtlShopList.DataSource = dsListInfo;
                    dtlShopList.DataBind();

                }
                else
                {
                    pnlSaveList.Visible = false;
                    pnlNoSaveList.Visible = true;

                }
            }
            else
            {
                pnlSaveList.Visible = false;
                pnlNoSaveList.Visible = true;

            }

            dbInfo.dispose();
           
        }

        protected void dtlShopList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            lblMsg.Text = "";
            lblMsg.Visible = false;
            int intListID = 0;
            intListID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "AddAllList")
            {
                string strShopping = string.Empty;
                string strShop = string.Empty;
                if (Request.Cookies["ShoppingCart"] == null || Request.Cookies["ShoppingCart"].Value == "")
                {

                    strShopping = AddProductToCart(strShop, intListID);                   
                    HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                    Response.Cookies.Add(ShoppingCart);

                }
                else
                {
                    strShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                    strShopping = AddProductToCart(strShop, intListID);                    
                    HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                    Response.Cookies.Add(ShoppingCart);

                }

                Response.Redirect("product_order.aspx", false);
           }


            if (e.CommandName == "DeleteList")
            {
                int intDelete = 0;
                 int intDeleteMap = 0;
                intDelete = dbInfo.DeleteUserSavedList(intListID,Convert.ToInt32(Request.Cookies["userId"].Value));
                if (intDelete > 0)
                {
                    intDeleteMap = dbInfo.DeleteUserSavedListMappingInfo(intListID);
                    if (intDeleteMap > 0)
                    {
                        lblMsg.Text = "";
                        lblMsg.Visible = false;
                        BindSaveList();
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Visible = true;
                        lblMsg.Text = AppConstants.strDeleteSaveListFailed;
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.strDeleteSaveListFailed;
                }

            }
        }


        public string AddProductToCart(string strShop, int intListID)
        {
            string strShopping = string.Empty;
            string strTitle = string.Empty;
            string strQty = string.Empty;
            string strPrice = string.Empty;
            int intProdId = 0;
            DataSet dsListInfo = new DataSet();
            DataSet dsShop = new DataSet();

            dsListInfo = dbInfo.GetUserSavedListDetails(intListID, Convert.ToInt32(Request.Cookies["userId"].Value));

            if (dsListInfo.Tables.Count > 0)
            {
                if (dsListInfo != null && dsListInfo.Tables.Count > 0 && dsListInfo.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsListInfo.Tables[0].Rows)
                    {
                        strQty = Convert.ToString(dtrow["listlink_qty"]);                       
                        intProdId = Convert.ToInt32(dtrow["product_id"]);

                        if (strShop == "" && strShopping == "")
                        {
                            strShopping = Convert.ToString(intProdId) + "|@|" + strQty;
                        }
                        else
                        {
                            if (strShopping == "")
                            {
                                strShopping = strShop + "|@|" + Convert.ToString(intProdId) + "|@|" + strQty;

                            }
                            else
                            {
                                strShopping = strShopping + "|@|" + Convert.ToString(intProdId) + "|@|" + strQty;


                            }

                        }
               

                    }
                }
            }

            return strShopping;


        }

        
    }
}

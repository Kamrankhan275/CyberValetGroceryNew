using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CyberValetGrocery.Class;
using System.Data;

namespace CyberValetGrocery
{
    public partial class SavelistAddProduct : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userId"] == null)
            {
                lblMsg.Text = "We're sorry, but you must be logged in to see Save Lists";
                lblMsg.Visible = true;
            }
            else
            {
                if (!IsPostBack)
                {
                    lblMsg.Text = "";
                    lblMsg.Visible = false;
                    BindSaveList();
                }
            }
        }

        public void BindSaveList()
        {
            lblMsg.Text = "";
            lblMsg.Visible = false;

            int intListId = 0;
            intListId = Convert.ToInt32(Request.QueryString["ProdId"]);
            string qty = Convert.ToString(Request.QueryString["qty"]);
            // lblMsg.Text = Convert.ToString(intListId) + "qty" + qty;
            // lblMsg.Visible = true;


            DataSet dsListInfo = new DataSet();

            dsListInfo = dbInfo.GetUserSavedListInformation(Convert.ToInt32(Request.Cookies["userId"].Value));

            if (dsListInfo.Tables.Count > 0)
            {
                if (dsListInfo != null && dsListInfo.Tables.Count > 0 && dsListInfo.Tables[0].Rows.Count > 0)
                {
                    dtlShopList.DataSource = dsListInfo;
                    dtlShopList.DataBind();

                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.strNoSaveListProd;
                    lblMsg.Visible = true;
                    lblMsg.CssClass = "ErrorTxt1";

                }
            }
            else
            {



            }
            dsListInfo.Dispose();
            dbInfo.dispose();

        }
        protected void dtlShopList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            lblMsg.Text = "";
            lblMsg.Visible = false;
            int intListID = 0;
            int prodID = 0;
            int intListMap = 0;
            intListID = Convert.ToInt32(e.CommandArgument);
            prodID = Convert.ToInt32(Request.QueryString["ProdId"]);
            string qty = Convert.ToString(Request.QueryString["qty"]);

            if (e.CommandName == "AddAllList")
            {

                DataSet dsListName = new DataSet();

                dsListName = dbInfo.CheckListProductAlreadyExist(intListID, prodID);


                if (dsListName != null && dsListName.Tables.Count > 0 && dsListName.Tables[0].Rows.Count > 0)
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.strSaveListProdAlreadyExist;
                    lblMsg.Visible = true;
                    lblMsg.CssClass = "ErrorTxt1";


                }

                else
                {


                    intListMap = dbInfo.InsertSavedListMappingInfo(intListID, Convert.ToInt32(prodID), Convert.ToInt32(qty));

                    // Response.Redirect("product_order.aspx", false);

                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.strSaveListProdAdd;
                    lblMsg.Visible = true;
                    lblMsg.CssClass = "formTextUSer";

                }


                dbInfo.dispose();

            }

        }
    }
}

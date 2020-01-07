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

namespace CyberValetGrocery.Admin
{
    public partial class ShoppingListPrint : System.Web.UI.Page
    {
        DbProvider dbShoppingList = new DbProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            getCompanyName();

            if (!IsPostBack)
            {
                try
                {
                    BindGrid();
                    getTotal();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        public void BindGrid()
        {
            string strDate = Convert.ToString(Request.QueryString["deliveryId"]);
            DataSet dtShoppingList = new DataSet();
            DataView view;

            dtShoppingList = dbShoppingList.getShoppingCartListDateWise1(strDate);

            if (Session["SortExpression"] != null && Convert.ToString(Session["SortExpression"]).Trim().Length > 0)
            {
                if (Session["SortDirection"] != null && Convert.ToString(Session["SortDirection"]).Trim().Length > 0)
                {
                    string sortDirection = Convert.ToString(Session["SortDirection"]);
                    string sortExpression = Convert.ToString(Session["SortExpression"]);

                    view = dbShoppingList.GetShoppingList(strDate, sortDirection, sortExpression);

                    if (view.Table.Rows.Count > 0)
                    {
                        gridShoppingList.DataSource = view;
                        gridShoppingList.DataBind();
                    }
                }
            }
            else
            {
                if (dtShoppingList.Tables.Count > 0)
                {
                    if (dtShoppingList != null && dtShoppingList.Tables.Count > 0 && dtShoppingList.Tables[0].Rows.Count > 0)
                    {
                        gridShoppingList.DataSource = dtShoppingList;
                        gridShoppingList.DataBind();
                    }
                }
            }           

            dbShoppingList.dispose();
        }

        //Function for get short company name for page title
        public void getCompanyName()
        {
            DbProvider dbGetCompanyName = new DbProvider();
            DataSet dsGetCompanyName = new DataSet();
            string strDate = Request.QueryString["deliveryId"];
            dsGetCompanyName = dbGetCompanyName.getShortCompanyName();

            if (dsGetCompanyName.Tables.Count > 0)
            {
                if (dsGetCompanyName != null && dsGetCompanyName.Tables.Count > 0 && dsGetCompanyName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetCompanyName.Tables[0].Rows)
                    {
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.shoppingListPrintPageTitle;
                        lblLocation.Text = Convert.ToString(dtrow["LocationName"]);
                    }
                }
            }

            lblDate.Text = strDate;
            dbGetCompanyName.dispose();
        }

        //Function for getting Info Email from database(Constant).
        public void getTotal()
        {
            string strDate = Convert.ToString(Request.QueryString["deliveryId"]);
            DataSet dsGetTotal = new DataSet();
            dsGetTotal = dbShoppingList.getShoppingCartListDateWise(strDate);

            dbShoppingList.dispose();

            string amount = "";
            string quentity = "";

            if (dsGetTotal.Tables[0].Rows.Count > 0)
            {
                if (dsGetTotal != null && dsGetTotal.Tables.Count > 0 && dsGetTotal.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetTotal.Tables[0].Rows)
                    {
                        quentity += Convert.ToString(dtrow["orderproduct_quantity"]) + ",";
                        amount += Convert.ToString(dtrow["orderproduct_price"]) + ",";
                    }
                }
            }

            string[] strAllTotalQuentity = quentity.Split(',');
            string[] strTotalAmountByProduct = amount.Split(',');
            double[] strTotalAmount = new double[strAllTotalQuentity.Length];
            double totalAmountFprTheDay = 0;

            for (int totalAmount = 0; totalAmount < strAllTotalQuentity.Length - 1; totalAmount++)
            {
                totalAmountFprTheDay += Convert.ToDouble(strAllTotalQuentity[totalAmount]) * Convert.ToDouble(strTotalAmountByProduct[totalAmount]);
            }

            lblAmount.Text = Convert.ToString(totalAmountFprTheDay);
        }
    }
}


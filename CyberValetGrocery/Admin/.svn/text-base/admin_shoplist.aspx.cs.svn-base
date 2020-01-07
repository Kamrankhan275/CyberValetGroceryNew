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
    public partial class admin_shoplist : System.Web.UI.Page
    {
        DbProvider dbShoppingList = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        protected void Page_Load(object sender, EventArgs e)
        {
            getCompanyName();
            changeLinks();
            if (!IsPostBack)
            {

                try
                {
                  
                    BindGrid();

                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }

        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbShoppingList.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminCustomers.Tables[0].Rows.Count > 0)
            {
                if (dsAdminCustomers != null && dsAdminCustomers.Tables.Count > 0 && dsAdminCustomers.Tables[0].Rows.Count > 0)
                {
                    MyDataListCustomers.DataSource = dsAdminCustomers;
                    MyDataListCustomers.DataBind();
                }

            }
            //for Site Functions

            DataList MyDataListSiteFunctions = (DataList)Page.Master.FindControl("dtlsitefunctions");
            sideType = 2;
            DataSet dsAdminSiteFunctions = dbShoppingList.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
            {
                if (dsAdminSiteFunctions != null && dsAdminSiteFunctions.Tables.Count > 0 && dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
                {
                    MyDataListSiteFunctions.DataSource = dsAdminSiteFunctions;
                    MyDataListSiteFunctions.DataBind();
                }

            }

            //for reports

            DataList MyDataListReports = (DataList)Page.Master.FindControl("dtlreports");
            sideType = 3;
            DataSet dsAdminReports = dbShoppingList.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }
            }


            foreach (DataListItem row1 in MyDataListSiteFunctions.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbSitefunctions");
                string name = MyLinkButton.Text;
                if (name == "Shopping Lists")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbShoppingList.dispose();
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.shoppingListPageTitle;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        public void BindGrid()
        {

            //getShoppingListDates
            DataSet dsShoppingListDates = new DataSet();
            dsShoppingListDates = dbShoppingList.getShoppingListDates();

            if (dsShoppingListDates.Tables.Count > 0)
            {
                if (dsShoppingListDates != null && dsShoppingListDates.Tables.Count > 0 && dsShoppingListDates.Tables[0].Rows.Count > 0)
                {
                    //check when no posts or photos found

                    gridDeliveryDateShoopingList.DataSource = dsShoppingListDates;
                    gridDeliveryDateShoopingList.DataBind();


                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            dbShoppingList.dispose();
        }

        protected void gridDeliveryDateShoopingList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDeliveryDateShoopingList.PageIndex = e.NewPageIndex;


            if (Convert.ToString(ViewState["ShoopingSortExpression"]) == "" && Convert.ToString(ViewState["ShoopingDirection"]) == "")
            {
                BindGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["ShoopingSortExpression"]), Convert.ToString(ViewState["ShoopingDirection"]));

            }
        }
        //Code for zip code grid sorting gridDeliveryDateShoopingList_Sorting
        protected void gridDeliveryDateShoopingList_Sorting(object sender, GridViewSortEventArgs e)
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
                lblMsg.Text = "Sorry, " + Addadvert_grid_Sortinge.Message;
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

            DataSet dsShoppingListDates = new DataSet();
            dsShoppingListDates = dbShoppingList.getShoppingListDates();

            if (dsShoppingListDates != null && dsShoppingListDates.Tables.Count > 0 && dsShoppingListDates.Tables[0].Rows.Count > 0)
            {
                DataTable ds1 = dsShoppingListDates.Tables[0];
                DataView dv = new DataView(ds1);
                dv.Sort = sortExpression + direction;
                gridDeliveryDateShoopingList.DataSource = dv;
                gridDeliveryDateShoopingList.DataBind();
            }
            ViewState["ShoopingSortExpression"] = sortExpression;
            ViewState["ShoopingDirection"] = direction;
            dbShoppingList.dispose();
        }
    }
}

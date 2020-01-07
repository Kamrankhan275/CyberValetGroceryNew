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
    public partial class ViewProdcutReport : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        protected void Page_Load(object sender, EventArgs e)
        {
            changeLinks();
            getCompanyName();
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
            DataSet dsAdminCustomers = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

            }


            foreach (DataListItem row1 in MyDataListReports.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbreports");
                string name = MyLinkButton.Text;
                if (name == "Product Report")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbListInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.ProductReportList;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }
        public void BindGrid()
        {
            DataSet dsProductList=new DataSet();
            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            int intshelfid = 0;
            int perPage = 0;
            string strPopular = string.Empty;
            double price = 0;
            strStartDate = Convert.ToString(Request.QueryString["sDate"]);
            strToDate = Convert.ToString(Request.QueryString["eDate"]);
            intshelfid = Convert.ToInt32(Request.QueryString["shelfId"]);
            strPopular = Convert.ToString(Request.QueryString["strPopular"]);
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            dsProductList = dbListInfo.GetProductReportListDeatils(strStartDate,strToDate,intshelfid,strPopular);
            if (dsProductList.Tables.Count > 0)
            {
                if (dsProductList != null && dsProductList.Tables.Count > 0 && dsProductList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsProductList.Tables[0].Rows)
                    {
                        price = Math.Round(Convert.ToDouble(dtrow["extended_price"]), 2);
                        //dtrow["extended_price"] = Convert.ToString(price);
                        dtrow["extended_price"] = Convert.ToDecimal(price).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    gridProductReport.PageSize = perPage;
                    gridProductReport.DataSource = dsProductList;
                    gridProductReport.DataBind();
                }
                else
                {
                    gridProductReport.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }



        }

       


     

        protected void gridProductReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridProductReport.PageIndex = e.NewPageIndex;
            if (Convert.ToString(ViewState["ProductSortExpression"]) == "" && Convert.ToString(ViewState["ProductDirection"]) == "")
            {
                BindGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["ProductSortExpression"]), Convert.ToString(ViewState["ProductDirection"]));
            }
        }





        protected void gridProductReport_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet dsProductList = new DataSet();
            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            int intshelfid = 0;
            int perPage = 0;
            string strPopular = string.Empty;
            strStartDate = Convert.ToString(Request.QueryString["sDate"]);
            strToDate = Convert.ToString(Request.QueryString["eDate"]);
            intshelfid = Convert.ToInt32(Request.QueryString["shelfId"]);
            strPopular = Convert.ToString(Request.QueryString["strPopular"]);
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            dsProductList = dbListInfo.GetProductReportListDeatils(strStartDate, strToDate, intshelfid, strPopular);
            if (dsProductList.Tables.Count > 0)
            {
                if (dsProductList != null && dsProductList.Tables.Count > 0 && dsProductList.Tables[0].Rows.Count > 0)
                {
                    gridProductReport.PageSize = perPage;
                    DataTable dtSorting = dsProductList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridProductReport.DataSource = dvSorting;
                    gridProductReport.DataBind();
                }
            }

            ViewState["ProductSortExpression"] = sortExpression;
            ViewState["ProductDirection"] = direction;
            dbListInfo.dispose();
        }





        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {

            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            int intshelfid = 0;
            int perPage = 0;
            string locId = string.Empty;
            string strPopular = string.Empty;
            strStartDate = Convert.ToString(Request.QueryString["sDate"]);
            strToDate = Convert.ToString(Request.QueryString["eDate"]);
            intshelfid = Convert.ToInt32(Request.QueryString["shelfId"]);
            strPopular = Convert.ToString(Request.QueryString["strPopular"]);
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            locId = Convert.ToString(Request.QueryString["locId"]);
            Response.Redirect("admin_product_report.aspx?check=1&shelfId=" + intshelfid + "&perPage=" + perPage + "&strPopular=" + strPopular + "&sDate=" + strStartDate + "&eDate=" + strToDate + "&locId=" + locId);
          
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            int intshelfid = 0;
            int perPage = 0;
            string locId = string.Empty;
            string strPopular = string.Empty;
            strStartDate = Convert.ToString(Request.QueryString["sDate"]);
            strToDate = Convert.ToString(Request.QueryString["eDate"]);
            intshelfid = Convert.ToInt32(Request.QueryString["shelfId"]);
            strPopular = Convert.ToString(Request.QueryString["strPopular"]);
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            locId = Convert.ToString(Request.QueryString["locId"]);
            Response.Redirect("admin_product_report.aspx?check=1&shelfId=" + intshelfid + "&perPage=" + perPage + "&strPopular=" + strPopular + "&sDate=" + strStartDate + "&eDate=" + strToDate + "&locId=" + locId);
          
        }
    }
}

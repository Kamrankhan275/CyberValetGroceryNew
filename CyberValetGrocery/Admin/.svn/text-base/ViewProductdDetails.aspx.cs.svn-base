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
using System.Configuration;
using System.Collections;
using System.Drawing.Imaging;


namespace CyberValetGrocery.Admin
{
    public partial class ViewProductdDetails : System.Web.UI.Page
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


            foreach (DataListItem row1 in MyDataListSiteFunctions.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbSitefunctions");
                string name = MyLinkButton.Text;
                if (name == "Products")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.ProductList;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void BindGrid()
        {
            int locationId = 0;
            int perPage = 0;
            int shefId = 0;
            string strKey = string.Empty;
            string image=string.Empty;
            locationId = Convert.ToInt32(Request.QueryString["loc"]);
            shefId = Convert.ToInt32(Request.QueryString["shefId"]);
            strKey = Request.QueryString["strKey"];           
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            DataSet dsProductList = new DataSet();
            double price = 0;
            double preprice = 0;
            double buyprice = 0;
            dsProductList = dbListInfo.GetProductListDeatils(locationId, shefId, strKey);         
            if (dsProductList.Tables.Count > 0)
            {
                if (dsProductList != null && dsProductList.Tables.Count > 0 && dsProductList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsProductList.Tables[0].Rows)
                    {
                        if (Convert.ToString(dtrow["productlink_price"]) != "")
                        {
                            price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                            dtrow["productlink_price"] = Convert.ToString(price);
                        }

                        if (Convert.ToString(dtrow["productlink_buyprice"]) != "")
                        {
                            buyprice = Math.Round(Convert.ToDouble(dtrow["productlink_buyprice"]), 2);
                            dtrow["productlink_buyprice"] = Convert.ToString(buyprice);
                        }
                        if (Convert.ToString(dtrow["productlink_presale"]) != "")
                        {
                            preprice = Math.Round(Convert.ToDouble(dtrow["productlink_presale"]), 2);
                            dtrow["productlink_presale"] = Convert.ToString(preprice);
                        }
                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }

                    }

                    gridProductList.PageSize = perPage;                   
                    gridProductList.DataSource = dsProductList;
                    gridProductList.DataBind();
                    
                
                }
                else
                {
                    gridProductList.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gridProductList.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

            
        }

        public string Thumbnail(string imgName)
        {
            string urlThumbnail = string.Empty;
            if (imgName != "")
            {

               urlThumbnail = "thumbnailmainimage.aspx?imgName=" + imgName;

            }
            return urlThumbnail;
        }
      



        protected void gridProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProductList.PageIndex = e.NewPageIndex;

            if (Convert.ToString(ViewState["ProductSortExpression"]) == "" && Convert.ToString(ViewState["ProductDirection"]) == "")
            {
                BindGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["ProductSortExpression"]), Convert.ToString(ViewState["ProductDirection"]));

            }
        }

        protected void gridProductList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int intProductID = 0;
                if (e.CommandName == "DeleteProduct")
                {
                    intProductID = Convert.ToInt32(e.CommandArgument);
                    BindDeleteGrid(intProductID);              



                }



            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }



        public void BindDeleteGrid(int intProductID)
        {
            int intDeleteProduct = 0;
            intDeleteProduct = dbListInfo.DeleteProductInfo(intProductID);
            BindGrid();
            
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            int locationId = 0;
            int perPage = 0;
            int shefId = 0;
            string strKey = string.Empty;
            locationId = Convert.ToInt32(Request.QueryString["loc"]);
            shefId = Convert.ToInt32(Request.QueryString["shefId"]);
            strKey = Request.QueryString["strKey"];
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            Response.Redirect("admin_product.aspx?check=1&loc=" + locationId + "&shefId=" + shefId + "&perPage=" + perPage + "&strKey=" + strKey, false);

          

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            int locationId = 0;
            int perPage = 0;
            int shefId = 0;
            string strKey = string.Empty;
            locationId = Convert.ToInt32(Request.QueryString["loc"]);
            shefId = Convert.ToInt32(Request.QueryString["shefId"]);
            strKey = Request.QueryString["strKey"];
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            Response.Redirect("admin_product.aspx?check=1&loc=" + locationId + "&shefId=" + shefId + "&perPage=" + perPage + "&strKey=" + strKey, false);

        }

        protected void gridProductList_Sorting(object sender, GridViewSortEventArgs e)
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

            int locationId = 0;
            int perPage = 0;
            int shefId = 0;
            string strKey = string.Empty;
            string image = string.Empty;
            double price = 0;
            double preprice = 0;
            double buyprice = 0;
            locationId = Convert.ToInt32(Request.QueryString["loc"]);
            shefId = Convert.ToInt32(Request.QueryString["shefId"]);
            strKey = Request.QueryString["strKey"];
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            DataSet dsProductList = new DataSet();
            dsProductList = dbListInfo.GetProductListDeatils(locationId, shefId, strKey);
            if (dsProductList.Tables.Count > 0)
            {
                if (dsProductList != null && dsProductList.Tables.Count > 0 && dsProductList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsProductList.Tables[0].Rows)
                    {
                        if (Convert.ToString(dtrow["productlink_price"]) != "")
                        {
                            price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                            dtrow["productlink_price"] = Convert.ToString(price);
                        }

                        if (Convert.ToString(dtrow["productlink_buyprice"]) != "")
                        {
                            buyprice = Math.Round(Convert.ToDouble(dtrow["productlink_buyprice"]), 2);
                            dtrow["productlink_buyprice"] = Convert.ToString(buyprice);
                        }
                        if (Convert.ToString(dtrow["productlink_presale"]) != "")
                        {
                            preprice = Math.Round(Convert.ToDouble(dtrow["productlink_presale"]), 2);
                            dtrow["productlink_presale"] = Convert.ToString(preprice);
                        }
                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }

                    }

                    gridProductList.PageSize = perPage;                
                    DataTable dtSorting = dsProductList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridProductList.DataSource = dvSorting;
                    gridProductList.DataBind();
                   
                }
            }
            ViewState["ProductSortExpression"] = sortExpression;
            ViewState["ProductDirection"] = direction;
            dbListInfo.dispose();
        }
    }
}

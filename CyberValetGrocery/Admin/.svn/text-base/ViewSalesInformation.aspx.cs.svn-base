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
    public partial class ViewSalesInformation : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 changeLinks();
                 getCompanyName();
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
                if (name == "Sale Items")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.SaleItemsList;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }




        public void BindGrid()
        {
            lblMsg.Text = "";
            string image = string.Empty;
            double price = 0;
            double preprice = 0;
            DataSet dsSalesItemList = new DataSet();
            dsSalesItemList = dbListInfo.GetSalesItemListDetails(Convert.ToInt32(AppConstants.locationId));
            if (dsSalesItemList.Tables.Count > 0)
            {
                if (dsSalesItemList != null && dsSalesItemList.Tables.Count > 0 && dsSalesItemList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsSalesItemList.Tables[0].Rows)
                    {
                        price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                        dtrow["productlink_price"] = Convert.ToString(price);
                        if (Convert.ToString(dtrow["productlink_presale"])!= "")
                        {
                            preprice = Math.Round(Convert.ToDouble(dtrow["productlink_presale"]), 2);
                            dtrow["productlink_presale"]= Convert.ToString(preprice);
                        }
                        
                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }

                    }
                    gridProductList.DataSource = dsSalesItemList;
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
      



        protected void gridProductList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int intProductID = 0;
                int intUpdate = 0;
                intProductID = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "UpdateProduct")
                {
                    for (int i = 0; i < gridProductList.Rows.Count; i++)
                    {
                       
                        GridViewRow item = gridProductList.Rows[i];
                        TextBox txtPrice;
                        TextBox txtPreSale;
                        ImageButton btnUpdate;
                        txtPrice = (TextBox)item.FindControl("txtPrice");
                        txtPreSale = (TextBox)item.FindControl("txtPerSale");
                        btnUpdate = (ImageButton)item.FindControl("btnUpdate");

                        int intComVal = Convert.ToInt32(btnUpdate.CommandArgument);

                        if (intProductID == intComVal)
                        {
                            if (txtPrice.Text != "")
                            {
                                if (txtPreSale.Text != "")
                                {

                                    intUpdate = dbListInfo.UpdateSaleInfo(intProductID, Convert.ToDouble(txtPrice.Text),Convert.ToDouble(txtPreSale.Text));
                                }
                                else
                                {
                                    intUpdate = dbListInfo.UpdateSaleInfo1(intProductID, Convert.ToDouble(txtPrice.Text));


                                }
                            }



                        }


                    }


                  

                }


                if (e.CommandName == "Hide")
                {
                     
                    for (int i = 0; i < gridProductList.Rows.Count; i++)
                    {
                        
                        GridViewRow item = gridProductList.Rows[i];
                        TextBox txtPreSale;
                        ImageButton btnHide;
                        txtPreSale = (TextBox)item.FindControl("txtPerSale");
                        btnHide = (ImageButton)item.FindControl("btnHide");

                        int intComVal = Convert.ToInt32(btnHide.CommandArgument);                     

                        if (intProductID == intComVal)
                        {
                            if (txtPreSale.Text != "")
                            {
                                intUpdate = dbListInfo.UpdatePreSaleInformation(intProductID, Convert.ToDouble(txtPreSale.Text));
                            }
                            else
                            {
                                intUpdate = dbListInfo.UpdatePreSaleInformation1(intProductID);


                            }
                          


                        }


                    }
                    BindGrid();


                }

                






            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
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

            DataSet dsSalesItemList = new DataSet();
            string image = string.Empty;
            double price = 0;
            double preprice = 0;
            dsSalesItemList = dbListInfo.GetSalesItemListDetails(Convert.ToInt32(AppConstants.locationId));
            if (dsSalesItemList.Tables.Count > 0)
            {
                if (dsSalesItemList != null && dsSalesItemList.Tables.Count > 0 && dsSalesItemList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsSalesItemList.Tables[0].Rows)
                    {
                        price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                        dtrow["productlink_price"] = Convert.ToString(price);
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

                    DataTable dtSorting = dsSalesItemList.Tables[0];
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



        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_sales.aspx", false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_sales.aspx", false);

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSales.aspx", false);

        }
    }
}

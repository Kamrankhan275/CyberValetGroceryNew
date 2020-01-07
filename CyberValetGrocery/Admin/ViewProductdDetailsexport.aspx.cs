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
using System.IO;
namespace CyberValetGrocery.Admin
{
    public partial class ViewProductdDetailsexport : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        DbProvider dbListInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        double presale;
        double price;
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
            string strUPC = string.Empty;
            string image = string.Empty;
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
            Response.Redirect("admin_UploadProductPrice.aspx?check=1&loc=" + locationId + "&shefId=" + shefId + "&perPage=" + perPage + "&strKey=" + strKey, false);

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
            Response.Redirect("admin_UploadProductPrice.aspx?check=1&loc=" + locationId + "&shefId=" + shefId + "&perPage=" + perPage + "&strKey=" + strKey, false);


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
            string strUPC = string.Empty;
            string image = string.Empty;
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
        protected void CreateCSVFile(DataTable dt, string strFilePath)
        {


            // Create the CSV file to which grid data will be exported.

            StreamWriter sw = new StreamWriter(strFilePath, false);

            // First we will write the headers.

            //DataTable dt = m_dsProducts.Tables[0];

            int iColCount = dt.Columns.Count;

            for (int i = 0; i < iColCount; i++)
            {

                sw.Write(dt.Columns[i]);

                if (i < iColCount - 1)
                {

                    sw.Write(",");

                }

            }

            sw.Write(sw.NewLine);

            // Now write all the rows.

            foreach (DataRow dr in dt.Rows)
            {

                for (int i = 0; i < iColCount; i++)
                {

                    if (!Convert.IsDBNull(dr[i]))
                    {

                        sw.Write(dr[i].ToString());

                    }

                    if (i < iColCount - 1)
                    {

                        sw.Write(",");

                    }

                }

                sw.Write(sw.NewLine);

            }

            sw.Close();



        }
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            int locationId = 0;
            int perPage = 0;
            int shefId = 0;
            string strKey = string.Empty;
            string strUPC = string.Empty;
            string image = string.Empty;
            locationId = Convert.ToInt32(Request.QueryString["loc"]);
            shefId = Convert.ToInt32(Request.QueryString["shefId"]);
            strKey = Request.QueryString["strKey"];
            
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            DataSet dsProductList = new DataSet();
            double price = 0;
            double preprice = 0;
            double buyprice = 0;
            dsProductList = dbListInfo.GetProductListDeatils1(locationId, shefId, strKey); 
            DataTable dt1 = dsProductList.Tables[0];
            string strFileName = "/ProductDetail.csv";
            // CreateCSVFile(dt1,strFileName);     

            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader("content-disposition", "attachment;filename=" + strFileName);
           //StreamWriter sw = new StreamWriter(strFilePath, false);
            //Response.AddHeader("content-disposition", "attachment;filename=" + strFileName);

            if (dsProductList.Tables.Count > 0)
            {
                if (dsProductList != null && dsProductList.Tables.Count > 0 && dsProductList.Tables[0].Rows.Count > 0)
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


                    if (dsProductList.Tables.Count > 0)
                    {
                        string enxportstr = string.Empty;


                        int iColCount = dt1.Columns.Count;


                        for (int i = 0; i <=dt1.Columns.Count - 1; i++)
                        {

                            context.Response.Write(dt1.Columns[i]);

                            if (i < iColCount - 1)
                            {

                                context.Response.Write(",");
                              

                            }

                        }

                        context.Response.Write(Environment.NewLine);



                        //now we want to write the columns headers of the table
                        //for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                        //{
                        //    if (i < 0)
                        //    {
                        //        //adding comma in between columns...
                        //        context.Response.Write(",");
                        //    }
                        //    context.Response.Write(dt1.Columns[i].ColumnName);
                        //}


                       //context.Response.Write(Environment.NewLine);

                        //Write data into context 

                        foreach (DataRow dr in dt1.Rows)
                        {

                            for (int i = 0; i < iColCount; i++)
                            {

                                if (!Convert.IsDBNull(dr[i]))
                                {

                                    context.Response.Write(dr[i].ToString().Replace(",", ";"));

                                }

                                if (i < iColCount - 1)
                                {

                                    context.Response.Write(",");

                                }

                            }

                            context.Response.Write(Environment.NewLine);

                        }
                        context.Response.End();
                        
                        
                        
                        
                        
                        
                        
                        //foreach (DataRow row in dt1.Rows)
                        //{
                        //    //  here we are again going into loop because we want "comma" in between columns 
                        //    for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                        //    {
                        //        if (i < 0)
                        //        {
                        //            context.Response.Write(",");
                        //        }
                        //        context.Response.Write(row[i]);
                        //    }
                        //    context.Response.Write(Environment.NewLine);
                        //}
                        //context.Response.End();




                    }

                    lblMsg.Text = "File export";
                }

            }

        }

       
        protected void BtnUploadCsv_Click(object sender, EventArgs e)
        {
            if (fileUploadCsv.PostedFile.FileName == string.Empty)
            {

                lblMsg.Visible = true;

                return;

            }

            else
            {

                //save the file 

                //restrict user to upload other file extenstion
                string[] FileExt = fileUploadCsv.FileName.Split('.');
                string FileEx = FileExt[FileExt.Length - 1];

                if (FileEx.ToLower() == "csv" || FileEx.ToLower() == "xlsx")
                {

                    fileUploadCsv.SaveAs(Server.MapPath("..\\CSVLoad\\" + fileUploadCsv.FileName));
                   // Server.MapPath("..\\Product\\") + strFileName2)
               
                
                
                
                
                }

                else
                {

                    lblMsg.Visible = true;

                    return;

                }

            }



            //create object for CSVReader and pass the stream

            CSVReader reader = new CSVReader(fileUploadCsv.PostedFile.InputStream);

            //get the header

            string[] headers = reader.GetCSVLine();

            DataTable dt = new DataTable();

            //add headers

            foreach (string strHeader in headers)
                dt.Columns.Add(strHeader);


            //string strHeader;
            string[] data;
           
            while ((data = reader.GetCSVLine()) != null)
            {

                dt.Rows.Add(data);

                int product_id= Convert.ToInt32(Convert.ToString(data[0]));
                string title = Convert.ToString(Convert.ToString(data[1]));
               // string saletitle = Convert.ToString(Convert.ToString(data[2]));
               string size = Convert.ToString(Convert.ToString(data[2]));
               string desc = Convert.ToString(Convert.ToString(data[3]));

               string image1 = Convert.ToString(Convert.ToString(data[4]));
               string image2 = Convert.ToString(Convert.ToString(data[5]));
                string suggest = Convert.ToString(Convert.ToString(data[10]));
                string recomm = Convert.ToString(Convert.ToString(data[11]));

               string strpresale = Convert.ToString(data[8]);

               if (strpresale != "")
               {
                   presale = Convert.ToDouble(strpresale);
               }

            
               string strprice = Convert.ToString(data[9]);
                if (strprice != "")
               {
                    price = Convert.ToDouble(strprice);
               }
                //if (saletitle == "" || saletitle==null)
                //{
                //    saletitle =" ";
                //}

                if (strpresale == "" || strpresale =="0")
                {
                    int intUpdate_ifnull = dbInfo.UpdateProductPrice_ifnull(product_id, price, size, recomm, suggest);

                    
                }
                else
                {
                    int intUpdate = dbInfo.UpdateProductPrice(product_id, presale, price, size, recomm, suggest);
                }

                int intUpdateSize = dbInfo.UpdateProductSize(product_id, size, desc, title,image1,image2);
                
                

               // int intUpdate = dbInfo.UpdateProductPrice(product_id,presale,price,size);

              }

           

            //bind gridview

            //lblMsg.Visible = true;
           // lblMsg.Text = "Sucessfully succed";
          // gv.DataSource = dt;

            //gv.DataBind();
            BindGrid();
            lblMsgError.Visible = false;
            lblMsg.Visible = true;
            lblMsg.Text = "Sucessfully updated the prices";

        }//

    }
}

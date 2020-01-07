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
    public partial class AddSales : System.Web.UI.Page
    {
        DbProvider dbAddInfo = new DbProvider();
        DropdownProvider dropProduct = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAdd.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                try
                {
                    dropProduct.bindProductDropdown(drpProduct);
                   

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
            DataSet dsAdminCustomers = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            dbAddInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.AddSaleItems;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int insertProduct=0;
                string productId = drpProduct.SelectedValue;
                insertProduct = dbAddInfo.UpdateProductSaleInfo(Convert.ToInt32(productId), Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtPreSale.Text));
                if (insertProduct != 0)
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.salesAddSuccess;
                     lblMsg.ForeColor = System.Drawing.Color.Black;
                    drpProduct.SelectedValue = "Select";
                    txtPreSale.Text = "";
                    txtPrice.Text = "";
                    txtSize.Text = "";
                    txtSize.Enabled = true;
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.salesAddFailed;
                    lblMsg.ForeColor = System.Drawing.Color.Red;


                }
                

               
                



               
                

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }


        }

      




        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewSalesInformation.aspx", false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewSalesInformation.aspx", false);


        }

        protected void drpProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productId = drpProduct.SelectedValue;
            DataSet dsProductInfo = new DataSet();
            if (productId == "Select")
            {
                txtPreSale.Text = "";
                txtPrice.Text = "";
                txtSize.Text = "";
                txtSize.Enabled = true;

            }
            else
            {
                double price = 0;
                double preprice = 0;
                dsProductInfo = dbAddInfo.SelectProductInformationDeatils(Convert.ToInt32(productId));
                if (dsProductInfo.Tables.Count > 0)
                {
                    if (dsProductInfo != null && dsProductInfo.Tables.Count > 0 && dsProductInfo.Tables[0].Rows.Count > 0)
                    {
                        txtSize.Text = Convert.ToString(dsProductInfo.Tables[0].Rows[0]["product_size"]);
                        txtSize.Enabled = false;
                        price = Math.Round(Convert.ToDouble(dsProductInfo.Tables[0].Rows[0]["productlink_price"]), 2);
                        txtPrice.Text = Convert.ToString(price);
                       
                        if (Convert.ToString(dsProductInfo.Tables[0].Rows[0]["productlink_presale"]) != "")
                        {
                            preprice = Math.Round(Convert.ToDouble(dsProductInfo.Tables[0].Rows[0]["productlink_presale"]), 2);
                            txtPreSale.Text = Convert.ToString(preprice);

                        }
                        else
                        {
                            txtPreSale.Text = Convert.ToString(dsProductInfo.Tables[0].Rows[0]["productlink_presale"]);
                        }
                        
                         
                    }
                }


            }


        }
        
       

    }
}

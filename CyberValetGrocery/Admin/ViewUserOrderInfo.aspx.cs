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
    public partial class ViewUserOrderInfo : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                changeLinks();
                getCompanyName();
                if (!IsPostBack)
                {

                    int userId = Convert.ToInt32(Request.QueryString["userId"]);
                    DataSet dsUserItemList = new DataSet();
                    dsUserItemList = dbListInfo.GetHomeUserInformation(userId);
                    if (dsUserItemList.Tables.Count > 0)
                    {
                        if (dsUserItemList != null && dsUserItemList.Tables.Count > 0 && dsUserItemList.Tables[0].Rows.Count > 0)
                        {
                            lblFName.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_fname"]);
                            lblLName.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_lname"]);
                           // lblAccountVal.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsUserItemList.Tables[0].Rows[0]["users_accountvalue"]), 2));
                            lblAccountVal.Text = Convert.ToDecimal(dsUserItemList.Tables[0].Rows[0]["users_accountvalue"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            if (Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_newsletter"]) == "1")
                            {
                                lblMailing.Text = AppConstants.strYes;

                            }
                            else
                            {
                                lblMailing.Text = AppConstants.strNo;

                            }
                        }
                    }
                    BindOrderGrid();
                    BindProductGrid();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

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


            foreach (DataListItem row1 in MyDataListCustomers.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbCustomers");
                string name = MyLinkButton.Text;
                if (name == "Users")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.UserOrder;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void BindOrderGrid()
        {
            double totAmt = 0;
            int userId = Convert.ToInt32(Request.QueryString["userId"]);
            DataSet dsUSerItemList = new DataSet();
            dsUSerItemList = dbListInfo.GetUserOrderDetailInformation(userId);
            if (dsUSerItemList.Tables.Count > 0)
            {
                if (dsUSerItemList != null && dsUSerItemList.Tables.Count > 0 && dsUSerItemList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsUSerItemList.Tables[0].Rows)
                    {                   

                      //dtrow["orders_totalfinal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]),2));
                        dtrow["orders_totalfinal"] = Convert.ToDecimal(dtrow["orders_totalfinal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                      totAmt = totAmt + Convert.ToDouble(dtrow["orders_totalfinal"]);

                    }
                    //lblGrandTotal.Text = Convert.ToString(totAmt);
                    lblGrandTotal.Text = Convert.ToDecimal(totAmt).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    gridUserOrderList.DataSource = dsUSerItemList;
                    gridUserOrderList.DataBind();
                }
                else
                {
                    gridUserOrderList.Visible = false;
                    pnlTot.Visible = false;
                    lblMsg.Text = "";
                    lblGrandTotal.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }




        public void BindProductGrid()
        {
           
            int userId = Convert.ToInt32(Request.QueryString["userId"]);
            DataSet dsUserProductList = new DataSet();
            dsUserProductList = dbListInfo.GetUserProductDetailInformation(userId);
            if (dsUserProductList.Tables.Count > 0)
            {
                if (dsUserProductList != null && dsUserProductList.Tables.Count > 0 && dsUserProductList.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dtrow in dsUserProductList.Tables[0].Rows)
                    {

                        //dtrow["orderproduct_price"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orderproduct_price"]), 2));
                        dtrow["orderproduct_price"] = Convert.ToDecimal(dtrow["orderproduct_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                      

                    }
                    gridUserProductList.DataSource = dsUserProductList;
                    gridUserProductList.DataBind();
                }
                else
                {
                    gridUserProductList.Visible = false;
                    lblMsg1.Text = "";                   
                    lblMsg1.Visible = true;
                    lblMsg1.Text = AppConstants.noRecord;
                    lblMsg1.ForeColor = System.Drawing.Color.Red;
                }
            }
           
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            string strKey = string.Empty;
            int intIn = 0;
            int intSortBy = 0;
            int perPage = 0;
            int locId = 0;
            strKey = Request.QueryString["strKey"];
            intIn = Convert.ToInt32(Request.QueryString["intIn"]);
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            intSortBy = Convert.ToInt32(Request.QueryString["SortBy"]);
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            Response.Redirect("ViewUserInformation.aspx?strKey=" + strKey + "&intIn=" + intIn + "&SortBy=" + intSortBy + "&locId=" + locId + "&perPage=" + perPage, false);

            

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {

            string strKey = string.Empty;
            int intIn = 0;
            int intSortBy = 0;
            int perPage = 0;
            int locId = 0;
            strKey = Request.QueryString["strKey"];
            intIn = Convert.ToInt32(Request.QueryString["intIn"]);
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            intSortBy = Convert.ToInt32(Request.QueryString["SortBy"]);
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            Response.Redirect("ViewUserInformation.aspx?strKey=" + strKey + "&intIn=" + intIn + "&SortBy=" + intSortBy + "&locId=" + locId + "&perPage=" + perPage, false);

        }
    }
}

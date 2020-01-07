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
    public partial class ViewDetailCouponReport : System.Web.UI.Page
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
                if (name == "Coupon Report")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.CouponReportList;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void BindGrid()
        {
            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            int location = 0;
            strStartDate = Request.QueryString["startDate"];
            strToDate = Request.QueryString["endDate"];
            location = Convert.ToInt32(Request.QueryString["location"]);
            DataSet dsCouponList = dbListInfo.SelectCouponReportsDetails(strStartDate, strToDate, location);
            if (dsCouponList.Tables.Count > 0)
            {
                if (dsCouponList != null && dsCouponList.Tables.Count > 0 && dsCouponList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsCouponList.Tables[0].Rows)
                    {
                        dtrow["transactions_amount"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["transactions_amount"]), 2));

                    }

                    gridCouponDetailList.DataSource = dsCouponList;
                    gridCouponDetailList.DataBind();
                    DataSet dsCouponListTotal = dbListInfo.SelectCouponReportsTotalDetails(strStartDate, strToDate, location);
                    if (dsCouponListTotal.Tables.Count > 0)
                    {
                        if (dsCouponListTotal != null && dsCouponListTotal.Tables.Count > 0 && dsCouponListTotal.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow drTotal in dsCouponListTotal.Tables[0].Rows)
                            {
                                lblTotalAmt.Text = Convert.ToString(Math.Round(Convert.ToDouble(drTotal["totalAmt"]),2));
                            }
                        }
                    }


                }
                else
                {
                    pnlAmount.Visible = false;
                    gridCouponDetailList.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                pnlAmount.Visible = false;
                gridCouponDetailList.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gridCouponDetailList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridCouponDetailList.PageIndex = e.NewPageIndex;
            if (Convert.ToString(ViewState["CouponSortExpression"]) == "" && Convert.ToString(ViewState["CouponDirection"]) == "")
            {
                BindGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["CouponSortExpression"]), Convert.ToString(ViewState["CouponDirection"]));

            }
        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            int location = 0;
            strStartDate = Request.QueryString["startDate"];
            strToDate = Request.QueryString["endDate"];
            location = Convert.ToInt32(Request.QueryString["location"]);
            Response.Redirect("admin_couponreport.aspx?check=1&startDate=" + strStartDate + "&endDate=" + strToDate + "&location=" + location, false);

          

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            int location = 0;
            strStartDate = Request.QueryString["startDate"];
            strToDate = Request.QueryString["endDate"];
            location = Convert.ToInt32(Request.QueryString["location"]);
            Response.Redirect("admin_couponreport.aspx?check=1&startDate=" + strStartDate + "&endDate=" + strToDate + "&location=" + location, false);

        }
        protected void gridCouponDetailList_Sorting(object sender, GridViewSortEventArgs e)
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

            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            int location = 0;
            strStartDate = Request.QueryString["startDate"];
            strToDate = Request.QueryString["endDate"];
            location = Convert.ToInt32(Request.QueryString["location"]);
            DataSet dsCouponList = dbListInfo.SelectCouponReportsDetails(strStartDate, strToDate, location);
            if (dsCouponList.Tables.Count > 0)
            {
                if (dsCouponList != null && dsCouponList.Tables.Count > 0 && dsCouponList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsCouponList.Tables[0].Rows)
                    {
                        dtrow["transactions_amount"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["transactions_amount"]), 2));

                    }

                    DataTable dtSorting = dsCouponList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridCouponDetailList.DataSource = dvSorting;
                    gridCouponDetailList.DataBind();
                }
            }
            ViewState["CouponSortExpression"] = sortExpression;
            ViewState["CouponDirection"] = direction;
            dbListInfo.dispose();
        }
    }
}

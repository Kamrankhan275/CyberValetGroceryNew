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
    public partial class admin_coupon : System.Web.UI.Page
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
                if (name == "Coupons")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.CouponCodeList;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }



        protected void gridCouponList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridCouponList.PageIndex = e.NewPageIndex;          
            if (Convert.ToString(ViewState["CouponSortExpression"]) == "" && Convert.ToString(ViewState["CouponDirection"]) == "")
            {
                BindGrid();
            }
            else
            {

                SortGridView(Convert.ToString(ViewState["CouponSortExpression"]), Convert.ToString(ViewState["CouponDirection"]));
            }
        }

        protected void gridCouponList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int intCouponID = 0;
                int status = 0;
                if (e.CommandName == "Hide")
                {
                    intCouponID = Convert.ToInt32(e.CommandArgument);

                    for (int intCoupon = 0; intCoupon < gridCouponList.Rows.Count; intCoupon++)
                    {
                        Panel pnlHide;
                        Panel pnlUnHide;
                        ImageButton btnHide;


                        GridViewRow item = gridCouponList.Rows[intCoupon];
                        pnlHide = (Panel)item.FindControl("pnlHide");
                        pnlUnHide = (Panel)item.FindControl("pnlUnHide");
                        btnHide = (ImageButton)item.FindControl("btnHide");

                        int intComVal = Convert.ToInt32(btnHide.CommandArgument);

                        if (intCouponID == intComVal)
                        {
                            status = 1;
                            pnlHide.Visible = false;
                            pnlUnHide.Visible = true;
                            int intUpdateStatus = dbListInfo.UpdateCouponStatus(intCouponID, status);

                        }


                    }

                   

                }

                if (e.CommandName == "UnHide")
                {
                    intCouponID = Convert.ToInt32(e.CommandArgument);

                    for (int intCoupon = 0; intCoupon < gridCouponList.Rows.Count; intCoupon++)
                    {
                        Panel pnlHide;
                        Panel pnlUnHide;
                        ImageButton btnUnHide;
                        GridViewRow item = gridCouponList.Rows[intCoupon];
                        pnlHide = (Panel)item.FindControl("pnlHide");
                        pnlUnHide = (Panel)item.FindControl("pnlUnHide");
                        btnUnHide = (ImageButton)item.FindControl("btnUnHide");
                        int intComVal = Convert.ToInt32(btnUnHide.CommandArgument);
                        if (intCouponID == intComVal)
                        {
                            status = 0;
                            pnlHide.Visible = true;
                            pnlUnHide.Visible = false;
                            int intUpdateStatus = dbListInfo.UpdateCouponStatus(intCouponID, status);
                        }


                    }



                }

                dbListInfo.dispose();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }

        public void BindGrid()
        {
            DataSet dsCouponList = new DataSet();
            dsCouponList = dbListInfo.GetCouponsDeatils();
            if (dsCouponList.Tables.Count > 0)
            {
                if (dsCouponList != null && dsCouponList.Tables.Count > 0 && dsCouponList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsCouponList.Tables[0].Rows)
                    {
                       dtrow["coupon_amount"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["coupon_amount"]), 2));
                      
                    }
                    gridCouponList.DataSource = dsCouponList;
                    gridCouponList.DataBind();
                   
                  for (int i = 0; i < gridCouponList.Rows.Count; i++)
                    {
                        Panel pnlHide;
                        Panel pnlUnHide;
                        Label lblStatus;
                        GridViewRow item = gridCouponList.Rows[i];
                        pnlHide = (Panel)item.FindControl("pnlHide");
                        pnlUnHide = (Panel)item.FindControl("pnlUnHide");
                        lblStatus = (Label)item.FindControl("lblCouponStatus");
                        if (Convert.ToInt32(lblStatus.Text) == 1)
                        {
                            pnlHide.Visible = false;
                            pnlUnHide.Visible =true;
                        }

                     }

                }
                else
                {
                    gridCouponList.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                gridCouponList.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }


            dbListInfo.dispose();
        }



        protected void gridCouponList_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet dsCouponList = new DataSet();
            dsCouponList = dbListInfo.GetCouponsDeatils();
            if (dsCouponList.Tables.Count > 0)
            {
                if (dsCouponList != null && dsCouponList.Tables.Count > 0 && dsCouponList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsCouponList.Tables[0].Rows)
                    {
                        dtrow["coupon_amount"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["coupon_amount"]), 2));

                    }

                    DataTable dtSorting = dsCouponList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridCouponList.DataSource = dvSorting;
                    gridCouponList.DataBind();
                }
            }
            ViewState["CouponSortExpression"] = sortExpression;
            ViewState["CouponDirection"] = direction;
            dbListInfo.dispose();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCoupon.aspx", false);

        }

       
    }
}

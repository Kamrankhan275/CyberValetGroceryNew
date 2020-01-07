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
using System.Text;
using System.IO;
using CyberValetGrocery.Class;

namespace CyberValetGrocery
{
    public partial class viewallpast : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["userId"] == null)
                {
                    Response.Redirect("My_Account.aspx", false);
                }
                else
                {
                    BindSideLink();
                    getCompanyName();
                    if (!IsPostBack)
                    {
                        lblMsg.Visible = false;
                        lblMsg.Text = "";
                        BindOrderGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
        public void BindSideLink()
        {

            Panel pnlHow = (Panel)Page.Master.FindControl("pnlHow");
            pnlHow.Visible = false;
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = false;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = true;
            Panel pnlAccNoLogin = (Panel)Page.Master.FindControl("pnlAccNoLogin");
            pnlAccNoLogin.Visible = false;
            Panel pnlAccLog = (Panel)Page.Master.FindControl("pnlAccLog");
            pnlAccLog.Visible = true;


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgPastOrderNm;

                    }
                }
            }
            dbGetCompanyName.dispose();
        }



        public void BindOrderGrid()
        {
            int userId = 0;          
            userId = Convert.ToInt32(Request.Cookies["userId"].Value);
            DataSet dsUserOrderInfo = new DataSet();
            dsUserOrderInfo = dbInfo.GetUserOrderInformation(userId);
            if (dsUserOrderInfo.Tables.Count > 0)
            {
                if (dsUserOrderInfo != null && dsUserOrderInfo.Tables.Count > 0 && dsUserOrderInfo.Tables[0].Rows.Count > 0)
                {
                    lblErrMsg.Text = "";
                    foreach (DataRow dtrow in dsUserOrderInfo.Tables[0].Rows)
                    {

                        if (Convert.ToString(dtrow["orders_totalfinal"]) != "")
                        {
                            dtrow["orders_totalfinal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));

                        }
                    }
                    gridOrderList.DataSource = dsUserOrderInfo;
                    gridOrderList.DataBind();
                }
                else
                {
                    lblErrMsg.Text = "";
                    lblErrMsg.Visible = false;
                    lblErrMsg.Text = AppConstants.strUserNoOrder;
                    gridOrderList.Visible = false;


                }
            }
            else
            {
                lblErrMsg.Text = "";
                lblErrMsg.Visible = false;
                lblErrMsg.Text = AppConstants.strUserNoOrder;
                gridOrderList.Visible = false;


            }
            dbInfo.dispose();
          
        }



        protected void gridOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridOrderList.PageIndex = e.NewPageIndex;
            if (Convert.ToString(ViewState["pagingsortExpression"]) == "" && Convert.ToString(ViewState["pagingsortdirection"]) == "")
            {
                 BindOrderGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["pagingsortExpression"]), Convert.ToString(ViewState["pagingsortdirection"]));

            }
           
        }



       

        protected void gridOrderList_Sorting(object sender, GridViewSortEventArgs e)
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
            int userId = 0;
            userId = Convert.ToInt32(Request.Cookies["userId"].Value);
            DataSet dsUserOrderInfo = new DataSet();
            dsUserOrderInfo = dbInfo.GetUserOrderInformation(userId);
            if (dsUserOrderInfo.Tables.Count > 0)
            {
                if (dsUserOrderInfo != null && dsUserOrderInfo.Tables.Count > 0 && dsUserOrderInfo.Tables[0].Rows.Count > 0)
                {
                    lblErrMsg.Text = "";
                    foreach (DataRow dtrow in dsUserOrderInfo.Tables[0].Rows)
                    {

                        if (Convert.ToString(dtrow["orders_totalfinal"]) != "")
                        {
                            dtrow["orders_totalfinal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));

                        }
                    }

                    DataTable dtSorting = dsUserOrderInfo.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridOrderList.DataSource = dvSorting;
                    gridOrderList.DataBind();

                }
            }
            ViewState["pagingsortExpression"] = sortExpression;
            ViewState["pagingsortdirection"] = direction;
            dbInfo.dispose();
        }


      
    }
}

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
    public partial class ViewAdminDepositors : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                changeLinks();
                getCompanyName();
                if (!IsPostBack)
                {
                   
                    BindGrid();
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
                if (name == "Depositors")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.Depositors;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }
        public void BindGrid()
        {
            string strKey = string.Empty;
            int intIn = 0;          
            int perPage = 0;
            int locId = 0;
            strKey = Request.QueryString["strKey"];
            intIn = Convert.ToInt32(Request.QueryString["intIn"]);
            locId = Convert.ToInt32(Request.QueryString["locId"]);            
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            DataSet dsUSerItemList = new DataSet();
            dsUSerItemList = dbListInfo.GetDepositorsDetailInformation(strKey, intIn, locId);
            if (dsUSerItemList.Tables.Count > 0)
            {
                if (dsUSerItemList != null && dsUSerItemList.Tables.Count > 0 && dsUSerItemList.Tables[0].Rows.Count > 0)
                {

                    gridDepositorList.PageSize = perPage;
                    gridDepositorList.DataSource = dsUSerItemList;
                    gridDepositorList.DataBind();
                    foreach (DataRow dtrow in dsUSerItemList.Tables[0].Rows)
                    {
                        int parentId = Convert.ToInt32(dtrow["parent_id"]);
                        DataSet dsTransItemList = new DataSet();
                        dsTransItemList = dbListInfo.GetTransactionDetails(parentId);
                        if (dsTransItemList.Tables.Count > 0)
                        {
                            if (dsTransItemList != null && dsTransItemList.Tables.Count > 0 && dsTransItemList.Tables[0].Rows.Count > 0)
                            {
                            }
                            else
                            {
                                for (int i = 0; i < gridDepositorList.Rows.Count; i++)
                                {

                                    GridViewRow item = gridDepositorList.Rows[i];
                                    Panel pnlView;
                                    Label lblParentId;
                                    pnlView = (Panel)item.FindControl("pnlView");
                                    lblParentId = (Label)item.FindControl("lblParentId");
                                    if (parentId == Convert.ToInt32(lblParentId.Text))
                                    {
                                        pnlView.Visible = false;
                                    }
                                 
                                }

                            }
                        }
                        else
                        {
                            for (int i = 0; i < gridDepositorList.Rows.Count; i++)
                            {

                                GridViewRow item = gridDepositorList.Rows[i];
                                Panel pnlView;
                                Label lblParentId;
                                pnlView = (Panel)item.FindControl("pnlView");
                                lblParentId = (Label)item.FindControl("lblParentId");
                                if (parentId == Convert.ToInt32(lblParentId.Text))
                                {
                                    pnlView.Visible = false;
                                }

                            }

                        }

                    }
                   
                    
                }
                else
                {
                    gridDepositorList.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gridDepositorList.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

           
        }


        protected void gridDepositorList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridDepositorList.PageIndex = e.NewPageIndex;           
            if (Convert.ToString(ViewState["DepositSortExpression"]) == "" && Convert.ToString(ViewState["DepositDirection"]) == "")
            {
                BindGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["DepositSortExpression"]), Convert.ToString(ViewState["DepositDirection"]));

            }
        }

        protected void gridDepositorList_Sorting(object sender, GridViewSortEventArgs e)
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

            string strKey = string.Empty;
            int intIn = 0;
            int perPage = 0;
            int locId = 0;
            strKey = Request.QueryString["strKey"];
            intIn = Convert.ToInt32(Request.QueryString["intIn"]);
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            DataSet dsUSerItemList = new DataSet();
            dsUSerItemList = dbListInfo.GetDepositorsDetailInformation(strKey, intIn, locId);
            if (dsUSerItemList.Tables.Count > 0)
            {
                if (dsUSerItemList != null && dsUSerItemList.Tables.Count > 0 && dsUSerItemList.Tables[0].Rows.Count > 0)
                {
                    gridDepositorList.PageSize = perPage;
                    DataTable dtSorting = dsUSerItemList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridDepositorList.DataSource = dvSorting;
                    gridDepositorList.DataBind();
                    foreach (DataRow dtrow in dsUSerItemList.Tables[0].Rows)
                    {
                        int parentId = Convert.ToInt32(dtrow["parent_id"]);
                        DataSet dsTransItemList = new DataSet();
                        dsTransItemList = dbListInfo.GetTransactionDetails(parentId);
                        if (dsTransItemList.Tables.Count > 0)
                        {
                            if (dsTransItemList != null && dsTransItemList.Tables.Count > 0 && dsTransItemList.Tables[0].Rows.Count > 0)
                            {
                            }
                            else
                            {
                                for (int i = 0; i < gridDepositorList.Rows.Count; i++)
                                {

                                    GridViewRow item = gridDepositorList.Rows[i];
                                    Panel pnlView;
                                    Label lblParentId;
                                    pnlView = (Panel)item.FindControl("pnlView");
                                    lblParentId = (Label)item.FindControl("lblParentId");
                                    if (parentId == Convert.ToInt32(lblParentId.Text))
                                    {
                                        pnlView.Visible = false;
                                    }

                                }

                            }
                        }
                        else
                        {
                            for (int i = 0; i < gridDepositorList.Rows.Count; i++)
                            {

                                GridViewRow item = gridDepositorList.Rows[i];
                                Panel pnlView;
                                Label lblParentId;
                                pnlView = (Panel)item.FindControl("pnlView");
                                lblParentId = (Label)item.FindControl("lblParentId");
                                if (parentId == Convert.ToInt32(lblParentId.Text))
                                {
                                    pnlView.Visible = false;
                                }

                            }

                        }

                    }

                }
            }
            ViewState["DepositSortExpression"] = sortExpression;
            ViewState["DepositDirection"] = direction;
            dbListInfo.dispose();
        }
       
        
         protected void imgBack1_Click(object sender, ImageClickEventArgs e)
         {

             string strKey = string.Empty;
             int intIn = 0;
             int perPage = 0;
             int locId = 0;
             strKey = Request.QueryString["strKey"];
             intIn = Convert.ToInt32(Request.QueryString["intIn"]);
             locId = Convert.ToInt32(Request.QueryString["locId"]);
             perPage = Convert.ToInt32(Request.QueryString["perPage"]);
             Response.Redirect("admin_depositors.aspx?check=1&strKey=" + strKey + "&intIn=" + intIn + "&locId=" + locId + "&perPage=" + perPage, false);
           

         }

         protected void imgBack_Click(object sender, ImageClickEventArgs e)
         {
             string strKey = string.Empty;
             int intIn = 0;
             int perPage = 0;
             int locId = 0;
             strKey = Request.QueryString["strKey"];
             intIn = Convert.ToInt32(Request.QueryString["intIn"]);
             locId = Convert.ToInt32(Request.QueryString["locId"]);
             perPage = Convert.ToInt32(Request.QueryString["perPage"]);
             Response.Redirect("admin_depositors.aspx?check=1&strKey=" + strKey + "&intIn=" + intIn + "&locId=" + locId + "&perPage=" + perPage, false);

         }
    }
}

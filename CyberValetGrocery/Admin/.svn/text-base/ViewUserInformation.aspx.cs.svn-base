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
    public partial class ViewUserInformation : System.Web.UI.Page
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.User;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }





        public void BindGrid()
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
            DataSet dsUSerItemList = new DataSet();
            dsUSerItemList = dbListInfo.GetUserDetailInformation(strKey, intIn, locId, intSortBy);
            if (dsUSerItemList.Tables.Count > 0)
            {
                if (dsUSerItemList != null && dsUSerItemList.Tables.Count > 0 && dsUSerItemList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsUSerItemList.Tables[0].Rows)
                    {
                        DataSet dsUserOrderCount = new DataSet();
                        dsUserOrderCount = dbListInfo.GetUserOrderCount(Convert.ToInt32(dtrow["users_id"]));
                        dtrow["orders"] = Convert.ToString(dsUserOrderCount.Tables[0].Rows[0]["orderCnt"]);

                    }
                    griduserList.PageSize = perPage;
                    griduserList.DataSource = dsUSerItemList;
                    griduserList.DataBind();
                    //for (int i = 0; i < griduserList.Rows.Count; i++)
                    //{

                    //    GridViewRow item = griduserList.Rows[i];
                    //    Panel pnlView;
                    //    Label lblOrders;
                    //    pnlView = (Panel)item.FindControl("pnlView");
                    //    lblOrders = (Label)item.FindControl("lblOrders");
                    //    if (Convert.ToInt32(lblOrders.Text) == 0)
                    //    {
                    //        pnlView.Visible = false;
                    //    }

                    //}
                }

                else
                {
                    griduserList.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }



            else
            {
                griduserList.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
           
           
       



        protected void griduserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            griduserList.PageIndex = e.NewPageIndex;
            BindGrid();
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
             Response.Redirect("admin_users.aspx?check=1&strKey=" + strKey + "&intIn=" + intIn + "&SortBy=" + intSortBy + "&locId=" + locId + "&perPage=" + perPage, false);


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
             Response.Redirect("admin_users.aspx?check=1&strKey=" + strKey + "&intIn=" + intIn + "&SortBy=" + intSortBy + "&locId=" + locId + "&perPage=" + perPage, false);


         }

         protected void griduserList_Sorting(object sender, GridViewSortEventArgs e)
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
             int intSortBy = 0;
             int perPage = 0;
             int locId = 0;
             strKey = Request.QueryString["strKey"];
             intIn = Convert.ToInt32(Request.QueryString["intIn"]);
             locId = Convert.ToInt32(Request.QueryString["locId"]);
             intSortBy = Convert.ToInt32(Request.QueryString["SortBy"]);
             perPage = Convert.ToInt32(Request.QueryString["perPage"]);
             DataSet dsUSerItemList = new DataSet();
             dsUSerItemList = dbListInfo.GetUserDetailInformation(strKey, intIn, locId, intSortBy);
             if (dsUSerItemList.Tables.Count > 0)
             {
                 if (dsUSerItemList != null && dsUSerItemList.Tables.Count > 0 && dsUSerItemList.Tables[0].Rows.Count > 0)
                 {
                     foreach (DataRow dtrow in dsUSerItemList.Tables[0].Rows)
                     {
                         DataSet dsUserOrderCount = new DataSet();
                         dsUserOrderCount = dbListInfo.GetUserOrderCount(Convert.ToInt32(dtrow["users_id"]));
                         dtrow["orders"] = Convert.ToString(dsUserOrderCount.Tables[0].Rows[0]["orderCnt"]);

                     }
                     griduserList.PageSize = perPage;
                     DataTable dtSorting = dsUSerItemList.Tables[0];
                     DataView dvSorting = new DataView(dtSorting);
                     dvSorting.Sort = sortExpression + direction;
                     griduserList.DataSource = dvSorting;
                     griduserList.DataBind();
                     //for (int i = 0; i < griduserList.Rows.Count; i++)
                     //{

                     //    GridViewRow item = griduserList.Rows[i];
                     //    Panel pnlView;
                     //    Label lblOrders;
                     //    pnlView = (Panel)item.FindControl("pnlView");
                     //    lblOrders = (Label)item.FindControl("lblOrders");
                     //    if (Convert.ToInt32(lblOrders.Text) == 0)
                     //    {
                     //        pnlView.Visible = false;
                     //    }

                     //}
                 }
             }


             dbListInfo.dispose();
         }


    }
}

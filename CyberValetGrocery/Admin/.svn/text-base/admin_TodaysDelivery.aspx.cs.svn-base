using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using CyberValetGrocery.Class;

namespace CyberValetGrocery.Admin
{
    public partial class admin_TodaysDelivery : System.Web.UI.Page
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
                if (name == "Today's Delivery")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.TodaysDeliveryList;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }



        protected void gridTodaysDateList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteTime")
                {
                    int intTimeID = Convert.ToInt32(e.CommandArgument);
                    BindDeleteGrid(intTimeID);

                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }


        public void BindDeleteGrid(int intDateTimeID)
        {
            int intDeleteTime = 0;
            intDeleteTime = dbListInfo.DeleteTime(intDateTimeID);
            BindGrid();

        }


        protected void gridTodaysDateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridTodaysDateList.PageIndex = e.NewPageIndex;
            if (Convert.ToString(ViewState["TodaysDateSortExpression"]) == "" && Convert.ToString(ViewState["TodaysDateDirection"]) == "")
            {

                BindGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["TodaysDateSortExpression"]), Convert.ToString(ViewState["TodaysDateDirection"]));

            }

        }


   

        public void BindGrid()
        {
            lblMsg.Text = "";
            DataSet dsTodaysDateList = new DataSet();
            DataTable dtTodaysTime = new DataTable();
            DataRow rowTodaysTime;
            int TimeId = 0;
            string strShowHide = string.Empty;
            string strTimeNm = string.Empty;
            string strStartTime = string.Empty;
            string strAmPm = string.Empty;
            string strEndTime = string.Empty;
            string strPMAM = string.Empty;
            int intStartTime = 0;
            int intEndTime = 0;
            string strdate = string.Empty;
            string strmonth = string.Empty;
            string strday = string.Empty;
            string stryear = string.Empty;
            dtTodaysTime.Columns.Add("StartTime");
            dtTodaysTime.Columns.Add("AM_PM");
            dtTodaysTime.Columns.Add("EndTime");
            dtTodaysTime.Columns.Add("PM_AM");
            dtTodaysTime.Columns.Add("ShowHide");
            dtTodaysTime.Columns.Add("TimeNm");
            dtTodaysTime.Columns.Add("TimeId");
            dsTodaysDateList = dbListInfo.GetTodaysDeliveryDetails();
            if (dsTodaysDateList.Tables.Count > 0)
            {

                if (dsTodaysDateList != null && dsTodaysDateList.Tables.Count > 0 && dsTodaysDateList.Tables[0].Rows.Count > 0)
                {
                    gridTodaysDateList.DataSource = dsTodaysDateList;
                    gridTodaysDateList.DataBind();
                }
                else
                {
                    gridTodaysDateList.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                foreach (DataRow dtrowTime in dsTodaysDateList.Tables[0].Rows)
                {


                    TimeId = Convert.ToInt32(dtrowTime["TimeId"]);
                    strShowHide = Convert.ToString(dtrowTime["ShowHide"]);
                    if (Convert.ToInt32(dtrowTime["StartTime"]) > 12)
                    {
                        intStartTime = Convert.ToInt32(dtrowTime["StartTime"]) - 12;
                    }
                    else
                    {
                        intStartTime = Convert.ToInt32(dtrowTime["StartTime"]);
                    }
                    strAmPm = Convert.ToString(dtrowTime["AM_PM"]);
                    if (Convert.ToInt32(dtrowTime["EndTime"]) > 12)
                    {
                        intEndTime = Convert.ToInt32(dtrowTime["EndTime"]) - 12;
                    }
                    else
                    {
                        intEndTime = Convert.ToInt32(dtrowTime["EndTime"]);
                    }
                    strPMAM = Convert.ToString(dtrowTime["PM_AM"]);

                    //strTimeNm = strStartTime + " " + strAmPm + " - " + strEndTime + " " + strPMAM;

                    strTimeNm = intStartTime + " " + strAmPm + " - " + intEndTime + " " + strPMAM;

                    rowTodaysTime = dtTodaysTime.NewRow();
                   
                    rowTodaysTime["StartTime"] = intStartTime;
                    rowTodaysTime["AM_PM"] = strAmPm;
                    rowTodaysTime["EndTime"] = intEndTime;
                    rowTodaysTime["PM_AM"] = strPMAM;
                    rowTodaysTime["TimeId"] = TimeId;
                    rowTodaysTime["TimeNm"] = strTimeNm;
                    rowTodaysTime["ShowHide"] = strShowHide;
                    dtTodaysTime.Rows.Add(rowTodaysTime);
                }

                foreach (GridViewRow gridtime in gridTodaysDateList.Rows)
                {
                    if (dsTodaysDateList.Tables.Count > 0)
                    {
                        if (dsTodaysDateList != null && dsTodaysDateList.Tables.Count > 0 && dsTodaysDateList.Tables[0].Rows.Count > 0)
                        {
                      
                            Label lblStartTimeNm;
                            lblStartTimeNm = (Label)gridtime.FindControl("lblStartTime");

                            Label lblTimeNm;
                            lblTimeNm = (Label)gridtime.FindControl("lblTime");

                            Label lblEndTimeNm;
                            lblEndTimeNm = (Label)gridtime.FindControl("lblEndTime");

                            Label lblTime2;
                            lblTime2 = (Label)gridtime.FindControl("lblTime2");

                            string strTime = lblStartTimeNm.Text + "" + lblTimeNm.Text + "-" + lblEndTimeNm.Text + "" + lblTime2.Text;

                            gridTodaysDateList.DataSource = dtTodaysTime;
                            gridTodaysDateList.DataBind();

                           
                        }
                    }
                }
            }
            else
            {
                gridTodaysDateList.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


     

        protected void gridTodaysDateList_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet dsTodaysDateList = new DataSet();
            dsTodaysDateList = dbListInfo.GetTodaysDeliveryDetails();
            if (dsTodaysDateList.Tables.Count > 0)
            {
                if (dsTodaysDateList != null && dsTodaysDateList.Tables.Count > 0 && dsTodaysDateList.Tables[0].Rows.Count > 0)
                {
                    DataTable dtSorting = dsTodaysDateList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridTodaysDateList.DataSource = dvSorting;
                    gridTodaysDateList.DataBind();
                }
            }

            ViewState["TodaysDateSortExpression"] = sortExpression;
            ViewState["TodaysDateDirection"] = direction;
            dbListInfo.dispose();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTodaysDelivery.aspx", false);
        }

    }
}

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
    public partial class ViewOrdersDetail : System.Web.UI.Page
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


            foreach (DataListItem row1 in MyDataListCustomers.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbCustomers");
                string name = MyLinkButton.Text;
                if (name == "Orders")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.Orders;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        public void BindGrid()
        {
            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            string OrderNum = string.Empty;
            int intShow = 0;
            int intLocId = 0;
            int OrderType = 0;
            strStartDate = Convert.ToString(Request.QueryString["stDate"]);
            strToDate = Convert.ToString(Request.QueryString["enDate"]);
            OrderNum = Convert.ToString(Request.QueryString["ordNum"]);
            intLocId = Convert.ToInt32(Request.QueryString["intLocId"]);
            intShow = Convert.ToInt32(Request.QueryString["intShow"]);
            OrderType = Convert.ToInt32(Request.QueryString["OrderType"]);
            DataSet dsList = new DataSet();
            DataSet dsTotal = new DataSet();
            dsList = dbListInfo.GetOrderListInfo(strStartDate, strToDate, intLocId,Convert.ToString(OrderNum), OrderType);
            if (dsList.Tables.Count > 0)
            {
                if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    if (intShow != 0)
                    {
                        gridOrderList.PageSize = intShow;

                    }
                    else
                    {
                        gridOrderList.PageSize = 10;
                    }
                    gridOrderList.DataSource = dsList;
                    gridOrderList.DataBind();
                    

                }
                else
                {
                    gridOrderList.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gridOrderList.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void gridOrderList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateDelievry")
                {
                    int intOrderID = Convert.ToInt32(e.CommandArgument);
                    int intUpdateText = 0;
                    string strDate = string.Empty;
                    string strOrdDate = string.Empty;
                    for (int i = 0; i < gridOrderList.Rows.Count; i++)
                    {
                        TextBox txtDate;
                        TextBox txtTime;
                        Label lblDate;
                        Label lblTime;
                        ImageButton btnUpdate;
                        GridViewRow item = gridOrderList.Rows[i];
                        txtDate = (TextBox)item.FindControl("txtDate");
                        txtTime = (TextBox)item.FindControl("txtTime");
                        btnUpdate = (ImageButton)item.FindControl("btnUpdate");
                        lblDate = (Label)item.FindControl("lblDate");
                        lblTime = (Label)item.FindControl("lblTime");
                        intUpdateText = Convert.ToInt32(btnUpdate.CommandArgument);
                        if (intOrderID == intUpdateText)
                        {
                            if (lblDate.Text == txtDate.Text)
                            {
                                if (lblTime.Text != txtTime.Text)
                                {
                                    BindUpdateGrid(intOrderID, strOrdDate,txtTime.Text);
                                }
                               
                            }
                            else
                            {
                                int returnDate = 0;
                                DataValidator dataValidator = new DataValidator();
                                returnDate = DataValidator.IsValidDateGreaterToday(txtDate.Text);
                                if (returnDate != 0)
                                {
                                    strDate = splitDate(txtDate.Text);
                                    BindUpdateGrid(intOrderID, strDate, txtTime.Text);
                                }
                                else
                                {
                                    if (lblTime.Text != txtTime.Text)
                                    {
                                        BindUpdateGrid(intOrderID,strOrdDate,txtTime.Text);
                                    }

                                }


                            }
                        }
                            
                        
                        
                        
                    }
                    BindGrid();

                }
                if (e.CommandName == "DeleteDelievry")
                {
                    int intOrderID = 0;
                   intOrderID = Convert.ToInt32(e.CommandArgument);
                    BindDeleteGrid(intOrderID);
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }
        public string splitDate(string strDate)
        {
           
            string strNewDate=string.Empty;
            string[] dateInfo = new string[2];
            char[] splitter = { '/' };
            dateInfo = strDate.Split(splitter);
            int day = Convert.ToInt32(dateInfo[1]);
            int month = Convert.ToInt32(dateInfo[0]);
            int year = Convert.ToInt32(dateInfo[2]);
            strNewDate=year+"/"+month+"/"+day;
            return strNewDate;
        }


        public void BindDeleteGrid(int intOrderID)
        {
            int intDelete = 0;
            intDelete = dbListInfo.DeleteOrderInfo(intOrderID);
            if (intDelete > 0)
            {
                BindGrid();
            }


            
        }

        public void BindUpdateGrid(int intOrderID, string txtDate, string txtTime)
        {
            int intupdate = 0;
            if (txtDate != "")
            {
                intupdate = dbListInfo.UpdateOrderInfo(intOrderID, Convert.ToDateTime(txtDate),txtTime);
            }
            else
            {
                intupdate = dbListInfo.UpdateOrderTimeInfo(intOrderID,txtTime);

            }
            if (intupdate==1)
            {
                BindGrid();
            }

        }


        protected void gridOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridOrderList.PageIndex = e.NewPageIndex;
            if (Convert.ToString(ViewState["OrderListSortExpression"]) == "" && Convert.ToString(ViewState["OrderListDirection"]) == "")
            {
                BindGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["OrderListSortExpression"]), Convert.ToString(ViewState["OrderListDirection"]));

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

            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            string OrderNum = string.Empty;
            int intShow = 0;
            int intLocId = 0;
            int OrderType = 0;
            strStartDate = Convert.ToString(Request.QueryString["stDate"]);
            strToDate = Convert.ToString(Request.QueryString["enDate"]);
            OrderNum = Convert.ToString(Request.QueryString["ordNum"]);
            intLocId = Convert.ToInt32(Request.QueryString["intLocId"]);
            intShow = Convert.ToInt32(Request.QueryString["intShow"]);
            OrderType = Convert.ToInt32(Request.QueryString["OrderType"]);
            DataSet dsList = new DataSet();
            DataSet dsTotal = new DataSet();
            dsList = dbListInfo.GetOrderListInfo(strStartDate, strToDate, intLocId, OrderNum, OrderType);
            if (dsList.Tables.Count > 0)
            {
                if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    if (intShow != 0)
                    {
                        gridOrderList.PageSize = intShow;

                    }
                    else
                    {
                        gridOrderList.PageSize = 10;
                    }
                    DataTable dtSorting = dsList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridOrderList.DataSource = dvSorting;
                    gridOrderList.DataBind();

                }
            }
            ViewState["OrderListSortExpression"] = sortExpression;
            ViewState["OrderListDirection"] = direction;
            dbListInfo.dispose();
        }

         protected void imgBack1_Click(object sender, ImageClickEventArgs e)
         {
             string strStartDate = string.Empty;
             string strToDate = string.Empty;
             string OrderNum = string.Empty;
             string intShow = string.Empty;
             string intLocId = string.Empty;
             string OrderType = string.Empty;
             
             strStartDate = Convert.ToString(Request.QueryString["stDate"]);
             strToDate = Convert.ToString(Request.QueryString["enDate"]);

             OrderNum = Convert.ToString(Request.QueryString["ordNum"]);


             intLocId = Convert.ToString(Request.QueryString["intLocId"]);
             intShow = Convert.ToString(Request.QueryString["intShow"]);
             OrderType = Convert.ToString(Request.QueryString["OrderType"]);
             Response.Redirect("admin_orders.aspx?check=1&stDate=" + strStartDate + "&enDate=" + strToDate + "&ordNum=" + OrderNum + "&intShow=" + intShow + "&intLocId=" + intLocId + "&OrderType=" + OrderType, false);
             

         }

         protected void imgBack_Click(object sender, ImageClickEventArgs e)
         {
             string strStartDate = string.Empty;
             string strToDate = string.Empty;
             string OrderNum = string.Empty;
             string intShow = string.Empty;
             string intLocId = string.Empty;
             string OrderType = string.Empty;

             strStartDate = Convert.ToString(Request.QueryString["stDate"]);
             strToDate = Convert.ToString(Request.QueryString["enDate"]);

             OrderNum = Convert.ToString(Request.QueryString["ordNum"]);


             intLocId = Convert.ToString(Request.QueryString["intLocId"]);
             intShow = Convert.ToString(Request.QueryString["intShow"]);
             OrderType = Convert.ToString(Request.QueryString["OrderType"]);
             Response.Redirect("admin_orders.aspx?check=1&stDate=" + strStartDate + "&enDate=" + strToDate + "&ordNum=" + OrderNum + "&intShow=" + intShow + "&intLocId=" + intLocId + "&OrderType=" + OrderType, false);
             
         }
    }
}

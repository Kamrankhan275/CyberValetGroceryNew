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
    public partial class admin_delivery1 : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        DropdownProvider dropZip = new DropdownProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                try
                {
                    
                    BindGrid();
                    dropZip.binddeliverydateWeek(ddlDate);
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
                if (name == "Delivery Dates")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.DelieveryDateList;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        public void BindGrid()
        {
            lblMsg.Text = "";
            DataSet dsDeliveryDateList = new DataSet();
            dsDeliveryDateList = dbListInfo.GetDeliveryDateDetails();
            if (dsDeliveryDateList.Tables.Count > 0)
            {
                if (dsDeliveryDateList != null && dsDeliveryDateList.Tables.Count > 0 && dsDeliveryDateList.Tables[0].Rows.Count > 0)
                {
                    gridDeliveryDate.DataSource = dsDeliveryDateList;
                    gridDeliveryDate.DataBind();
                }
                else
                {
                    gridDeliveryDate.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gridDeliveryDate.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void gridDeliveryDate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDeliveryDate.PageIndex = e.NewPageIndex;            
            if (Convert.ToString(ViewState["DeliverySortExpression"]) == "" && Convert.ToString(ViewState["DeliveryDirection"]) == "")
            {

            BindGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["DeliverySortExpression"]),Convert.ToString(ViewState["DeliveryDirection"]));

            }
            
        }




        protected void gridDeliveryDate_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteDelivery")
                {
                    int intDeliveryID = Convert.ToInt32(e.CommandArgument);
                    BindDeleteGrid(intDeliveryID);

                }
                

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }


        public void BindDeleteGrid(int intDeliveryID)
        {
            int intDeleteDate = 0;            
            intDeleteDate = dbListInfo.DeleteDelievryDate(intDeliveryID);
            BindGrid();           

        }
                

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddDeliveryDate.aspx", false);
        }


        protected void gridDeliveryDate_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet dsDeliveryDateList = new DataSet();
            dsDeliveryDateList = dbListInfo.GetDeliveryDateDetails();
            if (dsDeliveryDateList.Tables.Count > 0)
            {
                if (dsDeliveryDateList != null && dsDeliveryDateList.Tables.Count > 0 && dsDeliveryDateList.Tables[0].Rows.Count > 0)
                {
                    DataTable dtSorting = dsDeliveryDateList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridDeliveryDate.DataSource = dvSorting;
                    gridDeliveryDate.DataBind();
                }
            }

            ViewState["DeliverySortExpression"] = sortExpression;
            ViewState["DeliveryDirection"] = direction;
            dbListInfo.dispose();
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ddlDate.SelectedValue != "Select")
            {
                string strdateid = ddlDate.SelectedValue.ToString();

                string strdeliverydate = string.Empty;
                int intDeleteDate = 0;
                int checkOrders = 0;
                DataSet dsorder = new DataSet();
                DataSet dsDeliveryDateList = new DataSet();
                dsDeliveryDateList = dbListInfo.GetOrderdeliverydataInfo(Convert.ToInt32(strdateid));
                if (dsDeliveryDateList.Tables.Count > 0)
                {
                    if (dsDeliveryDateList != null && dsDeliveryDateList.Tables.Count > 0 && dsDeliveryDateList.Tables[0].Rows.Count > 0)
                    {

                       

                        strdeliverydate = Convert.ToString(dsDeliveryDateList.Tables[0].Rows[0]["deliverydate_date"]);

                        dsorder = dbListInfo.GetOrderdeliverydataInfoDetails(strdeliverydate);

                       
                        DateTime date1 = Convert.ToDateTime(strdeliverydate);
                        string strdeliverydate1 = date1.ToShortDateString();
                        Response.Redirect("EditDeliveryDate.aspx?DeliveryDateID=" + strdateid + "&date=" + strdeliverydate1, false);
                      

                    }
                }

            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Text = "Please Select Delivery Date to Update.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
            }




        }



    }
}

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
    public partial class Viewdeliveryschedule : System.Web.UI.Page
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
                    string strDate = Request.QueryString["date"];
                    lblDate.Text = strDate;
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
                if (name == "Delivery Schedules")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbListInfo.dispose();
        }

        //Function for get short company name for page title
        public void getCompanyName()
        {
            string companyName = "";
            DbProvider dbGetCompanyName = new DbProvider();
            DataSet dsGetCompanyName = new DataSet();

            dsGetCompanyName = dbGetCompanyName.getShortCompanyName();

            if (dsGetCompanyName.Tables.Count > 0)
            {
                if (dsGetCompanyName != null && dsGetCompanyName.Tables.Count > 0 && dsGetCompanyName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetCompanyName.Tables[0].Rows)
                    {
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.DeliverySchedules;
                        companyName = Convert.ToString(dtrow["CompanyShortName"]);
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        public void BindGrid()
        {
            lblMsg.Text = "";
            string strDate = string.Empty;
            int locId = 0;
            strDate = Convert.ToString(Request.QueryString["date"]);
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            DataSet dsDeliveryDateList = new DataSet();
            dsDeliveryDateList = dbListInfo.GetDeliverySheduleDetails(strDate,locId);
            if (dsDeliveryDateList.Tables.Count > 0)
            {
                if (dsDeliveryDateList != null && dsDeliveryDateList.Tables.Count > 0 && dsDeliveryDateList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsDeliveryDateList.Tables[0].Rows)
                    {

                        //dtrow["orders_grocerytotal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_grocerytotal"]), 2));
                        //dtrow["orders_deliveryfee"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_deliveryfee"]), 2));
                        //dtrow["orders_tax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tax"]), 2));
                        //dtrow["orders_tip"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tip"]), 2));
                        //dtrow["orders_totalfinal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));

                        dtrow["orders_grocerytotal"] = Convert.ToDecimal(dtrow["orders_grocerytotal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        dtrow["orders_deliveryfee"] = Convert.ToDecimal(dtrow["orders_deliveryfee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        dtrow["orders_tax"] = Convert.ToDecimal(dtrow["orders_tax"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        dtrow["orders_tip"] = Convert.ToDecimal(dtrow["orders_tip"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        dtrow["orders_totalfinal"] = Convert.ToDecimal(dtrow["orders_totalfinal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);


                        if (Convert.ToString(dtrow["orders_paymenttype"]) == "AF")
                        {
                            dtrow["orders_complimentary"] = Convert.ToString(0.00);

                        }
                        else if (Convert.ToString(dtrow["orders_paymenttype"]) == "AF-CC")
                        {
                           // dtrow["orders_complimentary"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_complimentary"]), 2));
                            dtrow["orders_complimentary"] = Convert.ToDecimal(dtrow["orders_complimentary"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        }
                        else
                        {
                           // dtrow["orders_complimentary"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));
                            dtrow["orders_complimentary"] = Convert.ToDecimal(dtrow["orders_totalfinal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        }

                    }
                    gridDeliveryList.DataSource = dsDeliveryDateList;
                    gridDeliveryList.DataBind();
                }
                else
                {
                    gridDeliveryList.Visible = false;
                    imgBtnPrint.Visible = false;
                    btnViewShopping.Visible = false;
                    btnPrintAllRec.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gridDeliveryList.Visible = false;
                imgBtnPrint.Visible = false;
                btnViewShopping.Visible = false;
                btnPrintAllRec.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }



        }


        protected void gridDeliveryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDeliveryList.PageIndex = e.NewPageIndex;

            if (Convert.ToString(ViewState["DeliverySortExpression"]) == "" && Convert.ToString(ViewState["DeliveryDirection"]) == "")
            {
                BindGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["DeliverySortExpression"]), Convert.ToString(ViewState["DeliveryDirection"]));
            }
        }

        protected void gridDeliveryList_Sorting(object sender, GridViewSortEventArgs e)
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

            string strDate = string.Empty;
            int locId = 0;
            strDate = Convert.ToString(Request.QueryString["date"]);
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            DataSet dsDeliveryDateList = new DataSet();
            dsDeliveryDateList = dbListInfo.GetDeliverySheduleDetails(strDate,locId);
            if (dsDeliveryDateList.Tables.Count > 0)
            {
                if (dsDeliveryDateList != null && dsDeliveryDateList.Tables.Count > 0 && dsDeliveryDateList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsDeliveryDateList.Tables[0].Rows)
                    {

                        //dtrow["orders_grocerytotal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_grocerytotal"]), 2));
                        //dtrow["orders_deliveryfee"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_deliveryfee"]), 2));
                        //dtrow["orders_tax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tax"]), 2));
                        //dtrow["orders_tip"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tip"]), 2));
                        //dtrow["orders_totalfinal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));

                        dtrow["orders_grocerytotal"] = Convert.ToDecimal(dtrow["orders_grocerytotal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        dtrow["orders_deliveryfee"] = Convert.ToDecimal(dtrow["orders_deliveryfee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        dtrow["orders_tax"] = Convert.ToDecimal(dtrow["orders_tax"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        dtrow["orders_tip"] = Convert.ToDecimal(dtrow["orders_tip"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        dtrow["orders_totalfinal"] = Convert.ToDecimal(dtrow["orders_totalfinal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);



                        if (Convert.ToString(dtrow["orders_paymenttype"]) == "AF")
                        {
                            //dtrow["orders_complimentary"] = Convert.ToString(0.00);
                            dtrow["orders_complimentary"] = Convert.ToDecimal(dtrow["orders_complimentary"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        }
                        else if (Convert.ToString(dtrow["orders_paymenttype"]) == "AF-CC")
                        {
                            //dtrow["orders_complimentary"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_complimentary"]), 2));
                            dtrow["orders_complimentary"] = Convert.ToDecimal(dtrow["orders_complimentary"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        }
                        else
                        {
                            //dtrow["orders_complimentary"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));
                            dtrow["orders_complimentary"] = Convert.ToDecimal(dtrow["orders_totalfinal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        }

                    }
                  
                    DataTable dtSorting = dsDeliveryDateList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridDeliveryList.DataSource = dvSorting;
                    gridDeliveryList.DataBind();

                }
            }
            ViewState["DeliverySortExpression"] = sortExpression;
            ViewState["DeliveryDirection"]=direction;
            dbListInfo.dispose();
        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_deliveryschedule.aspx", false);

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_deliveryschedule.aspx", false);
        }


        protected void gridDeliveryList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateDelievry")
                {
                    int intOrderID = 0;
                    int intShedule = 0;
                    int intUpdate = 0;
                    double charges = 0;
                    intOrderID = Convert.ToInt32(e.CommandArgument);


                    for (int i = 0; i < gridDeliveryList.Rows.Count; i++)
                    {
                        TextBox txtGroceries;
                        TextBox txtDelivery;
                        TextBox txtTax;
                        TextBox txtTip;
                        TextBox txtTotal;
                        TextBox txtCharges;
                        ImageButton btnUpdate;
                        Label lblPayType;
                        Label lblTotal;
                        Label lblComplimentry;
                        GridViewRow item = gridDeliveryList.Rows[i];
                        txtGroceries = (TextBox)item.FindControl("txtGroceries");
                        txtDelivery = (TextBox)item.FindControl("txtDelivery");
                        txtTax = (TextBox)item.FindControl("txtTax");
                        txtTip = (TextBox)item.FindControl("txtTip");
                        txtTotal = (TextBox)item.FindControl("txtTotal");
                        txtCharges = (TextBox)item.FindControl("txtCharges");
                        btnUpdate = (ImageButton)item.FindControl("btnUpdate");
                        lblPayType = (Label)item.FindControl("lblPayType");
                        lblTotal = (Label)item.FindControl("lblTotal");
                        lblComplimentry = (Label)item.FindControl("lblCharges");
                        intShedule = Convert.ToInt32(btnUpdate.CommandArgument);
                        if (intOrderID == intShedule)
                        {

                            charges = Convert.ToDouble(lblComplimentry.Text) + (Convert.ToDouble(txtCharges.Text) - Convert.ToDouble(lblTotal.Text));
                            intUpdate = dbListInfo.UpdateDeliverySheduleDetails(intOrderID, Convert.ToDouble(txtGroceries.Text), Convert.ToDouble(txtDelivery.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtTip.Text), Convert.ToDouble(txtTotal.Text), charges);
                            if (intUpdate==1)
                            {
                                BindGrid();
                            }

                        }

                    }

                }



            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }


      


        protected void imgBtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            string strDate = string.Empty;
            int locId = 0;
            strDate = Convert.ToString(Request.QueryString["date"]);
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            //Response.Write("<script language='javascript'> window.open('DeliverySchedulePrint.aspx', 'window','HEIGHT=600,WIDTH=820,top=50,left=50,toolbar=yes,scrollbars=yes,resizable=yes');</script>");

            Response.Write("<script>window.open('DeliverySchedulePrint.aspx?date=" + strDate + "&locId=" + locId + "','_blank');</script>");

            changeLinks();
            getCompanyName();
            //Response.Redirect("DeliverySchedulePrint.aspx", false);
           

        }

      

        protected void btnViewShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewShoppingListDetail.aspx?deliveryId=" + Request.QueryString["date"]);
        }

        protected void btnPrintAllRec_Click(object sender, EventArgs e)
        {
            string strDate = string.Empty;
            int locId = 0;
            strDate = Convert.ToString(Request.QueryString["date"]);
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            Response.Write("<script>window.open('UserAllOrderDeatilsPrint.aspx?date=" + strDate + "&locId=" + locId + "','_blank');</script>");
            changeLinks();
            getCompanyName();
        }

       


    }
}

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
    public partial class EditTodaysDelivery : System.Web.UI.Page
    {
        DbProvider dbEditInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                try
                {
                    DataSet dsTodaysDeliveryList = new DataSet();
                    changeLinks();
                    btnUpdate.Attributes.Add("onclick", "clcontent();");
                    if (!IsPostBack)
                    {
                        lblMsg.Text = "";
                        //dropTopAisle.bindTopAisleCheckbox(chkTopAisles);//Bind Checkbox into dropdown
                        int intTimeId = Convert.ToInt32(Request.QueryString["TimeId"]);
                        dsTodaysDeliveryList = dbEditInfo.SelectTimeDeatils(intTimeId);
                        if (dsTodaysDeliveryList.Tables.Count > 0)
                        {
                            if (dsTodaysDeliveryList != null && dsTodaysDeliveryList.Tables.Count > 0 && dsTodaysDeliveryList.Tables[0].Rows.Count > 0)
                            {
                                txtStartTime.Text = Convert.ToString(dsTodaysDeliveryList.Tables[0].Rows[0]["StartTime"]);

                                if (Convert.ToString(dsTodaysDeliveryList.Tables[0].Rows[0]["AM_PM"]) == "AM")
                                {
                                    drpStartTime.SelectedValue = "1";
                                }
                                else
                                {
                                    drpStartTime.SelectedValue = "2";

                                }
                                txtEndTime.Text = Convert.ToString(dsTodaysDeliveryList.Tables[0].Rows[0]["EndTime"]);

                                if (Convert.ToString(dsTodaysDeliveryList.Tables[0].Rows[0]["PM_AM"]) == "PM")
                                {
                                    drpEndTime.SelectedValue = "2";

                                }
                                else
                                {
                                    drpEndTime.SelectedValue = "1";
                                }

                                if (Convert.ToString(dsTodaysDeliveryList.Tables[0].Rows[0]["ShowHide"]) == "0")
                                {
                                    rdShow.SelectedValue = "0";
                                }
                                else
                                {
                                    rdShow.SelectedValue = "1";
                                }
                            }
                        }
                    }
                    dbEditInfo.dispose();

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.UpdateTodaysDelivery;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbEditInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbEditInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbEditInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            dbEditInfo.dispose();
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            Response.Redirect("admin_TodaysDelivery.aspx", false);
        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            Response.Redirect("admin_TodaysDelivery.aspx", false);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                int intUpdateTime = 0;
                int intTimeId = 0;

                int intTime = Convert.ToInt32(Request.QueryString["TimeId"]);
                intTimeId = dbEditInfo.TimeUpdateAlreadyExist(Convert.ToInt32(txtStartTime.Text), Convert.ToString(drpStartTime.SelectedItem.Text), Convert.ToInt32(txtEndTime.Text), Convert.ToString(drpEndTime.SelectedItem.Text), Convert.ToInt32(rdShow.SelectedValue), intTime);
                if (intTimeId == 0)
                {

                    intUpdateTime = dbEditInfo.UpdateTimeInfo(Convert.ToInt32(txtStartTime.Text), Convert.ToString(drpStartTime.SelectedItem.Text), Convert.ToInt32(txtEndTime.Text), Convert.ToString(drpEndTime.SelectedItem.Text), Convert.ToInt32(rdShow.SelectedValue), intTime);

                    if (intUpdateTime == 1)
                    {

                        lblMsg.Text = AppConstants.TodayTimeUpdateSuccess;
                        lblMsg.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.TodayTimeUpdateFailed;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.TodayTimeAlreadyExist;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                dbEditInfo.dispose();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}
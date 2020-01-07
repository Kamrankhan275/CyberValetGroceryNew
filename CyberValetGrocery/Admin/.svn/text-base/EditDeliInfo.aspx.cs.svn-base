using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CyberValetGrocery.Class;
using System.Data;
namespace CyberValetGrocery.Admin
{
    public partial class EditDeliInfo : System.Web.UI.Page
    {
        DbProvider dbEditInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {

            btnUpdate.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            try
            {

                DataSet dsDeliInfoList = new DataSet();
                DataSet dsTopAisleMappingList = new DataSet();
                changeLinks();
                btnUpdate.Attributes.Add("onclick", "clcontent();");
                if (!IsPostBack)
                {

                    lblMsg.Text = "";
                    //dropTopAisle.bindTopAisleCheckbox(chkTopAisles);//Bind Checkbox into dropdown
                    int intDeliInfoId = Convert.ToInt32(Request.QueryString["DeliInfoId"]);
                    dsDeliInfoList = dbEditInfo.SelectDeliInfoDeatils(intDeliInfoId);
                    if (dsDeliInfoList.Tables.Count > 0)
                    {
                        if (dsDeliInfoList != null && dsDeliInfoList.Tables.Count > 0 && dsDeliInfoList.Tables[0].Rows.Count > 0)
                        {
                            txtDeliveryName.Text = Convert.ToString(dsDeliInfoList.Tables[0].Rows[0]["DeliveryName"]);

                            if (Convert.ToString(dsDeliInfoList.Tables[0].Rows[0]["Status"]) == "0")
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
                if (name == "Delivery Info")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbEditInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.UpdateDeliveryInfo;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_DeliveryInfo.aspx", false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_DeliveryInfo.aspx", false);

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                int intUpdateDeliveryInfo = 0;
                int intDelInfoId = 0;
                int DelInfoId = Convert.ToInt32(Request.QueryString["DeliInfoId"]);
                intDelInfoId = dbEditInfo.UpdateDeliInfoAlreadyExist(txtDeliveryName.Text, DelInfoId);
                if (intDelInfoId == 0)
                {

                    intUpdateDeliveryInfo = dbEditInfo.UpdateDeliveryInfo(txtDeliveryName.Text, Convert.ToInt32(rdShow.SelectedValue), DelInfoId);

                    if (intUpdateDeliveryInfo == 1)
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.DeliveryInfoUpdateSuccess;
                        lblMsg.ForeColor = System.Drawing.Color.Black;

                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.DeliveryInfoUpdateFailed;
                        lblMsg.ForeColor = System.Drawing.Color.Red;

                    }

                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.DeliveryInfoAlreadyExist;
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

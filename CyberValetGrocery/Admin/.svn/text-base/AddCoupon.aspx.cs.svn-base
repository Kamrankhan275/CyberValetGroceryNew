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
    public partial class AddCoupon : System.Web.UI.Page
    {
        DbProvider dbAddInfo = new DbProvider();
        DropdownProvider dropLocation = new DropdownProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnAdd.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
               
                dropLocation.bindLocationDropdown(drpLocation);//Bind location  into dropdown
                lblMsg.Text = "";
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.AddCoupon;
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
            DataSet dsAdminCustomers = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int intInsertCoupons = 0;
                int status = 0;
                int intCoupons = 0;
                intCoupons = dbAddInfo.couponsCodeAlreadyExist(txtCouponName.Text);
                if (intCoupons == 0)
                {

                    intInsertCoupons = dbAddInfo.InsertCouponsInfo(txtCouponName.Text, Convert.ToDouble(txtAmount.Text), Convert.ToInt32(drpLocation.SelectedValue), status);
                    if (intInsertCoupons == 1)
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.couponAddSuccess;
                        lblMsg.ForeColor = System.Drawing.Color.Black;
                        txtCouponName.Text = "";
                        txtAmount.Text = "";
                        drpLocation.SelectedValue = "Select";

                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.couponAddFailed;
                        lblMsg.ForeColor = System.Drawing.Color.Red;

                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.couponAlreadyExist;
                    lblMsg.ForeColor = System.Drawing.Color.Red;


                }


              


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            Response.Redirect("admin_coupon.aspx", false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            Response.Redirect("admin_coupon.aspx", false);


        }
    }
}

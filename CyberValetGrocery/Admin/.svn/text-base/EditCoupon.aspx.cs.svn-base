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
    public partial class EditCoupon : System.Web.UI.Page
    {
        DbProvider dbEditInfo = new DbProvider();
        DropdownProvider dropLocation = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet dsCouponList = new DataSet();
                changeLinks();
                getCompanyName();
                btnUpdate.Attributes.Add("onclick", "clcontent();");
                if (!IsPostBack)
                {
                    dropLocation.bindLocationDropdown(drpLocation);//Bind Location  into dropdown
                    lblMsg.Text = "";
                    int couponId = Convert.ToInt32(Request.QueryString["couponId"]);
                    dsCouponList = dbEditInfo.selectCouponsDeatils(couponId);
                    if (dsCouponList.Tables.Count > 0)
                    {
                        if (dsCouponList != null && dsCouponList.Tables.Count > 0 && dsCouponList.Tables[0].Rows.Count > 0)
                        {
                           
                            //txtAmount.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsCouponList.Tables[0].Rows[0]["coupon_amount"]),2));
                            txtAmount.Text = Convert.ToDecimal(dsCouponList.Tables[0].Rows[0]["coupon_amount"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            txtCouponName.Text = Convert.ToString(dsCouponList.Tables[0].Rows[0]["coupon_code"]);
                            drpLocation.SelectedValue = Convert.ToString(dsCouponList.Tables[0].Rows[0]["location_id"]);
                        }
                    }

                   
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
                if (name == "Coupons")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.UpdateCoupon;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
              
                int intCoupons = 0;
                int intUpdateCoupons = 0;
                int couponId = Convert.ToInt32(Request.QueryString["couponId"]);
                intCoupons = dbEditInfo.couponsCodeAlreadyUpdateExist(txtCouponName.Text,couponId);
                if (intCoupons == 0)
                {
                    intUpdateCoupons = dbEditInfo.UpdateCouponsInfo(txtCouponName.Text, Convert.ToDouble(txtAmount.Text), Convert.ToInt32(drpLocation.SelectedValue), couponId);
                    if (intUpdateCoupons == 1)
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.couponUpdateSuccess;
                        lblMsg.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.couponUpdateFailed;
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

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_coupon.aspx", false);

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_coupon.aspx", false);

        }
    }
}

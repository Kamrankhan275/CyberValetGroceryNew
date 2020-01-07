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

namespace CyberValetGrocery
{
    public partial class CouponPop : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["userId"] == null)
                {
                    Response.Redirect("LoginPage.aspx", false);

                }
                else
                {
                    btnAdd.Attributes.Add("onclick", "clcontent();");
                    getCompanyName();
                    if (!IsPostBack)
                    {
                        string strcoupon = string.Empty;
                        strcoupon = Convert.ToString(Request.QueryString["coupon"]);
                        txtCouponName.Text = strcoupon;
                        pnlCoupon.Visible = true;
                        pnlMSg.Visible = false;
                        DataSet dsUserInfo = new DataSet();

                        dsUserInfo = dbInfo.GetUserDetailsInfo(Convert.ToInt32(Request.Cookies["userId"].Value));

                        if (dsUserInfo.Tables.Count > 0)
                        {
                            if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                            {
                                ViewState["UsersFname"] = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_fname"]);
                                ViewState["UsersAccValue"] = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_accountvalue"]);
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
                        ViewState["ContactEmail"] = Convert.ToString(dtrow["ContactEmail"]);
                        ViewState["CompanyShortName"] = Convert.ToString(dtrow["CompanyShortName"]);

                    }
                }
            }
            dbGetCompanyName.dispose();
        }





        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                 DataSet dsCouponDetail = new DataSet();

                 dsCouponDetail = dbInfo.GetCouponDetailInfo(txtCouponName.Text);

                 if (dsCouponDetail.Tables.Count > 0)
                 {
                     if (dsCouponDetail != null && dsCouponDetail.Tables.Count > 0 && dsCouponDetail.Tables[0].Rows.Count > 0)
                     {



                         DataSet dsCoupon = new DataSet();

                         dsCoupon = dbInfo.GetCouponInformation(txtCouponName.Text);

                         if (dsCoupon.Tables.Count > 0)
                         {
                             if (dsCoupon != null && dsCoupon.Tables.Count > 0 && dsCoupon.Tables[0].Rows.Count > 0)
                             {
                                 lblMsg.Text = "";
                                 lblMsg.Text = AppConstants.couponAlreadyUsed;
                             }
                             else
                             {

                                 DataSet dsUserCoupon = new DataSet();

                                 dsUserCoupon = dbInfo.GetUserCouponInfo(txtCouponName.Text, Convert.ToInt32(Request.Cookies["userId"].Value));
                                 if (dsUserCoupon.Tables.Count > 0)
                                 {
                                     if (dsUserCoupon != null && dsUserCoupon.Tables.Count > 0 && dsUserCoupon.Tables[0].Rows.Count > 0)
                                     {
                                         lblMsg.Text = "";
                                         lblMsg.Text = AppConstants.couponAlreadyUsed;
                                     }
                                     else
                                     {

                                         CouponAmountTransaction(txtCouponName.Text, Convert.ToInt32(Request.Cookies["userId"].Value));



                                     }
                                 }


                             }
                         }
                         else
                         {

                             DataSet dsUserCoupon = new DataSet();

                             dsUserCoupon = dbInfo.GetUserCouponInfo(txtCouponName.Text, Convert.ToInt32(Request.Cookies["userId"].Value));
                             if (dsUserCoupon.Tables.Count > 0)
                             {
                                 if (dsUserCoupon != null && dsUserCoupon.Tables.Count > 0 && dsUserCoupon.Tables[0].Rows.Count > 0)
                                 {
                                     lblMsg.Text = "";
                                     lblMsg.Text = AppConstants.couponAlreadyUsed;
                                 }
                                 else
                                 {

                                     CouponAmountTransaction(txtCouponName.Text, Convert.ToInt32(Request.Cookies["userId"].Value));



                                 }
                             }


                         }
                     }
                     else
                     {
                         lblMsg.Text = "";
                         lblMsg.Text = AppConstants.couponInvalid;

                     }
                 }
                 else
                 {
                     lblMsg.Text = "";
                     lblMsg.Text = AppConstants.couponInvalid;

                 }
                   


                dbInfo.dispose();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        public void CouponAmountTransaction(string coupon, int intUserId)
        {
            int intReturn = 0;
            int intAddTran = 0;
            int intCouponLink = 0;
            int intUpdateUser = 0;
            double amt = 0;
            string strCommment = string.Empty;
            double totAccBal = 0;

            DataSet dsUserCoupon = new DataSet();
            DataSet dsUserInformation = new DataSet();
            dsUserCoupon = dbInfo.GetCouponDetailInfo(txtCouponName.Text);
            if (dsUserCoupon.Tables.Count > 0)
            {
                if (dsUserCoupon != null && dsUserCoupon.Tables.Count > 0 && dsUserCoupon.Tables[0].Rows.Count > 0)
                {
                    
                    if (Convert.ToString(dsUserCoupon.Tables[0].Rows[0]["coupon_amount"]) != "")
                    {
                        amt =Math.Round(Convert.ToDouble(dsUserCoupon.Tables[0].Rows[0]["coupon_amount"]),2);

                    }
                    strCommment = Convert.ToString(ViewState["CompanyShortName"]) + " - " + Convert.ToString(dsUserCoupon.Tables[0].Rows[0]["coupon_code"]);
                    intAddTran = dbInfo.InsertUserCouponTransaction(DateTime.Now, amt, intUserId, strCommment, Convert.ToString(ViewState["CompanyShortName"]), Convert.ToInt32(dsUserCoupon.Tables[0].Rows[0]["coupon_id"]));
                    if (intAddTran == 1)
                    {

                        intCouponLink = dbInfo.InsertUserCouponLink(intUserId, Convert.ToInt32(dsUserCoupon.Tables[0].Rows[0]["coupon_id"]));

                        if (intCouponLink == 1)
                        {
                            totAccBal =Math.Round(Convert.ToDouble(ViewState["UsersAccValue"]),2) + amt;

                            intUpdateUser = dbInfo.UpdateUserAccInfo(intUserId, totAccBal);

                            if (intUpdateUser == 1)
                            {


                                intReturn = 0;
                                

                            }
                            else
                            {
                                intReturn = 1;

                            }
                        }
                        else
                        {
                            intReturn = 1;

                        }
                        

                    }
                    else
                    {
                        intReturn = 1;

                    }


                }
            }

            if (intReturn == 0)
            {
                lblMsg.Text = "";
                pnlCoupon.Visible = false;
                pnlMSg.Visible = true;
                lblName.Text = Convert.ToString(ViewState["UsersFname"]);
                lblAccVal.Text = Convert.ToString(amt);
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.tranFailed;
                pnlCoupon.Visible = true;
                pnlMSg.Visible = false;
               

            }



            dbInfo.dispose();
           

        }



    }
}

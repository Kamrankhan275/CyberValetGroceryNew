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
    public partial class EditUser : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        PasswordRestrictions EncryptDecrypt = new PasswordRestrictions();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Attributes.Add("onclick", "clcontent();");
                changeLinks();
                getCompanyName();

                if (!IsPostBack)
                {
                    lblMsg.Text = "";
                    int userId = Convert.ToInt32(Request.QueryString["userId"]);
                    DateTime dtJoin = new DateTime();
                    string strDate = string.Empty;
                    string strDay = string.Empty;
                    string strMonth = string.Empty;
                    DataSet dsUserList = new DataSet();
                    dsUserList = dbListInfo.GetHomeUserInformation(userId);

                    bool isMember = false;

                    if (dsUserList.Tables.Count > 0)
                    {
                        if (dsUserList != null && dsUserList.Tables.Count > 0 && dsUserList.Tables[0].Rows.Count > 0)
                        {
                            dtJoin = Convert.ToDateTime(dsUserList.Tables[0].Rows[0]["users_regdate"]);

                            if (dtJoin.Month < 10)
                            {
                                strMonth = "0" + Convert.ToString(dtJoin.Month);
                            }
                            else
                            {
                                strMonth = Convert.ToString(dtJoin.Month);
                            }

                            if (dtJoin.Day < 10)
                            {
                                strDay = "0" + Convert.ToString(dtJoin.Day);
                            }
                            else
                            {
                                strDay = Convert.ToString(dtJoin.Day);
                            }

                            isMember = Convert.ToBoolean(dsUserList.Tables[0].Rows[0]["Users_Membership"]);

                            if (isMember)
                            {
                                chkMembership.Checked = true;
                            }

                            strDate = strMonth + "/" + strDay + "/" + dtJoin.Year;
                            lblJoinedDate.Text = Convert.ToString(strDate);
                            txtFName.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_fname"]);
                            txtLName.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_lname"]);
                            txtEmail.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_email"]);
                            txtPhone.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_phone"]);
                            string strPass = EncryptDecrypt.decryptPassword(Convert.ToString(dsUserList.Tables[0].Rows[0]["users_password"]));
                            // string strPass = EncryptDecrypt.decryptPassword("+wn9ic+TlO19/JBPOVezpg==");
                            txtPassword.Text = strPass;
                            ViewState["UserPassword"] = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_password"]);
                            txtCell.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_cell"]);

                            if (Convert.ToString(dsUserList.Tables[0].Rows[0]["users_newsletter"]) == "1")
                            {
                                chkMailingList.Checked = true;
                            }
                            //if (Convert.ToString(dsUserList.Tables[0].Rows[0]["usersstatus_id"]) == "1")
                            //{
                            drpStatus.SelectedValue = Convert.ToString(dsUserList.Tables[0].Rows[0]["usersstatus_id"]);
                            //}

                            //Delivery info
                            txtDeliveryAdd1.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_address1"]);
                            txtDeliveryAdd2.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_address2"]);
                            txtDeliveryCity.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_city"]);
                            txtDeliveryState.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_state"]);
                            txtDeliveryZip.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_zip"]);

                            // Billing  info
                            txtBillingAdd1.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_baddress1"]);
                            txtBillingAdd2.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_baddress2"]);
                            txtBillingCity.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_bcity"]);
                            txtBillingState.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_bstate"]);
                            txtBillingZip.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_bzip"]);
                            //txtCreditCard.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_creditcard"]);
                            //txtExpiration.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_expirationdate"]);
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.UserUpdate;
                    }
                }
            }

            dbGetCompanyName.dispose();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string strEncrypt = string.Empty;
                string chkMail = string.Empty;
                int intChkValidation = checkValidation();
                int intUser = 0;
                int intStatus = 0;
                int intUpdateUSer = 0;

                int userId = Convert.ToInt32(Request.QueryString["userId"]);

                if (intChkValidation == 0)
                {
                    intUser = dbListInfo.userEmailAlreadyExist(txtEmail.Text, userId);

                    if (intUser == 0)
                    {
                        if (chkMailingList.Checked == true)
                        {
                            chkMail = "1";
                        }
                        else
                        {
                            chkMail = "0";
                        }

                        if (Convert.ToInt32(drpStatus.SelectedValue) == 1)
                        {
                            intStatus = 1;
                        }
                        else
                        {
                            intStatus = 0;
                        }

                        if (txtPassword.Text == "")
                        {
                            strEncrypt = Convert.ToString(ViewState["UserPassword"]);
                        }
                        else
                        {
                            strEncrypt = EncryptDecrypt.encryptPassword(txtPassword.Text);
                        }

                        intUpdateUSer = dbListInfo.UpdateUserInformation(txtFName.Text, txtLName.Text, txtEmail.Text, strEncrypt, txtPhone.Text, txtCell.Text, chkMail, intStatus, txtDeliveryAdd1.Text, txtDeliveryAdd2.Text, txtDeliveryCity.Text, txtDeliveryState.Text, txtDeliveryZip.Text, txtBillingAdd1.Text, txtBillingAdd2.Text, txtBillingCity.Text, txtBillingState.Text, txtBillingZip.Text, userId, chkMembership.Checked);

                        if (intUpdateUSer != 0)
                        {
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.userUpdateSuccess;
                            lblMsg.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.userUpdateFailed;
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.userEmailExist;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public int checkValidation()
        {
            DataValidator dataValidator = new DataValidator();
            bool returnEmail;
            bool returnPhone;
            int intReturn = 0;
            returnEmail = DataValidator.IsValidEmail(Convert.ToString(txtEmail.Text));
            returnPhone = DataValidator.IsValidPhone(Convert.ToString(txtPhone.Text));

            if (returnEmail == false)
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.invalidEmail;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;
            }
            else if (returnPhone == false)
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.invalidPhone;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;
            }

            return intReturn;
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
            Response.Redirect("ViewUserInformation.aspx?strKey=" + strKey + "&intIn=" + intIn + "&SortBy=" + intSortBy + "&locId=" + locId + "&perPage=" + perPage, false);
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
            Response.Redirect("ViewUserInformation.aspx?strKey=" + strKey + "&intIn=" + intIn + "&SortBy=" + intSortBy + "&locId=" + locId + "&perPage=" + perPage, false);
        }
    }
}

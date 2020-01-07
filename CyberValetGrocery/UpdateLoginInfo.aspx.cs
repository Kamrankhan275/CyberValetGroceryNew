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
    public partial class UpdateLoginInfo : System.Web.UI.Page
    {

        DbProvider dbInfo = new DbProvider();
        PasswordRestrictions pwdRestrict = new PasswordRestrictions();
        string demo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["userId"] == null)
                {
                    Response.Redirect("My_Account.aspx", false);
                }
                else
                {
                 txtEmail.Attributes.Add("onblur", "CheckEmailAvailability();");
                 btnUpdate.Attributes.Add("onclick", "clcontent();");
                BindSideLink();
                getCompanyName();
                if (!IsPostBack)
                {
                        int userId = 0;
                        string strPass = string.Empty;
                        userId = Convert.ToInt32(Request.Cookies["userId"].Value);
                        DataSet dsUserDetailsInfo = new DataSet();
                        dsUserDetailsInfo = dbInfo.GetUserDetailsInfo(userId);
                        if (dsUserDetailsInfo.Tables.Count > 0)
                        {
                            if (dsUserDetailsInfo != null && dsUserDetailsInfo.Tables.Count > 0 && dsUserDetailsInfo.Tables[0].Rows.Count > 0)
                            {
                                txtEmail.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_email"]);
                                txtReEmail.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_email"]);
                                demo = pwdRestrict.decryptPassword(Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_password"]));
                                strPass = pwdRestrict.encryptPassword(Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_password"]));//Code to encrypt the password.
                                txtPassword.Text = strPass;
                                txtRePassword.Text = strPass;
                                //ViewState["UserPassword"] = strPass;
                                ViewState["UserPassword"] = demo;
                                ViewState["Useremail"] = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_email"]);
                            }

                        }
                        dbInfo.dispose();


                }
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
        public void BindSideLink()
        {
            Panel pnlHow = (Panel)Page.Master.FindControl("pnlHow");
            pnlHow.Visible = false;
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = false;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = true;
            Panel pnlAccNoLogin = (Panel)Page.Master.FindControl("pnlAccNoLogin");
            pnlAccNoLogin.Visible = false;
            Panel pnlAccLog = (Panel)Page.Master.FindControl("pnlAccLog");
            pnlAccLog.Visible = true;


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgMyAccount;

                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string strPassNew = string.Empty;
                int intUpdate = 0;
                int userId = 0;
                int intChkValidation = checkValidation();
                if (intChkValidation == 0)
                {
                    userId = Convert.ToInt32(Request.Cookies["userId"].Value);
                    DataSet dsUserDetailsInfo = new DataSet();
                    dsUserDetailsInfo = dbInfo.GetUserEmailalreadyExit(userId, txtEmail.Text);
                    int intEmailChk = 0;
                    if (dsUserDetailsInfo.Tables.Count > 0)
                    {
                        if (dsUserDetailsInfo != null && dsUserDetailsInfo.Tables.Count > 0 && dsUserDetailsInfo.Tables[0].Rows.Count > 0)
                        {
                            string strOldEmail = string.Empty;
                            strOldEmail = Convert.ToString(ViewState["Useremail"]);
                            if (strOldEmail != txtEmail.Text)
                            {
                                intEmailChk = 1;
                                lblMsg.Text = "";
                                lblMsg.Text = AppConstants.userEmailAlreadyExist;
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                            }


                        }
                    }
                    if (intEmailChk == 0)
                    {

                        if (txtPassword.Text == Convert.ToString(ViewState["UserPassword"]))
                        {
                            strPassNew = Convert.ToString(ViewState["UserPassword"]);
                        }
                        else if ((txtPassword.Text == "") || (txtPassword.Text == null))
                        {
                            strPassNew = pwdRestrict.encryptPassword(Convert.ToString(ViewState["UserPassword"]));
                        }
                        else
                        {
                            strPassNew = pwdRestrict.encryptPassword(Convert.ToString(txtPassword.Text));//Code to encrypt the password.
                        }

                        intUpdate = dbInfo.UpdateUserLoginDetailsInfo(txtEmail.Text, strPassNew, userId);
                        if (intUpdate == 1)
                        {
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.userUpdateLoginInfoSuccuss;
                            lblMsg.ForeColor = System.Drawing.Color.Black;

                        }
                        else
                        {
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.userUpdateLoginInfoFailed;
                            lblMsg.ForeColor = System.Drawing.Color.Red;

                        }





                    }
                }



                else
                {
                    if (txtPassword.Text == Convert.ToString(ViewState["UserPassword"]))
                    {
                        strPassNew = Convert.ToString(ViewState["UserPassword"]);
                    }
                    else
                    {
                        strPassNew = pwdRestrict.decryptPassword(Convert.ToString(txtPassword.Text));//Code to encrypt the password.
                    }
                    intUpdate = dbInfo.UpdateUserLoginDetailsInfo(txtEmail.Text, strPassNew, userId);
                    if (intUpdate == 1)
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.userUpdateLoginInfoSuccuss;
                        lblMsg.ForeColor = System.Drawing.Color.Black;

                    }



                }

                      
                
                dbInfo.dispose();

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
            int intReturn = 0;
            int intCheck = 0;
            string strMsg = string.Empty;
            returnEmail = DataValidator.IsValidEmail(Convert.ToString(txtEmail.Text));
            if (txtPassword.Text != "")
            {
                if (txtRePassword.Text == "")
                {
                    strMsg = AppConstants.UserRetypePassword;
                    intCheck = 1;
                }
                

            }

            if (returnEmail == false)
            {
                strMsg = strMsg+"<br>"+AppConstants.invalidUserRegEmail;
                intCheck = 1;
            }


            if (intCheck == 1)
            {
                lblMsg.Text = "";
                lblMsg.Text = strMsg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;


            }



            return intReturn;


        }
    }
}

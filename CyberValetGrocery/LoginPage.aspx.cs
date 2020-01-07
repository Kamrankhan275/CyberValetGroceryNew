﻿using System;
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
using System.Configuration;
using System.Collections;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Globalization;
using System.Collections.Specialized;
using System.Drawing.Drawing2D;
using System.IO;

namespace CyberValetGrocery
{
    public partial class LoginPage : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                BindSideLink();
                getCompanyName();
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                lblMsg.Text = "";
                Page.Form.DefaultButton = btnLogin.UniqueID;
                btnLogin.Attributes.Add("onkeypress", "clcontent();");

                if (!IsPostBack)
                {
                    lblCompanyNm.Text = Convert.ToString(ViewState["CompanyName"]);

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
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = true;

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgLoginPage;
                        ViewState["CompanyName"] = Convert.ToString(dtrow["CompanyShortName"]);
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void createCookie(string strUserId)
        {


            HttpCookie userId = new HttpCookie("userId", strUserId);
            Response.Cookies.Add(userId);
           

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string strUserId = string.Empty;
                string strUserName = string.Empty;
                lblMsg.Text = "";
                //string strPass = string.Empty;
                PasswordRestrictions pwdRestrict = new PasswordRestrictions();
                string strPass = pwdRestrict.encryptPassword(txtPassword.Text);//Code to encrypt the password.
               // string strPass = pwdRestrict.decryptPassword(txtPassword.Text);//Code to encrypt the password.
                DataSet dsLogin = dbInfo.GetUserLoginInfo(txtEmail.Text, strPass);//To fetch admin id from database with the username and  password provided by user.
                if (dsLogin.Tables[0].Rows.Count > 0)
                {
                    if (dsLogin != null && dsLogin.Tables.Count > 0 && dsLogin.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drLogin in dsLogin.Tables[0].Rows)
                        {

                            strUserId = Convert.ToString(drLogin["users_id"]);
                            strUserName = Convert.ToString(drLogin["users_fname"]) + " " + Convert.ToString(drLogin["users_lname"]);
                            Session["LoginUserName"] = strUserName;
                            createCookie(strUserId);
                              Response.Redirect("product_order.aspx", false);
                            //Response.Redirect(ConfigurationSettings.AppSettings["strHTTPSLinkProductOrder"], false);
                        }
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.userLoginFailed;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    txtEmail.Text = "";
                    txtPassword.Text = "";

                }

                dbInfo.dispose();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }
    }
}

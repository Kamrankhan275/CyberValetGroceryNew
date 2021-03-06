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

namespace CyberValetGrocery.Admin
{
    public partial class index : System.Web.UI.Page
    {
        DbProvider dbloginInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsSecureConnection)
            {
                //String sNewURL = "https://" + Request.ServerVariables["SERVER_NAME"] + Request.ServerVariables["URL"];
                //Response.Redirect(sNewURL);
            }
            getCompanyName();
            if (!IsPostBack)
            {
                lblMsg.Text = "";


            }


        }

        protected void createCookie(string strAdminId)
        {         


            HttpCookie adminId = new HttpCookie("adminId", strAdminId);
            Response.Cookies.Add(adminId);
            adminId.Expires = DateTime.Now.AddDays(1);

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.LoginPage;
                      
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
               string strAdminId = string.Empty;
                lblMsg.Text = "";
                PasswordRestrictions pwdRestrict = new PasswordRestrictions();
                string strPass = pwdRestrict.encryptPassword(txtAdminPassword.Text);//Code to encrypt the password.
                //string depas = pwdRestrict.decryptPassword(txtAdminPassword.Text);
                DataSet dsAdminLogin = dbloginInfo.GetLoginInfo(txtAdminEmail.Text, strPass);//To fetch admin id from database with the username and  password provided by user.
                if (dsAdminLogin.Tables[0].Rows.Count > 0)
                {
                    if (dsAdminLogin != null && dsAdminLogin.Tables.Count > 0 && dsAdminLogin.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drLogin in dsAdminLogin.Tables[0].Rows)
                        {

                            strAdminId = Convert.ToString(drLogin["admin_id"]);
                            createCookie(strAdminId);
                            Response.Redirect("index3.aspx", false);
                            
                        
                        
                        }
                    }
                }
                else
                {
                    lblMsg.Text = AppConstants.loginFailed;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    txtAdminEmail.Text = "";
                    txtAdminPassword.Text = "";

                }





              

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }

        protected void btnForgot_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("ForgotPassword.aspx", false);
               

            }
            catch (Exception ex)
            {
               Response.Write(ex.Message);

            }

        }
    }
}

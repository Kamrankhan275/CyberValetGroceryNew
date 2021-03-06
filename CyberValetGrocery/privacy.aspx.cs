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

namespace CyberValetGrocery
{
    public partial class privacy : System.Web.UI.Page
    {
       
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindSideLink();
                getCompanyName();
                if (!IsPostBack)
                {
                    //lblCmpNm.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm1.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm2.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm3.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm4.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm5.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm6.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm7.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm8.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm9.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm10.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm11.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm12.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm13.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm14.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm15.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm16.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm17.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm18.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm19.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm20.Text = Convert.ToString(ViewState["CompanyShortName"]);
                    //lblCmpNm21.Text = Convert.ToString(ViewState["CompanyShortName"]);

                    //lblWebsiteUrl.Text = Convert.ToString(ViewState["ShortURL"]);
                    //lblWebsiteUrl1.Text = Convert.ToString(ViewState["ShortURL"]);
                    
                   


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
            pnlHow.Visible = true;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = false;

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgPrivacyPolicy;
                        ViewState["ContactEmail"] = Convert.ToString(dtrow["ContactEmail"]);
                        ViewState["ShortURL"] = Convert.ToString(dtrow["ShortURL"]);
                        ViewState["CompanyShortName"] = Convert.ToString(dtrow["CompanyShortName"]);

                    }
                }
            }
            dbGetCompanyName.dispose();
        }
    }
}

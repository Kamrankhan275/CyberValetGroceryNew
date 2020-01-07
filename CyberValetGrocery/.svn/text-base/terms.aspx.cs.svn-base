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
    public partial class terms : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                BindSideLink();
                getCompanyName();
                //lblCompanyNm.Text = Convert.ToString(ViewState["CompanyName"]);
                //lblCompanyNm1.Text = Convert.ToString(ViewState["CompanyName"]);
                //lblCompanyNm2.Text = Convert.ToString(ViewState["CompanyName"]);
                //lblCompanyNm3.Text = Convert.ToString(ViewState["CompanyName"]);
                //lblCompanyNm4.Text = Convert.ToString(ViewState["CompanyName"]);
                //lblCompanyNm5.Text = Convert.ToString(ViewState["CompanyName"]);
                //lblCompanyNm6.Text = Convert.ToString(ViewState["CompanyName"]);
                //lblCompanyNm7.Text = Convert.ToString(ViewState["CompanyName"]);
                //lblCompanyNm8.Text = Convert.ToString(ViewState["CompanyName"]);
                //lblCompanyNm9.Text = Convert.ToString(ViewState["CompanyName"]);
                //lblShortNm.Text = Convert.ToString(ViewState["ShortName"]);
                //lblShortNm1.Text = Convert.ToString(ViewState["ShortName"]);
                //lblShortNm2.Text = Convert.ToString(ViewState["ShortName"]);
                if (!IsPostBack)
                {

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
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = false;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgTermsConditions;
                        ViewState["CompanyName"] = Convert.ToString(dtrow["CompanyShortName"]);
                        ViewState["ShortName"] = Convert.ToString(dtrow["ShortURL"]);

                    }
                }
            }
            dbGetCompanyName.dispose();
        }
    }
}

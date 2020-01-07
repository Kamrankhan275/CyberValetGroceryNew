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
    public partial class My_Account : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HtmlGenericControl liItem = (HtmlGenericControl)Master.FindControl("myaccount");
                liItem.Attributes.Add("class", "selected");

                if (Request.Cookies["userId"]!= null )
                {
                   string userID = Convert.ToString(Request.Cookies["userId"].Value);
                    Response.Redirect("MyAccount.aspx", false);
                }
                else
                {
                    BindSideLink();
                    getCompanyName();
                    if (!IsPostBack)
                    {

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
            pnlAccNoLogin.Visible = true;
            Panel pnlAccLog = (Panel)Page.Master.FindControl("pnlAccLog");
            pnlAccLog.Visible = false;


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
    }
}

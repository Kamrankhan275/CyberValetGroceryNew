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
    public partial class CheckZipCode : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindSideLink();
                getCompanyName();
                Page.Form.DefaultButton = btnGo.UniqueID;

                btnGo.Attributes.Add("onkeypress", "clcontent();");
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgSignUp;

                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsZip=new DataSet();
                dsZip = dbInfo.GetUserZipInfo(txtZipCode.Text);
                  if (dsZip.Tables.Count > 0)
                  {
                      if (dsZip != null && dsZip.Tables.Count > 0 && dsZip.Tables[0].Rows.Count > 0)
                      {
                          Response.Redirect("Registration.aspx?zip=" + txtZipCode.Text, false);

                      }
                      else
                      {

                          Response.Redirect("AddNonDeliveryZone.aspx?zip=" + txtZipCode.Text, false);


                      }
                  }
                  else
                  {

                      Response.Redirect("AddNonDeliveryZone.aspx?zip=" + txtZipCode.Text, false);


                  }


                  dbInfo.dispose();

            }
            catch (Exception ex)
            {
                Response.Redirect(ex.Message);

            }

        }
    }
}

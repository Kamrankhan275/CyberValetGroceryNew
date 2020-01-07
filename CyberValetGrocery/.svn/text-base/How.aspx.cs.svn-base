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
    public partial class How : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HtmlGenericControl liItem = (HtmlGenericControl)Master.FindControl("how");
                liItem.Attributes.Add("class", "selected");
                BindSideLink();
                getCompanyName();
                if (!IsPostBack)
                {

                //    lblDeliveryFee.Text = Convert.ToDecimal(ViewState["DeliveryFee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                  //  lblScheduleFee.Text = Convert.ToDecimal(ViewState["ScheduleFee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                }

            }
            catch( Exception ex)
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgHowItWork;
                       // ViewState["DeliveryFee"] = Convert.ToString(dtrow["OneHrDeliveryFee"]);
                       // ViewState["ScheduleFee"] = Convert.ToString(dtrow["DeliveryFee"]); 
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnShopping_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("shop.aspx", false);
        }
    }
}

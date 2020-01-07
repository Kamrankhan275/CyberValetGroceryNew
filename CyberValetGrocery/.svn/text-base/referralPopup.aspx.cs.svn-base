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
    public partial class referralPopup : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

               
                getCompanyName();
                if (!IsPostBack)
                {
                    lblCmpyNm.Text=Convert.ToString( ViewState["CompanyName"]);
                    lblCmpyNm1.Text = Convert.ToString(ViewState["CompanyName"]);
                    lblCmpyNm2.Text = Convert.ToString(ViewState["CompanyName"]);
                    lblCmpyNm3.Text = Convert.ToString(ViewState["CompanyName"]);
                    //lblDeliverCharge.Text = Convert.ToString(ViewState["DeliverCharge"]);
                    litSitURl.Text = "<a href='mailto:" + Convert.ToString(ViewState["SiteUrl"]) + "' class='Userlink1'>" + Convert.ToString(ViewState["SiteUrl"]) + "</a>'";

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
                       
                        ViewState["CompanyName"] = Convert.ToString(dtrow["CompanyShortName"]);
                        ViewState["SiteUrl"] = Convert.ToString(dtrow["LongURL"]);
                        //ViewState["DeliverCharge"] = Convert.ToString(dtrow["DeliveryFeeCutOff"]);
                        ViewState["ShortURL"]= Convert.ToString(dtrow["ShortURL"]);
                    }
                }
            }
            dbGetCompanyName.dispose();
        }
    }
}

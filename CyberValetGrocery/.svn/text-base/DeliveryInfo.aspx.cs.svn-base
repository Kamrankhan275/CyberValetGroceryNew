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
    public partial class DeliveryInfo : System.Web.UI.Page
    {
        DbProvider dbSelectZip = new DbProvider();
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindSideLink();
                getCompanyName();
                if (!IsPostBack)
                {
                  //  lblCompanyNm1.Text = Convert.ToString(ViewState["CompanyName"]);
                   // lblCompanyNm.Text = Convert.ToString(ViewState["CompanyName"]);
                   // lblDeliveryFee.Text = Convert.ToDecimal(ViewState["DeliveryFee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                  //  lblScheduleFee.Text = Convert.ToDecimal(ViewState["ScheduleFee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    BindGrid();

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgDeliveryInformation;
                        ViewState["CompanyName"] = Convert.ToString(dtrow["CompanyShortName"]);
                        ViewState["DeliveryFee"] = Convert.ToString(dtrow["OneHrDeliveryFee"]);                      
                        ViewState["ScheduleFee"] = Convert.ToString(dtrow["DeliveryFee"]); 
                        ViewState["OrderCutoff"] = Convert.ToString(dtrow["Numberoftimeslot"]);

                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        //Function for Bind Zip data grid.
        public void BindGrid()
        {

            DataSet dsSelectZip = new DataSet();
            dsSelectZip = dbSelectZip.SelectAdminZipCodes();

            if (dsSelectZip.Tables.Count > 0)
            {
                if (dsSelectZip != null && dsSelectZip.Tables.Count > 0 && dsSelectZip.Tables[0].Rows.Count > 0)
                {
                    //check when no posts or photos found
                  
                    foreach (DataRow dtrow in dsSelectZip.Tables[0].Rows)
                    {
                        
                    }


                   // gridZipList.DataSource = dsSelectZip;
                  //  gridZipList.DataBind();


                }
                else
                {
                    
                }
            }
           
            
            dbSelectZip.dispose();
        }
       

        protected void btnShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shop.aspx", false);
        
        }

    }
}

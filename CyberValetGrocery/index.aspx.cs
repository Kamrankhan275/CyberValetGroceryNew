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
    public partial class index : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        DropdownProvider dropZip = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Request.IsSecureConnection)
            {
                String sNewURL = "https://" + Request.ServerVariables["SERVER_NAME"] + Request.ServerVariables["URL"];
                Response.Redirect(sNewURL);
            }

            if (!IsPostBack)
            {

                getCompanyName();
                dropZip.bindZipDropdown(drpZip);
                HtmlGenericControl liItem = (HtmlGenericControl)Master.FindControl("home");
                liItem.Attributes.Add("class", "selected");
            }
        }


        public void getCompanyName()
        {
            DataSet dsGetHomePageTxt = new DataSet();
            DataSet dsGetCompanyName = new DataSet();



            dsGetCompanyName = dbInfo.getShortCompanyName();

            if (dsGetCompanyName.Tables.Count > 0)
            {
                if (dsGetCompanyName != null && dsGetCompanyName.Tables.Count > 0 && dsGetCompanyName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetCompanyName.Tables[0].Rows)
                    {
                        string strNm = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgIndex + " " + Convert.ToString(dtrow["LocationName"]);
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgIndex  + " " + Convert.ToString(dtrow["LocationName"]);
                       // Page.Header.Title = Convert.ToString(strNm);
                       // Page.Title= Convert.ToString(strNm);
                        ViewState["CompanyNm"] = Convert.ToString(dtrow["CompanyShortName"]);

                    }
                }
            }
            dsGetHomePageTxt = dbInfo.GetHomePageTxt();
            if (dsGetHomePageTxt.Tables.Count > 0)
            {
                if (dsGetHomePageTxt != null && dsGetHomePageTxt.Tables.Count > 0 && dsGetHomePageTxt.Tables[0].Rows.Count > 0)
                {


                  lblHomepageText.Text = Convert.ToString(dsGetHomePageTxt.Tables[0].Rows[0]["homepage_text"]);
                  lblSalesTxt.Text = Convert.ToString(dsGetHomePageTxt.Tables[0].Rows[0]["sale_text"]);
                //  imgSaleImage.ImageUrl = "Product/" + Convert.ToString(dsGetHomePageTxt.Tables[0].Rows[0]["sale_limit"]);
                    if (Convert.ToString(dsGetHomePageTxt.Tables[0].Rows[0]["sale_price"]) != "")
                    {
                   //     lblSalesPrice.Text = Convert.ToDecimal(dsGetHomePageTxt.Tables[0].Rows[0]["sale_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        lblSalesPrice.Text = Convert.ToDecimal(dsGetHomePageTxt.Tables[0].Rows[0]["sale_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                    //    lblSalesPrice.Text = "";
                        lblSalesPrice.Text = "";
                    }


                }
                else
                {
                   // string strHomeTxt = "<b>Welcome to " + Convert.ToString(ViewState["CompanyNm"]) + "</b>,premiere online grocery delivery service!";
                  //  lblSalesTxt.Text = "Check what's on sale";
                   // lblSalesPrice.Text = "";
                  

                }
            }
            dbInfo.dispose();
        }

        protected void btnGo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DataSet dsZip = new DataSet();
                dsZip = dbInfo.GetUserZipInfo(drpZip.SelectedValue);
                if (dsZip.Tables.Count > 0)
                {
                    if (dsZip != null && dsZip.Tables.Count > 0 && dsZip.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect("Registration.aspx?zip=" + drpZip.SelectedValue, false);

                    }
                    else
                    {

                        Response.Redirect("AddNonDeliveryZone.aspx?zip=" + drpZip.SelectedValue, false);


                    }
                }
                else
                {

                    Response.Redirect("AddNonDeliveryZone.aspx?zip=" + drpZip.SelectedValue, false);


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

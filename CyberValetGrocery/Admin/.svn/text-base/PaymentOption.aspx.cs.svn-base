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
namespace CyberValetGrocery.Admin
{
    public partial class PaymentOption : System.Web.UI.Page
    {
        DbProvider dbpUpdatePaymnetOption = new DbProvider();
        DropdownProvider drpProvider = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Attributes.Add("onclick", "clcontent();");
                changeLinks();
                getCompanyName();
                try
                {
                    btnUpdate.Attributes.Add("onclick", "clcontent();");
                    if (!IsPostBack)
                    {
                        drpProvider.bindPaymentOptionDropdown(drpPaymentOption);
                        getpaymentOptions();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

        }


        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbpUpdatePaymnetOption.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminCustomers.Tables[0].Rows.Count > 0)
            {
                if (dsAdminCustomers != null && dsAdminCustomers.Tables.Count > 0 && dsAdminCustomers.Tables[0].Rows.Count > 0)
                {
                    MyDataListCustomers.DataSource = dsAdminCustomers;
                    MyDataListCustomers.DataBind();
                }

            }
            //for Site Functions

            DataList MyDataListSiteFunctions = (DataList)Page.Master.FindControl("dtlsitefunctions");
            sideType = 2;
            DataSet dsAdminSiteFunctions = dbpUpdatePaymnetOption.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
            {
                if (dsAdminSiteFunctions != null && dsAdminSiteFunctions.Tables.Count > 0 && dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
                {
                    MyDataListSiteFunctions.DataSource = dsAdminSiteFunctions;
                    MyDataListSiteFunctions.DataBind();
                }

            }

            //for reports

            DataList MyDataListReports = (DataList)Page.Master.FindControl("dtlreports");
            sideType = 3;
            DataSet dsAdminReports = dbpUpdatePaymnetOption.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.paymentOptionTitle;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        //Function for get short company name for page title
        public void getpaymentOptions()
        {

            int paymetOptionId = 1;
            DataSet dsPaymentOpt = new DataSet();

            dsPaymentOpt = dbpUpdatePaymnetOption.GetPaymentOption(paymetOptionId);

            if (dsPaymentOpt.Tables.Count > 0)
            {
                if (dsPaymentOpt != null && dsPaymentOpt.Tables.Count > 0 && dsPaymentOpt.Tables[0].Rows.Count > 0)
                {

                    drpPaymentOption.SelectedValue = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["payment_Id"]);
                    BindPaymentTextBoxValue();
                    if (Convert.ToInt32(dsPaymentOpt.Tables[0].Rows[0]["payment_Id"]) == 1)
                    {
                        pnlAthorize.Visible = true;
                       // pnlPaypel.Visible = false;
                        pnlPaypalIPN.Visible = false;
                    
                    }
                    else if (Convert.ToInt32(dsPaymentOpt.Tables[0].Rows[0]["payment_Id"]) == 2)
                    {
                        pnlAthorize.Visible = false;
                      //  pnlPaypel.Visible = true; 
                        pnlPaypalIPN.Visible = true;
                    }
                   
                }
            }
            dbpUpdatePaymnetOption.dispose();
        }

        public void BindPaymentTextBoxValue()
        {
            lblMsg.Text = "";
            int paymetOptionId = 1;
            DataSet dsPaymentOpt = new DataSet();
            dsPaymentOpt = dbpUpdatePaymnetOption.GetPaymentOption(paymetOptionId);

            if (dsPaymentOpt.Tables.Count > 0)
            {
                if (dsPaymentOpt != null && dsPaymentOpt.Tables.Count > 0 && dsPaymentOpt.Tables[0].Rows.Count > 0)
                {                       
                        txtAPILogin.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["API_Login"]);
                        txtTranKey.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["API_TransKey"]);
                        txtPostUrl.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["API_PostUrl"]);                 
                        //txtEndPayUrl.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["API_PayPalEndPoint"]);
                        //txtPayUserNm.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["API_PayPalUserName"]);
                        //txtPayPwd.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["API_PayPalPassword"]);
                        //txtPaySignature.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["API_PayPalSignature"]);
                        //txtECURL.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["PAYPAL_EC_URL"]);
                        //txtECURLLOGIN.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["ECURLLOGIN"]);
                        txtPaypalUrl.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["PaypalUrl"]);
                        txtBusEmail.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["PaypalEmail"]);
                        txtSubmitUrl.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["PaypalSubUrl"]);
                        txtToken.Text = Convert.ToString(dsPaymentOpt.Tables[0].Rows[0]["PDTToken"]);

                    
                }
            }




        }

        //Code for update payment options.
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           
                int retPaymentOption = 0;
                int payment_option_Id = 1;
                if (Page.IsValid)
                {
                   // retPaymentOption = dbpUpdatePaymnetOption.updateOaymentOption(payment_option_Id, Convert.ToInt32(drpPaymentOption.SelectedValue), txtAPILogin.Text, txtTranKey.Text, txtPostUrl.Text, txtEndPayUrl.Text, txtPayUserNm.Text, txtPayPwd.Text, txtPaySignature.Text, txtECURL.Text, txtECURLLOGIN.Text);
                    retPaymentOption = dbpUpdatePaymnetOption.updateOaymentOptionNew(payment_option_Id, Convert.ToInt32(drpPaymentOption.SelectedValue), txtAPILogin.Text, txtTranKey.Text, txtPostUrl.Text,txtPaypalUrl.Text,txtBusEmail.Text,txtSubmitUrl.Text,txtToken.Text);
                    
                    if (retPaymentOption == 1)
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.paymentOptionSuccess;
                        lblMsg.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.paymentOptionFailed;
                        lblMsg.ForeColor = System.Drawing.Color.Red;

                    }
                }
                
           
        }

        protected void drpPaymentOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int paymetOption = 0;
                if (drpPaymentOption.SelectedValue == "Select")
                {
                    lblMsg.Text = "";
                    pnlAthorize.Visible=false;
                   // pnlPaypel.Visible=false;
                    pnlPaypalIPN.Visible = false;
                    
                    

                }
                else
                {
                    paymetOption = Convert.ToInt32(drpPaymentOption.SelectedValue);
                    BindPaymentTextBoxValue();
                    if(paymetOption==1)
                    {
                        lblMsg.Text = "";
                        pnlAthorize.Visible = true;
                        //pnlPaypel.Visible = false;
                        pnlPaypalIPN.Visible = false;
                    

                    }
                    else if (paymetOption == 2)
                    {
                        lblMsg.Text = "";
                        pnlAthorize.Visible = false;
                        //pnlPaypel.Visible = true;
                        pnlPaypalIPN.Visible = true;
                    
                    }

                }




            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
           

        }
    }
}

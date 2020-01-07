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
    public partial class CustomerTransactionsDetails1 : System.Web.UI.Page
    {

        DbProvider dbListInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int transactionId = Convert.ToInt32(Request.QueryString["transactionId"]);
                DataSet dsTransItemList = new DataSet();
                dsTransItemList = dbListInfo.GetCustTransactionDetailsIfo(transactionId);
                if (dsTransItemList.Tables.Count > 0)
                {
                    if (dsTransItemList != null && dsTransItemList.Tables.Count > 0 && dsTransItemList.Tables[0].Rows.Count > 0)
                    {
                      

                      lblTransactionsAddress.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_address"]);
                        if(Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_address2"])=="")
                        {
                      lblTransactionsAddress2.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_address3"]);
                        }
                        else
                        {
                      lblTransactionsAddress2.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_address2"]);

                        }
                      lblTransactionsCity.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_city"]);
                      lblTransactionsState.Text =Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_state"]);
                      lblTransactionsZip.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_zip"]);
                      if (lblTransactionsState.Text == "" && lblTransactionsZip.Text == "")
                      {
                          lblComma.Visible = false;
                          lblComma1.Visible = false;

                      }
                      lblTransactionsPhone.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_phone"]);
                      lblComments.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_comment"]);
                      lblCustomers.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["users"]);
                      //lblTransactionsAmount.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsTransItemList.Tables[0].Rows[0]["transactions_amount"]), 2));

                      lblTransactionsAmount.Text = Convert.ToDecimal(dsTransItemList.Tables[0].Rows[0]["transactions_amount"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                      
                      lblTransactionsDate.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_date"]);
                      lblLName.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_lname"]);
                      lblFName.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_fname"]);
                      lblOrder.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["orders_id"]);

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

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
    public partial class TransactionsDetails : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int parentId = Convert.ToInt32(Request.QueryString["parentId"]);
                DataSet dsTransItemList = new DataSet();
                dsTransItemList = dbListInfo.GetTransactionDetails(parentId);
                if (dsTransItemList.Tables.Count > 0)
                {
                    if (dsTransItemList != null && dsTransItemList.Tables.Count > 0 && dsTransItemList.Tables[0].Rows.Count > 0)
                    {
                       
                        lblFName.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["users_fname"]);
                        lblLName.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["users_lname"]);
                        //lblTransactionsAmount.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsTransItemList.Tables[0].Rows[0]["transactions_amount"]), 2));
                        lblTransactionsAmount.Text = Convert.ToDecimal(dsTransItemList.Tables[0].Rows[0]["transactions_amount"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        lblTransactionsPhone.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_phone"]);
                        lblTransactionsCity.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_city"]);
                        lblTransactionsState.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_state"]);
                        lblTransactionsZip.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_zip"]);
                        lblTransactionsAddress.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_address"]);
                        lblTransactionsAddress2.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_address2"]);
                        lblTransactionsDate.Text = Convert.ToString(dsTransItemList.Tables[0].Rows[0]["transactions_date"]);
                    }
                    else
                    {
                        pnlTransaction.Visible = false;
                        lblMsg.Text = "";
                        lblMsg.Visible = true;
                        lblMsg.Text = AppConstants.noTransaction;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }

                }
                else
                {
                    pnlTransaction.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noTransaction;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }

                

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }


        }
    }
}

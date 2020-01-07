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
    public partial class MyAccount : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HtmlGenericControl liItem = (HtmlGenericControl)Master.FindControl("myaccount");
                liItem.Attributes.Add("class", "selected");
                if (Request.Cookies["userId"] == null)
                {
                    Response.Redirect("My_Account.aspx", false);
                }
                else
                {
                    BindSideLink();
                    getCompanyName();
                    if (!IsPostBack)
                    {
                        BindUserInformation();
                        BindOrderGrid();
                        BindAccounGrid();
                    //  BindLoyality();
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
            pnlAccNoLogin.Visible = false;
            Panel pnlAccLog = (Panel)Page.Master.FindControl("pnlAccLog");
            pnlAccLog.Visible = true;
        }

        public void BindUserInformation()
        {
            int userId = 0;
            string strName = string.Empty;
            userId = Convert.ToInt32(Request.Cookies["userId"].Value);
            DataSet dsUserDetailsInfo = new DataSet();
            dsUserDetailsInfo = dbInfo.GetUserDetailsInfo(userId);
            if (dsUserDetailsInfo.Tables.Count > 0)
            {
                if (dsUserDetailsInfo != null && dsUserDetailsInfo.Tables.Count > 0 && dsUserDetailsInfo.Tables[0].Rows.Count > 0)
                {                    
                    strName = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_fname"]) + " " + Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_lname"]);
                    lblUserName.Text=strName;
                    lblName.Text = strName;
                    lblPhone.Text =Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_phone"]);
                    lblEmail.Text =Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_email"]);
                    lblAddress.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_address1"]);
                    lblCity.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_city"]);
                    lblState.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_state"]);
                    lblZip.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_zip"]);
                    if (Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_baddress1"]) != "")
                    {
                        pnlBillAdd.Visible = true;
                        pnlNoBillAdd.Visible = false;
                        lblNoBillInfo.Text = "";
                        lblBillAddress.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_baddress1"]);
                        lblBillCity.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_bcity"]);
                        lblBillState.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_bstate"]);
                        lblBillZip.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_bzip"]);
                    }
                    else
                    {
                        pnlBillAdd.Visible = false;
                        pnlNoBillAdd.Visible = true;
                        lblNoBillInfo.Text = "";
                        lblNoBillInfo.Text =AppConstants.strNoBillAddress;

                    }
                    if (dsUserDetailsInfo.Tables[0].Rows[0]["users_accountvalue"] != "")
                    {

                        //lblAccBAl.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsUserDetailsInfo.Tables[0].Rows[0]["users_accountvalue"]), 2));
                        lblAccBAl.Text = Convert.ToDecimal(dsUserDetailsInfo.Tables[0].Rows[0]["users_accountvalue"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
            }
            dbInfo.dispose();


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

        // Modified by: Shashank            Date: 02-16-2011
        // Before this Loyality fund in this website is not available
        //public void BindLoyality()
        //{
        //    int intOrdUnder50 = 0;
        //    int intOrdAbv50 = 0;
        //    int userId = 0;
        //    string strName = string.Empty;
        //    userId = Convert.ToInt32(Request.Cookies["userId"].Value);
        //    DataSet dsUserDetailsInfo = new DataSet();
        //    dsUserDetailsInfo = dbInfo.GetUserDetailsInfo(userId);
        //    if (dsUserDetailsInfo.Tables.Count > 0)
        //    {
        //        if (dsUserDetailsInfo != null && dsUserDetailsInfo.Tables.Count > 0 && dsUserDetailsInfo.Tables[0].Rows.Count > 0)
        //        {
        //            if (Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_under100"]) != "")
        //            {
        //                intOrdUnder50 = 5 - Convert.ToInt32(dsUserDetailsInfo.Tables[0].Rows[0]["users_under100"]);
        //                if (intOrdUnder50 == 0)
        //                {
        //                    imgUnderFifty.ImageUrl = AppConstants.strLoyalityImg + Convert.ToString(intOrdUnder50) + AppConstants.strLoyalityImg1;

        //                    lblUnderFifty.Text = AppConstants.strLoyalityMsg + Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_under100"]) + AppConstants.strLoyalityMsg1 + "5 " + AppConstants.strLoyalityMsg2;
        //                }
        //                else
        //                {
        //                    imgUnderFifty.ImageUrl = AppConstants.strLoyalityImg + Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_under100"]) + AppConstants.strLoyalityImg1;
        //                    lblUnderFifty.Text = AppConstants.strLoyalityMsg + Convert.ToString(intOrdUnder50) + AppConstants.strLoyalityMsg1 + "5 " + AppConstants.strLoyalityMsg2;
        //                }
        //            }
        //            if (Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_over100"]) != "")
        //            {
        //                intOrdAbv50 = 5 - Convert.ToInt32(dsUserDetailsInfo.Tables[0].Rows[0]["users_over100"]);
        //                if (intOrdAbv50 == 0)
        //                {
        //                    imgOverFifty.ImageUrl = AppConstants.strLoyalityImg + Convert.ToString(intOrdAbv50) + AppConstants.strLoyalityImg1;
        //                    lblOverFifty.Text = AppConstants.strLoyalityMsg + Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_over100"]) + AppConstants.strLoyalityMsg1 + "10 " + AppConstants.strLoyalityMsg2;
        //                }
        //                else
        //                {
        //                    imgOverFifty.ImageUrl = AppConstants.strLoyalityImg + Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_over100"]) + AppConstants.strLoyalityImg1;
        //                    lblOverFifty.Text = AppConstants.strLoyalityMsg + Convert.ToString(intOrdAbv50) + AppConstants.strLoyalityMsg1 + "10 " + AppConstants.strLoyalityMsg2;
        //                }
        //            }
        //        }
        //    }
        //    dbInfo.dispose();
        //}

        //public void BindLoyality()
        //{
        //    int intOrdUnder50 = 0;
        //    int intOrdAbv50 = 0;
        //    int userId = 0;
        //    string strName = string.Empty;
        //    userId = Convert.ToInt32(Request.Cookies["userId"].Value);
        //    DataSet dsUserDetailsInfo = new DataSet();
        //    dsUserDetailsInfo = dbInfo.GetUserDetailsInfo(userId);
        //    if (dsUserDetailsInfo.Tables.Count > 0)
        //    {
        //        if (dsUserDetailsInfo != null && dsUserDetailsInfo.Tables.Count > 0 && dsUserDetailsInfo.Tables[0].Rows.Count > 0)
        //        {

        //            if (Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_under100"]) != "")
        //            {
        //                intOrdUnder50 = 5 - Convert.ToInt32(dsUserDetailsInfo.Tables[0].Rows[0]["users_under100"]);
        //                if (intOrdUnder50 == 0)
        //                {
        //                    imgUnderFifty.ImageUrl = AppConstants.strLoyalityImg + Convert.ToString(intOrdUnder50) + AppConstants.strLoyalityImg1;

        //                    lblUnderFifty.Text = AppConstants.strLoyalityMsg + Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_under100"]) + AppConstants.strLoyalityMsg1 + "5 " + AppConstants.strLoyalityMsg2;

        //                }
        //                else
        //                {



        //                    imgUnderFifty.ImageUrl = AppConstants.strLoyalityImg + Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_under100"]) + AppConstants.strLoyalityImg1;

        //                    lblUnderFifty.Text = AppConstants.strLoyalityMsg + Convert.ToString(intOrdUnder50) + AppConstants.strLoyalityMsg1 + "5 " + AppConstants.strLoyalityMsg2;
        //                }
        //            }



        //            if (Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_over100"]) != "")
        //            {
        //                intOrdAbv50 = 5 - Convert.ToInt32(dsUserDetailsInfo.Tables[0].Rows[0]["users_over100"]);

        //                if (intOrdAbv50 == 0)
        //                {
        //                    imgOverFifty.ImageUrl = AppConstants.strLoyalityImg + Convert.ToString(intOrdAbv50) + AppConstants.strLoyalityImg1;


        //                    lblOverFifty.Text = AppConstants.strLoyalityMsg + Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_over100"]) + AppConstants.strLoyalityMsg1 + "10 " + AppConstants.strLoyalityMsg2;

        //                }
        //                else
        //                {

        //                    imgOverFifty.ImageUrl = AppConstants.strLoyalityImg + Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_over100"]) + AppConstants.strLoyalityImg1;


        //                    lblOverFifty.Text = AppConstants.strLoyalityMsg + Convert.ToString(intOrdAbv50) + AppConstants.strLoyalityMsg1 + "10 " + AppConstants.strLoyalityMsg2;
        //                }


        //            }

        //        }
        //    }

        //    dbInfo.dispose();


        //}

        public void BindOrderGrid()
        {

            int userId = 0;          
            userId = Convert.ToInt32(Request.Cookies["userId"].Value);
            DataSet dsUserOrderInfo = new DataSet();
            dsUserOrderInfo = dbInfo.GetUserOrderDetailsInfo(userId);
            if (dsUserOrderInfo.Tables.Count > 0)
            {
                if (dsUserOrderInfo != null && dsUserOrderInfo.Tables.Count > 0 && dsUserOrderInfo.Tables[0].Rows.Count > 0)
                {
                    lblNoOrder.Visible = false;
                    lblNoOrder.Text = "";
                    lblView.Visible = true;
                    foreach (DataRow dtrow in dsUserOrderInfo.Tables[0].Rows)
                    {

                        if (Convert.ToString(dtrow["orders_totalfinal"])!="")
                        {
                            dtrow["orders_totalfinal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));

                        }
                    }

                    gridOrderList.DataSource = dsUserOrderInfo;
                    gridOrderList.DataBind();

                }
                else
                {
                    lblNoOrder.Visible = true;
                    lblNoOrder.Text = "";
                    lblNoOrder.Text = Convert.ToString(AppConstants.strUserNoOrder);
                    gridOrderList.Visible = false;
                    lblView.Visible = false;

                }

            }
            else
            {
                lblNoOrder.Visible = true;
                lblNoOrder.Text = "";
                lblNoOrder.Text = Convert.ToString(AppConstants.strUserNoOrder);
                gridOrderList.Visible = false;
                lblView.Visible = false;

            }

            dbInfo.dispose();
        }


        public void BindAccounGrid()
        {
            string strOrderNm = string.Empty;
            string strOrder = string.Empty;
            int userId = 0;            
            userId = Convert.ToInt32(Request.Cookies["userId"].Value);
            DataSet dsUserTransacInfo = new DataSet();
            dsUserTransacInfo = dbInfo.GetUserTransactionInfo(userId);
            if (dsUserTransacInfo.Tables.Count > 0)
            {
                if (dsUserTransacInfo != null && dsUserTransacInfo.Tables.Count > 0 && dsUserTransacInfo.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsUserTransacInfo.Tables[0].Rows)
                    {

                        if (Convert.ToInt32(dtrow["transactions_amount"]) >= 0)
                        {
                            
                            dtrow["transactions_comment"] = "Deposit";
                            dtrow["transactions_amount"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["transactions_amount"]), 2));


                        }
                        else if (Convert.ToInt32(dtrow["transactions_amount"]) < 0)
                        {

                            dtrow["transactions_comment"] = "Draw";
                            string strAmt = SplitDate(Convert.ToString(dtrow["transactions_amount"]));
                            dtrow["transactions_amount"] ="-"+Convert.ToString(Math.Round(Convert.ToDouble(strAmt), 2));

                        }


                        if (Convert.ToString(dtrow["orders_id"]) == null || Convert.ToString(dtrow["orders_id"]) == "")
                        {
                            dtrow["transactions_fname"] = Convert.ToString(strOrder);
                        }
                        else
                        {
                            DataSet dsUserOrderNumberInfo = new DataSet();
                            dsUserOrderNumberInfo = dbInfo.GetUserOrderDetail(userId,Convert.ToInt32(dtrow["orders_id"]));
                            if (dsUserOrderNumberInfo.Tables.Count > 0)
                            {
                                if (dsUserOrderNumberInfo != null && dsUserOrderNumberInfo.Tables.Count > 0 && dsUserOrderNumberInfo.Tables[0].Rows.Count > 0)
                                {
                                    dtrow["transactions_fname"] = Convert.ToString(dsUserOrderNumberInfo.Tables[0].Rows[0]["orders_number"]);

                                }
                            }


                        }


                       

                    }
                    gridBalanceList.DataSource = dsUserTransacInfo;
                    gridBalanceList.DataBind();
                    for (int i = 0; i < gridBalanceList.Rows.Count; i++)
                    {

                        GridViewRow item = gridBalanceList.Rows[i];
                        Label lblTranType;
                        Label lblOpnBracket;
                        Label lblClsBracket;
                        lblTranType = (Label)item.FindControl("lblTranType");
                        lblOpnBracket = (Label)item.FindControl("lblOpnBracket");
                        lblClsBracket = (Label)item.FindControl("lblClsBracket");
                        if (lblTranType.Text == "Deposit")
                        {
                            lblOpnBracket.Visible = false;
                            lblClsBracket.Visible = false;
                            lblTranType.ForeColor = System.Drawing.Color.Green;

                        }
                        else if (lblTranType.Text == "Draw")
                        {
                            lblOpnBracket.Visible = true;
                            lblClsBracket.Visible = true;
                            lblTranType.ForeColor = System.Drawing.Color.Red;


                        }

                    }

                }
                else
                {
                    gridBalanceList.Visible = false;

                }
            }
            dbInfo.dispose();

        }

        public string SplitDate(string StrAmt)
        {
            string[] Info = new string[2];
            char[] splitter = { '-' };
            Info = StrAmt.Split(splitter);
            string strReturn = Info[1];           
            return strReturn;
        }

        protected void gridBalanceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridBalanceList.PageIndex = e.NewPageIndex;
            BindAccounGrid();
        }

    }
}

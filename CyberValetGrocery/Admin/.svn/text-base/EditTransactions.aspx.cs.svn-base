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
    public partial class EditTransactions : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        DropdownProvider dropUser = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                btnUpdate.Attributes.Add("onclick", "clcontent();");
                changeLinks();
                getCompanyName();
                if (!IsPostBack)
                {
                    dropUser.bindUsers1(drpCustomer);                   
                    DateTime todayDate = System.DateTime.Now;
                    lblDate.Text = Convert.ToString(todayDate);
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
            DataSet dsAdminCustomers = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

            }


            foreach (DataListItem row1 in MyDataListCustomers.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbCustomers");
                string name = MyLinkButton.Text;
                if (name == "Transactions")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbListInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.TransactionsUpdate;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (FCKeditor1.Value != "")
                {
                    int intUserId = 0;
                    int intOrderId = 0;
                    int intInsertTranc = 0;
                    double account;
                    int intUpdateTranc = 0;
                    DateTime todayDate = System.DateTime.Now;
                    intUserId = Convert.ToInt32(drpCustomer.SelectedValue);
                    if (txtOrderId.Text == "")
                    {
                        intOrderId = 0;
                    }
                    else
                    {
                        intOrderId = Convert.ToInt32(txtOrderId.Text);

                    }
                    intInsertTranc = dbListInfo.InsertTransactionInformation(todayDate, Convert.ToDouble(txtTransAmt.Text), intOrderId, Convert.ToString(FCKeditor1.Value), intUserId);
                    if (intInsertTranc == 1)
                    {
                        DataSet dsUserList = new DataSet();
                        dsUserList = dbListInfo.GetAccountInformation(intUserId);
                        if (dsUserList.Tables.Count > 0)
                        {
                            if (dsUserList != null && dsUserList.Tables.Count > 0 && dsUserList.Tables[0].Rows.Count > 0)
                            {
                                account = Convert.ToDouble(dsUserList.Tables[0].Rows[0]["users_accountvalue"]) + Convert.ToDouble(txtTransAmt.Text);
                                intUpdateTranc = dbListInfo.UpdateTransactionInfo(account, intUserId);
                                if (intUpdateTranc == 1)
                                {
                                    lblMsg.Text = "";
                                    txtOrderId.Text = "";
                                    txtTransAmt.Text = "";
                                    FCKeditor1.Value = "";
                                    drpCustomer.SelectedValue = "Select";
                                    lblMsg.Text = AppConstants.tranAccountUpdateSuccess;
                                    lblMsg.ForeColor = System.Drawing.Color.Black;

                                }
                                else
                                {
                                    lblMsg.Text = "";
                                    lblMsg.Text = AppConstants.tranAccountUpdateFailed;
                                    lblMsg.ForeColor = System.Drawing.Color.Black;

                                }
                            }
                        }


                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.tranAccountUpdateFailed;
                        lblMsg.ForeColor = System.Drawing.Color.Black;

                    }


                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.strcommentRequired;
                    lblMsg.ForeColor = System.Drawing.Color.Red;

                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }


        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {

            int locId = 0;
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            Response.Redirect("admin_transactions.aspx?check=2&locId=" + locId, false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            int locId = 0;
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            Response.Redirect("admin_transactions.aspx?check=2&locId=" + locId, false);
        }
    }
}

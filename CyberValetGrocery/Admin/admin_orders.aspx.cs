using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CyberValetGrocery.Class;
using System;

namespace CyberValetGrocery.Admin
{
    public partial class admin_orders : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        DropdownProvider dropLocation = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                changeLinks();
                getCompanyName();
                if (!IsPostBack)
                {
                    dropLocation.bindLocationDropdown(drpLocation);//Bind location  into dropdown   
                    int check = 0;
                    check = Convert.ToInt32(Request.QueryString["check"]);
                    if (check == 1)
                    {                                         
                       
                        int OrderType = 0;
                        txtFromDate.Text = Convert.ToString(Request.QueryString["stDate"]);
                        txtToDate.Text = Convert.ToString(Request.QueryString["enDate"]);
                        if (Convert.ToString(Request.QueryString["ordNum"]) != "0")
                        {

                            txtorderNum.Text = Convert.ToString(Request.QueryString["ordNum"]);
                        }
                        drpLocation.SelectedValue = Convert.ToString(Request.QueryString["intLocId"]);
                        drpShow.SelectedValue = Convert.ToString(Request.QueryString["intShow"]);
                        OrderType = Convert.ToInt32(Request.QueryString["OrderType"]);
                        for (int rdDateCnt = 0; rdDateCnt < rdDate.Items.Count; rdDateCnt++)
                        {
                            if (Convert.ToInt32(rdDate.Items[rdDateCnt].Value) == OrderType)
                            {
                                rdDate.Items[rdDateCnt].Selected = true;
                            }
                        }
                    }



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
                if (name == "Orders")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.Orders;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        

        

        protected void btnBegin_Click(object sender, EventArgs e)
        {
            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            string strOrderNum =string.Empty;
            int OrderType = 0;
            int intShow = Convert.ToInt32(drpShow.SelectedValue);
            int intLocId = Convert.ToInt32(drpLocation.SelectedValue);
            strStartDate = txtFromDate.Text;
            strToDate = txtToDate.Text;
            strOrderNum = txtorderNum.Text;
            string strMsg = string.Empty;
            int cnt = 0;
            for (int rdDateCnt = 0; rdDateCnt < rdDate.Items.Count; rdDateCnt++)
            {
                if (rdDate.Items[rdDateCnt].Selected == true)
                {
                    cnt = 1;
                    OrderType = Convert.ToInt32(rdDate.Items[rdDateCnt].Value);

                }
            }

            if (strStartDate != "" ||strToDate != "")
            {
                if (cnt == 0)
                {
                  strMsg = AppConstants.orderType;                   
                }    
                if (strStartDate == "")
                {
                    strMsg = strMsg + "<br>" + AppConstants.selectStartDate;
                }
                if (strToDate == "")
                {
                    strMsg =strMsg+"<br>"+AppConstants.selectEndDate;
                
                }
                if(strMsg=="")
                {
                    int intDate = CheckDate(OrderType);
                        if (intDate == 0)
                        {
                            strMsg = "";

                            Response.Redirect("ViewOrdersDetail.aspx?stDate=" + strStartDate + "&enDate=" + strToDate + "&ordNum=" + strOrderNum + "&intShow=" + intShow + "&intLocId=" + intLocId + "&OrderType=" + OrderType, false);
                        }                        
                    
                }
            }
            else if (strOrderNum !="")
            {
               strMsg = "";
               Response.Redirect("ViewOrdersDetail.aspx?stDate=" + strStartDate + "&enDate=" + strToDate + "&ordNum=" + strOrderNum + "&intShow=" + intShow + "&intLocId=" + intLocId + "&OrderType=" + OrderType, false);

            }
            else
            {
                strMsg = "";
                Response.Redirect("ViewOrdersDetail.aspx?stDate=" + strStartDate + "&enDate=" + strToDate + "&ordNum=" + strOrderNum + "&intShow=" + intShow + "&intLocId=" + intLocId + "&OrderType=" + OrderType, false);

            }
            if (strMsg != "")
            {
                lblMsg.Text = "";
                lblMsg.Text = strMsg;
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }


        }


        public int CheckDate(int OrderType)
        {
            int returnDate = 0;
            DataValidator dataValidator = new DataValidator();
            if (OrderType == 1)
            {
                returnDate = DataValidator.IsValidTodaysDate(txtToDate.Text);
            }

            if (returnDate == 1)
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.invalidOrderReportEndDate;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                returnDate = 1;

            }
            else
            {
                returnDate = DataValidator.IsValidDate(txtFromDate.Text, txtToDate.Text);
                if (returnDate == 2)
                {

                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.invalidOrderReportStartDate;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    returnDate = 2;

                }
                else
                {
                    lblMsg.Text = "";
                    returnDate = 0;


                }

            }

            return returnDate;

        }  
    }
}

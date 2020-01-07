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
using System.Globalization;

namespace CyberValetGrocery.Admin
{
    public partial class EditDeliveryDate : System.Web.UI.Page
    {
        DbProvider dbAddInfo = new DbProvider();
        DropdownProvider dropZip = new DropdownProvider();
        string strDeliverydateID = string.Empty;
        string strDate = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAdd.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            Label1.Text = "";
            if (!IsPostBack)
            {
                strDeliverydateID = Convert.ToString(Request.QueryString["DeliveryDateID"]);
                 strDate = Convert.ToString(Request.QueryString["date"]);
                txtDeliveryDate.Text = Convert.ToDateTime(strDate).ToShortDateString();
                dropZip.bindZipCheckBox(lisZip);

                DataSet dsDeliverytime = dbAddInfo.SelectDeliveryDatezipAllDetails(strDeliverydateID);
                if (dsDeliverytime.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsDeliverytime.Tables[0].Rows)
                    {
                        string zipid = Convert.ToString(dtrow["zipcode_id"]);
                        for (int intZip = 0; intZip < lisZip.Items.Count; intZip++)
                        {
                            if (zipid == lisZip.Items[intZip].Value)
                            {
                                lisZip.Items[intZip].Selected = true;
                            }
                        }
                       // lisZip.Items[Convert.ToInt32(zipid)].Selected = true;
                       // lisZip.Items.SelectedValue = zipid;
                    }
                }
                dropZip.bindLocationDropdown(drpLocation);
              
                lblMsg.Text = "";
                Label1.Text = "";
                BindCheck();
            }
        }


     

        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

            }


            foreach (DataListItem row1 in MyDataListSiteFunctions.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbSitefunctions");
                string name = MyLinkButton.Text;
                if (name == "Delivery Dates")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbAddInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.AddDelieveryDate;
                        ViewState["Numberoftimeslot"] = Convert.ToString(dtrow["Numberoftimeslot"]);
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_delivery.aspx", false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_delivery.aspx", false);

        }
        public void BindCheck()
        {
           int DeliverydateID = Convert.ToInt32(Request.QueryString["DeliveryDateID"]);

           DataSet dsDeliverytime = dbAddInfo.GetdsDeliverytimeInfoDetails(DeliverydateID);
            if (dsDeliverytime.Tables[0].Rows.Count > 0)
            {
                if (dsDeliverytime != null && dsDeliverytime.Tables.Count > 0 && dsDeliverytime.Tables[0].Rows.Count > 0)
                {
                    dtlDelieveryTime.DataSource = dsDeliverytime;
                    dtlDelieveryTime.DataBind();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string FailedZipCode = string.Empty;
                string strcheckValidation = string.Empty;
                int intInsertDate = 0;
                int intInsertDateZipMap = 0;
                int intZipcode = 1;
                int intInsertDateMap = 0;
                int checkDateAlreadyExit = 0;
                int Numberoftimeslot = 0;
                int intCnt = 0;
                Label1.Text = "";

                if (!string.IsNullOrEmpty(txtDeliveryDate.Text))
                {
                    strcheckValidation = CheckValidation();
                    if (strcheckValidation == string.Empty)
                    { 

                            string dateID = Convert.ToString(Request.QueryString["DeliveryDateID"]);
                            
                            for (int intZip = 0; intZip < lisZip.Items.Count; intZip++)
                            {
                                if (lisZip.Items[intZip].Selected == true)
                                {
                                    int intZipVal = Convert.ToInt32(lisZip.Items[intZip].Value);
                                    checkDateAlreadyExit = dbAddInfo.DeliveryDateAlreadyExist(txtDeliveryDate.Text, intZipVal);
                                    if (checkDateAlreadyExit != 0)
                                    {
                                        lblMsg.Text = "";
                                        lblMsg.Text = AppConstants.deliveryDatezipAlreadyExist;
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                    }
                                    else
                                    {
                                        intZipVal = Convert.ToInt32(lisZip.Items[intZip].Value);
                                        intInsertDateZipMap = dbAddInfo.InsertDeliveryDateZipInfo(Convert.ToInt32(dateID), intZipVal);
                                    }
                                }
                                else
                                {
                                    // Check if in orders
                                    int intZipVal1 = Convert.ToInt32(lisZip.Items[intZip].Value);
                                    if (dbAddInfo.CheckDeliveryZipInOrder(txtDeliveryDate.Text, lisZip.Items[intZip].Text)== 0) 
                                        intInsertDateZipMap = dbAddInfo.DeleteDeliveryDateZipInfo1(Convert.ToInt32(dateID), intZipVal1); 
                                    else
                                    {
                                        FailedZipCode += lisZip.Items[intZip].Text + ",";
                                        
                                    }
                                }
                            }

                                if (ViewState["Numberoftimeslot"] != "")
                                {
                                    Numberoftimeslot = Convert.ToInt32(ViewState["Numberoftimeslot"]);
                                }
                                for (int i = 0; i < dtlDelieveryTime.Items.Count; i++)
                                {
                                    string strTime = string.Empty;
                                    int intId = 0;
                                    CheckBox chkDeliveryTime;
                                    Label lblDeliveryTime;
                                    TextBox txtDeliveryTime;
                                    DataListItem item = dtlDelieveryTime.Items[i];
                                    chkDeliveryTime = (CheckBox)item.FindControl("chkDelieveryTime");
                                    lblDeliveryTime = (Label)item.FindControl("lblTimeID");
                                    txtDeliveryTime = (TextBox)item.FindControl("txtTime");
                                    intId = Convert.ToInt32(lblDeliveryTime.Text);
                                    strTime = Convert.ToString(txtDeliveryTime.Text);
                                    //if (chkDeliveryTime.Checked == true && strTime != "")
                                    //{
                                        if (intCnt < Numberoftimeslot)
                                        {
                                             intInsertDateMap = dbAddInfo.UpdateDeliveryDateMappingInfo(Convert.ToInt32(dateID), intId, Convert.ToInt32(txtDeliveryTime.Text), Convert.ToInt32(drpLocation.SelectedValue));

                                            intCnt++;
                                        }
                                    //}
                                    //else if (chkDeliveryTime.Checked == false && strTime != "")
                                    //{
                                    //    if (intCnt < Numberoftimeslot)
                                    //    {
                                    //         intInsertDateMap = dbAddInfo.UpdateDeliveryDateMappingInfo(Convert.ToInt32(dateID), intId, Convert.ToInt32(txtDeliveryTime.Text), Convert.ToInt32(drpLocation.SelectedValue));
                                    //        intCnt++;
                                    //    }
                                    //}
                                }
                                if (intInsertDateMap != 0)
                                {
                                    clear();
                                    if (!string.IsNullOrEmpty(FailedZipCode))
                                    {
                                        lblMsg.Text = "";
                                        lblMsg.Text = "Failed to update " + FailedZipCode + " .These are used in orders.Remaining Updated Successfully!";
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                    }
                                    else
                                    {

                                        lblMsg.Text = "";
                                        lblMsg.Text = lblMsg.Text + "<br/>" + AppConstants.deliveryDateUdpateSuccess;
                                        lblMsg.ForeColor = System.Drawing.Color.Black;
                                    }
                                   
                                }
                                else
                                {
                                    lblMsg.Text = "";
                                    lblMsg.Text = AppConstants.deliveryDateAddFailed;
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }
                          
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = strcheckValidation;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = "Please select deliverydate";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                //textbox
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                lblMsg.Text = ex.Message;

            }

        }




        public string SplitDate(string StrDate)
        {
            string[] dateInfo = new string[2];
            char[] splitter = { '/' };
            dateInfo = StrDate.Split(splitter);
            string day = dateInfo[1];
            string month = dateInfo[0];
            string year = dateInfo[2];
            string strReturn = day + '/' + month + '/' + year;
            return strReturn;
        }



        public string CheckValidation()
        {
            int intChkCnt = 0;
            int intId = 1;
            string strTime = string.Empty;
            string strMsg = string.Empty;
            int returnDate = 0;
            DataValidator dataValidator = new DataValidator();
            returnDate = DataValidator.IsValidDateGreaterToday1(txtDeliveryDate.Text);
           // returnDate = DataValidator.IsValidDateGreaterToday(ddlDate.SelectedItem.ToString());
            for (int intZip = 0; intZip < lisZip.Items.Count; intZip++)
            {
                if (lisZip.Items[intZip].Selected == true)
                {
                    intChkCnt = 1;
                }
            }


            for (int i = 0; i < dtlDelieveryTime.Items.Count; i++)
            {
                CheckBox chkDeliveryTime;
                Label lblDeliveryTime;
                TextBox txtDeliveryTime;
                DataListItem item = dtlDelieveryTime.Items[i];
                chkDeliveryTime = (CheckBox)item.FindControl("chkDelieveryTime");
                lblDeliveryTime = (Label)item.FindControl("lblTimeID");
                txtDeliveryTime = (TextBox)item.FindControl("txtTime");
                strTime = Convert.ToString(txtDeliveryTime.Text);
                if (chkDeliveryTime.Checked == true && strTime != "")
                {
                    intId = 1;

                }
                else if (chkDeliveryTime.Checked == false && strTime != "")
                {
                    intId = 2;

                }
                else if (chkDeliveryTime.Checked == true && strTime == "")
                {
                    intId = 0;

                }
                //if (strTime == "")
                //{
                //    intId = 0;

                //}
            }
            if (intChkCnt == 0)
            {
                strMsg = AppConstants.deliveryDateZipCode;
            }
            if (returnDate == 0)
            {

                strMsg = strMsg + "<br>" + AppConstants.invalidDate;

            }
            if (intId == 0)
            {

                strMsg = strMsg + "<br>" + AppConstants.invalidHours;

            }
            if (intId == 2)
            {

                strMsg = strMsg + "<br>" + AppConstants.invalidTime;

            }
            return strMsg;

        }





        public void clear()
        {

            txtDeliveryDate.Text = "";
           drpLocation.SelectedValue = "Select";
            string strTime = string.Empty;
            for (int intZip = 0; intZip < lisZip.Items.Count; intZip++)
            {
                if (lisZip.Items[intZip].Selected == true)
                {
                    lisZip.Items[intZip].Selected = false;

                }
            }

            for (int i = 0; i < dtlDelieveryTime.Items.Count; i++)
            {
                CheckBox chkDeliveryTime;
                Label lblDeliveryTime;
                TextBox txtDeliveryTime;
                DataListItem item = dtlDelieveryTime.Items[i];
                chkDeliveryTime = (CheckBox)item.FindControl("chkDelieveryTime");
                lblDeliveryTime = (Label)item.FindControl("lblTimeID");
                txtDeliveryTime = (TextBox)item.FindControl("txtTime");
                strTime = Convert.ToString(txtDeliveryTime.Text);

                if (chkDeliveryTime.Checked == true && strTime != "")
                {
                    chkDeliveryTime.Checked = false;
                    txtDeliveryTime.Text = "";
                }
                else if (chkDeliveryTime.Checked == false && strTime != "")
                {
                    txtDeliveryTime.Text = "";
                }
                else if (chkDeliveryTime.Checked == true && strTime == "")
                {
                    chkDeliveryTime.Checked = false;
                    txtDeliveryTime.Text = "";
                }
            }
        }
    }
}

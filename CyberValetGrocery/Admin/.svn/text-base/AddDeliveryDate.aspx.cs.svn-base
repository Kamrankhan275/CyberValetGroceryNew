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
    public partial class AddDeliveryDate : System.Web.UI.Page
    {
        DbProvider dbAddInfo = new DbProvider();
        DropdownProvider dropZip = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAdd.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                dropZip.bindZipCheckBox(lisZip);
                for (int intZip = 0; intZip < lisZip.Items.Count; intZip++)
                {
                    lisZip.Items[intZip].Selected = true;
                }
                dropZip.bindLocationDropdown(drpLocation);
                lblMsg.Text = "";
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
            DataSet dsDeliverytime = dbAddInfo.GetdsDeliverytimeInfo();
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
                string strcheckValidation = string.Empty;
                int intInsertDate = 0;
                int intInsertDateZipMap = 0;
                int intZipcode = 1;
                int intInsertDateMap = 0;
                int checkDateAlreadyExit = 0;
                int Numberoftimeslot = 0;
                int intCnt = 0;

                strcheckValidation = CheckValidation();
                if (strcheckValidation == "")
                {
                    checkDateAlreadyExit = dbAddInfo.DeliveryDateAlreadyExist(txtDeliveryDate.Text);
                    if (checkDateAlreadyExit == 0)
                    {
                        lblMsg.Text = "";
                        DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
                        DateTime dtDate = Convert.ToDateTime(txtDeliveryDate.Text, myDTFI);
                        //string strDate = SplitDate(txtDeliveryDate.Text);
                        //DateTime dtDate = Convert.ToDateTime(strDate);
                        intInsertDate = dbAddInfo.InsertDeliveryDateInfo(dtDate, Convert.ToInt32(drpLocation.SelectedValue));
                        if (intInsertDate != 0)
                        {

                            for (int intZip = 0; intZip < lisZip.Items.Count; intZip++)
                            {
                                

                                if (lisZip.Items[intZip].Selected == true)
                                {
                                    int intZipVal = Convert.ToInt32(lisZip.Items[intZip].Value);
                                    intInsertDateZipMap = dbAddInfo.InsertDeliveryDateZipInfo(intInsertDate,intZipVal);
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
                                if (chkDeliveryTime.Checked == true && strTime != "")
                                {
                                    if (intCnt < Numberoftimeslot)
                                    {
                                        intInsertDateMap = dbAddInfo.InsertDeliveryDateMappingInfo(intInsertDate, intId, Convert.ToInt32(strTime), Convert.ToInt32(drpLocation.SelectedValue));
                                        intCnt++;
                                    }

                                }
                                else if (chkDeliveryTime.Checked == false && strTime != "")
                                {
                                    if (intCnt < Numberoftimeslot)
                                    {
                                        intInsertDateMap = dbAddInfo.InsertDeliveryDateMappingInfo(intInsertDate, intId, Convert.ToInt32(strTime), Convert.ToInt32(drpLocation.SelectedValue));
                                        intCnt++;
                                    }

                                }


                            }
                            if (intInsertDateMap != 0)
                            {
                                lblMsg.Text = "";
                                lblMsg.Text = AppConstants.deliveryDateAddSuccess;
                                lblMsg.ForeColor = System.Drawing.Color.Black;
                                clear();


                            }
                            else
                            {
                                lblMsg.Text = "";
                                lblMsg.Text = AppConstants.deliveryDateAddFailed;
                                lblMsg.ForeColor = System.Drawing.Color.Red;

                            }
                        }
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.deliveryDateAlreadyExist;
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
            string month =dateInfo[0];
            string year = dateInfo[2];
            string strReturn=day+'/'+month+'/'+year;
            return strReturn;
        }

       

        public string CheckValidation()
        {
            int intChkCnt = 0;
            int intId = 0;
            string strTime = string.Empty;
            string strMsg = string.Empty;
            int returnDate = 0;
            DataValidator dataValidator = new DataValidator();
            returnDate = DataValidator.IsValidDateGreaterToday(txtDeliveryDate.Text);
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
                    intId = 1;

                }
                else if (chkDeliveryTime.Checked == true && strTime == "")
                {
                    intId = 0;

                }
                
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

                }

            }
            
          

        }
    }
}

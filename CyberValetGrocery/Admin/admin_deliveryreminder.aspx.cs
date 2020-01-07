using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using System.Collections.Specialized;
using CyberValetGrocery.Class;

namespace CyberValetGrocery.Admin
{
    public partial class admin_deliveryreminder : System.Web.UI.Page
    {
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        DbProvider dbDeliveryReminder = new DbProvider();
        DropdownProvider drProviderDeliverReminder = new DropdownProvider();
        string companyName = "";
        string infoEmailAddress = "";
        string allUsersName = "";
        string allUsersEmailAddress = "";
        string allDeliveryTime = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
               
                drProviderDeliverReminder.bindDeliveryReminderDropdown(drpDeliveryDate);
                pnlEmail.Visible = false;
                BindGrid();
              
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            int retDeliveryUpdate = 0;
            try
            {
               int intReturn=sendOrderReminderEmailMail();
               if (intReturn > 0)
               {
                   if (intReturn == 1)
                   {
                       pnlEmail.Visible = true;
                       BindGridCustomerInformation();
                       retDeliveryUpdate = dbDeliveryReminder.updateDeliveryReminder(Convert.ToString(drpDeliveryDate.SelectedValue));
                       lblMsg.Text = "";
                       lblMsg.Text = AppConstants.strDeliveryRemindersuccessfully;
                       lblMsg.ForeColor = System.Drawing.Color.Black;
                       drpDeliveryDate.SelectedValue = "Select";
                   }
                   else
                   {
                       lblMsg.Text = "";
                       lblMsg.Text = AppConstants.strNoDeliveryReminder;
                       lblMsg.ForeColor = System.Drawing.Color.Red;
                       

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
            DataSet dsAdminCustomers = dbDeliveryReminder.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbDeliveryReminder.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbDeliveryReminder.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
                if (name == "Delivery Reminders")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbDeliveryReminder.dispose();
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.deliveryReminderPageTitle;
                        companyName = Convert.ToString(dtrow["CompanyShortName"]);
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        //Funcation for getting Info Email from database(Constant).
        public void getInfoEmailAddress()
        {
            int constantId = 1;

            DataSet dsGetInfoEmailAddress = new DataSet();
            dbDeliveryReminder.dispose();
            dsGetInfoEmailAddress = dbDeliveryReminder.GetInfoEmmailAddressConstant(constantId);

            if (dsGetInfoEmailAddress.Tables[0].Rows.Count > 0)
            {
                if (dsGetInfoEmailAddress != null && dsGetInfoEmailAddress.Tables.Count > 0 && dsGetInfoEmailAddress.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dtrow in dsGetInfoEmailAddress.Tables[0].Rows)
                    {
                        infoEmailAddress = Convert.ToString(dtrow["InfoEmail"]);
                    }
                }
            }
        }

        //Funcation for getting Info Email from database(Constant).
        public void getAllUsersEmailAddress()
        {

            DataSet dsGetAllUsersEmailAddress = new DataSet();
            dbDeliveryReminder.dispose();
            dsGetAllUsersEmailAddress = dbDeliveryReminder.GetUsersEmailAddressForDeliveryReminder(Convert.ToString(drpDeliveryDate.SelectedValue));

            if (dsGetAllUsersEmailAddress.Tables[0].Rows.Count > 0)
            {
                if (dsGetAllUsersEmailAddress != null && dsGetAllUsersEmailAddress.Tables.Count > 0 && dsGetAllUsersEmailAddress.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetAllUsersEmailAddress.Tables[0].Rows)
                    {
                        allUsersName += Convert.ToString(dtrow["users_fname"]) + ",";
                        allUsersEmailAddress += Convert.ToString(dtrow["users_email"]) + ",";
                        allDeliveryTime += Convert.ToString(dtrow["orders_deliverytime"]) + ",";

                    }
                }
            }
        }

        // Function for send text email to all users.
        public int sendOrderReminderEmailMail()
        {
            getInfoEmailAddress();
            getAllUsersEmailAddress();

            string strToEmail = allUsersEmailAddress;
            string strFromEmail = infoEmailAddress;


            string[] strAllUserEmails = allUsersEmailAddress.Split(',');
            string[] strAllUserFirstName = allUsersName.Split(',');
            string[] strAllDeliveryTime = allDeliveryTime.Split(',');

            string strSubject = companyName + AppConstants.strOrderReminder;

            try
            {
                string strEmailContent = string.Empty;
                if (strAllUserEmails.Length - 1 > 0)
                {
                    for (int email = 0; email < strAllUserEmails.Length - 1; email++)
                    {
                        MailMessage emailFromAdmin = new MailMessage(strFromEmail, strAllUserEmails[email]);

                        //Fetch file name from AppConstants class file
                        string strFileName = AppConstants.strDeliveryReminderTextFile;

                        //object created for NameValueCollection
                        NameValueCollection emailVariable = new NameValueCollection();


                        emailVariable["$InfoEmailAddress$"] = strFromEmail;

                        emailVariable["$name$"] = strAllUserFirstName[email];

                        emailVariable["$deliveryTime$"] = strAllDeliveryTime[email];

                        emailVariable["$companyName$"] = companyName;

                        emailVariable["$deliveryDate$"] = Convert.ToString(drpDeliveryDate.SelectedValue);

                        //object created for EmailGenerator class file 
                        EmailGenerator getEmailContent = new EmailGenerator();
                        strEmailContent = getEmailContent.SendEmailFromFile(strFileName, emailVariable);


                        emailFromAdmin.Subject = strSubject;
                        emailFromAdmin.Body = strEmailContent;

                        emailFromAdmin.IsBodyHtml = true;

                        SmtpClient smtpServer = new SmtpClient();
                        smtpServer.Send(emailFromAdmin);
                    }
                    return (1);
                }
                else
                {
                    return (2);
                }
            }
            catch
            {
                return (0);
            }
        }

        //Function for Bind Zip data grid for getting sent delivery reminder dates.
        public void BindGrid()
        {

            DataSet dsDeliveryReminderSentEmail = new DataSet();
            dsDeliveryReminderSentEmail = dbDeliveryReminder.getDeliveryReminderSentEmailInfo();

            if (dsDeliveryReminderSentEmail.Tables.Count > 0)
            {
                if (dsDeliveryReminderSentEmail != null && dsDeliveryReminderSentEmail.Tables.Count > 0 && dsDeliveryReminderSentEmail.Tables[0].Rows.Count > 0)
                {
                    gridDeliveryReminderSentEmail.DataSource = dsDeliveryReminderSentEmail;
                    gridDeliveryReminderSentEmail.DataBind();
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            dbDeliveryReminder.dispose();
        }

        //Function for Bind grid for getting delivery reminder coustomer info.
        public void BindGridCustomerInformation()
        {

            DataSet dsDeliveryReminderSentEmail = new DataSet();
            dsDeliveryReminderSentEmail = dbDeliveryReminder.GetUsersEmailAddressForDeliveryReminder(Convert.ToString(drpDeliveryDate.SelectedValue));

            if (dsDeliveryReminderSentEmail.Tables.Count > 0)
            {
                if (dsDeliveryReminderSentEmail != null && dsDeliveryReminderSentEmail.Tables.Count > 0 && dsDeliveryReminderSentEmail.Tables[0].Rows.Count > 0)
                {
                    //check when no posts or photos found

                    gridCustomerInfo.DataSource = dsDeliveryReminderSentEmail;
                    gridCustomerInfo.DataBind();
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            dbDeliveryReminder.dispose();
        }
        //GetUsersEmailAddressForDeliveryReminder


        protected void gridDeliveryReminderSentEmail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridDeliveryReminderSentEmail.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridCustomerInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridCustomerInfo.PageIndex = e.NewPageIndex;
            BindGridCustomerInformation();
        }

    }
}

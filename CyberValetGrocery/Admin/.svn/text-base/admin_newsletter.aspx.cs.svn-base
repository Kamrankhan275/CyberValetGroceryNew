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
    public partial class admin_newsletter : System.Web.UI.Page
    {
        DbProvider dbNewsletterText = new DbProvider();
        DropdownProvider dropLocation = new DropdownProvider();
        string infoEmailAddress = "";
        string allUsersName = "";
        string allUsersEmailAddress = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSend.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {

                dropLocation.bindLocationDropdown(drpLocation);//Bind location  into dropdown
                

            }

        }

        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbNewsletterText.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbNewsletterText.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbNewsletterText.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
                if (name == "Newsletter (text)")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbNewsletterText.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.Newsletter;
                        ViewState["CompanyName"] = Convert.ToString(dtrow["CompanyShortName"]);
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (FCKeditor1.Value != "")
                {
                   int intReturn=sendTextNewsletterMail();
                   if (intReturn == 1)
                   {
                       drpLocation.SelectedValue = "Select";
                       txtSubject.Text = "";
                       lblMsg.Text = "";
                       FCKeditor1.Value = "";
                       lblMsg.Text = AppConstants.strNewsSuccess;
                       lblMsg.ForeColor = System.Drawing.Color.Black;
                   }

                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.strBodyRequired;
                    lblMsg.ForeColor = System.Drawing.Color.Red;

                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }


        //Funcation for getting Info Email from database(Constant).
        public void getInfoEmailAddress()
        {
            int constantId = 1;

            DataSet dsGetInfoEmailAddress = new DataSet();
            dbNewsletterText.dispose();
            dsGetInfoEmailAddress = dbNewsletterText.GetInfoEmmailAddressConstant(constantId);

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

            int intUsersStatusId = 0;
            int intUsersNewsletter = 0;

            intUsersStatusId = AppConstants.intUsersStatusId;
            intUsersNewsletter = AppConstants.intUsersNewsletter;

            DataSet dsGetAllUsersEmailAddress = new DataSet();
            dbNewsletterText.dispose();
            dsGetAllUsersEmailAddress = dbNewsletterText.GetUsersEmailAddress(intUsersStatusId, intUsersNewsletter);

            if (dsGetAllUsersEmailAddress.Tables[0].Rows.Count > 0)
            {
                if (dsGetAllUsersEmailAddress != null && dsGetAllUsersEmailAddress.Tables.Count > 0 && dsGetAllUsersEmailAddress.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetAllUsersEmailAddress.Tables[0].Rows)
                    {
                        allUsersName += Convert.ToString(dtrow["users_fname"]) + ",";
                        allUsersEmailAddress += Convert.ToString(dtrow["users_email"]) + ",";
                    }
                }
            }
        }

        // Function for send text email to all users.
        public int sendTextNewsletterMail()
        {
            getInfoEmailAddress();
            getAllUsersEmailAddress();

            string strToEmail = allUsersEmailAddress;
            string strFromEmail = infoEmailAddress;

            string[] strAllUserEmails = allUsersEmailAddress.Split(',');
            string[] strAllUserFirstName = allUsersName.Split(',');

            string strSubject = txtSubject.Text;

            try
            {
                string strEmailContent = string.Empty;
                if (strAllUserEmails.Length - 1 > 0)
                {
                    for (int email = 0; email < strAllUserEmails.Length - 1; email++)
                    {
                        MailMessage emailFromAdmin = new MailMessage(strFromEmail, strAllUserEmails[email]);

                        //Fetch file name from AppConstants class file
                        string strFileName = AppConstants.strNewsletterTextFile;

                        //object created for NameValueCollection
                        NameValueCollection emailVariable = new NameValueCollection();

                        emailVariable["$NewsLetterText$"] = FCKeditor1.Value;
                        emailVariable["$name$"] = strAllUserFirstName[email];
                        emailVariable["$MessageText$"] = FCKeditor1.Value;
                        emailVariable["$InfoEmailAddress$"] = strFromEmail;
                        emailVariable["$companyName$"] = Convert.ToString(ViewState["CompanyName"]);

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


    }
}

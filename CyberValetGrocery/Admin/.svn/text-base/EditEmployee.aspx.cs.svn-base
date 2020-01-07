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
    public partial class EditEmployee : System.Web.UI.Page
    {
        DbProvider dbEditInfo = new DbProvider();
        DropdownProvider dropPermission = new DropdownProvider();
        PasswordRestrictions EncryptDecrypt = new PasswordRestrictions();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Attributes.Add("onclick", "clcontent();");
            DataSet dsEmployeeList = new DataSet();
            DataSet dsEmployeePermissionList = new DataSet();
            changeLinks();
            getCompanyName();
            try
            {
                if (!IsPostBack)
                {
                    dropPermission.bindEmployeeCheckbox(chkPermission);//Bind client name  into dropdown
                    lblMsg.Text = "";       
                    int employeeId = Convert.ToInt32(Request.QueryString["employeeId"]);
                    dsEmployeeList = dbEditInfo.SelectEmployeeDeatils(employeeId);
                    if (dsEmployeeList.Tables.Count > 0)
                     {
                         if (dsEmployeeList != null && dsEmployeeList.Tables.Count > 0 && dsEmployeeList.Tables[0].Rows.Count > 0)
                         {
                             txtFirstName.Text = Convert.ToString(dsEmployeeList.Tables[0].Rows[0]["admin_fname"]);
                             txtLastName.Text = Convert.ToString(dsEmployeeList.Tables[0].Rows[0]["admin_lname"]);
                             txtEmail.Text = Convert.ToString(dsEmployeeList.Tables[0].Rows[0]["admin_email"]);
                             string strPass = EncryptDecrypt.decryptPassword(Convert.ToString(dsEmployeeList.Tables[0].Rows[0]["admin_password"]));
                             txtPassword.Text = strPass;                             
                             ViewState["EmployeePassword"] = strPass;
                             dsEmployeePermissionList = dbEditInfo.SelectEmployeePermissionDeatils(employeeId);
                             if (dsEmployeePermissionList.Tables.Count > 0)
                             {
                                 if (dsEmployeePermissionList != null && dsEmployeePermissionList.Tables.Count > 0 && dsEmployeePermissionList.Tables[0].Rows.Count > 0)
                                 {
                                     for (int intEmpPermission = 0; intEmpPermission < chkPermission.Items.Count; intEmpPermission++)
                                     {
                                         for (int intEmployee = 0; intEmployee < dsEmployeePermissionList.Tables[0].Rows.Count; intEmployee++)
                                         {
                                             if (Convert.ToInt32(chkPermission.Items[intEmpPermission].Value) == Convert.ToInt32(dsEmployeePermissionList.Tables[0].Rows[intEmployee]["permissions_id"]))
                                             {
                                                 chkPermission.Items[intEmpPermission].Selected = true;

                                             }
                                         }
                                             
                                         
                                     }
                                 }
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
            DataSet dsAdminCustomers = dbEditInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbEditInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbEditInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
                if (name == "Employees")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbEditInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.UpdateEmployee;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                       
                int intEmployee = 0;
                int intUpdateEmployeeId;
                int intUpdateEmployeePermission = 0;
                int intDeleteEmployeeId = 0;
                string strEncrypt = string.Empty;
                int employeeId = Convert.ToInt32(Request.QueryString["employeeId"]);
                int intChkErr = checkValidation();       
                if (intChkErr == 0)
                {
                    intEmployee = dbEditInfo.employeeUpdateEmailAlreadyExist(txtEmail.Text,employeeId);
                    if (intEmployee == 0)
                    {
                        if (txtPassword.Text != "")
                        {
                            strEncrypt = EncryptDecrypt.encryptPassword(txtPassword.Text);
                        }
                        else
                        {
                            strEncrypt =EncryptDecrypt.encryptPassword(Convert.ToString(ViewState["EmployeePassword"]));
                        }
                        intUpdateEmployeeId = dbEditInfo.UpdateEmployeeDetailInfo(txtFirstName.Text, txtLastName.Text, txtEmail.Text, strEncrypt, employeeId);
                        if (intUpdateEmployeeId != 0)
                        {
                            intDeleteEmployeeId = dbEditInfo.DeleteEmployeePermission(employeeId);
                            if (intDeleteEmployeeId != 0)
                            {
                                for (int intEmpPermission = 0; intEmpPermission < chkPermission.Items.Count; intEmpPermission++)
                                {
                                    if (chkPermission.Items[intEmpPermission].Selected == true)
                                    {
                                        int chkValue = Convert.ToInt32(chkPermission.Items[intEmpPermission].Value);
                                        intUpdateEmployeePermission = dbEditInfo.InsertEmployeePermissionInfo(employeeId, chkValue);

                                    }
                                }

                                lblMsg.Text = "";
                                lblMsg.Text = AppConstants.employeeUpdateSuccess;
                                lblMsg.ForeColor = System.Drawing.Color.Black;
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


        public int checkValidation()
        {

            DataValidator dataValidator = new DataValidator();
            bool returnEmail;
            int intReturn = 0;
            int intChkCnt = 0;
            string strMsg = string.Empty;
            returnEmail = DataValidator.IsValidEmail(Convert.ToString(txtEmail.Text));
            for (int intEmpPermission = 0; intEmpPermission < chkPermission.Items.Count; intEmpPermission++)
            {
                if (chkPermission.Items[intEmpPermission].Selected == true)
                {
                    intChkCnt = 1;


                }
            }
            if (returnEmail == false && intChkCnt == 0)
            {
                strMsg = AppConstants.invalidEmail + "<br>" + AppConstants.strSelectPermission;
                lblMsg.Text = "";
                lblMsg.Text = strMsg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;

            }
            else if (returnEmail == false)
            {
                strMsg = AppConstants.invalidEmail;
                lblMsg.Text = "";
                lblMsg.Text = strMsg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;
            }
            else if (intChkCnt == 0)
            {
                strMsg = AppConstants.strSelectPermission;
                lblMsg.Text = "";
                lblMsg.Text = strMsg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;

            }
            else
            {
                intReturn = 0;

            }



            return intReturn;






        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_employee.aspx", false);

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_employee.aspx", false);

        }
    }
}

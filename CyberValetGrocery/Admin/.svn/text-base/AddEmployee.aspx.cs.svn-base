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
    public partial class AddEmployee : System.Web.UI.Page
    {
        DbProvider dbAddInfo = new DbProvider();
        DropdownProvider dropPermission = new DropdownProvider();
        PasswordRestrictions EncryptDecrypt = new PasswordRestrictions();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAdd.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                dropPermission.bindEmployeeCheckbox(chkPermission);//Bind client name  into dropdown
                lblMsg.Text = "";                

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
                if (name == "Employees")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.AddEmployee;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }
       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                int intChkErr =checkValidation();
                int intEmployee = 0;
                int intInsertEmployeeId;
                int intInsertEmployeePermission = 0;
                string strEncrypt = string.Empty;                
                if (intChkErr == 0)
                {
                    intEmployee = dbAddInfo.employeeEmailAlreadyExist(txtEmail.Text);
                    if (intEmployee == 0)
                    {
                        strEncrypt = EncryptDecrypt.encryptPassword(txtPassword.Text);
                        intInsertEmployeeId = dbAddInfo.InsertEmployeeDetailInfo(txtFirstName.Text, txtLastName.Text, txtEmail.Text, strEncrypt);
                        if (intInsertEmployeeId != 0)
                        {
                            for (int intEmpPermission = 0; intEmpPermission < chkPermission.Items.Count; intEmpPermission++)
                            {
                                if (chkPermission.Items[intEmpPermission].Selected == true)
                                {
                                    int chkValue = Convert.ToInt32(chkPermission.Items[intEmpPermission].Value);
                                    intInsertEmployeePermission = dbAddInfo.InsertEmployeePermissionInfo(intInsertEmployeeId,chkValue);

                                }
                            }
                            clear();
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.employeeAddSuccess;
                            lblMsg.ForeColor = System.Drawing.Color.Black;
                        }

                       
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.employeeEmailExist;
                        lblMsg.ForeColor = System.Drawing.Color.Red;

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
                int intReturn=0;
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



        public void clear()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";

            for (int intEmpPermission = 0; intEmpPermission < chkPermission.Items.Count; intEmpPermission++)
            {
                if (chkPermission.Items[intEmpPermission].Selected == true)
                {
                    chkPermission.Items[intEmpPermission].Selected = false;


                }
            }

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            Response.Redirect("admin_employee.aspx", false);

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            Response.Redirect("admin_employee.aspx", false);

        }
    }
}

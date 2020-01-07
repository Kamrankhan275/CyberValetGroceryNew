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

namespace CyberValetGrocery
{
    public partial class UpdatePhoneInfo : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["userId"] == null)
                {
                    Response.Redirect("My_Account.aspx", false);
                }
                else
                {
                    btnUpdate.Attributes.Add("onclick", "clcontent();");
                    BindSideLink();
                    getCompanyName();
                    if (!IsPostBack)
                    {
                        int userId = 0;
                        userId = Convert.ToInt32(Request.Cookies["userId"].Value);
                        DataSet dsUserDetailsInfo = new DataSet();
                        dsUserDetailsInfo = dbInfo.GetUserDetailsInfo(userId);
                        if (dsUserDetailsInfo.Tables.Count > 0)
                        {
                            if (dsUserDetailsInfo != null && dsUserDetailsInfo.Tables.Count > 0 && dsUserDetailsInfo.Tables[0].Rows.Count > 0)
                            {

                                txtPhone1.Text = Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_phone"]);
                                txtPhone2.Text =Convert.ToString(dsUserDetailsInfo.Tables[0].Rows[0]["users_cell"]);
                            }
                        }
                    }
                }


                dbInfo.dispose();
                
               

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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = 0;
                int intUpdate=0;
                userId = Convert.ToInt32(Request.Cookies["userId"].Value);
               
               
                int intChkValidation = checkValidation();
                if (intChkValidation == 0)
                {

                    intUpdate = dbInfo.UpdateUserPhoneDetailsInfo(txtPhone1.Text, txtPhone2.Text, userId);
                    if (intUpdate == 1)
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.userUpdatePhoneInfoSuccuss;
                        lblMsg.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.userUpdatePhoneInfoFailed;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                
                dbInfo.dispose();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        public int checkValidation()
        {

            DataValidator dataValidator = new DataValidator();
            bool returnPhone1;
            bool returnPhone2;
            int intCheck = 0;
            int intReturn = 0;
            string strMsg = string.Empty;
            returnPhone1 = DataValidator.IsValidPhone(Convert.ToString(txtPhone1.Text));
            if (txtPhone2.Text != "")
            {
                returnPhone2 = DataValidator.IsValidPhone(Convert.ToString(txtPhone2.Text));
            }
            else
            {
                returnPhone2 = true;
            }

            if (returnPhone1 == false)
            {
                strMsg = strMsg + "<br>" + AppConstants.invalidUserRegPhone1;
                intCheck = 1;


            }
            if (returnPhone2 == false)
            {
                strMsg = strMsg + "<br>" + AppConstants.invalidUserRegPhone2;
                intCheck = 1;
            }


            if (intCheck != 0)
            {

                lblMsg.Text = "";
                lblMsg.Text = strMsg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;
            }




            return intReturn;


        }
    }
}

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
    public partial class AddShelves : System.Web.UI.Page
    {
        DbProvider dbAddInfo = new DbProvider();
        DropdownProvider dropAsile = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAdd.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                dropAsile.bindAsileCheckbox(chkAisles);//Bind client name  into dropdown
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
                if (name == "Shelves")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.AddShelves;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                int intChkErr = checkValidation();
                int intShelf = 0;
                int intPopular = 0;
                int intInsertShelf;
                int intInsertShelfMapping = 0;
                string strEncrypt = string.Empty;
                if (intChkErr == 0)
                {
                    intShelf = dbAddInfo.ShelfNameAlreadyExist(txtShelfName.Text);
                    if (intShelf == 0)
                    {
                        if (chkPopular.Checked == true)
                        {
                            intPopular = 1;
                        }
                        else
                        {
                            intPopular = 0;
                        }
                       // intInsertShelf = dbAddInfo.InsertShelfDetailInfo(txtShelfName.Text, Convert.ToInt32(txtMapping.Text),Convert.ToString(intPopular),Convert.ToInt32(AppConstants.locationId));
                        intInsertShelf = dbAddInfo.InsertShelfDetailInfo(txtShelfName.Text,txtMapping.Text, Convert.ToString(intPopular), Convert.ToInt32(AppConstants.locationId));
                        if (intInsertShelf != 0)
                        {
                            for (int intAsileVal = 0; intAsileVal < chkAisles.Items.Count; intAsileVal++)
                            {
                                if (chkAisles.Items[intAsileVal].Selected == true)
                                {
                                    int chkValue = Convert.ToInt32(chkAisles.Items[intAsileVal].Value);
                                    intInsertShelfMapping = dbAddInfo.InsertShelfMappingInfo(intInsertShelf, chkValue);

                                }
                            }
                            clear();
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.shelfAddSuccess;
                            lblMsg.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.shelfAddFailed;
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }




                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.shelfAlreadyExist;
                        lblMsg.ForeColor = System.Drawing.Color.Red;

                    }





                }



            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }
        }


        public void clear()
        {

            txtMapping.Text = "";
            txtShelfName.Text = "";
            chkPopular.Checked = false;
            for (int intAsileVal = 0; intAsileVal < chkAisles.Items.Count; intAsileVal++)
                            {
                                if (chkAisles.Items[intAsileVal].Selected == true)
                                {
                                   chkAisles.Items[intAsileVal].Selected = false;                                    

                                }
                            }

        }

        public int checkValidation()
        {

            DataValidator dataValidator = new DataValidator();

            int intReturn = 0;
            int intChkCnt = 0;
            string strMsg = string.Empty;            
            for (int intAsile = 0; intAsile < chkAisles.Items.Count; intAsile++)
            {
                if (chkAisles.Items[intAsile].Selected == true)
                {
                    intChkCnt = 1;

                }
            }           
           if (intChkCnt == 0)
            {
                strMsg = AppConstants.strSelectAisles;
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

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {

            lblMsg.Text = "";
            Response.Redirect("admin_category2.aspx", false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {

            lblMsg.Text = "";
            Response.Redirect("admin_category2.aspx", false);

        }
    }
}

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
using System.Configuration;
using System.Collections;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Globalization;
using System.Collections.Specialized;
using System.Drawing.Drawing2D;
using System.IO;

namespace CyberValetGrocery.Admin
{
    public partial class EditAisle : System.Web.UI.Page
    {
        DbProvider dbEditInfo = new DbProvider();
        DropdownProvider dropTopAisle = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            try
            {

                DataSet dsAislesList = new DataSet();
                DataSet dsTopAisleMappingList = new DataSet();
                changeLinks();
                btnUpdate.Attributes.Add("onclick", "clcontent();");
                if (!IsPostBack)
                {
                   
                    lblMsg.Text = "";
                    dropTopAisle.bindTopAisleCheckbox(chkTopAisles);//Bind Checkbox into dropdown
                    int aislesId = Convert.ToInt32(Request.QueryString["aislesId"]);
                    dsAislesList = dbEditInfo.SelectAislesDeatils(aislesId);
                    if (dsAislesList.Tables.Count > 0)
                    {
                        if (dsAislesList != null && dsAislesList.Tables.Count > 0 && dsAislesList.Tables[0].Rows.Count > 0)
                        {
                            txtAisleName.Text = Convert.ToString(dsAislesList.Tables[0].Rows[0]["aisle_name"]);                         
                            
                            if (Convert.ToString(dsAislesList.Tables[0].Rows[0]["aisle_show"]) == "0")
                            {
                                rdShow.SelectedValue = "0";

                            }
                            else
                            {
                                rdShow.SelectedValue = "1";

                            }
                            
                            dsTopAisleMappingList = dbEditInfo.SelectTopAisleMappingDeatils(aislesId);
                            if (dsTopAisleMappingList.Tables.Count > 0)
                            {
                                if (dsTopAisleMappingList != null && dsTopAisleMappingList.Tables.Count > 0 && dsTopAisleMappingList.Tables[0].Rows.Count > 0)
                                {
                                    for (int intShelf = 0; intShelf < chkTopAisles.Items.Count; intShelf++)
                                    {
                                        for (int intShelfMapping = 0; intShelfMapping < dsTopAisleMappingList.Tables[0].Rows.Count; intShelfMapping++)
                                        {
                                            if (Convert.ToInt32(chkTopAisles.Items[intShelf].Value) == Convert.ToInt32(dsTopAisleMappingList.Tables[0].Rows[intShelfMapping]["aisletop_id"]))
                                            {
                                                chkTopAisles.Items[intShelf].Selected = true;


                                            }
                                        }


                                    }
                                }
                            }
                        }
                    }

                    lblMsg.Text = "";

                }
                dbEditInfo.dispose();


                
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
                if (name == "Aisles")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbEditInfo.dispose();


        }


        public int checkValidation()
        {

            DataValidator dataValidator = new DataValidator();

            int intReturn = 0;
            int intChkCnt = 0;
            string strMsg = string.Empty;
            for (int intTopAisleVal = 0; intTopAisleVal < chkTopAisles.Items.Count; intTopAisleVal++)
            {
                if (chkTopAisles.Items[intTopAisleVal].Selected == true)
                {
                    intChkCnt = 1;

                }
            }
            if (intChkCnt == 0)
            {
                strMsg = AppConstants.strSelectTopAisles;
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.UpdateAisle;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int intChkErr = checkValidation();
                int intUpdateAisles = 0;
                int intAisle = 0;
                int intDeleteTopAisle = 0;             
                int intInsertTopAisleMapping = 0;
                int aislesId = Convert.ToInt32(Request.QueryString["aislesId"]);
                intAisle = dbEditInfo.AisleNameUpdateAlreadyExist(txtAisleName.Text,aislesId);
                if (intAisle == 0)
                {
                   
                   intUpdateAisles = dbEditInfo.UpdateAisleInfo(txtAisleName.Text, Convert.ToInt32(AppConstants.locationId), rdShow.SelectedValue, aislesId);
                       
                        if (intUpdateAisles != 0)
                        {
                            intDeleteTopAisle = dbEditInfo.DeleteTopAisleMappingInformation(aislesId);
                            //if (intDeleteTopAisle != 0)
                            //{
                                for (int intAisleVal = 0; intAisleVal < chkTopAisles.Items.Count; intAisleVal++)
                                {
                                    if (chkTopAisles.Items[intAisleVal].Selected == true)
                                    {
                                        int chkValue = Convert.ToInt32(chkTopAisles.Items[intAisleVal].Value);
                                        intInsertTopAisleMapping = dbEditInfo.InsertTopAisleMappingInfo(chkValue, aislesId);

                                    }
                                }
                            //}
                            lblMsg.Text = "";         
                            lblMsg.Text = AppConstants.asileUpdateSuccess;
                            lblMsg.ForeColor = System.Drawing.Color.Black;

                        }
                        else
                        {
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.asileUpdateFailed;
                            lblMsg.ForeColor = System.Drawing.Color.Red;

                        }
                    
                    
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.asileAlreadyExist;
                    lblMsg.ForeColor = System.Drawing.Color.Red;


                }


                dbEditInfo.dispose();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }

        }



        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_category.aspx", false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_category.aspx", false);

        }
    }
}

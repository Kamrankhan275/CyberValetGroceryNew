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
    public partial class EditShelves : System.Web.UI.Page
    {
        DbProvider dbEditInfo = new DbProvider();
        DropdownProvider dropAsile = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Attributes.Add("onclick", "clcontent();");           
            changeLinks();
            getCompanyName();
            try
            {
                if (!IsPostBack)
                {
                    DataSet dsShelfList = new DataSet();
                    DataSet dsShelfMappingList = new DataSet();
                    dropAsile.bindAsileCheckbox(chkAisles);//Bind Checkbox into dropdown
                    int shelfId = Convert.ToInt32(Request.QueryString["shelfId"]);
                    dsShelfList = dbEditInfo.SelectShelfDeatils(shelfId);
                    if (dsShelfList.Tables.Count > 0)
                    {
                        if (dsShelfList != null && dsShelfList.Tables.Count > 0 && dsShelfList.Tables[0].Rows.Count > 0)
                        {
                            txtShelfName.Text = Convert.ToString(dsShelfList.Tables[0].Rows[0]["shelf_name"]); 
                            txtMapping.Text=Convert.ToString(dsShelfList.Tables[0].Rows[0]["shelf_position"]);
                            if (Convert.ToString(dsShelfList.Tables[0].Rows[0]["shelf_popular"]) == "1")
                            {
                                chkPopular.Checked = true;
                            }

                            if (Convert.ToString(dsShelfList.Tables[0].Rows[0]["shelf_show"]) == "0")
                            {
                                rdShow.SelectedValue = "0";

                            }
                            else
                            {
                                rdShow.SelectedValue = "1";

                            }

                            dsShelfMappingList = dbEditInfo.SelectShelfMappingDeatils(shelfId);
                            if (dsShelfMappingList.Tables.Count > 0)
                            {
                                if (dsShelfMappingList != null && dsShelfMappingList.Tables.Count > 0 && dsShelfMappingList.Tables[0].Rows.Count > 0)
                                {
                                    for (int intShelf = 0; intShelf < chkAisles.Items.Count; intShelf++)
                                    {
                                        for (int intShelfMapping = 0; intShelfMapping < dsShelfMappingList.Tables[0].Rows.Count; intShelfMapping++)
                                        {
                                            if (Convert.ToInt32(chkAisles.Items[intShelf].Value) == Convert.ToInt32(dsShelfMappingList.Tables[0].Rows[intShelfMapping]["aisle_id"]))
                                            {
                                                chkAisles.Items[intShelf].Selected = true;
                                               
                                            }
                                        }


                                    }
                                }
                            }

                        }
                    }

                        lblMsg.Text = "";
                    

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
                if (name == "Shelves")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.UpdateShelf;
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
                int intShelf = 0;
                int intPopular = 0;
                int intUpdateShelf;
                int intDeleteAsile=0;
                int intInsertShelfMapping = 0;               
                int shelfId = Convert.ToInt32(Request.QueryString["shelfId"]);
                if (intChkErr == 0)
                {
                    intShelf = dbEditInfo.ShelfNameUpdateAlreadyExist(txtShelfName.Text, shelfId);
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
                     //  intUpdateShelf = dbEditInfo.UpdateShelfDetailInfo(txtShelfName.Text,Convert.ToInt32(rdShow.SelectedValue), Convert.ToInt32(txtMapping.Text) , Convert.ToString(intPopular), shelfId);
                      intUpdateShelf = dbEditInfo.UpdateShelfDetailInfo(txtShelfName.Text, Convert.ToInt32(rdShow.SelectedValue), txtMapping.Text, Convert.ToString(intPopular), shelfId);
                        if (intUpdateShelf != 0)
                        {

                            intDeleteAsile = dbEditInfo.DeleteShelvesMappingInformation(shelfId);
                            if (intDeleteAsile != 0)
                            {
                                for (int intAsileVal = 0; intAsileVal < chkAisles.Items.Count; intAsileVal++)
                                {
                                    if (chkAisles.Items[intAsileVal].Selected == true)
                                    {
                                        int chkValue = Convert.ToInt32(chkAisles.Items[intAsileVal].Value);
                                        intInsertShelfMapping = dbEditInfo.InsertShelfMappingInfo(shelfId, chkValue);
                                       
                                        if (intInsertShelfMapping != 0)
                                        {
                                            int updatelinkid = 0;
                                            updatelinkid = dbEditInfo.UpdateShelfProductMappingInfo(intInsertShelfMapping, shelfId, chkValue);
                                        }

                                    }
                                }
                            }


                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.shelfUpdateSuccess;
                            lblMsg.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {

                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.shelfUpdateFailed;
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
            Response.Redirect("admin_category2.aspx", false);


        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_category2.aspx", false);


        }
    }
}

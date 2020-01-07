using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CyberValetGrocery.Class;

namespace CyberValetGrocery.Admin
{
    public partial class EditStore : System.Web.UI.Page
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
                string strstorename = string.Empty;
                DataSet dsAislesList = new DataSet();
                changeLinks();
                btnUpdate.Attributes.Add("onclick", "clcontent();");

                if (!IsPostBack)
                {
                    lblMsg.Text = "";

                    int storeId = Convert.ToInt32(Request.QueryString["storeId"]);
                    txtStoreName.Text = dbEditInfo.GetStoreLocationName(storeId);
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

                if (name == "Aisles")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + " - Update Store Location.";
                    }
                }
            }

            dbGetCompanyName.dispose();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int intUpdateStore = 0;
                int intstore = 0;
                int storeId = Convert.ToInt32(Request.QueryString["storeId"]);
                intstore = dbEditInfo.StoreNameUpdateAlreadyExist(txtStoreName.Text);

                if (intstore == 0)
                {
                    intUpdateStore = dbEditInfo.UpdateStoreInfo(txtStoreName.Text, storeId);

                    if (intUpdateStore != 0)
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = "Store Location Updated Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = "Update store location Name failed.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = "Store Location Name Already exists.";
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
            Response.Redirect("admin_storelocation.aspx", false);
        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_storelocation.aspx", false);
        }
    }
}

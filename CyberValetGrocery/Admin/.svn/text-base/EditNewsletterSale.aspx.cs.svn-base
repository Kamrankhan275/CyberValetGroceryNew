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
  

    public partial class EditNewsletterSale : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        DropdownProvider dropSales = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                changeLinks();
                getCompanyName();
                if (!Page.IsPostBack)
                {


                    int intEmailId = 0;
                    int intCheck = 0;
                    intCheck = Convert.ToInt32(Request.QueryString["Check"]);
                    if (intCheck == 1)
                    {
                        BindSubject();

                    }
                    else
                    {




                        intEmailId = Convert.ToInt32(Request.QueryString["EmailSendId"]);
                        string strHead = string.Empty;
                        string strFoot = string.Empty;
                        string strProdId = string.Empty;
                        string strProdtit = string.Empty;



                        DataSet dsInfo = new DataSet();
                        dsInfo = dbListInfo.SelectSendEmailInformation(intEmailId);
                        txtSubject.Text = Convert.ToString(dsInfo.Tables[0].Rows[0]["Subject"]);
                        txtFromDate.Text = Convert.ToString(dsInfo.Tables[0].Rows[0]["StarDate"]);
                        txtToDate.Text = Convert.ToString(dsInfo.Tables[0].Rows[0]["EndDate"]);
                        strHead = Convert.ToString(dsInfo.Tables[0].Rows[0]["HeaderMsg"]);
                        FCKeditor1.Value = strHead;
                        strFoot = Convert.ToString(dsInfo.Tables[0].Rows[0]["FooterMsg"]);
                        FCKeditor2.Value = strFoot;
                        DataSet dsSalesItemList = new DataSet();
                        int incnt = 0;
                        dsSalesItemList = dbListInfo.GetSalesDetailsInformation(Convert.ToInt32(AppConstants.locationId));
                        if (dsSalesItemList.Tables.Count > 0)
                        {
                            if (dsSalesItemList != null && dsSalesItemList.Tables.Count > 0 && dsSalesItemList.Tables[0].Rows.Count > 0)
                            {
                                dropSales.bindSalesItemDropdown(drpSaleItem1);
                                dropSales.bindSalesItemDropdown(drpSaleItem2);
                                dropSales.bindSalesItemDropdown(drpSaleItem3);
                                dropSales.bindSalesItemDropdown(drpSaleItem4);
                                dropSales.bindSalesItemDropdown(drpSaleItem5);
                                dropSales.bindSalesItemDropdown(drpSaleItem6);
                                dropSales.bindSalesItemDropdown(drpSaleItem7);
                                dropSales.bindSalesItemDropdown(drpSaleItem8);

                                if (Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale1"]) != "")
                                {
                                    incnt = 0;
                                    strProdId = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale1"]);
                                    strProdtit = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle1"]);

                                    foreach (DataRow dtrow in dsSalesItemList.Tables[0].Rows)
                                    {
                                        if (Convert.ToString(dtrow["product_id"]) == strProdId && Convert.ToString(dtrow["product_title"]) == strProdtit)
                                        {
                                            incnt = 1;
                                        }
                                    }
                                    if (incnt == 1)
                                    {
                                        lblSaleItem1.Text = "";
                                        txtSaleItem1.Text = "";
                                        pnlSaleItem1.Visible = false;
                                        pnlSaleItemDrp1.Visible = true;
                                        drpSaleItem1.SelectedValue = strProdId;

                                    }
                                    else
                                    {
                                        pnlSaleItem1.Visible = true;
                                        pnlSaleItemDrp1.Visible = false;
                                        txtSaleItem1.Text = strProdtit;
                                        lblSaleItem1.Text = "";
                                        lblSaleItem1.Text = AppConstants.unavailableSale;
                                    }


                                }
                                else
                                {
                                    pnlSaleItem1.Visible = false;
                                    pnlSaleItemDrp1.Visible = true;
                                    lblSaleItem1.Text = "";
                                    txtSaleItem1.Text = "";
                                    btnSaleItem1.Visible = false;


                                }


                                if (Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale2"]) != "")
                                {
                                    incnt = 0;
                                    strProdId = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale2"]);
                                    strProdtit = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle2"]);

                                    foreach (DataRow dtrow in dsSalesItemList.Tables[0].Rows)
                                    {
                                        if (Convert.ToString(dtrow["product_id"]) == strProdId && Convert.ToString(dtrow["product_title"]) == strProdtit)
                                        {
                                            incnt = 1;
                                        }
                                    }
                                    if (incnt == 1)
                                    {

                                        pnlSaleItem2.Visible = false;
                                        pnlSaleItemDrp2.Visible = true;
                                        drpSaleItem2.SelectedValue = strProdId;
                                        lblSaleItem2.Text = "";
                                        txtSaleItem2.Text = "";

                                    }
                                    else
                                    {
                                        pnlSaleItem2.Visible = true;
                                        pnlSaleItemDrp2.Visible = false;
                                        txtSaleItem2.Text = strProdtit;
                                        lblSaleItem1.Text = "";
                                        lblSaleItem2.Text = AppConstants.unavailableSale;
                                    }


                                }
                                else
                                {
                                    pnlSaleItem2.Visible = false;
                                    pnlSaleItemDrp2.Visible = true;
                                    lblSaleItem2.Text = "";
                                    txtSaleItem2.Text = "";
                                    btnSaleItem2.Visible = false;


                                }



                                if (Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale3"]) != "")
                                {
                                    incnt = 0;
                                    strProdId = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale3"]);
                                    strProdtit = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle3"]);

                                    foreach (DataRow dtrow in dsSalesItemList.Tables[0].Rows)
                                    {
                                        if (Convert.ToString(dtrow["product_id"]) == strProdId && Convert.ToString(dtrow["product_title"]) == strProdtit)
                                        {
                                            incnt = 1;
                                        }
                                    }
                                    if (incnt == 1)
                                    {
                                        pnlSaleItem3.Visible = false;
                                        pnlSaleItemDrp3.Visible = true;
                                        drpSaleItem3.SelectedValue = strProdId;
                                        lblSaleItem3.Text = "";
                                        txtSaleItem2.Text = "";

                                    }
                                    else
                                    {
                                        pnlSaleItem3.Visible = true;
                                        pnlSaleItemDrp3.Visible = false;
                                        txtSaleItem3.Text = strProdtit;
                                        lblSaleItem1.Text = "";
                                        lblSaleItem3.Text = AppConstants.unavailableSale;
                                    }


                                }
                                else
                                {
                                    pnlSaleItem3.Visible = false;
                                    pnlSaleItemDrp3.Visible = true;
                                    txtSaleItem3.Text = "";
                                    lblSaleItem3.Text = "";
                                    btnSaleItem3.Visible = false;


                                }


                                if (Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale4"]) != "")
                                {
                                    incnt = 0;
                                    strProdId = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale4"]);
                                    strProdtit = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle4"]);

                                    foreach (DataRow dtrow in dsSalesItemList.Tables[0].Rows)
                                    {
                                        if (Convert.ToString(dtrow["product_id"]) == strProdId && Convert.ToString(dtrow["product_title"]) == strProdtit)
                                        {
                                            incnt = 1;
                                        }
                                    }
                                    if (incnt == 1)
                                    {
                                        pnlSaleItem4.Visible = false;
                                        pnlSaleItemDrp4.Visible = true;
                                        drpSaleItem4.SelectedValue = strProdId;
                                        txtSaleItem4.Text = "";
                                        lblSaleItem4.Text = "";
                                    }
                                    else
                                    {
                                        pnlSaleItem4.Visible = true;
                                        pnlSaleItemDrp4.Visible = false;
                                        txtSaleItem4.Text = strProdtit;
                                        lblSaleItem4.Text = "";
                                        lblSaleItem4.Text = AppConstants.unavailableSale;
                                    }


                                }
                                else
                                {
                                    pnlSaleItem4.Visible = false;
                                    pnlSaleItemDrp4.Visible = true;
                                    txtSaleItem4.Text = "";
                                    lblSaleItem4.Text = "";
                                    btnSaleItem4.Visible = false;


                                }

                                if (Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale5"]) != "")
                                {
                                    incnt = 0;
                                    strProdId = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale5"]);
                                    strProdtit = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle5"]);

                                    foreach (DataRow dtrow in dsSalesItemList.Tables[0].Rows)
                                    {
                                        if (Convert.ToString(dtrow["product_id"]) == strProdId && Convert.ToString(dtrow["product_title"]) == strProdtit)
                                        {
                                            incnt = 1;
                                        }
                                    }
                                    if (incnt == 1)
                                    {
                                        pnlSaleItem5.Visible = false;
                                        pnlSaleItemDrp5.Visible = true;
                                        drpSaleItem5.SelectedValue = strProdId;
                                        txtSaleItem5.Text = "";
                                        lblSaleItem5.Text = "";

                                    }
                                    else
                                    {
                                        pnlSaleItem5.Visible = true;
                                        pnlSaleItemDrp5.Visible = false;
                                        txtSaleItem5.Text = strProdtit;
                                        lblSaleItem5.Text = "";
                                        lblSaleItem5.Text = AppConstants.unavailableSale;
                                    }


                                }
                                else
                                {
                                    pnlSaleItem5.Visible = false;
                                    pnlSaleItemDrp5.Visible = true;
                                    txtSaleItem5.Text = "";
                                    lblSaleItem5.Text = "";
                                    btnSaleItem5.Visible = false;


                                }
                                if (Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale6"]) != "")
                                {
                                    incnt = 0;
                                    strProdId = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale6"]);
                                    strProdtit = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle6"]);

                                    foreach (DataRow dtrow in dsSalesItemList.Tables[0].Rows)
                                    {
                                        if (Convert.ToString(dtrow["product_id"]) == strProdId && Convert.ToString(dtrow["product_title"]) == strProdtit)
                                        {
                                            incnt = 1;
                                        }
                                    }
                                    if (incnt == 1)
                                    {
                                        pnlSaleItem6.Visible = false;
                                        pnlSaleItemDrp6.Visible = true;
                                        drpSaleItem6.SelectedValue = strProdId;
                                        txtSaleItem6.Text = "";
                                        lblSaleItem6.Text = "";
                                    }
                                    else
                                    {
                                        pnlSaleItem6.Visible = true;
                                        pnlSaleItemDrp6.Visible = false;
                                        txtSaleItem6.Text = strProdtit;
                                        lblSaleItem6.Text = "";
                                        lblSaleItem6.Text = AppConstants.unavailableSale;
                                    }


                                }
                                else
                                {
                                    pnlSaleItem6.Visible = false;
                                    pnlSaleItemDrp6.Visible = true;
                                    txtSaleItem6.Text = "";
                                    lblSaleItem6.Text = "";
                                    btnSaleItem6.Visible = false;


                                }
                                if (Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale7"]) != "")
                                {
                                    incnt = 0;
                                    strProdId = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale7"]);
                                    strProdtit = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle7"]);

                                    foreach (DataRow dtrow in dsSalesItemList.Tables[0].Rows)
                                    {
                                        if (Convert.ToString(dtrow["product_id"]) == strProdId && Convert.ToString(dtrow["product_title"]) == strProdtit)
                                        {
                                            incnt = 1;
                                        }
                                    }
                                    if (incnt == 1)
                                    {
                                        pnlSaleItem7.Visible = false;
                                        pnlSaleItemDrp7.Visible = true;
                                        txtSaleItem7.Text = "";
                                        lblSaleItem7.Text = "";
                                        drpSaleItem7.SelectedValue = strProdId;

                                    }
                                    else
                                    {
                                        pnlSaleItem7.Visible = true;
                                        pnlSaleItemDrp7.Visible = false;
                                        txtSaleItem7.Text = strProdtit;
                                        lblSaleItem7.Text = "";
                                        lblSaleItem7.Text = AppConstants.unavailableSale;
                                    }


                                }
                                else
                                {
                                    pnlSaleItem7.Visible = false;
                                    pnlSaleItemDrp7.Visible = true;
                                    txtSaleItem7.Text = "";
                                    lblSaleItem7.Text = "";
                                    btnSaleItem7.Visible = false;


                                }
                                if (Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale8"]) != "")
                                {
                                    incnt = 0;
                                    strProdId = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSale8"]);
                                    strProdtit = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle8"]);

                                    foreach (DataRow dtrow in dsSalesItemList.Tables[0].Rows)
                                    {
                                        if (Convert.ToString(dtrow["product_id"]) == strProdId && Convert.ToString(dtrow["product_title"]) == strProdtit)
                                        {
                                            incnt = 1;
                                        }
                                    }
                                    if (incnt == 1)
                                    {
                                        pnlSaleItem8.Visible = false;
                                        pnlSaleItemDrp8.Visible = true;
                                        drpSaleItem8.SelectedValue = strProdId;
                                        txtSaleItem8.Text = "";
                                        lblSaleItem8.Text = "";
                                    }
                                    else
                                    {
                                        pnlSaleItem8.Visible = true;
                                        pnlSaleItemDrp8.Visible = false;
                                        txtSaleItem8.Text = strProdtit;
                                        lblSaleItem8.Text = "";
                                        lblSaleItem8.Text = AppConstants.unavailableSale;
                                    }


                                }
                                else
                                {
                                    pnlSaleItem8.Visible = false;
                                    pnlSaleItemDrp8.Visible = true;
                                    txtSaleItem8.Text = "";
                                    lblSaleItem8.Text = "";
                                    btnSaleItem8.Visible = false;


                                }

                            }
                            else
                            {
                                lblNoSalesItem.Text = "";
                                lblNoSalesItem.Text = AppConstants.NoProductavailableSale;
                                btnPreviewNewsletter.Visible = false;
                                pnlSaleItemDrp1.Visible = false;
                                pnlSaleItemDrp2.Visible = false;
                                pnlSaleItemDrp3.Visible = false;
                                pnlSaleItemDrp4.Visible = false;
                                pnlSaleItemDrp5.Visible = false;
                                pnlSaleItemDrp6.Visible = false;
                                pnlSaleItemDrp7.Visible = false;
                                pnlSaleItemDrp8.Visible = false;
                                btnSaleItem1.Visible = false;
                                btnSaleItem2.Visible = false;
                                btnSaleItem3.Visible = false;
                                btnSaleItem4.Visible = false;
                                btnSaleItem5.Visible = false;
                                btnSaleItem6.Visible = false;
                                btnSaleItem7.Visible = false;
                                btnSaleItem8.Visible = false;
                                txtSaleItem1.Text = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle1"]);
                                txtSaleItem2.Text = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle2"]);
                                txtSaleItem3.Text = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle3"]);
                                txtSaleItem4.Text = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle4"]);
                                txtSaleItem5.Text = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle5"]);
                                txtSaleItem6.Text = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle6"]);
                                txtSaleItem7.Text = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle7"]);
                                txtSaleItem8.Text = Convert.ToString(dsInfo.Tables[0].Rows[0]["ProductSaleTitle8"]);
                                lblSaleItem1.Text = "";
                                lblSaleItem1.Text = AppConstants.unavailableSale;
                                lblSaleItem2.Text = "";
                                lblSaleItem2.Text = AppConstants.unavailableSale;
                                lblSaleItem3.Text = "";
                                lblSaleItem3.Text = AppConstants.unavailableSale;
                                lblSaleItem4.Text = "";
                                lblSaleItem4.Text = AppConstants.unavailableSale;
                                lblSaleItem5.Text = "";
                                lblSaleItem5.Text = AppConstants.unavailableSale;
                                lblSaleItem6.Text = "";
                                lblSaleItem6.Text = AppConstants.unavailableSale;
                                lblSaleItem7.Text = "";
                                lblSaleItem7.Text = AppConstants.unavailableSale;
                                lblSaleItem8.Text = "";
                                lblSaleItem8.Text = AppConstants.unavailableSale;
                            }
                        }
                    }










                    Page.ClientScript.RegisterOnSubmitStatement(
                   FCKeditor1.GetType(),
                         "editor1",
                     "FCKeditorAPI.GetInstance('" + FCKeditor1.ClientID + "').UpdateLinkedField();");

                    Page.ClientScript.RegisterOnSubmitStatement(
                        FCKeditor2.GetType(),
                        "editor2",
                        "FCKeditorAPI.GetInstance('" + FCKeditor2.ClientID + "').UpdateLinkedField();");


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }


        public void BindSubject()
        {
            pnlSaleItemDrp1.Visible = true;
            pnlSaleItemDrp2.Visible = true;
            pnlSaleItemDrp3.Visible = true;
            pnlSaleItemDrp4.Visible = true;
            pnlSaleItemDrp5.Visible = true;
            pnlSaleItemDrp6.Visible = true;
            pnlSaleItemDrp7.Visible = true;
            pnlSaleItemDrp8.Visible = true;
            pnlSaleItem1.Visible = false;
            pnlSaleItem2.Visible = false;
            pnlSaleItem3.Visible = false;
            pnlSaleItem4.Visible = false;
            pnlSaleItem5.Visible = false;
            pnlSaleItem6.Visible = false;
            pnlSaleItem7.Visible = false;
            pnlSaleItem8.Visible = false;
            pnlSaleItem8.Visible = false;
            dropSales.bindSalesItemDropdown(drpSaleItem1);
            dropSales.bindSalesItemDropdown(drpSaleItem2);
            dropSales.bindSalesItemDropdown(drpSaleItem3);
            dropSales.bindSalesItemDropdown(drpSaleItem4);
            dropSales.bindSalesItemDropdown(drpSaleItem5);
            dropSales.bindSalesItemDropdown(drpSaleItem6);
            dropSales.bindSalesItemDropdown(drpSaleItem7);
            dropSales.bindSalesItemDropdown(drpSaleItem8);
            DataSet dsSubject = new DataSet();
            dsSubject = dbListInfo.SelectSubject();
            DataSet dsSales1 = new DataSet();
            if (dsSubject.Tables.Count > 0)
            {
                if (dsSubject != null && dsSubject.Tables.Count > 0 && dsSubject.Tables[0].Rows.Count > 0)
                {
                    txtFromDate.Text = Convert.ToString(dsSubject.Tables[0].Rows[0]["StarDate"]);
                    txtToDate.Text = Convert.ToString(dsSubject.Tables[0].Rows[0]["EndDate"]); ;
                    FCKeditor1.Value = Convert.ToString(dsSubject.Tables[0].Rows[0]["HeaderMsg"]);
                    FCKeditor2.Value = Convert.ToString(dsSubject.Tables[0].Rows[0]["FooterMsg"]);
                    txtSubject.Text = Convert.ToString(dsSubject.Tables[0].Rows[0]["Subject"]);
                    if (Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod1"]) != "")
                    {
                        drpSaleItem1.SelectedValue = Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod1"]);

                    }
                    if (Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod2"]) != "")
                    {
                        drpSaleItem2.SelectedValue = Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod2"]);

                    }
                    if (Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod3"]) != "")
                    {
                        drpSaleItem3.SelectedValue = Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod3"]);


                    }
                    if (Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod4"]) != "")
                    {
                        drpSaleItem4.SelectedValue = Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod4"]);

                    }
                    if (Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod5"]) != "")
                    {
                        drpSaleItem5.SelectedValue = Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod5"]);

                    }
                    if (Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod6"]) != "")
                    {
                        drpSaleItem6.SelectedValue = Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod6"]);

                    }
                    if (Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod7"]) != "")
                    {
                        drpSaleItem7.SelectedValue = Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod7"]);

                    }
                    if (Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod8"]) != "")
                    {
                        drpSaleItem8.SelectedValue = Convert.ToString(dsSubject.Tables[0].Rows[0]["Prod8"]);

                    }

                }
            }
        }


        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
                if (name == "Newsletter (sales)")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbListInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.Editnewslettersales;

                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        protected void btnSaleItem1_Click(object sender, EventArgs e)
        {
            txtSaleItem1.Text = "";
            lblSaleItem1.Text = "";
            btnSaleItem1.Visible = false;
            pnlSaleItem1.Visible = false;
            pnlSaleItemDrp1.Visible = true;
        }
        protected void btnSaleItem2_Click(object sender, EventArgs e)
        {
            txtSaleItem2.Text = "";
            lblSaleItem2.Text = "";
            btnSaleItem2.Visible = false;
            pnlSaleItem2.Visible = false;
            pnlSaleItemDrp2.Visible = true;

        }
        protected void btnSaleItem3_Click(object sender, EventArgs e)
        {
            txtSaleItem3.Text = "";
            lblSaleItem3.Text = "";
            btnSaleItem3.Visible = false;
            pnlSaleItem3.Visible = false;
            pnlSaleItemDrp3.Visible = true;

        }
        protected void btnSaleItem4_Click(object sender, EventArgs e)
        {
            txtSaleItem4.Text = "";
            lblSaleItem4.Text = "";
            btnSaleItem4.Visible = false;
            pnlSaleItem4.Visible = false;
            pnlSaleItemDrp4.Visible = true;

        }
        protected void btnSaleItem5_Click(object sender, EventArgs e)
        {
            txtSaleItem5.Text = "";
            lblSaleItem5.Text = "";
            btnSaleItem5.Visible = false;
            pnlSaleItem5.Visible = false;
            pnlSaleItemDrp5.Visible = true;

        }
        protected void btnSaleItem6_Click(object sender, EventArgs e)
        {
            txtSaleItem6.Text = "";
            lblSaleItem6.Text = "";
            btnSaleItem6.Visible = false;
            pnlSaleItem6.Visible = false;
            pnlSaleItemDrp6.Visible = true;


        }
        protected void btnSaleItem7_Click(object sender, EventArgs e)
        {
            txtSaleItem7.Text = "";
            lblSaleItem7.Text = "";
            btnSaleItem7.Visible = false;
            pnlSaleItem7.Visible = false;
            pnlSaleItemDrp7.Visible = true;


        }
        protected void btnSaleItem8_Click(object sender, EventArgs e)
        {
            txtSaleItem8.Text = "";
            lblSaleItem8.Text = "";
            btnSaleItem8.Visible = false;
            pnlSaleItem8.Visible = false;
            pnlSaleItemDrp8.Visible = true;


        }

        protected void btnPreviewNewsletter_Click(object sender, EventArgs e)
        {
            int intEmailId = 0;
            intEmailId = Convert.ToInt32(Request.QueryString["EmailSendId"]);
            int intlocId = 0;
            intlocId = Convert.ToInt32(Request.QueryString["intlocId"]);
            string strHeader = string.Empty;
            int intPreview = 0;
            string strFooter = string.Empty;
            string strStartDate = string.Empty;
            string strToDate = string.Empty;
            string strProd1 = string.Empty;
            string strProd2 = string.Empty;
            string strProd3 = string.Empty;
            string strProd4 = string.Empty;
            string strProd5 = string.Empty;
            string strProd6 = string.Empty;
            string strProd7 = string.Empty;
            string strProd8 = string.Empty;


            strStartDate = txtFromDate.Text;
            strToDate = txtToDate.Text;

            int intDate = CheckDate();
            if (intDate == 0)
            {

                strHeader = FCKeditor1.Value;
                strFooter = FCKeditor2.Value;
                DataSet dsPreview = new DataSet();
                dsPreview = dbListInfo.GetPreviewDetails(intlocId);
                if (txtSaleItem1.Text == "")
                {
                    if (drpSaleItem1.SelectedValue != "Select")
                    {
                        strProd1 = drpSaleItem1.SelectedValue;
                    }


                }
                if (txtSaleItem2.Text == "")
                {
                    if (drpSaleItem2.SelectedValue != "Select")
                    {
                        strProd2 = drpSaleItem2.SelectedValue;
                    }


                }
                if (txtSaleItem3.Text == "")
                {
                    if (drpSaleItem3.SelectedValue != "Select")
                    {
                        strProd3 = drpSaleItem3.SelectedValue;
                    }


                }
                if (txtSaleItem4.Text == "")
                {
                    if (drpSaleItem4.SelectedValue != "Select")
                    {
                        strProd4 = drpSaleItem4.SelectedValue;
                    }


                }
                if (txtSaleItem5.Text == "")
                {
                    if (drpSaleItem5.SelectedValue != "Select")
                    {
                        strProd5 = drpSaleItem5.SelectedValue;
                    }


                }
                if (txtSaleItem6.Text == "")
                {
                    if (drpSaleItem6.SelectedValue != "Select")
                    {
                        strProd6 = drpSaleItem5.SelectedValue;
                    }


                }
                if (txtSaleItem7.Text == "")
                {
                    if (drpSaleItem7.SelectedValue != "Select")
                    {
                        strProd7 = drpSaleItem7.SelectedValue;
                    }


                }
                if (txtSaleItem8.Text == "")
                {
                    if (drpSaleItem8.SelectedValue != "Select")
                    {
                        strProd8 = drpSaleItem8.SelectedValue;
                    }


                }


                if (dsPreview.Tables.Count > 0)
                {
                    if (dsPreview != null && dsPreview.Tables.Count > 0 && dsPreview.Tables[0].Rows.Count > 0)
                    {
                        int intPreviewId = Convert.ToInt32(AppConstants.intPreview);
                        intPreview = dbListInfo.UpdatePreviewInfo(txtSubject.Text, strStartDate, strToDate, strHeader, strFooter, intlocId, intPreviewId, strProd1, strProd2, strProd3, strProd4, strProd5, strProd6, strProd7, strProd8);
                        Response.Redirect("NewsPreview.aspx?EmailSendId=" + intEmailId);


                    }
                    else
                    {
                        intPreview = dbListInfo.InsertPreviewInfo(txtSubject.Text, strStartDate, strToDate, strHeader, strFooter, intlocId, intlocId, strProd1, strProd2, strProd3, strProd4, strProd5, strProd6, strProd7, strProd8);
                        Response.Redirect("NewsPreview.aspx?EmailSendId=" + intEmailId);
                    }
                }
                else
                {
                    intPreview = dbListInfo.InsertPreviewInfo(txtSubject.Text, strStartDate, strToDate, strHeader, strFooter, intlocId, intlocId, strProd1, strProd2, strProd3, strProd4, strProd5, strProd6, strProd7, strProd8);
                    Response.Redirect("NewsPreview.aspx?EmailSendId=" + intEmailId);

                }




            }
            else
            {

            }


        }

        public int CheckDate()
        {
            int returnDate = 0;
            int returnDate1 = 0;

            DataValidator dataValidator = new DataValidator();
            returnDate = DataValidator.checkDateEntered(txtFromDate.Text);
            returnDate1 = DataValidator.checkDateEntered(txtToDate.Text);
            if (returnDate == 1 || returnDate1 == 1)
            {
                if (returnDate == 1 && returnDate1 == 1)
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.invalidSEDate;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    returnDate = 1;
                }
                else if (returnDate == 1)
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.invalidSDate;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    returnDate = 1;

                }
                else if (returnDate1 == 1)
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.invalidEDate;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    returnDate = 1;

                }

            }
            else
            {




                returnDate = DataValidator.IsValidDateGreaterToday(txtFromDate.Text);
                if (returnDate == 0)
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.invalidNewsStartDate;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    returnDate = 1;

                }
                else
                {
                    returnDate = DataValidator.IsValidNewsLetterDate(txtFromDate.Text, txtToDate.Text);
                    if (returnDate == 2)
                    {

                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.invalidNewsEndDate;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        returnDate = 2;

                    }
                    else
                    {
                        lblMsg.Text = "";
                        returnDate = 0;


                    }

                }
            }

            return returnDate;

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewAllNewsSaleDetails.aspx", false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ViewAllNewsSaleDetails.aspx", false);

        }
    }
}

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
    public partial class NewsPreview1 : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        string infoEmailAddress = "";
        string allUsersName = "";
        string allUsersEmailAddress = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["adminId"] == null || Convert.ToString(Request.Cookies["adminId"]) == "")
            {
                Response.Redirect("index.aspx", false);
            }
            else
            {
                changeLinks();
                getCompanyName();
                if (!IsPostBack)
                {
                    string strAllSales = string.Empty;

                    strAllSales = Convert.ToString(ViewState["strLongUrl"]) + "/sales.aspx";
                    //strAllSales = "#";
                    string strCustomerEmail = string.Empty;
                    strCustomerEmail = "mailto:" + Convert.ToString(ViewState["strCustomerServiceEmail"]);
                    litViewAllSaleItems.Text = "<a href='" + strAllSales + "' class='Logoutlink'>View All Sale Items</a>";
                    litcustomerservice.Text = "<a href='" + strCustomerEmail + "'>" + Convert.ToString(ViewState["strCustomerServiceEmail"]) + "</a>";

                    BindSubject();
                    BindGridProduct();
                    BindGridFeaturedProduct();


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
            string strCustomerServiceEmail = string.Empty;
            string strLongUrl = string.Empty;
            dsGetCompanyName = dbGetCompanyName.getShortCompanyName();

            if (dsGetCompanyName.Tables.Count > 0)
            {
                if (dsGetCompanyName != null && dsGetCompanyName.Tables.Count > 0 && dsGetCompanyName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetCompanyName.Tables[0].Rows)
                    {
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.Newslettersales;
                        strCustomerServiceEmail = Convert.ToString(dtrow["CustomerServiceEmail"]);
                        ViewState["strCustomerServiceEmail"] = strCustomerServiceEmail;
                        strLongUrl = Convert.ToString(dtrow["LongURL"]);
                        ViewState["strLongUrl"] = strLongUrl;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void BindSubject()
        {
            DataSet dsSubject = new DataSet();
            dsSubject = dbListInfo.SelectSubject();
            if (dsSubject.Tables.Count > 0)
            {
                if (dsSubject != null && dsSubject.Tables.Count > 0 && dsSubject.Tables[0].Rows.Count > 0)
                {
                    string strDate = Convert.ToString(dsSubject.Tables[0].Rows[0]["StarDate"]) + " to " + Convert.ToString(dsSubject.Tables[0].Rows[0]["EndDate"]);
                    ViewState["StarDateNew"] = Convert.ToString(dsSubject.Tables[0].Rows[0]["StarDate"]);
                    ViewState["EndDateNew"] = Convert.ToString(dsSubject.Tables[0].Rows[0]["EndDate"]);
                    lblWeekDate.Text = strDate;
                    lblEmailHeader.Text = Convert.ToString(dsSubject.Tables[0].Rows[0]["HeaderMsg"]);
                    lblFooterText.Text = Convert.ToString(dsSubject.Tables[0].Rows[0]["FooterMsg"]);
                    ViewState["EmailSubject"] = Convert.ToString(dsSubject.Tables[0].Rows[0]["Subject"]);

                }
            }
        }


        public void BindGridProduct()
        {
            DataSet dsSales1 = new DataSet();
            string strView = string.Empty;
            string strViewLink = string.Empty;
            string strImgName = string.Empty;
            DataSet dsItemList = new DataSet();
            dsItemList = dbListInfo.SelectSubject();
            if (dsItemList.Tables.Count > 0)
            {
                if (dsItemList != null && dsItemList.Tables.Count > 0 && dsItemList.Tables[0].Rows.Count > 0)
                {


                    strViewLink = Convert.ToString(ViewState["strLongUrl"]) + "/products.aspx?shelf=";
                    // strView = "#";
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["Prod1"]) != "")
                    {


                        dsSales1 = dbListInfo.SelectSendEmailProductInformation(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["Prod1"]), Convert.ToInt32(AppConstants.locationId));
                        //for product 1
                        pnlProd1.Visible = true;
                        lblPnl1.Visible = false;

                        strView = strViewLink + Convert.ToString(dsSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSales1.Tables[0].Rows[0]["aisle_id"]);
                        if (Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]) == "")
                        {
                            lblProdImageNm1.Text = "no_image.gif";
                            imgProd1.ImageUrl = Thumbnail("no_image.gif");

                        }
                        else
                        {

                            strImgName = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]);
                            lblProdImageNm1.Text = strImgName;
                            imgProd1.ImageUrl = Thumbnail(strImgName);
                        }
                        lblProductId1.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_id"]);
                        lblProdTitle1.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_title"]);
                        //lblProdPrice1.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                        lblProdPrice1.Text = "$" + Convert.ToDecimal(dsSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        litProdView1.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["Prod2"]) != "")
                    {

                        dsSales1 = dbListInfo.SelectSendEmailProductInformation(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["Prod2"]), Convert.ToInt32(AppConstants.locationId));

                        //  for product 2
                        pnlProd2.Visible = true;
                        lblPnl2.Visible = false;
                        strView = strViewLink + Convert.ToString(dsSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSales1.Tables[0].Rows[0]["aisle_id"]);
                        if (Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]) == "")
                        {
                            lblProdImageNm2.Text = "no_image.gif";
                            imgProd2.ImageUrl = Thumbnail("no_image.gif");

                        }
                        else
                        {
                            strImgName = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]);
                            lblProdImageNm2.Text = strImgName;
                            imgProd2.ImageUrl = Thumbnail(strImgName);
                        }
                        lblProductId2.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_id"]);
                        lblProdTitle2.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_title"]);
                        //lblProdPrice2.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                        lblProdPrice2.Text = "$" + Convert.ToDecimal(dsSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        litProdView2.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["Prod3"]) != "")
                    {

                        dsSales1 = dbListInfo.SelectSendEmailProductInformation(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["Prod3"]), Convert.ToInt32(AppConstants.locationId));
                        // for product 3
                        pnlProd3.Visible = true;
                        lblPnl3.Visible = false;
                        strView = strViewLink + Convert.ToString(dsSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSales1.Tables[0].Rows[0]["aisle_id"]);
                        if (Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]) == "")
                        {
                            imgProd3.ImageUrl = Thumbnail("no_image.gif");
                            lblProdImageNm3.Text = "no_image.gif";
                        }
                        else
                        {
                            strImgName = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]);
                            lblProdImageNm3.Text = strImgName;
                            imgProd3.ImageUrl = Thumbnail(strImgName);
                        }
                        lblProductId3.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_id"]);
                        lblProdTitle3.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_title"]);
                        //lblProdPrice3.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                        lblProdPrice2.Text = "$" + Convert.ToDecimal(dsSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        lblProdPrice2.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["Prod4"]) != "")
                    {
                        dsSales1 = dbListInfo.SelectSendEmailProductInformation(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["Prod4"]), Convert.ToInt32(AppConstants.locationId));
                        //for product 4
                        pnlProd4.Visible = true;
                        lblPnl4.Visible = false;
                        strView = strViewLink + Convert.ToString(dsSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSales1.Tables[0].Rows[0]["aisle_id"]);
                        if (Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]) == "")
                        {
                            imgProd4.ImageUrl = Thumbnail("no_image.gif");
                            lblProdImageNm4.Text = "no_image.gif";
                        }
                        else
                        {
                            strImgName = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]);
                            lblProdImageNm4.Text = strImgName;
                            imgProd4.ImageUrl = Thumbnail(strImgName);
                        }
                        lblProductId4.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_id"]);
                        lblProdTitle4.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_title"]);
                        //lblProdPrice4.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                        lblProdPrice4.Text = "$" + Convert.ToDecimal(dsSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        litProdView4.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["Prod5"]) != "")
                    {
                        dsSales1 = dbListInfo.SelectSendEmailProductInformation(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["Prod5"]), Convert.ToInt32(AppConstants.locationId));
                        // for product 5
                        pnlProd5.Visible = true;
                        lblPnl5.Visible = false;
                        strView = strViewLink + Convert.ToString(dsSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSales1.Tables[0].Rows[0]["aisle_id"]);
                        if (Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]) == "")
                        {
                            lblProdImageNm5.Text = "no_image.gif";
                            imgProd5.ImageUrl = Thumbnail("no_image.gif");

                        }
                        else
                        {
                            strImgName = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]);
                            lblProdImageNm5.Text = strImgName;
                            imgProd5.ImageUrl = Thumbnail(strImgName);
                        }
                        lblProductId5.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_id"]);
                        lblProdTitle5.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_title"]);
                        // lblProdPrice5.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                        lblProdPrice5.Text = "$" + Convert.ToDecimal(dsSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        litProdView5.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["Prod6"]) != "")
                    {
                        dsSales1 = dbListInfo.SelectSendEmailProductInformation(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["Prod6"]), Convert.ToInt32(AppConstants.locationId));
                        //for product 6
                        pnlProd6.Visible = true;
                        lblPnl6.Visible = false;
                        strView = strViewLink + Convert.ToString(dsSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSales1.Tables[0].Rows[0]["aisle_id"]);
                        if (Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]) == "")
                        {
                            lblProdImageNm6.Text = "no_image.gif";
                            imgProd6.ImageUrl = Thumbnail("no_image.gif");

                        }
                        else
                        {
                            strImgName = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]);
                            lblProdImageNm6.Text = strImgName;
                            imgProd6.ImageUrl = Thumbnail(strImgName);
                        }
                        lblProductId6.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_id"]);
                        lblProdTitle6.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_title"]);
                        //lblProdPrice6.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                        lblProdPrice6.Text = "$" + Convert.ToDecimal(dsSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        litProdView6.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["Prod7"]) != "")
                    {
                        dsSales1 = dbListInfo.SelectSendEmailProductInformation(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["Prod7"]), Convert.ToInt32(AppConstants.locationId));
                        //for product 7
                        pnlProd7.Visible = true;
                        lblPnl7.Visible = false;
                        strView = strViewLink + Convert.ToString(dsSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSales1.Tables[0].Rows[0]["aisle_id"]);
                        if (Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]) == "")
                        {
                            lblProdImageNm7.Text = "no_image.gif";
                            imgProd7.ImageUrl = Thumbnail("no_image.gif");

                        }
                        else
                        {
                            strImgName = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]);
                            lblProdImageNm7.Text = strImgName;
                            imgProd7.ImageUrl = Thumbnail(strImgName);
                        }
                        lblProductId7.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_id"]);
                        lblProdTitle7.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_title"]);
                        //lblProdPrice7.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                        lblProdPrice7.Text = "$" + Convert.ToDecimal(dsSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        litProdView7.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["Prod8"]) != "")
                    {
                        dsSales1 = dbListInfo.SelectSendEmailProductInformation(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["Prod8"]), Convert.ToInt32(AppConstants.locationId));
                        //for product 8
                        pnlProd8.Visible = true;
                        lblPnl8.Visible = false;
                        strView = strViewLink + Convert.ToString(dsSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSales1.Tables[0].Rows[0]["aisle_id"]);
                        if (Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]) == "")
                        {
                            lblProdImageNm8.Text = "no_image.gif";
                            imgProd8.ImageUrl = Thumbnail("no_image.gif");

                        }
                        else
                        {
                            strImgName = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_image"]);
                            lblProdImageNm8.Text = strImgName;
                            imgProd8.ImageUrl = Thumbnail(strImgName);
                        }
                        lblProductId8.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_id"]);
                        lblProdTitle8.Text = Convert.ToString(dsSales1.Tables[0].Rows[0]["product_title"]);
                        //lblProdPrice8.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                        lblProdPrice8.Text = "$" + Convert.ToDecimal(dsSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        litProdView8.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                    }
                }


                else
                {
                    pnlProduct.Visible = false;
                }

            }
            else
            {
                pnlProduct.Visible = false;
            }

        }


        public string Thumbnail(string imgName)
        {
            string urlThumbnail = string.Empty;
            if (imgName != "")
            {

                urlThumbnail = "thumbnailmainimage.aspx?imgName=" + imgName;

            }
            return urlThumbnail;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            int intReturn = sendTextNewsletterMail();
            if (intReturn == 1)
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.strNewsSuccess;
                lblMsg.ForeColor = System.Drawing.Color.Black;

            }
        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            int intEmailId = 0;
            intEmailId = Convert.ToInt32(Request.QueryString["EmailSendId"]);
            Response.Redirect("EditNewsletterSale.aspx?Check=1&EmailSendId=" + intEmailId, false);
        }


        public void BindGridFeaturedProduct()
        {

            int cntProduct = 0;
            string strView = string.Empty;
            string strViewLink = string.Empty;
            string strImgName = string.Empty;
            DataSet dsSalesItemList = new DataSet();
            dsSalesItemList = dbListInfo.GetFeatureSalesDetails(Convert.ToInt32(AppConstants.locationId));
            if (dsSalesItemList.Tables.Count > 0)
            {
                if (dsSalesItemList != null && dsSalesItemList.Tables.Count > 0 && dsSalesItemList.Tables[0].Rows.Count > 0)
                {
                    cntProduct = dsSalesItemList.Tables[0].Rows.Count;
                    strViewLink = Convert.ToString(ViewState["strLongUrl"]) + "/products.aspx?shelf=";
                    //strView = "#";
                    for (cntProduct = 0; cntProduct < dsSalesItemList.Tables[0].Rows.Count; cntProduct++)
                    {
                        if (cntProduct == 0)
                        {
                            //for product 1
                            pnlFeat1.Visible = true;
                            //lblFeat1.Visible = false;

                            strView = strViewLink + Convert.ToString(dsSalesItemList.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSalesItemList.Tables[0].Rows[0]["aisle_id"]);
                            if (Convert.ToString(dsSalesItemList.Tables[0].Rows[0]["product_image"]) == "")
                            {
                                lblFeatImageNm1.Text = "no_image.gif";
                                imgFeat1.ImageUrl = Thumbnail("no_image.gif");

                            }
                            else
                            {
                                strImgName = Convert.ToString(dsSalesItemList.Tables[0].Rows[0]["product_image"]);
                                lblFeatImageNm1.Text = strImgName;
                                imgFeat1.ImageUrl = Thumbnail(strImgName);
                            }
                            lblFeatProductId1.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[0]["product_id"]);
                            lblFeatTitle1.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[0]["product_title"]);
                            //lblFeatPrice1.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSalesItemList.Tables[0].Rows[0]["productlink_price"]), 2));
                            lblFeatPrice1.Text = "$" + Convert.ToDecimal(dsSalesItemList.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            litFeatView1.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        }
                        else if (cntProduct == 1)
                        {


                            //  for product 2
                            pnlFeat2.Visible = true;
                            // lblFeat2.Visible = false;
                            strView = strViewLink + Convert.ToString(dsSalesItemList.Tables[0].Rows[1]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSalesItemList.Tables[0].Rows[1]["aisle_id"]);
                            if (Convert.ToString(dsSalesItemList.Tables[0].Rows[1]["product_image"]) == "")
                            {
                                lblFeatImageNm2.Text = "no_image.gif";
                                imgFeat2.ImageUrl = Thumbnail("no_image.gif");

                            }
                            else
                            {
                                strImgName = Convert.ToString(dsSalesItemList.Tables[0].Rows[1]["product_image"]);
                                lblFeatImageNm2.Text = strImgName;
                                imgFeat2.ImageUrl = Thumbnail(strImgName);
                            }
                            lblFeatProductId2.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[1]["product_id"]);
                            lblFeatTitle2.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[1]["product_title"]);
                            //lblFeatPrice2.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSalesItemList.Tables[0].Rows[1]["productlink_price"]), 2));
                            lblFeatPrice2.Text = "$" + Convert.ToDecimal(dsSalesItemList.Tables[0].Rows[1]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            litFeatView2.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        }
                        else if (cntProduct == 2)
                        {

                            // for product 3
                            pnlFeat3.Visible = true;
                            // lblFeat3.Visible = false;
                            strView = strViewLink + Convert.ToString(dsSalesItemList.Tables[0].Rows[2]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSalesItemList.Tables[0].Rows[2]["aisle_id"]);
                            if (Convert.ToString(dsSalesItemList.Tables[0].Rows[2]["product_image"]) == "")
                            {
                                lblFeatImageNm3.Text = "no_image.gif";
                                imgFeat3.ImageUrl = Thumbnail("no_image.gif");

                            }
                            else
                            {
                                strImgName = Convert.ToString(dsSalesItemList.Tables[0].Rows[2]["product_image"]);
                                lblFeatImageNm3.Text = strImgName;
                                imgFeat3.ImageUrl = Thumbnail(strImgName);
                            }
                            lblFeatProductId3.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[2]["product_id"]);
                            lblFeatTitle3.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[2]["product_title"]);
                            //lblFeatPrice3.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSalesItemList.Tables[0].Rows[2]["productlink_price"]), 2));
                            lblFeatPrice3.Text = "$" + Convert.ToDecimal(dsSalesItemList.Tables[0].Rows[2]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            litFeatView3.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        }
                        else if (cntProduct == 3)
                        {
                            //for product 4
                            pnlFeat4.Visible = true;
                            //lblFeat4.Visible = false;
                            strView = strViewLink + Convert.ToString(dsSalesItemList.Tables[0].Rows[3]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSalesItemList.Tables[0].Rows[3]["aisle_id"]);
                            if (Convert.ToString(dsSalesItemList.Tables[0].Rows[3]["product_image"]) == "")
                            {
                                lblFeatImageNm4.Text = "no_image.gif";
                                imgFeat4.ImageUrl = Thumbnail("no_image.gif");

                            }
                            else
                            {
                                strImgName = Convert.ToString(dsSalesItemList.Tables[0].Rows[3]["product_image"]);
                                lblFeatImageNm4.Text = strImgName;
                                imgFeat4.ImageUrl = Thumbnail(strImgName);
                            }
                            lblFeatProductId4.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[3]["product_id"]);
                            lblFeatTitle4.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[3]["product_title"]);
                            //lblFeatPrice4.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSalesItemList.Tables[0].Rows[3]["productlink_price"]), 2));
                            lblFeatPrice4.Text = "$" + Convert.ToDecimal(dsSalesItemList.Tables[0].Rows[3]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            litFeatView4.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        }
                        else if (cntProduct == 4)
                        {
                            // for product 5
                            pnlFeat5.Visible = true;
                            // lblFeat5.Visible = false;
                            strView = strViewLink + Convert.ToString(dsSalesItemList.Tables[0].Rows[4]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSalesItemList.Tables[0].Rows[4]["aisle_id"]);
                            if (Convert.ToString(dsSalesItemList.Tables[0].Rows[4]["product_image"]) == "")
                            {
                                lblFeatImageNm5.Text = "no_image.gif";
                                imgFeat5.ImageUrl = Thumbnail("no_image.gif");

                            }
                            else
                            {
                                strImgName = Convert.ToString(dsSalesItemList.Tables[0].Rows[4]["product_image"]);
                                lblFeatImageNm5.Text = strImgName;
                                imgFeat5.ImageUrl = Thumbnail(strImgName);
                            }
                            lblFeatProductId5.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[4]["product_id"]);
                            lblFeatTitle5.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[4]["product_title"]);
                            //lblFeatPrice4.Text = "$" + Convert.ToDecimal(dsSalesItemList.Tables[0].Rows[3]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            lblFeatPrice4.Text = "$" + Convert.ToDecimal(dsSalesItemList.Tables[0].Rows[4]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            litFeatView5.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        }
                        else if (cntProduct == 5)
                        {
                            //for product 6
                            pnlFeat6.Visible = true;
                            // lblFeat6.Visible = false;
                            strView = strViewLink + Convert.ToString(dsSalesItemList.Tables[0].Rows[5]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSalesItemList.Tables[0].Rows[5]["aisle_id"]);
                            if (Convert.ToString(dsSalesItemList.Tables[0].Rows[5]["product_image"]) == "")
                            {
                                lblFeatImageNm6.Text = "no_image.gif";
                                imgFeat6.ImageUrl = Thumbnail("no_image.gif");

                            }
                            else
                            {
                                strImgName = Convert.ToString(dsSalesItemList.Tables[0].Rows[5]["product_image"]);
                                lblFeatImageNm6.Text = strImgName;
                                imgFeat6.ImageUrl = Thumbnail(strImgName);
                            }
                            lblFeatProductId6.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[5]["product_id"]);
                            lblFeatTitle6.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[5]["product_title"]);
                            //lblFeatPrice6.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSalesItemList.Tables[0].Rows[5]["productlink_price"]), 2));
                            lblFeatPrice6.Text = "$" + Convert.ToDecimal(dsSalesItemList.Tables[0].Rows[5]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            litFeatView6.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        }
                        else if (cntProduct == 6)
                        {
                            //for product 7
                            pnlFeat7.Visible = true;
                            //  lblFeat7.Visible = false;
                            strView = strViewLink + Convert.ToString(dsSalesItemList.Tables[0].Rows[6]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSalesItemList.Tables[0].Rows[6]["aisle_id"]);
                            if (Convert.ToString(dsSalesItemList.Tables[0].Rows[6]["product_image"]) == "")
                            {
                                lblFeatImageNm7.Text = "no_image.gif";
                                imgFeat7.ImageUrl = Thumbnail("no_image.gif");

                            }
                            else
                            {
                                strImgName = Convert.ToString(dsSalesItemList.Tables[0].Rows[6]["product_image"]);
                                lblFeatImageNm7.Text = strImgName;
                                imgProd7.ImageUrl = Thumbnail(strImgName);
                            }
                            lblFeatProductId7.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[6]["product_id"]);
                            lblFeatTitle7.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[6]["product_title"]);
                            //lblFeatPrice7.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSalesItemList.Tables[0].Rows[6]["productlink_price"]), 2));
                            lblFeatPrice7.Text = "$" + Convert.ToDecimal(dsSalesItemList.Tables[0].Rows[6]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            litFeatView7.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        }
                        else if (cntProduct == 7)
                        {
                            //for product 8
                            pnlFeat8.Visible = true;
                            // lblFeat8.Visible = false;
                            strView = strViewLink + Convert.ToString(dsSalesItemList.Tables[0].Rows[7]["shelf_id"]) + "&aisle=" + Convert.ToString(dsSalesItemList.Tables[0].Rows[7]["aisle_id"]);
                            if (Convert.ToString(dsSalesItemList.Tables[0].Rows[7]["product_image"]) == "")
                            {
                                lblFeatImageNm8.Text = "no_image.gif";
                                imgFeat8.ImageUrl = Thumbnail("no_image.gif");

                            }
                            else
                            {
                                strImgName = Convert.ToString(dsSalesItemList.Tables[0].Rows[7]["product_image"]);
                                lblFeatImageNm8.Text = strImgName;
                                imgProd8.ImageUrl = Thumbnail(strImgName);
                            }
                            lblFeatProductId8.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[7]["product_id"]);
                            lblFeatTitle8.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[7]["product_title"]);
                            //lblFeatPrice8.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSalesItemList.Tables[0].Rows[7]["productlink_price"]), 2));
                            lblFeatPrice8.Text = "$" + Convert.ToDecimal(dsSalesItemList.Tables[0].Rows[7]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            litFeatView8.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                        }
                    }

                }
                else
                {
                    pnlFeatured.Visible = false;
                }

            }
            else
            {
                pnlFeatured.Visible = false;
            }

        }



        //Funcation for getting Info Email from database(Constant).
        public void getInfoEmailAddress()
        {
            int constantId = 1;

            DataSet dsGetInfoEmailAddress = new DataSet();
            dbListInfo.dispose();
            dsGetInfoEmailAddress = dbListInfo.GetInfoEmmailAddressConstant(constantId);

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
            dbListInfo.dispose();
            dsGetAllUsersEmailAddress = dbListInfo.GetUsersEmailAddress(intUsersStatusId, intUsersNewsletter);

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

            string strSubject = Convert.ToString(ViewState["EmailSubject"]);

            try
            {
                string strEmailContent = string.Empty;
                if (strAllUserEmails.Length - 1 > 0)
                {
                    for (int email = 0; email < strAllUserEmails.Length - 1; email++)
                    {
                        MailMessage emailFromAdmin = new MailMessage(strFromEmail, strAllUserEmails[email]);

                        //Fetch file name from AppConstants class file
                        string strFileName = AppConstants.strNewsletterSalesTextFile;

                        //object created for NameValueCollection
                        NameValueCollection emailVariable = new NameValueCollection();
                        // string strHeader = Server.MapPath("../images/newsletter_header.gif");
                        string strHeader = "https://www.CyberValetGrocery.com/images/newsletter_header.gif";
                        emailVariable["$HeaderImage$"] = "<img src='" + strHeader + "' height='95' border='0'/>";
                        emailVariable["$lblWeekDate$"] = lblWeekDate.Text;
                        emailVariable["$lblEmailHeader$"] = lblEmailHeader.Text;
                        emailVariable["$lblFooterText$"] = lblFooterText.Text;
                        emailVariable["$litcustomerservice$"] = litcustomerservice.Text;
                        emailVariable["$litViewAllSaleItems$"] = litViewAllSaleItems.Text;
                        // string strImgProd = Server.MapPath("../Product/");
                        string strImgProd = "https://www.CyberValetGrocery.com/Product/";
                        string strImg = string.Empty;
                        //sales Product

                        //Prod1
                        if (lblProdTitle1.Text == "")
                        {
                            emailVariable["$imgProd1$"] = "";
                        }
                        else
                        {
                            strImg = strImgProd + lblProdImageNm1.Text;
                            emailVariable["$imgProd1$"] = "<img src='" + strImg + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblProdTitle1$"] = lblProdTitle1.Text;
                        emailVariable["$litProdView1$"] = litProdView1.Text;
                        emailVariable["$lblProdPrice1$"] = lblProdPrice1.Text;
                        //emailVariable["$lblProdPrice1$"] = Convert.ToDecimal(lblProdPrice1.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);


                        //Prod2
                        if (lblProdTitle2.Text == "")
                        {
                            emailVariable["$imgProd2$"] = "";
                        }
                        else
                        {
                            strImg = strImgProd + lblProdImageNm2.Text;
                            emailVariable["$imgProd2$"] = "<img src='" + strImg + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblProdTitle2$"] = lblProdTitle2.Text;
                        emailVariable["$litProdView2$"] = litProdView2.Text;
                        emailVariable["$lblProdPrice2$"] = lblProdPrice2.Text;
                        //emailVariable["$lblProdPrice2$"] = Convert.ToDecimal(lblProdPrice2.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);


                        //Prod3
                        if (lblProdTitle3.Text == "")
                        {
                            emailVariable["$imgProd3$"] = "";
                        }
                        else
                        {
                            strImg = strImgProd + lblProdImageNm3.Text;
                            emailVariable["$imgProd3$"] = "<img src='" + strImg + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblProdTitle3$"] = lblProdTitle3.Text;
                        emailVariable["$litProdView3$"] = litProdView3.Text;
                        emailVariable["$lblProdPrice3$"] = lblProdPrice3.Text;
                        // emailVariable["$lblProdPrice3$"] = Convert.ToDecimal(lblProdPrice3.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        //Prod4
                        if (lblProdTitle4.Text == "")
                        {
                            emailVariable["$imgProd4$"] = "";
                        }
                        else
                        {
                            strImg = strImgProd + lblProdImageNm4.Text;
                            emailVariable["$imgProd4$"] = "<img src='" + strImg + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblProdTitle4$"] = lblProdTitle4.Text;
                        emailVariable["$litProdView4$"] = litProdView4.Text;
                        emailVariable["$lblProdPrice4$"] = lblProdPrice4.Text;
                        //emailVariable["$lblProdPrice4$"] = Convert.ToDecimal(lblProdPrice4.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        //Prod5
                        if (lblProdTitle5.Text == "")
                        {
                            emailVariable["$imgProd5$"] = "";
                        }
                        else
                        {
                            strImg = strImgProd + lblProdImageNm5.Text;
                            emailVariable["$imgProd5$"] = "<img src='" + strImg + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblProdTitle5$"] = lblProdTitle5.Text;
                        emailVariable["$litProdView5$"] = litProdView5.Text;
                        emailVariable["$lblProdPrice5$"] = lblProdPrice5.Text;
                        // emailVariable["$lblProdPrice5$"] = Convert.ToDecimal(lblProdPrice5.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);



                        //Prod6
                        if (lblProdTitle6.Text == "")
                        {
                            emailVariable["$imgProd6$"] = "";
                        }
                        else
                        {
                            strImg = strImgProd + lblProdImageNm6.Text;
                            emailVariable["$imgProd6$"] = "<img src='" + strImg + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblProdTitle6$"] = lblProdTitle6.Text;
                        emailVariable["$litProdView6$"] = litProdView6.Text;
                        emailVariable["$lblProdPrice6$"] = lblProdPrice6.Text;
                        //emailVariable["$lblProdPrice6$"] = Convert.ToDecimal(lblProdPrice6.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);


                        //Prod7
                        if (lblProdTitle7.Text == "")
                        {
                            emailVariable["$imgProd7$"] = "";
                        }
                        else
                        {
                            strImg = strImgProd + lblProdImageNm7.Text;
                            emailVariable["$imgProd7$"] = "<img src='" + strImg + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblProdTitle7$"] = lblProdTitle7.Text;
                        emailVariable["$litProdView7$"] = litProdView7.Text;
                        emailVariable["$lblProdPrice7$"] = lblProdPrice7.Text;
                        //emailVariable["$lblProdPrice7$"] = Convert.ToDecimal(lblProdPrice7.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);


                        //Prod8
                        if (lblProdTitle8.Text == "")
                        {
                            emailVariable["$imgProd8$"] = "";
                        }
                        else
                        {
                            strImg = strImgProd + lblProdImageNm8.Text;
                            emailVariable["$imgProd8$"] = "<img src='" + strImg + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblProdTitle8$"] = lblProdTitle8.Text;
                        emailVariable["$litProdView8$"] = litProdView8.Text;
                        emailVariable["$lblProdPrice8$"] = lblProdPrice8.Text;
                        //emailVariable["$lblProdPrice8$"] = Convert.ToDecimal(lblProdPrice8.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);



                        //Featured Product

                        //Feat1
                        if (lblFeatTitle1.Text == "")
                        {
                            emailVariable["$imgFeat1$"] = "";
                        }
                        else
                        {
                            emailVariable["$imgFeat1$"] = "<img src='" + strImgProd + lblFeatImageNm1.Text + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblFeatTitle1$"] = lblFeatTitle1.Text;
                        emailVariable["$litFeatView1$"] = litFeatView1.Text;
                        emailVariable["$lblFeatPrice1$"] = lblFeatPrice1.Text;
                        //emailVariable["$lblFeatPrice1$"] = Convert.ToDecimal(lblFeatPrice1.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);


                        //Feat2
                        if (lblFeatTitle2.Text == "")
                        {
                            emailVariable["$imgFeat2$"] = "";
                        }
                        else
                        {
                            emailVariable["$imgFeat2$"] = "<img src='" + strImgProd + lblFeatImageNm2.Text + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblFeatTitle2$"] = lblFeatTitle2.Text;
                        emailVariable["$litFeatView2$"] = litFeatView2.Text;
                        emailVariable["$lblFeatPrice2$"] = lblFeatPrice2.Text;
                        //emailVariable["$lblFeatPrice2$"] = Convert.ToDecimal(lblFeatPrice2.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);


                        //Feat3
                        if (lblFeatTitle3.Text == "")
                        {
                            emailVariable["$imgFeat3$"] = "";
                        }
                        else
                        {
                            emailVariable["$imgFeat3$"] = "<img src='" + strImgProd + lblFeatImageNm3.Text + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblFeatTitle3$"] = lblFeatTitle3.Text;
                        emailVariable["$litFeatView3$"] = litFeatView3.Text;
                        emailVariable["$lblFeatPrice3$"] = lblFeatPrice3.Text;
                        //emailVariable["$lblFeatPrice3$"] = Convert.ToDecimal(lblFeatPrice3.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);



                        //Feat4
                        if (lblFeatTitle4.Text == "")
                        {
                            emailVariable["$imgFeat4$"] = "";
                        }
                        else
                        {
                            emailVariable["$imgFeat4$"] = "<img src='" + strImgProd + lblFeatImageNm4.Text + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblFeatTitle4$"] = lblFeatTitle4.Text;
                        emailVariable["$litFeatView4$"] = litFeatView4.Text;
                        emailVariable["$lblFeatPrice4$"] = lblFeatPrice4.Text;
                        //emailVariable["$lblFeatPrice4$"] = Convert.ToDecimal(lblFeatPrice4.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        //Feat5
                        if (lblFeatTitle5.Text == "")
                        {
                            emailVariable["$imgFeat5$"] = "";
                        }
                        else
                        {
                            emailVariable["$imgFeat5$"] = "<img src='" + strImgProd + lblFeatImageNm5.Text + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblFeatTitle5$"] = lblFeatTitle5.Text;
                        emailVariable["$litFeatView5$"] = litFeatView5.Text;
                        emailVariable["$lblFeatPrice5$"] = lblFeatPrice5.Text;
                        // emailVariable["$lblFeatPrice5$"] = Convert.ToDecimal(lblFeatPrice5.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        //Feat6
                        if (lblFeatTitle6.Text == "")
                        {
                            emailVariable["$imgFeat6$"] = "";
                        }
                        else
                        {
                            emailVariable["$imgFeat6$"] = "<img src='" + strImgProd + lblFeatImageNm6.Text + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblFeatTitle6$"] = lblFeatTitle6.Text;
                        emailVariable["$litFeatView6$"] = litFeatView6.Text;
                        emailVariable["$lblFeatPrice6$"] = lblFeatPrice6.Text;
                        // emailVariable["$lblFeatPrice6$"] = Convert.ToDecimal(lblFeatPrice6.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        //Feat7
                        if (lblFeatTitle7.Text == "")
                        {
                            emailVariable["$imgFeat7$"] = "";
                        }
                        else
                        {
                            emailVariable["$imgFeat7$"] = "<img src='" + strImgProd + lblFeatImageNm7.Text + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblFeatTitle7$"] = lblFeatTitle7.Text;
                        emailVariable["$litFeatView7$"] = litFeatView7.Text;
                        emailVariable["$lblFeatPrice7$"] = lblFeatPrice7.Text;
                        //emailVariable["$lblFeatPrice7$"] = Convert.ToDecimal(lblFeatPrice7.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                        //Feat8
                        if (lblFeatTitle8.Text == "")
                        {
                            emailVariable["$imgFeat8$"] = "";
                        }
                        else
                        {
                            emailVariable["$imgFeat8$"] = "<img src='" + strImgProd + lblFeatImageNm8.Text + "'  width='50px' height='50px' />";
                        }
                        emailVariable["$lblFeatTitle8$"] = lblFeatTitle8.Text;
                        emailVariable["$litFeatView8$"] = litFeatView8.Text;
                        emailVariable["$lblFeatPrice8$"] = lblFeatPrice8.Text;
                        //emailVariable["$lblFeatPrice8$"] = Convert.ToDecimal(lblFeatPrice8.Text).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);



                        //object created for EmailGenerator class file 
                        EmailGenerator getEmailContent = new EmailGenerator();
                        strEmailContent = getEmailContent.SendEmailFromFile(strFileName, emailVariable);


                        emailFromAdmin.Subject = strSubject;
                        emailFromAdmin.Body = strEmailContent;

                        emailFromAdmin.IsBodyHtml = true;

                        SmtpClient smtpServer = new SmtpClient();
                        smtpServer.Send(emailFromAdmin);
                    }
                    saveTextNewsMailInformation();
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



        public void saveTextNewsMailInformation()
        {
            int insertInfo = 0;
            //Sales Product
            string prod1 = string.Empty;
            string prodTit1e1 = string.Empty;
            string prod2 = string.Empty;
            string prodTit1e2 = string.Empty;
            string prod3 = string.Empty;
            string prodTit1e3 = string.Empty;
            string prod4 = string.Empty;
            string prodTit1e4 = string.Empty;
            string prod5 = string.Empty;
            string prodTit1e5 = string.Empty;
            string prod6 = string.Empty;
            string prodTit1e6 = string.Empty;
            string prod7 = string.Empty;
            string prodTit1e7 = string.Empty;
            string prod8 = string.Empty;
            string prodTit1e8 = string.Empty;
            //Feature product
            string prodFeat1 = string.Empty;
            string prodFeatTit1e1 = string.Empty;
            string prodFeat2 = string.Empty;
            string prodFeatTit1e2 = string.Empty;
            string prodFeat3 = string.Empty;
            string prodFeatTit1e3 = string.Empty;
            string prodFeat4 = string.Empty;
            string prodFeatTit1e4 = string.Empty;
            string prodFeat5 = string.Empty;
            string prodFeatTit1e5 = string.Empty;
            string prodFeat6 = string.Empty;
            string prodFeatTit1e6 = string.Empty;
            string prodFeat7 = string.Empty;
            string prodFeatTit1e7 = string.Empty;
            string prodFeat8 = string.Empty;
            string prodFeatTit1e8 = string.Empty;

            string startDate = string.Empty;
            string EndDate = string.Empty;

            string strHead = string.Empty;
            string strFoot = string.Empty;
            string strSub = string.Empty;



            prod1 = lblProductId1.Text;
            prodTit1e1 = lblProdTitle1.Text;
            prod2 = lblProductId2.Text;
            prodTit1e2 = lblProdTitle2.Text;
            prod3 = lblProductId3.Text;
            prodTit1e3 = lblProdTitle3.Text;
            prod4 = lblProductId4.Text;
            prodTit1e4 = lblProdTitle4.Text;
            prod5 = lblProductId5.Text;
            prodTit1e5 = lblProdTitle5.Text;
            prod6 = lblProductId6.Text;
            prodTit1e6 = lblProdTitle6.Text;
            prod7 = lblProductId7.Text;
            prodTit1e7 = lblProdTitle7.Text;
            prod8 = lblProductId8.Text;
            prodTit1e8 = lblProdTitle8.Text;

            prodFeat1 = lblFeatProductId1.Text;
            prodFeatTit1e1 = lblFeatTitle1.Text;
            prodFeat2 = lblFeatProductId2.Text;
            prodFeatTit1e2 = lblFeatTitle2.Text;
            prodFeat3 = lblFeatProductId3.Text;
            prodFeatTit1e3 = lblFeatTitle3.Text;
            prodFeat4 = lblFeatProductId4.Text;
            prodFeatTit1e4 = lblFeatTitle4.Text;
            prodFeat5 = lblFeatProductId5.Text;
            prodFeatTit1e5 = lblFeatTitle5.Text;
            prodFeat6 = lblFeatProductId6.Text;
            prodFeatTit1e6 = lblFeatTitle6.Text;
            prodFeat7 = lblFeatProductId7.Text;
            prodFeatTit1e7 = lblFeatTitle7.Text;
            prodFeat8 = lblFeatProductId8.Text;
            prodFeatTit1e8 = lblFeatTitle8.Text;
            startDate = Convert.ToString(ViewState["StarDateNew"]);
            EndDate = Convert.ToString(ViewState["EndDateNew"]);
            strHead = lblEmailHeader.Text;
            strFoot = lblFooterText.Text;
            strSub = Convert.ToString(ViewState["EmailSubject"]); ;
            insertInfo = dbListInfo.InsertEmailInfo(strSub, startDate, EndDate, strHead, strFoot, Convert.ToInt32(AppConstants.locationId), DateTime.Now, prod1, prod2, prod3, prod4, prod5, prod6, prod7, prod8, prodFeat1, prodFeat2, prodFeat3, prodFeat4, prodFeat5, prodFeat6, prodFeat7, prodFeat8, prodFeatTit1e1, prodFeatTit1e2, prodFeatTit1e3, prodFeatTit1e4, prodFeatTit1e5, prodFeatTit1e6, prodFeatTit1e7, prodFeatTit1e8, prodTit1e1, prodTit1e2, prodTit1e3, prodTit1e4, prodTit1e5, prodTit1e6, prodTit1e7, prodTit1e8);
            if (insertInfo == 1)
            {

            }
        }
    }
}
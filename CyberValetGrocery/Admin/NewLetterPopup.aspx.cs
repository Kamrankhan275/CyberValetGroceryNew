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
    public partial class NewLetterPopup : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            getCompanyName();
            if (!IsPostBack)
            {
                string strAllSales = string.Empty;
                int intSendEmailId = 0;
                string strCustomerEmail = string.Empty;
                strCustomerEmail = "mailto:" + Convert.ToString(ViewState["strCustomerServiceEmail"]);
                strAllSales = Convert.ToString(ViewState["strLongUrl"]) + "/sales.aspx";
                // strAllSales = "#";
                litViewAllSaleItems.Text = "<a href='" + strAllSales + "' class='Logoutlink' target='_blank'>View All Sale Items</a>";
                litcustomerservice.Text = "<a href='" + strCustomerEmail + "'>" + Convert.ToString(ViewState["strCustomerServiceEmail"]) + "</a>";
                intSendEmailId = Convert.ToInt32(Request.QueryString["mailId"]);
                DataSet dsNewsInfo = new DataSet();
                dsNewsInfo = dbListInfo.SelectSendEmailInformation(intSendEmailId);
                if (dsNewsInfo.Tables.Count > 0)
                {
                    if (dsNewsInfo != null && dsNewsInfo.Tables.Count > 0 && dsNewsInfo.Tables[0].Rows.Count > 0)
                    {
                        BindSubject(dsNewsInfo);
                        BindGridProduct(dsNewsInfo);
                        BindGridFeaturedProduct(dsNewsInfo);
                    }
                }


            }


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
                        strCustomerServiceEmail = Convert.ToString(dtrow["CustomerServiceEmail"]);
                        ViewState["strCustomerServiceEmail"] = strCustomerServiceEmail;
                        strLongUrl = Convert.ToString(dtrow["LongURL"]);
                        ViewState["strLongUrl"] = strLongUrl;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void BindSubject(DataSet dsSubject)
        {
            if (dsSubject.Tables.Count > 0)
            {
                if (dsSubject != null && dsSubject.Tables.Count > 0 && dsSubject.Tables[0].Rows.Count > 0)
                {
                    string strDate = Convert.ToString(dsSubject.Tables[0].Rows[0]["StarDate"]) + " to " + Convert.ToString(dsSubject.Tables[0].Rows[0]["EndDate"]);
                    lblWeekDate.Text = strDate;
                    lblEmailHeader.Text = Convert.ToString(dsSubject.Tables[0].Rows[0]["HeaderMsg"]);
                    lblFooterText.Text = Convert.ToString(dsSubject.Tables[0].Rows[0]["FooterMsg"]);
                    ViewState["EmailSubject"] = Convert.ToString(dsSubject.Tables[0].Rows[0]["Subject"]);

                }
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



        public void BindGridProduct(DataSet dsItemList)
        {
            DataSet dsSales1 = new DataSet();
            string strView = string.Empty;
            string strViewLink = string.Empty;
            string strImgName = string.Empty;
            if (dsItemList.Tables.Count > 0)
            {
                if (dsItemList != null && dsItemList.Tables.Count > 0 && dsItemList.Tables[0].Rows.Count > 0)
                {


                    strViewLink = Convert.ToString(ViewState["strLongUrl"]) + "/products.aspx?shelf=";
                    //strView = "#";
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSale1"]) != "")
                    {


                        dsSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["ProductSale1"]), Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSaleTitle1"]), Convert.ToInt32(AppConstants.locationId));
                        pnlProd1.Visible = true;
                        lblPnl1.Visible = false;
                        if (dsSales1.Tables.Count > 0)
                        {
                            if (dsSales1 != null && dsSales1.Tables.Count > 0 && dsSales1.Tables[0].Rows.Count > 0)
                            {

                                //for product 1


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
                            }
                            else
                            {
                                pnlProd1.Visible = false;

                            }
                        }
                        else
                        {
                            pnlProd1.Visible = false;

                        }



                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSale2"]) != "")
                    {

                        dsSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["ProductSale2"]), Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSaleTitle2"]), Convert.ToInt32(AppConstants.locationId));
                        pnlProd2.Visible = true;
                        lblPnl2.Visible = false;
                        if (dsSales1.Tables.Count > 0)
                        {
                            if (dsSales1 != null && dsSales1.Tables.Count > 0 && dsSales1.Tables[0].Rows.Count > 0)
                            {
                                //  for product 2

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
                            }
                            else
                            {
                                pnlProd2.Visible = false;

                            }
                        }
                        else
                        {
                            pnlProd2.Visible = false;

                        }

                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSale3"]) != "")
                    {

                        dsSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["ProductSale3"]), Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSaleTitle3"]), Convert.ToInt32(AppConstants.locationId));
                        // for product 3
                        pnlProd3.Visible = true;
                        lblPnl3.Visible = false;
                        if (dsSales1.Tables.Count > 0)
                        {
                            if (dsSales1 != null && dsSales1.Tables.Count > 0 && dsSales1.Tables[0].Rows.Count > 0)
                            {

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
                                lblProdPrice3.Text = "$" + Convert.ToDecimal(dsSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                litProdView3.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                            }
                            else
                            {
                                pnlProd3.Visible = false;

                            }

                        }
                        else
                        {
                            pnlProd3.Visible = false;

                        }

                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSale4"]) != "")
                    {
                        dsSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["ProductSale4"]), Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSaleTitle4"]), Convert.ToInt32(AppConstants.locationId));
                        //for product 4
                        pnlProd4.Visible = true;
                        lblPnl4.Visible = false;
                        if (dsSales1.Tables.Count > 0)
                        {
                            if (dsSales1 != null && dsSales1.Tables.Count > 0 && dsSales1.Tables[0].Rows.Count > 0)
                            {

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
                            }
                            else
                            {
                                pnlProd4.Visible = false;

                            }

                        }
                        else
                        {
                            pnlProd4.Visible = false;

                        }

                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSale5"]) != "")
                    {
                        dsSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["ProductSale5"]), Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSaleTitle5"]), Convert.ToInt32(AppConstants.locationId));
                        // for product 5
                        pnlProd5.Visible = true;
                        lblPnl5.Visible = false;
                        if (dsSales1.Tables.Count > 0)
                        {
                            if (dsSales1 != null && dsSales1.Tables.Count > 0 && dsSales1.Tables[0].Rows.Count > 0)
                            {

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
                                //lblProdPrice5.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                                lblProdPrice5.Text = "$" + Convert.ToDecimal(dsSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                litProdView5.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                            }
                            else
                            {
                                pnlProd5.Visible = false;

                            }
                        }
                        else
                        {
                            pnlProd5.Visible = false;

                        }

                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSale6"]) != "")
                    {
                        dsSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["ProductSale6"]), Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSaleTitle6"]), Convert.ToInt32(AppConstants.locationId));
                        //for product 6
                        pnlProd6.Visible = true;
                        lblPnl6.Visible = false;
                        if (dsSales1.Tables.Count > 0)
                        {
                            if (dsSales1 != null && dsSales1.Tables.Count > 0 && dsSales1.Tables[0].Rows.Count > 0)
                            {

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
                            }
                            else
                            {
                                pnlProd6.Visible = false;

                            }
                        }
                        else
                        {
                            pnlProd6.Visible = false;

                        }

                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSale7"]) != "")
                    {
                        dsSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["ProductSale7"]), Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSaleTitle7"]), Convert.ToInt32(AppConstants.locationId));
                        //for product 7

                        pnlProd7.Visible = true;
                        lblPnl7.Visible = false;
                        if (dsSales1.Tables.Count > 0)
                        {
                            if (dsSales1 != null && dsSales1.Tables.Count > 0 && dsSales1.Tables[0].Rows.Count > 0)
                            {
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
                            }
                            else
                            {
                                pnlProd7.Visible = false;

                            }
                        }
                        else
                        {
                            pnlProd7.Visible = false;

                        }

                        dsSales1.Dispose();
                    }
                    if (Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSale8"]) != "")
                    {
                        dsSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsItemList.Tables[0].Rows[0]["ProductSale8"]), Convert.ToString(dsItemList.Tables[0].Rows[0]["ProductSaleTitle8"]), Convert.ToInt32(AppConstants.locationId));
                        //for product 8
                        pnlProd8.Visible = true;
                        lblPnl8.Visible = false;
                        if (dsSales1.Tables.Count > 0)
                        {
                            if (dsSales1 != null && dsSales1.Tables.Count > 0 && dsSales1.Tables[0].Rows.Count > 0)
                            {
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
                            else
                            {
                                pnlProd8.Visible = false;

                            }
                        }
                        else
                        {
                            pnlProd8.Visible = false;

                        }

                        dsSales1.Dispose();
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



        public void BindGridFeaturedProduct(DataSet dsFeature)
        {


            string strView = string.Empty;
            string strViewLink = string.Empty;
            string strImgName = string.Empty;
            DataSet dsFeatureSales1 = new DataSet();
            if (dsFeature.Tables.Count > 0)
            {
                if (dsFeature != null && dsFeature.Tables.Count > 0 && dsFeature.Tables[0].Rows.Count > 0)
                {

                    strViewLink = Convert.ToString(ViewState["strLongUrl"]) + "/products.aspx?shelf=";
                    // strView = "#";

                    if (Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProduct1"]) != "")
                    {
                        dsFeatureSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsFeature.Tables[0].Rows[0]["FeatureProduct1"]), Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProductTitle1"]), Convert.ToInt32(AppConstants.locationId));
                        //for product 1
                        pnlFeat1.Visible = true;
                        //lblFeat1.Visible = false;

                        if (dsFeatureSales1.Tables.Count > 0)
                        {
                            if (dsFeatureSales1 != null && dsFeatureSales1.Tables.Count > 0 && dsFeatureSales1.Tables[0].Rows.Count > 0)
                            {

                                strView = strViewLink + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["aisle_id"]);
                                if (Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]) == "")
                                {
                                    lblFeatImageNm1.Text = "no_image.gif";
                                    imgFeat1.ImageUrl = Thumbnail("no_image.gif");

                                }
                                else
                                {
                                    strImgName = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]);
                                    lblFeatImageNm1.Text = strImgName;
                                    imgFeat1.ImageUrl = Thumbnail(strImgName);
                                }
                                lblFeatProductId1.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_id"]);
                                lblFeatTitle1.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_title"]);
                                //lblFeatPrice1.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                                lblFeatPrice1.Text = "$" + Convert.ToDecimal(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                litFeatView1.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                            }
                            else
                            {
                                pnlFeat1.Visible = false;
                                lblFeat1.Visible = true;

                            }
                        }
                        else
                        {
                            pnlFeat1.Visible = false;
                            lblFeat1.Visible = true;

                        }
                        lblFeat1.Visible = false;
                        dsFeatureSales1.Dispose();
                    }
                    else
                    {
                        pnlFeat1.Visible = false;
                        lblFeat1.Visible = false;

                    }
                    if (Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProduct2"]) != "")
                    {
                        dsFeatureSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsFeature.Tables[0].Rows[0]["FeatureProduct2"]), Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProductTitle2"]), Convert.ToInt32(AppConstants.locationId));


                        //  for product 2
                        pnlFeat2.Visible = true;
                        // lblFeat2.Visible = false;
                        strView = strViewLink + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["aisle_id"]);
                        if (dsFeatureSales1.Tables.Count > 0)
                        {
                            if (dsFeatureSales1 != null && dsFeatureSales1.Tables.Count > 0 && dsFeatureSales1.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]) == "")
                                {
                                    lblFeatImageNm2.Text = "no_image.gif";
                                    imgFeat2.ImageUrl = Thumbnail("no_image.gif");

                                }
                                else
                                {
                                    strImgName = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]);
                                    lblFeatImageNm2.Text = strImgName;
                                    imgFeat2.ImageUrl = Thumbnail(strImgName);
                                }
                                lblFeatProductId2.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_id"]);
                                lblFeatTitle2.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_title"]);
                                //lblFeatPrice2.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                                lblFeatPrice2.Text = "$" + Convert.ToDecimal(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                litFeatView2.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                                dsFeatureSales1.Dispose();
                            }
                            else
                            {
                                pnlFeat2.Visible = false;
                                lblFeat2.Visible = true;

                            }
                        }
                        else
                        {
                            pnlFeat2.Visible = false;
                            lblFeat2.Visible = true;

                        }
                        lblFeat2.Visible = false;
                        dsFeatureSales1.Dispose();
                    }
                    else
                    {
                        pnlFeat2.Visible = false;
                        lblFeat2.Visible = false;

                    }
                    if (Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProduct3"]) != "")
                    {
                        dsFeatureSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsFeature.Tables[0].Rows[0]["FeatureProduct3"]), Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProductTitle3"]), Convert.ToInt32(AppConstants.locationId));

                        // for product 3
                        pnlFeat3.Visible = true;
                        // lblFeat3.Visible = false;

                        if (dsFeatureSales1.Tables.Count > 0)
                        {
                            if (dsFeatureSales1 != null && dsFeatureSales1.Tables.Count > 0 && dsFeatureSales1.Tables[0].Rows.Count > 0)
                            {
                                strView = strViewLink + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["aisle_id"]);
                                if (Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]) == "")
                                {
                                    lblFeatImageNm3.Text = "no_image.gif";
                                    imgFeat3.ImageUrl = Thumbnail("no_image.gif");

                                }
                                else
                                {
                                    strImgName = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]);
                                    lblFeatImageNm3.Text = strImgName;
                                    imgFeat3.ImageUrl = Thumbnail(strImgName);
                                }
                                lblFeatProductId3.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_id"]);
                                lblFeatTitle3.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_title"]);
                                //lblFeatPrice3.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                                lblFeatPrice3.Text = "$" + Convert.ToDecimal(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                litFeatView3.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                            }
                            else
                            {
                                pnlFeat3.Visible = false;
                                lblFeat3.Visible = true;

                            }
                        }
                        else
                        {
                            pnlFeat3.Visible = false;
                            lblFeat3.Visible = true;

                        }
                        lblFeat3.Visible = false;
                        dsFeatureSales1.Dispose();
                    }
                    else
                    {
                        pnlFeat3.Visible = false;
                        lblFeat3.Visible = false;

                    }
                    if (Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProduct4"]) != "")
                    {
                        dsFeatureSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsFeature.Tables[0].Rows[0]["FeatureProduct4"]), Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProductTitle4"]), Convert.ToInt32(AppConstants.locationId));

                        //for product 4
                        pnlFeat4.Visible = true;
                        //lblFeat4.Visible = false;

                        if (dsFeatureSales1.Tables.Count > 0)
                        {
                            if (dsFeatureSales1 != null && dsFeatureSales1.Tables.Count > 0 && dsFeatureSales1.Tables[0].Rows.Count > 0)
                            {
                                strView = strViewLink + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["aisle_id"]);
                                if (Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]) == "")
                                {
                                    lblFeatImageNm4.Text = "no_image.gif";
                                    imgFeat4.ImageUrl = Thumbnail("no_image.gif");

                                }
                                else
                                {
                                    strImgName = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]);
                                    lblFeatImageNm4.Text = strImgName;
                                    imgFeat4.ImageUrl = Thumbnail(strImgName);
                                }
                                lblFeatProductId4.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_id"]);
                                lblFeatTitle4.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_title"]);
                                //lblFeatPrice4.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                                lblFeatPrice4.Text = "$" + Convert.ToDecimal(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                litFeatView4.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                            }
                            else
                            {
                                pnlFeat4.Visible = false;
                                lblFeat4.Visible = true;

                            }
                        }
                        else
                        {
                            pnlFeat4.Visible = false;
                            lblFeat4.Visible = true;

                        }
                        lblFeat4.Visible = false;
                        dsFeatureSales1.Dispose();
                    }
                    else
                    {
                        pnlFeat4.Visible = false;
                        lblFeat4.Visible = false;

                    }
                    if (Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProduct5"]) != "")
                    {
                        dsFeatureSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsFeature.Tables[0].Rows[0]["FeatureProduct5"]), Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProductTitle5"]), Convert.ToInt32(AppConstants.locationId));

                        // for product 5
                        pnlFeat5.Visible = true;
                        // lblFeat5.Visible = false;

                        if (dsFeatureSales1.Tables.Count > 0)
                        {
                            if (dsFeatureSales1 != null && dsFeatureSales1.Tables.Count > 0 && dsFeatureSales1.Tables[0].Rows.Count > 0)
                            {
                                strView = strViewLink + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["aisle_id"]);
                                if (Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]) == "")
                                {
                                    lblFeatImageNm5.Text = "no_image.gif";
                                    imgFeat5.ImageUrl = Thumbnail("no_image.gif");

                                }
                                else
                                {
                                    strImgName = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]);
                                    lblFeatImageNm5.Text = strImgName;
                                    imgFeat5.ImageUrl = Thumbnail(strImgName);
                                }
                                lblFeatProductId5.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_id"]);
                                lblFeatTitle5.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_title"]);
                                //lblFeatPrice5.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                                lblFeatPrice5.Text = "$" + Convert.ToDecimal(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                litFeatView5.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                            }
                            else
                            {
                                pnlFeat5.Visible = false;
                                lblFeat5.Visible = true;

                            }
                        }
                        else
                        {
                            pnlFeat5.Visible = false;
                            lblFeat5.Visible = true;

                        }
                        lblFeat5.Visible = false;
                        dsFeatureSales1.Dispose();
                    }
                    else
                    {
                        pnlFeat5.Visible = false;
                        lblFeat5.Visible = false;

                    }
                    if (Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProduct6"]) != "")
                    {
                        dsFeatureSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsFeature.Tables[0].Rows[0]["FeatureProduct6"]), Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProductTitle6"]), Convert.ToInt32(AppConstants.locationId));


                        //for product 6
                        pnlFeat6.Visible = true;
                        // lblFeat6.Visible = false;

                        if (dsFeatureSales1.Tables.Count > 0)
                        {
                            if (dsFeatureSales1 != null && dsFeatureSales1.Tables.Count > 0 && dsFeatureSales1.Tables[0].Rows.Count > 0)
                            {
                                strView = strViewLink + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["aisle_id"]);
                                if (Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]) == "")
                                {
                                    lblFeatImageNm6.Text = "no_image.gif";
                                    imgFeat6.ImageUrl = Thumbnail("no_image.gif");

                                }
                                else
                                {
                                    strImgName = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]);
                                    lblFeatImageNm6.Text = strImgName;
                                    imgFeat6.ImageUrl = Thumbnail(strImgName);
                                }
                                lblFeatProductId6.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_id"]);
                                lblFeatTitle6.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_title"]);
                                //lblFeatPrice6.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                                lblFeatPrice6.Text = "$" + Convert.ToDecimal(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                litFeatView6.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                            }
                            else
                            {
                                pnlFeat6.Visible = false;
                                lblFeat6.Visible = true;

                            }
                        }
                        else
                        {
                            pnlFeat6.Visible = false;
                            lblFeat6.Visible = true;

                        }
                        lblFeat6.Visible = false;
                        dsFeatureSales1.Dispose();
                    }
                    else
                    {
                        pnlFeat6.Visible = false;
                        lblFeat6.Visible = false;

                    }
                    if (Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProduct7"]) != "")
                    {
                        dsFeatureSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsFeature.Tables[0].Rows[0]["FeatureProduct7"]), Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProductTitle7"]), Convert.ToInt32(AppConstants.locationId));

                        //for product 7
                        pnlFeat7.Visible = true;
                        //  lblFeat7.Visible = false;

                        if (dsFeatureSales1.Tables.Count > 0)
                        {
                            if (dsFeatureSales1 != null && dsFeatureSales1.Tables.Count > 0 && dsFeatureSales1.Tables[0].Rows.Count > 0)
                            {
                                strView = strViewLink + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["aisle_id"]);
                                if (Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]) == "")
                                {
                                    lblFeatImageNm7.Text = "no_image.gif";
                                    imgFeat7.ImageUrl = Thumbnail("no_image.gif");

                                }
                                else
                                {
                                    strImgName = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]);
                                    lblFeatImageNm7.Text = strImgName;
                                    imgProd7.ImageUrl = Thumbnail(strImgName);
                                }
                                lblFeatProductId7.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_id"]);
                                lblFeatTitle7.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_title"]);
                                //lblFeatPrice7.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                                lblFeatPrice7.Text = "$" + Convert.ToDecimal(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                litFeatView7.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                            }
                            else
                            {
                                pnlFeat7.Visible = false;
                                lblFeat7.Visible = true;

                            }
                        }
                        else
                        {
                            pnlFeat7.Visible = false;
                            lblFeat7.Visible = true;

                        }
                        lblFeat7.Visible = false;
                        dsFeatureSales1.Dispose();
                    }
                    else
                    {
                        pnlFeat7.Visible = false;
                        lblFeat7.Visible = false;

                    }
                    if (Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProduct8"]) != "")
                    {
                        dsFeatureSales1 = dbListInfo.SelectSendEmailProductInfo(Convert.ToInt32(dsFeature.Tables[0].Rows[0]["FeatureProduct8"]), Convert.ToString(dsFeature.Tables[0].Rows[0]["FeatureProductTitle8"]), Convert.ToInt32(AppConstants.locationId));
                        //for product 8
                        pnlFeat8.Visible = true;
                        // lblFeat8.Visible = false;

                        if (dsFeatureSales1.Tables.Count > 0)
                        {
                            if (dsFeatureSales1 != null && dsFeatureSales1.Tables.Count > 0 && dsFeatureSales1.Tables[0].Rows.Count > 0)
                            {
                                strView = strViewLink + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["shelf_id"]) + "&aisle=" + Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["aisle_id"]);
                                if (Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]) == "")
                                {
                                    lblFeatImageNm8.Text = "no_image.gif";
                                    imgFeat8.ImageUrl = Thumbnail("no_image.gif");

                                }
                                else
                                {
                                    strImgName = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_image"]);
                                    lblFeatImageNm8.Text = strImgName;
                                    imgProd8.ImageUrl = Thumbnail(strImgName);
                                }
                                lblFeatProductId8.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_id"]);
                                lblFeatTitle8.Text = Convert.ToString(dsFeatureSales1.Tables[0].Rows[0]["product_title"]);
                                //lblFeatPrice8.Text = "$" + Convert.ToString(Math.Round(Convert.ToDouble(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]), 2));
                                lblFeatPrice8.Text = "$" + Convert.ToDecimal(dsFeatureSales1.Tables[0].Rows[0]["productlink_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                litFeatView8.Text = "<a href='" + strView + "'class='sublink' target='_blank'>View</a>";
                            }
                            else
                            {
                                pnlFeat8.Visible = false;
                                lblFeat8.Visible = true;

                            }
                        }
                        else
                        {
                            pnlFeat8.Visible = false;
                            lblFeat8.Visible = true;

                        }
                        lblFeat8.Visible = false;
                        dsFeatureSales1.Dispose();
                    }
                    else
                    {
                        pnlFeat8.Visible = false;
                        lblFeat8.Visible = false;

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
    }
}
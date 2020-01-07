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
using System.Globalization;

namespace CyberValetGrocery
{
    public partial class Shop : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {

            HtmlGenericControl liItem = (HtmlGenericControl)Master.FindControl("shop");
            liItem.Attributes.Add("class", "selected");
            BindSideLink();
            getCompanyName();
            if (!IsPostBack)
            {
                DataSet dsDeliveryList = new DataSet();
                DataSet dsUserDeliveryList = new DataSet();
                DataSet dsUserInfo = new DataSet();
                DateTime dtDate = new DateTime();
                string strDel = string.Empty;
                string strDay = string.Empty;
                string strMonth = string.Empty;
                string strYear = string.Empty;
                string strDate = string.Empty;
                DataTable dtDelivery = new DataTable();
                DataRow rowDelivery;
                dtDelivery.Columns.Add("deliverydate_id");
                dtDelivery.Columns.Add("deliverydate_date");

                DataSet dsList = new DataSet();
                dsList = dbInfo.GetUserShopDelveryTimeInformation();
                if (Request.Cookies["userId"] == null || Request.Cookies["userId"].Value == "")
                {
                    // dsDeliveryList = dbInfo.GetDeliveryDateInformation(Convert.ToInt32(AppConstants.locationId));

                    BindDeliveryDateInfo(dsList);
                }
                else
                {
                    dsDeliveryList = dbInfo.GetUserNewDelveryTimeInformation();
                    dsUserInfo = dbInfo.GetUserDetailsInfo(Convert.ToInt32(Request.Cookies["userId"].Value));
                    if (dsUserInfo.Tables.Count > 0)
                    {
                        if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                        {
                            string intZipId = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_zip"]);
                            dsUserDeliveryList = dbInfo.GetUserDeliveryDateInformationNew(Convert.ToInt32(AppConstants.locationId), intZipId);
                            if (dsUserDeliveryList.Tables.Count > 0)
                            {
                                if (dsUserDeliveryList != null && dsUserDeliveryList.Tables.Count > 0 && dsUserDeliveryList.Tables[0].Rows.Count > 0)
                                {
                                    if (dsDeliveryList.Tables.Count > 0)
                                    {
                                        if (dsDeliveryList != null && dsDeliveryList.Tables.Count > 0 && dsDeliveryList.Tables[0].Rows.Count > 0)
                                        {

                                            foreach (DataRow dtrow in dsDeliveryList.Tables[0].Rows)
                                            {
                                                foreach (DataRow dtrow1 in dsUserDeliveryList.Tables[0].Rows)
                                                {
                                                    if (Convert.ToString(dtrow1["deliverydate_id"]) == Convert.ToString(dtrow["deliverydate_id"]))
                                                    {

                                                        rowDelivery = dtDelivery.NewRow();
                                                        rowDelivery["deliverydate_id"] = Convert.ToString(dtrow1["deliverydate_id"]);
                                                        rowDelivery["deliverydate_date"] = Convert.ToString(dtrow1["deliverydate_date"]);
                                                        dtDelivery.Rows.Add(rowDelivery);
                                                    }
                                                }


                                            }
                                            if (dtDelivery.Rows.Count > 0)
                                            {
                                                DataSet dsDelivery = new DataSet();
                                                dsDelivery.Tables.Add(dtDelivery);
                                                BindDeliveryDateInfo(dsDelivery);


                                            }
                                            else
                                            {
                                                pnlDeliveryInfo.Visible = false;

                                            }
                                        }
                                        else
                                        {
                                            pnlDeliveryInfo.Visible = false;

                                        }
                                    }
                                    else
                                    {
                                        pnlDeliveryInfo.Visible = false;

                                    }


                                }
                                else
                                {
                                    pnlDeliveryInfo.Visible = false;

                                }
                            }
                            else
                            {
                                pnlDeliveryInfo.Visible = false;
                            }


                        }
                    }


                }
                DataSet dsAislesList = new DataSet();
                dsAislesList = dbInfo.GetUserAislesDeatils();
                if (dsAislesList.Tables.Count > 0)
                {
                    if (dsAislesList != null && dsAislesList.Tables.Count > 0 && dsAislesList.Tables[0].Rows.Count > 0)
                    {

                        dtlAislesDetail.DataSource = dsAislesList;
                        dtlAislesDetail.DataBind();
                    }

                }
                dbInfo.dispose();
                DataSet dsHighlightedAisles = new DataSet();
                dsHighlightedAisles = dbInfo.GetUserAislesDeatilsHighlighted();
                if (dsHighlightedAisles.Tables.Count > 0)
                {
                    if (dsHighlightedAisles != null && dsHighlightedAisles.Tables.Count > 0 && dsHighlightedAisles.Tables[0].Rows.Count > 0)
                    {
                        pnlHighLight.Visible = true;
                        HighlightTopAisle.DataSource = dsHighlightedAisles;
                        HighlightTopAisle.DataBind();
                    }
                    else
                    {
                        pnlHighLight.Visible = false;
                    }

                }

            }



        }

        public void BindDeliveryDateInfo(DataSet dsDeliveryList)
        {
            DateTime dtDate = new DateTime();
            string strDel = string.Empty;
            string strDay = string.Empty;
            string strMonth = string.Empty;
            string strYear = string.Empty;
            string strDate = string.Empty;

            if (dsDeliveryList.Tables.Count > 0)
            {
                if (dsDeliveryList != null && dsDeliveryList.Tables.Count > 0 && dsDeliveryList.Tables[0].Rows.Count > 0)
                {
                    pnlDeliveryInfo.Visible = true;
                    foreach (DataRow dtrow in dsDeliveryList.Tables[0].Rows)
                    {
                        if (Convert.ToString(dtrow["deliverydate_date"]) != "")
                        {

                            dtDate = Convert.ToDateTime(dtrow["deliverydate_date"]);
                            strDay = Convert.ToString(dtDate.DayOfWeek);
                            strYear = Convert.ToString(dtDate.Year);
                            strDate = Convert.ToString(dtDate.Day);
                            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dtDate.Month);

                            if (Convert.ToInt32(strDate) < 10)
                            {
                                strDate = "0" + strDate;
                            }

                            if (strDel == "")
                            {
                                strDel = strDay + ", " + monthName + " " + strDate + ", " + strYear + "  ";
                                lblDeliveryDate1.Text = strDel;
                                lbland.Visible = false;
                            }
                            else
                            {
                                strDel = strDay + ", " + monthName + " " + strDate + ", " + strYear;
                                lblDeliveryDate2.Text = strDel;
                                lbland.Visible = true;


                            }

                        }
                    }
                }


                else
                {

                    pnlDeliveryInfo.Visible = false;
                }

            }
            else
            {

                pnlDeliveryInfo.Visible = false;
            }
        }



        public string Thumbnail(string imgName)
        {
            string urlThumbnail = string.Empty;
            if (imgName != "")
            {

                urlThumbnail = "thumbnailUserAisileimg.aspx?imgName=" + imgName;

            }
            return urlThumbnail;
        }


        public void BindSideLink()
        {
            Panel pnlHow = (Panel)Page.Master.FindControl("pnlHow");
            pnlHow.Visible = false;
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = true;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;



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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgShop;

                    }
                }
            }
            dbGetCompanyName.dispose();
        }



    }
}

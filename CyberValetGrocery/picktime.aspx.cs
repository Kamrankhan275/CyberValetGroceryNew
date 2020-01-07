﻿using System;
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

namespace CyberValetGrocery
{
    public partial class picktime : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        DropdownProvider dropState = new DropdownProvider();
        DbProvider dbAddInfo = new DbProvider();
        DropdownProvider dropDeliveryInfo = new DropdownProvider();
        string strUserPickTimeInfo = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["userId"] == null)
                {
                    Response.Redirect("LoginPage.aspx", false);
                }
                else
                {
                    getCompanyName();

                    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();
                    lblMsg.Visible = false;
                    txtImmediatedel.Visible = false;
                    lblMsg.Text = "";

                    string strTime = string.Empty;

                    if (!IsPostBack)
                    {
                        BindUserBillingInformation();
                        getServerTimeInMinutes();
                        pnlDelivery.Visible = true;
                        pnlDeldate.Visible = false;
                        pnlFutureDate.Visible = false;
                        trFuture.Visible = false;
                        pnlTodaysDelivery.Visible = false;
                        pnlImmediateDelivery.Visible = false;
                        getServerTime();
                        getCurrentServerTimeInMinutes();
                        getNextServerTimeInMinutes();
                        lblMsg.Visible = false;
                        lblMsg.Text = "";
                        bindfuturedatedropdown();
                        dropDeliveryInfo.bindStoreLocation(ddlstoreLocation);
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        btnChoose.Visible = false;
                        pnlDeliveryType.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        public void getNextServerTimeInMinutes()
        {
            DbProvider dbGetServerTime = new DbProvider();
            DataSet dsServerTime = new DataSet();
            dsServerTime = dbGetServerTime.getNextServerTimeInMinutes();

            if (dsServerTime.Tables.Count > 0)
            {
                if (dsServerTime != null && dsServerTime.Tables.Count > 0 && dsServerTime.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsServerTime.Tables[0].Rows)
                    {
                        lblNextTime.Text = Convert.ToString(dtrow["HourMinuteSecond"]);
                    }
                }
            }

            dbGetServerTime.dispose();
        }

        public void getCurrentServerTimeInMinutes()
        {
            DbProvider dbGetServerTime = new DbProvider();
            DataSet dsServerTime = new DataSet();
            dsServerTime = dbGetServerTime.getCurrentServerTimeInMinutes();

            if (dsServerTime.Tables.Count > 0)
            {
                if (dsServerTime != null && dsServerTime.Tables.Count > 0 && dsServerTime.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsServerTime.Tables[0].Rows)
                    {
                        lblCurrentTime.Text = Convert.ToString(dtrow["HourMinuteSecond"]);
                    }
                }
            }

            dbGetServerTime.dispose();
        }

        public void getServerTime()
        {
            DbProvider dbGetServerTime = new DbProvider();
            DataSet dsServerTime = new DataSet();
            dsServerTime = dbGetServerTime.getServerTime();

            if (dsServerTime.Tables.Count > 0)
            {
                if (dsServerTime != null && dsServerTime.Tables.Count > 0 && dsServerTime.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsServerTime.Tables[0].Rows)
                    {
                        lblTime.Text = Convert.ToString(dtrow["HourMinuteSecond"]);
                    }
                }
            }

            dbGetServerTime.dispose();
        }

        public void getServerTimeInMinutes()
        {
            DbProvider dbGetServerTime = new DbProvider();
            DataSet dsServerTime = new DataSet();
            dsServerTime = dbGetServerTime.getServerTimeInMinutes();

            if (dsServerTime.Tables.Count > 0)
            {
                if (dsServerTime != null && dsServerTime.Tables.Count > 0 && dsServerTime.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsServerTime.Tables[0].Rows)
                    {
                        lblTimeForMinute.Text = Convert.ToString(dtrow["TimeInMinutes"]);
                    }
                }
            }

            dbGetServerTime.dispose();
        }

        public void BindUserBillingInformation()
        {
            string fName = string.Empty;
            string lName = string.Empty;
            string phone = string.Empty;
            string zipcode = string.Empty;
            DataSet dsUserInfo = new DataSet();
            dsUserInfo = dbInfo.GetUserDetailsInfoCheckZip(Convert.ToInt32(Request.Cookies["userId"].Value));

            if (dsUserInfo.Tables.Count > 0)
            {
                if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                {
                    zipcode = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["Zip"]);

                    DataSet dsZip = new DataSet();
                    dsZip = dbInfo.GetUserZipInfo(zipcode);

                    if (dsZip.Tables.Count > 0)
                    {
                        if (dsZip != null && dsZip.Tables.Count > 0 && dsZip.Tables[0].Rows.Count > 0)
                        {
                            dropDeliveryInfo.bindDeliveryInfoDropdown(drpDelivery);
                        }
                        else
                        {
                            dropDeliveryInfo.bindDeliveryInfoDropdown1(drpDelivery);
                        }
                    }
                    else
                    {
                        dropDeliveryInfo.bindDeliveryInfoDropdown1(drpDelivery);
                    }

                    dbInfo.dispose();
                }
                else
                {
                    dropDeliveryInfo.bindDeliveryInfoDropdown1(drpDelivery);
                }
            }
            else
            {
                dropDeliveryInfo.bindDeliveryInfoDropdown1(drpDelivery);
            }
        }

        public void BindDeliveryInfoPickUp()
        {
            DataTable dtDelivery = new DataTable();
            DataRow rowDelivery;

            dtDelivery.Columns.Add("deliverydate_id");
            dtDelivery.Columns.Add("deliverydate_date");

            DataSet dsDeleryDateTime = new DataSet();
            DataSet dsUserDeliveryList = new DataSet();
            DataSet dsUserInfo = new DataSet();
            dsDeleryDateTime = dbInfo.GetUserNewDelveryTimeInformationPickUp();
            dsUserInfo = dbInfo.GetUserDetailsInfoGetZip(Convert.ToInt32(Request.Cookies["userId"].Value));

            if (dsUserInfo.Tables.Count > 0)
            {
                if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                {
                    int intZipId = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["Zip"]);

                    dsUserDeliveryList = dbInfo.GetUserPickTimeDelDateInfo(Convert.ToInt32(AppConstants.locationId), intZipId);

                    if (dsUserDeliveryList.Tables.Count > 0)
                    {
                        if (dsUserDeliveryList != null && dsUserDeliveryList.Tables.Count > 0 && dsUserDeliveryList.Tables[0].Rows.Count > 0)
                        {
                            if (dsDeleryDateTime.Tables.Count > 0)
                            {
                                if (dsDeleryDateTime != null && dsDeleryDateTime.Tables.Count > 0 && dsDeleryDateTime.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dtrow in dsDeleryDateTime.Tables[0].Rows)
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
                                        BindDelivery(dsDelivery);
                                    }
                                    else
                                    {
                                        lblMsg.Text = "";
                                        lblMsg.Visible = true;
                                        lblMsg.Text = AppConstants.strNoTodaysDelivery;
                                        pnlDeldate.Visible = false;
                                        btnChoose.Visible = false;
                                        btnSubmit.Visible = false;
                                        gridTimeInfo.Visible = false;
                                        pnlDeliveryType.Visible = true;
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = "";
                                    lblMsg.Visible = true;
                                    lblMsg.Text = AppConstants.strNoTodaysDelivery;
                                    pnlDeldate.Visible = false;
                                    btnChoose.Visible = false;
                                    btnSubmit.Visible = false;
                                    gridTimeInfo.Visible = false;
                                    pnlDeliveryType.Visible = true;
                                }
                            }
                            else
                            {
                                lblMsg.Text = "";
                                lblMsg.Visible = true;
                                lblMsg.Text = AppConstants.strNoTodaysDelivery;
                                pnlDeldate.Visible = false;
                                btnChoose.Visible = false;
                                btnSubmit.Visible = false;
                                gridTimeInfo.Visible = false;
                                pnlDeliveryType.Visible = true;
                            }
                        }
                        else
                        {
                            lblMsg.Text = "";
                            lblMsg.Visible = true;
                            lblMsg.Text = AppConstants.strNoTodaysDelivery;
                            pnlDeldate.Visible = false;
                            btnChoose.Visible = false;
                            btnSubmit.Visible = false;
                            gridTimeInfo.Visible = false;
                            pnlDeliveryType.Visible = true;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Visible = true;
                        lblMsg.Text = AppConstants.strNoTodaysDelivery;
                        pnlDeldate.Visible = false;
                        btnChoose.Visible = false;
                        btnSubmit.Visible = false;
                        gridTimeInfo.Visible = false;
                        pnlDeliveryType.Visible = true;
                    }
                }
            }
        }

        public void BindDeliveryInfo()
        {
            DataTable dtDelivery = new DataTable();
            DataRow rowDelivery;

            dtDelivery.Columns.Add("deliverydate_id");
            dtDelivery.Columns.Add("deliverydate_date");

            DataSet dsDeleryDateTime = new DataSet();
            DataSet dsUserDeliveryList = new DataSet();
            DataSet dsUserInfo = new DataSet();

            dsDeleryDateTime = dbInfo.GetUserNewDelveryTimeInformation();
            dsUserInfo = dbInfo.GetUserDetailsInfoGetZip(Convert.ToInt32(Request.Cookies["userId"].Value));

            if (dsUserInfo.Tables.Count > 0)
            {
                if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                {
                    int intZipId = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["Zip"]);

                    dsUserDeliveryList = dbInfo.GetDeliveryDateWithZip(Convert.ToInt32(AppConstants.locationId), intZipId);

                    if (dsUserDeliveryList.Tables.Count > 0)
                    {
                        if (dsUserDeliveryList != null && dsUserDeliveryList.Tables.Count > 0 && dsUserDeliveryList.Tables[0].Rows.Count > 0)
                        {
                            if (dsDeleryDateTime.Tables.Count > 0)
                            {
                                if (dsDeleryDateTime != null && dsDeleryDateTime.Tables.Count > 0 && dsDeleryDateTime.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dtrow in dsDeleryDateTime.Tables[0].Rows)
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
                                        BindDelivery(dsDelivery);
                                        pnlDeliveryType.Visible = false;
                                        pnlDeldate.Visible = true;
                                        pnlFutureDate.Visible = true;
                                        trFuture.Visible = true;
                                        btnChoose.Visible = true;
                                    }
                                    else
                                    {
                                        lblMsg.Text = "";
                                        lblMsg.Visible = true;
                                        lblMsg.Text = AppConstants.strNoDelDateAva;
                                        pnlDeldate.Visible = false;
                                        btnChoose.Visible = false;
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = "";
                                    lblMsg.Visible = true;
                                    lblMsg.Text = AppConstants.strNoDelDateAva;
                                    pnlDeldate.Visible = false;
                                    btnChoose.Visible = false;
                                }
                            }
                            else
                            {
                                lblMsg.Text = "";
                                lblMsg.Visible = true;
                                lblMsg.Text = AppConstants.strNoDelDateAva;
                                pnlDeldate.Visible = false;
                                btnChoose.Visible = false;
                            }
                        }
                        else
                        {
                            lblMsg.Text = "";
                            lblMsg.Visible = true;
                            lblMsg.Text = AppConstants.strNoDelDateAva;
                            pnlDeldate.Visible = false;
                            btnChoose.Visible = false;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Visible = true;
                        lblMsg.Text = AppConstants.strNoDelDateAva;
                        pnlDeldate.Visible = false;
                        btnChoose.Visible = false;
                    }
                }
            }
        }

        public void BindDelivery(DataSet dsDeleryDateTime)
        {
            DataTable dtDelivery = new DataTable();
            DataRow rowDel;

            dtDelivery.Columns.Add("DelDate");
            dtDelivery.Columns.Add("DelId");
            dtDelivery.Columns.Add("DDate");

            int delevryId = 0;
            DateTime delveryDate;
            string strDay = string.Empty;
            string strMonth = string.Empty;
            string strYear = string.Empty;
            string strDayVal = string.Empty;
            string strDate = string.Empty;

            DateTime today = DateTime.Now;

            if (dsDeleryDateTime.Tables.Count > 0)
            {
                if (dsDeleryDateTime != null && dsDeleryDateTime.Tables.Count > 0 && dsDeleryDateTime.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsDeleryDateTime.Tables[0].Rows)
                    {
                        delevryId = Convert.ToInt32(dtrow["deliverydate_id"]);
                        delveryDate = Convert.ToDateTime(dtrow["deliverydate_date"]);
                        strDayVal = delveryDate.Day.ToString();
                        strDay = delveryDate.DayOfWeek.ToString();
                        strMonth = MonthName(delveryDate.Month.ToString());
                        strYear = delveryDate.Year.ToString();
                        strDate = strDay + ", " + strMonth + " " + strDayVal + ", " + strYear;
                        rowDel = dtDelivery.NewRow();
                        rowDel["DelId"] = delevryId;
                        rowDel["DelDate"] = strDate;
                        rowDel["DDate"] = delveryDate;
                        dtDelivery.Rows.Add(rowDel);
                    }

                    dtlDeliveryGrid.DataSource = dtDelivery;
                    dtlDeliveryGrid.DataBind();

                    foreach (DataListItem dtList in dtlDeliveryGrid.Items)
                    {
                        RadioButtonList rdList;
                        rdList = (RadioButtonList)dtList.FindControl("rdChkTime");

                        Label lblDelId;
                        lblDelId = (Label)dtList.FindControl("lblDelId");

                        DataSet dsDelivery = new DataSet();
                        dsDelivery = dbInfo.GetDelveryTimeInfo(Convert.ToInt32(lblDelId.Text));

                        if (dsDelivery.Tables.Count > 0)
                        {
                            if (dsDelivery != null && dsDelivery.Tables.Count > 0 && dsDelivery.Tables[0].Rows.Count > 0)
                            {
                                rdList.DataSource = dsDelivery;
                                rdList.DataTextField = "deliverytime_time";
                                rdList.DataValueField = "deliverytime_id";
                                rdList.DataBind();
                            }
                        }
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.strNoDelDateAva;
                    pnlDeldate.Visible = false;
                    btnChoose.Visible = false;
                }
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.strNoDelDateAva;
                pnlDeldate.Visible = false;
                btnChoose.Visible = false;
            }
        }

        public void bindfuturedatedropdown()
        {
            DataSet dsUserInfo;
            DataSet dsUserDeliveryList;
            dsUserInfo = dbInfo.GetUserDetailsInfoGetZip(Convert.ToInt32(Request.Cookies["userId"].Value));

            if (dsUserInfo.Tables.Count > 0)
            {
                if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                {
                    int intZipId = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["Zip"]);
                    dsUserDeliveryList = dbInfo.GetUserPickTimeDelDateDetails1(Convert.ToInt32(AppConstants.locationId), intZipId);

                    if (dsUserDeliveryList.Tables.Count > 0)
                    {
                        if (dsUserDeliveryList != null && dsUserDeliveryList.Tables.Count > 0 && dsUserDeliveryList.Tables[0].Rows.Count > 0)
                        {
                            drpFutureDate.DataSource = dsUserDeliveryList;
                            drpFutureDate.DataTextField = "deliverydate_dateTime";
                            drpFutureDate.DataValueField = "deliverydate_id";
                            drpFutureDate.DataBind();
                        }
                    }
                }
            }

            drpFutureDate.Items.Insert(0, new ListItem("Select", "Select"));
            drpFutureDate.SelectedValue = "Select";
        }

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgPickTime;
                    }
                }
            }

            dbGetCompanyName.dispose();
        }

        protected void btnChoose_Click(object sender, EventArgs e)
        {
            int intChk = 0;

            foreach (DataListItem dtList in dtlDeliveryGrid.Items)
            {
                RadioButtonList rdList;
                rdList = (RadioButtonList)dtList.FindControl("rdChkTime");

                for (int i = 0; i < rdList.Items.Count; i++)
                {
                    if (rdList.Items[i].Selected == true)
                    {
                        ViewState["DeliveryTime"] = rdList.Items[i].Value;
                        intChk = 1;
                    }
                }
            }

            if (intChk == 1)
            {
                intChk = 0;
                lblMsg.Visible = false;
                lblMsg.Text = "";
                string strUserPickTimeInfo = string.Empty;
                strUserPickTimeInfo = Convert.ToString(ViewState["DelDate"]) + "!*@!" + Convert.ToString(ViewState["DeliveryTime"]);

                if (ViewState["IsPickUp"] != null)
                {
                    if (!Convert.ToBoolean(ViewState["IsPickUp"].ToString()))
                    {
                        HttpCookie StoreLocationId = new HttpCookie("StoreLocationId", "0");
                        Response.Cookies.Add(StoreLocationId);
                        CreateUserShopAddInfoCookie(strUserPickTimeInfo);
                        Response.Redirect("tipping.aspx", false);
                    }
                    else
                    {
                        strUserPickTimeInfo += "!*@!" + Convert.ToString(ViewState["TodaysDelivery"]);
                        CreateUserShopAddInfoCookie(strUserPickTimeInfo);

                        HttpCookie strUserTipping = new HttpCookie("strUserTipping", "1!*@!0");
                        Response.Cookies.Add(strUserTipping);
                        Response.Redirect("Payment.aspx", false);
                    }
                }
                else
                {
                    HttpCookie StoreLocationId = new HttpCookie("StoreLocationId", "0");
                    Response.Cookies.Add(StoreLocationId);
                    CreateUserShopAddInfoCookie(strUserPickTimeInfo);
                    Response.Redirect("tipping.aspx", false);
                }
            }
            else if (drpFutureDate.SelectedValue != "Select" && drpFutureDateTime.SelectedValue != "Select")
            {
                intChk = 0;
                lblMsg.Visible = false;
                lblMsg.Text = "";

                string strUserPickTimeInfo = string.Empty;
                string date = Convert.ToString(drpFutureDate.SelectedItem);

                DateTimeFormatInfo dtformat = new DateTimeFormatInfo();
                dtformat.ShortDatePattern = "MM/dd/yyyy";
                dtformat.DateSeparator = "/";

                DateTime date1 = Convert.ToDateTime(date, dtformat);

                strUserPickTimeInfo = Convert.ToString(date1) + "!*@!" + Convert.ToString(drpFutureDateTime.SelectedValue);

                if (ViewState["IsPickUp"] != null)
                {
                    if (!Convert.ToBoolean(ViewState["IsPickUp"].ToString()))
                    {
                        HttpCookie StoreLocationId = new HttpCookie("StoreLocationId", "0");
                        Response.Cookies.Add(StoreLocationId);
                        CreateUserShopAddInfoCookie(strUserPickTimeInfo);
                        Response.Redirect("tipping.aspx", false);
                    }
                    else
                    {
                        strUserPickTimeInfo += "!*@!" + Convert.ToString(ViewState["TodaysDelivery"]);
                        CreateUserShopAddInfoCookie(strUserPickTimeInfo);

                        HttpCookie strUserTipping = new HttpCookie("strUserTipping", "1!*@!0");
                        Response.Cookies.Add(strUserTipping);
                        Response.Redirect("Payment.aspx", false);
                    }
                }
                else
                {
                    HttpCookie StoreLocationId = new HttpCookie("StoreLocationId", "0");
                    Response.Cookies.Add(StoreLocationId);
                    CreateUserShopAddInfoCookie(strUserPickTimeInfo);
                    Response.Redirect("tipping.aspx", false);
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.selectDeliverytime;
            }
        }

        private void CreateUserShopAddInfoCookie(string strUserPickTimeInfo)
        {
            HttpCookie strUserPickTime = new HttpCookie("UserShopAddInfo", strUserPickTimeInfo);
            Response.Cookies.Add(strUserPickTime);
        }

        public string MonthName(string strMonth)
        {
            string strReturn = string.Empty;

            switch (strMonth)
            {
                case "1":
                    strReturn = "January";
                    break;
                case "2":
                    strReturn = "February";
                    break;
                case "3":
                    strReturn = "March";
                    break;
                case "4":
                    strReturn = "April";
                    break;
                case "5":
                    strReturn = "May";
                    break;
                case "6":
                    strReturn = "June";
                    break;
                case "7":
                    strReturn = "July";
                    break;
                case "8":
                    strReturn = "August";
                    break;
                case "9":
                    strReturn = "September";
                    break;
                case "10":
                    strReturn = "October";
                    break;
                case "11":
                    strReturn = "November";
                    break;
                case "12":
                    strReturn = "December";
                    break;
            }

            return strReturn;
        }

        protected void rdChkTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intCheck = 0;
            string strNew = string.Empty;
            string strDeliveryCntId = string.Empty;

            foreach (DataListItem dtList in dtlDeliveryGrid.Items)
            {
                RadioButtonList rdList;
                rdList = (RadioButtonList)dtList.FindControl("rdChkTime");

                Label lblDelId;
                lblDelId = (Label)dtList.FindControl("lblDelId");

                Label lblDelDate;
                lblDelDate = (Label)dtList.FindControl("lblDelDate");

                for (int i = 0; i < rdList.Items.Count; i++)
                {
                    if (rdList.Items[i].Selected == true)
                    {
                        if (Convert.ToString(ViewState["SelectedValue"]) == "")
                        {
                            strNew = lblDelId.Text;
                            intCheck = 1;
                            ViewState["DelDate"] = lblDelDate.Text;
                        }
                        else
                        {
                            if (Convert.ToString(ViewState["SelectedValue"]) != lblDelId.Text)
                            {
                                ViewState["DelDate"] = lblDelDate.Text;
                                strNew = lblDelId.Text;
                                intCheck = 1;
                            }
                        }
                    }
                }
            }

            strDeliveryCntId = strNew;

            if (intCheck == 1)
            {
                foreach (DataListItem dtList in dtlDeliveryGrid.Items)
                {
                    RadioButtonList rdList;
                    rdList = (RadioButtonList)dtList.FindControl("rdChkTime");

                    Label lblDelId;
                    lblDelId = (Label)dtList.FindControl("lblDelId");

                    if (lblDelId.Text != strDeliveryCntId)
                    {
                        for (int i = 0; i < rdList.Items.Count; i++)
                        {
                            rdList.Items[i].Selected = false;
                        }
                    }
                }
            }

            ViewState["SelectedValue"] = strNew;
            strNew = "";
            intCheck = 0;
        }

        protected void drpFutureDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDeliveryInfo();

            string delivery_id = drpFutureDate.SelectedValue.ToString();

            if (delivery_id.Equals("Select"))
            {
                dropState.dispose();
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
            else
            {
                Panel2.Visible = false;
                Panel1.Visible = true;
                dropState.bindFutureDateTime(drpFutureDateTime, delivery_id);
            }
        }
        public void BindOneHourDeliveryInfo()
        {
            string strTimeNm = string.Empty;
            strTimeNm = lblCurrentTime.Text + "  - " + lblNextTime.Text;
            ViewState["Time"] = strTimeNm;
        }

        public void BindDeliveryInfoHours()
        {
            int totalTime = 0;
            int TimeId = 0;
            string strTimeNm = string.Empty;
            string strStartTime = string.Empty;
            string strAmPm = string.Empty;
            string strEndTime = string.Empty;
            string strPMAM = string.Empty;
            int intStartTime = 0;
            int intEndTime = 0;
            string strdate = string.Empty;
            string strmonth = string.Empty;
            string strday = string.Empty;
            string stryear = string.Empty;
            string strTodayDeldate = string.Empty;
            string strTodaysDateTime = string.Empty;

            DataTable dtTodaysTime = new DataTable();
            DataRow rowTodaysTime;
            dtTodaysTime.Columns.Add("TimeNm");
            dtTodaysTime.Columns.Add("TimeId");

            totalTime = Convert.ToInt32(lblTime.Text) + 4;

            DataSet dsSelectTime = new DataSet();
            DataSet dsSelectTimeInfo = new DataSet();

            dsSelectTime = dbInfo.GetDelveryTimeHours(Convert.ToInt32(totalTime));
            dsSelectTimeInfo = dbInfo.GetDeliveryTimeHoursInfo(Convert.ToInt32(totalTime));

            if (dsSelectTime.Tables.Count > 0)
            {
                if (dsSelectTime != null && dsSelectTime.Tables.Count > 0 && dsSelectTime.Tables[0].Rows.Count > 0)
                {
                    gridTimeInfo.DataSource = dsSelectTimeInfo;
                    gridTimeInfo.DataBind();

                    foreach (DataRow dtrowTime in dsSelectTime.Tables[0].Rows)
                    {
                        TimeId = Convert.ToInt32(dtrowTime["TimeId"]);

                        if (Convert.ToInt32(dtrowTime["StartTime"]) > 12)
                        {
                            intStartTime = Convert.ToInt32(dtrowTime["StartTime"]) - 12;
                        }
                        else
                        {
                            intStartTime = Convert.ToInt32(dtrowTime["StartTime"]);
                        }

                        strAmPm = Convert.ToString(dtrowTime["AM_PM"]);

                        if (Convert.ToInt32(dtrowTime["EndTime"]) > 12)
                        {
                            intEndTime = Convert.ToInt32(dtrowTime["EndTime"]) - 12;
                        }
                        else
                        {
                            intEndTime = Convert.ToInt32(dtrowTime["EndTime"]);
                        }

                        strPMAM = Convert.ToString(dtrowTime["PM_AM"]);

                        strTimeNm = intStartTime + " " + strAmPm + " - " + intEndTime + " " + strPMAM;

                        rowTodaysTime = dtTodaysTime.NewRow();
                        rowTodaysTime["TimeId"] = TimeId;
                        rowTodaysTime["TimeNm"] = strTimeNm;
                        dtTodaysTime.Rows.Add(rowTodaysTime);
                    }

                    foreach (GridViewRow gridtime in gridTimeInfo.Rows)
                    {
                        if (dsSelectTime.Tables.Count > 0)
                        {
                            if (dsSelectTime != null && dsSelectTime.Tables.Count > 0 && dsSelectTime.Tables[0].Rows.Count > 0)
                            {
                                RadioButtonList rdTimeList;
                                rdTimeList = (RadioButtonList)gridtime.FindControl("rdBtnChkTime");
                                rdTimeList.DataSource = dtTodaysTime;
                                rdTimeList.DataTextField = "TimeNm";
                                rdTimeList.DataValueField = "TimeId";
                                rdTimeList.DataBind();

                                Label lblNmTime = (Label)gridtime.FindControl("lblNmTime");

                                DateTime dttoday = DateTime.Now;

                                strmonth = MonthName(dttoday.Month.ToString());
                                strdate = dttoday.Day.ToString();
                                strday = dttoday.DayOfWeek.ToString();
                                stryear = dttoday.Year.ToString();
                                strTodayDeldate = strday + ", " + strmonth + " " + strdate + ", " + stryear;
                                strTodaysDateTime = Convert.ToString(dttoday);

                                ViewState["TodaysDelDate"] = strTodaysDateTime;
                            }
                        }
                    }

                    pnlDelivery.Visible = false;
                    pnlDeldate.Visible = false;
                    pnlFutureDate.Visible = false;
                    trFuture.Visible = false;
                    ViewState["TodaysDelivery"] = drpDelivery.SelectedValue;
                    pnlTodaysDelivery.Visible = true;
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.strNoTodaysDelivery;
                    pnlTodaysDelivery.Visible = false;
                    btnSubmit.Visible = false;
                    gridTimeInfo.Visible = false;
                    pnlDeliveryType.Visible = true;
                }
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.strNoTodaysDelivery;
                pnlTodaysDelivery.Visible = false;
                btnSubmit.Visible = false;
                gridTimeInfo.Visible = false;
                pnlDeliveryType.Visible = true;
            }

            dbInfo.dispose();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int intTimeChk = 0;
            int intInsertDate = 0;

            foreach (GridViewRow gridtime in gridTimeInfo.Rows)
            {
                RadioButtonList rdTimeList;
                rdTimeList = (RadioButtonList)gridtime.FindControl("rdBtnChkTime");

                for (int i = 0; i < rdTimeList.Items.Count; i++)
                {
                    if (rdTimeList.Items[i].Selected == true)
                    {
                        ViewState["TodaysDelTime"] = rdTimeList.Items[i].Value;
                        intTimeChk = 1;
                    }
                }
            }

            if (intTimeChk == 1)
            {
                lblMsg.Visible = false;
                lblMsg.Text = "";

                string strUserShopInfo = string.Empty;
                string strShopInfo = string.Empty;

                DateTime dtDate = DateTime.Now;

                int intlocationid = 1;
                int checkDateAlreadyExit = 0;
                string strdate = string.Empty;
                strdate = Convert.ToString(dtDate.ToShortDateString());

                //checkDateAlreadyExit = dbAddInfo.DeliveryDateAlreadyExist(Convert.ToString(strdate));

                //if (checkDateAlreadyExit == 0)
                //{
                //    intInsertDate = dbAddInfo.InsertDeliveryDateInfo(Convert.ToDateTime(strdate), intlocationid);
                //}
                //else
                //{
                //    lblMsg.Text = "";
                //    lblMsg.Text = AppConstants.deliveryDateAlreadyExist;
                //    lblMsg.ForeColor = System.Drawing.Color.Red;
                //}

                if (ViewState["IsPickUp"] != null)
                {
                    if (Convert.ToBoolean(ViewState["IsPickUp"].ToString()))
                    {
                        strUserPickTimeInfo = Convert.ToString(ViewState["TodaysDelDate"]) + "!*@!" + Convert.ToString(ViewState["TodaysDelTime"]) + "!*@!" + Convert.ToString(ViewState["TodaysDelivery"]);
                        CreateUserShopAddInfoCookie(strUserPickTimeInfo);
                        CreateStoreLocationCookie();
                        HttpCookie strUserTipping = new HttpCookie("strUserTipping", "1!*@!0");
                        Response.Cookies.Add(strUserTipping);
                        Response.Redirect("payment.aspx", false);
                    }
                    else
                    {
                        strUserPickTimeInfo = Convert.ToString(ViewState["TodaysDelDate"]) + "!*@!" + Convert.ToString(ViewState["TodaysDelTime"]);
                        CreateUserShopAddInfoCookie(strUserPickTimeInfo);

                        HttpCookie cookie = new HttpCookie("StoreLocationId", "0");
                        Response.Redirect("Tipping.aspx", false);
                    }
                }
                else
                {
                    strUserPickTimeInfo = Convert.ToString(ViewState["TodaysDelDate"]) + "!*@!" + Convert.ToString(ViewState["TodaysDelTime"]);
                    CreateUserShopAddInfoCookie(strUserPickTimeInfo);
                    Response.Redirect("Tipping.aspx", false);
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.selectDeliverytime;
            }
        }

        protected void btnImmdiateDelSubmit_Click(object sender, EventArgs e)
        {
            int intInsertDate = 0;
            string strTime = string.Empty;

            lblMsg.Visible = false;
            lblMsg.Text = "";

            string strUserShopInfo = string.Empty;
            string strShopInfo = string.Empty;

            DateTime dtDate = DateTime.Now;

            int intlocationid = 1;
            int checkDateAlreadyExit = 0;
            string strdate = string.Empty;
            string strmonth = string.Empty;
            string strday = string.Empty;
            string stryear = string.Empty;
            string strTodayDeldate = string.Empty;
            string strTodaysDateTime = string.Empty;
            DateTime dttoday = DateTime.Now;

            strmonth = MonthName(dttoday.Month.ToString());
            strdate = dttoday.Day.ToString();
            strday = dttoday.DayOfWeek.ToString();
            stryear = dttoday.Year.ToString();
            strTodayDeldate = strday + ", " + strmonth + " " + strdate + ", " + stryear;
            strTodaysDateTime = Convert.ToString(dttoday);
            ViewState["TodaysDelDate"] = strTodaysDateTime;

            string strImmdiatedate = string.Empty;

            ViewState["TodaysDelTime"] = txtImmediatedel.Text;
            strImmdiatedate = Convert.ToString(dtDate.ToShortDateString());
            checkDateAlreadyExit = dbAddInfo.DeliveryDateAlreadyExist(Convert.ToString(strImmdiatedate));

            if (checkDateAlreadyExit == 0)
            {
                intInsertDate = dbAddInfo.InsertDeliveryDateInfo(Convert.ToDateTime(strImmdiatedate), intlocationid);
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.deliveryDateAlreadyExist;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

            strUserPickTimeInfo = Convert.ToString(ViewState["TodaysDelDate"]) + "!*@!" + Convert.ToString(ViewState["TodaysDelTime"]) + "!*@!" + Convert.ToString(ViewState["TodaysDelivery"]);

            HttpCookie strUserPickTime = new HttpCookie("UserShopAddInfo", strUserPickTimeInfo);
            Response.Cookies.Add(strUserPickTime);

            CreateStoreLocationCookie();

            Response.Redirect("payment.aspx", false);
        }

        protected void CreateStoreLocationCookie()
        {
            string StoreLocationId1 = ddlstoreLocation.SelectedValue.ToString();

            if (StoreLocationId1 == "")
                StoreLocationId1 = "0";

            HttpCookie StoreLocationId = new HttpCookie("StoreLocationId", StoreLocationId1);
            Response.Cookies.Add(StoreLocationId);
        }

        protected void ddlDeliveryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDeliveryType.Visible = false;

            if (ddlDeliveryType.SelectedIndex == 1)
            {
                BindDeliveryInfo();

                HttpCookie IsSameDay = new HttpCookie("IsSameDay", "false");
                Response.Cookies.Add(IsSameDay);
            }
            else if (ddlDeliveryType.SelectedIndex == 2)
            {
                HttpCookie IsSameDay = new HttpCookie("IsSameDay", "true");
                Response.Cookies.Add(IsSameDay);

                BindDeliveryInfoHours();
                BindDeliveryInfoPickUp();
            }
        }

        protected void drpDelivery_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(drpDelivery.SelectedValue) == "1")
                {
                    ViewState["IsPickUp"] = false;
                    txtImmediatedel.Visible = true;
                    BindOneHourDeliveryInfo();
                    getServerTime();

                    txtImmediatedel.Text = Convert.ToString(ViewState["Time"]);

                    pnlImmediateDelivery.Visible = true;
                    pnlDelivery.Visible = false;
                    pnlDeldate.Visible = false;
                    pnlFutureDate.Visible = false;
                    trFuture.Visible = false;

                    ViewState["TodaysDelivery"] = drpDelivery.SelectedValue;

                    pnlStoreLocation.Visible = false;
                }
                else if (Convert.ToString(drpDelivery.SelectedValue) == "2")
                {
                    ViewState["IsPickUp"] = true;

                    BindDeliveryType();
                    pnlDeliveryType.Visible = false;
                    pnlDelivery.Visible = false;
                    pnlDeldate.Visible = false;
                    pnlFutureDate.Visible = false;
                    trFuture.Visible = false;
                    ViewState["TodaysDelivery"] = drpDelivery.SelectedValue;
                    pnlStoreLocation.Visible = true;
                }
                else if (Convert.ToString(drpDelivery.SelectedValue) == "3")
                {
                    ViewState["IsPickUp"] = false;

                    BindDeliveryType();

                    pnlDelivery.Visible = false;
                    pnlTodaysDelivery.Visible = false;
                    ViewState["TodaysDelivery"] = drpDelivery.SelectedValue;
                    pnlStoreLocation.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        protected void ddlStoreLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstoreLocation.SelectedIndex > 0)
            {
                pnlDeliveryType.Visible = true;
                pnlStoreLocation.Visible = false;

                CreateStoreLocationCookie();
            }
        }

        private void BindDeliveryType()
        {
            pnlDeliveryType.Visible = true;

            string delInfo = String.Empty;

            if (ViewState["IsPickUp"] != null)
            {
                if (Convert.ToBoolean(ViewState["IsPickUp"].ToString()))
                {
                    delInfo = " Pick Up";
                }
                else
                {
                    delInfo = " Delivery";
                }
            }

            DataSet ds = new DataSet();
            ds = dbAddInfo.GetDeliveryType();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    row["DeliveryName"] += delInfo;
                }

                ddlDeliveryType.DataSource = ds;
                ddlDeliveryType.DataTextField = "DeliveryName";
                ddlDeliveryType.DataValueField = "DeliInfoID";
                ddlDeliveryType.DataBind();
            }
        }
    }
}
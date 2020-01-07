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
using System.Text;
using System.IO;
using CyberValetGrocery.Class;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;

namespace CyberValetGrocery
{
    public partial class UserLogout : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strShopping = string.Empty;

            DataSet dsDeleteInfo = dbInfo.DeleteAddressInfo(Convert.ToInt32(Request.Cookies["userId"].Value));

            HttpCookie myCookie = new HttpCookie("userId");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);

            if (Request.Cookies["strUserPickTime"] != null)
                if (Request.Cookies["strUserPickTime"].Value != "")
                {
                    HttpCookie strUserPickTime = new HttpCookie("strUserPickTime", null);
                    Response.Cookies.Add(strUserPickTime);
                }

            if (Request.Cookies["strUserTipping"] != null)
                if (Request.Cookies["strUserTipping"].Value != "")
                {
                    HttpCookie strUserTipping = new HttpCookie("strUserTipping");
                    strUserTipping.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(strUserTipping);
                }

            if (Request.Cookies["StoreLocationId"] != null)
                if (Request.Cookies["StoreLocationId"].Value != "")
                {
                    HttpCookie strUserTipping = new HttpCookie("StoreLocationId");
                    strUserTipping.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(strUserTipping);
                }

            if (Request.Cookies["IsSameDay"] != null)
                if (Request.Cookies["IsSameDay"].Value != "")
                {
                    HttpCookie isSameDay = new HttpCookie("IsSameDay");
                    isSameDay.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(isSameDay);
                }

            if (Request.Cookies["UserShopAddInfo"] != null)
            {
                HttpCookie UserShopAddInfo = new HttpCookie("UserShopAddInfo");
                UserShopAddInfo.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(UserShopAddInfo);
            }


            HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", null);

            Response.Cookies.Add(ShoppingCart);      

            HttpCookie PaypalShopping = new HttpCookie("PaypalShopping", null);
            Response.Cookies.Add(PaypalShopping);

            HttpCookie DepositFund = new HttpCookie("DepositFund", null);
            Response.Cookies.Add(DepositFund);

            //HttpCookie StrShipping = new HttpCookie("UserShopAddInfo", null);
            //Response.Cookies.Add(StrShipping);
            //HttpCookie UserShopAddInfo = new HttpCookie("UserShopAddInfo", null);
            //Response.Cookies.Add(UserShopAddInfo);

            HttpCookie emailcount = new HttpCookie("emailcount", null);
            emailcount.Expires = DateTime.Now.AddDays(-1d);

            Response.Cookies.Add(emailcount);


            Session.Remove("LoginUserName");
            Session.RemoveAll();

            Response.Redirect("index.aspx", false);



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CyberValetGrocery.Admin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["adminId"] != null)
                {
                    HttpCookie myCookieadmin = new HttpCookie("adminId");
                    myCookieadmin.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookieadmin);
                }    
                Session.Remove("adminFName");
                Session.RemoveAll();
               // Request.Cookies.Clear();
               // Request.Cookies.Remove("adminId");                
                Response.Redirect("index.aspx", false);
               
            }

        }
    }
}

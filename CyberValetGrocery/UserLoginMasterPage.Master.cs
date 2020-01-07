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

namespace CyberValetGrocery
{
    public partial class UserLoginMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getCompanyName();
         
            if (Request.Cookies["userId"] == null || Request.Cookies["userId"].Value == "")
            {
                pnlLogin.Visible = true;
                pnlLoged.Visible = false;
              

            }
            else
            {   getUserFirstName();
                pnlLogin.Visible = false;
                pnlLoged.Visible = true;
            }

        }
        public void getUserFirstName()
        {
            DbProvider dbGetEmailAddress = new DbProvider();
            DataSet dsEmailAddress = new DataSet();
            dsEmailAddress = dbGetEmailAddress.GetUserUserFistNameForWelcome(Convert.ToInt32(Request.Cookies["userId"].Value));

            if (dsEmailAddress.Tables.Count > 0)
            {
                if (dsEmailAddress != null && dsEmailAddress.Tables.Count > 0 && dsEmailAddress.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsEmailAddress.Tables[0].Rows)
                    {

                        lblUserFirstName.Text = Convert.ToString(dtrow["users_fname"]);



                    }
                }
            }


            dbGetEmailAddress.dispose();


        }

        public void getCompanyName()
        {

            DbProvider dbGetCompanyName = new DbProvider();
            DataSet dsGetCompanyName = new DataSet();
            DataSet dsGetHomePageTxt = new DataSet();


            dsGetCompanyName = dbGetCompanyName.getShortCompanyName();

            if (dsGetCompanyName.Tables.Count > 0)
            {
                if (dsGetCompanyName != null && dsGetCompanyName.Tables.Count > 0 && dsGetCompanyName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetCompanyName.Tables[0].Rows)
                    {
                       
                      // lblCmpNm.Text = Convert.ToString(dtrow["CompanyShortName"]);
                       


                    }
                }
            }


            dbGetCompanyName.dispose();

            

        }

    }
}

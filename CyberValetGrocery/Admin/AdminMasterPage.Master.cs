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
using System.Data.SqlClient;

namespace CyberValetGrocery.Admin
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        DbProvider dbloginInfo = new DbProvider();
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.Cookies["adminId"] == null)
            {
                Response.Redirect("index.aspx", true);
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["adminId"] == null)
            {
                Response.Redirect("index.aspx", false);
            }
            else
            {
            }
        }
       
        public string RemoveSpaceFunction(string str)
        {
            string strRerurn = string.Empty;
            
            string[] strSplit = new string[2];
            string[] strNewSplit1 = new string[2];
            string[] strNewSplit2 = new string[2];
            string strNewFirstPart1=string.Empty;
            char[] splitter = { ' ' };
            strSplit = str.Split(splitter);
            string firstPart = Convert.ToString(strSplit[0]);

            string secondPart = Convert.ToString(strSplit[1]);

            if (secondPart != "")
            {


                //if (secondPart.IndexOf[0] == "(")
                //{
                    char[] splitterNew = { '(' };
                    strNewSplit1 = secondPart.Split(splitterNew);
                    string strNewFirstPart = Convert.ToString(strNewSplit1[0]);
                    string strNewSecondPart = Convert.ToString(strNewSplit1[1]);
                    char[] splitterNew1 = { ')' };
                    strNewSplit2 = strNewSecondPart.Split(splitterNew1);
                    strNewFirstPart1 = Convert.ToString(strNewSplit2[0]);
                    string strNewSecondPart1 = Convert.ToString(strNewSplit2[1]);
                //}
                //else
                //{
                //    strNewFirstPart1 = secondPart;
                //}

            }
            if (strNewFirstPart1 != "")
            {
                strRerurn = firstPart + strNewFirstPart1;
            }
            else
            {
                strRerurn = firstPart;
            }
            
           
            return strRerurn;
        }

       

       
    }
}

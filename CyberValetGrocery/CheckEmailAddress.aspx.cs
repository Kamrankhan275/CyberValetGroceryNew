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

namespace CyberValetGrocery
{
    public partial class CheckEmailAddress : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string res = CheckUserNameAvailability();
                Response.Write(res);
                Response.End();
            }
            catch (System.Threading.ThreadAbortException)
            {
                
            }
        }

       
        public string CheckUserNameAvailability()
        {
            string uname = string.Empty;
            string result = string.Empty;
            int user_Id=0;
            DataSet dsEmail = new DataSet();
            uname = Request.QueryString["Email"];
            if (uname != null)
            {


                dsEmail = dbInfo.GetUserEmailInfo(uname);
                if (dsEmail.Tables.Count > 0)
                {
                    if (dsEmail != null && dsEmail.Tables.Count > 0 && dsEmail.Tables[0].Rows.Count > 0)
                    {
                        user_Id = Convert.ToInt32(dsEmail.Tables[0].Rows[0]["users_id"]);

                    }
                }

              
                if (user_Id != 0)
                {
                    result = "False";
                }
                else
                {
                    result = "True";
                }
                dbInfo.dispose();
            }

            return result;
        }
    }
}

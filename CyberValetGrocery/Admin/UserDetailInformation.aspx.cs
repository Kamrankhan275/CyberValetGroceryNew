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

namespace CyberValetGrocery.Admin
{
    public partial class UserDetailInformation : System.Web.UI.Page
    {
        DbProvider dbloginInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                   
                    Bind();
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        public void Bind()
        {
           
            string strName = string.Empty;

            int userId = Convert.ToInt32(Request.QueryString["userId"]);
             DataSet dsUserList = new DataSet();
             dsUserList = dbloginInfo.GetHomeUserInformation(userId);
            if (dsUserList.Tables.Count > 0)
            {
                if (dsUserList != null && dsUserList.Tables.Count > 0 && dsUserList.Tables[0].Rows.Count > 0)
                {
                    strName = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_lname"]) + " " + Convert.ToString(dsUserList.Tables[0].Rows[0]["users_fname"]);
                    lblName.Text = strName;
                    lblEmail.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_email"]);
                    lblAddress1.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_address1"]);
                    lblPhone.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_phone"]);
                    lblState.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_state"]);
                    lblZip.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_zip"]);
                    lblCity.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_city"]);
                    lblAddress2.Text = Convert.ToString(dsUserList.Tables[0].Rows[0]["users_address2"]);
                }
            }

           



           
           



        }
    }


}


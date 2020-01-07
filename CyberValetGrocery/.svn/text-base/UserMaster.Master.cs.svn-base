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
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        DbProvider dbListInfo = new DbProvider();       
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtSearch.Attributes.Add("onkeypress", "clcontentFocus(event)");

            txtSearch.Attributes.Add("onKeyPress", "doClick('" + btnGo.ClientID + "',event)");
            if (!IsPostBack)
            {
              
                if (Request.Cookies["userId"] == null)
                {
                    pnlLogin.Visible = true;
                
                    pnlLoged.Visible = false;
                    lblSerMsg.Visible = true;
                    lblSerMsg.Text = "";

                }
                else
                { 
                    getUserFirstName();
                    lblSerMsg.Visible = true;
                    lblSerMsg.Text = "";
                    pnlLogin.Visible = false;
                    pnlLoged.Visible = true;
                }
                BindAisles();
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

        public void BindAisles()
        {


            DataSet dsAislesList = new DataSet();
            string strAisleName = string.Empty;
            dsAislesList = dbListInfo.GetAllUserAislesDeatils();
           
            if (dsAislesList.Tables.Count > 0)
            {
                 
                if (dsAislesList != null && dsAislesList.Tables.Count > 0 && dsAislesList.Tables[0].Rows.Count > 0)
                {
                    dtlCatgory.DataSource = dsAislesList;
                    dtlCatgory.DataBind();
                    foreach (DataListItem Dtl in dtlCatgory.Items)
                    {

                        Label lblAisleText = (Label)Dtl.FindControl("lblAisleText");

                        strAisleName = Convert.ToString(lblAisleText.Text);
                        if (Convert.ToString(strAisleName) == "Wine & Spirits")
                        {                          
                              lblAisleText.CssClass = "LinkRed";
                           
                        }
                        if (Convert.ToString(strAisleName) == "Buon Giorno Italia")
                        {
                            lblAisleText.CssClass = "LinkRed";

                        }

                    }
                   
                }
                
            }
            dbListInfo.dispose();

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string strSearch = string.Empty;
            int intChk = 0;
            strSearch = txtSearch.Text;
            if (strSearch == "#")
            {
                intChk = 1;
            }
            else if (strSearch == "&")
            {
                intChk = 2;
            }
            Response.Redirect("searchresults.aspx?intChk=" + intChk + "&keyword=" + strSearch, false);

        }
        }
    }

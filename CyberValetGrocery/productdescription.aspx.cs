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
    public partial class productdescription : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {



                DataSet dsList = new DataSet();

                if (!IsPostBack)
                {
                    string image = string.Empty;
                    string image2 = string.Empty;
                    int prodId = 0;
                    prodId = Convert.ToInt32(Request.QueryString["prodId"]);
                    dsList = dbInfo.SelectProductInfoDeatils(prodId);

                    if (dsList.Tables.Count > 0)
                    {
                        if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                        {
                            lblProdNm.Text = Convert.ToString(dsList.Tables[0].Rows[0]["product_title"]);
                            if (Convert.ToString(dsList.Tables[0].Rows[0]["product_description"]) != "")
                            {
                                lblDesc.Text = Convert.ToString(dsList.Tables[0].Rows[0]["product_description"]);
                                lblDesc.ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                lblDesc.Text = AppConstants.pgNoDescription;
                                lblDesc.ForeColor = System.Drawing.Color.Red;

                            }

                            image = Convert.ToString(dsList.Tables[0].Rows[0]["product_image"]);
                            image2 = Convert.ToString(dsList.Tables[0].Rows[0]["product_image2"]);
                            if (image2 == "" || image2 == null)
                            {

                                if (image != "")
                                {
                                    imgPopProduct.ImageUrl = "~/Product/" + image;
                                }
                                else
                                {
                                    imgPopProduct.ImageUrl = "~/Product/no_image.gif";
                                }
                            }
                            else
                            {
                                imgPopProduct.ImageUrl = "~/Product/" + image2;


                            }
                            if (Convert.ToString(dsList.Tables[0].Rows[0]["product_size"]) != "")
                            {
                                pnlSze.Visible = true;
                                lblSize.Text = Convert.ToString(dsList.Tables[0].Rows[0]["product_size"]);
                            }
                            else
                            {
                                pnlSze.Visible = false;

                            }
                        }
                    }



                }

                dbInfo.dispose();


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

        }
    }
}

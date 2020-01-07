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
    public partial class UserSavedListDetails : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int intListId = Convert.ToInt32(Request.QueryString["listId"]);

                    BindGrid();

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }


        public void BindGrid()
        {
          
            string image = string.Empty;           
            DataSet dsProductList = new DataSet();
            double price = 0;           
            double totalPrice = 0;

            int intListId = Convert.ToInt32(Request.QueryString["listId"]);

            dsProductList = dbListInfo.GetSavedListProductInfo(intListId, Convert.ToInt32(AppConstants.locationId));
            if (dsProductList.Tables.Count > 0)
            {
                if (dsProductList != null && dsProductList.Tables.Count > 0 && dsProductList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsProductList.Tables[0].Rows)
                    {

                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }
                        price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                        dtrow["productlink_price"] = Convert.ToString(price);
                        totalPrice = totalPrice + (price * Convert.ToDouble(dtrow["listlink_qty"]));                       

                    }

                    lblSubTot.Visible = true;
                    //lblTotal.Text = Convert.ToString(totalPrice);
                    lblTotal.Text = Convert.ToDecimal(totalPrice).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    gridSavedListDetails.DataSource = dsProductList;
                    gridSavedListDetails.DataBind();


                }
                else
                {
                    gridSavedListDetails.Visible = false;
                    lblSubTot.Visible = false;
                    lblTotal.Text = "";
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gridSavedListDetails.Visible = false;
                lblSubTot.Visible = false;
                lblTotal.Text = "";
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }


        }

        public string Thumbnail(string imgName)
        {
            string urlThumbnail = string.Empty;
            if (imgName != "")
            {

                urlThumbnail = "thumbnailmainimage.aspx?imgName=" + imgName;

            }
            return urlThumbnail;
        }

        protected void gridSavedListDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridSavedListDetails.PageIndex = e.NewPageIndex;
            BindGrid();

        }
    }
}

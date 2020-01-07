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
    public partial class DeliveryDateInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int deliveryId = Convert.ToInt32(Request.QueryString["deliveryId"]);

                  

                    if (deliveryId == 1)
                    {

                        lblDate.Text = "5/3/2010";
                    }
                    if (deliveryId == 2)
                    {

                        lblDate.Text = "4/30/2010";
                    }

                    if (deliveryId == 3)
                    {

                        lblDate.Text = "4/28/2010";
                    }

                    if (deliveryId == 4)
                    {

                        lblDate.Text = "4/17/2010";
                    }

                    if (deliveryId == 5)
                    {

                        lblDate.Text = "4/15/2010";
                    }

                    BindGrid(deliveryId);


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
        public void BindGrid(int intListId)
        {
            DataTable dtDate = new DataTable();
            DataRow rowDateDetail;
            dtDate.Columns.Add("DeliveryTime");
            dtDate.Columns.Add("CutOff");
            dtDate.Columns.Add("Capacity");

            rowDateDetail = dtDate.NewRow();
            rowDateDetail["DeliveryTime"] = "4pm-5pm";
            rowDateDetail["CutOff"] = "02:00 AM";
            rowDateDetail["Capacity"] = "4";
            dtDate.Rows.Add(rowDateDetail);



            rowDateDetail = dtDate.NewRow();
            rowDateDetail["DeliveryTime"] = "5pm-6pm";
            rowDateDetail["CutOff"] = "03:00 AM";
            rowDateDetail["Capacity"] = "5";
            dtDate.Rows.Add(rowDateDetail);



            rowDateDetail = dtDate.NewRow();
            rowDateDetail["DeliveryTime"] = "6pm-7pm";
            rowDateDetail["CutOff"] = "02:00 AM";
            rowDateDetail["Capacity"] = "3";
            dtDate.Rows.Add(rowDateDetail);

            gridDeliveryDetails.DataSource = dtDate;
            gridDeliveryDetails.DataBind();
        }
        protected void gridDeliveryDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDeliveryDetails.PageIndex = e.NewPageIndex;
            int deliveryId = Convert.ToInt32(Request.QueryString["deliveryId"]);
            BindGrid(deliveryId);


        }
    }
}







          

               








           

        

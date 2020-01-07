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
    public partial class DeliverySchedulePrint : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strDate = string.Empty;                    
                    strDate = Convert.ToString(Request.QueryString["date"]);
                    lblDate.Text = strDate;
                    BindGrid();

                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }



        }

        public void BindGrid()
        {
           
            string strDate = string.Empty;
            int locId = 0;
            double tips=0;
            strDate = Convert.ToString(Request.QueryString["date"]);
            locId = Convert.ToInt32(Request.QueryString["locId"]);
            DataSet dsDeliveryDateList = new DataSet();
            dsDeliveryDateList = dbListInfo.GetDeliverySheduleDetails(strDate, locId);
            if (dsDeliveryDateList.Tables.Count > 0)
            {
                if (dsDeliveryDateList != null && dsDeliveryDateList.Tables.Count > 0 && dsDeliveryDateList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsDeliveryDateList.Tables[0].Rows)
                    {

                        dtrow["orders_grocerytotal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_grocerytotal"]), 2));
                        dtrow["orders_deliveryfee"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_deliveryfee"]), 2));
                        dtrow["orders_tax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tax"]), 2));
                        tips = Math.Round(Convert.ToDouble(dtrow["orders_tip"]), 2);
                        if (tips == 0 || tips == 0.00)
                        {
                            double strString = 0;
                            dtrow["orders_tip"] = Convert.ToString(strString);
                        }
                        else
                        {
                            dtrow["orders_tip"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tip"]), 2));


                        }
                        dtrow["orders_totalfinal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));
                        if (Convert.ToString(dtrow["orders_paymenttype"]) == "AF")
                        {
                            dtrow["orders_complimentary"] = Convert.ToString(0.00);

                        }
                        else if (Convert.ToString(dtrow["orders_paymenttype"]) == "AF-CC")
                        {
                            dtrow["orders_complimentary"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_complimentary"]), 2));

                        }
                        else
                        {
                            dtrow["orders_complimentary"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));

                        }

                    }

                    gridDeliveryList.DataSource = dsDeliveryDateList;
                    gridDeliveryList.DataBind();
                    for (int i = 0; i < gridDeliveryList.Rows.Count; i++)
                    {
                        Label lblTip;
                       GridViewRow item = gridDeliveryList.Rows[i];
                       lblTip = (Label)item.FindControl("lblTip");
                       if (lblTip.Text == "0")
                       {
                           lblTip.Visible = false;

                       }
                    }
                }
                else
                {
                    gridDeliveryList.Visible = false;
                    
                }
            }
            else
            {
                gridDeliveryList.Visible = false;                
            }



        }
    }
}

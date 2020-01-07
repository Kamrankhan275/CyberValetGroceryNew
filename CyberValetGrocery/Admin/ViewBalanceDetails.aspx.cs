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
    public partial class ViewBalanceDetails : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                try
                {
                   
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
            int userId = 0;
            userId = Convert.ToInt32(Request.QueryString["userId"]);
            double amt = 0;
            DataSet dsBalanceList = new DataSet();
            dsBalanceList = dbListInfo.GetBalanceReportsDeatilsInfo(userId);
            if (dsBalanceList.Tables.Count > 0)
            {
                if (dsBalanceList != null && dsBalanceList.Tables.Count > 0 && dsBalanceList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsBalanceList.Tables[0].Rows)
                    {
                        amt = Math.Round(Convert.ToDouble(dtrow["transactions_amount"]), 2);
                        dtrow["transactions_amount"] = Convert.ToString(amt);
                    }
                    gridBalanceDetails.DataSource = dsBalanceList;
                    gridBalanceDetails.DataBind();

                }
                else
                {
                    gridBalanceDetails.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gridBalanceDetails.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }





        }

        protected void gridBalanceDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridBalanceDetails.PageIndex = e.NewPageIndex;           
            BindGrid();
        }
    }
}

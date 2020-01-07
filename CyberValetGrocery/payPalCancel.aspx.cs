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
using System.Text;
using System.IO;
using CyberValetGrocery.Class;

namespace CyberValetGrocery
{
    public partial class payPalCancel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getCompanyName();
            if (!IsPostBack)
            {
              //  int orderCancelUpdate = _dbpCancelOrder.userCancelPaypalOrder(Convert.ToInt32(Session["cartOrderAdded"]));

            }

        }

        //Function for get short company name for page title
        public void getCompanyName()
        {

            DbProvider dbGetCompanyName = new DbProvider();
            DataSet dsGetCompanyName = new DataSet();

            dsGetCompanyName = dbGetCompanyName.getShortCompanyName();

            if (dsGetCompanyName.Tables.Count > 0)
            {
                if (dsGetCompanyName != null && dsGetCompanyName.Tables.Count > 0 && dsGetCompanyName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetCompanyName.Tables[0].Rows)
                    {
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgPayPalCancel;

                    }
                }
            }
            dbGetCompanyName.dispose();
        }

    }
}

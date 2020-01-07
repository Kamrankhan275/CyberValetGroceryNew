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
using System.Runtime.CompilerServices;
using System.Xml;
using System.Globalization;
using System.Net;
using System.Configuration;
using webresponce.CyberValetGrocery;




namespace CyberValetGrocery
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string postUrl = string.Empty;
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet dsGetPaymentOption = new DataSet();

            dsGetPaymentOption = dbInfo.GetPaymentOptionDetails();

            if (dsGetPaymentOption.Tables.Count > 0)
            {
                if (dsGetPaymentOption != null && dsGetPaymentOption.Tables.Count > 0 && dsGetPaymentOption.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetPaymentOption.Tables[0].Rows)
                    {
                        postUrl = Convert.ToString(dtrow["PaypalUrl"]);
                    }
                }
            }


          //  string postUrl = ConfigurationManager.AppSettings["paypalUrl"];
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(postUrl);

            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);
            string ipnPost = strRequest;
            strRequest += "&cmd=_notify-validate";
            req.ContentLength = strRequest.Length;

            //for proxy
            //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
            //req.Proxy = proxy;

            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(),
                                     System.Text.Encoding.ASCII);
            streamOut.Write(strRequest);
            streamOut.Close();

            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();

            // logging ipn messages... be sure that you give write
            // permission to process executing this code
            string logPathDir = ResolveUrl("GCheckoutMessages");
            string logPath = string.Format("{0}\\{1}.txt",
                             Server.MapPath(logPathDir), DateTime.Now.Ticks);
            File.WriteAllText(logPath, ipnPost);
            //
            bool responseCorrect = false;
            if (strResponse == "VERIFIED")
            {
                int orderid = 0;
                string cardHoldersName = string.Empty;
                string[] splittedipnPost = ipnPost.Split('&');

                DbProvider _dbpBBillingDetails = new DbProvider();
                string trid = string.Empty;
                string authid = string.Empty;
                string cctype = string.Empty;
                authid = string.Empty;
                int cartAuthorisationInsertStatus = 0;
                string ccardno = string.Empty;
                string ccv = string.Empty;
                string expDateMonth = string.Empty;
                string expYear = string.Empty;
                double paymentGross = 0;
                foreach (string selectedIpin in splittedipnPost)
                {
                    string[] Namevalue = selectedIpin.Trim().ToLower().Split('=');

                    if (Namevalue[0] == "custom")
                    {
                        orderid = Convert.ToInt32(Namevalue[1]);
                        responseCorrect = true;
                    }
                    else if (Namevalue[0] == "txn_id")
                    {
                        trid = Namevalue[1];

                        // insert cart credentials   cart_creditcards

                        if (cartAuthorisationInsertStatus == 0)
                        {
                            Response.Write("authorisation details not inserted");
                        }


                    }
                    else if (Namevalue[0].Trim() == "first_name")
                    {
                        cardHoldersName = Namevalue[1];
                    }
                    else if (Namevalue[0].Trim() == "payment_gross")
                    {
                        paymentGross = Convert.ToDouble(Namevalue[1].Trim());
                        //_dbpBBillingDetails.UserupdateTransactionAuthorisation(orderid, );
                    }

                }
                if (responseCorrect == true)
                {

                }
                else if (strResponse == "INVALID")
                {
                    //log for manual investigation
                    Response.Redirect("payPalCancel.aspx");
                }
                else
                {
                    //log response/ipn data for manual investigation
                }

            }
        }


     
    }
}

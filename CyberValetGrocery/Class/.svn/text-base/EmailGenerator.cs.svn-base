using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Globalization;
using CyberValetGrocery.Class;
namespace CyberValetGrocery.Class
{
    public class EmailGenerator
    {
        public EmailGenerator()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// 1)Read Email text file from EmailContent folder and store filecontent into string variable.
        /// 2)Then fetch all the parameters which are stored in NameValueCollection and replaces the values in 
        /// email text file content.
        /// 3)and returns email body content
        /// </summary>
        /// <param name="strVendorToAdminFileName">Email file name to read </param>
        /// <param name="valEmailVariables">Containts email parameter and values</param>
        /// <returns>email body content</returns>
        public string SendEmailFromFile(string strVendorToAdminFileName, NameValueCollection valEmailVariables)
        {
            //fetch email folder path and store it into string variable.
            string strEmailTextFilePath = System.Web.HttpContext.Current.Server.MapPath(AppConstants.strFolderPath);

            //store Email text file path into string variable.      
            string strVendorToAdminFilePath = strEmailTextFilePath + AppConstants.strBackSlash + strVendorToAdminFileName;

            string strEmailFileContent = string.Empty;

            //Read email text file from EmailContent folder
            strEmailFileContent = System.IO.File.ReadAllText(strVendorToAdminFilePath);

            int intLen = valEmailVariables.Count;

            //Fetch all the values which is stored in NameValueCollection and replace values into 
            //email text file content.
            foreach (string strEmailParameters in valEmailVariables)
            {
                string strEmailParameterValues = Convert.ToString(valEmailVariables[strEmailParameters]);
                strEmailFileContent = strEmailFileContent.Replace(strEmailParameters, strEmailParameterValues);
            }

            return strEmailFileContent;
        }

        /// <summary>
        /// 
        /// 1)Fetch all the parameters which are stored in NameValueCollection and replaces the values in 
        /// email content which are fetched from database.
        /// 2)and returns email body content
        /// </summary>
        /// <param name="strEmailContentFromDatabase">Email Content from database</param>
        /// <param name="valEmailVariables">Containts email parameter and values</param>
        /// <returns>email body content</returns>
        public string SendEmailFromDatabase(string strEmailContentFromDatabase, NameValueCollection valEmailVariables)
        {

            string strEmailFileContent = string.Empty;

            strEmailFileContent = strEmailContentFromDatabase;

            //Fetch all the values which is stored in NameValueCollection and replace values into 
            //email content.
            foreach (string strEmailParameters in valEmailVariables)
            {
                string strEmailParameterValues = Convert.ToString(valEmailVariables[strEmailParameters]);
                strEmailFileContent = strEmailFileContent.Replace(strEmailParameters, strEmailParameterValues);
            }

            return strEmailFileContent;
        }
    }
}

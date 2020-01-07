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

namespace CyberValetGrocery.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
            DbProvider dbAddInfo = new DbProvider();
            DropdownProvider dropSelf = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            btnAdd.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                dropSelf.bindShelfDropdown(drpShelf);//Bind shelf  into dropdown
                lblMsg.Text = "";
            }


        }
        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminCustomers.Tables[0].Rows.Count > 0)
            {
                if (dsAdminCustomers != null && dsAdminCustomers.Tables.Count > 0 && dsAdminCustomers.Tables[0].Rows.Count > 0)
                {
                    MyDataListCustomers.DataSource = dsAdminCustomers;
                    MyDataListCustomers.DataBind();
                }

            }
            //for Site Functions

            DataList MyDataListSiteFunctions = (DataList)Page.Master.FindControl("dtlsitefunctions");
            sideType = 2;
            DataSet dsAdminSiteFunctions = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
            {
                if (dsAdminSiteFunctions != null && dsAdminSiteFunctions.Tables.Count > 0 && dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
                {
                    MyDataListSiteFunctions.DataSource = dsAdminSiteFunctions;
                    MyDataListSiteFunctions.DataBind();
                }

            }

            //for reports

            DataList MyDataListReports = (DataList)Page.Master.FindControl("dtlreports");
            sideType = 3;
            DataSet dsAdminReports = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

            }


            foreach (DataListItem row1 in MyDataListSiteFunctions.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbSitefunctions");
                string name = MyLinkButton.Text;
                if (name == "Products")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbAddInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.AddProduct;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            Response.Redirect("admin_product.aspx", false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            Response.Redirect("admin_product.aspx", false);

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
            try
            {
                int intProduct = 0;
                int intProductMapping = 0;
                int intInsertProduct = 0;
                string imgName = string.Empty;
                 string imgNameLarge = string.Empty;
                int intShelfId = 0;
                int intAsileId = 0;
                int intAsileLink = 0;
                int intSuggest = 0;
                int intTax = 0;
                int intRecom = 0;
                int intHide = 0;
                double soda=0;
                int intCheckImg = 0;
               intProduct = dbAddInfo.ProductNameAlreadyExist(Server.HtmlEncode(txtTitle.Text), txtSize.Text);
               if (intProduct == 0)
               {
                     intCheckImg= UploadProductImage();
                     if (intCheckImg == 0)
                     
                     {

                         imgName = Convert.ToString(ViewState["filename"]);
                         imgNameLarge = Convert.ToString(ViewState["fileLargename"]);
                         intInsertProduct = dbAddInfo.InsertProductInfo(Server.HtmlEncode(txtTitle.Text), FCKeditor1.Value, imgName, txtSize.Text, imgNameLarge, FCKeditor2.Value, txtStore.Text);
                         if (intInsertProduct != 0)
                         {
                             intShelfId = Convert.ToInt32(drpShelf.SelectedValue);
                             if (chkSuggestItem.Checked == true)
                             {
                                 intSuggest = 1;

                             }
                             if (chkRecomItem.Checked == true)
                             {
                                 intRecom = 1;

                             }
                             //if (chkTaxItem.Checked == true)
                             //{
                             //    intTax = 1;

                             //}
                             intTax = Convert.ToInt32(drpType.SelectedValue);
                             if (chkHideItem.Checked == true)
                             {
                                 intHide = 1;

                             }
                             if (txtSodaDeposit.Text != "")
                             {
                                 soda = Convert.ToDouble(txtSodaDeposit.Text);
                             }

                             DataSet dsShelfinfo = dbAddInfo.SelectAsileInfo(intShelfId);
                             if (dsShelfinfo.Tables.Count > 0)
                             {
                                 if (dsShelfinfo != null && dsShelfinfo.Tables.Count > 0 && dsShelfinfo.Tables[0].Rows.Count > 0)
                                 {
                                     foreach (DataRow drShelfinfo in dsShelfinfo.Tables[0].Rows)
                                     {

                                         intAsileId = Convert.ToInt32(drShelfinfo["aisle_id"]);
                                         intAsileLink = Convert.ToInt32(drShelfinfo["aislelink_id"]);
                                         if (txtPrePrice.Text != "")
                                         {
                                             intProductMapping = dbAddInfo.InsertProductMappingInfo(Convert.ToInt32(AppConstants.locationId), intInsertProduct, intShelfId, intAsileId, intAsileLink, Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtBuyPrice.Text), Convert.ToDouble(txtPrePrice.Text), soda, Convert.ToString(intSuggest), Convert.ToString(intTax), Convert.ToString(intRecom), Convert.ToString(intHide));
                                         }
                                         else
                                         {
                                             intProductMapping = dbAddInfo.InsertProductMappingInfo1(Convert.ToInt32(AppConstants.locationId), intInsertProduct, intShelfId, intAsileId, intAsileLink, Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtBuyPrice.Text), soda, Convert.ToString(intSuggest), Convert.ToString(intTax), Convert.ToString(intRecom), Convert.ToString(intHide));


                                         }
                                     }

                                 }
                             }

                             lblMsg.Text = "";
                             lblMsg.Text = AppConstants.productAddSuccess;
                             lblMsg.ForeColor = System.Drawing.Color.Black;
                             clear();


                         }
                         else
                         {
                             lblMsg.Text = "";
                             lblMsg.Text = AppConstants.productAddFailed;
                             lblMsg.ForeColor = System.Drawing.Color.Red;

                         }
                     }

                     else
                     {
                         lblMsg.Text = "";
                         lblMsg.Text = AppConstants.imgError;
                         lblMsg.ForeColor = System.Drawing.Color.Red;

                     }
                   
                 
               }
               else
               {
                   lblMsg.Text = "";
                   lblMsg.Text = AppConstants.productAlreadyExist;
                   lblMsg.ForeColor = System.Drawing.Color.Red;
               }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }

        }
        private int UploadProductImage()
        {
            string strFileName2, imgType3;
            string path = Server.MapPath("..\\Product\\");
            int file_append = 0;
            bool chkImg = true;
            int intReturn = 0;
            int nFileLen = uploadImg.PostedFile.ContentLength;
            if (nFileLen != 0)
            {
                strFileName2 = uploadImg.PostedFile.FileName;
                imgType3 = uploadImg.PostedFile.ContentType;
                chkImg = CheckFileType(strFileName2);
                if (chkImg == true)
                {

                    strFileName2 = System.IO.Path.GetFileName(strFileName2);

                    while (System.IO.File.Exists(Server.MapPath("..\\Product\\") + strFileName2))
                    {
                        HttpPostedFile myFile;
                        myFile = uploadImg.PostedFile;
                        file_append = file_append + 1;
                        strFileName2 = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + file_append.ToString() + ".jpg";
                    }
                    uploadImg.PostedFile.SaveAs(path + strFileName2);

                    intReturn = 0;
                    int nFileLenLarge = uploadLargeImg.PostedFile.ContentLength;
                    if (nFileLenLarge != 0)
                    {
                        UploadProductLargeImage();
                    }
                    else
                    {

                        ViewState["fileLargename"] = "";
                        ViewState["Largecontent"] = "";
                    }

                }

                else
                {
                    intReturn = 1;

                }
            }
            else
            {
                strFileName2 = "";
                imgType3 = "";
                intReturn = 0;
            }
            ViewState["filename"] = strFileName2;
            ViewState["content"] = imgType3;
            return intReturn;

            
        }










        private int UploadProductLargeImage()
        {
            string strFileName2, imgType3;
            string path = Server.MapPath("..\\Product\\");
            int file_append = 0;
            bool chkImg = true;
            int intReturn = 0;
            int nFileLen = uploadLargeImg.PostedFile.ContentLength;
            if (nFileLen != 0)
            {
                strFileName2 = uploadLargeImg.PostedFile.FileName;
                imgType3 = uploadLargeImg.PostedFile.ContentType;
                chkImg = CheckFileType(strFileName2);
                if (chkImg == true)
                {

                    strFileName2 = System.IO.Path.GetFileName(strFileName2);

                    while (System.IO.File.Exists(Server.MapPath("..\\Product\\") + strFileName2))
                    {
                        HttpPostedFile myFile;
                        myFile = uploadLargeImg.PostedFile;
                        file_append = file_append + 1;
                        strFileName2 = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + file_append.ToString() + ".jpg";
                    }
                    uploadLargeImg.PostedFile.SaveAs(path + strFileName2);

                    intReturn = 0;
                    

                }

                else
                {
                    intReturn = 1;

                }
            }
            else
            {
                strFileName2 = "";
                imgType3 = "";
                intReturn = 0;
            }
            ViewState["fileLargename"] = strFileName2;
            ViewState["Largecontent"] = imgType3;
            return intReturn;


        }



        public bool CheckFileType(string FileName)
        {

            string Ext = Path.GetExtension(FileName);

            switch (Ext.ToLower())
            {

                case ".gif":

                    return true;

                    break;

                case ".jpeg":

                    return true;

                    break;

                case ".jpg":

                    return true;

                    break;

                case ".png":

                    return true;

                    break;
                case ".bmp":

                    return true;

                    break;

                default:

                    return false;

                    break;

            }

        }



        public void clear()
        {
            txtBuyPrice.Text = "";
            FCKeditor1.Value = "";
            FCKeditor2.Value = "";
            txtPrePrice.Text = "";
            txtPrice.Text = "";
            txtSize.Text = "";
            txtSodaDeposit.Text = "";
            txtStore.Text = "";
            txtTitle.Text = "";
            drpShelf.SelectedValue = "Select";
            chkHideItem.Checked = false;
            chkRecomItem.Checked = false;
            chkSuggestItem.Checked = false;
            //chkTaxItem.Checked = false;
            drpType.SelectedValue = "Select";

        }
    }
}

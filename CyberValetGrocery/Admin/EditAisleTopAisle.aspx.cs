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
    public partial class EditAisleTopAisle : System.Web.UI.Page
    {
        DbProvider dbEditInfo = new DbProvider();
        int aisletopId = 0;
        int HighlightAisle = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            try
            {

                DataSet dsTopAislesList = new DataSet();
                changeLinks();
                btnUpdate.Attributes.Add("onclick", "clcontent();");
                if (!IsPostBack)
                {

                    lblMsg.Text = "";
                    aisletopId = Convert.ToInt32(Request.QueryString["aisletopId"]);
                    dsTopAislesList = dbEditInfo.SelectAisleTopDeatils(aisletopId);
                    if (dsTopAislesList.Tables.Count > 0)
                    {
                        if (dsTopAislesList != null && dsTopAislesList.Tables.Count > 0 && dsTopAislesList.Tables[0].Rows.Count > 0)
                        {
                            txtAisleTopName.Text = Convert.ToString(dsTopAislesList.Tables[0].Rows[0]["aisletop_name"]);
                            
                            if (Convert.ToString(dsTopAislesList.Tables[0].Rows[0]["aisletop_show"]) == "0")
                            {
                                rdShow.SelectedValue = "0";

                            }
                            else
                            {
                                rdShow.SelectedValue = "1";

                            }
                            HighlightAisle = Convert.ToInt32(dsTopAislesList.Tables[0].Rows[0]["HighlightAisle"]);
                            if (HighlightAisle == 0)
                            {
                                highlightedShop.Checked = false;
                            }
                            else
                            {
                                highlightedShop.Checked = true;
                            }
                            string image = Convert.ToString(dsTopAislesList.Tables[0].Rows[0]["aisletop_image"]);
                            ViewState["imageNm"] = image;
                            imgAsile.ImageUrl = "~/AisleTop/" + image;
                        }
                    }



                }
                dbEditInfo.dispose();



            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }


        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbEditInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbEditInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbEditInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
                if (name == "Aisles Top Aisles")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbEditInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.UpdateTopAisle;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                System.Drawing.Image thumbnailImage;
                int intUpdateAisles = 0;
                int intAisle = 0;
                int intCheckImg = 0;
                string imgName = string.Empty;
                aisletopId = Convert.ToInt32(Request.QueryString["aisletopId"]);
                intAisle = dbEditInfo.TopAisleNameUpdateAlreadyExist(txtAisleTopName.Text, aisletopId);
                if (intAisle == 0)
                {

                    intCheckImg = UploadAisleImage();
                    if (intCheckImg == 0)
                    {
                        imgName = Convert.ToString(ViewState["filename"]);
                        if (imgName != "")
                        {
                            string imgpath = Server.MapPath("../BigImage/") + imgName;
                            System.Drawing.Image image = System.Drawing.Image.FromFile(imgpath);
                            thumbnailImage = image.GetThumbnailImage(125, 112, null, new IntPtr());
                            string path = Server.MapPath("../AisleTop/") + imgName;
                            thumbnailImage.Save(path);
                        }
                        else
                        {

                            imgName = Convert.ToString(ViewState["imageNm"]);

                        }
                        if (highlightedShop.Checked == true)
                        {
                            HighlightAisle = 1;
                        }
                        else
                        {
                            HighlightAisle = 0;
                        }

                        intUpdateAisles = dbEditInfo.UpdateTopAisleInfo(txtAisleTopName.Text, Convert.ToInt32(AppConstants.locationId), rdShow.SelectedValue, imgName, aisletopId, HighlightAisle);
                        if (intUpdateAisles == 1)
                        {
                            lblMsg.Text = "";
                            imgAsile.ImageUrl = "~/AisleTop/" + imgName;
                            lblMsg.Text = AppConstants.AsileTopUpdateSuccess;
                            lblMsg.ForeColor = System.Drawing.Color.Black;

                        }
                        else
                        {
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.asileUpdateFailed;
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
                    lblMsg.Text = AppConstants.asileAlreadyExist;
                    lblMsg.ForeColor = System.Drawing.Color.Red;


                }


                dbEditInfo.dispose();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }


        }


        private int UploadAisleImage()
        {


            string strFileName2, imgType3;
            string path = Server.MapPath("..\\BigImage\\");
            int file_append = 0;
            bool chkImg = true;
            int intReturn = 0;
            int nFileLen = imgAsileUpload.PostedFile.ContentLength;
            if (nFileLen != 0)
            {

                strFileName2 = imgAsileUpload.PostedFile.FileName;
                imgType3 = imgAsileUpload.PostedFile.ContentType;
                chkImg = CheckFileType(strFileName2);
                if (chkImg == true)
                {
                    strFileName2 = System.IO.Path.GetFileName(strFileName2);
                    while (System.IO.File.Exists(Server.MapPath("..\\BigImage\\") + strFileName2))
                    {
                        HttpPostedFile myFile;
                        myFile = imgAsileUpload.PostedFile;
                        file_append = file_append + 1;
                        strFileName2 = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + file_append.ToString() + ".jpg";
                    }
                    imgAsileUpload.PostedFile.SaveAs(path + strFileName2);
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
            ViewState["filename"] = strFileName2;
            ViewState["content"] = imgType3;
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

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_category3.aspx", false);
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_category3.aspx", false);
        }
    }
}

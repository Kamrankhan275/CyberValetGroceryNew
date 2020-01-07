using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing.Imaging;


namespace CyberValetGrocery.Admin
{
    public partial class thumbnailAisileimage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateThumbs2();

        }

        public void CreateThumbs2()
        {
            try
            {

                string QryString = Request.QueryString["imgName"];



                // Response.ContentType = "image/gif";
                string strBigServerPath = Server.MapPath("..//Aisles//") + QryString;

                System.Drawing.Image.GetThumbnailImageAbort dummyCallBack;
                dummyCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);

                System.Drawing.Image fullSizeImg = null;
                if (System.IO.File.Exists(strBigServerPath))
                {
                    fullSizeImg = System.Drawing.Image.FromFile(strBigServerPath);
                }

                System.Drawing.Image thumbNailImg;

                thumbNailImg = fullSizeImg.GetThumbnailImage(42, 42, dummyCallBack, IntPtr.Zero);
                if (System.IO.File.Exists(strBigServerPath))
                {
                    thumbNailImg.Save(Response.OutputStream, ImageFormat.Jpeg);
                }

            }


            catch (Exception ex)
            {
                Response.Write(ex.Message + "PageLoad");

            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
    }
}

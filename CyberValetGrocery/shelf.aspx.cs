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

namespace CyberValetGrocery
{
    public partial class shelf : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            try
            {
               
                BindSideLink();
                getCompanyName();
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                if (!IsPostBack)
                {
                    lblErrMsg.Visible = false; ;
                    int intCheck = 0;
                    int intChk = 0;
                    int aisleId = 0;
                  //  aisleId = Convert.ToInt32(Request.QueryString["aisle"]);

                    if (Request.QueryString["aisle"] != null)
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["aisle"].ToString()))
                        aisleId = Convert.ToInt32(Request.QueryString["aisle"].ToString());
                    }


                    DataSet dsShelfName = new DataSet();
                    dsShelfName = dbInfo.GetUserShelfName(aisleId);
                    if (dsShelfName.Tables.Count > 0)
                    {
                        if (dsShelfName != null && dsShelfName.Tables.Count > 0 && dsShelfName.Tables[0].Rows.Count > 0)
                        {
                            lblAisleName.Text = Convert.ToString(dsShelfName.Tables[0].Rows[0]["aisletop_name"]);
                            lblAisleName1.Text = Convert.ToString(dsShelfName.Tables[0].Rows[0]["aisletop_name"]);
                        }
                    }
                    //intChk = BindPopShelf();
                    intChk = BindAisle(aisleId);
                    //intCheck = BindAllProduct();
                    if (intCheck == 1 && intChk == 1)
                    {
                        //pnlAll.Visible = false;
                        pnlPopular.Visible = false;
                        lblErrMsg.Visible = true;
                        lblErrMsg.Text = AppConstants.pgNoProduct;
                           

                    }


                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
        public int BindPopShelf(int aisleId)
        {
             //int aisleId = 0;
             int intChk = 0;
                   // aisleId = Convert.ToInt32(Request.QueryString["aisle"]);
                    DataSet dsShelfName = new DataSet();
                    dsShelfName = dbInfo.GetUserPopShelfNameDeatils(aisleId);
                    if (dsShelfName.Tables.Count > 0)
                    {
                        if (dsShelfName != null && dsShelfName.Tables.Count > 0 && dsShelfName.Tables[0].Rows.Count > 0)
                        {
                            pnlPopular.Visible = true;
                            dtlPopCatgory.DataSource = dsShelfName;
                            dtlPopCatgory.DataBind();
                            intChk = 0;
                        }
                        else
                        {
                            pnlPopular.Visible = false;
                            intChk = 1;
                        }
                    }
                    else
                    {
                        pnlPopular.Visible = false;
                        intChk = 1;

                    }

                    return intChk;


        }



        public int BindAisle(int aisleId)
        {
           // int aisleId = 0;
            int intChk = 0;
            int intCheck = 0;
          //  aisleId = Convert.ToInt32(Request.QueryString["aisle"]);
            DataSet dsAisle = new DataSet();
            dsAisle = dbInfo.GetUserAisleNameDeatils(aisleId);
            if (dsAisle.Tables.Count > 0)
            {
                if (dsAisle != null && dsAisle.Tables.Count > 0 && dsAisle.Tables[0].Rows.Count > 0)
                {
                    pnlPopular.Visible = true;
                    dtlPopCatgory.DataSource = dsAisle;
                    dtlPopCatgory.DataBind();
                    int intaisle = 0;
                    //foreach (DataListItem DtlAisle in dtlPopCatgory.Items)
                    //{
                    for (int i = 0; i < dtlPopCatgory.Items.Count; i++)
                    {
                        DataListItem items = dtlPopCatgory.Items[i];

                        DataList dtlshelf = (DataList)items.FindControl("dtlShelf");
                        Label lblid = (Label)items.FindControl("lblaisleid");

                        intaisle = Convert.ToInt32(lblid.Text);
                        DataSet dsShelfName = new DataSet();

                        dsShelfName = dbInfo.GetUserShelfDeatils(aisleId, intaisle);
                        if (dsShelfName.Tables.Count > 0)
                        {
                            if (dsShelfName != null && dsShelfName.Tables.Count > 0 && dsShelfName.Tables[0].Rows.Count > 0)
                            {
                                //pnlAll.Visible = true;
                                dtlshelf.DataSource = dsShelfName;
                                dtlshelf.DataBind();
                                
                            }
                            else
                            {
                                //pnlAll.Visible = false;
                               
                            }
                        }
                        else
                        {
                            //pnlAll.Visible = false;
                            

                        }
                    }
                    intChk = 0;
                    
                }
                else
                {
                    //pnlPopular.Visible = false;
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = AppConstants.NoShelfRecordFound;
                    intChk = 1;
                }
            }
            else
            {
                //pnlPopular.Visible = false;
                lblErrMsg.Visible = true;
                lblErrMsg.Text = AppConstants.NoShelfRecordFound;
                intChk = 1;

            }

            return intChk;


        }


        
        public void BindSideLink()
        {
            Panel pnlHow = (Panel)Page.Master.FindControl("pnlHow");
            pnlHow.Visible = false;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = true;

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgShelf;

                    }
                }
            }
            dbGetCompanyName.dispose();
        }

       
    }
}

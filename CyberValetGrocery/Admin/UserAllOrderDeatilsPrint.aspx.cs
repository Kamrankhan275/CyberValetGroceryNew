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
    public partial class UserAllOrderDeatilsPrint : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTable dtOrder = new DataTable();
                    DataRow rowOrder;
                    dtOrder.Columns.Add("FName");
                    dtOrder.Columns.Add("LName");
                    dtOrder.Columns.Add("Phone");
                    dtOrder.Columns.Add("Phone2");
                    dtOrder.Columns.Add("Address");
                    dtOrder.Columns.Add("Address2");
                    dtOrder.Columns.Add("City");
                    dtOrder.Columns.Add("State");
                    
                    dtOrder.Columns.Add("Zip");

                    dtOrder.Columns.Add("orderNum");
                    dtOrder.Columns.Add("orderDate");
                    dtOrder.Columns.Add("deliveryDateTime");
                    dtOrder.Columns.Add("paymentMethod");
                    dtOrder.Columns.Add("SpecialOrInfo");
                    dtOrder.Columns.Add("subTotal");
                    dtOrder.Columns.Add("Tax");
                    dtOrder.Columns.Add("sodaDeposit");
                    dtOrder.Columns.Add("deliveryFee");
                    dtOrder.Columns.Add("tips");
                    dtOrder.Columns.Add("orderTot");
                    dtOrder.Columns.Add("Picktype");
                    string strDate = string.Empty;
                    int locId = 0;
                    int userId = 0;
                    int orderId = 0;
                    string strPaymentType = string.Empty;
                    string strText = string.Empty;
                    double accountdebit = 0;
                    int picktype = 0;
                    strDate = Convert.ToString(Request.QueryString["date"]);
                    locId = Convert.ToInt32(Request.QueryString["locId"]);
                    DataSet dsDeliveryDateList = new DataSet();
                    dsDeliveryDateList = dbListInfo.GetDeliverySheduleDetails(strDate, locId);
                    if (dsDeliveryDateList.Tables.Count > 0)
                    {
                        if (dsDeliveryDateList != null && dsDeliveryDateList.Tables.Count > 0 && dsDeliveryDateList.Tables[0].Rows.Count > 0)
                        {
                            dtlOrder.DataSource = dsDeliveryDateList;
                            dtlOrder.DataBind();
                            foreach (DataListItem dtList in dtlOrder.Items)
                            {
                                Label lblOrder;
                                Label lblUser;
                                DataList dtOrderList;
                                lblOrder = (Label)dtList.FindControl("lblOrd");
                                lblUser = (Label)dtList.FindControl("lblUid");
                                dtOrderList = (DataList)dtList.FindControl("dtlOrderDetail");


                                DataSet dsUserItemList = new DataSet();
                                userId = Convert.ToInt32(lblUser.Text);
                                orderId = Convert.ToInt32(lblOrder.Text);
                                dtOrder.Rows.Clear();
                                rowOrder = dtOrder.NewRow();

                                dsUserItemList = dbListInfo.GetHomeUserInformation(userId);
                                if (dsUserItemList.Tables.Count > 0)
                                {
                                    if (dsUserItemList != null && dsUserItemList.Tables.Count > 0 && dsUserItemList.Tables[0].Rows.Count > 0)
                                    {

                                        rowOrder["FName"] = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_fname"]);
                                        rowOrder["LName"] = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_lname"]);
                                        rowOrder["Phone"] = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_phone"]);
                                        rowOrder["Phone2"] = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_cell"]);
                                    }
                                }

                                DataSet dsUserOrderList = new DataSet();
                                dsUserOrderList = dbListInfo.GetUserOrderDetail(userId, orderId);
                                if (dsUserOrderList.Tables.Count > 0)
                                {
                                    if (dsUserOrderList != null && dsUserOrderList.Tables.Count > 0 && dsUserOrderList.Tables[0].Rows.Count > 0)
                                    {
                                        rowOrder["Address"] = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_address"]);
                                        rowOrder["Address2"] = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_address2"]);
                                        rowOrder["City"] = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_city"]);
                                        rowOrder["State"] = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_state"]);
                                        rowOrder["Zip"] = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_zip"]);
                                        rowOrder["orderNum"] = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_number"]);
                                        rowOrder["orderDate"] = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["ordered"]);
                                        string pickup = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_picktype"]);
                                       // rowOrder["Picktype"] = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_picktype"]);
                                     // picktype =Convert.ToInt32(rowOrder["Picktype"]);
                                        //if (pickup == "")
                                        //{
                                        //    ViewState["Picktype"] = " ";
                                        //}
                                        //else
                                        //{
                                        //    BindPicktype(Convert.ToInt32(pickup));
                                        //}
                                        //if (pickup =="3")
                                        //{
                                        //    ViewState["Picktype"]="dddddd";
                                        //}
                                        //else{
                                        //      ViewState["Picktype"]="eeeeeeeeee";
                                        //}
                                       // lblDeliveryDateTime.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["delivery"]) + "(" + ViewState["Picktype"] + ")";

                                        rowOrder["deliveryDateTime"] = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["delivery"]) + "(" + ViewState["Picktype"] + ")"; 
                                       // rowOrder["deliveryDateTime"] = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["delivery"]);
                                        rowOrder["SpecialOrInfo"] = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_instructions"]);

                                        // rowOrder["subTotal"] = Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_grocerytotal"]), 2));
                                        // rowOrder["Tax"]= Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_tax"]), 2));
                                        // rowOrder["sodaDeposit"] = Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_sodadeposit"]), 2));
                                        // rowOrder["deliveryFee"] = Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_deliveryfee"]), 2));
                                        // rowOrder["tips"] = Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_tip"]), 2));
                                        //rowOrder["orderTot"] = Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]), 2));

                                        rowOrder["subTotal"] = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_grocerytotal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                        rowOrder["Tax"] = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_tax"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                        rowOrder["sodaDeposit"] = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_sodadeposit"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                        
                                        
                                        
                                        
                                        rowOrder["deliveryFee"] = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_deliveryfee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                        rowOrder["tips"] = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_tip"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                        rowOrder["orderTot"] = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);


                                        strPaymentType = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_paymenttype"]);
                                        if (strPaymentType == Convert.ToString(AppConstants.strCOD))
                                        {
                                            rowOrder["paymentMethod"] = Convert.ToString(AppConstants.strCODDetail);

                                        }
                                        else if (strPaymentType == Convert.ToString(AppConstants.strCC))
                                        {
                                            rowOrder["paymentMethod"] = Convert.ToString(AppConstants.strCCDetail);

                                        }
                                        else if (strPaymentType == Convert.ToString(AppConstants.strAF))
                                        {
                                            rowOrder["paymentMethod"] = Convert.ToString(AppConstants.strAFDetail);

                                        }
                                        else if (strPaymentType == Convert.ToString(AppConstants.strAFCOD))
                                        {

                                            accountdebit = Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]), 2) - Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2);
                                            //strText = Convert.ToString(accountdebit) + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2)) + " " + Convert.ToString(AppConstants.strCODDetail);
                                            strText = Convert.ToDecimal(accountdebit).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strCODDetail);
                                            rowOrder["paymentMethod"] = strText;
                                        }
                                        else if (strPaymentType == Convert.ToString(AppConstants.strAFCC))
                                        {

                                            accountdebit = Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]), 2) - Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2);
                                            //strText = Convert.ToString(accountdebit) + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2)) + " " + Convert.ToString(AppConstants.strCCDetail);
                                            strText = Convert.ToDecimal(accountdebit).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strCCDetail);
                                            rowOrder["paymentMethod"] = strText;


                                        }
                                        else
                                        {
                                            rowOrder["paymentMethod"] = "";
                                        }


                                    }
                                }
                                dtOrder.Rows.Add(rowOrder);
                                dtOrderList.DataSource = dtOrder;
                                dtOrderList.DataBind();

                                foreach (DataListItem dtNewList in dtOrderList.Items)
                                {
                                    GridView itemGrid;
                                    itemGrid = (GridView)dtNewList.FindControl("gridUserProductList1");
                                    DataSet dsUserProductList = new DataSet();
                                    dsUserProductList = dbListInfo.GetUserProductDetail(orderId);
                                    if (dsUserProductList.Tables.Count > 0)
                                    {
                                        if (dsUserProductList != null && dsUserProductList.Tables.Count > 0 && dsUserProductList.Tables[0].Rows.Count > 0)
                                        {

                                            foreach (DataRow dtrow1 in dsUserProductList.Tables[0].Rows)
                                            {

                                                //dtrow1["orderproduct_price"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow1["orderproduct_price"]), 2));
                                                dtrow1["orderproduct_price"] = Convert.ToDecimal(dtrow1["orderproduct_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                                                dtrow1["orderproduct_quantity"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow1["orderproduct_quantity"]), 2));


                                            }

                                            itemGrid.DataSource = dsUserProductList;
                                            itemGrid.DataBind();
                                        }
                                        else
                                        {
                                            itemGrid.Visible = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }


        public void BindPicktype(int picktype)
        {
            int orderId = 0;
            int intpicktype = 0;
            intpicktype = picktype;
            DataSet dsUserProductList = new DataSet();
            //dsUserProductList = dbInfo.GetUserOrderProductDetail(orderId, userId);
            dsUserProductList = dbListInfo.GetPickupInfo(intpicktype);

            if (dsUserProductList.Tables.Count > 0)
            {
                if (dsUserProductList != null && dsUserProductList.Tables.Count > 0 && dsUserProductList.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dtrow in dsUserProductList.Tables[0].Rows)
                    {

                        //dtrow["orderproduct_price"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orderproduct_price"]), 2));


                        ViewState["Picktype"] = Convert.ToString(dsUserProductList.Tables[0].Rows[0]["DeliveryName"]);
                    }

                }
                else
                {

                }
            }
            dbListInfo.dispose();
        }



    }
}


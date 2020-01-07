﻿using System;
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
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CyberValetGrocery.Class
{
    public class DropdownProvider : BaseProvider
    {
        //public DropdownProvider()
        //{
        //    //
        //    // TODO: Add constructor logic here
        //    //
        //}



        //public New() : base("defaultDBConnection.ConnectionString")
        //{
        //}


        public DropdownProvider()
            : base("defaultDBConnection.ConnectionString")
        {
        }


        public void bindStoreLocation(DropDownList ddl)
        {
            DataSet dsstorelocation;

            initializeDBConnection();

            try
            {
                dsstorelocation = execDatasetSelectByKey(DBQuery.SelectStoreLocation);

                DataTable dtlocation = dsstorelocation.Tables[0];

                ddl.DataSource = dtlocation;
                ddl.DataValueField = "storelocation_id";
                ddl.DataTextField = "storelocation_name";
                ddl.DataBind();
                dispose();
                dsstorelocation.Dispose();
            }
            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
        }

        public bool bindLocationDropdown(DropDownList dropDown)
        {

            DataSet dsLocation;
            initializeDBConnection();
            try
            {
                dsLocation = execDatasetSelectByKey(DBQuery.selectLocation);
                DataTable dtState = dsLocation.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "location_name";
                    dropDown.DataValueField = "location_id";
                    dropDown.DataSource = dsLocation;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsLocation.Dispose();
                    return false;
                }

                dropDown.DataTextField = "location_name";
                dropDown.DataValueField = "location_id";
                dropDown.DataSource = dsLocation;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsLocation.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }



        public bool bindShelfDropdown(DropDownList dropDown)
        {

            DataSet dsShelf;
            initializeDBConnection();
            try
            {
                dsShelf = execDatasetSelectByKey(DBQuery.selectShelvesDeatilsInfo);
                DataTable dtState = dsShelf.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "shelf_name";
                    dropDown.DataValueField = "shelf_id";
                    dropDown.DataSource = dsShelf;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsShelf.Dispose();
                    return false;
                }

                dropDown.DataTextField = "shelf_name";
                dropDown.DataValueField = "shelf_id";

                dropDown.DataSource = dsShelf;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsShelf.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }



        public bool bindProductTypeTaxDropdown(DropDownList dropDown)
        {

            DataSet dsTaxRates;
            initializeDBConnection();
            try
            {
                dsTaxRates = execDatasetSelectByKey(DBQuery.selectTaxRatesInfo);
                DataTable dtState = dsTaxRates.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "Tax_Cat_Name";
                    dropDown.DataValueField = "taxId";
                    dropDown.DataSource = dsTaxRates;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsTaxRates.Dispose();
                    return false;
                }

                dropDown.DataTextField = "Tax_Cat_Name";
                dropDown.DataValueField = "taxId";

                dropDown.DataSource = dsTaxRates;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsTaxRates.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }



        public bool bindMinOrderDropdown(DropDownList dropDown)
        {

            DataSet dsMinOrder;
            initializeDBConnection();
            try
            {
                dsMinOrder = execDatasetSelectByKey(DBQuery.selectMinOrderInfo);
                DataTable dtState = dsMinOrder.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "CategoryName";
                    dropDown.DataValueField = "MinOrdId";
                    dropDown.DataSource = dsMinOrder;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsMinOrder.Dispose();
                    return false;
                }

                dropDown.DataTextField = "CategoryName";
                dropDown.DataValueField = "MinOrdId";

                dropDown.DataSource = dsMinOrder;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsMinOrder.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }



        public bool bindEmployeeCheckbox(CheckBoxList CheckBox)
        {

            DataSet dsEmployee;
            initializeDBConnection();
            try
            {
                dsEmployee = execDatasetSelectByKey(DBQuery.selectEmployeePermission);
                DataTable dtState = dsEmployee.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    CheckBox.DataTextField = "permissions_permission";
                    CheckBox.DataValueField = "permissions_id";
                    CheckBox.DataSource = dsEmployee;
                    CheckBox.DataBind();
                    dispose();
                    dsEmployee.Dispose();
                    return false;
                }

                CheckBox.DataTextField = "permissions_permission";
                CheckBox.DataValueField = "permissions_id";

                CheckBox.DataSource = dsEmployee;
                CheckBox.DataBind();
                dispose();
                dsEmployee.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }




        public bool bindAsileCheckbox(CheckBoxList CheckBox)
        {

            DataSet dsAsile;
            initializeDBConnection();
            try
            {
                dsAsile = execDatasetSelectByKey(DBQuery.selectAsile);
                DataTable dtState = dsAsile.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    CheckBox.DataTextField = "aisle_name";
                    CheckBox.DataValueField = "aisle_id";
                    CheckBox.DataSource = dsAsile;
                    CheckBox.DataBind();
                    dispose();
                    dsAsile.Dispose();
                    return false;
                }

                CheckBox.DataTextField = "aisle_name";
                CheckBox.DataValueField = "aisle_id";

                CheckBox.DataSource = dsAsile;
                CheckBox.DataBind();
                dispose();
                dsAsile.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }



        public bool bindZipCheckBox(CheckBoxList CheckBox)
        {

            DataSet dsZip;
            initializeDBConnection();
            try
            {
                dsZip = execDatasetSelectByKey(DBQuery.selectZip);
                DataTable dtState = dsZip.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    CheckBox.DataTextField = "zipcode_zipcode";
                    CheckBox.DataValueField = "zipcode_id";
                    CheckBox.DataSource = dsZip;
                    CheckBox.DataBind();
                    dispose();
                    dsZip.Dispose();
                    return false;
                }

                CheckBox.DataTextField = "zipcode_zipcode";
                CheckBox.DataValueField = "zipcode_id";
                CheckBox.DataSource = dsZip;
                CheckBox.DataBind();
                dispose();
                dsZip.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }


        public bool bindZoneCheckBox(CheckBoxList CheckBox)
        {

            DataSet dsZip;
            initializeDBConnection();
            try
            {
                dsZip = execDatasetSelectByKey(DBQuery.selectZone);
                DataTable dtState = dsZip.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    CheckBox.DataTextField = "Zone";
                    CheckBox.DataValueField = "zone_id";
                    CheckBox.DataSource = dsZip;
                    CheckBox.DataBind();
                    dispose();
                    dsZip.Dispose();
                    return false;
                }

                CheckBox.DataTextField = "Zone";
                CheckBox.DataValueField = "zone_id";

                CheckBox.DataSource = dsZip;
                CheckBox.DataBind();
                dispose();
                dsZip.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }


        //public bool bindZipList(ListBox listZip)
        //{

        //    DataSet dsZip;
        //    initializeDBConnection();
        //    try
        //    {
        //        dsZip = execDatasetSelectByKey(DBQuery.selectZip);
        //        DataTable dtState = dsZip.Tables[0];

        //        if (dtState == null || dtState.Rows.Count == 0)
        //        {
        //            listZip.DataTextField = "zipcode_zipcode";
        //            listZip.DataValueField = "zipcode_id";
        //            listZip.DataSource = dsZip;
        //            listZip.DataBind();
        //            dispose();
        //            dsZip.Dispose();
        //            return false;
        //        }

        //        listZip.DataTextField = "zipcode_zipcode";
        //        listZip.DataValueField = "zipcode_id";

        //        listZip.DataSource = dsZip;
        //        listZip.DataBind();
        //        dispose();
        //        dsZip.Dispose();

        //    }

        //    catch (SqlException sqlEx)
        //    {
        //        string str;
        //        str = sqlEx.Message + sqlEx.StackTrace;
        //    }
        //    catch (Exception ex)
        //    {
        //        string str;
        //        str = ex.Message + ex.StackTrace;
        //    }
        //    return true;

        //}


        public bool bindProductDropdown(DropDownList dropDown)
        {

            DataSet dsProduct;
            initializeDBConnection();
            try
            {
                dsProduct = execDatasetSelectByKey(DBQuery.selectProduct);
                DataTable dtState = dsProduct.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "product_title";
                    dropDown.DataValueField = "product_id";
                    dropDown.DataSource = dsProduct;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsProduct.Dispose();
                    return false;
                }

                dropDown.DataTextField = "product_title";
                dropDown.DataValueField = "product_id";

                dropDown.DataSource = dsProduct;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsProduct.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }



        public bool bindShelfDropdownNew(DropDownList dropDown)
        {

            DataSet dsShelf;
            initializeDBConnection();
            try
            {
                dsShelf = execDatasetSelectByKey(DBQuery.selectShelvesDeatilsInfo);
                DataTable dtState = dsShelf.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "shelf_name";
                    dropDown.DataValueField = "shelf_id";
                    dropDown.DataSource = dsShelf;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Show All...", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsShelf.Dispose();
                    return false;
                }

                dropDown.DataTextField = "shelf_name";
                dropDown.DataValueField = "shelf_id";

                dropDown.DataSource = dsShelf;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Show All...", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsShelf.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }



        //Function for Payment option dropdown

        public bool bindPaymentOptionDropdown(DropDownList dropDown)
        {

            DataSet dsPaymentOption;
            initializeDBConnection();
            try
            {
                dsPaymentOption = execDatasetSelectByKey(DBQuery.selectPaymentOptions);
                DataTable dtState = dsPaymentOption.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "payment_name";
                    dropDown.DataValueField = "payment_Id";
                    dropDown.DataSource = dsPaymentOption;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsPaymentOption.Dispose();
                    return false;
                }

                dropDown.DataTextField = "payment_name";
                dropDown.DataValueField = "payment_Id";

                dropDown.DataSource = dsPaymentOption;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsPaymentOption.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }

        //Function for Delivery Reminder

        public bool bindDeliveryReminderDropdown(DropDownList dropDown)
        {

            DataSet dsDeliveryReminder;
            initializeDBConnection();
            try
            {
                dsDeliveryReminder = execDatasetSelectByKey(DBQuery.selectDeliveryRemindersDate);
                DataTable dtState = dsDeliveryReminder.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "deliverydate_date";
                    dropDown.DataValueField = "deliverydate_date";
                    dropDown.DataSource = dsDeliveryReminder;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsDeliveryReminder.Dispose();
                    return false;
                }

                dropDown.DataTextField = "deliverydate_date";
                dropDown.DataValueField = "deliverydate_date";

                dropDown.DataSource = dsDeliveryReminder;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsDeliveryReminder.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }


        public bool bindLocation(DropDownList dropDown)
        {

            DataSet dsLocation;
            initializeDBConnection();
            try
            {
                dsLocation = execDatasetSelectByKey(DBQuery.selectLocation);
                DataTable dtState = dsLocation.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "location_name";
                    dropDown.DataValueField = "location_id";
                    dropDown.DataSource = dsLocation;
                    dropDown.DataBind();

                    dispose();
                    dsLocation.Dispose();
                    return false;
                }

                dropDown.DataTextField = "location_name";
                dropDown.DataValueField = "location_id";

                dropDown.DataSource = dsLocation;
                dropDown.DataBind();
                dispose();
                dsLocation.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }





        public bool bindUsers1(DropDownList dropDown)
        {

            DataSet dsLocation;
            initializeDBConnection();
            try
            {
                dsLocation = execDatasetSelectByKey(DBQuery.selectUsers);
                DataTable dtState = dsLocation.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "userName";
                    dropDown.DataValueField = "users_id";
                    dropDown.DataSource = dsLocation;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsLocation.Dispose();
                    return false;
                }

                dropDown.DataTextField = "userName";
                dropDown.DataValueField = "users_id";
                dropDown.DataSource = dsLocation;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsLocation.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }



        //Function for Delivery Date
        public bool bindDeliveryDateDropdown(DropDownList dropDown)
        {

            DataSet dsDeliveryReminder;
            initializeDBConnection();
            try
            {
                dsDeliveryReminder = execDatasetSelectByKey(DBQuery.selectDeliveryDate);
                DataTable dtState = dsDeliveryReminder.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "deliverydate_date";
                    dropDown.DataValueField = "deliverydate_date";
                    dropDown.DataSource = dsDeliveryReminder;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsDeliveryReminder.Dispose();
                    return false;
                }

                dropDown.DataTextField = "deliverydate_date";
                dropDown.DataValueField = "deliverydate_date";

                dropDown.DataSource = dsDeliveryReminder;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsDeliveryReminder.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }




        //Function for Sales item
        public bool bindSalesItemDropdown(DropDownList dropDown)
        {

            DataSet dsSales;
            initializeDBConnection();
            try
            {
                dsSales = execDatasetSelectByKey(DBQuery.selectSales);
                DataTable dtState = dsSales.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "product_title";
                    dropDown.DataValueField = "product_id";
                    dropDown.DataSource = dsSales;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsSales.Dispose();
                    return false;
                }

                dropDown.DataTextField = "product_title";
                dropDown.DataValueField = "product_id";

                dropDown.DataSource = dsSales;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsSales.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }


        public bool bindStateDropdown(DropDownList dropDown)
        {

            DataSet dsShelf;
            initializeDBConnection();
            try
            {
                dsShelf = execDatasetSelectByKey(DBQuery.selectStateDeatilsInfo);
                DataTable dtState = dsShelf.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "state_long_name";
                    dropDown.DataValueField = "state_short_name";
                    dropDown.DataSource = dsShelf;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsShelf.Dispose();
                    return false;
                }

                dropDown.DataTextField = "state_long_name";
                dropDown.DataValueField = "state_short_name";

                dropDown.DataSource = dsShelf;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsShelf.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }


        public bool bindStateDropdownNew(DropDownList dropDown, string shortNm)
        {

            DataSet dsShelf;
            initializeDBConnection();
            try
            {


                List<SqlParameter> sqlParams = new List<SqlParameter>();

                SqlParameter sqlParam = new SqlParameter("@shortNm", SqlDbType.VarChar);
                sqlParam.Value = shortNm;
                sqlParam.Size = 50;
                sqlParams.Add(sqlParam);

                dsShelf = execDatasetSelectByKeyParams(DBQuery.selectStateDeatilsInfoNew, sqlParams);

                //dsShelf = execDatasetSelectByKey(DBQuery.selectStateDeatilsInfo);
                DataTable dtState = dsShelf.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "state_long_name";
                    dropDown.DataValueField = "state_short_name";
                    dropDown.DataSource = dsShelf;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsShelf.Dispose();
                    return false;
                }

                dropDown.DataTextField = "state_long_name";
                dropDown.DataValueField = "state_short_name";

                dropDown.DataSource = dsShelf;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsShelf.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }



        public bool bindZipDropdown(DropDownList dropDown)
        {

            DataSet dsZip;
            initializeDBConnection();
            try
            {
                dsZip = execDatasetSelectByKey(DBQuery.selectZip);
                DataTable dtState = dsZip.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "zipcode_zipcode";
                    dropDown.DataValueField = "zipcode_id";
                    dropDown.DataSource = dsZip;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsZip.Dispose();
                    return false;
                }

                dropDown.DataTextField = "zipcode_zipcode";
                dropDown.DataValueField = "zipcode_id";

                dropDown.DataSource = dsZip;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsZip.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }


        public bool bindTopAisleCheckbox(CheckBoxList CheckBox)
        {

            DataSet dsTopAsile;
            initializeDBConnection();
            try
            {
                dsTopAsile = execDatasetSelectByKey(DBQuery.selectTopAisle);
                DataTable dtState = dsTopAsile.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    CheckBox.DataTextField = "aisletop_name";
                    CheckBox.DataValueField = "aisletop_id";
                    CheckBox.DataSource = dsTopAsile;
                    CheckBox.DataBind();
                    dispose();
                    dsTopAsile.Dispose();
                    return false;
                }

                CheckBox.DataTextField = "aisletop_name";
                CheckBox.DataValueField = "aisletop_id";

                CheckBox.DataSource = dsTopAsile;
                CheckBox.DataBind();
                dispose();
                dsTopAsile.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }


        public bool bindDeliveryInfoDropdown(DropDownList dropDown)
        {

            DataSet dsDeliveryInfo;
            initializeDBConnection();
            try
            {
                dsDeliveryInfo = execDatasetSelectByKey(DBQuery.selectDeliInfo);
                DataTable dtState = dsDeliveryInfo.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "DeliveryName";
                    dropDown.DataValueField = "DeliInfoId";
                    dropDown.DataSource = dsDeliveryInfo;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsDeliveryInfo.Dispose();
                    return false;
                }

                dropDown.DataTextField = "DeliveryName";
                dropDown.DataValueField = "DeliInfoId";

                dropDown.DataSource = dsDeliveryInfo;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsDeliveryInfo.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }

        // user not within zipcode
        public bool bindDeliveryInfoDropdown1(DropDownList dropDown)
        {

            DataSet dsDeliveryInfo;
            initializeDBConnection();
            try
            {
                dsDeliveryInfo = execDatasetSelectByKey(DBQuery.selectDeliInfo1);
                DataTable dtState = dsDeliveryInfo.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "DeliveryName";
                    dropDown.DataValueField = "DeliInfoId";
                    dropDown.DataSource = dsDeliveryInfo;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsDeliveryInfo.Dispose();
                    return false;
                }

                dropDown.DataTextField = "DeliveryName";
                dropDown.DataValueField = "DeliInfoId";

                dropDown.DataSource = dsDeliveryInfo;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsDeliveryInfo.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }


        public bool bindFutureDateTime(DropDownList dropDown, string delivery_id)
        {

            DataSet dsShelf;
            initializeDBConnection();
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                SqlParameter sqlParam = new SqlParameter("@delId", SqlDbType.VarChar);
                sqlParam.Value = delivery_id;
                sqlParam.Size = 50;
                sqlParams.Add(sqlParam);

                dsShelf = execDatasetSelectByKeyParams(DBQuery.selectDelveryTimeInfo, sqlParams);

                // dsShelf = execDatasetSelectByKey(DBQuery.selectDeliverytimeInfo);

                //dsShelf = execDatasetSelectByKey(DBQuery.selectStateDeatilsInfo);
                DataTable dtState = dsShelf.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "deliverytime_time";
                    dropDown.DataValueField = "deliverytime_id";
                    dropDown.DataSource = dsShelf;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    // dropDown.SelectedValue = "deliverytime_id";
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsShelf.Dispose();
                    return false;
                }

                dropDown.DataTextField = "deliverytime_time";
                dropDown.DataValueField = "deliverytime_id";

                dropDown.DataSource = dsShelf;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                // dropDown.SelectedValue = "deliverytime_id";
                dropDown.SelectedValue = "Select";
                dispose();
                dsShelf.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }


        public bool bindStateDropdownCountry(DropDownList dropDown, string country)
        {

            DataSet dsShelf = new DataSet();
            initializeDBConnection();
            try
            {

                if (country == "CA")
                {
                    dsShelf = execDatasetSelectByKey(DBQuery.selectStateCADeatilsInfo);

                }

                else if (country == "US")
                {
                    dsShelf = execDatasetSelectByKey(DBQuery.selectStateDeatilsInfo);

                }

                //dsShelf = execDatasetSelectByKey(DBQuery.selectStateDeatilsInfo);
                DataTable dtState = dsShelf.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "state_long_name";
                    dropDown.DataValueField = "state_short_name";
                    dropDown.DataSource = dsShelf;
                    dropDown.DataBind();
                    dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsShelf.Dispose();
                    return false;
                }

                dropDown.DataTextField = "state_long_name";
                dropDown.DataValueField = "state_short_name";

                dropDown.DataSource = dsShelf;
                dropDown.DataBind();
                dropDown.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                dropDown.SelectedValue = "Select";
                dispose();
                dsShelf.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }


        public bool binddeliverydateWeek(DropDownList dropDown)
        {
            DateTime startingDate = new DateTime();
            DataSet dsLocation;
            initializeDBConnection();
            try
            {
                dsLocation = execDatasetSelectByKey(DBQuery.selectLastdeliveryDate);
                DataTable dtState = dsLocation.Tables[0];



                if (dtState == null || dtState.Rows.Count == 0)
                {
                    dropDown.DataTextField = "deliverydate_date";
                    dropDown.DataValueField = "deliverydate_id";
                    dropDown.DataSource = dsLocation;
                    dropDown.DataBind();
                    dropDown.Items.Insert(0, "Select");
                    dropDown.SelectedValue = "Select";
                    dispose();
                    dsLocation.Dispose();
                    return false;
                }

                dropDown.DataTextField = "deliverydate_date";
                dropDown.DataValueField = "deliverydate_id";

                dropDown.DataSource = dsLocation;
                dropDown.DataBind();
                dropDown.Items.Insert(0, "Select");
                dropDown.SelectedValue = "Select";
                dispose();
                dsLocation.Dispose();
            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }

        public bool bindZipCheckBox(CheckBoxList CheckBox, int zone_id)
        {

            DataSet dsZip;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            SqlParameter sqlParam = new SqlParameter("@zone_id", SqlDbType.Int);
            sqlParam.Value = zone_id;
            sqlParam.Size = 5;
            sqlParams.Add(sqlParam);

            initializeDBConnection();
            try
            {
                dsZip = execDatasetByKeyParams(DBQuery.selectZipZone, sqlParams);
                DataTable dtState = dsZip.Tables[0];

                if (dtState == null || dtState.Rows.Count == 0)
                {
                    CheckBox.DataTextField = "zipcode_zipcode";
                    CheckBox.DataValueField = "zipcode_id";
                    CheckBox.DataSource = dsZip;
                    CheckBox.DataBind();
                    dispose();
                    dsZip.Dispose();
                    return false;
                }

                CheckBox.DataTextField = "zipcode_zipcode";
                CheckBox.DataValueField = "zipcode_id";
                CheckBox.DataSource = dsZip;
                CheckBox.DataBind();
                dispose();
                dsZip.Dispose();

            }

            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message + ex.StackTrace;
            }
            return true;

        }

    }
}

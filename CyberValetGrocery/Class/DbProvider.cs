using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Collections;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Security.Cryptography;
using CyberValetGrocery.Class;
namespace CyberValetGrocery.Class
{
    public class DbProvider : BaseProvider
    {
        public DbProvider()
            : base("defaultDBConnection.ConnectionString")
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //'***************************************************************************

        //'#################### "Admin Side functions" ##########################

        //'***************************************************************************


        /// <summary>
        /// retrive login information
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns></returns>

        public DataSet GetLoginInfo(string username, string password)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@username", SqlDbType.VarChar);
            sqlParam.Value = username;
            sqlParam.Size = 30;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@password", SqlDbType.VarChar);
            sqlParam1.Value = password;
            sqlParam1.Size = 30;
            sqlParams.Add(sqlParam1);

            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectLoginInfo, sqlParams);



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
            dispose();
            return loginDs;
        }


        /// <summary>
        /// Check email address exist in database
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>

        public DataSet GetLoginEmailInfo(string username)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@username", SqlDbType.VarChar);
            sqlParam.Value = username;
            sqlParam.Size = 30;
            sqlParams.Add(sqlParam);


            DataSet loginEmailDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginEmailDs = execDatasetSelectByKeyParams(DBQuery.selectLoginEmailInfo, sqlParams);



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
            dispose();
            return loginEmailDs;
        }



        /// <summary>
        /// Retrive shopping constant variables value
        /// </summary>
        /// <returns></returns>
        public DataSet GetConstantVaraibleInfo()
        {
            DataSet dsConstantVaraible = default(DataSet);

            initializeDBConnection();
            try
            {
                dsConstantVaraible = execDatasetSelectByKey(DBQuery.selectConstantVaraibleInfo);
            }
            catch (SqlException sqlEx)
            {
                dsConstantVaraible = null;
            }
            catch (Exception ex)
            {
                dsConstantVaraible = null;
            }
            return dsConstantVaraible;
        }

        /// <summary>
        /// update admin forgot password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int UpdateAdminForgotPassword(string username, string password)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@username", SqlDbType.VarChar);
            sqlParam.Value = username;
            sqlParam.Size = 30;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@password", SqlDbType.VarChar);
            sqlParam1.Value = password;
            sqlParam1.Size = 30;
            sqlParams.Add(sqlParam1);

            int intUpdate = 0;

            initializeDBConnection();

            try
            {
                intUpdate = execDMLByKeyParams(DBQuery.updateAdminPasswordInfo, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                intUpdate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intUpdate = 0;

            }
            dispose();
            return intUpdate;
        }





        /// <summary>
        /// Retrive side link pages name from database
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="intType"></param>
        /// <returns></returns>
        public DataSet GetSideLinkInfo(int adminId, int intType)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@adminId", SqlDbType.Int);
            sqlParam.Value = adminId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intType", SqlDbType.Int);
            sqlParam1.Value = intType;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            DataSet SideLinkInfoDs = new DataSet();

            initializeDBConnection();

            try
            {
                SideLinkInfoDs = execDatasetSelectByKeyParams(DBQuery.selectSideLinkInfo, sqlParams);



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
            dispose();
            return SideLinkInfoDs;
        }

        /********Coupons ********/

        /// <summary>
        /// Insert Coupon information
        /// </summary>
        /// <param name="CouponsCode"></param>
        /// <param name="amount"></param>
        /// <param name="locationId"></param>
        /// <param name="status"></param>
        /// <returns></returns>

        public int InsertCouponsInfo(string CouponsCode, double amount, int locationId, int status)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@CouponsCode", SqlDbType.VarChar);
            sqlParam.Value = CouponsCode;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@amount", SqlDbType.Float);
            sqlParam1.Value = amount;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam2.Value = locationId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@status", SqlDbType.Int);
            sqlParam3.Value = status;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);


            int insertCoupons = 0;


            initializeDBConnection();

            try
            {
                insertCoupons = execDMLByKeyParams(DBQuery.insertCouponsInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertCoupons = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertCoupons = 0;

            }
            dispose();
            return insertCoupons;
        }


        /// <summary>
        /// retrive coupons information
        /// </summary>
        /// <returns></returns>
        public DataSet GetCouponsDeatils()
        {
            DataSet dsCouponsDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsCouponsDeatils = execDatasetSelectByKey(DBQuery.selectCouponsDeatils);
            }
            catch (SqlException sqlEx)
            {
                dsCouponsDeatils = null;
            }
            catch (Exception ex)
            {
                dsCouponsDeatils = null;
            }
            return dsCouponsDeatils;
        }
        /// <summary>
        /// update status for coupon code
        /// </summary>
        /// <param name="CouponId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdateCouponStatus(int CouponId, int status)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@CouponId", SqlDbType.Int);
            sqlParam.Value = CouponId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@status", SqlDbType.Int);
            sqlParam1.Value = status;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);




            int intUpdate = 0;

            initializeDBConnection();

            try
            {
                intUpdate = execDMLByKeyParams(DBQuery.updateCouponStatus, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                intUpdate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intUpdate = 0;

            }
            dispose();
            return intUpdate;
        }

        /// <summary>
        /// check coupons Code already exist
        /// </summary>
        /// <param name="couponsCode"></param>
        /// <returns></returns>

        public int couponsCodeAlreadyExist(string couponsCode)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@couponsCode", SqlDbType.VarChar);
            sqlParam.Value = couponsCode;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            int couponsId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectcouponsCodeAlreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        couponsId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    couponsId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                couponsId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                couponsId = 0;

            }
            dispose();
            return couponsId;
        }


        /// <summary>
        /// check coupons Code already exist
        /// </summary>
        /// <param name="couponsCode"></param>
        /// <param name="CouponId"></param>
        /// <returns></returns>
        public int couponsCodeAlreadyUpdateExist(string couponsCode, int CouponId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@couponsCode", SqlDbType.VarChar);
            sqlParam.Value = couponsCode;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@CouponId", SqlDbType.Int);
            sqlParam1.Value = CouponId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int couponsId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectcouponsCodeAlreadyUpdateExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        couponsId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    couponsId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                couponsId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                couponsId = 0;

            }
            dispose();
            return couponsId;
        }

        /// <summary>
        /// retrive Coupons Deatils
        /// </summary>
        /// <param name="couponsId"></param>
        /// <returns></returns>
        public DataSet selectCouponsDeatils(int CouponId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@CouponId", SqlDbType.Int);
            sqlParam.Value = CouponId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet SideLinkInfoDs = new DataSet();

            initializeDBConnection();

            try
            {
                SideLinkInfoDs = execDatasetSelectByKeyParams(DBQuery.selectCouponsDeatilsInfo, sqlParams);



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
            dispose();
            return SideLinkInfoDs;
        }
        /// <summary>
        /// code to update coupons info
        /// </summary>
        /// <param name="CouponsCode"></param>
        /// <param name="amount"></param>
        /// <param name="locationId"></param>
        /// <param name="CouponId"></param>
        /// <returns></returns>

        public int UpdateCouponsInfo(string CouponsCode, double amount, int locationId, int CouponId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@CouponsCode", SqlDbType.VarChar);
            sqlParam.Value = CouponsCode;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@amount", SqlDbType.Float);
            sqlParam1.Value = amount;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam2.Value = locationId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@CouponId", SqlDbType.Int);
            sqlParam3.Value = CouponId;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);


            int updateCoupons = 0;


            initializeDBConnection();

            try
            {
                updateCoupons = execDMLByKeyParams(DBQuery.updateCouponsInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateCoupons = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateCoupons = 0;

            }
            dispose();
            return updateCoupons;
        }


        /******** Employee  ********/


        /// <summary>
        /// Check Employee email already exist
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>

        public int employeeEmailAlreadyExist(string username)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@username", SqlDbType.VarChar);
            sqlParam.Value = username;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            int employeeId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectLoginEmailInfo, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        employeeId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    employeeId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                employeeId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                employeeId = 0;

            }
            dispose();
            return employeeId;
        }

        /// <summary>
        /// insert employee detail information
        /// </summary>
        /// <param name="firstNm"></param>
        /// <param name="lastNm"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public int InsertEmployeeDetailInfo(string firstNm, string lastNm, string email, string password)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@firstNm", SqlDbType.VarChar);
            sqlParam.Value = firstNm;
            sqlParam.Size = 15;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@lastNm", SqlDbType.VarChar);
            sqlParam1.Value = lastNm;
            sqlParam1.Size = 15;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParam2.Value = email;
            sqlParam2.Size = 30;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@password", SqlDbType.VarChar);
            sqlParam3.Value = password;
            sqlParam3.Size = 30;
            sqlParams.Add(sqlParam3);


            int insertEmployee = 0;


            initializeDBConnection();

            try
            {

                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertEmployeeDetailInfo, sqlParams);

                foreach (DataRow drr in ds.Tables[0].Rows)
                {
                    insertEmployee = Convert.ToInt32(drr[0].ToString());
                }
            }
            catch (SqlException sqlEx)
            {
                insertEmployee = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertEmployee = 0;

            }
            dispose();
            return insertEmployee;
        }



        /// <summary>
        /// insert employee permission information
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        public int InsertEmployeePermissionInfo(int adminId, int permissionId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@adminId", SqlDbType.Int);
            sqlParam.Value = adminId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@permissionId", SqlDbType.Int);
            sqlParam1.Value = permissionId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int insertEmployee = 0;


            initializeDBConnection();

            try
            {
                insertEmployee = execDMLByKeyParams(DBQuery.insertEmployeePermissionInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertEmployee = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertEmployee = 0;

            }
            dispose();
            return insertEmployee;
        }


        /// <summary>
        /// retrive employee details
        /// </summary>
        /// <returns></returns>
        public DataSet GetEmployeeDeatils()
        {
            DataSet dsEmployeeDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsEmployeeDeatils = execDatasetSelectByKey(DBQuery.selectEmployeeDeatils);
            }
            catch (SqlException sqlEx)
            {
                dsEmployeeDeatils = null;
            }
            catch (Exception ex)
            {
                dsEmployeeDeatils = null;
            }
            return dsEmployeeDeatils;
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public int DeleteEmployee(int adminId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@adminId", SqlDbType.Int);
            sqlParam.Value = adminId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            List<SqlParameter> sqlParams1 = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@adminId", SqlDbType.Int);
            sqlParam1.Value = adminId;
            sqlParam1.Size = 4;
            sqlParams1.Add(sqlParam1);


            int deleteEmployee = 0;
            int deleteEmployeePermissions = 0;


            initializeDBConnection();

            try
            {
                deleteEmployee = execDMLByKeyParams(DBQuery.deleteEmployee, sqlParams);
                if (deleteEmployee != 0)
                {
                    deleteEmployeePermissions = execDMLByKeyParams(DBQuery.deleteEmployeePermission, sqlParams1);

                }



            }
            catch (SqlException sqlEx)
            {
                deleteEmployeePermissions = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteEmployeePermissions = 0;

            }
            dispose();
            return deleteEmployeePermissions;
        }


        /// <summary>
        /// retrive employee information
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>

        public DataSet SelectEmployeeDeatils(int employeeId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@employeeId", SqlDbType.Int);
            sqlParam.Value = employeeId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            DataSet EmployeeDeatils = new DataSet();

            initializeDBConnection();

            try
            {
                EmployeeDeatils = execDatasetSelectByKeyParams(DBQuery.selectEmployeeDeatilsInfo, sqlParams);


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
            dispose();
            return EmployeeDeatils;
        }


        /// <summary>
        /// etrive employee permission information
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public DataSet SelectEmployeePermissionDeatils(int employeeId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@employeeId", SqlDbType.Int);
            sqlParam.Value = employeeId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            DataSet EmployeeDeatils = new DataSet();

            initializeDBConnection();

            try
            {
                EmployeeDeatils = execDatasetSelectByKeyParams(DBQuery.selectEmployeePermissionDeatils, sqlParams);


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
            dispose();
            return EmployeeDeatils;


        }
        /// <summary>
        /// check email already exist in database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public int employeeUpdateEmailAlreadyExist(string email, int adminId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParam.Value = email;
            sqlParam.Size = 30;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@adminId", SqlDbType.Int);
            sqlParam1.Value = adminId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int employeeId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectEmployeeEmailInfo, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        employeeId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    employeeId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                employeeId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                employeeId = 0;

            }
            dispose();
            return employeeId;
        }


        /// <summary>
        /// updtae employee detail information
        /// </summary>
        /// <param name="firstNm"></param>
        /// <param name="lastNm"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public int UpdateEmployeeDetailInfo(string firstNm, string lastNm, string email, string password, int employeeId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@firstNm", SqlDbType.VarChar);
            sqlParam.Value = firstNm;
            sqlParam.Size = 15;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@lastNm", SqlDbType.VarChar);
            sqlParam1.Value = lastNm;
            sqlParam1.Size = 15;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParam2.Value = email;
            sqlParam2.Size = 30;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@password", SqlDbType.VarChar);
            sqlParam3.Value = password;
            sqlParam3.Size = 30;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@employeeId", SqlDbType.Int);
            sqlParam4.Value = employeeId;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            int updateEmployee = 0;


            initializeDBConnection();

            try
            {

                updateEmployee = execDMLByKeyParams(DBQuery.updateEmployeeDetailInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateEmployee = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateEmployee = 0;

            }
            dispose();
            return updateEmployee;
        }

        /// <summary>
        /// delete employee permission data
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public int DeleteEmployeePermission(int adminId)
        {



            List<SqlParameter> sqlParams1 = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@adminId", SqlDbType.Int);
            sqlParam1.Value = adminId;
            sqlParam1.Size = 4;
            sqlParams1.Add(sqlParam1);



            int deleteEmployeePermissions = 0;


            initializeDBConnection();

            try
            {

                deleteEmployeePermissions = execDMLByKeyParams(DBQuery.deleteEmployeePermission, sqlParams1);





            }
            catch (SqlException sqlEx)
            {
                deleteEmployeePermissions = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteEmployeePermissions = 0;

            }
            dispose();
            return deleteEmployeePermissions;
        }




        /****************** Aisles ***************/


        /// <summary>
        /// retrive aisles details
        /// </summary>
        /// <returns></returns>

        public DataSet GetAislesDeatils()
        {
            DataSet dsAislesDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsAislesDeatils = execDatasetSelectByKey(DBQuery.selectAislesDeatils);
            }
            catch (SqlException sqlEx)
            {
                dsAislesDeatils = null;
            }
            catch (Exception ex)
            {
                dsAislesDeatils = null;
            }
            return dsAislesDeatils;
        }

        /// <summary>
        /// delete asile information 
        /// </summary>
        /// <param name="aisleId"></param>
        /// <returns></returns>
        public int DeleteAisles(int aisleId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisleId", SqlDbType.Int);
            sqlParam.Value = aisleId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            int deleteAisle = 0;



            List<SqlParameter> sqlParams1 = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@aisleId", SqlDbType.Int);
            sqlParam1.Value = aisleId;
            sqlParam1.Size = 4;
            sqlParams1.Add(sqlParam1);


            int deleteAisleMapping = 0;



            initializeDBConnection();

            try
            {
                deleteAisle = execDMLByKeyParams(DBQuery.deleteAisle, sqlParams);
                if (deleteAisle != 0)
                {
                    deleteAisleMapping = execDMLByKeyParams(DBQuery.deleteAisleMapping, sqlParams);

                }





            }
            catch (SqlException sqlEx)
            {
                deleteAisleMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteAisleMapping = 0;

            }
            dispose();
            return deleteAisleMapping;
        }

        /// <summary>
        /// check aisle name already exist in database
        /// </summary>
        /// <param name="aisleName"></param>
        /// <returns></returns>

        public int AisleNameAlreadyExist(string aisleName)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisleName", SqlDbType.VarChar);
            sqlParam.Value = aisleName;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            int aisleId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectAisleNameAlreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        aisleId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    aisleId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                aisleId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                aisleId = 0;

            }
            dispose();
            return aisleId;
        }


        /// <summary>
        /// insert asile information 
        /// </summary>
        /// <param name="aisleName"></param>
        /// <param name="locationId"></param>
        /// <param name="status"></param>
        /// <param name="imageName"></param>
        /// <returns></returns>
        public int InsertAisleInfo(string aisleName, int locationId, string status, string imageName)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisleName", SqlDbType.VarChar);
            sqlParam.Value = aisleName;
            sqlParam.Size = 75;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam1.Value = locationId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@status", SqlDbType.VarChar);
            sqlParam2.Value = status;
            sqlParam2.Size = 1;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@imageName", SqlDbType.VarChar);
            sqlParam3.Value = imageName;
            sqlParam3.Size = 200;
            sqlParams.Add(sqlParam3);




            int insertAisle = 1;


            initializeDBConnection();

            try
            {
                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertAisleInfo, sqlParams);

                //foreach (DataRow drr in ds.Tables[0].Rows)
                //{
                //    insertAisle = Convert.ToInt32(drr[0].ToString());
                //}


            }
            catch (SqlException sqlEx)
            {
                insertAisle = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertAisle = 0;

            }
            dispose();
            return insertAisle;
        }


        /// <summary>
        /// select aisle details
        /// </summary>
        /// <param name="aislesId"></param>
        /// <returns></returns>
        public DataSet SelectAislesDeatils(int aisleId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisleId", SqlDbType.Int);
            sqlParam.Value = aisleId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet SideLinkInfoDs = new DataSet();

            initializeDBConnection();

            try
            {
                SideLinkInfoDs = execDatasetSelectByKeyParams(DBQuery.selectAislesDeatilsInfo, sqlParams);



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
            dispose();
            return SideLinkInfoDs;
        }

        /// <summary>
        /// check aisleName already exist
        /// </summary>
        /// <param name="aisleName"></param>
        /// <param name="aisleId"></param>
        /// <returns></returns>

        public int AisleNameUpdateAlreadyExist(string aisleName, int aisleId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisleName", SqlDbType.VarChar);
            sqlParam.Value = aisleName;
            sqlParam.Size = 75;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@aisleId", SqlDbType.VarChar);
            sqlParam1.Value = aisleId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int intAisleId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectAisleNameUpdateAlreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        intAisleId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    intAisleId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                intAisleId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intAisleId = 0;

            }
            dispose();
            return intAisleId;
        }



        /// <summary>
        /// update aisle information 
        /// </summary>
        /// <param name="aisleName"></param>
        /// <param name="locationId"></param>
        /// <param name="status"></param>
        /// <param name="imageName"></param>
        /// <param name="aisleId"></param>
        /// <returns></returns>

        public int UpdateAisleInfo(string aisleName, int locationId, string status, string imageName, int aisleId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisleName", SqlDbType.VarChar);
            sqlParam.Value = aisleName;
            sqlParam.Size = 75;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam1.Value = locationId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@status", SqlDbType.VarChar);
            sqlParam2.Value = status;
            sqlParam2.Size = 1;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@imageName", SqlDbType.VarChar);
            sqlParam3.Value = imageName;
            sqlParam3.Size = 200;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@aisleId", SqlDbType.Int);
            sqlParam4.Value = aisleId;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            int updateAisle = 0;


            initializeDBConnection();

            try
            {
                updateAisle = execDMLByKeyParams(DBQuery.updateAisleInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateAisle = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateAisle = 0;

            }
            dispose();
            return updateAisle;
        }


        /****************** Shelves List ***************/
        /// <summary>
        /// retrive shelf details
        /// </summary>
        /// <returns></returns>
        public DataSet GetShelvesDeatils()
        {
            DataSet dsShelvesDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsShelvesDeatils = execDatasetSelectByKey(DBQuery.selectShelvesDeatils);
            }
            catch (SqlException sqlEx)
            {
                dsShelvesDeatils = null;
            }
            catch (Exception ex)
            {
                dsShelvesDeatils = null;
            }
            return dsShelvesDeatils;
        }


        /// <summary>
        /// delete shelf
        /// </summary>
        /// <param name="shelvesId"></param>
        /// <returns></returns>
        public int DeleteShelves(int shelvesId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@shelvesId", SqlDbType.Int);
            sqlParam.Value = shelvesId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            int deleteShelves = 0;

            List<SqlParameter> sqlParams1 = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@shelvesId", SqlDbType.Int);
            sqlParam1.Value = shelvesId;
            sqlParam1.Size = 4;
            sqlParams1.Add(sqlParam1);


            int deleteShelvesMapping = 0;


            initializeDBConnection();

            try
            {
                deleteShelves = execDMLByKeyParams(DBQuery.deleteShelves, sqlParams);
                if (deleteShelves != 0)
                {

                    deleteShelvesMapping = execDMLByKeyParams(DBQuery.deleteShelvesMapping, sqlParams1);
                }




            }
            catch (SqlException sqlEx)
            {
                deleteShelvesMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteShelvesMapping = 0;

            }
            dispose();
            return deleteShelvesMapping;
        }

        /// <summary>
        /// check shelf name already exist
        /// </summary>
        /// <param name="shelfName"></param>
        /// <returns></returns>
        public int ShelfNameAlreadyExist(string shelfName)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@shelfName", SqlDbType.VarChar);
            sqlParam.Value = shelfName;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            int shelfId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectShelfNameInfo, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        shelfId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    shelfId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                shelfId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                shelfId = 0;

            }
            dispose();
            return shelfId;
        }



        /// <summary>
        /// insert Shelf Detail Information
        /// </summary>
        /// <param name="ShelfName"></param>
        /// <param name="Mapping"></param>
        /// <param name="popular"></param>
        /// <param name="locationId"></param>
        /// <returns></returns>


        public int InsertShelfDetailInfo(string ShelfName, string Mapping, string popular, int locationId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@ShelfName", SqlDbType.VarChar);
            sqlParam.Value = ShelfName;
            sqlParam.Size = 65;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@Mapping", SqlDbType.VarChar);
            sqlParam1.Value = Mapping;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@popular", SqlDbType.VarChar);
            sqlParam2.Value = popular;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam3.Value = locationId;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);



            int insertShelf = 0;


            initializeDBConnection();

            try
            {
                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertShelfDetailInfo, sqlParams);

                foreach (DataRow drr in ds.Tables[0].Rows)
                {
                    insertShelf = Convert.ToInt32(drr[0].ToString());
                }


            }
            catch (SqlException sqlEx)
            {
                insertShelf = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertShelf = 0;

            }
            dispose();
            return insertShelf;
        }


        /// <summary>
        /// insert asile and shelf mapping 
        /// </summary>
        /// <param name="shelfId"></param>
        /// <param name="aisleId"></param>
        /// <returns></returns>
        public int InsertShelfMappingInfo(int shelfId, int aisleId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@shelfId", SqlDbType.Int);
            sqlParam.Value = shelfId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@aisleId", SqlDbType.Int);
            sqlParam1.Value = aisleId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int insertShelfMapping = 0;


            initializeDBConnection();

            try
            {
                insertShelfMapping = execDMLByKeyParams(DBQuery.insertShelfMappingInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertShelfMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertShelfMapping = 0;

            }
            dispose();
            return insertShelfMapping;
        }



        public int UpdateShelfProductMappingInfo(int aislelinkID, int shelfID, int aisleID)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aislelinkID", SqlDbType.Int);
            sqlParam.Value = aislelinkID;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam2 = new SqlParameter("@shelfID", SqlDbType.Int);
            sqlParam2.Value = shelfID;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@aisleID", SqlDbType.Int);
            sqlParam3.Value = aisleID;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);

            int updateShelf = 0;

            initializeDBConnection();

            try
            {
                updateShelf = execDMLByKeyParams(DBQuery.updateShelfProductMappingInfo, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                updateShelf = 0;
            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateShelf = 0;
            }
            dispose();
            return updateShelf;
        }
        /// <summary>
        /// retrive Shelf Deatils
        /// </summary>
        /// <param name="shelfId"></param>
        /// <returns></returns>
        public DataSet SelectShelfDeatils(int shelfId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@shelfId", SqlDbType.Int);
            sqlParam.Value = shelfId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet SideLinkInfoDs = new DataSet();

            initializeDBConnection();

            try
            {
                SideLinkInfoDs = execDatasetSelectByKeyParams(DBQuery.selectShelfDeatilsInfo, sqlParams);



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
            dispose();
            return SideLinkInfoDs;
        }


        /// <summary>
        /// retrive shelf mapping
        /// </summary>
        /// <param name="shelfId"></param>
        /// <returns></returns>
        public DataSet SelectShelfMappingDeatils(int shelfId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@shelfId", SqlDbType.Int);
            sqlParam.Value = shelfId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            DataSet ShelfMappingDeatils = new DataSet();

            initializeDBConnection();

            try
            {
                ShelfMappingDeatils = execDatasetSelectByKeyParams(DBQuery.selectShelfMappingDeatils, sqlParams);


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
            dispose();
            return ShelfMappingDeatils;


        }


        /// <summary>
        /// check whether self name already exist
        /// </summary>
        /// <param name="shelfName"></param>
        /// <param name="shelfId"></param>
        /// <returns></returns>

        public int ShelfNameUpdateAlreadyExist(string shelfName, int shelfId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@shelfName", SqlDbType.VarChar);
            sqlParam.Value = shelfName;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@shelfId", SqlDbType.Int);
            sqlParam1.Value = shelfId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int intShelfId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.shelfNameUpdateAlreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        intShelfId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    intShelfId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                intShelfId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intShelfId = 0;

            }
            dispose();
            return intShelfId;
        }





        /// <summary>
        /// updtae shelf details information
        /// </summary>
        /// <param name="ShelfName"></param>
        /// <param name="Mapping"></param>
        /// <param name="popular"></param>
        /// <param name="shelfId"></param>
        /// <returns></returns>

        public int UpdateShelfDetailInfo(string ShelfName, int shelf_show, string Mapping, string popular, int shelfId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@ShelfName", SqlDbType.VarChar);
            sqlParam.Value = ShelfName;
            sqlParam.Size = 65;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam2 = new SqlParameter("@shelf_show", SqlDbType.Int);
            sqlParam2.Value = shelf_show;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            //SqlParameter sqlParam1 = new SqlParameter("@Mapping", SqlDbType.Int);
            //sqlParam1.Value = Mapping;
            //sqlParam1.Size = 4;
            //sqlParams.Add(sqlParam1);

            SqlParameter sqlParam1 = new SqlParameter("@Mapping", SqlDbType.VarChar);
            sqlParam1.Value = Mapping;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam3 = new SqlParameter("@popular", SqlDbType.VarChar);
            sqlParam3.Value = popular;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@shelfId", SqlDbType.Int);
            sqlParam4.Value = shelfId;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);



            int updateShelf = 0;


            initializeDBConnection();

            try
            {


                updateShelf = execDMLByKeyParams(DBQuery.updateShelfDetailInfo, sqlParams);



            }
            catch (SqlException sqlEx)
            {
                updateShelf = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateShelf = 0;

            }
            dispose();
            return updateShelf;
        }






        /// <summary>
        /// delete shelf mapping information
        /// </summary>
        /// <param name="shelvesId"></param>
        /// <returns></returns>



        public int DeleteShelvesMappingInformation(int shelvesId)
        {


            List<SqlParameter> sqlParams1 = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@shelvesId", SqlDbType.Int);
            sqlParam1.Value = shelvesId;
            sqlParam1.Size = 4;
            sqlParams1.Add(sqlParam1);


            int deleteShelvesMapping = 0;


            initializeDBConnection();

            try
            {

                deleteShelvesMapping = execDMLByKeyParams(DBQuery.deleteShelvesMapping, sqlParams1);


            }
            catch (SqlException sqlEx)
            {
                deleteShelvesMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteShelvesMapping = 0;

            }
            dispose();
            return deleteShelvesMapping;
        }


        /****************** Aisles Top Aisles ***************/

        /// <summary>
        /// retrive top aisles  details
        /// </summary>
        /// <returns></returns>

        public DataSet GetAislesTopAisleDeatils()
        {
            DataSet dsAislesTopDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsAislesTopDeatils = execDatasetSelectByKey(DBQuery.selectAislesTopAisleDeatils);
            }
            catch (SqlException sqlEx)
            {
                dsAislesTopDeatils = null;
            }
            catch (Exception ex)
            {
                dsAislesTopDeatils = null;
            }
            return dsAislesTopDeatils;
        }

        /// <summary>
        /// To insert Aisle Top Aisle 
        /// </summary>
        /// <param name="aisleName"></param>
        /// <param name="locationId"></param>
        /// <param name="status"></param>
        /// <param name="aisletop_image"></param>
        /// <returns></returns>
        public int InsertAisleTopAisleInfo(string aisleName, int locationId, string status, string aisletop_image, int HighlightAisle)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisletop_name", SqlDbType.VarChar);
            sqlParam.Value = aisleName;
            sqlParam.Size = 75;
            sqlParams.Add(sqlParam);



            SqlParameter sqlParam1 = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam1.Value = locationId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@status", SqlDbType.VarChar);
            sqlParam2.Value = status;
            sqlParam2.Size = 1;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@aisletop_image", SqlDbType.VarChar);
            sqlParam3.Value = aisletop_image;
            sqlParam3.Size = 200;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@HighlightAisle", SqlDbType.Int);
            sqlParam4.Value = HighlightAisle;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            int insertTopAisle = 0;


            initializeDBConnection();

            try
            {
                insertTopAisle = execDMLByKeyParams(DBQuery.insertAisleTopAisleInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertTopAisle = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertTopAisle = 0;

            }
            dispose();
            return insertTopAisle;
        }

        /// <summary>
        /// To select Aisle Top Aisle Details
        /// </summary>
        /// <param name="aisleId"></param>
        /// <returns></returns>

        public DataSet SelectAisleTopDeatils(int aisletop_id)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisletop_id", SqlDbType.Int);
            sqlParam.Value = aisletop_id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet dsSelectAisleTop = new DataSet();

            initializeDBConnection();

            try
            {
                dsSelectAisleTop = execDatasetSelectByKeyParams(DBQuery.selectTopAislesDeatilsInfo, sqlParams);



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
            dispose();
            return dsSelectAisleTop;
        }

        /// <summary>
        /// To check top aisle name already exist in database
        /// </summary>
        /// <param name="aisletopName"></param>
        /// <returns></returns>
        public int TopAisleNameAlreadyExist(string aisletopName)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisletop_name", SqlDbType.VarChar);
            sqlParam.Value = aisletopName;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            int aisletopId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectTopAisleNameAlreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        aisletopId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    aisletopId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                aisletopId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                aisletopId = 0;

            }
            dispose();
            return aisletopId;
        }

        /// <summary>
        /// To update top aisle info 
        /// </summary>
        /// <param name="aisleName"></param>
        /// <param name="locationId"></param>
        /// <param name="status"></param>
        /// <param name="imageName"></param>
        /// <param name="aisleId"></param>
        /// <returns></returns>

        public int UpdateTopAisleInfo(string aisletopName, int locationId, string status, string aisletopimage, int aisletopId, int HighlightAisle)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisletop_name", SqlDbType.VarChar);
            sqlParam.Value = aisletopName;
            sqlParam.Size = 75;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam1.Value = locationId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@status", SqlDbType.VarChar);
            sqlParam2.Value = status;
            sqlParam2.Size = 1;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@aisletop_image", SqlDbType.VarChar);
            sqlParam3.Value = aisletopimage;
            sqlParam3.Size = 200;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@aisletop_id", SqlDbType.Int);
            sqlParam4.Value = aisletopId;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@HighlightAisle", SqlDbType.Int);
            sqlParam5.Value = HighlightAisle;
            sqlParam5.Size = 4;
            sqlParams.Add(sqlParam5);

            int updateTopAisle = 0;


            initializeDBConnection();

            try
            {
                updateTopAisle = execDMLByKeyParams(DBQuery.updateTopAisleInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateTopAisle = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateTopAisle = 0;

            }
            dispose();
            return updateTopAisle;
        }


        /// <summary>
        /// To select top aisle name already exist
        /// </summary>
        /// <param name="aisletopname"></param>
        /// <param name="aisletopId"></param>
        /// <returns></returns>
        public int TopAisleNameUpdateAlreadyExist(string aisletopname, int aisletopId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisletop_name", SqlDbType.VarChar);
            sqlParam.Value = aisletopname;
            sqlParam.Size = 75;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@aisletop_id", SqlDbType.VarChar);
            sqlParam1.Value = aisletopId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int intTopAisleId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectTopAisleNameUpdateAlreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        intTopAisleId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    intTopAisleId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                intTopAisleId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intTopAisleId = 0;

            }
            dispose();
            return intTopAisleId;
        }


        /// <summary>
        /// To Delete top aisles
        /// </summary>
        /// <param name="aisleId"></param>
        /// <returns></returns>
        public int DeleteTopAisles(int aisletopId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisletop_id", SqlDbType.Int);
            sqlParam.Value = aisletopId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            int deleteTopAisle = 0;



            List<SqlParameter> sqlParams1 = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@aisletop_id", SqlDbType.Int);
            sqlParam1.Value = aisletopId;
            sqlParam1.Size = 4;
            sqlParams1.Add(sqlParam1);


            int deleteTopAisleMapping = 0;



            initializeDBConnection();

            try
            {
                deleteTopAisle = execDMLByKeyParams(DBQuery.deleteTopAisle, sqlParams);
                if (deleteTopAisle != 0)
                {
                    deleteTopAisleMapping = execDMLByKeyParams(DBQuery.deleteTopAisleMapping, sqlParams);

                }

            }
            catch (SqlException sqlEx)
            {
                deleteTopAisleMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteTopAisleMapping = 0;

            }
            dispose();
            return deleteTopAisleMapping;
        }


        /// <summary>
        /// To Delete top aisle mapping info
        /// </summary>
        /// <param name="shelvesId"></param>
        /// <returns></returns>
        public int DeleteTopAisleMappingInformation(int aisleid)
        {


            List<SqlParameter> sqlParams1 = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@aisle_id", SqlDbType.Int);
            sqlParam1.Value = aisleid;
            sqlParam1.Size = 4;
            sqlParams1.Add(sqlParam1);


            int deleteTopAisleMapping = 0;


            initializeDBConnection();

            try
            {

                deleteTopAisleMapping = execDMLByKeyParams(DBQuery.deleteTopAisleMappingInfo, sqlParams1);


            }
            catch (SqlException sqlEx)
            {
                deleteTopAisleMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteTopAisleMapping = 0;

            }
            dispose();
            return deleteTopAisleMapping;
        }

        /// <summary>
        /// To insert top aisle mapping info
        /// </summary>
        /// <param name="aisletopid"></param>
        /// <param name="aisleId"></param>
        /// <returns></returns>
        public int InsertTopAisleMappingInfo(int aisletopid, int aisleId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisletop_id", SqlDbType.Int);
            sqlParam.Value = aisletopid;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@aisle_id", SqlDbType.Int);
            sqlParam1.Value = aisleId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int insertTopAisleMapping = 0;


            initializeDBConnection();

            try
            {
                insertTopAisleMapping = execDMLByKeyParams(DBQuery.insertTopAisleMappingInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertTopAisleMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertTopAisleMapping = 0;

            }
            dispose();
            return insertTopAisleMapping;
        }


        /// <summary>
        /// To select top aisle mapping details
        /// </summary>
        /// <param name="shelfId"></param>
        /// <returns></returns>
        public DataSet SelectTopAisleMappingDeatils(int aisleId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisle_id", SqlDbType.Int);
            sqlParam.Value = aisleId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            DataSet TopAisleMappingDeatils = new DataSet();

            initializeDBConnection();

            try
            {
                TopAisleMappingDeatils = execDatasetSelectByKeyParams(DBQuery.selectTopAisleMappingDeatils, sqlParams);


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
            dispose();
            return TopAisleMappingDeatils;


        }


        /****************** Non-Delivery Zones List ***************/


        /// <summary>
        /// retrive Non-Delivery Zones reports
        /// </summary>
        /// <returns></returns>

        public DataSet GetNonDeliveryZonesDeatils()
        {
            DataSet dsNonDeliveryZonesDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsNonDeliveryZonesDeatils = execDatasetSelectByKey(DBQuery.selectdsNonDeliveryZonesDeatils);
            }
            catch (SqlException sqlEx)
            {
                dsNonDeliveryZonesDeatils = null;
            }
            catch (Exception ex)
            {
                dsNonDeliveryZonesDeatils = null;
            }
            return dsNonDeliveryZonesDeatils;
        }


        /// <summary>
        /// delete Non Delivery Zip code
        /// </summary>
        /// <param name="intZipID"></param>
        /// <returns></returns>
        public int DeleteNonDeliveryZip(int intZipID)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intZipID", SqlDbType.Int);
            sqlParam.Value = intZipID;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            int deleteAisle = 0;



            initializeDBConnection();

            try
            {
                deleteAisle = execDMLByKeyParams(DBQuery.deleteNonDeliveryZip, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                deleteAisle = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteAisle = 0;

            }
            dispose();
            return deleteAisle;
        }






        /****************** Products ****************/
        /// <summary>
        /// retrive product information
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="shefId"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public DataSet GetProductListDeatils(int locationId, int shefId, string strKey)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam.Value = locationId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@shefId", SqlDbType.Int);
            sqlParam1.Value = shefId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            SqlParameter sqlParam2 = new SqlParameter("@strKey", SqlDbType.VarChar);
            sqlParam2.Value = strKey;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {
                if (locationId != 0 && shefId == 0 && strKey == "")
                {
                    productDs = execDatasetSelectByKeyParams(DBQuery.productListDeatils, sqlParams);
                }
                if (locationId != 0 && shefId != 0 && strKey == "")
                {
                    productDs = execDatasetSelectByKeyParams(DBQuery.productListDeatils1, sqlParams);
                }
                if (locationId != 0 && shefId != 0 && strKey != "")
                {
                    productDs = execDatasetSelectByKeyParams(DBQuery.productListDeatils2, sqlParams);
                }
                if (locationId != 0 && shefId == 0 && strKey != "")
                {
                    productDs = execDatasetSelectByKeyParams(DBQuery.productListDeatils3, sqlParams);
                }


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
            dispose();
            return productDs;
        }

        /// <summary>
        /// delete product from database
        /// </summary>
        /// <param name="intProductID"></param>
        /// <returns></returns>

        public int DeleteProductInfo(int intProductID)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intProductID", SqlDbType.Int);
            sqlParam.Value = intProductID;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            int deleteProduct = 0;

            List<SqlParameter> sqlParams1 = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@intProductID", SqlDbType.Int);
            sqlParam1.Value = intProductID;
            sqlParam1.Size = 4;
            sqlParams1.Add(sqlParam1);


            int deleteProductMapping = 0;


            initializeDBConnection();

            try
            {
                deleteProduct = execDMLByKeyParams(DBQuery.deleteProductInfo, sqlParams);
                if (deleteProduct != 0)
                {

                    deleteProductMapping = execDMLByKeyParams(DBQuery.deleteProductMappingInfo, sqlParams1);
                }




            }
            catch (SqlException sqlEx)
            {
                deleteProductMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteProductMapping = 0;

            }
            dispose();
            return deleteProductMapping;
        }


        /// <summary>
        /// check Product Name Already Exist
        /// </summary>
        /// <param name="productTitle"></param>
        /// <param name="size"></param>
        /// <returns></returns>

        public int ProductNameAlreadyExist(string productTitle, string size)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productTitle", SqlDbType.VarChar);
            sqlParam.Value = productTitle;
            sqlParam.Size = 255;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@size", SqlDbType.VarChar);
            sqlParam1.Value = size;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            int productId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectProductNameInfo, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {

                    productId = 1;



                }
                else
                {
                    productId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                productId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                productId = 0;

            }
            dispose();
            return productId;
        }






        /// <summary>
        /// insert product information
        /// </summary>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        /// <param name="imgNm"></param>
        /// <param name="size"></param>
        /// <param name="imgNm1"></param>
        /// <param name="comment"></param>
        /// <param name="store"></param>
        /// <returns></returns>


        public int InsertProductInfo(string title, string desc, string imgNm, string size, string imgNm1, string comment, string store)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@title", SqlDbType.VarChar);
            sqlParam.Value = title;
            sqlParam.Size = 255;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@desc", SqlDbType.VarChar);
            sqlParam1.Value = desc;
            sqlParam1.Size = 5000;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@imgNm", SqlDbType.VarChar);
            sqlParam2.Value = imgNm;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@size", SqlDbType.VarChar);
            sqlParam3.Value = size;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@imgNm1", SqlDbType.VarChar);
            sqlParam4.Value = imgNm1;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@comment", SqlDbType.VarChar);
            sqlParam5.Value = comment;
            sqlParam5.Size = 255;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@store", SqlDbType.VarChar);
            sqlParam6.Value = store;
            sqlParam6.Size = 50;
            sqlParams.Add(sqlParam6);



            int insertProduct = 0;


            initializeDBConnection();

            try
            {
                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertProductInfo, sqlParams);

                foreach (DataRow drr in ds.Tables[0].Rows)
                {
                    insertProduct = Convert.ToInt32(drr[0].ToString());
                }


            }
            catch (SqlException sqlEx)
            {
                insertProduct = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertProduct = 0;

            }
            dispose();
            return insertProduct;
        }
        /// <summary>
        /// select asile information
        /// </summary>
        /// <param name="shefId"></param>
        /// <returns></returns>
        public DataSet SelectAsileInfo(int shefId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@shefId", SqlDbType.Int);
            sqlParam.Value = shefId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {

                productDs = execDatasetSelectByKeyParams(DBQuery.asileListDeatils, sqlParams);




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
            dispose();
            return productDs;
        }


        /// <summary>
        /// insert product details information
        /// </summary>
        /// <param name="locId"></param>
        /// <param name="productId"></param>
        /// <param name="shelfId"></param>
        /// <param name="asileId"></param>
        /// <param name="asileLink"></param>
        /// <param name="price"></param>
        /// <param name="buyPrice"></param>
        /// <param name="perSale"></param>
        /// <param name="soda"></param>
        /// <param name="suggest"></param>
        /// <param name="tax"></param>
        /// <param name="recomm"></param>
        /// <param name="hide"></param>
        /// <returns></returns>
        public int InsertProductMappingInfo(int locId, int productId, int shelfId, int asileId, int asileLink, double price, double buyPrice, double perSale, double soda, string suggest, string tax, string recomm, string hide, string minorder)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@productId", SqlDbType.Int);
            sqlParam1.Value = productId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@shelfId", SqlDbType.Int);
            sqlParam2.Value = shelfId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@asileId", SqlDbType.Int);
            sqlParam3.Value = asileId;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@asileLink", SqlDbType.Int);
            sqlParam4.Value = asileLink;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@price", SqlDbType.Float);
            sqlParam5.Value = price;
            sqlParam5.Size = 8;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@buyPrice", SqlDbType.Float);
            sqlParam6.Value = buyPrice;
            sqlParam6.Size = 8;
            sqlParams.Add(sqlParam6);

            SqlParameter sqlParam7 = new SqlParameter("@perSale", SqlDbType.Float);
            sqlParam7.Value = perSale;
            sqlParam7.Size = 8;
            sqlParams.Add(sqlParam7);


            SqlParameter sqlParam8 = new SqlParameter("@soda", SqlDbType.Float);
            sqlParam8.Value = soda;
            sqlParam8.Size = 8;
            sqlParams.Add(sqlParam8);


            SqlParameter sqlParam9 = new SqlParameter("@suggest", SqlDbType.VarChar);
            sqlParam9.Value = suggest;
            sqlParam9.Size = 1;
            sqlParams.Add(sqlParam9);


            SqlParameter sqlParam10 = new SqlParameter("@tax", SqlDbType.VarChar);
            sqlParam10.Value = tax;
            sqlParam10.Size = 1;
            sqlParams.Add(sqlParam10);

            SqlParameter sqlParam11 = new SqlParameter("@recomm", SqlDbType.VarChar);
            sqlParam11.Value = recomm;
            sqlParam11.Size = 1;
            sqlParams.Add(sqlParam11);


            SqlParameter sqlParam12 = new SqlParameter("@hide", SqlDbType.VarChar);
            sqlParam12.Value = hide;
            sqlParam12.Size = 1;
            sqlParams.Add(sqlParam12);

            SqlParameter sqlParam13 = new SqlParameter("@minorder", SqlDbType.VarChar);
            sqlParam13.Value = minorder;
            sqlParam13.Size = 4;
            sqlParams.Add(sqlParam13);



            int insertShelfMapping = 0;


            initializeDBConnection();

            try
            {
                insertShelfMapping = execDMLByKeyParams(DBQuery.insertProductMappingInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertShelfMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertShelfMapping = 0;

            }
            dispose();
            return insertShelfMapping;
        }


        /// <summary>
        /// insert product mapping info
        /// </summary>
        /// <param name="locId"></param>
        /// <param name="productId"></param>
        /// <param name="shelfId"></param>
        /// <param name="asileId"></param>
        /// <param name="asileLink"></param>
        /// <param name="price"></param>
        /// <param name="buyPrice"></param>
        /// <param name="soda"></param>
        /// <param name="suggest"></param>
        /// <param name="tax"></param>
        /// <param name="recomm"></param>
        /// <param name="hide"></param>
        /// <returns></returns>

        public int InsertProductMappingInfo1(int locId, int productId, int shelfId, int asileId, int asileLink, double price, double buyPrice, double soda, string suggest, string tax, string recomm, string hide, string minorder)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@productId", SqlDbType.Int);
            sqlParam1.Value = productId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@shelfId", SqlDbType.Int);
            sqlParam2.Value = shelfId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@asileId", SqlDbType.Int);
            sqlParam3.Value = asileId;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@asileLink", SqlDbType.Int);
            sqlParam4.Value = asileLink;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@price", SqlDbType.Float);
            sqlParam5.Value = price;
            sqlParam5.Size = 8;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@buyPrice", SqlDbType.Float);
            sqlParam6.Value = buyPrice;
            sqlParam6.Size = 8;
            sqlParams.Add(sqlParam6);




            SqlParameter sqlParam7 = new SqlParameter("@soda", SqlDbType.Float);
            sqlParam7.Value = soda;
            sqlParam7.Size = 8;
            sqlParams.Add(sqlParam7);


            SqlParameter sqlParam8 = new SqlParameter("@suggest", SqlDbType.VarChar);
            sqlParam8.Value = suggest;
            sqlParam8.Size = 1;
            sqlParams.Add(sqlParam8);


            SqlParameter sqlParam9 = new SqlParameter("@tax", SqlDbType.VarChar);
            sqlParam9.Value = tax;
            sqlParam9.Size = 1;
            sqlParams.Add(sqlParam9);

            SqlParameter sqlParam10 = new SqlParameter("@recomm", SqlDbType.VarChar);
            sqlParam10.Value = recomm;
            sqlParam10.Size = 1;
            sqlParams.Add(sqlParam10);


            SqlParameter sqlParam11 = new SqlParameter("@hide", SqlDbType.VarChar);
            sqlParam11.Value = hide;
            sqlParam11.Size = 1;
            sqlParams.Add(sqlParam11);

            SqlParameter sqlParam12 = new SqlParameter("@minorder", SqlDbType.VarChar);
            sqlParam12.Value = minorder;
            sqlParam12.Size = 4;
            sqlParams.Add(sqlParam12);



            int insertShelfMapping = 0;


            initializeDBConnection();

            try
            {
                insertShelfMapping = execDMLByKeyParams(DBQuery.insertProductMappingInfo1, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertShelfMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertShelfMapping = 0;

            }
            dispose();
            return insertShelfMapping;
        }


        /// <summary>
        /// retrive product information
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="asileId"></param>
        /// <returns></returns>

        public DataSet SelectProductDeatils(int productId, int asileId, int shelfId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productId", SqlDbType.Int);
            sqlParam.Value = productId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@asileId", SqlDbType.Int);
            sqlParam1.Value = asileId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@shelfId", SqlDbType.Int);
            sqlParam2.Value = shelfId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);




            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {

                productDs = execDatasetSelectByKeyParams(DBQuery.selectProductDeatils, sqlParams);




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
            dispose();
            return productDs;
        }

        /// <summary>
        /// check product name already exist
        /// </summary>
        /// <param name="productTitle"></param>
        /// <param name="size"></param>
        /// <param name="product"></param>
        /// <returns></returns>

        public int ProductNameUpdateAlreadyExist(string productTitle, string size, int product)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productTitle", SqlDbType.VarChar);
            sqlParam.Value = productTitle;
            sqlParam.Size = 255;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@size", SqlDbType.VarChar);
            sqlParam1.Value = size;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam3 = new SqlParameter("@product", SqlDbType.Int);
            sqlParam3.Value = product;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);


            int productId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectProductNameAlreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {

                    productId = 1;



                }
                else
                {
                    productId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                productId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                productId = 0;

            }
            dispose();
            return productId;
        }


        /// <summary>
        /// update product information
        /// </summary>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        /// <param name="imgNm"></param>
        /// <param name="size"></param>
        /// <param name="imgNm1"></param>
        /// <param name="comment"></param>
        /// <param name="store"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public int UpdateProductInfo(string title, string desc, string imgNm, string size, string imgNm1, string comment, string store, int productId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@title", SqlDbType.VarChar);
            sqlParam.Value = title;
            sqlParam.Size = 255;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@desc", SqlDbType.VarChar);
            sqlParam1.Value = desc;
            sqlParam1.Size = 5000;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@imgNm", SqlDbType.VarChar);
            sqlParam2.Value = imgNm;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@size", SqlDbType.VarChar);
            sqlParam3.Value = size;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@imgNm1", SqlDbType.VarChar);
            sqlParam4.Value = imgNm1;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@comment", SqlDbType.VarChar);
            sqlParam5.Value = comment;
            sqlParam5.Size = 255;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@store", SqlDbType.VarChar);
            sqlParam6.Value = store;
            sqlParam6.Size = 50;
            sqlParams.Add(sqlParam6);


            SqlParameter sqlParam7 = new SqlParameter("@productId", SqlDbType.VarChar);
            sqlParam7.Value = productId;
            sqlParam7.Size = 4;
            sqlParams.Add(sqlParam7);



            int updateProduct = 0;


            initializeDBConnection();

            try
            {
                updateProduct = execDMLByKeyParams(DBQuery.updateProductInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateProduct = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateProduct = 0;

            }
            dispose();
            return updateProduct;
        }





        /// <summary>
        /// update product mapping information
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="asileId"></param>
        /// <param name="price"></param>
        /// <param name="buyPrice"></param>
        /// <param name="perSale"></param>
        /// <param name="soda"></param>
        /// <param name="suggest"></param>
        /// <param name="tax"></param>
        /// <param name="recomm"></param>
        /// <param name="hide"></param>
        /// <returns></returns>

        public int UpdateProductMappingInfo(int productid, int asileId, double price, double buyPrice, double perSale, double soda, string suggest, string tax, string recomm, string hide)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productid", SqlDbType.Int);
            sqlParam.Value = productid;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@asileId", SqlDbType.Int);
            sqlParam1.Value = asileId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@price", SqlDbType.Float);
            sqlParam2.Value = price;
            sqlParam2.Size = 8;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@buyPrice", SqlDbType.Float);
            sqlParam3.Value = buyPrice;
            sqlParam3.Size = 8;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@perSale", SqlDbType.Float);
            sqlParam4.Value = perSale;
            sqlParam4.Size = 8;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@soda", SqlDbType.Float);
            sqlParam5.Value = soda;
            sqlParam5.Size = 8;
            sqlParams.Add(sqlParam5);


            SqlParameter sqlParam6 = new SqlParameter("@suggest", SqlDbType.VarChar);
            sqlParam6.Value = suggest;
            sqlParam6.Size = 1;
            sqlParams.Add(sqlParam6);


            SqlParameter sqlParam7 = new SqlParameter("@tax", SqlDbType.VarChar);
            sqlParam7.Value = tax;
            sqlParam7.Size = 1;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@recomm", SqlDbType.VarChar);
            sqlParam8.Value = recomm;
            sqlParam8.Size = 1;
            sqlParams.Add(sqlParam8);


            SqlParameter sqlParam9 = new SqlParameter("@hide", SqlDbType.VarChar);
            sqlParam9.Value = hide;
            sqlParam9.Size = 1;
            sqlParams.Add(sqlParam9);





            int insertShelfMapping = 0;


            initializeDBConnection();

            try
            {
                insertShelfMapping = execDMLByKeyParams(DBQuery.updateProductMappingInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertShelfMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertShelfMapping = 0;

            }
            dispose();
            return insertShelfMapping;
        }


        /// <summary>
        /// update product maooing info
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="asileId"></param>
        /// <param name="price"></param>
        /// <param name="buyPrice"></param>
        /// <param name="soda"></param>
        /// <param name="suggest"></param>
        /// <param name="tax"></param>
        /// <param name="recomm"></param>
        /// <param name="hide"></param>
        /// <returns></returns>
        public int UpdateProductMappingInfo1(int productid, int asileId, double price, double buyPrice, double soda, string suggest, string tax, string recomm, string hide)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productid", SqlDbType.Int);
            sqlParam.Value = productid;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@asileId", SqlDbType.Int);
            sqlParam1.Value = asileId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@price", SqlDbType.Float);
            sqlParam2.Value = price;
            sqlParam2.Size = 8;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@buyPrice", SqlDbType.Float);
            sqlParam3.Value = buyPrice;
            sqlParam3.Size = 8;
            sqlParams.Add(sqlParam3);



            SqlParameter sqlParam4 = new SqlParameter("@soda", SqlDbType.Float);
            sqlParam4.Value = soda;
            sqlParam4.Size = 8;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@suggest", SqlDbType.VarChar);
            sqlParam5.Value = suggest;
            sqlParam5.Size = 1;
            sqlParams.Add(sqlParam5);


            SqlParameter sqlParam6 = new SqlParameter("@tax", SqlDbType.VarChar);
            sqlParam6.Value = tax;
            sqlParam6.Size = 1;
            sqlParams.Add(sqlParam6);

            SqlParameter sqlParam7 = new SqlParameter("@recomm", SqlDbType.VarChar);
            sqlParam7.Value = recomm;
            sqlParam7.Size = 1;
            sqlParams.Add(sqlParam7);


            SqlParameter sqlParam8 = new SqlParameter("@hide", SqlDbType.VarChar);
            sqlParam8.Value = hide;
            sqlParam8.Size = 1;
            sqlParams.Add(sqlParam8);




            int insertShelfMapping = 0;


            initializeDBConnection();

            try
            {
                insertShelfMapping = execDMLByKeyParams(DBQuery.updateProductMappingInfo1, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertShelfMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertShelfMapping = 0;

            }
            dispose();
            return insertShelfMapping;
        }

        /// <summary>
        /// delete product mapping information
        /// </summary>
        /// <param name="intProductID"></param>
        /// <returns></returns>

        public int DeleteProductMapping(int intProductID)
        {


            List<SqlParameter> sqlParams1 = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@intProductID", SqlDbType.Int);
            sqlParam1.Value = intProductID;
            sqlParam1.Size = 4;
            sqlParams1.Add(sqlParam1);


            int deleteProductMapping = 0;


            initializeDBConnection();

            try
            {


                deleteProductMapping = execDMLByKeyParams(DBQuery.deleteProductMappingInfo, sqlParams1);




            }
            catch (SqlException sqlEx)
            {
                deleteProductMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteProductMapping = 0;

            }
            dispose();
            return deleteProductMapping;
        }



        /*************** Coupons Reports **************/

        /// <summary>
        /// retrive coupon code reports details
        /// </summary>
        /// <param name="strStartDate"></param>
        /// <param name="strToDate"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public DataSet SelectCouponReportsDetails(string strStartDate, string strToDate, int location)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strStartDate", SqlDbType.VarChar);
            sqlParam.Value = strStartDate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@strToDate", SqlDbType.VarChar);
            sqlParam1.Value = strToDate;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@location", SqlDbType.Int);
            sqlParam2.Value = location;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);




            DataSet CouponReportsDs = new DataSet();

            initializeDBConnection();

            try
            {

                CouponReportsDs = execDatasetSelectByKeyParams(DBQuery.selectCouponReportsDetails, sqlParams);




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
            dispose();
            return CouponReportsDs;
        }

        /// <summary>
        /// retrive coupon report amount total
        /// </summary>
        /// <param name="strStartDate"></param>
        /// <param name="strToDate"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public DataSet SelectCouponReportsTotalDetails(string strStartDate, string strToDate, int location)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strStartDate", SqlDbType.VarChar);
            sqlParam.Value = strStartDate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@strToDate", SqlDbType.VarChar);
            sqlParam1.Value = strToDate;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@location", SqlDbType.Int);
            sqlParam2.Value = location;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);




            DataSet CouponReportsDs = new DataSet();

            initializeDBConnection();

            try
            {

                CouponReportsDs = execDatasetSelectByKeyParams(DBQuery.selectCouponReportsTotalDetails, sqlParams);




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
            dispose();
            return CouponReportsDs;
        }







        /********** Deleivery Date ************/
        /// <summary>
        /// retrive delivery date details
        /// </summary>
        /// <returns></returns>
        public DataSet GetDeliveryDateDetails()
        {
            DataSet dsEmployeeDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsEmployeeDeatils = execDatasetSelectByKey(DBQuery.selectDeliveryDateDetails);
            }
            catch (SqlException sqlEx)
            {
                dsEmployeeDeatils = null;
            }
            catch (Exception ex)
            {
                dsEmployeeDeatils = null;
            }
            return dsEmployeeDeatils;
        }

        /// <summary>
        /// delete delivery Date information
        /// </summary>
        /// <param name="intDeliveryID"></param>
        /// <returns></returns>
        public int DeleteDelievryDate(int intDeliveryID)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intDeliveryID", SqlDbType.Int);
            sqlParam.Value = intDeliveryID;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            int deleteDate = 0;



            List<SqlParameter> sqlParams1 = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@intDeliveryID", SqlDbType.Int);
            sqlParam1.Value = intDeliveryID;
            sqlParam1.Size = 4;
            sqlParams1.Add(sqlParam1);


            int deleteDelievryMapping = 0;


            List<SqlParameter> sqlParams2 = new List<SqlParameter>();

            SqlParameter sqlParam2 = new SqlParameter("@intDeliveryID", SqlDbType.Int);
            sqlParam2.Value = intDeliveryID;
            sqlParam2.Size = 4;
            sqlParams2.Add(sqlParam2);


            int deleteDelievryZip = 0;



            initializeDBConnection();

            try
            {
                deleteDate = execDMLByKeyParams(DBQuery.deleteDeliveryDate, sqlParams);
                if (deleteDate != 0)
                {
                    deleteDelievryMapping = execDMLByKeyParams(DBQuery.deleteDeliveryDateTime, sqlParams1);
                    if (deleteDelievryMapping != 0)
                    {
                        deleteDelievryZip = execDMLByKeyParams(DBQuery.deleteDeliveryDateZip, sqlParams2);

                    }

                }





            }
            catch (SqlException sqlEx)
            {
                deleteDelievryMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteDelievryMapping = 0;

            }
            dispose();
            return deleteDelievryMapping;
        }


        /// <summary>
        /// retrive delievry date info
        /// </summary>
        /// <returns></returns>
        public DataSet GetdsDeliverytimeInfo()
        {
            DataSet dsEmployeeDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsEmployeeDeatils = execDatasetSelectByKey(DBQuery.selectDeliverytimeInfo);
            }
            catch (SqlException sqlEx)
            {
                dsEmployeeDeatils = null;
            }
            catch (Exception ex)
            {
                dsEmployeeDeatils = null;
            }
            return dsEmployeeDeatils;
        }





        /// <summary>
        /// insert delivery date information
        /// </summary>
        /// <param name="deliveryDate"></param>
        /// <param name="intLocId"></param>
        /// <returns></returns>
        public int InsertDeliveryDateInfo(DateTime deliveryDate, int intLocId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@deliveryDate", SqlDbType.DateTime);
            sqlParam.Value = deliveryDate;
            sqlParam.Size = 8;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@intLocId", SqlDbType.Int);
            sqlParam1.Value = intLocId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int insertDeliveryDate = 0;


            initializeDBConnection();

            try
            {
                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertDeliveryDateInfo, sqlParams);

                foreach (DataRow drr in ds.Tables[0].Rows)
                {
                    insertDeliveryDate = Convert.ToInt32(drr[0].ToString());
                }


            }
            catch (SqlException sqlEx)
            {
                insertDeliveryDate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertDeliveryDate = 0;

            }
            dispose();
            return insertDeliveryDate;
        }


        /// <summary>
        /// insert delievery date zip info
        /// </summary>
        /// <param name="deliveryDateId"></param>
        /// <param name="ZiptId"></param>
        /// <returns></returns>

        public int InsertDeliveryDateZipInfo(int deliveryDateId, int zipcodeid)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@deliveryDateId", SqlDbType.Int);
            sqlParam.Value = deliveryDateId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@zipcode_id", SqlDbType.Int);
            sqlParam1.Value = zipcodeid;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            int insertZip = 0;


            initializeDBConnection();

            try
            {
                insertZip = execDMLByKeyParams(DBQuery.insertDeliveryDateZipInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertZip = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertZip = 0;

            }
            dispose();
            return insertZip;
        }



        /// <summary>
        /// insert deleivery date mapping info
        /// </summary>
        /// <param name="deliveryDateId"></param>
        /// <param name="timeId"></param>
        /// <param name="intCapacity"></param>
        /// <param name="intLoc"></param>
        /// <returns></returns>

        public int InsertDeliveryDateMappingInfo(int deliveryDateId, int timeId, int intCapacity, int intLoc)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@deliveryDateId", SqlDbType.Int);
            sqlParam.Value = deliveryDateId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@timeId", SqlDbType.Int);
            sqlParam1.Value = timeId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@intCapacity", SqlDbType.Int);
            sqlParam2.Value = intCapacity;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam3.Value = intLoc;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);


            int insertDate = 0;


            initializeDBConnection();

            try
            {
                insertDate = execDMLByKeyParams(DBQuery.insertDeliveryDateMappingInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertDate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertDate = 0;

            }
            dispose();
            return insertDate;
        }


        /// <summary>
        /// check delivery date already exit
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>

        public int DeliveryDateAlreadyExist1(string strDate)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strDate", SqlDbType.VarChar);
            sqlParam.Value = strDate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);



            int DateId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectDeliveryDateAlreadyExist1, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {

                    DateId = 1;



                }
                else
                {
                    DateId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                DateId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                DateId = 0;

            }
            dispose();
            return DateId;
        }
        public int DeliveryDateAlreadyExist(string strDate, int ZipCode)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strDate", SqlDbType.VarChar);
            sqlParam.Value = strDate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@ZipCode", SqlDbType.VarChar);
            sqlParam1.Value = ZipCode;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            int DateId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectDeliveryDateAlreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {

                    DateId = 1;



                }
                else
                {
                    DateId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                DateId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                DateId = 0;

            }
            dispose();
            return DateId;
        }


        /// <summary>
        /// retrive delivery date capacity information
        /// </summary>
        /// <param name="deliveryId"></param>
        /// <returns></returns>
        public DataSet GetDeliveryDateCapacityDetails(int deliveryId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@deliveryId", SqlDbType.Int);
            sqlParam.Value = deliveryId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.selectDeliveryDateCapacityDetails, sqlParams);




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
            dispose();
            return dateDs;
        }




        /*********** Sales Item *************/

        /// <summary>
        /// get home page information
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public DataSet GetdsHomePageInfo(int locationId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam.Value = locationId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.selectHomePageInfo, sqlParams);




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
            dispose();
            return dateDs;
        }


        /// <summary>
        /// insert home page information
        /// </summary>
        /// <param name="strHomePage"></param>
        /// <param name="strLimit"></param>
        /// <param name="strWelcomeTxt"></param>
        /// <param name="intLoc"></param>
        /// <param name="Price"></param>
        /// <returns></returns>
        public int InsertHomePageInfo(string strHomePage, string strLimit, string strWelcomeTxt, int intLoc, double Price, int check)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strHomePage", SqlDbType.VarChar);
            sqlParam.Value = strHomePage;
            sqlParam.Size = 300;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@strLimit", SqlDbType.VarChar);
            sqlParam1.Value = strLimit;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@strWelcomeTxt", SqlDbType.VarChar);
            sqlParam2.Value = strWelcomeTxt;
            sqlParam2.Size = 3000;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam3.Value = intLoc;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@Price", SqlDbType.Float);
            sqlParam4.Value = Price;
            sqlParam4.Size = 8;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@check", SqlDbType.Int);
            sqlParam5.Value = check;
            sqlParam5.Size = 4;
            sqlParams.Add(sqlParam5);


            int insertDate = 0;


            initializeDBConnection();

            try
            {
                if (check == 0)
                {
                    insertDate = execDMLByKeyParams(DBQuery.insertHomePageInfo, sqlParams);
                }
                else if (check == 1)
                {
                    insertDate = execDMLByKeyParams(DBQuery.updateHomePageInfo, sqlParams);

                }


            }
            catch (SqlException sqlEx)
            {
                insertDate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertDate = 0;

            }
            dispose();
            return insertDate;
        }


        /// <summary>
        /// retrive sales item details
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public DataSet GetSalesItemListDetails(int locationId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam.Value = locationId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.salesItemListDetails, sqlParams);




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
            dispose();
            return dateDs;
        }



        /// <summary>
        /// update presales info
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public int UpdatePreSaleInformation(int productid, double price)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productid", SqlDbType.Int);
            sqlParam.Value = productid;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            SqlParameter sqlParam1 = new SqlParameter("@price", SqlDbType.Float);
            sqlParam1.Value = price;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);




            int updateSale = 0;


            initializeDBConnection();

            try
            {
                updateSale = execDMLByKeyParams(DBQuery.updatePreSaleInformation, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateSale = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateSale = 0;

            }
            dispose();
            return updateSale;
        }


        /// <summary>
        /// update presales info
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public int UpdatePreSaleInformation1(int productid)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productid", SqlDbType.Int);
            sqlParam.Value = productid;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            int updateSale = 0;


            initializeDBConnection();

            try
            {
                updateSale = execDMLByKeyParams(DBQuery.updatePreSaleInformation1, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateSale = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateSale = 0;

            }
            dispose();
            return updateSale;
        }



        /// <summary>
        /// update sale info
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="price"></param>
        /// <param name="preSale"></param>
        /// <returns></returns>

        public int UpdateSaleInfo(int productid, double price, double preSale)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productid", SqlDbType.Int);
            sqlParam.Value = productid;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            SqlParameter sqlParam1 = new SqlParameter("@price", SqlDbType.Float);
            sqlParam1.Value = price;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@preSale", SqlDbType.Float);
            sqlParam2.Value = preSale;
            sqlParam2.Size = 8;
            sqlParams.Add(sqlParam2);




            int updateSale = 0;


            initializeDBConnection();

            try
            {
                updateSale = execDMLByKeyParams(DBQuery.updateSaleInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateSale = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateSale = 0;

            }
            dispose();
            return updateSale;
        }






        /// <summary>
        /// update sale info
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public int UpdateSaleInfo1(int productid, double price)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productid", SqlDbType.Int);
            sqlParam.Value = productid;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            SqlParameter sqlParam1 = new SqlParameter("@price", SqlDbType.Float);
            sqlParam1.Value = price;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);






            int updateSale = 0;


            initializeDBConnection();

            try
            {
                updateSale = execDMLByKeyParams(DBQuery.updateSaleInfo1, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateSale = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateSale = 0;

            }
            dispose();
            return updateSale;
        }





        /// <summary>
        /// retrive product information
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>

        public DataSet SelectProductInformationDeatils(int productId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productId", SqlDbType.Int);
            sqlParam.Value = productId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.selectProductInformationDeatils, sqlParams);




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
            dispose();
            return dateDs;
        }



        /// <summary>
        /// update produtc sale info
        /// </summary>
        /// <param name="intProductId"></param>
        /// <param name="Price"></param>
        /// <param name="PrePrice"></param>
        /// <returns></returns>

        public int UpdateProductSaleInfo(int intProductId, double Price, double PrePrice)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intProductId", SqlDbType.Int);
            sqlParam.Value = intProductId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@Price", SqlDbType.Float);
            sqlParam1.Value = Price;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@PrePrice", SqlDbType.Float);
            sqlParam2.Value = PrePrice;
            sqlParam2.Size = 8;
            sqlParams.Add(sqlParam2);


            int insertSaleInfo = 0;


            initializeDBConnection();

            try
            {
                insertSaleInfo = execDMLByKeyParams(DBQuery.updateProductSaleInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertSaleInfo = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertSaleInfo = 0;

            }
            dispose();
            return insertSaleInfo;
        }



        /************** Product Reports ************/
        /// <summary>
        /// retrive product reports details
        /// </summary>
        /// <param name="strStartDate"></param>
        /// <param name="strToDate"></param>
        /// <param name="intshelfid"></param>
        /// <param name="strPopular"></param>
        /// <returns></returns>

        public DataSet GetProductReportListDeatils(string strStartDate, string strToDate, int intshelfid, string strPopular)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strStartDate", SqlDbType.VarChar);
            sqlParam.Value = strStartDate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@strToDate", SqlDbType.VarChar);
            sqlParam1.Value = strToDate;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@intshelfid", SqlDbType.Int);
            sqlParam2.Value = intshelfid;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@strPopular", SqlDbType.VarChar);
            sqlParam3.Value = strPopular;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);

            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {
                if (intshelfid == 0)
                {
                    if (strPopular == "DESC")
                    {
                        productDs = execDatasetSelectByKeyParams(DBQuery.ProductReportListDeatils, sqlParams);
                    }
                    else
                    {
                        productDs = execDatasetSelectByKeyParams(DBQuery.ProductReportListDeatils1, sqlParams);

                    }
                }
                if (intshelfid != 0)
                {
                    if (strPopular == "DESC")
                    {
                        productDs = execDatasetSelectByKeyParams(DBQuery.ProductReportListDeatilsNew, sqlParams);
                    }
                    else
                    {
                        productDs = execDatasetSelectByKeyParams(DBQuery.ProductReportListDeatilsNew1, sqlParams);

                    }
                }



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
            dispose();
            return productDs;
        }



        /************** Balance Reports ***************/

        public DataSet GetBalanceReportsDeatils(int locId, int intBalAmt, int orderBy)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@intBalAmt", SqlDbType.Int);
            sqlParam1.Value = intBalAmt;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@orderBy", SqlDbType.Int);
            sqlParam2.Value = orderBy;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {
                if (orderBy == 1)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectBalanceReportsDeatils, sqlParams);
                }
                else
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectBalanceReportsDeatils1, sqlParams);

                }




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
            dispose();
            return infoDs;
        }


        /// <summary>
        /// etrive balance  reports details
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataSet GetBalanceReportsDeatilsInfo(int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectBalanceReportsDeatilsInfo, sqlParams);





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
            dispose();
            return infoDs;
        }






        /********* Home  Page ***********/
        /// <summary>
        /// retrive users deatil
        /// </summary>
        /// <returns></returns>

        public DataSet GetHomeUserDetailInfo()
        {
            DataSet dsInfo = default(DataSet);

            initializeDBConnection();
            try
            {
                dsInfo = execDatasetSelectByKey(DBQuery.selectHomeUserDetailInfo);
            }
            catch (SqlException sqlEx)
            {
                dsInfo = null;
            }
            catch (Exception ex)
            {
                dsInfo = null;
            }
            return dsInfo;
        }





        public DataSet GetUserReportDetailInfo()
        {
            DataSet dsInfo = default(DataSet);

            initializeDBConnection();
            try
            {
                dsInfo = execDatasetSelectByKey(DBQuery.selectUserReportInfo);
            }
            catch (SqlException sqlEx)
            {
                dsInfo = null;
            }
            catch (Exception ex)
            {
                dsInfo = null;
            }
            return dsInfo;
        }
        /// <summary>
        /// retrive order detail
        /// </summary>
        /// <param name="locId"></param>
        /// <param name="strTodayDate"></param>
        /// <returns></returns>
        public DataSet GetHomeOrderDetailInfo(int locId, string strTodayDate)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@strTodayDate", SqlDbType.VarChar);
            sqlParam1.Value = strTodayDate;
            sqlParam1.Size = 12;
            sqlParams.Add(sqlParam1);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectHomeOrderDetailInfo, sqlParams);





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
            dispose();
            return infoDs;
        }



        public DataSet GetHomeOrderDetailInfo1(int locId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);





            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectHomeOrderDetailInfo1, sqlParams);





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
            dispose();
            return infoDs;
        }

        /// <summary>
        /// retrive particular user information
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataSet GetHomeUserInformation(int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectHomeUserInformation, sqlParams);





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
            dispose();
            return infoDs;
        }


        /// <summary>
        /// retrive user information as per search criteria
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="intIn"></param>
        /// <param name="locId"></param>
        /// <param name="intSortBy"></param>
        /// <returns></returns>
        public DataSet GetUserDetailInformation(string strKey, int intIn, int locId, int intSortBy)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strKey", SqlDbType.VarChar);
            sqlParam.Value = strKey;
            sqlParam.Size = 30;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intIn", SqlDbType.VarChar);
            sqlParam1.Value = intIn;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@locId", SqlDbType.VarChar);
            sqlParam2.Value = locId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@intSortBy", SqlDbType.VarChar);
            sqlParam3.Value = intSortBy;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);


            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {
                if (strKey == "" && intSortBy == 1)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailInformation, sqlParams);
                }
                else if (strKey == "" && intSortBy == 2)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailInformation1, sqlParams);
                }
                else if (strKey == "" && intSortBy == 3)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailInformation2, sqlParams);
                }

                if (strKey != "" && intSortBy == 1 && @intIn == 1)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailInformation3, sqlParams);
                }
                else if (strKey != "" && intSortBy == 2 && @intIn == 1)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailInformation4, sqlParams);
                }
                else if (strKey != "" && intSortBy == 3 && @intIn == 1)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailInformation5, sqlParams);
                }

                if (strKey != "" && intSortBy == 1 && @intIn == 2)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailInformation6, sqlParams);
                }
                else if (strKey != "" && intSortBy == 2 && @intIn == 2)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailInformation7, sqlParams);
                }
                else if (strKey != "" && intSortBy == 3 && @intIn == 2)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailInformation8, sqlParams);
                }






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
            dispose();
            return infoDs;
        }

        /// <summary>
        /// retrive number of order per user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataSet GetUserOrderCount(int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserOrderCount, sqlParams);





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
            dispose();
            return infoDs;
        }


        /// <summary>
        /// retrive user order detail information
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataSet GetUserOrderDetailInformation(int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserOrderDetailInformation, sqlParams);





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
            dispose();
            return infoDs;
        }



        /// <summary>
        /// retrive order product detail info
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        public DataSet GetUserProductDetailInformation(int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserProductDetailInformation, sqlParams);





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
            dispose();
            return infoDs;
        }






        /// <summary>
        /// retrive order details
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public DataSet GetUserOrderDetail(int userId, int orderId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@orderId", SqlDbType.Int);
            sqlParam1.Value = orderId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserOrderDetail, sqlParams);





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
            dispose();
            return infoDs;
        }

        /// <summary>
        /// retrive product deatils
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>

        public DataSet GetUserProductDetail(int orderId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@orderId", SqlDbType.Int);
            sqlParam.Value = orderId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserProductDetail, sqlParams);





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
            dispose();
            return infoDs;
        }






        /// <summary>
        /// check user email already exist
        /// </summary>
        /// <param name="email"></param>
        /// <param name="intUserId"></param>
        /// <returns></returns>


        public int userEmailAlreadyExist(string email, int intUserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParam.Value = email;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam1.Value = intUserId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int employeeId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectEmailAlreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        employeeId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    employeeId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                employeeId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                employeeId = 0;

            }
            dispose();
            return employeeId;
        }

        /// <summary>
        /// update user information
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <param name="phn"></param>
        /// <param name="cell"></param>
        /// <param name="chkMail"></param>
        /// <param name="status"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="bAddress1"></param>
        /// <param name="bAddress2"></param>
        /// <param name="bCity"></param>
        /// <param name="bState"></param>
        /// <param name="bZip"></param>
        /// <param name="intUserId"></param>
        /// <returns></returns>

        public int UpdateUserInformation(string fName, string lName, string email, string pwd, string phn, string cell, string chkMail, int status, string address1, string address2, string city, string state, string zip, string bAddress1, string bAddress2, string bCity, string bState, string bZip, int intUserId, bool isMember)
        {
            int member = Convert.ToInt32(isMember);

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@fName", SqlDbType.VarChar);
            sqlParam.Value = fName;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@lName", SqlDbType.VarChar);
            sqlParam1.Value = lName;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParam2.Value = email;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@pwd", SqlDbType.VarChar);
            sqlParam3.Value = pwd;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@phn", SqlDbType.VarChar);
            sqlParam4.Value = phn;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@cell", SqlDbType.VarChar);
            sqlParam5.Value = cell;
            sqlParam5.Size = 50;
            sqlParams.Add(sqlParam5);


            SqlParameter sqlParam6 = new SqlParameter("@chkMail", SqlDbType.VarChar);
            sqlParam6.Value = chkMail;
            sqlParam6.Size = 1;
            sqlParams.Add(sqlParam6);


            SqlParameter sqlParam7 = new SqlParameter("@status", SqlDbType.Int);
            sqlParam7.Value = status;
            sqlParam7.Size = 4;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@address1", SqlDbType.VarChar);
            sqlParam8.Value = address1;
            sqlParam8.Size = 50;
            sqlParams.Add(sqlParam8);


            SqlParameter sqlParam9 = new SqlParameter("@address2", SqlDbType.VarChar);
            sqlParam9.Value = address2;
            sqlParam9.Size = 50;
            sqlParams.Add(sqlParam9);


            SqlParameter sqlParam10 = new SqlParameter("@city", SqlDbType.VarChar);
            sqlParam10.Value = city;
            sqlParam10.Size = 50;
            sqlParams.Add(sqlParam10);


            SqlParameter sqlParam11 = new SqlParameter("@state", SqlDbType.VarChar);
            sqlParam11.Value = state;
            sqlParam11.Size = 20;
            sqlParams.Add(sqlParam11);


            SqlParameter sqlParam12 = new SqlParameter("@zip", SqlDbType.VarChar);
            sqlParam12.Value = zip;
            sqlParam12.Size = 200;
            sqlParams.Add(sqlParam12);


            SqlParameter sqlParam13 = new SqlParameter("@bAddress1", SqlDbType.VarChar);
            sqlParam13.Value = bAddress1;
            sqlParam13.Size = 50;
            sqlParams.Add(sqlParam13);


            SqlParameter sqlParam14 = new SqlParameter("@bAddress2", SqlDbType.VarChar);
            sqlParam14.Value = bAddress2;
            sqlParam14.Size = 50;
            sqlParams.Add(sqlParam14);


            SqlParameter sqlParam15 = new SqlParameter("@bCity", SqlDbType.VarChar);
            sqlParam15.Value = bCity;
            sqlParam15.Size = 50;
            sqlParams.Add(sqlParam15);

            SqlParameter sqlParam16 = new SqlParameter("@bState", SqlDbType.VarChar);
            sqlParam16.Value = bState;
            sqlParam16.Size = 50;
            sqlParams.Add(sqlParam16);


            SqlParameter sqlParam17 = new SqlParameter("@bZip", SqlDbType.VarChar);
            sqlParam17.Value = bZip;
            sqlParam17.Size = 50;
            sqlParams.Add(sqlParam17);


            SqlParameter sqlParam18 = new SqlParameter("@intUserId", SqlDbType.VarChar);
            sqlParam18.Value = intUserId;
            sqlParam18.Size = 4;
            sqlParams.Add(sqlParam18);

            sqlParams.Add(new SqlParameter { ParameterName = "isMember", Value = member, SqlDbType = SqlDbType.Int });

            int insertShelfMapping = 0;


            initializeDBConnection();

            try
            {
                insertShelfMapping = execDMLByKeyParams(DBQuery.updateUserInformation, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                insertShelfMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertShelfMapping = 0;

            }
            dispose();
            return insertShelfMapping;
        }





        //Depositors

        /// <summary>
        /// retrive depositor information
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="intIn"></param>
        /// <param name="locId"></param>
        /// <returns></returns>
        public DataSet GetDepositorsDetailInformation(string strKey, int intIn, int locId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strKey", SqlDbType.VarChar);
            sqlParam.Value = strKey;
            sqlParam.Size = 30;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intIn", SqlDbType.VarChar);
            sqlParam1.Value = intIn;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@locId", SqlDbType.VarChar);
            sqlParam2.Value = locId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);


            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {
                if (strKey == "")
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectDepositorsDetailInformation, sqlParams);
                }
                if (strKey != "")
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectDepositorsDetailInformation1, sqlParams);
                }

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
            dispose();
            return infoDs;
        }


        /// <summary>
        /// retrive transaction details
        /// </summary>
        /// <param name="intParentId"></param>
        /// <returns></returns>
        public DataSet GetTransactionDetails(int intParentId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intParentId", SqlDbType.Int);
            sqlParam.Value = intParentId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectTransactionDetails, sqlParams);


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
            dispose();
            return infoDs;
        }




        /// <summary>
        /// retrive customer transaction details
        /// </summary>
        /// <param name="locId"></param>
        /// <returns></returns>
        public DataSet GetCustomerTransactionDetail(int locId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectCustomerTransactionDetail, sqlParams);


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
            dispose();
            return infoDs;
        }


        /// <summary>
        /// retrive transaction detail information
        /// </summary>
        /// <param name="intTransId"></param>
        /// <returns></returns>


        public DataSet GetCustTransactionDetailsIfo(int intTransId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intTransId", SqlDbType.Int);
            sqlParam.Value = intTransId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectCustTransactionDetailsIfo, sqlParams);


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
            dispose();
            return infoDs;
        }



        /// <summary>
        /// insert transaction information
        /// </summary>
        /// <param name="dtToday"></param>
        /// <param name="amt"></param>
        /// <param name="orderId"></param>
        /// <param name="comment"></param>
        /// <param name="intUserId"></param>
        /// <returns></returns>

        public int InsertTransactionInformation(DateTime dtToday, double amt, int orderId, string comment, int intUserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@dtToday", SqlDbType.DateTime);
            sqlParam.Value = dtToday;
            sqlParam.Size = 8;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@amt", SqlDbType.Float);
            sqlParam1.Value = amt;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@orderId", SqlDbType.Int);
            sqlParam2.Value = orderId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@comment", SqlDbType.Text);
            sqlParam3.Value = comment;
            sqlParam3.Size = 5000;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam4.Value = intUserId;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            int insertTransc = 0;


            initializeDBConnection();

            try
            {
                if (orderId == 0)
                {
                    insertTransc = execDMLByKeyParams(DBQuery.insertTransactionInformation, sqlParams);
                }
                else
                {
                    insertTransc = execDMLByKeyParams(DBQuery.insertTransactionInformation1, sqlParams);
                }



            }
            catch (SqlException sqlEx)
            {
                insertTransc = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertTransc = 0;

            }
            dispose();
            return insertTransc;
        }




        /// <summary>
        /// retrive account information
        /// </summary>
        /// <param name="intuserId"></param>
        /// <returns></returns>
        public DataSet GetAccountInformation(int intuserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intuserId", SqlDbType.Int);
            sqlParam.Value = intuserId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectAccountInformation, sqlParams);


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
            dispose();
            return infoDs;
        }


        /// <summary>
        /// update transaction information
        /// </summary>
        /// <param name="account"></param>
        /// <param name="intUserId"></param>
        /// <returns></returns>
        public int UpdateTransactionInfo(double account, int intUserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();


            SqlParameter sqlParam0 = new SqlParameter("@account", SqlDbType.Float);
            sqlParam0.Value = account;
            sqlParam0.Size = 8;
            sqlParams.Add(sqlParam0);

            SqlParameter sqlParam1 = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam1.Value = intUserId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int insertTransc = 0;


            initializeDBConnection();

            try
            {

                insertTransc = execDMLByKeyParams(DBQuery.updateTransactionInfo, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                insertTransc = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertTransc = 0;

            }
            dispose();
            return insertTransc;
        }

        /// <summary>
        /// retrive saved product information
        /// </summary>
        /// <param name="intProduct"></param>
        /// <param name="intPopular"></param>
        /// <param name="intLoc"></param>
        /// <returns></returns>

        public DataSet GetSavedProductListReports(int intProduct, int intPopular, int intLoc)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intProduct", SqlDbType.Int);
            sqlParam.Value = intProduct;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@intPopular", SqlDbType.Int);
            sqlParam1.Value = intPopular;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam2.Value = intLoc;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);





            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {
                if (intProduct == 0 && intPopular == 1)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectSavedProductListReports, sqlParams);
                }
                else if (intProduct == 0 && intPopular == 2)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectSavedProductListReports1, sqlParams);
                }
                if (intProduct != 0 && intPopular == 1)
                {
                    if (intProduct == 10)
                    {
                        infoDs = execDatasetSelectByKeyParams(DBQuery.selectSavedProductReports, sqlParams);
                    }
                    if (intProduct == 50)
                    {
                        infoDs = execDatasetSelectByKeyParams(DBQuery.selectSavedProductReports1, sqlParams);
                    }
                    if (intProduct == 100)
                    {
                        infoDs = execDatasetSelectByKeyParams(DBQuery.selectSavedProductReports2, sqlParams);
                    }
                }
                if (intProduct != 0 && intPopular == 2)
                {
                    if (intProduct == 10)
                    {
                        infoDs = execDatasetSelectByKeyParams(DBQuery.selectSavedProductList, sqlParams);
                    }
                    if (intProduct == 50)
                    {
                        infoDs = execDatasetSelectByKeyParams(DBQuery.selectSavedProductList1, sqlParams);
                    }
                    if (intProduct == 100)
                    {
                        infoDs = execDatasetSelectByKeyParams(DBQuery.selectSavedProductList2, sqlParams);
                    }
                }


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
            dispose();
            return infoDs;
        }






        /// <summary>
        /// retrive saved list user information
        /// </summary>
        /// <param name="intList"></param>
        /// <param name="intLoc"></param>
        /// <returns></returns>

        public DataSet GetSavedUserListReports(int intList, int intLoc)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intList", SqlDbType.Int);
            sqlParam.Value = intList;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            SqlParameter sqlParam1 = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam1.Value = intLoc;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);





            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {
                if (intList == 1)
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectSavedUserListReports, sqlParams);
                }
                else
                {
                    infoDs = execDatasetSelectByKeyParams(DBQuery.selectSavedUserListReports1, sqlParams);
                }


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
            dispose();
            return infoDs;
        }

        /// <summary>
        /// retrive saved list total
        /// </summary>
        /// <param name="intListId"></param>
        /// <returns></returns>

        public DataSet GetSavedTotalReports(int intListId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intListId", SqlDbType.Int);
            sqlParam.Value = intListId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectGetSavedTotalReports, sqlParams);



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
            dispose();
            return infoDs;
        }


        /// <summary>
        /// retrive saved list product info
        /// </summary>
        /// <param name="intListId"></param>
        /// <param name="intLoc"></param>
        /// <returns></returns>
        public DataSet GetSavedListProductInfo(int intListId, int intLoc)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intListId", SqlDbType.Int);
            sqlParam.Value = intListId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam1.Value = intLoc;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectSavedListProductInfo, sqlParams);



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
            dispose();
            return infoDs;
        }


        //Delivery shedule

        /// <summary>
        /// retrive Delivery Shedule Details
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetDeliverySheduleDetails(string date, int locId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@date", SqlDbType.VarChar);
            sqlParam.Value = date;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam1.Value = locId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.selectDeliverySheduleDetails, sqlParams);




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
            dispose();
            return dateDs;
        }




        /// <summary>
        /// Update Delivery Shedule Details
        /// </summary>
        /// <param name="intOrderID"></param>
        /// <param name="groceries"></param>
        /// <param name="deliveryfee"></param>
        /// <param name="tax"></param>
        /// <param name="tip"></param>
        /// <param name="total"></param>
        /// <param name="charge"></param>
        /// <returns></returns>
        public int UpdateDeliverySheduleDetails(int intOrderID, double groceries, double deliveryfee, double tax, double tip, double total, double charge)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intOrderID", SqlDbType.Int);
            sqlParam.Value = intOrderID;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@groceries", SqlDbType.Float);
            sqlParam1.Value = groceries;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@deliveryfee", SqlDbType.Float);
            sqlParam2.Value = deliveryfee;
            sqlParam2.Size = 8;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@tax", SqlDbType.Float);
            sqlParam3.Value = tax;
            sqlParam3.Size = 8;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@tip", SqlDbType.Float);
            sqlParam4.Value = tip;
            sqlParam4.Size = 8;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@total", SqlDbType.Float);
            sqlParam5.Value = total;
            sqlParam5.Size = 8;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@charge", SqlDbType.Float);
            sqlParam6.Value = charge;
            sqlParam6.Size = 8;
            sqlParams.Add(sqlParam6);



            int insertTransc = 0;


            initializeDBConnection();

            try
            {

                insertTransc = execDMLByKeyParams(DBQuery.updateDeliverySheduleDetails, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                insertTransc = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertTransc = 0;

            }
            dispose();
            return insertTransc;
        }





        /// <summary>
        /// retrive order report information
        /// </summary>
        /// <param name="strStartDate"></param>
        /// <param name="strToDate"></param>
        /// <param name="locId"></param>
        /// <returns></returns>

        public DataSet GetOrderReportList(string strStartDate, string strToDate, int locId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strStartDate", SqlDbType.VarChar);
            sqlParam.Value = strStartDate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@strToDate", SqlDbType.VarChar);
            sqlParam1.Value = strToDate;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam2.Value = locId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.selectOrderReportList, sqlParams);




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
            dispose();
            return dateDs;
        }



        /// <summary>
        /// retrive order information
        /// </summary>
        /// <param name="strStartDate"></param>
        /// <param name="strToDate"></param>
        /// <param name="locId"></param>
        /// <param name="OrderNum"></param>
        /// <param name="OrderType"></param>
        /// <returns></returns>

        public DataSet GetOrderListInfo(string strStartDate, string strToDate, int locId, string OrderNum, int OrderType)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strStartDate", SqlDbType.VarChar);
            sqlParam.Value = strStartDate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@strToDate", SqlDbType.VarChar);
            sqlParam1.Value = strToDate;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam2.Value = locId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@OrderNum", SqlDbType.VarChar);
            sqlParam3.Value = OrderNum;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@OrderType", SqlDbType.Int);
            sqlParam4.Value = OrderType;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {
                if (strStartDate != "" && strToDate != "")
                {
                    if (OrderType == 1)
                    {
                        dateDs = execDatasetSelectByKeyParams(DBQuery.selectOrderListInfo, sqlParams);
                    }
                    else
                    {
                        dateDs = execDatasetSelectByKeyParams(DBQuery.selectOrderListInfo1, sqlParams);

                    }
                }
                else if (OrderNum != "")
                {
                    dateDs = execDatasetSelectByKeyParams(DBQuery.selectOrderListInfo2, sqlParams);
                }

                else
                {
                    dateDs = execDatasetSelectByKeyParams(DBQuery.selectOrderListInfo3, sqlParams);
                }






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
            dispose();
            return dateDs;
        }




        /// <summary>
        /// delete Order Information
        /// </summary>
        /// <param name="intOrderID"></param>
        /// <returns></returns>

        public int DeleteOrderInfo(int intOrderID)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intOrderID", SqlDbType.Int);
            sqlParam.Value = intOrderID;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            List<SqlParameter> sqlParams1 = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@intOrderID", SqlDbType.Int);
            sqlParam1.Value = intOrderID;
            sqlParam1.Size = 4;
            sqlParams1.Add(sqlParam1);


            int deleteOrder = 0;
            int deleteOrderProduct = 0;


            initializeDBConnection();

            try
            {
                deleteOrder = execDMLByKeyParams(DBQuery.deleteOrder, sqlParams);
                if (deleteOrder != 0)
                {
                    deleteOrderProduct = execDMLByKeyParams(DBQuery.deleteOrderProduct, sqlParams1);

                }



            }
            catch (SqlException sqlEx)
            {
                deleteOrderProduct = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteOrderProduct = 0;

            }
            dispose();
            return deleteOrderProduct;
        }

        /// <summary>
        /// update order information
        /// </summary>
        /// <param name="intOrderID"></param>
        /// <param name="Date"></param>
        /// <param name="strTime"></param>
        /// <returns></returns>
        public int UpdateOrderInfo(int intOrderID, DateTime Date, string strTime)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intOrderID", SqlDbType.Int);
            sqlParam.Value = intOrderID;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@Date", SqlDbType.DateTime);
            sqlParam1.Value = Date;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@strTime", SqlDbType.VarChar);
            sqlParam2.Value = strTime;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            int updateOrder = 0;

            initializeDBConnection();

            try
            {
                updateOrder = execDMLByKeyParams(DBQuery.updateOrderInfo, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                updateOrder = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateOrder = 0;

            }
            dispose();
            return updateOrder;
        }



        public int UpdateOrderTimeInfo(int intOrderID, string strTime)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intOrderID", SqlDbType.Int);
            sqlParam.Value = intOrderID;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@strTime", SqlDbType.VarChar);
            sqlParam1.Value = strTime;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            int updateOrder = 0;

            initializeDBConnection();

            try
            {
                updateOrder = execDMLByKeyParams(DBQuery.updateTimeInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateOrder = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateOrder = 0;

            }
            dispose();
            return updateOrder;
        }


        //News letter sales

        /// <summary>
        /// retrive sales details 
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public DataSet GetSalesDetails(int locationId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam.Value = locationId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.selectSalesDetails, sqlParams);




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
            dispose();
            return dateDs;
        }


        /// <summary>
        /// retrive preview details 
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public DataSet GetPreviewDetails(int locationId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam.Value = locationId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.selectPreviewDetails, sqlParams);




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
            dispose();
            return dateDs;
        }


        /// <summary>
        /// insert the newsletter preview information in database
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="strStartDate"></param>
        /// <param name="strToDate"></param>
        /// <param name="strHead"></param>
        /// <param name="strFoot"></param>
        /// <param name="intLoc"></param>
        /// <param name="intLoc1"></param>
        /// <param name="prod1"></param>
        /// <param name="prod2"></param>
        /// <param name="prod3"></param>
        /// <param name="prod4"></param>
        /// <param name="prod5"></param>
        /// <param name="prod6"></param>
        /// <param name="prod7"></param>
        /// <param name="prod8"></param>
        /// <returns></returns>
        public int InsertPreviewInfo(string subject, string strStartDate, string strToDate, string strHead, string strFoot, int intLoc, int intLoc1, string prod1, string prod2, string prod3, string prod4, string prod5, string prod6, string prod7, string prod8)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@subject", SqlDbType.VarChar);
            sqlParam.Value = subject;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@strStartDate", SqlDbType.NVarChar);
            sqlParam1.Value = strStartDate;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@strToDate", SqlDbType.NVarChar);
            sqlParam2.Value = strToDate;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@strHead", SqlDbType.Text);
            sqlParam3.Value = strHead;
            sqlParam3.Size = 5000;
            sqlParams.Add(sqlParam3);



            SqlParameter sqlParam4 = new SqlParameter("@strFoot", SqlDbType.VarChar);
            sqlParam4.Value = strFoot;
            sqlParam4.Size = 5000;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam5.Value = intLoc;
            sqlParam5.Size = 4;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@intLoc1", SqlDbType.Int);
            sqlParam6.Value = intLoc1;
            sqlParam6.Size = 4;
            sqlParams.Add(sqlParam6);


            SqlParameter sqlParam7 = new SqlParameter("@prod1", SqlDbType.VarChar);
            sqlParam7.Value = prod1;
            sqlParam7.Size = 50;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@prod2", SqlDbType.VarChar);
            sqlParam8.Value = prod2;
            sqlParam8.Size = 50;
            sqlParams.Add(sqlParam8);

            SqlParameter sqlParam9 = new SqlParameter("@prod3", SqlDbType.VarChar);
            sqlParam9.Value = prod3;
            sqlParam9.Size = 50;
            sqlParams.Add(sqlParam9);

            SqlParameter sqlParam10 = new SqlParameter("@prod4", SqlDbType.VarChar);
            sqlParam10.Value = prod4;
            sqlParam10.Size = 50;
            sqlParams.Add(sqlParam10);

            SqlParameter sqlParam11 = new SqlParameter("@prod5", SqlDbType.VarChar);
            sqlParam11.Value = prod5;
            sqlParam11.Size = 50;
            sqlParams.Add(sqlParam11);

            SqlParameter sqlParam12 = new SqlParameter("@prod6", SqlDbType.VarChar);
            sqlParam12.Value = prod6;
            sqlParam12.Size = 50;
            sqlParams.Add(sqlParam12);

            SqlParameter sqlParam13 = new SqlParameter("@prod7", SqlDbType.VarChar);
            sqlParam13.Value = prod7;
            sqlParam13.Size = 50;
            sqlParams.Add(sqlParam13);

            SqlParameter sqlParam14 = new SqlParameter("@prod8", SqlDbType.VarChar);
            sqlParam14.Value = prod8;
            sqlParam14.Size = 50;
            sqlParams.Add(sqlParam14);

            int updateOrder = 0;

            initializeDBConnection();

            try
            {
                updateOrder = execDMLByKeyParams(DBQuery.insertPreviewInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateOrder = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateOrder = 0;

            }
            dispose();
            return updateOrder;
        }

        /// <summary>
        /// update newsletter preview information in database 
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="strStartDate"></param>
        /// <param name="strToDate"></param>
        /// <param name="strHead"></param>
        /// <param name="strFoot"></param>
        /// <param name="intLoc"></param>
        /// <param name="previewId"></param>
        /// <param name="prod1"></param>
        /// <param name="prod2"></param>
        /// <param name="prod3"></param>
        /// <param name="prod4"></param>
        /// <param name="prod5"></param>
        /// <param name="prod6"></param>
        /// <param name="prod7"></param>
        /// <param name="prod8"></param>
        /// <returns></returns>
        public int UpdatePreviewInfo(string subject, string strStartDate, string strToDate, string strHead, string strFoot, int intLoc, int previewId, string prod1, string prod2, string prod3, string prod4, string prod5, string prod6, string prod7, string prod8)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@subject", SqlDbType.VarChar);
            sqlParam.Value = subject;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@strStartDate", SqlDbType.NVarChar);
            sqlParam1.Value = strStartDate;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@strToDate", SqlDbType.NVarChar);
            sqlParam2.Value = strToDate;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@strHead", SqlDbType.Text);
            sqlParam3.Value = strHead;
            sqlParam3.Size = 5000;
            sqlParams.Add(sqlParam3);



            SqlParameter sqlParam4 = new SqlParameter("@strFoot", SqlDbType.VarChar);
            sqlParam4.Value = strFoot;
            sqlParam4.Size = 5000;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam5.Value = intLoc;
            sqlParam5.Size = 4;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@previewId", SqlDbType.Int);
            sqlParam6.Value = previewId;
            sqlParam6.Size = 4;
            sqlParams.Add(sqlParam6);

            SqlParameter sqlParam7 = new SqlParameter("@prod1", SqlDbType.VarChar);
            sqlParam7.Value = prod1;
            sqlParam7.Size = 50;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@prod2", SqlDbType.VarChar);
            sqlParam8.Value = prod2;
            sqlParam8.Size = 50;
            sqlParams.Add(sqlParam8);

            SqlParameter sqlParam9 = new SqlParameter("@prod3", SqlDbType.VarChar);
            sqlParam9.Value = prod3;
            sqlParam9.Size = 50;
            sqlParams.Add(sqlParam9);

            SqlParameter sqlParam10 = new SqlParameter("@prod4", SqlDbType.VarChar);
            sqlParam10.Value = prod4;
            sqlParam10.Size = 50;
            sqlParams.Add(sqlParam10);

            SqlParameter sqlParam11 = new SqlParameter("@prod5", SqlDbType.VarChar);
            sqlParam11.Value = prod5;
            sqlParam11.Size = 50;
            sqlParams.Add(sqlParam11);

            SqlParameter sqlParam12 = new SqlParameter("@prod6", SqlDbType.VarChar);
            sqlParam12.Value = prod6;
            sqlParam12.Size = 50;
            sqlParams.Add(sqlParam12);

            SqlParameter sqlParam13 = new SqlParameter("@prod7", SqlDbType.VarChar);
            sqlParam13.Value = prod7;
            sqlParam13.Size = 50;
            sqlParams.Add(sqlParam13);

            SqlParameter sqlParam14 = new SqlParameter("@prod8", SqlDbType.VarChar);
            sqlParam14.Value = prod8;
            sqlParam14.Size = 50;
            sqlParams.Add(sqlParam14);


            int updateOrder = 0;

            initializeDBConnection();

            try
            {
                updateOrder = execDMLByKeyParams(DBQuery.updatePreviewInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateOrder = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateOrder = 0;

            }
            dispose();
            return updateOrder;
        }


        /// <summary>
        /// Retrive feature sale product inforamtion
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>

        public DataSet GetFeatureSalesDetails(int locationId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam.Value = locationId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.selectFeatureSalesDetails, sqlParams);




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
            dispose();
            return dateDs;
        }

        /// <summary>
        /// retrive subject information
        /// </summary>
        /// <returns></returns>
        public DataSet SelectSubject()
        {
            DataSet dsSelectUser = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;




            initializeDBConnection();
            try
            {
                dsSelectUser = execDatasetSelectByKey(DBQuery.selectSubject);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectUser = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectUser = null;
            }
            dispose();
            return dsSelectUser;
        }

        /********** New Added for Edit NewletterSale ***************/
        /// <summary>
        /// retrive send mail history
        /// </summary>
        /// <param name="intSendEmailId"></param>
        /// <returns></returns>

        public DataSet SelectSendEmailInformation(int intSendEmailId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intSendEmailId", SqlDbType.Int);
            sqlParam.Value = intSendEmailId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.selectSendEmailInformation, sqlParams);




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
            dispose();
            return dateDs;
        }




        /// <summary>
        /// retrive send email product information
        /// </summary>
        /// <param name="intProductId"></param>
        /// <param name="prodTitle"></param>
        /// <param name="locationId"></param>
        /// <returns></returns>

        public DataSet SelectSendEmailProductInfo(int intProductId, string prodTitle, int locationId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intProductId", SqlDbType.Int);
            sqlParam.Value = intProductId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@prodTitle", SqlDbType.VarChar);
            sqlParam1.Value = prodTitle;
            sqlParam1.Size = 225;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam2.Value = locationId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);


            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.selectSendEmailProductInfo, sqlParams);




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
            dispose();
            return dateDs;
        }


        /// <summary>
        /// retrive send email product information
        /// </summary>
        /// <param name="intProductId"></param>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public DataSet SelectSendEmailProductInformation(int intProductId, int locationId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intProductId", SqlDbType.Int);
            sqlParam.Value = intProductId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam1.Value = locationId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.SelectSendEmailProductInformation, sqlParams);




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
            dispose();
            return dateDs;
        }



        /// <summary>
        /// retrive send email  information
        /// </summary>
        /// <returns></returns>

        public DataSet GetSendEmailDeatils()
        {
            DataSet dsSendEmailDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsSendEmailDeatils = execDatasetSelectByKey(DBQuery.selectdsSendEmailDeatils);
            }
            catch (SqlException sqlEx)
            {
                dsSendEmailDeatils = null;
            }
            catch (Exception ex)
            {
                dsSendEmailDeatils = null;
            }
            return dsSendEmailDeatils;
        }


        /// <summary>
        /// delete send email  information
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>

        public int DeleteSendEmailDeatils(int intID)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intID", SqlDbType.Int);
            sqlParam.Value = intID;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            int deleteAisle = 0;



            initializeDBConnection();

            try
            {
                deleteAisle = execDMLByKeyParams(DBQuery.deleteSendEmailDeatils, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                deleteAisle = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteAisle = 0;

            }
            dispose();
            return deleteAisle;
        }




        /// <summary>
        /// insert send email  information
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="strStartDate"></param>
        /// <param name="strToDate"></param>
        /// <param name="strHead"></param>
        /// <param name="strFoot"></param>
        /// <param name="intLoc"></param>
        /// <param name="dateToday"></param>
        /// <param name="prod1"></param>
        /// <param name="prod2"></param>
        /// <param name="prod3"></param>
        /// <param name="prod4"></param>
        /// <param name="prod5"></param>
        /// <param name="prod6"></param>
        /// <param name="prod7"></param>
        /// <param name="prod8"></param>
        /// <param name="feat1"></param>
        /// <param name="feat2"></param>
        /// <param name="feat3"></param>
        /// <param name="feat4"></param>
        /// <param name="feat5"></param>
        /// <param name="feat6"></param>
        /// <param name="feat7"></param>
        /// <param name="feat8"></param>
        /// <param name="featTit1"></param>
        /// <param name="featTit2"></param>
        /// <param name="featTit3"></param>
        /// <param name="featTit4"></param>
        /// <param name="featTit5"></param>
        /// <param name="featTit6"></param>
        /// <param name="featTit7"></param>
        /// <param name="featTit8"></param>
        /// <param name="prodTit1"></param>
        /// <param name="prodTit2"></param>
        /// <param name="prodTit3"></param>
        /// <param name="prodTit4"></param>
        /// <param name="prodTit5"></param>
        /// <param name="prodTit6"></param>
        /// <param name="prodTit7"></param>
        /// <param name="prodTit8"></param>
        /// <returns></returns>
        public int InsertEmailInfo(string subject, string strStartDate, string strToDate, string strHead, string strFoot, int intLoc, DateTime dateToday, string prod1, string prod2, string prod3, string prod4, string prod5, string prod6, string prod7, string prod8, string feat1, string feat2, string feat3, string feat4, string feat5, string feat6, string feat7, string feat8, string featTit1, string featTit2, string featTit3, string featTit4, string featTit5, string featTit6, string featTit7, string featTit8, string prodTit1, string prodTit2, string prodTit3, string prodTit4, string prodTit5, string prodTit6, string prodTit7, string prodTit8)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@subject", SqlDbType.VarChar);
            sqlParam.Value = subject;
            sqlParam.Size = 100;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@strStartDate", SqlDbType.NVarChar);
            sqlParam1.Value = strStartDate;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@strToDate", SqlDbType.NVarChar);
            sqlParam2.Value = strToDate;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@strHead", SqlDbType.Text);
            sqlParam3.Value = strHead;
            sqlParam3.Size = 5000;
            sqlParams.Add(sqlParam3);



            SqlParameter sqlParam4 = new SqlParameter("@strFoot", SqlDbType.VarChar);
            sqlParam4.Value = strFoot;
            sqlParam4.Size = 5000;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam5.Value = intLoc;
            sqlParam5.Size = 4;
            sqlParams.Add(sqlParam5);


            SqlParameter sqlParam6 = new SqlParameter("@dateToday", SqlDbType.DateTime);
            sqlParam6.Value = dateToday;
            sqlParam6.Size = 8;
            sqlParams.Add(sqlParam6);


            SqlParameter sqlParam7 = new SqlParameter("@prod1", SqlDbType.VarChar);
            sqlParam7.Value = prod1;
            sqlParam7.Size = 250;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@prod2", SqlDbType.VarChar);
            sqlParam8.Value = prod2;
            sqlParam8.Size = 250;
            sqlParams.Add(sqlParam8);

            SqlParameter sqlParam9 = new SqlParameter("@prod3", SqlDbType.VarChar);
            sqlParam9.Value = prod3;
            sqlParam9.Size = 250;
            sqlParams.Add(sqlParam9);

            SqlParameter sqlParam10 = new SqlParameter("@prod4", SqlDbType.VarChar);
            sqlParam10.Value = prod4;
            sqlParam10.Size = 250;
            sqlParams.Add(sqlParam10);

            SqlParameter sqlParam11 = new SqlParameter("@prod5", SqlDbType.VarChar);
            sqlParam11.Value = prod5;
            sqlParam11.Size = 250;
            sqlParams.Add(sqlParam11);

            SqlParameter sqlParam12 = new SqlParameter("@prod6", SqlDbType.VarChar);
            sqlParam12.Value = prod6;
            sqlParam12.Size = 250;
            sqlParams.Add(sqlParam12);

            SqlParameter sqlParam13 = new SqlParameter("@prod7", SqlDbType.VarChar);
            sqlParam13.Value = prod7;
            sqlParam13.Size = 250;
            sqlParams.Add(sqlParam13);

            SqlParameter sqlParam14 = new SqlParameter("@prod8", SqlDbType.VarChar);
            sqlParam14.Value = prod8;
            sqlParam14.Size = 250;
            sqlParams.Add(sqlParam14);

            SqlParameter sqlParam15 = new SqlParameter("@feat1", SqlDbType.VarChar);
            sqlParam15.Value = feat1;
            sqlParam15.Size = 250;
            sqlParams.Add(sqlParam15);

            SqlParameter sqlParam16 = new SqlParameter("@feat2", SqlDbType.VarChar);
            sqlParam16.Value = feat2;
            sqlParam16.Size = 250;
            sqlParams.Add(sqlParam16);

            SqlParameter sqlParam17 = new SqlParameter("@feat3", SqlDbType.VarChar);
            sqlParam17.Value = feat3;
            sqlParam17.Size = 250;
            sqlParams.Add(sqlParam17);

            SqlParameter sqlParam18 = new SqlParameter("@feat4", SqlDbType.VarChar);
            sqlParam18.Value = feat4;
            sqlParam18.Size = 250;
            sqlParams.Add(sqlParam18);

            SqlParameter sqlParam19 = new SqlParameter("@feat5", SqlDbType.VarChar);
            sqlParam19.Value = feat5;
            sqlParam19.Size = 250;
            sqlParams.Add(sqlParam19);

            SqlParameter sqlParam20 = new SqlParameter("@feat6", SqlDbType.VarChar);
            sqlParam20.Value = feat6;
            sqlParam20.Size = 250;
            sqlParams.Add(sqlParam20);

            SqlParameter sqlParam21 = new SqlParameter("@feat7", SqlDbType.VarChar);
            sqlParam21.Value = feat7;
            sqlParam21.Size = 250;
            sqlParams.Add(sqlParam21);

            SqlParameter sqlParam23 = new SqlParameter("@feat8", SqlDbType.VarChar);
            sqlParam23.Value = feat8;
            sqlParam23.Size = 250;
            sqlParams.Add(sqlParam23);


            SqlParameter sqlParam24 = new SqlParameter("@featTit1", SqlDbType.VarChar);
            sqlParam24.Value = featTit1;
            sqlParam24.Size = 250;
            sqlParams.Add(sqlParam24);

            SqlParameter sqlParam25 = new SqlParameter("@featTit2", SqlDbType.VarChar);
            sqlParam25.Value = featTit2;
            sqlParam25.Size = 250;
            sqlParams.Add(sqlParam25);

            SqlParameter sqlParam26 = new SqlParameter("@featTit3", SqlDbType.VarChar);
            sqlParam26.Value = featTit3;
            sqlParam26.Size = 250;
            sqlParams.Add(sqlParam26);

            SqlParameter sqlParam27 = new SqlParameter("@featTit4", SqlDbType.VarChar);
            sqlParam27.Value = featTit4;
            sqlParam27.Size = 250;
            sqlParams.Add(sqlParam27);


            SqlParameter sqlParam28 = new SqlParameter("@featTit5", SqlDbType.VarChar);
            sqlParam28.Value = featTit5;
            sqlParam28.Size = 250;
            sqlParams.Add(sqlParam28);

            SqlParameter sqlParam29 = new SqlParameter("@featTit6", SqlDbType.VarChar);
            sqlParam29.Value = featTit6;
            sqlParam29.Size = 250;
            sqlParams.Add(sqlParam29);

            SqlParameter sqlParam30 = new SqlParameter("@featTit7", SqlDbType.VarChar);
            sqlParam30.Value = featTit7;
            sqlParam30.Size = 250;
            sqlParams.Add(sqlParam30);

            SqlParameter sqlParam31 = new SqlParameter("@featTit8", SqlDbType.VarChar);
            sqlParam31.Value = featTit8;
            sqlParam31.Size = 250;
            sqlParams.Add(sqlParam31);


            SqlParameter sqlParam32 = new SqlParameter("@prodTit1", SqlDbType.VarChar);
            sqlParam32.Value = prodTit1;
            sqlParam32.Size = 250;
            sqlParams.Add(sqlParam32);

            SqlParameter sqlParam33 = new SqlParameter("@prodTit2", SqlDbType.VarChar);
            sqlParam33.Value = prodTit2;
            sqlParam33.Size = 250;
            sqlParams.Add(sqlParam33);

            SqlParameter sqlParam34 = new SqlParameter("@prodTit3", SqlDbType.VarChar);
            sqlParam34.Value = prodTit3;
            sqlParam34.Size = 250;
            sqlParams.Add(sqlParam34);

            SqlParameter sqlParam35 = new SqlParameter("@prodTit4", SqlDbType.VarChar);
            sqlParam35.Value = prodTit4;
            sqlParam35.Size = 250;
            sqlParams.Add(sqlParam35);

            SqlParameter sqlParam36 = new SqlParameter("@prodTit5", SqlDbType.VarChar);
            sqlParam36.Value = prodTit5;
            sqlParam36.Size = 250;
            sqlParams.Add(sqlParam36);

            SqlParameter sqlParam37 = new SqlParameter("@prodTit6", SqlDbType.VarChar);
            sqlParam37.Value = prodTit6;
            sqlParam37.Size = 250;
            sqlParams.Add(sqlParam37);

            SqlParameter sqlParam38 = new SqlParameter("@prodTit7", SqlDbType.VarChar);
            sqlParam38.Value = prodTit7;
            sqlParam38.Size = 250;
            sqlParams.Add(sqlParam38);

            SqlParameter sqlParam39 = new SqlParameter("@prodTit8", SqlDbType.VarChar);
            sqlParam39.Value = prodTit8;
            sqlParam39.Size = 250;
            sqlParams.Add(sqlParam39);

            int updateOrder = 0;

            initializeDBConnection();

            try
            {
                updateOrder = execDMLByKeyParams(DBQuery.insertEmailInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateOrder = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateOrder = 0;

            }
            dispose();
            return updateOrder;
        }

        /// <summary>
        /// retrive  sales information
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>

        public DataSet GetSalesDetailsInformation(int locationId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam.Value = locationId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.selectSalesDetailsInformation, sqlParams);




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
            dispose();
            return dateDs;
        }


        /********* Shashank **********/
        /// <summary>
        /// retrive Admin zip information
        /// </summary>
        /// <returns></returns>
        public DataSet SelectAdminZipCodes()
        {
            DataSet dsSelectUser = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;




            initializeDBConnection();
            try
            {
                dsSelectUser = execDatasetSelectByKey(DBQuery.selectZipCode);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectUser = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectUser = null;
            }
            dispose();
            return dsSelectUser;
        }


        //code to retrive delivery charges according to users zipcode
        public DataSet selectZipCodeDeliveryFee(string UserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@UserId", SqlDbType.Int);
            sqlParam.Value = UserId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet dateDs = new DataSet();

            initializeDBConnection();

            try
            {

                dateDs = execDatasetSelectByKeyParams(DBQuery.selectZipCodeDelivery, sqlParams);


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
            dispose();
            return dateDs;
        }



        //Code to delete Zip Code from admin
        public int deleteZipCode(int zipcode_id)
        {

            int returnCount = 0;


            List<SqlParameter> sqlParams = new List<SqlParameter>();
            SqlParameter sqlParam = new SqlParameter("@zipcode_id", SqlDbType.Int);
            sqlParam.Value = zipcode_id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            initializeDBConnection();
            try
            {

                returnCount = execDMLByKeyParams(DBQuery.deletZipCode, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                string str = sqlEx.Message;
            }
            finally
            {
                dispose();
            }
            return returnCount;


        }

        //Code check zipcode is already exicts


        public int checkZipCode(string zipcode_zipcode, int zipCodeId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@zipcode_zipcode", SqlDbType.VarChar);
            sqlParam.Value = zipcode_zipcode;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@zipCodeId", SqlDbType.Int);
            sqlParam1.Value = zipCodeId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            int zipCodesId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.checkZipAvalable, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        zipCodesId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    zipCodesId = 0;
                }

            }
            catch (SqlException sqlEx)
            {
                zipCodesId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                zipCodesId = 0;

            }
            dispose();
            return zipCodesId;
        }


        /// <summary>
        /// check Zip Code information
        /// </summary>
        /// <param name="zipcode_zipcode"></param>
        /// <returns></returns>
        public int checkZipAddCode(string zipcode_zipcode)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@zipcode_zipcode", SqlDbType.VarChar);
            sqlParam.Value = zipcode_zipcode;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);



            int zipCodesId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.checkZipAddAvalable, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        zipCodesId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    zipCodesId = 0;
                }

            }
            catch (SqlException sqlEx)
            {
                zipCodesId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                zipCodesId = 0;

            }
            dispose();
            return zipCodesId;
        }

        //public int addNewZipCode(string zipcode_zipcode, int location_id, string zipcode_name, int DeliveryFee, int ZipOrderSize)
        //{
        //    List<SqlParameter> sqlParams = new List<SqlParameter>();
        //    int returnValueInsert = 0;


        //    SqlParameter sqlParam = new SqlParameter("@zipcode_zipcode", SqlDbType.VarChar);
        //    sqlParam.Value = zipcode_zipcode;
        //    sqlParam.Size = 50;
        //    sqlParams.Add(sqlParam);

        //    SqlParameter sqlParam1 = new SqlParameter("@location_id", SqlDbType.Int);
        //    sqlParam1.Value = location_id;
        //    sqlParam1.Size = 4;
        //    sqlParams.Add(sqlParam1);

        //    SqlParameter sqlParam2 = new SqlParameter("@zipcode_name", SqlDbType.VarChar);
        //    sqlParam2.Value = zipcode_name;
        //    sqlParam2.Size = 50;
        //    sqlParams.Add(sqlParam2);


        //    //SqlParameter sqlParam3 = new SqlParameter("@DeliveryFee", SqlDbType.Int);
        //    //sqlParam3.Value = DeliveryFee;
        //    //sqlParam3.Size = 4;
        //    //sqlParams.Add(sqlParam3);

        //    SqlParameter sqlParam4 = new SqlParameter("@ZipOrderSize", SqlDbType.Int);
        //    sqlParam4.Value = ZipOrderSize;
        //    sqlParam4.Size = 4;
        //    sqlParams.Add(sqlParam4);


        //    initializeDBConnection();
        //    try
        //    {

        //        returnValueInsert = execDMLByQueryParams(DBQuery.insertZipCode, sqlParams);

        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        string str;
        //        str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

        //    }
        //    catch (Exception ex)
        //    {
        //        string str;
        //        str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

        //    }

        //    finally
        //    {
        //        dispose();
        //    }

        //    return returnValueInsert;
        //}
        //Funnction for Add New zip code

        //public int addNewZipCode(string zipcode_zipcode, int location_id, string zipcode_name, int DeliveryFee, int ZipOrderSize)
        //{
        //    List<SqlParameter> sqlParams = new List<SqlParameter>();
        //    int returnValueInsert = 0;


        //    SqlParameter sqlParam = new SqlParameter("@zipcode_zipcode", SqlDbType.VarChar);
        //    sqlParam.Value = zipcode_zipcode;
        //    sqlParam.Size = 50;
        //    sqlParams.Add(sqlParam);

        //    SqlParameter sqlParam1 = new SqlParameter("@location_id", SqlDbType.Int);
        //    sqlParam1.Value = location_id;
        //    sqlParam1.Size = 4;
        //    sqlParams.Add(sqlParam1);

        //    SqlParameter sqlParam2 = new SqlParameter("@zipcode_name", SqlDbType.VarChar);
        //    sqlParam2.Value = zipcode_name;
        //    sqlParam2.Size = 50;
        //    sqlParams.Add(sqlParam2);


        //    //SqlParameter sqlParam3 = new SqlParameter("@DeliveryFee", SqlDbType.Int);
        //    //sqlParam3.Value = DeliveryFee;
        //    //sqlParam3.Size = 4;
        //    //sqlParams.Add(sqlParam3);

        //    SqlParameter sqlParam4 = new SqlParameter("@ZipOrderSize", SqlDbType.Int);
        //    sqlParam4.Value = ZipOrderSize;
        //    sqlParam4.Size = 4;
        //    sqlParams.Add(sqlParam4);


        //    initializeDBConnection();
        //    try
        //    {

        //        returnValueInsert = execDMLByQueryParams(DBQuery.insertZipCode, sqlParams);

        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        string str;
        //        str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

        //    }
        //    catch (Exception ex)
        //    {
        //        string str;
        //        str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

        //    }

        //    finally
        //    {
        //        dispose();
        //    }

        //    return returnValueInsert;
        //}


        public int addNewZipCode1(string zipcode_zipcode, int location_id, string zipcode_name, int ZipOrderSize)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;


            SqlParameter sqlParam = new SqlParameter("@zipcode_zipcode", SqlDbType.VarChar);
            sqlParam.Value = zipcode_zipcode;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@location_id", SqlDbType.Int);
            sqlParam1.Value = location_id;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@zipcode_name", SqlDbType.VarChar);
            sqlParam2.Value = zipcode_name;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);


            //SqlParameter sqlParam3 = new SqlParameter("@DeliveryFee", SqlDbType.Int);
            //sqlParam3.Value = DeliveryFee;
            //sqlParam3.Size = 4;
            //sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@ZipOrderSize", SqlDbType.Int);
            sqlParam4.Value = ZipOrderSize;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            initializeDBConnection();
            try
            {

                returnValueInsert = execDMLByQueryParams(DBQuery.insertZipCode, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }

        //Function for get zip code ID for update.
        public DataSet GetZipCodeDetails(int zipcode_id)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@zipcode_id", SqlDbType.Int);
            sqlParam.Value = zipcode_id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet getZipCode = new DataSet();

            initializeDBConnection();

            try
            {
                getZipCode = execDatasetSelectByKeyParams(DBQuery.selectZipCodeForUpdate, sqlParams);
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
            dispose();
            return getZipCode;
        }

        /// <summary>
        /// update ZipCode  information
        /// </summary>
        /// <param name="zipcode_id"></param>
        /// <param name="zipcode_zipcode"></param>
        /// <param name="location_id"></param>
        /// <param name="zipcode_name"></param>
        /// <param name="orderSize"></param>
        /// <returns></returns>
        public int updateZipCode(int zipcode_id, string zipcode_zipcode, int location_id, string zipcode_name)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;

            SqlParameter sqlParam = new SqlParameter("@zipcode_id", SqlDbType.Int);
            sqlParam.Value = zipcode_id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@zipcode_zipcode", SqlDbType.VarChar);
            sqlParam1.Value = zipcode_zipcode;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@location_id", SqlDbType.Int);
            sqlParam2.Value = location_id;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@zipcode_name", SqlDbType.VarChar);
            sqlParam3.Value = zipcode_name;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);




            initializeDBConnection();
            try
            {

                returnValueInsert = execDMLByQueryParams(DBQuery.updateZipCode, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }

        public int updateZipCode(int zipcode_id, string zipcode_zipcode, int location_id, string zipcode_name, int DeliveryFee, int ZipOrderSize)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;

            SqlParameter sqlParam = new SqlParameter("@zipcode_id", SqlDbType.Int);
            sqlParam.Value = zipcode_id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@zipcode_zipcode", SqlDbType.VarChar);
            sqlParam1.Value = zipcode_zipcode;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@location_id", SqlDbType.Int);
            sqlParam2.Value = location_id;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@zipcode_name", SqlDbType.VarChar);
            sqlParam3.Value = zipcode_name;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@DeliveryFee", SqlDbType.Int);
            sqlParam4.Value = DeliveryFee;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);
            SqlParameter sqlParam5 = new SqlParameter("@ZipOrderSize", SqlDbType.Int);
            sqlParam5.Value = ZipOrderSize;
            sqlParam5.Size = 4;
            sqlParams.Add(sqlParam5);

            initializeDBConnection();
            try
            {

                returnValueInsert = execDMLByQueryParams(DBQuery.updateZipCode, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }

        public int updateZipCode1(int zipcode_id, string zipcode_zipcode, int location_id, string zipcode_name, double orderSize)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;

            SqlParameter sqlParam = new SqlParameter("@zipcode_id", SqlDbType.Int);
            sqlParam.Value = zipcode_id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@zipcode_zipcode", SqlDbType.VarChar);
            sqlParam1.Value = zipcode_zipcode;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@location_id", SqlDbType.Int);
            sqlParam2.Value = location_id;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@zipcode_name", SqlDbType.VarChar);
            sqlParam3.Value = zipcode_name;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@orderSize", SqlDbType.Float);
            sqlParam4.Value = orderSize;
            sqlParam4.Size = 8;
            sqlParams.Add(sqlParam4);



            initializeDBConnection();
            try
            {

                returnValueInsert = execDMLByQueryParams(DBQuery.updateZipCode1, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }

        //Functtion for get Shopping Cart constant
        public DataSet GetShoppingCartConstant(int ConstantId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@ConstantId", SqlDbType.Int);
            sqlParam.Value = ConstantId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet getZipCode = new DataSet();

            initializeDBConnection();

            try
            {
                getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingCartConstant, sqlParams);
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
            dispose();
            return getZipCode;
        }

        //Functtion for update Shopping Cart constant
        public int updateShoppingCartConstant(int ConstantId, double DeliveryFee, double TaxRate, double TaxRate1, double MinimumDeposit, int Numberoftimeslot, double DeliveryFeeCutOff, string CustomerServiceEmail, string ContactEmail, string InfoEmail, string LocationName, string StateShortName, string StateLongName, string CompanyShortName, string CompanyLongName, string ShortURL, string LongURL, double FirstOrderGift, double OneHrDeliveryFee)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;

            SqlParameter sqlParam = new SqlParameter("@ConstantId", SqlDbType.Int);
            sqlParam.Value = ConstantId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@DeliveryFee", SqlDbType.Float);
            sqlParam1.Value = DeliveryFee;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam3 = new SqlParameter("@TaxRate", SqlDbType.Float);
            sqlParam3.Value = TaxRate;
            sqlParam3.Size = 8;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@TaxRate1", SqlDbType.Float);
            sqlParam4.Value = TaxRate1;
            sqlParam4.Size = 8;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@MinimumDeposit", SqlDbType.Float);
            sqlParam5.Value = MinimumDeposit;
            sqlParam5.Size = 8;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@Numberoftimeslot", SqlDbType.Int);
            sqlParam6.Value = Numberoftimeslot;
            sqlParam6.Size = 4;
            sqlParams.Add(sqlParam6);

            SqlParameter sqlParam7 = new SqlParameter("@DeliveryFeeCutOff", SqlDbType.Float);
            sqlParam7.Value = DeliveryFeeCutOff;
            sqlParam7.Size = 8;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@CustomerServiceEmail", SqlDbType.VarChar);
            sqlParam8.Value = CustomerServiceEmail;
            sqlParam8.Size = 50;
            sqlParams.Add(sqlParam8);

            SqlParameter sqlParam9 = new SqlParameter("@ContactEmail", SqlDbType.VarChar);
            sqlParam9.Value = ContactEmail;
            sqlParam9.Size = 50;
            sqlParams.Add(sqlParam9);

            SqlParameter sqlParam10 = new SqlParameter("@InfoEmail", SqlDbType.VarChar);
            sqlParam10.Value = InfoEmail;
            sqlParam10.Size = 50;
            sqlParams.Add(sqlParam10);

            SqlParameter sqlParam11 = new SqlParameter("@LocationName", SqlDbType.VarChar);
            sqlParam11.Value = LocationName;
            sqlParam11.Size = 50;
            sqlParams.Add(sqlParam11);

            SqlParameter sqlParam12 = new SqlParameter("@StateShortName", SqlDbType.VarChar);
            sqlParam12.Value = StateShortName;
            sqlParam12.Size = 50;
            sqlParams.Add(sqlParam12);

            SqlParameter sqlParam13 = new SqlParameter("@StateLongName", SqlDbType.VarChar);
            sqlParam13.Value = StateLongName;
            sqlParam13.Size = 50;
            sqlParams.Add(sqlParam13);

            SqlParameter sqlParam14 = new SqlParameter("@CompanyShortName", SqlDbType.VarChar);
            sqlParam14.Value = CompanyShortName;
            sqlParam14.Size = 50;
            sqlParams.Add(sqlParam14);

            SqlParameter sqlParam15 = new SqlParameter("@CompanyLongName", SqlDbType.VarChar);
            sqlParam15.Value = CompanyLongName;
            sqlParam15.Size = 50;
            sqlParams.Add(sqlParam15);

            SqlParameter sqlParam16 = new SqlParameter("@ShortURL", SqlDbType.VarChar);
            sqlParam16.Value = ShortURL;
            sqlParam16.Size = 50;
            sqlParams.Add(sqlParam16);

            SqlParameter sqlParam17 = new SqlParameter("@LongURL", SqlDbType.VarChar);
            sqlParam17.Value = LongURL;
            sqlParam17.Size = 50;
            sqlParams.Add(sqlParam17);
            SqlParameter sqlParam18 = new SqlParameter("@FirstOrderGift", SqlDbType.Float);
            sqlParam18.Value = FirstOrderGift;
            sqlParam18.Size = 8;
            sqlParams.Add(sqlParam18);

            SqlParameter sqlParam19 = new SqlParameter("@OneHrDeliveryFee", SqlDbType.Float);
            sqlParam19.Value = OneHrDeliveryFee;
            sqlParam19.Size = 8;
            sqlParams.Add(sqlParam19);

            //
            initializeDBConnection();
            try
            {

                returnValueInsert = execDMLByQueryParams(DBQuery.updateShoppingCartConstant, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }

        //Functtion for update Location Shopping Cart constant 
        public int updateLocationName(int location_id, string location_name)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;

            SqlParameter sqlParam = new SqlParameter("@location_id", SqlDbType.Int);
            sqlParam.Value = location_id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@location_name", SqlDbType.VarChar);
            sqlParam1.Value = location_name;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            initializeDBConnection();
            try
            {

                returnValueInsert = execDMLByQueryParams(DBQuery.updateLocationName, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }

        //Funftion for getting company name
        public DataSet getShortCompanyName()
        {
            DataSet dsSelectCompanyName = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;

            initializeDBConnection();
            try
            {
                dsSelectCompanyName = execDatasetSelectByKey(DBQuery.selectCompanyName);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectCompanyName = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectCompanyName = null;
            }
            dispose();
            return dsSelectCompanyName;
        }

        //Functtion for get info email 
        public DataSet GetInfoEmmailAddressConstant(int ConstantId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@ConstantId", SqlDbType.Int);
            sqlParam.Value = ConstantId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet getZipCode = new DataSet();

            initializeDBConnection();

            try
            {
                getZipCode = execDatasetSelectByKeyParams(DBQuery.selectInfoEmailAddressConstant, sqlParams);
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
            dispose();
            return getZipCode;
        }

        //Functtion for get all users email address for sending newsletter
        public DataSet GetUsersEmailAddress(int usersstatus_id, int users_newsletter)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@usersstatus_id", SqlDbType.Int);
            sqlParam.Value = usersstatus_id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@users_newsletter", SqlDbType.Int);
            sqlParam1.Value = users_newsletter;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            DataSet getZipCode = new DataSet();

            initializeDBConnection();

            try
            {
                getZipCode = execDatasetSelectByKeyParams(DBQuery.selectUserExmailAddress, sqlParams);
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
            dispose();
            return getZipCode;
        }

        //Function for update payment option 


        public int updateOaymentOption(int payment_option_Id, int payment_Id, string APILogin, string TranKey, string PostUrl, string EndPayUrl, string PayUserNm, string PayPwd, string PaySignature, string ECURL, string ECURLLOGIN)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;

            SqlParameter sqlParam = new SqlParameter("@payment_option_Id", SqlDbType.Int);
            sqlParam.Value = payment_option_Id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@payment_Id", SqlDbType.VarChar);
            sqlParam1.Value = payment_Id;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@APILogin", SqlDbType.NVarChar);
            sqlParam2.Value = APILogin;
            sqlParam2.Size = 100;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@TranKey", SqlDbType.NVarChar);
            sqlParam3.Value = TranKey;
            sqlParam3.Size = 100;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@PostUrl", SqlDbType.NVarChar);
            sqlParam4.Value = PostUrl;
            sqlParam4.Size = 500;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@EndPayUrl", SqlDbType.NVarChar);
            sqlParam5.Value = EndPayUrl;
            sqlParam5.Size = 500;
            sqlParams.Add(sqlParam5);


            SqlParameter sqlParam6 = new SqlParameter("@PayUserNm", SqlDbType.NVarChar);
            sqlParam6.Value = PayUserNm;
            sqlParam6.Size = 100;
            sqlParams.Add(sqlParam6);

            SqlParameter sqlParam7 = new SqlParameter("@PayPwd", SqlDbType.NVarChar);
            sqlParam7.Value = PayPwd;
            sqlParam7.Size = 100;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@PaySignature", SqlDbType.NVarChar);
            sqlParam8.Value = PaySignature;
            sqlParam8.Size = 500;
            sqlParams.Add(sqlParam8);

            SqlParameter sqlParam9 = new SqlParameter("@ECURL", SqlDbType.NVarChar);
            sqlParam9.Value = ECURL;
            sqlParam9.Size = 500;
            sqlParams.Add(sqlParam9);

            SqlParameter sqlParam10 = new SqlParameter("@ECURLLOGIN", SqlDbType.NVarChar);
            sqlParam10.Value = ECURLLOGIN;
            sqlParam10.Size = 500;
            sqlParams.Add(sqlParam10);

            initializeDBConnection();
            try
            {
                if (payment_Id == 1)
                {
                    returnValueInsert = execDMLByQueryParams(DBQuery.updatePaymentOption, sqlParams);
                }
                else if (payment_Id == 2)
                {
                    returnValueInsert = execDMLByQueryParams(DBQuery.updatePaymentOption1, sqlParams);

                }

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }








        public int updateOaymentOptionNew(int payment_option_Id, int payment_Id, string APILogin, string TranKey, string PostUrl, string PayUrl, string busEmail, string subUrl, string PdtToken)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;

            SqlParameter sqlParam = new SqlParameter("@payment_option_Id", SqlDbType.Int);
            sqlParam.Value = payment_option_Id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@payment_Id", SqlDbType.VarChar);
            sqlParam1.Value = payment_Id;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@APILogin", SqlDbType.NVarChar);
            sqlParam2.Value = APILogin;
            sqlParam2.Size = 100;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@TranKey", SqlDbType.NVarChar);
            sqlParam3.Value = TranKey;
            sqlParam3.Size = 100;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@PostUrl", SqlDbType.NVarChar);
            sqlParam4.Value = PostUrl;
            sqlParam4.Size = 500;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@PayUrl", SqlDbType.NVarChar);
            sqlParam5.Value = PayUrl;
            sqlParam5.Size = 500;
            sqlParams.Add(sqlParam5);


            SqlParameter sqlParam6 = new SqlParameter("@busEmail", SqlDbType.NVarChar);
            sqlParam6.Value = busEmail;
            sqlParam6.Size = 100;
            sqlParams.Add(sqlParam6);

            SqlParameter sqlParam7 = new SqlParameter("@subUrl", SqlDbType.NVarChar);
            sqlParam7.Value = subUrl;
            sqlParam7.Size = 500;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@PdtToken", SqlDbType.NVarChar);
            sqlParam8.Value = PdtToken;
            sqlParam8.Size = 1000;
            sqlParams.Add(sqlParam8);





            initializeDBConnection();
            try
            {
                if (payment_Id == 1)
                {
                    returnValueInsert = execDMLByQueryParams(DBQuery.updatePaymentOption, sqlParams);
                }
                else if (payment_Id == 2)
                {

                    returnValueInsert = execDMLByQueryParams(DBQuery.updatePaymentOptionNew1, sqlParams);

                }

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }








        /// <summary>
        /// retrive paymant potion
        /// </summary>
        /// <param name="payment_option_Id"></param>
        /// <returns></returns>
        public DataSet GetPaymentOption(int payment_option_Id)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@payment_option_Id", SqlDbType.Int);
            sqlParam.Value = payment_option_Id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            DataSet getZipCode = new DataSet();

            initializeDBConnection();

            try
            {
                getZipCode = execDatasetSelectByKeyParams(DBQuery.selectPaymentOptionsForDisplay, sqlParams);
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
            dispose();
            return getZipCode;
        }






        //Functtion for get all users email address for sending newsletter
        public DataSet GetUsersEmailAddressForDeliveryReminder(string orders_deliverydate)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@orders_deliverydate", SqlDbType.VarChar);
            sqlParam.Value = orders_deliverydate;
            sqlParam.Size = 25;
            sqlParams.Add(sqlParam);


            DataSet getOrderReminder = new DataSet();

            initializeDBConnection();

            try
            {
                getOrderReminder = execDatasetSelectByKeyParams(DBQuery.selectDeliveryReminderInformation, sqlParams);
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
            dispose();
            return getOrderReminder;
        }


        //Function for get zip code ID for update.

        public DataSet getDeliveryReminderSentEmailInfo()
        {
            DataSet dsSelectDeliveryReminder = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;

            initializeDBConnection();
            try
            {
                dsSelectDeliveryReminder = execDatasetSelectByKey(DBQuery.selctDeliveryReminderSentEmailDate);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectDeliveryReminder = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectDeliveryReminder = null;
            }
            dispose();
            return dsSelectDeliveryReminder;
        }


        // Function for Update Delivery reminder sent email dates
        public int updateDeliveryReminder(string deliverydate_date)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;

            SqlParameter sqlParam = new SqlParameter("@deliverydate_date", SqlDbType.VarChar);
            sqlParam.Value = deliverydate_date;
            sqlParam.Size = 25;
            sqlParams.Add(sqlParam);


            initializeDBConnection();
            try
            {

                returnValueInsert = execDMLByQueryParams(DBQuery.updateDeliveryReminder, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }

        //Function fro get shopping list dates
        public DataSet getShoppingListDates()
        {
            DataSet dsSelectDeliveryReminder = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;

            initializeDBConnection();
            try
            {
                dsSelectDeliveryReminder = execDatasetSelectByKey(DBQuery.selectShoppingListDates);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectDeliveryReminder = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectDeliveryReminder = null;
            }
            dispose();
            return dsSelectDeliveryReminder;
        }

        //Function for getting Shopping cart list 
        public DataSet getShoppingCartListDateWise(string orders_deliverydate)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@orders_deliverydate", SqlDbType.VarChar);
            sqlParam.Value = orders_deliverydate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            DataSet getZipCode = new DataSet();

            initializeDBConnection();

            try
            {
                //getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingListProducts, sqlParams);
                getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingListProducts1, sqlParams);
                // getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingListsProducts, sqlParams);
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
            dispose();
            return getZipCode;
        }


        public DataSet getShoppingCartListDateWise_New(string orders_deliverydate)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@orders_deliverydate", SqlDbType.VarChar);
            sqlParam.Value = orders_deliverydate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            DataSet getZipCode = new DataSet();

            initializeDBConnection();

            try
            {
                //getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingListProducts, sqlParams);
                getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingListproduct_new, sqlParams);
                // getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingListsProducts, sqlParams);
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
            dispose();
            return getZipCode;
        }

        public DataSet getShoppingCartListDateWise1(string orders_deliverydate)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@orders_deliverydate", SqlDbType.VarChar);
            sqlParam.Value = orders_deliverydate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            DataSet getZipCode = new DataSet();

            initializeDBConnection();

            try
            {
                // getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingListProducts, sqlParams);
                getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingListProducts1, sqlParams);
                // getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingListsProducts, sqlParams);
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
            dispose();
            return getZipCode;
        }


        public DataSet getShoppingCartListDateWiseNew(string orders_deliverydate, string sortexpressions)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@orders_deliverydate", SqlDbType.VarChar);
            sqlParam.Value = orders_deliverydate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            DataSet getZipCode = new DataSet();

            initializeDBConnection();

            try
            {
                if (sortexpressions == "product_title")
                {
                    getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingListProducts_title, sqlParams);
                }
                if (sortexpressions == "shelf_position")
                {
                    getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingListProducts_position, sqlParams);
                }
                if (sortexpressions == "shelf_name")
                {
                    getZipCode = execDatasetSelectByKeyParams(DBQuery.selectShoppingListsProducts_shelfname, sqlParams);
                }
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
            dispose();
            return getZipCode;
        }


        // Function for search report by desc order


        public DataSet getSearchReportsByDescOrder()
        {
            DataSet dsSelectSearchReport = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;

            initializeDBConnection();
            try
            {
                dsSelectSearchReport = execDatasetSelectByKey(DBQuery.selectSearchReportDsc);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectSearchReport = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectSearchReport = null;
            }
            dispose();
            return dsSelectSearchReport;
        }

        // Function for search report by asc order


        public DataSet getSearchReportsByAscOrder()
        {
            DataSet dsSelectSearchReport = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;

            initializeDBConnection();
            try
            {
                dsSelectSearchReport = execDatasetSelectByKey(DBQuery.selectSearchReportAsc);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectSearchReport = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectSearchReport = null;
            }
            dispose();
            return dsSelectSearchReport;
        }

        /**************** User Side *******************************/
        /// <summary>
        /// retrive asile information
        /// </summary>
        /// <returns></returns>
        public DataSet GetUserAislesDeatils()
        {
            DataSet dsAislesDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsAislesDeatils = execDatasetSelectByKey(DBQuery.selectUserAislesDeatils);
            }
            catch (SqlException sqlEx)
            {
                dsAislesDeatils = null;
            }
            catch (Exception ex)
            {
                dsAislesDeatils = null;
            }
            return dsAislesDeatils;
        }


        public DataSet GetUserAislesDeatilsHighlighted()
        {
            DataSet dsAislesDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsAislesDeatils = execDatasetSelectByKey(DBQuery.selectUserAislesDeatilsTop);
            }
            catch (SqlException sqlEx)
            {
                dsAislesDeatils = null;
            }
            catch (Exception ex)
            {
                dsAislesDeatils = null;
            }
            return dsAislesDeatils;
        }

        public DataSet GetAllUserAislesDeatils()
        {
            DataSet dsAislesDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsAislesDeatils = execDatasetSelectByKey(DBQuery.selectAllUserAislesDeatils);
            }
            catch (SqlException sqlEx)
            {
                dsAislesDeatils = null;
            }
            catch (Exception ex)
            {
                dsAislesDeatils = null;
            }
            return dsAislesDeatils;
        }
        /// <summary>
        /// check user existance
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DataSet GetUserLoginInfo(string username, string password)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@username", SqlDbType.VarChar);
            sqlParam.Value = username;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@password", SqlDbType.VarChar);
            sqlParam1.Value = password;
            sqlParam1.Size = 30;
            sqlParams.Add(sqlParam1);

            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserLoginInfo, sqlParams);



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
            dispose();
            return loginDs;
        }

        /// <summary>
        /// check email already exist
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataSet GetUserEmailInfo(string username)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@username", SqlDbType.VarChar);
            sqlParam.Value = username;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);




            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserEmailInfo, sqlParams);



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
            dispose();
            return loginDs;
        }

        /// <summary>
        /// retrive zip code information
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public DataSet GetUserZipInfo(string zipCode)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@zipCode", SqlDbType.VarChar);
            sqlParam.Value = zipCode;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);




            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserZipCodeInfo, sqlParams);



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
            dispose();
            return loginDs;
        }


        /// <summary>
        /// retrive search result for product by key word
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataSet GetSearchDetails1(string strKey, int locId, int search)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strKey", SqlDbType.VarChar);
            sqlParam.Value = strKey;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam1.Value = locId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@search", SqlDbType.Int);
            sqlParam2.Value = search;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);




            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                if (search == 0)
                {
                    loginDs = execDatasetSelectByKeyParams(DBQuery.selectSearchDetails1, sqlParams);
                }
                else if (search == 1)
                {
                    loginDs = execDatasetSelectByKeyParams(DBQuery.selectSearchDetails2, sqlParams);

                }



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
            dispose();
            return loginDs;
        }


        /// <summary>
        /// insert search result information
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dtToday"></param>
        /// <param name="locationId"></param>
        /// <param name="total"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int InsertSearchResultInfo(string key, DateTime dtToday, int locationId, int total, int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@key", SqlDbType.VarChar);
            sqlParam.Value = key;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@dtToday", SqlDbType.DateTime);
            sqlParam1.Value = dtToday;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam2.Value = locationId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@total", SqlDbType.Int);
            sqlParam3.Value = total;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam4.Value = userId;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            int intInsert = 0;


            initializeDBConnection();

            try
            {
                if (userId == 0)
                {
                    intInsert = execDMLByKeyParams(DBQuery.insertSearchResultInfo1, sqlParams);
                }
                else
                {
                    intInsert = execDMLByKeyParams(DBQuery.insertSearchResultInfo, sqlParams);
                }


            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }


        /// <summary>
        /// retrive shelf name details
        /// </summary>
        /// <param name="aisleId"></param>
        /// <returns></returns>
        public DataSet GetUserShelfNameDeatils(int aisleId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisleId", SqlDbType.Int);
            sqlParam.Value = aisleId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);





            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserShelfNameDeatils, sqlParams);




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
            dispose();
            return loginDs;
        }

        /// <summary>
        /// retrive shelf name details
        /// </summary>
        /// <param name="aisleId"></param>
        /// <returns></returns>
        public DataSet GetUserPopShelfNameDeatils(int aisleId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisleId", SqlDbType.Int);
            sqlParam.Value = aisleId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);





            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserPopShelfNameDeatils, sqlParams);




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
            dispose();
            return loginDs;
        }


        public DataSet GetUserShelfDeatils(int aisleId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisle_id", SqlDbType.Int);
            sqlParam.Value = aisleId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);





            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserShelfDeatils, sqlParams);




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
            dispose();
            return loginDs;
        }



        public DataSet GetUserAisleNameDeatils(int aisletopid)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisletop_id", SqlDbType.Int);
            sqlParam.Value = aisletopid;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);





            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserAisleNameDeatils, sqlParams);




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
            dispose();
            return loginDs;
        }



        /// <summary>
        /// retrive aisle and shelf name details
        /// </summary>
        /// <param name="aisleId"></param>
        /// <param name="intShelf"></param>
        /// <returns></returns>
        public DataSet GetAisleInfo(int aisleId, int intShelf, int intAisleTopId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisleId", SqlDbType.Int);
            sqlParam.Value = aisleId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intShelf", SqlDbType.Int);
            sqlParam1.Value = intShelf;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);





            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectAisleInfo, sqlParams);




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
            dispose();
            return loginDs;
        }


        /// <summary>
        /// retrive shopped product  details
        /// </summary>
        /// <param name="aisleId"></param>
        /// <param name="intShelf"></param>
        /// <param name="intLoc"></param>
        /// <returns></returns>
        public DataSet GetShopProductInfo(int aisletop_id, int intShelf, int intLoc)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisletop_id", SqlDbType.Int);
            sqlParam.Value = aisletop_id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intShelf", SqlDbType.Int);
            sqlParam1.Value = intShelf;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam2.Value = intLoc;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);





            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectShopProductInfo, sqlParams);




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
            dispose();
            return loginDs;
        }


        /// <summary>
        /// retrive shopped popular product  details
        /// </summary>
        /// <param name="aisleId"></param>
        /// <param name="intShelf"></param>
        /// <param name="intLoc"></param>
        /// <returns></returns>
        public DataSet GetShopPopularProductInfo(int aisleId, int intShelf, int intLoc)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisleId", SqlDbType.Int);
            sqlParam.Value = aisleId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intShelf", SqlDbType.Int);
            sqlParam1.Value = intShelf;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam2.Value = intLoc;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);





            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectShopPopularProductInfo, sqlParams);




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
            dispose();
            return loginDs;
        }

        /// <summary>
        /// retrive  product price  details
        /// </summary>
        /// <param name="strProdNm"></param>
        /// <returns></returns>
        public DataSet ProductPriceAmount(string strProdNm, int prodId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strProdNm", SqlDbType.VarChar);
            sqlParam.Value = strProdNm;
            sqlParam.Size = 1000;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@prodId", SqlDbType.Int);
            sqlParam1.Value = prodId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);





            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectProductPriceAmount, sqlParams);




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
            dispose();
            return loginDs;
        }



        /// <summary>
        /// To select tax rates  
        /// </summary>
        /// <returns></returns>
        public DataSet GetUserTaxRate(string strTaxRate)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@taxId", SqlDbType.VarChar);
            sqlParam.Value = strTaxRate;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet dsTaxRate = new DataSet();

            initializeDBConnection();

            try
            {
                dsTaxRate = execDatasetSelectByKeyParams(DBQuery.selectTaxAmount, sqlParams);




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
            dispose();
            return dsTaxRate;
        }

        /// <summary>
        /// To select Minimum Order Amount
        /// </summary>
        /// <param name="strTaxRate"></param>
        /// <returns></returns>

        public DataSet GetUserMinAmount(int intMinOrdId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@MinOrdId", SqlDbType.Int);
            sqlParam.Value = intMinOrdId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet dsTaxRate = new DataSet();

            initializeDBConnection();

            try
            {
                dsTaxRate = execDatasetSelectByKeyParams(DBQuery.selectMinAmount, sqlParams);




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
            dispose();
            return dsTaxRate;
        }

        /// <summary>
        /// retrive product  details information
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public DataSet SelectProductInfoDeatils(int productId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productId", SqlDbType.Int);
            sqlParam.Value = productId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {

                productDs = execDatasetSelectByKeyParams(DBQuery.selectProductInfoDeatils, sqlParams);


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
            dispose();
            return productDs;
        }


        /// <summary>
        /// retrive minimum order information
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataSet GetMinOrderAmt(int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {

                productDs = execDatasetSelectByKeyParams(DBQuery.selectMinOrderAmt, sqlParams);


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
            dispose();
            return productDs;
        }


        /// <summary>
        /// retrive suggested product  details information
        /// </summary>
        /// <param name="locId"></param>
        /// <returns></returns>
        public DataSet GetSuggestProdInfo(int locId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {

                productDs = execDatasetSelectByKeyParams(DBQuery.selectSuggestProdInfo, sqlParams);




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
            dispose();
            return productDs;
        }


        /// <summary>
        /// retrive delivery time  information
        /// </summary>
        /// <returns></returns>
        public DataSet GetDelveryTimeInformation()
        {
            DataSet dsInfo = default(DataSet);

            initializeDBConnection();
            try
            {
                dsInfo = execDatasetSelectByKey(DBQuery.selectdDelveryTimeInformation);
            }
            catch (SqlException sqlEx)
            {
                dsInfo = null;
            }
            catch (Exception ex)
            {
                dsInfo = null;
            }
            return dsInfo;
        }

        /// <summary>
        /// retrive delivery time  information
        /// </summary>
        /// <param name="delId"></param>
        /// <returns></returns>
        public DataSet GetDelveryTimeInfo(int delId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@delId", SqlDbType.Int);
            sqlParam.Value = delId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {

                productDs = execDatasetSelectByKeyParams(DBQuery.selectDelveryTimeInfo, sqlParams);




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
            dispose();
            return productDs;
        }
        public DataSet GetDelveryTimeInfo1(int delId, int deltime_id)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@delId", SqlDbType.Int);
            sqlParam.Value = delId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@deltime_id", SqlDbType.Int);
            sqlParam1.Value = deltime_id;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {

                productDs = execDatasetSelectByKeyParams(DBQuery.selectDelveryTimeInfo1, sqlParams);




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
            dispose();
            return productDs;
        }

        /// <summary>
        /// retrive home page text  information
        /// </summary>
        /// <returns></returns>
        public DataSet GetHomePageTxt()
        {
            DataSet dsSelectCompanyName = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;

            initializeDBConnection();
            try
            {
                dsSelectCompanyName = execDatasetSelectByKey(DBQuery.selectHomePageTxt);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectCompanyName = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectCompanyName = null;
            }
            dispose();
            return dsSelectCompanyName;
        }

        /// <summary>
        /// retrive sales product  information
        /// </summary>
        /// <param name="intLoc"></param>
        /// <returns></returns>
        public DataSet GetSalesProductInfo(int intLoc)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam.Value = intLoc;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectSalesProductInfo, sqlParams);




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
            dispose();
            return loginDs;
        }

        /// <summary>
        /// retrive Shelf Name  information
        /// </summary>
        /// <param name="aisleId"></param>
        /// <returns></returns>
        public DataSet GetUserShelfName(int aisleId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisletop_id", SqlDbType.Int);
            sqlParam.Value = aisleId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserShelfName, sqlParams);




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
            dispose();
            return loginDs;
        }
        /// <summary>
        /// Update User Forgot Password information
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int UpdateUserForgotPassword(string username, string password)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@username", SqlDbType.VarChar);
            sqlParam.Value = username;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@password", SqlDbType.VarChar);
            sqlParam1.Value = password;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            int intUpdate = 0;

            initializeDBConnection();

            try
            {
                intUpdate = execDMLByKeyParams(DBQuery.updateUserPasswordInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                intUpdate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intUpdate = 0;

            }
            dispose();
            return intUpdate;
        }


        /// <summary>
        /// retrive user detail information
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataSet GetUserDetailsInfo(int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailsInfo, sqlParams);

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
            dispose();
            return loginDs;
        }

        public DataSet GetUserDetailsInfoForDeliveryFee(int User_Id)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@User_Id", SqlDbType.Int);
            sqlParam.Value = User_Id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailsInfoDeliveryFees, sqlParams);

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
            dispose();
            return loginDs;
        }
        public DataSet GetUserDetailsInfoCheckZip(int User_Id)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@User_Id", SqlDbType.Int);
            sqlParam.Value = User_Id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectAddressInfo, sqlParams);

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
            dispose();
            return loginDs;
        }

        public DataSet GetDeliveryDateWithZip(int locationID, int zipcode)
        {
            bool isSpecial = false;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter { ParameterName = "LocationiD", SqlDbType = SqlDbType.Int, Value = locationID, Size = 4 });
            sqlParams.Add(new SqlParameter { ParameterName = "intZip", SqlDbType = SqlDbType.Int, Value = zipcode, Size = 10 });

            initializeDBConnection();

            DataSet ds = new DataSet();

            try
            {
                string query = "";

                DateTime today = DateTime.Now;
                var dayOfWeek = today.DayOfWeek;
                var time = today.Hour;

                query = DBQuery.selectUserDeliveryDateInformation1;

                //Condition to have the cut off time for zipcodes 29915, 29926 and 29928 as 48 hrs for Saturday's delivery date.   
                if (zipcode == 29915 || zipcode == 29926 || zipcode == 29928)
                {
                    isSpecial = true;
                }

                if (isSpecial)
                {
                    if (dayOfWeek == DayOfWeek.Friday || (dayOfWeek == DayOfWeek.Thursday) && time >= 17)
                    {
                        query = DBQuery.selectUserDeliveryDateInformation2;
                    }
                }

                ds = execDatasetSelectByKeyParams(query, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                string str = sqlEx.Message + sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                string str = ex.Message + ex.StackTrace;
            }

            dispose();
            return ds;
        }

        public DataSet GetUserDetailsInfoGetZip(int User_Id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@User_Id", SqlDbType.Int);
            sqlParam.Value = User_Id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailsInfoGetZip, sqlParams);

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
            dispose();
            return loginDs;
        }
        /// <summary>
        /// To get Zone Info
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        public DataSet GetUserZoneInfo(int zipcodeid)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@zipcode_id", SqlDbType.Int);
            sqlParam.Value = zipcodeid;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectZoneInfo, sqlParams);


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
            dispose();
            return loginDs;
        }


        /// <summary>
        /// update User Phone Details Info
        /// </summary>
        /// <param name="phoneNm1"></param>
        /// <param name="phoneNm2"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int UpdateUserPhoneDetailsInfo(string phoneNm1, string phoneNm2, int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@phoneNm1", SqlDbType.VarChar);
            sqlParam.Value = phoneNm1;
            sqlParam.Size = 12;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@phoneNm2", SqlDbType.VarChar);
            sqlParam1.Value = phoneNm2;
            sqlParam1.Size = 12;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam2.Value = userId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            int intUpdate = 0;

            initializeDBConnection();

            try
            {
                intUpdate = execDMLByKeyParams(DBQuery.updateUserPhoneDetailsInfo, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                intUpdate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intUpdate = 0;

            }
            dispose();
            return intUpdate;
        }



        /// <summary>
        /// update delivery address information
        /// </summary>
        /// <param name="strAddress1"></param>
        /// <param name="strAddress2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipcode"></param>
        /// <param name="userId"></param>
        /// <returns></returns>

        public int UpdateUserDeliveryAddressDetails(string strAddress1, string strAddress2, string city, string state, string zipcode, int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strAddress1", SqlDbType.VarChar);
            sqlParam.Value = strAddress1;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@strAddress2", SqlDbType.VarChar);
            sqlParam1.Value = strAddress2;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@city", SqlDbType.VarChar);
            sqlParam2.Value = city;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@state", SqlDbType.VarChar);
            sqlParam3.Value = state;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@zipcode", SqlDbType.VarChar);
            sqlParam4.Value = zipcode;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam5.Value = userId;
            sqlParam5.Size = 4;
            sqlParams.Add(sqlParam5);

            int intUpdate = 0;

            initializeDBConnection();

            try
            {
                intUpdate = execDMLByKeyParams(DBQuery.updateUserDeliveryAddressDetails, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                intUpdate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intUpdate = 0;

            }
            dispose();
            return intUpdate;
        }



        public int UpdateUserBillingAddressDetails(string strAddress1, string strAddress2, string city, string state, string zipcode, int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strAddress1", SqlDbType.VarChar);
            sqlParam.Value = strAddress1;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@strAddress2", SqlDbType.VarChar);
            sqlParam1.Value = strAddress2;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@city", SqlDbType.VarChar);
            sqlParam2.Value = city;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@state", SqlDbType.VarChar);
            sqlParam3.Value = state;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@zipcode", SqlDbType.VarChar);
            sqlParam4.Value = zipcode;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam5.Value = userId;
            sqlParam5.Size = 4;
            sqlParams.Add(sqlParam5);

            int intUpdate = 0;

            initializeDBConnection();

            try
            {
                intUpdate = execDMLByKeyParams(DBQuery.updateUserBillingAddressDetails, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                intUpdate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intUpdate = 0;

            }
            dispose();
            return intUpdate;
        }
        /// <summary>
        /// check user email already exit
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public DataSet GetUserEmailalreadyExit(int userId, string email)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParam1.Value = email;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserEmailalreadyExit, sqlParams);

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
            dispose();
            return loginDs;
        }


        /// <summary>
        /// updtae user login information
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int UpdateUserLoginDetailsInfo(string email, string pwd, int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParam.Value = email;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@pwd", SqlDbType.VarChar);
            sqlParam1.Value = pwd;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam2.Value = userId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            int intUpdate = 0;

            initializeDBConnection();

            try
            {
                intUpdate = execDMLByKeyParams(DBQuery.updateUserLoginDetailsInfo, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                intUpdate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intUpdate = 0;

            }
            dispose();
            return intUpdate;
        }
        /// <summary>
        /// Insert Non Delivery Zone Information
        /// </summary>
        /// <param name="zipCode"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="date1"></param>
        /// <returns></returns>
        public int InsertNonDeliveryZoneInfo(string zipCode, string email, string name, DateTime date1)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@zipCode", SqlDbType.VarChar);
            sqlParam.Value = zipCode;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParam1.Value = email;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@name", SqlDbType.VarChar);
            sqlParam2.Value = name;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@date1", SqlDbType.DateTime);
            sqlParam3.Value = date1;
            sqlParam3.Size = 8;
            sqlParams.Add(sqlParam3);


            int insertDate = 0;


            initializeDBConnection();

            try
            {
                insertDate = execDMLByKeyParams(DBQuery.insertNonDeliveryZoneInfo, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                insertDate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertDate = 0;

            }
            dispose();
            return insertDate;
        }

        /// <summary>
        ///  Insert new user Information
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="phone"></param>
        /// <param name="cell"></param>
        /// <param name="email"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="pwd"></param>
        /// <param name="locId"></param>
        /// <param name="strHear"></param>
        /// <param name="estimate"></param>
        /// <param name="date1"></param>
        /// <param name="accValue"></param>
        /// <param name="newsletter"></param>
        /// <param name="statusId"></param>
        /// <param name="under100"></param>
        /// <param name="over100"></param>
        /// <returns></returns>
        public int InsertNewUserInformation(string fName, string lName, string phone, string cell, string email, string address1, string address2, string city, string state, string zip, string pwd, int locId, string strHear, DateTime date1, double accValue, int newsletter, int statusId, int under100, int over100, int isMember)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@fName", SqlDbType.VarChar);
            sqlParam.Value = fName;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@lName", SqlDbType.VarChar);
            sqlParam1.Value = lName;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@phone", SqlDbType.VarChar);
            sqlParam2.Value = phone;
            sqlParam2.Size = 12;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@cell", SqlDbType.VarChar);
            sqlParam3.Value = cell;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParam4.Value = email;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@address1", SqlDbType.VarChar);
            sqlParam5.Value = address1;
            sqlParam5.Size = 50;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@address2", SqlDbType.VarChar);
            sqlParam6.Value = address2;
            sqlParam6.Size = 50;
            sqlParams.Add(sqlParam6);

            SqlParameter sqlParam7 = new SqlParameter("@city", SqlDbType.VarChar);
            sqlParam7.Value = city;
            sqlParam7.Size = 50;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@state", SqlDbType.VarChar);
            sqlParam8.Value = state;
            sqlParam8.Size = 50;
            sqlParams.Add(sqlParam8);

            SqlParameter sqlParam9 = new SqlParameter("@zip", SqlDbType.VarChar);
            sqlParam9.Value = zip;
            sqlParam9.Size = 50;
            sqlParams.Add(sqlParam9);

            SqlParameter sqlParam10 = new SqlParameter("@pwd", SqlDbType.VarChar);
            sqlParam10.Value = pwd;
            sqlParam10.Size = 50;
            sqlParams.Add(sqlParam10);


            SqlParameter sqlParam11 = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam11.Value = locId;
            sqlParam11.Size = 4;
            sqlParams.Add(sqlParam11);


            SqlParameter sqlParam12 = new SqlParameter("@strHear", SqlDbType.VarChar);
            sqlParam12.Value = strHear;
            sqlParam12.Size = 225;
            sqlParams.Add(sqlParam12);

            //SqlParameter sqlParam13 = new SqlParameter("@estimate", SqlDbType.VarChar);
            //sqlParam13.Value = estimate;
            //sqlParam13.Size = 225;
            //sqlParams.Add(sqlParam13);


            SqlParameter sqlParam14 = new SqlParameter("@date1", SqlDbType.DateTime);
            sqlParam14.Value = date1;
            sqlParam14.Size = 8;
            sqlParams.Add(sqlParam14);


            SqlParameter sqlParam15 = new SqlParameter("@accValue", SqlDbType.Float);
            sqlParam15.Value = accValue;
            sqlParam15.Size = 8;
            sqlParams.Add(sqlParam15);



            SqlParameter sqlParam16 = new SqlParameter("@newsletter", SqlDbType.Int);
            sqlParam16.Value = newsletter;
            sqlParam16.Size = 4;
            sqlParams.Add(sqlParam16);


            SqlParameter sqlParam17 = new SqlParameter("@statusId", SqlDbType.Int);
            sqlParam17.Value = statusId;
            sqlParam17.Size = 4;
            sqlParams.Add(sqlParam17);


            SqlParameter sqlParam18 = new SqlParameter("@under100", SqlDbType.Int);
            sqlParam18.Value = under100;
            sqlParam18.Size = 4;
            sqlParams.Add(sqlParam18);


            SqlParameter sqlParam19 = new SqlParameter("@over100", SqlDbType.Int);
            sqlParam19.Value = over100;
            sqlParam19.Size = 4;
            sqlParams.Add(sqlParam19);

            sqlParams.Add(new SqlParameter { ParameterName = "isMember", Value = isMember, SqlDbType = SqlDbType.Int });

            int intInsert = 0;

            initializeDBConnection();

            try
            {
                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertNewUserInformation, sqlParams);

                foreach (DataRow drr in ds.Tables[0].Rows)
                {
                    intInsert = Convert.ToInt32(drr[0].ToString());
                }

                // intInsert = execDMLByKeyParams(DBQuery.insertNewUserInformation, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }

        /// <summary>
        /// retrive Zip Code And Order Amt Information
        /// </summary>
        /// <returns></returns>
        public DataSet GetZipCodeAndOrdAmtInfo()
        {
            DataSet dsConstantVaraible = default(DataSet);

            initializeDBConnection();
            try
            {
                dsConstantVaraible = execDatasetSelectByKey(DBQuery.selectZipCodeAndOrdAmtInfo);
            }
            catch (SqlException sqlEx)
            {
                dsConstantVaraible = null;
            }
            catch (Exception ex)
            {
                dsConstantVaraible = null;
            }
            return dsConstantVaraible;
        }



        public DataSet GetMinOrderInfo()
        {
            DataSet dsConstantVaraible = default(DataSet);

            initializeDBConnection();
            try
            {
                dsConstantVaraible = execDatasetSelectByKey(DBQuery.selectMinimumOrderInfo);
            }
            catch (SqlException sqlEx)
            {
                dsConstantVaraible = null;
            }
            catch (Exception ex)
            {
                dsConstantVaraible = null;
            }
            return dsConstantVaraible;
        }

        /// <summary>
        ///  Insert Account Fund Parent Information
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="email"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int InsertAccFundParentInfo(string fname, string lname, string email, int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@fname", SqlDbType.VarChar);
            sqlParam.Value = fname;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@lname", SqlDbType.VarChar);
            sqlParam1.Value = lname;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParam2.Value = email;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam3.Value = userId;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);

            int intInsert = 0;


            initializeDBConnection();

            try
            {

                intInsert = execDMLByKeyParams(DBQuery.insertAccFundParentInfo, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }

        /// <summary>
        /// retrive Parent Email Information
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public DataSet GetUserParentEmailInfo(string email)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParam.Value = email;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserParentEmailInfo, sqlParams);

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
            dispose();
            return loginDs;
        }

        /// <summary>
        ///retrive Payment Option Details
        /// </summary>
        /// <returns></returns>

        public DataSet GetPaymentOptionDetails()
        {
            DataSet dsSelectCompanyName = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;

            initializeDBConnection();
            try
            {
                dsSelectCompanyName = execDatasetSelectByKey(DBQuery.selectPaymentOptionInfo);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectCompanyName = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectCompanyName = null;
            }
            dispose();
            return dsSelectCompanyName;
        }


        /// <summary>
        /// Insert Account Fund Transaction Information
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="phone"></param>
        /// <param name="amt"></param>
        /// <param name="intUserId"></param>
        /// <param name="parentId"></param>
        /// <param name="dateToday"></param>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public int InsertAccFundTransactionInformation(string fname, string lname, string address1, string address2, string city, string state, string zip, string phone, double amt, int intUserId, int parentId, DateTime dateToday, string transactionId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@fname", SqlDbType.VarChar);
            sqlParam.Value = fname;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@lname", SqlDbType.VarChar);
            sqlParam1.Value = lname;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@address1", SqlDbType.VarChar);
            sqlParam2.Value = address1;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@address2", SqlDbType.VarChar);
            sqlParam3.Value = address2;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@city", SqlDbType.VarChar);
            sqlParam4.Value = city;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@state", SqlDbType.VarChar);
            sqlParam5.Value = state;
            sqlParam5.Size = 50;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@zip", SqlDbType.VarChar);
            sqlParam6.Value = zip;
            sqlParam6.Size = 50;
            sqlParams.Add(sqlParam6);

            SqlParameter sqlParam7 = new SqlParameter("@phone", SqlDbType.VarChar);
            sqlParam7.Value = phone;
            sqlParam7.Size = 50;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@amt", SqlDbType.Float);
            sqlParam8.Value = amt;
            sqlParam8.Size = 8;
            sqlParams.Add(sqlParam8);

            SqlParameter sqlParam9 = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam9.Value = intUserId;
            sqlParam9.Size = 4;
            sqlParams.Add(sqlParam9);

            SqlParameter sqlParam10 = new SqlParameter("@parentId", SqlDbType.Int);
            sqlParam10.Value = parentId;
            sqlParam10.Size = 4;
            sqlParams.Add(sqlParam10);

            SqlParameter sqlParam11 = new SqlParameter("@dateToday", SqlDbType.DateTime);
            sqlParam11.Value = dateToday;
            sqlParam11.Size = 8;
            sqlParams.Add(sqlParam11);

            SqlParameter sqlParam12 = new SqlParameter("@transactionId", SqlDbType.VarChar);
            sqlParam12.Value = transactionId;
            sqlParam12.Size = 200;
            sqlParams.Add(sqlParam12);


            int intInsert = 0;


            initializeDBConnection();

            try
            {

                intInsert = execDMLByKeyParams(DBQuery.insertAccFundTransactionInformation, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }



        /// <summary>
        /// retrive Parent Details Information
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>

        public DataSet GetParentDetailsInfo(int parentId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@parentId", SqlDbType.Int);
            sqlParam.Value = parentId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectParentDetailsInfo, sqlParams);


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
            dispose();
            return loginDs;
        }


        /// <summary>
        /// update User Account Information 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userAccAmt"></param>
        /// <returns></returns>
        public int UpdateUserAccInfo(int userId, Double userAccAmt)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@userAccAmt", SqlDbType.Float);
            sqlParam1.Value = userAccAmt;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);


            int intInsert = 0;


            initializeDBConnection();

            try
            {

                intInsert = execDMLByKeyParams(DBQuery.updateUserAccInfo, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }


        /// <summary>
        /// retrive Transaction Information
        /// </summary>
        /// <param name="intUserId"></param>
        /// <returns></returns>
        public DataSet GetUserTransactionInfo(int intUserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam.Value = intUserId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserTransactionInfo, sqlParams);

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
            dispose();
            return infoDs;
        }


        /// <summary>
        /// retrive Order Details Information
        /// </summary>
        /// <param name="intUserId"></param>
        /// <returns></returns>
        public DataSet GetUserOrderDetailsInfo(int intUserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam.Value = intUserId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserOrderDetailsInfo, sqlParams);

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
            dispose();
            return infoDs;
        }

        /// <summary>
        /// retrive Order Details Information
        /// </summary>
        /// <param name="intUserId"></param>
        /// <returns></returns>

        public DataSet GetUserOrderInformation(int intUserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam.Value = intUserId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserOrderInformation, sqlParams);


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
            dispose();
            return infoDs;
        }


        /// <summary>
        /// retrive Order  Information
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public DataSet GetUserOrderInfo(int userId, int orderId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@orderId", SqlDbType.Int);
            sqlParam1.Value = orderId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserOrderInfo1, sqlParams);


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
            dispose();
            return infoDs;
        }


        /// <summary>
        /// retrive Pickup  Information
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public DataSet GetPickupInfo(int DeliInfoId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@DeliInfoId", SqlDbType.Int);
            sqlParam.Value = DeliInfoId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);






            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectPicktype, sqlParams);


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
            dispose();
            return infoDs;
        }











        /// <summary>
        /// retrive Order product  Information
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>






        public DataSet GetUserOrderProductDetail(int orderId, int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@orderId", SqlDbType.Int);
            sqlParam.Value = orderId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam1.Value = userId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserOrderProductDetail, sqlParams);


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
            dispose();
            return infoDs;
        }

        /// <summary>
        /// retrive delivery information
        /// </summary>
        /// <param name="locId"></param>
        /// <returns></returns>

        public DataSet GetDeliveryDateInformation(int locId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectDeliveryDateInformation, sqlParams);





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
            dispose();
            return infoDs;
        }

        /// <summary>
        /// Retrive User Delivery Date Information
        /// </summary>
        /// <param name="locId"></param>
        /// <param name="intZip"></param>
        /// <returns></returns>

        public DataSet GetUserDeliveryDateInformation(int locId, int intZip)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intZip", SqlDbType.Int);
            sqlParam1.Value = intZip;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserDeliveryDateInformation, sqlParams);





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
            dispose();
            return infoDs;
        }



        //Coupon code 

        /// <summary>
        /// retrive coupon details
        /// </summary>
        /// <param name="strCoupon"></param>
        /// <returns></returns>
        public DataSet GetCouponInformation(string strCoupon)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strCoupon", SqlDbType.VarChar);
            sqlParam.Value = strCoupon;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectCouponInformation, sqlParams);





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
            dispose();
            return infoDs;
        }

        /// <summary>
        /// Retrive user used coupon details
        /// </summary>
        /// <param name="strCoupon"></param>
        /// <param name="intUserId"></param>
        /// <returns></returns>
        public DataSet GetUserCouponInfo(string strCoupon, int intUserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strCoupon", SqlDbType.VarChar);
            sqlParam.Value = strCoupon;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam1.Value = intUserId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserCouponInfo, sqlParams);





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
            dispose();
            return infoDs;
        }

        /// <summary>
        /// retrive coupon details
        /// </summary>
        /// <param name="strCoupon"></param>
        /// <returns></returns>
        public DataSet GetCouponDetailInfo(string strCoupon)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strCoupon", SqlDbType.VarChar);
            sqlParam.Value = strCoupon;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectCouponDetailInfo, sqlParams);





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
            dispose();
            return infoDs;
        }

        /// <summary>
        /// Insert User Coupon Transaction  information 
        /// </summary>
        /// <param name="dtToday"></param>
        /// <param name="amt"></param>
        /// <param name="intUserId"></param>
        /// <param name="strComment"></param>
        /// <param name="fName"></param>
        /// <param name="couponId"></param>
        /// <returns></returns>
        public int InsertUserCouponTransaction(DateTime dtToday, double amt, int intUserId, string strComment, string fName, int couponId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@dtToday", SqlDbType.DateTime);
            sqlParam.Value = dtToday;
            sqlParam.Size = 8;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@amt", SqlDbType.Float);
            sqlParam1.Value = amt;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam2.Value = intUserId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@strComment", SqlDbType.VarChar);
            sqlParam3.Value = strComment;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@fName", SqlDbType.VarChar);
            sqlParam4.Value = fName;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@couponId", SqlDbType.Int);
            sqlParam5.Value = couponId;
            sqlParam5.Size = 50;
            sqlParams.Add(sqlParam5);




            int intInsert = 0;


            initializeDBConnection();

            try
            {

                intInsert = execDMLByKeyParams(DBQuery.insertUserCouponTransaction, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }

        /// <summary>
        /// Insert User Mapping Coupon information 
        /// </summary>
        /// <param name="intUserId"></param>
        /// <param name="couponId"></param>
        /// <returns></returns>

        public int InsertUserCouponLink(int intUserId, int couponId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam.Value = intUserId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@couponId", SqlDbType.Int);
            sqlParam1.Value = couponId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int intInsert = 0;


            initializeDBConnection();

            try
            {

                intInsert = execDMLByKeyParams(DBQuery.insertUserCouponLink, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }




        //Save list

        /// <summary>
        /// check list name already exist
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public DataSet CheckListNameAlreadyExist(string strList, int users_id)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strList", SqlDbType.VarChar);
            sqlParam.Value = strList;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@users_id", SqlDbType.Int);
            sqlParam1.Value = users_id;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.checkListNameAlreadyExist, sqlParams);





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
            dispose();
            return infoDs;
        }

        /// <summary>
        /// insert saved list information
        /// </summary>
        /// <param name="strListNm"></param>
        /// <param name="userId"></param>
        /// <param name="intLocId"></param>
        /// <param name="listType"></param>
        /// <returns></returns>

        public int InsertSavedListInfo(string strListNm, int userId, int intLocId, int listType)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strListNm", SqlDbType.VarChar);
            sqlParam.Value = strListNm;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam1.Value = userId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@intLocId", SqlDbType.Int);
            sqlParam2.Value = intLocId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@listType", SqlDbType.Int);
            sqlParam3.Value = listType;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);


            int intInsert = 0;


            initializeDBConnection();

            try
            {
                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertSavedListInfo, sqlParams);

                foreach (DataRow drr in ds.Tables[0].Rows)
                {
                    intInsert = Convert.ToInt32(drr[0].ToString());
                }

                // intInsert = execDMLByKeyParams(DBQuery.insertSavedListInfo, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }


        /// <summary>
        /// insert saved list mapping info
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="intProdId"></param>
        /// <param name="prodQty"></param>
        /// <returns></returns>
        public int InsertSavedListMappingInfo(int listId, int intProdId, int prodQty)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@listId", SqlDbType.Int);
            sqlParam.Value = listId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@intProdId", SqlDbType.Int);
            sqlParam1.Value = intProdId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@prodQty", SqlDbType.Int);
            sqlParam2.Value = prodQty;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);





            int intInsert = 0;


            initializeDBConnection();

            try
            {


                intInsert = execDMLByKeyParams(DBQuery.insertSavedListMappingInfo, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }





        /// <summary>
        /// Retrive user saved list information
        /// </summary>
        /// <param name="intUserId"></param>
        /// <returns></returns>
        public DataSet GetUserSavedListInformation(int intUserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam.Value = intUserId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserSavedListInformation, sqlParams);





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
            dispose();
            return infoDs;
        }


        /// <summary>
        /// Delete user saved list information
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="intUserId"></param>
        /// <returns></returns>
        public int DeleteUserSavedList(int listId, int intUserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();


            SqlParameter sqlParam = new SqlParameter("@listId", SqlDbType.Int);
            sqlParam.Value = listId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam1.Value = intUserId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            int intInsert = 0;


            initializeDBConnection();

            try
            {


                intInsert = execDMLByKeyParams(DBQuery.deleteUserSavedList, sqlParams);



            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }

        /// <summary>
        /// Delete user saved list mapping information
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public int DeleteUserSavedListMappingInfo(int listId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();


            SqlParameter sqlParam = new SqlParameter("@listId", SqlDbType.Int);
            sqlParam.Value = listId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);



            int intInsert = 0;


            initializeDBConnection();

            try
            {
                intInsert = execDMLByKeyParams(DBQuery.deleteUserSavedListMappingInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }


        public DataSet GetUserSavedListDetails(int intListId, int intUserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intListId", SqlDbType.Int);
            sqlParam.Value = intListId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam1.Value = intUserId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserSavedListDetails, sqlParams);





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
            dispose();
            return infoDs;
        }


        public DataSet SavedListProductInfo(int intProdId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intProdId", SqlDbType.Int);
            sqlParam.Value = intProdId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectListProductDetails, sqlParams);


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
            dispose();
            return loginDs;
        }


        //PayMent Page
        public DataSet selectAllOrderInfo()
        {
            DataSet dsConstantVaraible = default(DataSet);

            initializeDBConnection();
            try
            {
                dsConstantVaraible = execDatasetSelectByKey(DBQuery.selectAllOrderInfo);
            }
            catch (SqlException sqlEx)
            {
                dsConstantVaraible = null;
            }
            catch (Exception ex)
            {
                dsConstantVaraible = null;
            }
            return dsConstantVaraible;
        }



        public DataSet selectAllTransacInfo()
        {
            DataSet dsConstantVaraible = default(DataSet);

            initializeDBConnection();
            try
            {
                dsConstantVaraible = execDatasetSelectByKey(DBQuery.selectAllTransInfo);
            }
            catch (SqlException sqlEx)
            {
                dsConstantVaraible = null;
            }
            catch (Exception ex)
            {
                dsConstantVaraible = null;
            }
            return dsConstantVaraible;
        }








        public int InsertOrderInformation(int userId, string add1, string add2, string city, string state, string zip, string special, DateTime dtToday, DateTime DelDate, string DelTime, double totalFinal, double groceryTot, double tip, double soda, double delFee, double complimentry, int ordNum, string payType, double tax, double orders_Groceriestotal, double orders_Liquortotal, double orders_GroceriesTax, double orders_LiquorTax, int picktype)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@add1", SqlDbType.VarChar);
            sqlParam1.Value = add1;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@add2", SqlDbType.VarChar);
            sqlParam2.Value = add2;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@city", SqlDbType.VarChar);
            sqlParam3.Value = city;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@state", SqlDbType.VarChar);
            sqlParam4.Value = state;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@zip", SqlDbType.VarChar);
            sqlParam5.Value = zip;
            sqlParam5.Size = 50;
            sqlParams.Add(sqlParam5);


            SqlParameter sqlParam6 = new SqlParameter("@special", SqlDbType.VarChar);
            sqlParam6.Value = special;
            sqlParam6.Size = 1000;
            sqlParams.Add(sqlParam6);


            SqlParameter sqlParam7 = new SqlParameter("@dtToday", SqlDbType.DateTime);
            sqlParam7.Value = dtToday;
            sqlParam7.Size = 8;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@DelDate", SqlDbType.DateTime);
            sqlParam8.Value = DelDate;
            sqlParam8.Size = 8;
            sqlParams.Add(sqlParam8);

            SqlParameter sqlParam9 = new SqlParameter("@DelTime", SqlDbType.VarChar);
            sqlParam9.Value = DelTime;
            sqlParam9.Size = 50;
            sqlParams.Add(sqlParam9);


            SqlParameter sqlParam10 = new SqlParameter("@totalFinal", SqlDbType.Float);
            sqlParam10.Value = totalFinal;
            sqlParam10.Size = 4;
            sqlParams.Add(sqlParam10);


            SqlParameter sqlParam11 = new SqlParameter("@groceryTot", SqlDbType.Float);
            sqlParam11.Value = groceryTot;
            sqlParam11.Size = 4;
            sqlParams.Add(sqlParam11);


            SqlParameter sqlParam12 = new SqlParameter("@tip", SqlDbType.Float);
            sqlParam12.Value = tip;
            sqlParam12.Size = 4;
            sqlParams.Add(sqlParam12);

            SqlParameter sqlParam13 = new SqlParameter("@soda", SqlDbType.Float);
            sqlParam13.Value = soda;
            sqlParam13.Size = 4;
            sqlParams.Add(sqlParam13);


            SqlParameter sqlParam14 = new SqlParameter("@delFee", SqlDbType.Float);
            sqlParam14.Value = delFee;
            sqlParam14.Size = 4;
            sqlParams.Add(sqlParam14);


            SqlParameter sqlParam15 = new SqlParameter("@complimentry", SqlDbType.Float);
            sqlParam15.Value = complimentry;
            sqlParam15.Size = 4;
            sqlParams.Add(sqlParam15);


            SqlParameter sqlParam16 = new SqlParameter("@ordNum", SqlDbType.Int);
            sqlParam16.Value = ordNum;
            sqlParam16.Size = 4;
            sqlParams.Add(sqlParam16);


            SqlParameter sqlParam17 = new SqlParameter("@payType", SqlDbType.VarChar);
            sqlParam17.Value = payType;
            sqlParam17.Size = 50;
            sqlParams.Add(sqlParam17);

            SqlParameter sqlParam18 = new SqlParameter("@tax", SqlDbType.Float);
            sqlParam18.Value = tax;
            sqlParam18.Size = 8;
            sqlParams.Add(sqlParam18);

            SqlParameter sqlParam19 = new SqlParameter("@orders_Groceriestotal", SqlDbType.Float);
            sqlParam19.Value = orders_Groceriestotal;
            sqlParam19.Size = 8;
            sqlParams.Add(sqlParam19);

            SqlParameter sqlParam20 = new SqlParameter("@orders_Liquortotal", SqlDbType.Float);
            sqlParam20.Value = orders_Liquortotal;
            sqlParam20.Size = 8;
            sqlParams.Add(sqlParam20);

            SqlParameter sqlParam21 = new SqlParameter("@orders_GroceriesTax", SqlDbType.Float);
            sqlParam21.Value = orders_GroceriesTax;
            sqlParam21.Size = 8;
            sqlParams.Add(sqlParam21);

            SqlParameter sqlParam22 = new SqlParameter("@orders_LiquorTax", SqlDbType.Float);
            sqlParam22.Value = orders_LiquorTax;
            sqlParam22.Size = 8;
            sqlParams.Add(sqlParam22);

            SqlParameter sqlParam23 = new SqlParameter("@picktype", SqlDbType.Int);
            sqlParam23.Value = picktype;
            sqlParam23.Size = 4;
            sqlParams.Add(sqlParam23);


            int insertord = 0;


            initializeDBConnection();

            try
            {
                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertOrderInformation, sqlParams);

                foreach (DataRow drr in ds.Tables[0].Rows)
                {
                    insertord = Convert.ToInt32(drr[0].ToString());
                }


            }
            catch (SqlException sqlEx)
            {
                insertord = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertord = 0;

            }
            dispose();
            return insertord;
        }




        public int InsertOrderProductInfo(int orderId, int intProdId, int qty, double price)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();


            SqlParameter sqlParam = new SqlParameter("@orderId", SqlDbType.Int);
            sqlParam.Value = orderId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@intProdId", SqlDbType.Int);
            sqlParam1.Value = intProdId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@qty", SqlDbType.Int);
            sqlParam2.Value = qty;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@price", SqlDbType.Float);
            sqlParam3.Value = price;
            sqlParam3.Size = 8;
            sqlParams.Add(sqlParam3);



            int intInsert = 0;


            initializeDBConnection();

            try
            {
                intInsert = execDMLByKeyParams(DBQuery.insertOrderProductInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }




        public int UpdateUserLoyalityInfo(int userId, int intOver100, int intUnder100)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();


            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@intOver100", SqlDbType.Int);
            sqlParam1.Value = intOver100;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@intUnder100", SqlDbType.Int);
            sqlParam2.Value = intUnder100;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);



            int intInsert = 0;


            initializeDBConnection();

            try
            {
                if (intOver100 != 0 && intUnder100 == 0)
                {
                    intInsert = execDMLByKeyParams(DBQuery.updateUserLoyalityInfo, sqlParams);
                }
                else if (intOver100 == 0 && intUnder100 != 0)
                {
                    intInsert = execDMLByKeyParams(DBQuery.updateUserLoyalityInfo1, sqlParams);
                }


            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }





        public DataSet SelectDeliveryInfo(DateTime strDelDate, int intTime)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strDelDate", SqlDbType.DateTime);
            sqlParam.Value = strDelDate;
            sqlParam.Size = 8;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intTime", SqlDbType.Int);
            sqlParam1.Value = intTime;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectDeliveryInfo, sqlParams);


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
            dispose();
            return loginDs;
        }



        public int UpdateDeliveryInfo(int intCapVal, int intId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();


            SqlParameter sqlParam = new SqlParameter("@intCapVal", SqlDbType.Int);
            sqlParam.Value = intCapVal;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@intId", SqlDbType.Int);
            sqlParam1.Value = intId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            int intInsert = 0;


            initializeDBConnection();

            try
            {

                intInsert = execDMLByKeyParams(DBQuery.updateDeliveryInfo, sqlParams);



            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }


        public DataSet GetDelveryTime(int intTime)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();


            SqlParameter sqlParam = new SqlParameter("@intTime", SqlDbType.Int);
            sqlParam.Value = intTime;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectDelveryTime, sqlParams);


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
            dispose();
            return loginDs;
        }

        public int InsertTransactionInfo(DateTime dtToday, double amt, int orderId, string comment, int intUserId, string tranId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@dtToday", SqlDbType.DateTime);
            sqlParam.Value = dtToday;
            sqlParam.Size = 8;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@amt", SqlDbType.Float);
            sqlParam1.Value = amt;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@orderId", SqlDbType.Int);
            sqlParam2.Value = orderId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@comment", SqlDbType.Text);
            sqlParam3.Value = comment;
            sqlParam3.Size = 5000;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam4.Value = intUserId;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@tranId", SqlDbType.VarChar);
            sqlParam5.Value = tranId;
            sqlParam5.Size = 200;
            sqlParams.Add(sqlParam5);


            int insertTransc = 0;


            initializeDBConnection();

            try
            {

                insertTransc = execDMLByKeyParams(DBQuery.InsertTransactionInfo, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                insertTransc = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertTransc = 0;

            }
            dispose();
            return insertTransc;
        }


        public DataSet GetUserShopDelveryTimeInformation()
        {
            DataSet dsInfo = default(DataSet);

            initializeDBConnection();
            try
            {
                dsInfo = execDatasetSelectByKey(DBQuery.selectdUserShopDelveryTimeInformation);
            }
            catch (SqlException sqlEx)
            {
                dsInfo = null;
            }
            catch (Exception ex)
            {
                dsInfo = null;
            }
            return dsInfo;
        }



        public DataSet GetUserPickTimeDelDateInfo(int locId, int intZip)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intZip", SqlDbType.Int);
            sqlParam1.Value = intZip;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserPickTimeDelDateInfo, sqlParams);
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
            dispose();
            return infoDs;
        }

        public DataSet GetUserPickTimeDelDateInfo1(int locId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            //SqlParameter sqlParam1 = new SqlParameter("@intZip", SqlDbType.Int);
            //sqlParam1.Value = intZip;
            //sqlParam1.Size = 4;
            //sqlParams.Add(sqlParam1);



            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserPickTimeDelDateInfo1, sqlParams);
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
            dispose();
            return infoDs;
        }

        public DataSet GetUserNewDelveryTimeInformationPickUp()
        {
            DataSet dsInfo = default(DataSet);

            initializeDBConnection();

            try
            {
                dsInfo = execDatasetSelectByKey(DBQuery.selectdUserNewDelveryTimeInformationPickUp);
            }
            catch (SqlException sqlEx)
            {
                dsInfo = null;
            }
            catch (Exception ex)
            {
                dsInfo = null;
            }
            return dsInfo;

        }

        public DataSet GetUserNewDelveryTimeInformation()
        {
            DataSet dsInfo = default(DataSet);

            initializeDBConnection();
            try
            {
                dsInfo = execDatasetSelectByKey(DBQuery.selectdUserNewDelveryTimeInformation);
            }
            catch (SqlException sqlEx)
            {
                dsInfo = null;
            }
            catch (Exception ex)
            {
                dsInfo = null;
            }
            return dsInfo;
        }



        public int UpdateUserBillingInfo(string add1, string add2, string city, string state, string zip, int userId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@add1", SqlDbType.VarChar);
            sqlParam.Value = add1;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@add2", SqlDbType.VarChar);
            sqlParam1.Value = add2;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@city", SqlDbType.VarChar);
            sqlParam2.Value = city;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@state", SqlDbType.VarChar);
            sqlParam3.Value = state;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@zip", SqlDbType.VarChar);
            sqlParam4.Value = zip;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam5.Value = userId;
            sqlParam5.Size = 4;
            sqlParams.Add(sqlParam5);




            int intInsert = 0;


            initializeDBConnection();

            try
            {

                intInsert = execDMLByKeyParams(DBQuery.updateUserBillingInfo, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }

        public int InsertRegisterTransInfo(DateTime dtToday, double amt, string FName, string comment, int intUserId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@dtToday", SqlDbType.DateTime);
            sqlParam.Value = dtToday;
            sqlParam.Size = 8;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@amt", SqlDbType.Float);
            sqlParam1.Value = amt;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@FName", SqlDbType.VarChar);
            sqlParam2.Value = FName;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@comment", SqlDbType.Text);
            sqlParam3.Value = comment;
            sqlParam3.Size = 5000;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@intUserId", SqlDbType.Int);
            sqlParam4.Value = intUserId;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            int insertTransc = 0;


            initializeDBConnection();

            try
            {

                insertTransc = execDMLByKeyParams(DBQuery.insertRegisterTransInfo, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                insertTransc = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertTransc = 0;

            }
            dispose();
            return insertTransc;
        }

        //Functtion for get user FirstName address for welcome 
        public DataSet GetUserUserFistNameForWelcome(int users_id)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@users_id", SqlDbType.Int);
            sqlParam.Value = users_id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet getZipCode = new DataSet();

            initializeDBConnection();

            try
            {
                getZipCode = execDatasetSelectByKeyParams(DBQuery.selectUserEmailAddress, sqlParams);
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
            dispose();
            return getZipCode;
        }



        //New Added



        public DataSet GetUserReportClientZipDetailInfo(string ZipCode)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@ZipCode", SqlDbType.VarChar);
            sqlParam.Value = ZipCode;
            sqlParam.Size = 200;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserReportClientZipInfo, sqlParams);


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
            dispose();
            return infoDs;
        }



        public DataSet GetStateInfo(string stateId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@stateId", SqlDbType.VarChar);
            sqlParam.Value = stateId;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectStateInfo, sqlParams);


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
            dispose();
            return infoDs;
        }





        public DataSet GetClientActivityInfo(string ZipCode, string startDate, string endDate)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@ZipCode", SqlDbType.VarChar);
            sqlParam.Value = ZipCode;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@startDate", SqlDbType.VarChar);
            sqlParam1.Value = startDate;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@endDate", SqlDbType.VarChar);
            sqlParam2.Value = endDate;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);






            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectGetClientActivityInfo, sqlParams);


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
            dispose();
            return infoDs;
        }




        public DataSet GetInActivityClientInfo(int strOrdType)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strOrdType", SqlDbType.Int);
            sqlParam.Value = strOrdType;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {
                infoDs = execDatasetSelectByKeyParams(DBQuery.selectGetInActivityClientInfo, sqlParams);

                //if (strOrdType == 7)
                //{
                //    infoDs = execDatasetSelectByKeyParams(DBQuery.selectGetInActivityClientInfo, sqlParams);
                //}
                //if (strOrdType == 14)
                //{
                //    infoDs = execDatasetSelectByKeyParams(DBQuery.selectGetInActivityClientInfo1, sqlParams);
                //}
                //if (strOrdType == 21)
                //{
                //    infoDs = execDatasetSelectByKeyParams(DBQuery.selectGetInActivityClientInfo2, sqlParams);
                //}


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
            dispose();
            return infoDs;
        }

        /// <summary>
        /// To retrieve Tax Rate information
        /// </summary>
        /// <returns></returns>

        public DataSet SelectAdminTaxRates()
        {
            DataSet dsSelectAdminTaxRates = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;




            initializeDBConnection();
            try
            {
                dsSelectAdminTaxRates = execDatasetSelectByKey(DBQuery.selectTaxRate);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectAdminTaxRates = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectAdminTaxRates = null;
            }
            dispose();
            return dsSelectAdminTaxRates;
        }

        /// <summary>
        /// To delted Taxrates
        /// </summary>
        /// <param name="zipcode_id"></param>
        /// <returns></returns>
        public int deleteTaxRate(int taxId)
        {

            int returnCount = 0;


            List<SqlParameter> sqlParams = new List<SqlParameter>();
            SqlParameter sqlParam = new SqlParameter("@taxId", SqlDbType.Int);
            sqlParam.Value = taxId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            initializeDBConnection();
            try
            {

                returnCount = execDMLByKeyParams(DBQuery.deletTaxRate, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                string str = sqlEx.Message;
            }
            finally
            {
                dispose();
            }
            return returnCount;


        }

        /// <summary>
        /// To Check Tax rate already exists
        /// </summary>
        /// <param name="zipcode_zipcode"></param>
        /// <returns></returns>
        public int checkAddTaxRate(string Tax_Cat_Name)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@Tax_Cat_Name", SqlDbType.VarChar);
            sqlParam.Value = Tax_Cat_Name;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);



            int TaxId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.checkTaxRateAddAvalable, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        TaxId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    TaxId = 0;
                }

            }
            catch (SqlException sqlEx)
            {
                TaxId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                TaxId = 0;

            }
            dispose();
            return TaxId;
        }

        /// <summary>
        /// To add Tax rate
        /// </summary>
        /// <param name="Tax_Cat_Name"></param>
        /// <param name="tax_amount"></param>

        /// <returns></returns>
        public int addNewTaxRate(string Tax_Cat_Name, double tax_amount)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@Tax_Cat_Name", SqlDbType.VarChar);
            sqlParam.Value = Tax_Cat_Name;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@tax_amount", SqlDbType.Float);
            sqlParam1.Value = tax_amount;
            sqlParams.Add(sqlParam1);



            int insertTaxRate = 0;


            initializeDBConnection();

            try
            {
                insertTaxRate = execDMLByKeyParams(DBQuery.insertTaxRate, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertTaxRate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertTaxRate = 0;

            }
            dispose();
            return insertTaxRate;
        }



        /// <summary>
        /// To get tax rate details
        /// </summary>
        /// <param name="zipcode_id"></param>
        /// <returns></returns>

        public DataSet GetTaxRateDetails(int taxId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@taxId", SqlDbType.Int);
            sqlParam.Value = taxId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet getTaxRate = new DataSet();

            initializeDBConnection();

            try
            {
                getTaxRate = execDatasetSelectByKeyParams(DBQuery.selectTaxRateForUpdate, sqlParams);
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
            dispose();
            return getTaxRate;
        }






        public int checkEditTaxRate(string Tax_Cat_Name, int taxId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@Tax_Cat_Name", SqlDbType.VarChar);
            sqlParam.Value = Tax_Cat_Name;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@taxId", SqlDbType.Int);
            sqlParam1.Value = taxId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            int inttaxId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.checkEditTaxRateAvalable, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        inttaxId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    inttaxId = 0;
                }

            }
            catch (SqlException sqlEx)
            {
                inttaxId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                inttaxId = 0;

            }
            dispose();
            return inttaxId;
        }





        public int updateTaxRate(int taxId, string Tax_Cat_Name, double tax_amount)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;

            SqlParameter sqlParam = new SqlParameter("@taxId", SqlDbType.Int);
            sqlParam.Value = taxId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@Tax_Cat_Name", SqlDbType.VarChar);
            sqlParam1.Value = Tax_Cat_Name;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@tax_amount", SqlDbType.Float);
            sqlParam2.Value = tax_amount;
            sqlParams.Add(sqlParam2);




            initializeDBConnection();
            try
            {

                returnValueInsert = execDMLByQueryParams(DBQuery.updateTaxRate, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }



        // Minimum Order Amount

        /// <summary>
        /// To Select Minimum Order
        /// </summary>
        /// <returns></returns>

        public DataSet SelectAdminMinOrd()
        {
            DataSet dsSelectMinOrd = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;




            initializeDBConnection();
            try
            {
                dsSelectMinOrd = execDatasetSelectByKey(DBQuery.selectMinOrder);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectMinOrd = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectMinOrd = null;
            }
            dispose();
            return dsSelectMinOrd;
        }


        /// <summary>
        /// To delete Minimum Order
        /// </summary>
        /// <param name="zipcode_id"></param>
        /// <returns></returns>
        public int deleteMinOrder(int MinOrdId)
        {

            int returnCount = 0;


            List<SqlParameter> sqlParams = new List<SqlParameter>();
            SqlParameter sqlParam = new SqlParameter("@MinOrdId", SqlDbType.Int);
            sqlParam.Value = MinOrdId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            initializeDBConnection();
            try
            {

                returnCount = execDMLByKeyParams(DBQuery.deleteMinOrder, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                string str = sqlEx.Message;
            }
            finally
            {
                dispose();
            }
            return returnCount;


        }


        /// <summary>
        /// To check add min order amount
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <returns></returns>
        public int checkAddMinOrdAmt(string CategoryName)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@CategoryName", SqlDbType.VarChar);
            sqlParam.Value = CategoryName;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);



            int MinOrdId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.checkMinOrderAddAvalable, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        MinOrdId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    MinOrdId = 0;
                }

            }
            catch (SqlException sqlEx)
            {
                MinOrdId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                MinOrdId = 0;

            }
            dispose();
            return MinOrdId;
        }


        /// <summary>
        /// To add New Minimum Order Amount
        /// </summary>
        /// <param name="Tax_Cat_Name"></param>
        /// <param name="tax_amount"></param>
        /// <returns></returns>
        public int addNewMinOrder(string CategoryName, string Min_Amount)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@CategoryName", SqlDbType.VarChar);
            sqlParam.Value = CategoryName;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@Min_Amount", SqlDbType.Int);
            sqlParam1.Value = Min_Amount;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            int insertMinOrder = 0;


            initializeDBConnection();

            try
            {
                insertMinOrder = execDMLByKeyParams(DBQuery.insertMinOrder, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertMinOrder = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertMinOrder = 0;

            }
            dispose();
            return insertMinOrder;
        }

        /// <summary>
        /// To select Minimum Order 
        /// </summary>
        /// <param name="taxId"></param>
        /// <returns></returns>
        public DataSet GetMinimumOrderDetails(int MinOrdId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@MinOrdId", SqlDbType.Int);
            sqlParam.Value = MinOrdId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet getMinOrder = new DataSet();

            initializeDBConnection();

            try
            {
                getMinOrder = execDatasetSelectByKeyParams(DBQuery.selectMinOrderForUpdate, sqlParams);
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
            dispose();
            return getMinOrder;
        }


        /// <summary>
        /// To check Minimum Order
        /// </summary>
        /// <param name="Tax_Cat_Name"></param>
        /// <param name="taxId"></param>
        /// <returns></returns>
        public int checkEditMinOrder(string CategoryName, int MinOrdId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@CategoryName", SqlDbType.VarChar);
            sqlParam.Value = CategoryName;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@MinOrdId", SqlDbType.Int);
            sqlParam1.Value = MinOrdId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            int intminId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.checkEditMinOrderAvalable, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        intminId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    intminId = 0;
                }

            }
            catch (SqlException sqlEx)
            {
                intminId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intminId = 0;

            }
            dispose();
            return intminId;
        }


        /// <summary>
        /// to update minimum order 
        /// </summary>
        /// <param name="MinOrdId"></param>
        /// <param name="CategoryName"></param>
        /// <param name="MinAmount"></param>
        /// <returns></returns>

        public int updateMinOrder(int MinOrdId, string CategoryName, int MinAmount)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;

            SqlParameter sqlParam = new SqlParameter("@MinOrdId", SqlDbType.Int);
            sqlParam.Value = MinOrdId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@CategoryName", SqlDbType.VarChar);
            sqlParam1.Value = CategoryName;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@Min_Amount", SqlDbType.Int);
            sqlParam2.Value = MinAmount;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);




            initializeDBConnection();
            try
            {

                returnValueInsert = execDMLByQueryParams(DBQuery.updateMinOrder, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }


        // Todays Date Time

        public DataSet GetTodaysDeliveryDetails()
        {
            DataSet dsEmployeeDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsEmployeeDeatils = execDatasetSelectByKey(DBQuery.selectTodaysDeliveryDetails);
            }
            catch (SqlException sqlEx)
            {
                dsEmployeeDeatils = null;
            }
            catch (Exception ex)
            {
                dsEmployeeDeatils = null;
            }
            return dsEmployeeDeatils;
        }


        public int DeleteTime(int TimeId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@TimeId", SqlDbType.Int);
            sqlParam.Value = TimeId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            int deleteTime = 0;



            initializeDBConnection();

            try
            {
                deleteTime = execDMLByKeyParams(DBQuery.deleteTodaysTime, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                deleteTime = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteTime = 0;

            }
            dispose();
            return deleteTime;
        }





        public int InsertTimeInfo(int StartTime, string AM_PM, int EndTime, string PM_AM, int ShowHide)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@StartTime", SqlDbType.Int);
            sqlParam.Value = StartTime;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@AM_PM", SqlDbType.VarChar);
            sqlParam1.Value = AM_PM;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@EndTime", SqlDbType.Int);
            sqlParam2.Value = EndTime;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@PM_AM", SqlDbType.VarChar);
            sqlParam3.Value = PM_AM;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@ShowHide", SqlDbType.Int);
            sqlParam4.Value = ShowHide;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            int insertTodayDate = 0;


            initializeDBConnection();

            try
            {
                insertTodayDate = execDMLByKeyParams(DBQuery.insertTimeInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertTodayDate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertTodayDate = 0;

            }
            dispose();
            return insertTodayDate;
        }

        /// <summary>
        /// To check time already exists
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>

        public int TimeAlreadyExist(int StartTime, string AM_PM, int EndTime, string PM_AM, int ShowHide)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@StartTime", SqlDbType.Int);
            sqlParam.Value = StartTime;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@AM_PM", SqlDbType.VarChar);
            sqlParam1.Value = AM_PM;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@EndTime", SqlDbType.Int);
            sqlParam2.Value = EndTime;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@PM_AM", SqlDbType.VarChar);
            sqlParam3.Value = PM_AM;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@ShowHide", SqlDbType.Int);
            sqlParam4.Value = ShowHide;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            int intTimeId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectTimealreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        intTimeId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    intTimeId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                intTimeId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intTimeId = 0;

            }
            dispose();
            return intTimeId;
        }


        /// <summary>
        /// To select Time Details
        /// </summary>
        /// <param name="aisleId"></param>
        /// <returns></returns>
        public DataSet SelectTimeDeatils(int TimeId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@TimeId", SqlDbType.Int);
            sqlParam.Value = TimeId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet dsTime = new DataSet();

            initializeDBConnection();

            try
            {
                dsTime = execDatasetSelectByKeyParams(DBQuery.selectTimeInfo, sqlParams);



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
            dispose();
            return dsTime;
        }


        /// <summary>
        /// To check Time already exist
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="AM_PM"></param>
        /// <param name="EndTime"></param>
        /// <param name="PM_AM"></param>
        /// <param name="ShowHide"></param>
        /// <returns></returns>
        public int TimeUpdateAlreadyExist(int StartTime, string AM_PM, int EndTime, string PM_AM, int ShowHide, int TimeId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@StartTime", SqlDbType.Int);
            sqlParam.Value = StartTime;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@AM_PM", SqlDbType.VarChar);
            sqlParam1.Value = AM_PM;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@EndTime", SqlDbType.Int);
            sqlParam2.Value = EndTime;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@PM_AM", SqlDbType.VarChar);
            sqlParam3.Value = PM_AM;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@ShowHide", SqlDbType.Int);
            sqlParam4.Value = ShowHide;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@TimeId", SqlDbType.Int);
            sqlParam5.Value = TimeId;
            sqlParam5.Size = 4;
            sqlParams.Add(sqlParam5);


            int intTimeId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectTimeUpdateAlreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        intTimeId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    intTimeId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                intTimeId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intTimeId = 0;

            }
            dispose();
            return intTimeId;
        }


        /// <summary>
        /// To update Time info
        /// </summary>
        /// <param name="aisleName"></param>
        /// <param name="locationId"></param>
        /// <param name="status"></param>
        /// <param name="imageName"></param>
        /// <param name="aisleId"></param>
        /// <returns></returns>
        public int UpdateTimeInfo(int StartTime, string AM_PM, int EndTime, string PM_AM, int ShowHide, int TimeId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@StartTime", SqlDbType.Int);
            sqlParam.Value = StartTime;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@AM_PM", SqlDbType.VarChar);
            sqlParam1.Value = AM_PM;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@EndTime", SqlDbType.Int);
            sqlParam2.Value = EndTime;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@PM_AM", SqlDbType.VarChar);
            sqlParam3.Value = PM_AM;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@ShowHide", SqlDbType.Int);
            sqlParam4.Value = ShowHide;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@TimeId", SqlDbType.Int);
            sqlParam5.Value = TimeId;
            sqlParam5.Size = 4;
            sqlParams.Add(sqlParam5);


            int updateTime = 0;


            initializeDBConnection();

            try
            {
                updateTime = execDMLByKeyParams(DBQuery.updateTodaysTimeInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateTime = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateTime = 0;

            }
            dispose();
            return updateTime;
        }



        // User Todays Delivery Time

        public DataSet GetTodaysDelTimeInfo(int TimeId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@TimeId", SqlDbType.Int);
            sqlParam.Value = TimeId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {

                productDs = execDatasetSelectByKeyParams(DBQuery.selectUSerdelTimeInfo, sqlParams);




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
            dispose();
            return productDs;
        }


        public DataSet getServerTime()
        {
            DataSet dsSelectCompanyName = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;

            initializeDBConnection();
            try
            {
                dsSelectCompanyName = execDatasetSelectByKey(DBQuery.selectServerTime);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectCompanyName = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectCompanyName = null;
            }
            dispose();
            return dsSelectCompanyName;
        }

        public DataSet getServerTimeInMinutes()
        {
            DataSet dsSelectCompanyName = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;

            initializeDBConnection();
            try
            {
                dsSelectCompanyName = execDatasetSelectByKey(DBQuery.selectServerTimeInHours);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectCompanyName = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectCompanyName = null;
            }
            dispose();
            return dsSelectCompanyName;
        }

        public DataSet GetDelveryTimeHours(int StartTime)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@StartTime", SqlDbType.Int);
            sqlParam.Value = StartTime;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);




            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {

                productDs = execDatasetSelectByKeyParams(DBQuery.selectDelveryTimeInfoHours, sqlParams);




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
            dispose();
            return productDs;
        }

        public DataSet GetDeliveryTimeHoursInfo(int StartTime)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@StartTime", SqlDbType.Int);
            sqlParam.Value = StartTime;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {
                productDs = execDatasetSelectByKeyParams(DBQuery.selectDeliveryTimeInfoHours, sqlParams);




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
            dispose();
            return productDs;
        }

        public DataSet GetTodayDeliveryTime(int TimeId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@TimeId", SqlDbType.Int);
            sqlParam.Value = TimeId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            DataSet dsTodayTime = new DataSet();

            initializeDBConnection();

            try
            {
                dsTodayTime = execDatasetSelectByKeyParams(DBQuery.selectTodaysDeliveryTime, sqlParams);
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
            dispose();
            return dsTodayTime;
        }

        /// <summary>
        /// To select liquor amount
        /// </summary>
        /// <returns></returns>
        public DataSet getLiquorAmount()
        {
            DataSet dsSelectLiquorAmount = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;

            initializeDBConnection();
            try
            {
                dsSelectLiquorAmount = execDatasetSelectByKey(DBQuery.selectLiquorAmount);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectLiquorAmount = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectLiquorAmount = null;
            }
            dispose();
            return dsSelectLiquorAmount;
        }


        public int InsertdeliverydateInfo(string StartTime, string AM_PM, int EndTime, string PM_AM, int ShowHide)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@deliverydate_date", SqlDbType.Int);
            sqlParam.Value = StartTime;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@location_id", SqlDbType.Int);
            sqlParam1.Value = AM_PM;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);




            int insertTodayDate = 0;


            initializeDBConnection();

            try
            {
                insertTodayDate = execDMLByKeyParams(DBQuery.insertTimeInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertTodayDate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertTodayDate = 0;

            }
            dispose();
            return insertTodayDate;
        }


        /// <summary>
        /// To get delivery info
        /// </summary>
        /// <returns></returns>
        public DataSet GetDeliveryInfoDeatils()
        {
            DataSet dsDeliInfoDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsDeliInfoDeatils = execDatasetSelectByKey(DBQuery.selectDeliInfoDeatils);
            }
            catch (SqlException sqlEx)
            {
                dsDeliInfoDeatils = null;
            }
            catch (Exception ex)
            {
                dsDeliInfoDeatils = null;
            }
            return dsDeliInfoDeatils;
        }

        public DataSet GetDeliveryTypeDeatils()
        {
            DataSet dsDeliInfoDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsDeliInfoDeatils = execDatasetSelectByKey(DBQuery.selectDeliTypeDeatils);
            }
            catch (SqlException sqlEx)
            {
                dsDeliInfoDeatils = null;
            }
            catch (Exception ex)
            {
                dsDeliInfoDeatils = null;
            }
            return dsDeliInfoDeatils;
        }


        public DataSet SelectDeliInfoDeatils(int DeliInfoId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@DeliInfoId", SqlDbType.Int);
            sqlParam.Value = DeliInfoId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet dsDeliInfoDetails = new DataSet();

            initializeDBConnection();

            try
            {
                dsDeliInfoDetails = execDatasetSelectByKeyParams(DBQuery.selectDeliInfoDeatilsInfo, sqlParams);



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
            dispose();
            return dsDeliInfoDetails;
        }

        /// <summary>
        /// To check Delivery Info 
        /// </summary>
        /// <param name="DeliveryName"></param>
        /// <param name="DeliInfoId"></param>
        /// <returns></returns>
        public int UpdateDeliInfoAlreadyExist(string DeliveryName, int DeliInfoId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@DeliveryName", SqlDbType.VarChar);
            sqlParam.Value = DeliveryName;
            sqlParam.Size = 75;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@DeliInfoId", SqlDbType.Int);
            sqlParam1.Value = DeliInfoId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int intDeliInfoId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectDeliNameUpdateAlreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow drr in ds.Tables[0].Rows)
                    {
                        intDeliInfoId = Convert.ToInt32(drr[0].ToString());
                    }


                }
                else
                {
                    intDeliInfoId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                intDeliInfoId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intDeliInfoId = 0;

            }
            dispose();
            return intDeliInfoId;
        }


        public int UpdateDeliveryInfo(string DeliveryName, int status, int DeliInfoId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@DeliveryName", SqlDbType.VarChar);
            sqlParam.Value = DeliveryName;
            sqlParam.Size = 75;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam2 = new SqlParameter("@Status", SqlDbType.Int);
            sqlParam2.Value = status;
            sqlParam2.Size = 1;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam4 = new SqlParameter("@DeliInfoId", SqlDbType.Int);
            sqlParam4.Value = DeliInfoId;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            int updateDeliInfo = 0;


            initializeDBConnection();

            try
            {
                updateDeliInfo = execDMLByKeyParams(DBQuery.updateDeliveryInfoDetails, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateDeliInfo = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateDeliInfo = 0;

            }
            dispose();
            return updateDeliInfo;
        }

        public DataSet getCurrentServerTimeInMinutes()
        {
            DataSet dsSelectCompanyName = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;

            initializeDBConnection();
            try
            {
                dsSelectCompanyName = execDatasetSelectByKey(DBQuery.selectCurrentServerTimeInHours);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectCompanyName = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectCompanyName = null;
            }
            dispose();
            return dsSelectCompanyName;
        }
        public DataSet getNextServerTimeInMinutes()
        {
            DataSet dsSelectCompanyName = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;

            initializeDBConnection();
            try
            {
                dsSelectCompanyName = execDatasetSelectByKey(DBQuery.selectNextServerTimeInHours);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelectCompanyName = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelectCompanyName = null;
            }
            dispose();
            return dsSelectCompanyName;
        }

        public string CheckSpacing(string strProductNm)
        {
            string strReturn = string.Empty;
            if (strProductNm.Contains("-  "))
            {

                strReturn = strProductNm.Replace("-  ", "- ");
            }
            else
            {
                strReturn = strProductNm;
            }
            return strReturn;
        }


        public DataSet DeleteAddressInfo(int User_Id)
        {
            DataSet dsDeatils = default(DataSet);
            List<SqlParameter> sqlParams = new List<SqlParameter>();


            SqlParameter sqlParam = new SqlParameter("@User_Id", SqlDbType.Int);
            sqlParam.Value = User_Id;
            sqlParam.Size = 5;
            sqlParams.Add(sqlParam);


            initializeDBConnection();
            try
            {
                dsDeatils = execDatasetSelectByKeyParams(DBQuery.deleteAddressInfo, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                dsDeatils = null;
            }
            catch (Exception ex)
            {
                dsDeatils = null;
            }
            return dsDeatils;
        }


        public DataSet GetAddressInfo(int User_Id)
        {
            DataSet dsSelect = null;
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;



            SqlParameter sqlParam = new SqlParameter("@User_Id", SqlDbType.Int);
            sqlParam.Value = User_Id;
            sqlParam.Size = 5;
            sqlParams.Add(sqlParam);


            initializeDBConnection();
            try
            {
                dsSelect = execDatasetSelectByKeyParams(DBQuery.selectAddressInfo, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                string err = sqlEx.Message;
                dsSelect = null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dsSelect = null;
            }
            dispose();
            return dsSelect;
        }
        public DataSet GetUserDeliveryDateInformationNew(int locId, string intZip)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intZip", SqlDbType.VarChar);
            sqlParam1.Value = intZip;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserDeliveryDateInformation, sqlParams);





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
            dispose();
            return infoDs;
        }
        public DataSet GetProductDetails(int prodId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();


            SqlParameter sqlParam = new SqlParameter("@prodId", SqlDbType.Int);
            sqlParam.Value = prodId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectProductDetails, sqlParams);




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
            dispose();
            return loginDs;
        }
        public int AddressInfo(string address, string address2, string city, string state, string zip, string instruction, int User_Id, string CompanyName, string Phone)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();


            SqlParameter sqlParam = new SqlParameter("@address", SqlDbType.VarChar);
            sqlParam.Value = address;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@address2", SqlDbType.VarChar);
            sqlParam1.Value = address2;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@city", SqlDbType.VarChar);
            sqlParam2.Value = city;
            sqlParam2.Size = 30;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@state", SqlDbType.VarChar);
            sqlParam3.Value = state;
            sqlParam3.Size = 20;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@zip", SqlDbType.VarChar);
            sqlParam4.Value = zip;
            sqlParam4.Size = 5;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam9 = new SqlParameter("@instruction", SqlDbType.VarChar);
            sqlParam9.Value = instruction;
            sqlParam9.Size = 1000;
            sqlParams.Add(sqlParam9);

            SqlParameter sqlParam7 = new SqlParameter("@User_Id", SqlDbType.Int);
            sqlParam7.Value = User_Id;
            sqlParam7.Size = 5;
            sqlParams.Add(sqlParam7);



            SqlParameter sqlParam5 = new SqlParameter("@CompanyName", SqlDbType.VarChar);
            sqlParam5.Value = CompanyName;
            sqlParam5.Size = 5000;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam8 = new SqlParameter("@Phone", SqlDbType.VarChar);
            sqlParam8.Value = Phone;
            sqlParam8.Size = 15;
            sqlParams.Add(sqlParam8);
            int intInsert = 0;


            initializeDBConnection();

            try
            {
                intInsert = execDMLByKeyParams(DBQuery.insertAddressInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }
        //Funnction for Add New zip code
        public int addNewZipCode(string zipcode_zipcode, int location_id, string zipcode_name)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;


            SqlParameter sqlParam = new SqlParameter("@zipcode_zipcode", SqlDbType.VarChar);
            sqlParam.Value = zipcode_zipcode;
            sqlParam.Size = 5;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@location_id", SqlDbType.Int);
            sqlParam1.Value = location_id;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@zipcode_name", SqlDbType.VarChar);
            sqlParam2.Value = zipcode_name;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            //SqlParameter sqlParam3 = new SqlParameter("@ZipOrderSize", SqlDbType.Float);
            //sqlParam3.Value = ZipOrderSize;
            //sqlParam3.Size = 8;
            //sqlParams.Add(sqlParam3);


            initializeDBConnection();
            try
            {

                returnValueInsert = execDMLByQueryParams(DBQuery.insertZipCode, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }
        public DataSet GetUserShelfDeatils(int aisletop_id, int aisle_id)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisletop_id", SqlDbType.Int);
            sqlParam.Value = aisletop_id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@aisle_id", SqlDbType.Int);
            sqlParam1.Value = aisle_id;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            DataSet loginDs = new DataSet();

            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserShelfDeatils, sqlParams);




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
            dispose();
            return loginDs;
        }
        public int DeliveryDateAlreadyExist(string strDate)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strDate", SqlDbType.Date);
            sqlParam.Value = strDate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);



            int DateId = 0;
            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectDeliveryDateAlreadyExist, sqlParams);
                if (ds.Tables[0].Rows.Count != 0)
                {

                    DateId = 1;



                }
                else
                {
                    DateId = 0;
                }


            }
            catch (SqlException sqlEx)
            {
                DateId = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                DateId = 0;

            }
            dispose();
            return DateId;
        }

        public int InsertAisleInfo(string aisleName, int locationId, string status)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisleName", SqlDbType.VarChar);
            sqlParam.Value = aisleName;
            sqlParam.Size = 75;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam1.Value = locationId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@status", SqlDbType.VarChar);
            sqlParam2.Value = status;
            sqlParam2.Size = 1;
            sqlParams.Add(sqlParam2);



            int insertAisle = 0;


            initializeDBConnection();

            try
            {
                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertAisleInfo, sqlParams);

                foreach (DataRow drr in ds.Tables[0].Rows)
                {
                    insertAisle = Convert.ToInt32(drr[0].ToString());
                }


            }
            catch (SqlException sqlEx)
            {
                insertAisle = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertAisle = 0;

            }
            dispose();
            return insertAisle;
        }
        public int InsertNewUserInformation(string fName, string lName, string phone, string cell, string email, string address1, string address2, string city, string state, string zip, string pwd, int locId, string strHear, string estimate, DateTime date1, double accValue, int newsletter, int statusId, int under100, int over100, int isMember)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@fName", SqlDbType.VarChar);
            sqlParam.Value = fName;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@lName", SqlDbType.VarChar);
            sqlParam1.Value = lName;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@phone", SqlDbType.VarChar);
            sqlParam2.Value = phone;
            sqlParam2.Size = 16;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@cell", SqlDbType.VarChar);
            sqlParam3.Value = cell;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParam4.Value = email;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@address1", SqlDbType.VarChar);
            sqlParam5.Value = address1;
            sqlParam5.Size = 50;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@address2", SqlDbType.VarChar);
            sqlParam6.Value = address2;
            sqlParam6.Size = 50;
            sqlParams.Add(sqlParam6);

            SqlParameter sqlParam7 = new SqlParameter("@city", SqlDbType.VarChar);
            sqlParam7.Value = city;
            sqlParam7.Size = 50;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@state", SqlDbType.VarChar);
            sqlParam8.Value = state;
            sqlParam8.Size = 50;
            sqlParams.Add(sqlParam8);

            SqlParameter sqlParam9 = new SqlParameter("@zip", SqlDbType.VarChar);
            sqlParam9.Value = zip;
            sqlParam9.Size = 50;
            sqlParams.Add(sqlParam9);

            SqlParameter sqlParam10 = new SqlParameter("@pwd", SqlDbType.VarChar);
            sqlParam10.Value = pwd;
            sqlParam10.Size = 50;
            sqlParams.Add(sqlParam10);

            SqlParameter sqlParam11 = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam11.Value = locId;
            sqlParam11.Size = 4;
            sqlParams.Add(sqlParam11);

            SqlParameter sqlParam12 = new SqlParameter("@strHear", SqlDbType.VarChar);
            sqlParam12.Value = strHear;
            sqlParam12.Size = 225;
            sqlParams.Add(sqlParam12);

            SqlParameter sqlParam13 = new SqlParameter("@estimate", SqlDbType.VarChar);
            sqlParam13.Value = estimate;
            sqlParam13.Size = 225;
            sqlParams.Add(sqlParam13);

            SqlParameter sqlParam14 = new SqlParameter("@date1", SqlDbType.DateTime);
            sqlParam14.Value = date1;
            sqlParam14.Size = 8;
            sqlParams.Add(sqlParam14);

            SqlParameter sqlParam15 = new SqlParameter("@accValue", SqlDbType.Float);
            sqlParam15.Value = accValue;
            sqlParam15.Size = 8;
            sqlParams.Add(sqlParam15);

            SqlParameter sqlParam16 = new SqlParameter("@newsletter", SqlDbType.Int);
            sqlParam16.Value = newsletter;
            sqlParam16.Size = 4;
            sqlParams.Add(sqlParam16);

            SqlParameter sqlParam17 = new SqlParameter("@statusId", SqlDbType.Int);
            sqlParam17.Value = statusId;
            sqlParam17.Size = 4;
            sqlParams.Add(sqlParam17);

            SqlParameter sqlParam18 = new SqlParameter("@under100", SqlDbType.Int);
            sqlParam18.Value = under100;
            sqlParam18.Size = 4;
            sqlParams.Add(sqlParam18);

            SqlParameter sqlParam19 = new SqlParameter("@over100", SqlDbType.Int);
            sqlParam19.Value = over100;
            sqlParam19.Size = 4;
            sqlParams.Add(sqlParam19);

            sqlParams.Add(new SqlParameter { ParameterName = "isMember", Value = isMember, SqlDbType = SqlDbType.Int });

            int intInsert = 0;


            initializeDBConnection();

            try
            {
                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertNewUserInformation, sqlParams);

                foreach (DataRow drr in ds.Tables[0].Rows)
                {
                    intInsert = Convert.ToInt32(drr[0].ToString());
                }

                // intInsert = execDMLByKeyParams(DBQuery.insertNewUserInformation, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                intInsert = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intInsert = 0;

            }
            dispose();
            return intInsert;
        }

        /// <summary>
        /// insert product details information
        /// </summary>
        /// <param name="locId"></param>
        /// <param name="productId"></param>
        /// <param name="shelfId"></param>
        /// <param name="asileId"></param>
        /// <param name="asileLink"></param>
        /// <param name="price"></param>
        /// <param name="buyPrice"></param>
        /// <param name="perSale"></param>
        /// <param name="soda"></param>
        /// <param name="suggest"></param>
        /// <param name="tax"></param>
        /// <param name="recomm"></param>
        /// <param name="hide"></param>
        /// <returns></returns>
        public int InsertProductMappingInfo(int locId, int productId, int shelfId, int asileId, int asileLink, double price, double buyPrice, double perSale, double soda, string suggest, string tax, string recomm, string hide)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@productId", SqlDbType.Int);
            sqlParam1.Value = productId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@shelfId", SqlDbType.Int);
            sqlParam2.Value = shelfId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@asileId", SqlDbType.Int);
            sqlParam3.Value = asileId;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@asileLink", SqlDbType.Int);
            sqlParam4.Value = asileLink;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@price", SqlDbType.Float);
            sqlParam5.Value = price;
            sqlParam5.Size = 8;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@buyPrice", SqlDbType.Float);
            sqlParam6.Value = buyPrice;
            sqlParam6.Size = 8;
            sqlParams.Add(sqlParam6);

            SqlParameter sqlParam7 = new SqlParameter("@perSale", SqlDbType.Float);
            sqlParam7.Value = perSale;
            sqlParam7.Size = 8;
            sqlParams.Add(sqlParam7);


            SqlParameter sqlParam8 = new SqlParameter("@soda", SqlDbType.Float);
            sqlParam8.Value = soda;
            sqlParam8.Size = 8;
            sqlParams.Add(sqlParam8);


            SqlParameter sqlParam9 = new SqlParameter("@suggest", SqlDbType.VarChar);
            sqlParam9.Value = suggest;
            sqlParam9.Size = 1;
            sqlParams.Add(sqlParam9);


            SqlParameter sqlParam10 = new SqlParameter("@tax", SqlDbType.VarChar);
            sqlParam10.Value = tax;
            sqlParam10.Size = 1;
            sqlParams.Add(sqlParam10);

            SqlParameter sqlParam11 = new SqlParameter("@recomm", SqlDbType.VarChar);
            sqlParam11.Value = recomm;
            sqlParam11.Size = 1;
            sqlParams.Add(sqlParam11);


            SqlParameter sqlParam12 = new SqlParameter("@hide", SqlDbType.VarChar);
            sqlParam12.Value = hide;
            sqlParam12.Size = 1;
            sqlParams.Add(sqlParam12);

            ;


            int insertShelfMapping = 0;


            initializeDBConnection();

            try
            {
                insertShelfMapping = execDMLByKeyParams(DBQuery.insertProductMappingInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertShelfMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertShelfMapping = 0;

            }
            dispose();
            return insertShelfMapping;
        }


        /// <summary>
        /// insert product mapping info
        /// </summary>
        /// <param name="locId"></param>
        /// <param name="productId"></param>
        /// <param name="shelfId"></param>
        /// <param name="asileId"></param>
        /// <param name="asileLink"></param>
        /// <param name="price"></param>
        /// <param name="buyPrice"></param>
        /// <param name="soda"></param>
        /// <param name="suggest"></param>
        /// <param name="tax"></param>
        /// <param name="recomm"></param>
        /// <param name="hide"></param>
        /// <returns></returns>

        public int InsertProductMappingInfo1(int locId, int productId, int shelfId, int asileId, int asileLink, double price, double buyPrice, double soda, string suggest, string tax, string recomm, string hide)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@productId", SqlDbType.Int);
            sqlParam1.Value = productId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@shelfId", SqlDbType.Int);
            sqlParam2.Value = shelfId;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@asileId", SqlDbType.Int);
            sqlParam3.Value = asileId;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@asileLink", SqlDbType.Int);
            sqlParam4.Value = asileLink;
            sqlParam4.Size = 4;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@price", SqlDbType.Float);
            sqlParam5.Value = price;
            sqlParam5.Size = 8;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@buyPrice", SqlDbType.Float);
            sqlParam6.Value = buyPrice;
            sqlParam6.Size = 8;
            sqlParams.Add(sqlParam6);




            SqlParameter sqlParam7 = new SqlParameter("@soda", SqlDbType.Float);
            sqlParam7.Value = soda;
            sqlParam7.Size = 8;
            sqlParams.Add(sqlParam7);


            SqlParameter sqlParam8 = new SqlParameter("@suggest", SqlDbType.VarChar);
            sqlParam8.Value = suggest;
            sqlParam8.Size = 1;
            sqlParams.Add(sqlParam8);


            SqlParameter sqlParam9 = new SqlParameter("@tax", SqlDbType.VarChar);
            sqlParam9.Value = tax;
            sqlParam9.Size = 1;
            sqlParams.Add(sqlParam9);

            SqlParameter sqlParam10 = new SqlParameter("@recomm", SqlDbType.VarChar);
            sqlParam10.Value = recomm;
            sqlParam10.Size = 1;
            sqlParams.Add(sqlParam10);


            SqlParameter sqlParam11 = new SqlParameter("@hide", SqlDbType.VarChar);
            sqlParam11.Value = hide;
            sqlParam11.Size = 1;
            sqlParams.Add(sqlParam11);



            int insertShelfMapping = 0;


            initializeDBConnection();

            try
            {
                insertShelfMapping = execDMLByKeyParams(DBQuery.insertProductMappingInfo1, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertShelfMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertShelfMapping = 0;

            }
            dispose();
            return insertShelfMapping;
        }
        public int UpdateAisleInfo(string aisleName, int locationId, string status, int aisleId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@aisleName", SqlDbType.VarChar);
            sqlParam.Value = aisleName;
            sqlParam.Size = 75;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam1.Value = locationId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@status", SqlDbType.VarChar);
            sqlParam2.Value = status;
            sqlParam2.Size = 1;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@aisleId", SqlDbType.Int);
            sqlParam3.Value = aisleId;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);


            int updateAisle = 0;


            initializeDBConnection();

            try
            {
                updateAisle = execDMLByKeyParams(DBQuery.updateAisleInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                updateAisle = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                updateAisle = 0;

            }
            dispose();
            return updateAisle;
        }

        public int InsertOrderCountInfo(int UserId, int OrderCount, int OrderMonth)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();


            SqlParameter sqlParam1 = new SqlParameter("@UserId", SqlDbType.Int);
            sqlParam1.Value = UserId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@OrderCount", SqlDbType.Int);
            sqlParam2.Value = OrderCount;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@OrderMonth", SqlDbType.Int);
            sqlParam3.Value = OrderMonth;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);

            int insertTransc = 0;


            initializeDBConnection();

            try
            {

                insertTransc = execDMLByKeyParams(DBQuery.insertOrderCountTransInfo, sqlParams);




            }
            catch (SqlException sqlEx)
            {
                insertTransc = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertTransc = 0;

            }
            dispose();
            return insertTransc;
        }
        public DataSet GetUserDetailsInfoForLoyolity(int users_id)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@users_id", SqlDbType.Int);
            sqlParam.Value = users_id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);
            DataSet loginDs = new DataSet();
            initializeDBConnection();
            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.selectUserDetailsInfoForLoyoloty, sqlParams);
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
            dispose();
            return loginDs;
        }

        //Functtion for get Shopping Cart constant
        public DataSet GetDeliveryFee(int User_Id)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@User_Id", SqlDbType.Int);
            sqlParam.Value = User_Id;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            DataSet getZipCode = new DataSet();

            initializeDBConnection();

            try
            {
                getZipCode = execDatasetSelectByKeyParams(DBQuery.selectgetDeliveryFee, sqlParams);
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
            dispose();
            return getZipCode;
        }


        public DataSet GetUserPickTimeDelDateDetails(int locId, int intZip)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intZip", SqlDbType.Int);
            sqlParam1.Value = intZip;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);




            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.selectUserPickTimeDelDateDetails, sqlParams);





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
            dispose();
            return infoDs;
        }

        public DataSet GetUserPickTimeDelDateDetails1(int locId, int intZip)
        {
            bool isSpecial = false;
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locId", SqlDbType.Int);
            sqlParam.Value = locId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@intZip", SqlDbType.Int);
            sqlParam1.Value = intZip;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {
                string query = DBQuery.selectUserPickTimeDelDateDetails1;

                DateTime today = DateTime.Now;
                var dayOfWeek = today.DayOfWeek;
                var time = today.Hour;

                //Condition to have the cut off time for zipcodes 29915, 29926 and 29928 as 48 hrs for Saturday's delivery date.   
                if (intZip == 29915 || intZip == 29926 || intZip == 29928)
                {
                    isSpecial = true;
                }

                if (isSpecial)
                {
                    if (dayOfWeek == DayOfWeek.Friday || (dayOfWeek == (DayOfWeek.Thursday) && time >= 17))
                    {
                        query = DBQuery.selectUserPickTimeDelDateDetails2;
                    }
                }

                infoDs = execDatasetSelectByKeyParams(query, sqlParams);
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

            dispose();
            return infoDs;
        }


        public int updateShoppingCartConstant1(int ConstantId, double DeliveryFee, double TaxRate, double TaxRate1, double MinimumDeposit, int Numberoftimeslot, double DeliveryFeeCutOff, string CustomerServiceEmail, string ContactEmail, string InfoEmail, string LocationName, string StateShortName, string StateLongName, string CompanyShortName, string CompanyLongName, string ShortURL, string LongURL, double FirstOrderGift, double memberDeliveryFee, double pickUpDeliveryFee)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            int returnValueInsert = 0;

            SqlParameter sqlParam = new SqlParameter("@ConstantId", SqlDbType.Int);
            sqlParam.Value = ConstantId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@DeliveryFee", SqlDbType.Float);
            sqlParam1.Value = DeliveryFee;
            sqlParam1.Size = 8;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam3 = new SqlParameter("@TaxRate", SqlDbType.Float);
            sqlParam3.Value = TaxRate;
            sqlParam3.Size = 8;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam4 = new SqlParameter("@TaxRate1", SqlDbType.Float);
            sqlParam4.Value = TaxRate1;
            sqlParam4.Size = 8;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@MinimumDeposit", SqlDbType.Float);
            sqlParam5.Value = MinimumDeposit;
            sqlParam5.Size = 8;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@Numberoftimeslot", SqlDbType.Int);
            sqlParam6.Value = Numberoftimeslot;
            sqlParam6.Size = 4;
            sqlParams.Add(sqlParam6);

            SqlParameter sqlParam7 = new SqlParameter("@DeliveryFeeCutOff", SqlDbType.Float);
            sqlParam7.Value = DeliveryFeeCutOff;
            sqlParam7.Size = 8;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@CustomerServiceEmail", SqlDbType.VarChar);
            sqlParam8.Value = CustomerServiceEmail;
            sqlParam8.Size = 50;
            sqlParams.Add(sqlParam8);

            SqlParameter sqlParam9 = new SqlParameter("@ContactEmail", SqlDbType.VarChar);
            sqlParam9.Value = ContactEmail;
            sqlParam9.Size = 50;
            sqlParams.Add(sqlParam9);

            SqlParameter sqlParam10 = new SqlParameter("@InfoEmail", SqlDbType.VarChar);
            sqlParam10.Value = InfoEmail;
            sqlParam10.Size = 50;
            sqlParams.Add(sqlParam10);

            SqlParameter sqlParam11 = new SqlParameter("@LocationName", SqlDbType.VarChar);
            sqlParam11.Value = LocationName;
            sqlParam11.Size = 50;
            sqlParams.Add(sqlParam11);

            SqlParameter sqlParam12 = new SqlParameter("@StateShortName", SqlDbType.VarChar);
            sqlParam12.Value = StateShortName;
            sqlParam12.Size = 50;
            sqlParams.Add(sqlParam12);

            SqlParameter sqlParam13 = new SqlParameter("@StateLongName", SqlDbType.VarChar);
            sqlParam13.Value = StateLongName;
            sqlParam13.Size = 50;
            sqlParams.Add(sqlParam13);

            SqlParameter sqlParam14 = new SqlParameter("@CompanyShortName", SqlDbType.VarChar);
            sqlParam14.Value = CompanyShortName;
            sqlParam14.Size = 50;
            sqlParams.Add(sqlParam14);

            SqlParameter sqlParam15 = new SqlParameter("@CompanyLongName", SqlDbType.VarChar);
            sqlParam15.Value = CompanyLongName;
            sqlParam15.Size = 50;
            sqlParams.Add(sqlParam15);

            SqlParameter sqlParam16 = new SqlParameter("@ShortURL", SqlDbType.VarChar);
            sqlParam16.Value = ShortURL;
            sqlParam16.Size = 50;
            sqlParams.Add(sqlParam16);

            SqlParameter sqlParam17 = new SqlParameter("@LongURL", SqlDbType.VarChar);
            sqlParam17.Value = LongURL;
            sqlParam17.Size = 50;
            sqlParams.Add(sqlParam17);
            SqlParameter sqlParam18 = new SqlParameter("@FirstOrderGift", SqlDbType.Float);
            sqlParam18.Value = FirstOrderGift;
            sqlParam18.Size = 8;
            sqlParams.Add(sqlParam18);

            sqlParams.Add(new SqlParameter { ParameterName = "MemberDeliveryFee", Value = memberDeliveryFee, SqlDbType = SqlDbType.Money });
            sqlParams.Add(new SqlParameter { ParameterName = "PickUpDeliveryFee", SqlDbType = SqlDbType.Money, Value = pickUpDeliveryFee });

            initializeDBConnection();

            try
            {

                returnValueInsert = execDMLByQueryParams(DBQuery.updateShoppingCartConstant1, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str;
                str = "Sorry Can't complete operation, operation stopped" + ex.Message + ex.StackTrace;

            }

            finally
            {
                dispose();
            }

            return returnValueInsert;
        }

        public DataSet GetStoreDeatils()
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            DataSet getZipCode = new DataSet();

            initializeDBConnection();

            try
            {
                getZipCode = execDatasetSelectByKey(DBQuery.GetStoreLocation);
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

            dispose();
            return getZipCode;
        }

        public int StoreNameUpdateAlreadyExist(string storelocation_name)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@storelocation_name", SqlDbType.VarChar);
            sqlParam1.Value = storelocation_name;
            sqlParam1.Size = 80;
            sqlParams.Add(sqlParam1);

            int intStoreName = 0;

            initializeDBConnection();

            try
            {
                DataSet storeName = execDatasetByKeyParams(DBQuery.UpdateStoreNameExists, sqlParams);

                if (storeName.Tables[0].Rows.Count > 0)
                    intStoreName = 1;
                else
                    intStoreName = 0;

            }
            catch (SqlException sqlEx)
            {
                intStoreName = 0;
            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;

                intStoreName = 0;
            }

            dispose();
            return intStoreName;
        }

        public int UpdateStoreInfo(string storelocation_name, int storelocationid)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@storelocation_name", SqlDbType.VarChar);
            sqlParam1.Value = storelocation_name;
            sqlParam1.Size = 80;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@storelocationid", SqlDbType.Int);
            sqlParam2.Value = storelocationid;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            int intStoreName = 0;

            initializeDBConnection();

            try
            {
                intStoreName = execDMLByQueryParams(DBQuery.UpdateStoreInfo, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                intStoreName = 0;
            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intStoreName = 0;
            }

            dispose();
            return intStoreName;
        }

        public int StoreNameAlreadyExist(string storelocation_name)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@storelocation_name", SqlDbType.VarChar);
            sqlParam1.Value = storelocation_name;
            sqlParam1.Size = 80;
            sqlParams.Add(sqlParam1);

            int intStoreName = 0;

            initializeDBConnection();

            try
            {
                DataSet storeName = execDatasetByKeyParams(DBQuery.StoreNameExists, sqlParams);

                if (storeName.Tables[0].Rows.Count > 0)
                    intStoreName = 1;
                else
                    intStoreName = 0;
            }

            catch (SqlException sqlEx)
            {
                intStoreName = 0;
            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intStoreName = 0;
            }

            dispose();
            return intStoreName;
        }

        public int InsertStoreInfo(string storelocation_name)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@storelocation_name", SqlDbType.VarChar);
            sqlParam1.Value = storelocation_name;
            sqlParam1.Size = 80;
            sqlParams.Add(sqlParam1);

            int intStoreName = 0;

            initializeDBConnection();

            try
            {
                intStoreName = execDMLByQueryParams(DBQuery.InsertStoreInfo, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                intStoreName = 0;
            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                intStoreName = 0;
            }

            dispose();
            return intStoreName;
        }

        public string GetStoreLocationName(int storelocationid)
        {
            string storeLocationName = "";

            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter sqp1 = new SqlParameter("@storelocationid", SqlDbType.Int);
            sqp1.Size = 4;
            sqp1.Value = storelocationid;
            list.Add(sqp1);
            initializeDBConnection();

            try
            {
                storeLocationName = executeScalarQuery(DBQuery.SelectStoreLocationName, list);
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

            dispose();
            return storeLocationName;
        }

        public int InsertOrderInformation1(int userId, string add1, string add2, string city, string state, string zip, string special, DateTime dtToday, DateTime DelDate, string DelTime, double totalFinal, double groceryTot, double tip, double soda, double delFee, double complimentry, int ordNum, string payType, double tax, string ukname, int account, string TransID, string RefTransactionId, string CompanyName, string Phone, int pickType, int storeLocationID)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@add1", SqlDbType.VarChar);
            sqlParam1.Value = add1;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@add2", SqlDbType.VarChar);
            sqlParam2.Value = add2;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@city", SqlDbType.VarChar);
            sqlParam3.Value = city;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@state", SqlDbType.VarChar);
            sqlParam4.Value = state;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@zip", SqlDbType.VarChar);
            sqlParam5.Value = zip;
            sqlParam5.Size = 50;
            sqlParams.Add(sqlParam5);


            SqlParameter sqlParam6 = new SqlParameter("@special", SqlDbType.VarChar);
            sqlParam6.Value = special;
            sqlParam6.Size = 1000;
            sqlParams.Add(sqlParam6);


            SqlParameter sqlParam7 = new SqlParameter("@dtToday", SqlDbType.DateTime);
            sqlParam7.Value = dtToday;
            sqlParam7.Size = 8;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@DelDate", SqlDbType.DateTime);
            sqlParam8.Value = DelDate;
            sqlParam8.Size = 8;
            sqlParams.Add(sqlParam8);

            SqlParameter sqlParam9 = new SqlParameter("@DelTime", SqlDbType.VarChar);
            sqlParam9.Value = DelTime;
            sqlParam9.Size = 50;
            sqlParams.Add(sqlParam9);


            SqlParameter sqlParam10 = new SqlParameter("@totalFinal", SqlDbType.Float);
            sqlParam10.Value = totalFinal;
            sqlParam10.Size = 4;
            sqlParams.Add(sqlParam10);


            SqlParameter sqlParam11 = new SqlParameter("@groceryTot", SqlDbType.Float);
            sqlParam11.Value = groceryTot;
            sqlParam11.Size = 4;
            sqlParams.Add(sqlParam11);


            SqlParameter sqlParam12 = new SqlParameter("@tip", SqlDbType.Float);
            sqlParam12.Value = tip;
            sqlParam12.Size = 4;
            sqlParams.Add(sqlParam12);

            SqlParameter sqlParam13 = new SqlParameter("@soda", SqlDbType.Float);
            sqlParam13.Value = soda;
            sqlParam13.Size = 4;
            sqlParams.Add(sqlParam13);


            SqlParameter sqlParam14 = new SqlParameter("@delFee", SqlDbType.Float);
            sqlParam14.Value = delFee;
            sqlParam14.Size = 4;
            sqlParams.Add(sqlParam14);


            SqlParameter sqlParam15 = new SqlParameter("@complimentry", SqlDbType.Float);
            sqlParam15.Value = complimentry;
            sqlParam15.Size = 4;
            sqlParams.Add(sqlParam15);


            SqlParameter sqlParam16 = new SqlParameter("@ordNum", SqlDbType.Int);
            sqlParam16.Value = ordNum;
            sqlParam16.Size = 4;
            sqlParams.Add(sqlParam16);


            SqlParameter sqlParam17 = new SqlParameter("@payType", SqlDbType.VarChar);
            sqlParam17.Value = payType;
            sqlParam17.Size = 50;
            sqlParams.Add(sqlParam17);

            SqlParameter sqlParam18 = new SqlParameter("@tax", SqlDbType.Float);
            sqlParam18.Value = tax;
            sqlParam18.Size = 8;
            sqlParams.Add(sqlParam18);

            SqlParameter sqlParam19 = new SqlParameter("@ukname", SqlDbType.VarChar);
            sqlParam19.Value = ukname;
            sqlParam19.Size = 50;
            sqlParams.Add(sqlParam19);

            SqlParameter sqlParam20 = new SqlParameter("@account", SqlDbType.Int);
            sqlParam20.Value = account;
            sqlParam20.Size = 10;
            sqlParams.Add(sqlParam20);

            SqlParameter sqlParam21 = new SqlParameter("@TransID,", SqlDbType.VarChar);
            sqlParam21.Value = TransID;
            sqlParam21.Size = 50;
            sqlParams.Add(sqlParam21);

            SqlParameter sqlParam22 = new SqlParameter("@RefTransactionId", SqlDbType.VarChar);
            sqlParam22.Value = RefTransactionId;
            sqlParam22.Size = 50;
            sqlParams.Add(sqlParam22);

            SqlParameter sqlParam23 = new SqlParameter("@CompanyName", SqlDbType.VarChar);
            sqlParam23.Value = CompanyName;
            sqlParam23.Size = 5000;
            sqlParams.Add(sqlParam23);

            SqlParameter sqlParam24 = new SqlParameter("@Phone", SqlDbType.VarChar);
            sqlParam24.Value = Phone;
            sqlParam24.Size = 15;
            sqlParams.Add(sqlParam24);

            sqlParams.Add(new SqlParameter { ParameterName = "pickType", SqlDbType = SqlDbType.Int, Value = pickType, Size = 4 });
            sqlParams.Add(new SqlParameter { ParameterName = "storeLocationID", SqlDbType = SqlDbType.Int, Value = storeLocationID, Size = 4 });

            int insertord = 0;


            initializeDBConnection();

            try
            {
                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertOrderInformation1, sqlParams);

                foreach (DataRow drr in ds.Tables[0].Rows)
                {
                    insertord = Convert.ToInt32(drr[0].ToString());
                }


            }
            catch (SqlException sqlEx)
            {
                insertord = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertord = 0;

            }
            dispose();
            return insertord;
        }


        public int InsertOrderInformation(int userId, string add1, string add2, string city, string state, string zip, string special, DateTime dtToday, DateTime DelDate, string DelTime, double totalFinal, double groceryTot, double tip, double soda, double delFee, double complimentry, int ordNum, string payType, double tax, string TransID, string RefTransactionId, string CompanyName, string Phone, int pickType, int storeLocationID)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@userId", SqlDbType.Int);
            sqlParam.Value = userId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@add1", SqlDbType.VarChar);
            sqlParam1.Value = add1;
            sqlParam1.Size = 50;
            sqlParams.Add(sqlParam1);


            SqlParameter sqlParam2 = new SqlParameter("@add2", SqlDbType.VarChar);
            sqlParam2.Value = add2;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@city", SqlDbType.VarChar);
            sqlParam3.Value = city;
            sqlParam3.Size = 50;
            sqlParams.Add(sqlParam3);


            SqlParameter sqlParam4 = new SqlParameter("@state", SqlDbType.VarChar);
            sqlParam4.Value = state;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@zip", SqlDbType.VarChar);
            sqlParam5.Value = zip;
            sqlParam5.Size = 50;
            sqlParams.Add(sqlParam5);


            SqlParameter sqlParam6 = new SqlParameter("@special", SqlDbType.VarChar);
            sqlParam6.Value = special;
            sqlParam6.Size = 1000;
            sqlParams.Add(sqlParam6);


            SqlParameter sqlParam7 = new SqlParameter("@dtToday", SqlDbType.DateTime);
            sqlParam7.Value = dtToday;
            sqlParam7.Size = 8;
            sqlParams.Add(sqlParam7);

            SqlParameter sqlParam8 = new SqlParameter("@DelDate", SqlDbType.DateTime);
            sqlParam8.Value = DelDate;
            sqlParam8.Size = 8;
            sqlParams.Add(sqlParam8);

            SqlParameter sqlParam9 = new SqlParameter("@DelTime", SqlDbType.VarChar);
            sqlParam9.Value = DelTime;
            sqlParam9.Size = 50;
            sqlParams.Add(sqlParam9);


            SqlParameter sqlParam10 = new SqlParameter("@totalFinal", SqlDbType.Float);
            sqlParam10.Value = totalFinal;
            sqlParam10.Size = 4;
            sqlParams.Add(sqlParam10);


            SqlParameter sqlParam11 = new SqlParameter("@groceryTot", SqlDbType.Float);
            sqlParam11.Value = groceryTot;
            sqlParam11.Size = 4;
            sqlParams.Add(sqlParam11);


            SqlParameter sqlParam12 = new SqlParameter("@tip", SqlDbType.Float);
            sqlParam12.Value = tip;
            sqlParam12.Size = 4;
            sqlParams.Add(sqlParam12);

            SqlParameter sqlParam13 = new SqlParameter("@soda", SqlDbType.Float);
            sqlParam13.Value = soda;
            sqlParam13.Size = 4;
            sqlParams.Add(sqlParam13);


            SqlParameter sqlParam14 = new SqlParameter("@delFee", SqlDbType.Float);
            sqlParam14.Value = delFee;
            sqlParam14.Size = 4;
            sqlParams.Add(sqlParam14);


            SqlParameter sqlParam15 = new SqlParameter("@complimentry", SqlDbType.Float);
            sqlParam15.Value = complimentry;
            sqlParam15.Size = 4;
            sqlParams.Add(sqlParam15);


            SqlParameter sqlParam16 = new SqlParameter("@ordNum", SqlDbType.Int);
            sqlParam16.Value = ordNum;
            sqlParam16.Size = 4;
            sqlParams.Add(sqlParam16);


            SqlParameter sqlParam17 = new SqlParameter("@payType", SqlDbType.VarChar);
            sqlParam17.Value = payType;
            sqlParam17.Size = 50;
            sqlParams.Add(sqlParam17);

            SqlParameter sqlParam18 = new SqlParameter("@tax", SqlDbType.Float);
            sqlParam18.Value = tax;
            sqlParam18.Size = 8;
            sqlParams.Add(sqlParam18);

            SqlParameter sqlParam19 = new SqlParameter("@TransID", SqlDbType.VarChar);
            sqlParam19.Value = TransID;
            sqlParam19.Size = 50;
            sqlParams.Add(sqlParam19);

            SqlParameter sqlParam20 = new SqlParameter("@RefTransactionId", SqlDbType.VarChar);
            sqlParam20.Value = RefTransactionId;
            sqlParam20.Size = 50;
            sqlParams.Add(sqlParam20);

            SqlParameter sqlParam21 = new SqlParameter("@CompanyName", SqlDbType.VarChar);
            sqlParam21.Value = CompanyName;
            sqlParam21.Size = 5000;
            sqlParams.Add(sqlParam21);


            SqlParameter sqlParam22 = new SqlParameter("@Phone", SqlDbType.VarChar);
            sqlParam22.Value = Phone;
            sqlParam22.Size = 15;
            sqlParams.Add(sqlParam22);

            sqlParams.Add(new SqlParameter { ParameterName = "pickType", Value = pickType, SqlDbType = SqlDbType.Int, Size = 4 });
            sqlParams.Add(new SqlParameter { ParameterName = "storeLocationID", Value = storeLocationID, SqlDbType = SqlDbType.Int, Size = 4 });

            int insertord = 0;


            initializeDBConnection();

            try
            {
                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertOrderInformat, sqlParams);

                foreach (DataRow drr in ds.Tables[0].Rows)
                {
                    insertord = Convert.ToInt32(drr[0].ToString());
                }


            }
            catch (SqlException sqlEx)
            {
                insertord = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertord = 0;

            }
            dispose();
            return insertord;
        }


        public DataSet GetProductListDeatils1(int locationId, int shefId, string strKey)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@locationId", SqlDbType.Int);
            sqlParam.Value = locationId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            SqlParameter sqlParam1 = new SqlParameter("@shefId", SqlDbType.Int);
            sqlParam1.Value = shefId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            SqlParameter sqlParam2 = new SqlParameter("@strKey", SqlDbType.VarChar);
            sqlParam2.Value = strKey;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);



            DataSet productDs = new DataSet();

            initializeDBConnection();

            try
            {
                if (locationId != 0 && shefId == 0 && strKey == "")
                {
                    productDs = execDatasetSelectByKeyParams(DBQuery.productListDeatils4, sqlParams);
                }
                if (locationId != 0 && shefId != 0 && strKey == "")
                {
                    productDs = execDatasetSelectByKeyParams(DBQuery.productListDeatils5, sqlParams);
                }
                if (locationId != 0 && shefId != 0 && strKey != "")
                {
                    productDs = execDatasetSelectByKeyParams(DBQuery.productListDeatils6, sqlParams);
                }
                if (locationId != 0 && shefId != 0 && strKey != "")
                {
                    productDs = execDatasetSelectByKeyParams(DBQuery.productListDeatils7, sqlParams);
                }
                if (locationId != 0 && shefId != 0 && strKey == "")
                {
                    productDs = execDatasetSelectByKeyParams(DBQuery.productListDeatilsUPC3, sqlParams);
                }
                if (locationId != 0 && shefId == 0 && strKey == "")
                {
                    productDs = execDatasetSelectByKeyParams(DBQuery.productListDeatilsUPC4, sqlParams);
                }
                if (locationId != 0 && shefId == 0 && strKey != "")
                {
                    productDs = execDatasetSelectByKeyParams(DBQuery.productListDeatilsUPC6, sqlParams);
                }
                if (locationId != 0 && shefId == 0 && strKey != "")
                {
                    productDs = execDatasetSelectByKeyParams(DBQuery.productListDeatilsUPC8, sqlParams);
                }

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
            dispose();
            return productDs;
        }


        public int UpdateProductPrice_ifnull(int productid, double price, string size, string recomm, string suggest)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productid", SqlDbType.Int);
            sqlParam.Value = productid;
            sqlParam.Size = 6;
            sqlParams.Add(sqlParam);



            SqlParameter sqlParam2 = new SqlParameter("@price", SqlDbType.Float);
            sqlParam2.Value = price;
            sqlParam2.Size = 8;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam4 = new SqlParameter("@size", SqlDbType.VarChar);
            sqlParam4.Value = size;
            sqlParam4.Size = 1;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@recomm", SqlDbType.VarChar);
            sqlParam5.Value = recomm;
            sqlParam5.Size = 1;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@suggest", SqlDbType.VarChar);
            sqlParam6.Value = suggest;
            sqlParam6.Size = 1;
            sqlParams.Add(sqlParam6);


            int insertShelfMapping = 0;


            initializeDBConnection();

            try
            {
                insertShelfMapping = execDMLByKeyParams(DBQuery.updateProductPrice_ifnull, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertShelfMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertShelfMapping = 0;

            }
            dispose();
            return insertShelfMapping;
        }

        public int UpdateProductPrice(int productid, double perSale, double price, string size, string recomm, string suggest)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productid", SqlDbType.Int);
            sqlParam.Value = productid;
            sqlParam.Size = 6;
            sqlParams.Add(sqlParam);



            SqlParameter sqlParam2 = new SqlParameter("@price", SqlDbType.Float);
            sqlParam2.Value = price;
            sqlParam2.Size = 8;
            sqlParams.Add(sqlParam2);


            SqlParameter sqlParam3 = new SqlParameter("@perSale", SqlDbType.Float);
            sqlParam3.Value = perSale;
            sqlParam3.Size = 8;
            sqlParams.Add(sqlParam3);



            SqlParameter sqlParam4 = new SqlParameter("@size", SqlDbType.VarChar);
            sqlParam4.Value = size;
            sqlParam4.Size = 1;
            sqlParams.Add(sqlParam4);


            SqlParameter sqlParam5 = new SqlParameter("@recomm", SqlDbType.VarChar);
            sqlParam5.Value = recomm;
            sqlParam5.Size = 1;
            sqlParams.Add(sqlParam5);

            SqlParameter sqlParam6 = new SqlParameter("@suggest", SqlDbType.VarChar);
            sqlParam6.Value = suggest;
            sqlParam6.Size = 1;
            sqlParams.Add(sqlParam6);



            int insertShelfMapping = 0;


            initializeDBConnection();

            try
            {
                insertShelfMapping = execDMLByKeyParams(DBQuery.updateProductPrice, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertShelfMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertShelfMapping = 0;

            }
            dispose();
            return insertShelfMapping;
        }
        public int UpdateProductSize(int productid, string size, string desc, string title, string image1, string image2)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@productid", SqlDbType.Int);
            sqlParam.Value = productid;
            sqlParam.Size = 6;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam2 = new SqlParameter("@size", SqlDbType.VarChar);
            sqlParam2.Value = size;
            sqlParam2.Size = 50;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@desc", SqlDbType.VarChar);
            sqlParam3.Value = desc;
            sqlParam3.Size = 3000;
            sqlParams.Add(sqlParam3);

            SqlParameter sqlParam_title = new SqlParameter("@title", SqlDbType.VarChar);
            sqlParam_title.Value = title;
            sqlParam_title.Size = 255;
            sqlParams.Add(sqlParam_title);

            SqlParameter sqlParam4 = new SqlParameter("@image1", SqlDbType.VarChar);
            sqlParam4.Value = image1;
            sqlParam4.Size = 50;
            sqlParams.Add(sqlParam4);

            SqlParameter sqlParam5 = new SqlParameter("@image2", SqlDbType.VarChar);
            sqlParam5.Value = image2;
            sqlParam5.Size = 50;
            sqlParams.Add(sqlParam5);


            int insertShelfMapping = 0;


            initializeDBConnection();

            try
            {
                insertShelfMapping = execDMLByKeyParams(DBQuery.updateProductSize, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertShelfMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertShelfMapping = 0;

            }
            dispose();
            return insertShelfMapping;
        }


        public DataSet CheckListProductAlreadyExist(int listid, int prodid)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@listid", SqlDbType.Int);
            sqlParam.Value = listid;
            sqlParam.Size = 5;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@prodid", SqlDbType.Int);
            sqlParam1.Value = prodid;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            DataSet infoDs = new DataSet();

            initializeDBConnection();

            try
            {

                infoDs = execDatasetSelectByKeyParams(DBQuery.checkListProductAlreadyExist, sqlParams);





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
            dispose();
            return infoDs;
        }


        public DataSet GetOrderdeliverydataInfo(int intDeliveryID)
        {
            DataSet loginDs = new DataSet();
            DataSet dsDeliveryDateList = new DataSet();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@date_Id", SqlDbType.Int);
            sqlParam.Value = intDeliveryID;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.SelectDeliveryDateDetails, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;


            }
            dispose();
            return loginDs;

        }

        public DataSet GetOrderdeliverydataInfoDetails(string deliverydate)
        {
            DataSet loginDs = new DataSet();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@deliverydate", SqlDbType.DateTime);
            sqlParam.Value = deliverydate;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            initializeDBConnection();

            try
            {
                loginDs = execDatasetSelectByKeyParams(DBQuery.SelectOrderdeliverydatedetails1, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                string str;
                str = sqlEx.Message + sqlEx.StackTrace;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;


            }
            dispose();
            return loginDs;
        }

        public DataSet SelectDeliveryDatezipAllDetails(string strdate)
        {
            DataSet dsEmployeeDeatils = default(DataSet);


            List<SqlParameter> sqlParams = new List<SqlParameter>();
            string str = string.Empty;



            SqlParameter sqlParam = new SqlParameter("@DateId", SqlDbType.Int);
            sqlParam.Value = strdate;
            sqlParam.Size = 5;
            sqlParams.Add(sqlParam);

            initializeDBConnection();
            try
            {
                // dsEmployeeDeatils = execDatasetByKeyParams(DBQuery.SelectDeliveryDatezipAllDetails, sqlParams);
                dsEmployeeDeatils = execDatasetByKeyParams(DBQuery.selectDeliveryDatezipcode, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                dsEmployeeDeatils = null;
            }
            catch (Exception ex)
            {
                dsEmployeeDeatils = null;
            }
            return dsEmployeeDeatils;
        }

        public DataSet GetdsDeliverytimeInfoDetails(int dateID)
        {
            DataSet dsEmployeeDeatils = default(DataSet);

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@dateID", SqlDbType.Int);
            sqlParam.Value = dateID;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            initializeDBConnection();
            try
            {
                dsEmployeeDeatils = execDatasetSelectByKeyParams(DBQuery.selectDeliverytimeInfo1, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                dsEmployeeDeatils = null;
            }
            catch (Exception ex)
            {
                dsEmployeeDeatils = null;
            }
            return dsEmployeeDeatils;
        }
        public int CheckDeliveryZipInOrder(string deliveryDate, string zipcode)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            SqlParameter sqlParam = new SqlParameter("@deliverydate", SqlDbType.VarChar);
            sqlParam.Value = deliveryDate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);
            SqlParameter sqlParam1 = new SqlParameter("@zipcode", SqlDbType.VarChar);
            sqlParam1.Value = zipcode;
            sqlParam1.Size = 10;
            sqlParams.Add(sqlParam1);

            int insertZip = 0;
            initializeDBConnection();

            try
            {
                SqlDataReader reader = execSelectByKeyParams(DBQuery.QryCheckDeliveryZipInorders, sqlParams);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        insertZip = Convert.ToInt32(reader["count"]);
                    }

                }
                reader.Close();
            }
            catch (SqlException sqlEx)
            {
                insertZip = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertZip = 0;

            }
            dispose();
            return insertZip;
        }

        public int DeleteDeliveryDateZipInfo1(int deliveryDateId, int zipcodeid)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@deliveryDateId", SqlDbType.Int);
            sqlParam.Value = deliveryDateId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@zipcode_id", SqlDbType.Int);
            sqlParam1.Value = zipcodeid;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            int insertZip = 0;


            initializeDBConnection();

            try
            {
                insertZip = execDMLByKeyParams(DBQuery.DeleteDeliveryDateZipInfo1, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertZip = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertZip = 0;

            }
            dispose();
            return insertZip;
        }

        public DataSet GetDeliveryType()
        {
            initializeDBConnection();

            DataSet ds = new DataSet();

            try
            {
                ds = execDatasetSelectByKey(DBQuery.GetDeliveryType);
            }
            catch (SqlException sqlEx)
            {
                string str = sqlEx.Message;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }

            return ds;
        }

        public int UpdateDeliveryDateMappingInfo(int deliveryDateId, int timeId, int intCapacity, int intLoc)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@deliveryDateId", SqlDbType.Int);
            sqlParam.Value = deliveryDateId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@timeId", SqlDbType.Int);
            sqlParam1.Value = timeId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@intCapacity", SqlDbType.Int);
            sqlParam2.Value = intCapacity;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            SqlParameter sqlParam3 = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam3.Value = intLoc;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);

            int insertDate = 0;

            initializeDBConnection();

            try
            {
                insertDate = execDMLByKeyParams(DBQuery.UpdateDeliveryDateTIMEMappingInfo, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                insertDate = 0;
            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertDate = 0;
            }

            dispose();
            return insertDate;
        }

        public DataSet GetDeliveryDateDetailsSameDay()
        {
            DataSet dsEmployeeDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsEmployeeDeatils = execDatasetSelectByKey(DBQuery.selectDeliverySamedayDateInfo);
            }
            catch (SqlException sqlEx)
            {
                dsEmployeeDeatils = null;
            }
            catch (Exception ex)
            {
                dsEmployeeDeatils = null;
            }
            return dsEmployeeDeatils;
        }

        public int DeleteDelievryDateSameDay(int intDeliveryID)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@intDeliveryID", SqlDbType.Int);
            sqlParam.Value = intDeliveryID;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);


            int deleteDate = 0;



            List<SqlParameter> sqlParams1 = new List<SqlParameter>();

            SqlParameter sqlParam1 = new SqlParameter("@intDeliveryID", SqlDbType.Int);
            sqlParam1.Value = intDeliveryID;
            sqlParam1.Size = 4;
            sqlParams1.Add(sqlParam1);


            int deleteDelievryMapping = 0;


            initializeDBConnection();

            try
            {
                deleteDate = execDMLByKeyParams(DBQuery.deleteDeliveryDateSameDay, sqlParams);
                if (deleteDate != 0)
                {
                    deleteDelievryMapping = execDMLByKeyParams(DBQuery.deleteDeliveryDateSameDayZip, sqlParams1);
                    deleteDelievryMapping = execDMLByKeyParams(DBQuery.deleteDeliveryDateSameDayZip1, sqlParams1);
                    deleteDelievryMapping = execDMLByKeyParams(DBQuery.deleteDeliveryDateSameDayZip2, sqlParams1);

                }

            }
            catch (SqlException sqlEx)
            {
                deleteDelievryMapping = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                deleteDelievryMapping = 0;

            }
            dispose();
            return deleteDelievryMapping;
        }

        public DataSet DeliverySameDayDateZoneAlreadyExist(string strDate)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@strDate", SqlDbType.VarChar);
            sqlParam.Value = strDate;
            sqlParam.Size = 50;
            sqlParams.Add(sqlParam);




            DataSet ds = new DataSet();

            initializeDBConnection();

            try
            {
                ds = execDatasetSelectByKeyParams(DBQuery.selectDeliverySameDateZoneAlreadyExist, sqlParams);

            }
            catch (SqlException sqlEx)
            {
                ds = null;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                ds = null;
            }
            dispose();
            return ds;
        }

        public int InsertDeliverySamedayDateZipInfo(int deliveryDateId, int zipcodeid, int zone_id)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@deliveryDateId", SqlDbType.Int);
            sqlParam.Value = deliveryDateId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@zipcode_id", SqlDbType.Int);
            sqlParam1.Value = zipcodeid;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);

            SqlParameter sqlParam2 = new SqlParameter("@zone_id", SqlDbType.Int);
            sqlParam2.Value = zone_id;
            sqlParam2.Size = 4;
            sqlParams.Add(sqlParam2);

            int insertZip = 0;


            initializeDBConnection();

            try
            {
                insertZip = execDMLByKeyParams(DBQuery.insertDeliveryDateSamedayZipInfo1, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertZip = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertZip = 0;

            }
            dispose();
            return insertZip;
        }

        public int InsertSamDayDeleveryDateMappingInfo(int deliveryDateId, int timeId, int intLoc)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@deliveryDateId", SqlDbType.Int);
            sqlParam.Value = deliveryDateId;
            sqlParam.Size = 4;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@timeId", SqlDbType.Int);
            sqlParam1.Value = timeId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);



            SqlParameter sqlParam3 = new SqlParameter("@intLoc", SqlDbType.Int);
            sqlParam3.Value = intLoc;
            sqlParam3.Size = 4;
            sqlParams.Add(sqlParam3);


            int insertDate = 0;


            initializeDBConnection();

            try
            {
                insertDate = execDMLByKeyParams(DBQuery.insertSamDayDelDateMappingInfo, sqlParams);


            }
            catch (SqlException sqlEx)
            {
                insertDate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertDate = 0;

            }
            dispose();
            return insertDate;
        }

        public DataSet GetTodaysDeliveryDetails1()
        {
            DataSet dsEmployeeDeatils = default(DataSet);

            initializeDBConnection();
            try
            {
                dsEmployeeDeatils = execDatasetSelectByKey(DBQuery.selectTodaysDeliveryDetails1);
            }
            catch (SqlException sqlEx)
            {
                dsEmployeeDeatils = null;
            }
            catch (Exception ex)
            {
                dsEmployeeDeatils = null;
            }
            return dsEmployeeDeatils;
        }

        public int InsertDeliverySamedayDateInfo(DateTime deliveryDate, int intLocId)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter sqlParam = new SqlParameter("@deliveryDate", SqlDbType.DateTime);
            sqlParam.Value = deliveryDate;
            sqlParam.Size = 8;
            sqlParams.Add(sqlParam);

            SqlParameter sqlParam1 = new SqlParameter("@intLocId", SqlDbType.Int);
            sqlParam1.Value = intLocId;
            sqlParam1.Size = 4;
            sqlParams.Add(sqlParam1);


            int insertDeliveryDate = 0;


            initializeDBConnection();

            try
            {
                DataSet ds = execDatasetSelectByKeyParams(DBQuery.insertDeliverySamedayDateInfo, sqlParams);

                foreach (DataRow drr in ds.Tables[0].Rows)
                {
                    insertDeliveryDate = Convert.ToInt32(drr[0].ToString());
                }


            }
            catch (SqlException sqlEx)
            {
                insertDeliveryDate = 0;

            }
            catch (Exception ex)
            {
                string str = null;
                str = ex.Message;
                insertDeliveryDate = 0;

            }
            dispose();
            return insertDeliveryDate;
        }

        internal DataView GetShoppingList(string strDate, string sortDirection, string sortExpression)
        {
            DataSet ds = new DataSet();
            DataView view = new DataView();

            initializeDBConnection();

            try
            {
                if (sortExpression == "shelf_position")
                {
                    ds = execDatasetByKeyParams(DBQuery.GetShoppingList2, new List<SqlParameter> { new SqlParameter { ParameterName = "orders_deliverydate", SqlDbType = SqlDbType.VarChar, Value = strDate } });

                    view = new DataView(ds.Tables[0]);

                    if (sortDirection.ToLower() == "DESC".ToLower())
                        view.Sort = sortExpression + " " + sortDirection;
                }
                else
                {
                    ds = execDatasetByKeyParams(DBQuery.GetShoppingList + sortExpression + " " + sortDirection, new List<SqlParameter> { new SqlParameter { ParameterName = "orders_deliverydate", SqlDbType = SqlDbType.VarChar, Value = strDate } });
                    view = new DataView(ds.Tables[0]);
                }

                return view;
            }
            catch (SqlException sqlEx)
            {
                return view;
            }
            catch (Exception ex)
            {
                return view;
            }
        }
    }
}

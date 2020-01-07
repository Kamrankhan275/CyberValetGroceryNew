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
using System.Collections.Generic; 
namespace CyberValetGrocery.Class
{
    public class BaseProvider
    {
        protected string connectionStringConfigKey;
        protected string connectionString;
        protected SqlConnection dbConnection;								   // Constants
        protected string constOrderBy = " ORDER BY ";
        // Used to read various config settings such as 
        // db connection string
        // sql queries
        //protected ConfigurationSettings config;
        protected System.Configuration.ConfigurationSettings config;
        protected System.Configuration.ConfigurationSettings cf;

        public BaseProvider(string configConnectKey)
        {
            //
            // TODO: Add constructor logic here
            //
            if (configConnectKey == string.Empty)
            {

                connectionStringConfigKey = DBQuery.defaultDBConnection_ConnectionString;
            }
            else
            {
                connectionStringConfigKey = configConnectKey;
            }

            connectionString = null;
            dbConnection = null;
        }
        public void dispose()
        {
            if (dbConnection == null)
            {
                return;
            }
            if (dbConnection.State != ConnectionState.Open)
            {
                //' Now close the connection and cleanup its resources
                dbConnection.Close();
                dbConnection.Dispose();
                dbConnection = null;

            }
            else
            {
                dbConnection.Close();
                dbConnection.Dispose();
                dbConnection = null;
            }
        }

        public string executeScalarQuery(string key, List<SqlParameter> sqlParams)
        {
            int i = 0;
            string value = "";

            SqlCommand sqlCommand = new SqlCommand(key, dbConnection);

            int cmd_Count = sqlParams.Count;

            for (i = 0; i <= (cmd_Count - 1); i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);
            }

            value = sqlCommand.ExecuteScalar().ToString();
            return value;
        }

        public bool initializeDBConnection()
        {
            bool retVal = false;
            // ' If connection is already open then we dont need to do anything
            if (dbConnection == null)
            {
                try
                {
                    connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                 
                    dbConnection = new SqlConnection(connectionString);
                    dbConnection.Open();
                    retVal = true;
                }
                catch
                {

                    //SqlException sqlEx;
                    //string msg= sqlEx.Message;
                    retVal = false;

                }

            }
            else if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection = null;
                try
                {

                    connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                    dbConnection = new SqlConnection(connectionString);
                    dbConnection.Open();
                    retVal = true;
                }
                catch
                {
                    //SqlException sqlEx;
                    retVal = false;
                }
                retVal = true;
            }
            return retVal;
        }
        //' Executes a DML statement and returns the could of affected rows

        public int execDMLQuery(string sql)
        {
            int rowsAffected;
            SqlCommand sqlCommand;
            sqlCommand = new SqlCommand(sql, dbConnection);
            rowsAffected = sqlCommand.ExecuteNonQuery();
            // First cleanup the sql command object
            sqlCommand.Dispose();
            sqlCommand = null;
            // Return the number of affected rows by this query
            return rowsAffected;
        }

        public SqlDataReader execSelectQuery(string sql)
        {
            SqlDataReader dataReader;
            SqlCommand sqlCommand = new SqlCommand(sql, dbConnection);
            // Reads a recordset and return the corresponding datareader object
            dataReader = sqlCommand.ExecuteReader();
            return dataReader;

        }
        // Executes a select statement using a property key as parameter 
        // Returns the datareader for returned recordset

        public SqlDataReader execSelectByKey(string key)
        {
            string selectSql = key;
            return execSelectQuery(selectSql);
        }
        // Executes a select statement using a property key as parameter 
        // Parameters are expected as the second parameter to the function
        // Returns the datareader for returned recordset

        public SqlDataReader execSelectByKeyParams(string key, List<SqlParameter> sqlParams)
        {
            int i;
            SqlDataReader dataReader;
            string str = key;
            string sqlSelectQuery = new string(str.ToCharArray());

            SqlCommand sqlCommand = new SqlCommand(sqlSelectQuery, dbConnection);
            //' Reads a recordset and return the corresponding datareader object

            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);

            }
            sqlCommand.Prepare();
            dataReader = sqlCommand.ExecuteReader();
            return dataReader;
        }
        // Executes a select statement using a property key as parameter 
        // Parameters are expected as the second parameter to the function
        // Returns the datareader for returned recordset

        public int execDMLByKeyParams(string key, List<SqlParameter> sqlParams)
        {
            /*try
            {*/
            int i;
            int rowsAffected;
            SqlCommand sqlCommand = new SqlCommand(key, dbConnection);
            //Reads a recordset and return the corresponding datareader object
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);

            }
            sqlCommand.Prepare();
            rowsAffected = Convert.ToInt16(sqlCommand.ExecuteNonQuery());
            return rowsAffected;
            //}
            /*catch(Exception e)
            {
    //				Exception ex;
    //				ex.Message.ToString();
                return 0;
                Console.WriteLine("{0} Exception caught.", e);
            }*/

        }
        //' Executes a select statement and returns DataSet for returned recordset
        public DataSet execDatasetSelectQuery(string sql)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand(sql, dbConnection);
            dataAdapter.SelectCommand = sqlCommand;
            // Reads a recordset and fill data into the dataset
            dataAdapter.Fill(dataSet);
            return dataSet;
        }
        //Executes a select statement using a property key as parameter 
        //' Returns the DataSet for returned recordset

        public DataSet execDatasetSelectByKey(string key)
        {
            string selectSql = key;
            return execDatasetSelectQuery(selectSql);
        }
        // Executes a select statement using a property key and order by 
        // column name as parameters
        // Returns the DataSet for returned recordset

        public DataSet execDatasetSelectKeyOrderBy(string sqlKey, string orderByColumn)
        {
            string selectSql = sqlKey;
            string orderBySql = selectSql + constOrderBy + orderByColumn;
            return execDatasetSelectQuery(orderBySql);
        }

        public DataSet execDatasetByKeyParams(string key, List<SqlParameter> sqlParams)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            int i;
            SqlCommand sqlCommand = new SqlCommand(key, dbConnection);
            //' Reads a recordset and return the corresponding datareader object

            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);

            }
            dataAdapter.SelectCommand = sqlCommand;
            // Reads a recordset and fill data into the dataset
            dataAdapter.Fill(dataSet);
            return dataSet;

        }
        public DataSet execDatasetSelectQueryParam(string sql, List<SqlParameter> sqlParams)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            int i;
            SqlCommand sqlCommand = new SqlCommand(sql, dbConnection);
            // Reads a recordset and return the corresponding datareader object
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);
            }
            dataAdapter.SelectCommand = sqlCommand;
            //' Reads a recordset and fill data into the dataset
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        public DataSet execDatasetSelectKeyOrderByParam(string sqlKey, string orderByColumn, List<SqlParameter> sqlParams)
        {
            string selectSql = sqlKey;
            string orderBySql = selectSql + constOrderBy + orderByColumn;
            return execDatasetSelectQueryParam(orderBySql, sqlParams);
            //Dim orderBySql As String = sqlKey + constOrderBy + orderByColumn
            //Return execDatasetSelectQueryParam(orderBySql, sqlparam)
        }
        public DataSet execDatasetSelectPagesQuery(string sql, List<SqlParameter> sqlParams, int startRow, int pageSize, string tableName)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            int i;
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand(sql, dbConnection);
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);
            }

            sqlCommand.Prepare();
            dataAdapter.SelectCommand = sqlCommand;
            // Reads a recordset and fill data into the dataset
            dataAdapter.Fill(dataSet, startRow, pageSize, tableName);
            return dataSet;
        }


        //Executes a select statement using a property key as parameter 
        //' Returns the DataSet for returned recordset

        public DataSet execDatasetSelectPagesByKey(string sql, List<SqlParameter> sqlParams, int startRow, int pageSize, string tableName)
        {
            string selectSql = sql;
            return execDatasetSelectPagesQuery(selectSql, sqlParams, startRow, pageSize, tableName);
        }

        public DataSet execDatasetSelectQuery_temp(string key, int startRow, int pageSize, string tableName)
        {
            string selectSql = key;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            SqlCommand sqlCommand = new SqlCommand(selectSql, dbConnection);
            dataAdapter.SelectCommand = sqlCommand;
            //' Reads a recordset and fill data into the dataset
            dataAdapter.Fill(dataSet, startRow, pageSize, tableName);
            return dataSet;
        }

        public SqlDataReader execSelectByQueryParams(string query, List<SqlParameter> sqlParams)
        {
            int i;
            SqlDataReader dataReader;
            string sqlSelectQuery = new string(query.ToCharArray());
            SqlCommand sqlCommand = new SqlCommand(sqlSelectQuery, dbConnection);
            //' Reads a recordset and return the corresponding datareader object
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);
            }
            sqlCommand.Prepare();
            dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dataReader;
        }
        //'Executes a Select query and returns a dataset by ranjan@maxnet-tech.com
        public DataSet execSelectByQueryParams_dataset(string query, List<SqlParameter> sqlParams)
        {
            int i;
            DataSet dataset = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            string sqlSelectQuery = new string(query.ToCharArray());

            SqlCommand sqlCommand = new SqlCommand(sqlSelectQuery, dbConnection);
            //'Reads a recordset and return the corresponding dataset object
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);
            }
            sqlCommand.Prepare();
            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataset);
            return dataset;
        }

        // Executes a select statement using a property key as parameter 
        //Returns the DataSet for returned recordset

        public DataSet execDatasetSelectByKeyParams(string key, List<SqlParameter> sqlParams)
        {
            string selectSql = key;
            return execDatasetSelectByQueryParams(selectSql, sqlParams);
        }

        public DataSet execDatasetSelectByKeyParamsNew1(string key, List<SqlParameter> sqlParams)
        {
            //string selectSql = ConfigurationSettings.AppSettings[key].ToString();
            return execDatasetSelectByQueryParams1(key, sqlParams);
        }
        public DataSet execDatasetSelectByQueryParams(string key, List<SqlParameter> sqlParams)
        {
            int i;
            DataSet dataset = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            string sqlSelectQuery = new string(key.ToCharArray());
            SqlCommand sqlCommand = new SqlCommand(sqlSelectQuery, dbConnection);
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);
            }
            sqlCommand.Prepare();
            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataset);
            return dataset;
        }

        public DataSet execDatasetSelectByQueryParams1(string key, List<SqlParameter> sqlParams)
        {
            int i;
            DataSet dataset = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            string sqlSelectQuery = key;
            SqlCommand sqlCommand = new SqlCommand(sqlSelectQuery, dbConnection);
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);
            }
            sqlCommand.Prepare();
            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataset);
            return dataset;
        }



        public int execDMLByQueryParams(string query, List<SqlParameter> sqlParams)
        {
            int i;
            int rowsAffected;
            SqlCommand sqlCommand = new SqlCommand(query, dbConnection);
            //' Reads a recordset and return the corresponding datareader object
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);
            }
            sqlCommand.Prepare();
            rowsAffected = sqlCommand.ExecuteNonQuery();
            return rowsAffected;
        }

        //function for datalist custom paging
        public DataSet execDatasetSelectPagesByKeyParams(string key, List<SqlParameter> sqlParams, int startrow, int pagesize, string tablename)
        {
            string selectSql = key;
            return execDatasetSelectPagesByKeyParamsNew(selectSql, sqlParams, startrow, pagesize, tablename);
        }
        public DataSet execDatasetSelectPagesByKeyParams(string key, int startrow, int pagesize, string tablename)
        {
            string selectSql = key;
            return execDatasetSelectPagesByKeyParamsNew(selectSql, startrow, pagesize, tablename);
        }
        public DataSet execDatasetSelectPagesByKeyParamsNew(string sql, int startrow, int pagesize, string tablename)
        {
            SqlDataAdapter dataadapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, dbConnection);
            dataadapter.SelectCommand = cmd;
            dataadapter.Fill(ds, startrow, pagesize, tablename);
            return ds;
        }
        public DataSet execDatasetSelectPagesByKeyParamsNew(string key, List<SqlParameter> sqlParams, int startrow, int pagesize, string tablename)
        {
            int i;
            DataSet dataset = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            string sqlSelectQuery = new string(key.ToCharArray());
            SqlCommand sqlCommand = new SqlCommand(sqlSelectQuery, dbConnection);
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);
            }
            sqlCommand.Prepare();
            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataset, startrow, pagesize, tablename);
            return dataset;

        }



        public SqlDataReader execSelectByKeyParamsNew(string key, List<SqlParameter> sqlParams)
        {
            int i;
            SqlDataReader dataReader;
            string str = key;
            string sqlSelectQuery = new string(str.ToCharArray());

            SqlCommand sqlCommand = new SqlCommand(sqlSelectQuery, dbConnection);
            //' Reads a recordset and return the corresponding datareader object
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);

            }
            sqlCommand.Prepare();
            dataReader = sqlCommand.ExecuteReader();
            return dataReader;
        }

        public DataSet execDatasetByKeyParamsNew(string key, List<SqlParameter> sqlParams)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            int i;
            SqlCommand sqlCommand = new SqlCommand(key, dbConnection);
            //' Reads a recordset and return the corresponding datareader object
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);

            }
            dataAdapter.SelectCommand = sqlCommand;
            // Reads a recordset and fill data into the dataset
            dataAdapter.Fill(dataSet);
            return dataSet;

        }
        public int execDMLByKeyParamsss(string key, List<SqlParameter> sqlParams)
        {
            /*try
            {*/
            int i;
            int rowsAffected;
            SqlCommand sqlCommand = new SqlCommand(Convert.ToString(ConfigurationSettings.AppSettings[key]), dbConnection);
            //Reads a recordset and return the corresponding datareader object
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);

            }
            sqlCommand.Prepare();
            rowsAffected = Convert.ToInt16(sqlCommand.ExecuteScalar());
            return rowsAffected;
            //}
            /*catch(Exception e)
            {
    //				Exception ex;
    //				ex.Message);
                return 0;
                Console.WriteLine("{0} Exception caught.", e);
            }*/

        }

        public DataSet execDatasetSelectByKeyreplacewithparam(string key, List<SqlParameter> sqlParams)
        {
            string selectSql = key;
            string str = selectSql.Replace("{lessthan}", "<");
            return execDatasetByStringParams(str, sqlParams);

        }

        public DataSet execDatasetByStringParams(string str, List<SqlParameter> sqlParams)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            int i;
            SqlCommand sqlCommand = new SqlCommand(str, dbConnection);
            //' Reads a recordset and return the corresponding datareader object
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);

            }
            dataAdapter.SelectCommand = sqlCommand;
            // Reads a recordset and fill data into the dataset
            dataAdapter.Fill(dataSet);
            return dataSet;

        }

        public DataSet execSelectByKeyParamsConsPages(string key, List<SqlParameter> sqlParams)
        {
            //try
            //{
            int i = 0;
            DataSet dataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            //string sqlSelectQuery = ConfigurationSettings.AppSettings[key].ToString(); 
            SqlCommand sqlCommand = new SqlCommand(key, dbConnection);
            //da = New SqlDataAdapter(sqlCommand)
            // Reads a recordset and return the corresponding datareader object
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= (cmd_Count - 1); i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);
            }
            //sqlCommand.Prepare()
            da.SelectCommand = sqlCommand;
            da.Fill(dataSet);
            //dataReader = sqlCommand.ExecuteReader()
            return dataSet;
            //}
            //catch (Exception ex)
            //{
            //    string str = ex.Message;
            //}
        }
        public DataSet execDatasetSelectByKeyreplace(string key)
        {
            string selectSql = key;
            string str = selectSql.Replace("{lessthan}", "<");
            return execDatasetSelectQuery(str);

        }
        public DataSet execSelectByKeyParamsOversightPages(string key, List<SqlParameter> sqlParams)
        {
            //try
            //{
            int i = 0;
            DataSet dataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            string sqlSelectQuery = new string(key.ToCharArray());
            SqlCommand sqlCommand = new SqlCommand(sqlSelectQuery, dbConnection);
            //da = New SqlDataAdapter(sqlCommand)
            // Reads a recordset and return the corresponding datareader object
            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= cmd_Count - 1; i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);
            }
            //sqlCommand.Prepare()
            da.SelectCommand = sqlCommand;
            da.Fill(dataSet);
            //dataReader = sqlCommand.ExecuteReader()
            return dataSet;
            //}
            //catch (Exception ex)
            //{
            //    string str = ex.Message;
            //}
        }

        public DataSet execSelectByKeyParamsActivityList(string key, List<SqlParameter> sqlParams)
        {

            int i = 0;
            DataSet dataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand sqlCommand = new SqlCommand(key, dbConnection);

            int cmd_Count = sqlParams.Count;
            for (i = 0; i <= (cmd_Count - 1); i++)
            {
                sqlCommand.Parameters.Add(sqlParams[i]);
            }

            da.SelectCommand = sqlCommand;
            da.Fill(dataSet);

            return dataSet;

        }
    }
}

using MySql.Data.MySqlClient;
using pos_main.BAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_main
{
   
    public  class DatabaseConnection:IDisposable
    {
        MySqlConnection conn = null;
        string mysqlconn = "server=127.0.0.1; user=root; database=anasarif; password=";

        public void OpenConnection()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(mysqlconn);
                conn.Open();
            }
        }
        public void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        protected DataTable GetData(MySqlCommand pObjCommand)
        {
            try
            {
                pObjCommand.Connection = conn;
                DataTable dataTable = new DataTable();
                MySqlDataAdapter objAdapter = new MySqlDataAdapter(pObjCommand);
                objAdapter.Fill(dataTable);
                objAdapter.Dispose();
                CloseConnection();
                return dataTable;
            }
            catch (MySqlException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        void IDisposable.Dispose()
        {
            CloseConnection();
            GC.SuppressFinalize(this);
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace pos_main.BAL
{
    public class UserBAL:DatabaseConnection
    {
         string mysqlconn = "server=127.0.0.1; user=root; database=anasarif; password=";
        public DataTable UserLogin(string UserName,string Password)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM details WHERE username = @UserName AND password = @Password";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    OpenConnection(true);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@UserName", MySqlDbType.VarChar).Value = UserName;
                    cmd.Parameters.Add("@Password", MySqlDbType.VarChar).Value = Password;
                    dt = GetData(cmd);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }
        public bool SignUp(string UserName, string Name, string Password)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(mysqlconn); ;
                string query = "INSERT INTO `details` (`username`, `name`, `password`) VALUES (@UserName, @Name, @Password)";
                using (MySqlCommand cmd = new MySqlCommand(query,conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@UserName", MySqlDbType.VarChar).Value = UserName;
                    cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = Name;
                    cmd.Parameters.Add("@Password", MySqlDbType.VarChar).Value = Password;

                    int result = cmd.ExecuteNonQuery();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}

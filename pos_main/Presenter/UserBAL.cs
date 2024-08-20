using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using pos_main.Model;
using pos_main.view;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace pos_main.BAL
{
    public class UserBAL : DatabaseConnection, PosFunction
    {
        string mysqlconn = "server=127.0.0.1; user=root; database=anasarif; password=";
        public string UserLogin(string Email, string Password)
        {
            try
            {
                MySqlConnection conn =new MySqlConnection(mysqlconn);
                string query = "SELECT Status FROM details WHERE User_email = @Email AND password = @Password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Password", Password);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while logging in.", ex);
            }
        }
        public string UserDetail(string Email, string Password)
        {
            try
            {
                MySqlConnection conn =new MySqlConnection(mysqlconn);
                string query = "SELECT OrderNumber FROM details WHERE User_email = @Email AND password = @Password";
                using (MySqlCommand cmd = new MySqlCommand(query,conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    object result = cmd.ExecuteScalar();


                    if (result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SignUp(string UserName, string email, string Password,string TableName,int OrderCount)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(mysqlconn); ;
                string query = "INSERT INTO `details` (`Username`, `User_email`, `password`,`Status`,`OrderNumber`,`OrderCount`) VALUES (@UserName, @email, @Password,@status,@TableName,@OrderCount)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@UserName", MySqlDbType.VarChar).Value = UserName;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@Password", MySqlDbType.VarChar).Value = Password;
                    cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = "UnVerified";
                    cmd.Parameters.Add("@TableName", MySqlDbType.VarChar).Value = TableName;
                    cmd.Parameters.Add("@OrderCount", MySqlDbType.Int32).Value = OrderCount;

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
        public void NewUser(string tableName)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(mysqlconn))
                {
                    conn.Open();
                    string query = @"CREATE TABLE `" + tableName + "` (`Id` INT NOT NULL AUTO_INCREMENT,`Ordername` VARCHAR(50) NOT NULL,`Quantity` INT NOT NULL,`Price` INT NOT NULL,`Total` INT NOT NULL,PRIMARY KEY (`id`))";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void conection(string Ordername, int Quanity, int Price,string tableName)
        {
            try
            {
            int total = Quanity * Price;
            using (MySqlConnection conn = new MySqlConnection(mysqlconn))
            {
                conn.Open();
                string query = "INSERT INTO `" +tableName + "` (`Ordername`, `Quantity`, `Price`, `Total`) VALUES (@orderName,@quantity,@price,@total)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.Add("@orderName", MySqlDbType.VarChar).Value = Ordername;
                command.Parameters.Add("@quantity", MySqlDbType.Int64).Value = Quanity;
                command.Parameters.Add("@price", MySqlDbType.Int64).Value = Price;
                command.Parameters.Add("@total", MySqlDbType.Int64).Value = total;
                command.ExecuteNonQuery();
            }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(string Ordername, int Quanity, int Price,string tableName)
        {
            try
            {
            int updatetotal = Quanity * Price;
            using (MySqlConnection conn = new MySqlConnection(mysqlconn))
            {
                conn.Open();
                string query = "UPDATE `" + tableName + "` SET Quantity = Quantity + @quantity, Total = Total + @total WHERE Ordername = @orderName;";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.Add("@orderName", MySqlDbType.VarChar).Value = Ordername;
                command.Parameters.Add("@quantity", MySqlDbType.Int64).Value = Quanity;
                command.Parameters.Add("@total", MySqlDbType.Int64).Value = updatetotal;
                command.ExecuteNonQuery();
            }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Store(string Address, string phone ,string recievetext)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(mysqlconn))
                {
                    conn.Open();
                    string query = "UPDATE `details` SET `Phone` = @phone, `Address` = @address Where `User_email` = @recievetext";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                    command.Parameters.Add("@address", MySqlDbType.VarChar).Value = Address;
                    command.Parameters.Add("@recievetext", MySqlDbType.VarChar).Value = recievetext;
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool MainshowData(DataGridView DGV,string query)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(mysqlconn))
                {
                    conn.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    command.Fill(dt);
                    DGV.DataSource = dt;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ShowingData(DataGridView DGV,string tableName)
        {
            try
            {
                string query = "SELECT Id, Ordername, Price, Quantity, Total FROM `"+ tableName + "`;";
                bool uesrt=MainshowData(DGV,query);
                if (uesrt)
                {
                   return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data");
                return false;
            }
        }
        public void Detail(DataGridView DGV,string tableName)
        {
            try
            {
                string query = "Select Ordername,Price,Quantity from `" + tableName + "`;";
                MainshowData(DGV, query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public double total(double total,DataGridView DGV, Label label)
        {
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                total += Convert.ToDouble(DGV.Rows[i].Cells[4].Value);
            }
            label.Text = total.ToString() + " Rs";
            return total;
        }
        public int check(string Ordername,string tableName)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(mysqlconn))
                {
                    conn.Open();
                    string query = "SELECT Quantity FROM `"+ tableName + "` WHERE Ordername = @ordername";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.Add("@ordername", MySqlDbType.VarChar).Value = Ordername;

                    int Commingvalue = Convert.ToInt32(command.ExecuteScalar());
                    return Commingvalue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public void Check_the_Stock(string textbox, string product, int price, DataGridView DGV,string tableName)
        {
            try
            {
                if (string.IsNullOrEmpty(textbox))
                {
                    MessageBox.Show("Fill The Quantity");
                    return;
                }

                int quantity = int.Parse(textbox);
                int commingvalue = check(product, tableName);

                if (commingvalue + quantity > 100)
                {
                    MessageBox.Show("Out Of Stock & Will Be Available Soon");
                }
                else
                {
                    if (commingvalue == 0)
                    {
                        conection(product, quantity, price, tableName);
                    }
                    else
                    {
                        Update(product, quantity, price, tableName);
                    }
                    Detail(DGV, tableName);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        public void Delete(string tableName)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(mysqlconn))
                {
                    conn.Open();
                    string query = "DROP TABLE `"+tableName+"`;";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    string query1 = @"CREATE TABLE `" + tableName + "` (`Id` INT NOT NULL AUTO_INCREMENT,`Ordername` VARCHAR(50) NOT NULL,`Quantity` INT NOT NULL,`Price` INT NOT NULL,`Total` INT NOT NULL,PRIMARY KEY (`id`))";
                    MySqlCommand command1 = new MySqlCommand(query1, conn);
                    command1.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Print(DataGridView DGV,string tableName)
        {
            try
            {
                string query = "Select Ordername,Quantity,Total from `"+tableName+"`;";
                MainshowData(DGV, query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void PrintSlip(DataGridView DGV, PrintPageEventArgs e,string name,string phone,string Address,double total)
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string currentTime = DateTime.Now.ToString("HH:mm:ss");
            // Set font and create a brush for drawing text
            Font printFont = new Font("Arial", 18);
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);
            Brush printBrush = Brushes.Black;

            // Define margins and initial positions
            //int headerHeight = 20; // Height for the header row
            int headerHeight1 = 50; // Height for the header row
            int rowHeight = 0;
            int columnWidth = 0;
            int xPosition = e.MarginBounds.Left;
            int yPosition = e.MarginBounds.Top;

            // Draw additional information
            e.Graphics.DrawString("INVENTORY SYSTEM",
                new Font("Arial", 20, FontStyle.Bold),
                Brushes.Black,
                new Point(275, 10));

            e.Graphics.DrawString("Apna Mart",
                new Font("Arial", 20, FontStyle.Bold),
                Brushes.Black,
                new Point(355, 45));

            e.Graphics.DrawString("MAIN BRANCH",
                new Font("Arial", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(30, 100));

            e.Graphics.DrawString("LOCATION : SADDAR",
                new Font("Arial", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(30, 120));

            e.Graphics.DrawString("Tell No. : 03353748840",
                new Font("Arial", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(30, 140));

            e.Graphics.DrawString("Current Date: " + currentDate,
                new Font("Arial", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(30, 160));

            e.Graphics.DrawString("Current Time: " + currentTime,
                new Font("Arial", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(30, 180));

            e.Graphics.DrawString("CASHIER: MR. CASHIER",
                new Font("Arial", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(30, 210));

            // Draw separator line
            e.Graphics.DrawString(new string('-', 135),
                new Font("Arial", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(30, 230));

            // Move yPosition down after the header and other details
            yPosition = 250; // Adjust this value as needed to position the grid content correctly

            // Draw headers
            for (int i = 0; i < DGV.Columns.Count; i++)
            {
                if (i == 0)
                {
                    columnWidth = DGV.Columns[i].Width = 50;
                    e.Graphics.DrawString(DGV.Columns[i].HeaderText, boldFont, printBrush, xPosition, yPosition);
                    xPosition += columnWidth;
                }
                else
                {
                    columnWidth = DGV.Columns[i].Width = 150;
                    e.Graphics.DrawString(DGV.Columns[i].HeaderText, boldFont, printBrush, xPosition, yPosition);
                    xPosition += columnWidth;
                }
            }
            e.Graphics.DrawString(new string('-', 135),
                new Font("Arial", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(30, 269));
            // Move yPosition down after headers
            yPosition += headerHeight1;
            xPosition = e.MarginBounds.Left; // Reset xPosition for rows

            // Print rows
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Index < DGV.Rows.Count)
                {
                    rowHeight = row.Height;


                    // Draw each cell in the current row
                    for (int i = 0; i < DGV.Columns.Count; i++)
                    {
                        if (i % 5 == 0)
                        {
                            columnWidth = DGV.Columns[i].Width = 50;
                            e.Graphics.DrawString(row.Cells[i].Value?.ToString() ?? string.Empty, new Font("Arial", 12, FontStyle.Regular), printBrush, xPosition, yPosition);
                            xPosition += columnWidth;
                        }
                        else
                        {
                            columnWidth = DGV.Columns[i].Width = 150;
                            e.Graphics.DrawString(row.Cells[i].Value?.ToString() ?? string.Empty, new Font("Arial", 12, FontStyle.Regular), printBrush, xPosition, yPosition);
                            xPosition += columnWidth;
                        }
                    }

                    // Move yPosition down after the row
                    yPosition += rowHeight;
                    xPosition = e.MarginBounds.Left; // Reset xPosition for the next row
                }
            }

            // Draw footer lines
            e.Graphics.DrawString(new string('-', 135),
                new Font("Arial", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(30, yPosition));

            // Draw customer Total

            e.Graphics.DrawString("Total: " + total + "Rs",
                new Font("Arial", 16, FontStyle.Bold),
                Brushes.Black,
                new Point(550, yPosition + 30));

            // Draw customer details
            e.Graphics.DrawString("Name: " + name,
                new Font("Arial", 14, FontStyle.Bold),
                Brushes.Black,
                new Point(30, yPosition + 30));

            e.Graphics.DrawString("Phone No.: " + phone,
                new Font("Arial", 14, FontStyle.Bold),
                Brushes.Black,
                new Point(30, yPosition + 60));

            e.Graphics.DrawString("Address: " + Address,
                new Font("Arial", 14, FontStyle.Bold),
                Brushes.Black,
                new Point(30, yPosition + 90));

            e.Graphics.DrawString(new string('-', 38) + "Thank You" + new string('-', 38),
    new Font("Arial", 18, FontStyle.Bold),
    Brushes.Black,
    new Point(30, yPosition + 110));
        }
        public void admintable(DataGridView DGV)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(mysqlconn))
                {
                    conn.Open();
                    string query = "SELECT * FROM `details`";
                    MySqlDataAdapter command = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    command.Fill(dt);
                    DGV.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AdminUpdate(int id,string username, string email,string status)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(mysqlconn))
                {
                    conn.Open();
                string query = "UPDATE `details` SET Username = @username, User_email = @email, Status = @status WHERE User_id = @id;";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                    command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DeleteRow(int id,string ordernumber)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(mysqlconn))
                {
                    conn.Open();
                    string query = "DELETE FROM `details` WHERE User_id = @id;";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
                    command.ExecuteNonQuery();
                    string query1 = $"Drop table `{ordernumber}`;";
                    MySqlCommand command1 = new MySqlCommand(query1, conn);
                    command1.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public  int Ordercheck()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(mysqlconn))
                {
                    conn.Open();
                    string query = "SELECT Max(OrderCount) From `details`";
                    MySqlCommand command = new MySqlCommand(query, conn);

                    int Commingvalue = Convert.ToInt32(command.ExecuteScalar());
                    return Commingvalue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
}
        public int tablesearch(DataGridView AdminGV,DateTime dtFromDate,DateTime dtToDate)
        {
            try
            {
                string mysqlconn = "server=127.0.0.1; user=root; database=anasarif; password=";

                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(mysqlconn))
                {
                    conn.Open();
                    string query = "SELECT * FROM `details` WHERE Date BETWEEN @fromdate AND @todate";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // adding values
                        cmd.Parameters.AddWithValue("@fromdate", dtFromDate);
                        cmd.Parameters.AddWithValue("@todate", dtToDate);
                        // fill data to datatable
                        MySqlDataAdapter DataAdapter = new MySqlDataAdapter(cmd);
                        DataAdapter.Fill(dt);
                        // adding datasource
                        AdminGV.DataSource = dt;
                        return AdminGV.RowCount;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 00;
            }
        }
    }
}


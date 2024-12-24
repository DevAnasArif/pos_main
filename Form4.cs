using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Drawing.Printing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Org.BouncyCastle.Asn1.X509;
using Mysqlx.Crud;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using pos_main;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Collections;

namespace pos_main
{
    public partial class Form4 : Form
    {
        public string recievetext { get; set; }
        public Form4(string recievetext)
        {
            InitializeComponent();
            this.recievetext = recievetext;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dbms();
        }
        public void dbms()
        {
            string mysqlcon = "server=127.0.0.1; user=root; database=anasarif; password=";
            MySqlConnection con = new MySqlConnection(mysqlcon);
            con.Open();
            string query = "Select Id,Ordername,Price,Quantity,Total from `order`";
            MySqlDataAdapter comand = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            comand.Fill(dt);
            datagrid.DataSource = dt;
            con.Close();
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Close();
        }
        public double total;
        private void cashbtn_Click(object sender, EventArgs e)
        {
            double total = 0;
            for (int i = 0; i < datagrid.Rows.Count; i++)
            {
                total += Convert.ToDouble(datagrid.Rows[i].Cells[4].Value);
            }
            label2.Text = total.ToString() + " Rs";
            this.total = total;
        }

        string name = "";
        string phone;
        string Address;
        private void printbtn_Click(object sender, EventArgs e)
        {
            name = nametextbox.Text;
            String quantity = phonetextbox.Text;
            string newAddress = adresstextbox.Text;
            Address = newAddress;
            if (string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Fill You Details");
            }
            else
            {
                if (string.IsNullOrEmpty(quantity))
                {
                    MessageBox.Show("Fill You Details");
                }
                else
                {
                    if (quantity.Length == 11 && quantity.All(char.IsDigit))
                    {
                        phone = quantity;
                        string mysqlcon = "server=127.0.0.1; user=root; database=anasarif; password=";
                        MySqlConnection con = new MySqlConnection(mysqlcon);
                        con.Open();
                        string query = "Select Ordername,Quantity,Total from `order`";
                        MySqlDataAdapter comand = new MySqlDataAdapter(query, con);
                        DataTable dt = new DataTable();
                        comand.Fill(dt);
                        dataGrid2.DataSource = dt;
                        con.Close();
                        label8.Text = total + " Rs";
                        name2.Text = name;
                        phone2.Text = phone;
                        address2.Text = Address;
                        store(Address, phone);
                        printPreviewDialog1.Document = printDocument2;
                        printPreviewDialog1.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Enter Correct Number");
                    }
                }
            }
        }
        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        string currentTime = DateTime.Now.ToString("HH:mm:ss");
        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
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
            for (int i = 0; i < datagrid.Columns.Count; i++)
            {
                if (i == 0)
                {
                    columnWidth = datagrid.Columns[i].Width = 50;
                    e.Graphics.DrawString(datagrid.Columns[i].HeaderText, boldFont, printBrush, xPosition, yPosition);
                    xPosition += columnWidth;
                }
                else
                {
                    columnWidth = datagrid.Columns[i].Width = 150;
                    e.Graphics.DrawString(datagrid.Columns[i].HeaderText, boldFont, printBrush, xPosition, yPosition);
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
            foreach (DataGridViewRow row in datagrid.Rows)
            {
                if (row.Index < datagrid.Rows.Count)
                {
                    rowHeight = row.Height;


                    // Draw each cell in the current row
                    for (int i = 0; i < datagrid.Columns.Count; i++)
                    {
                        if (i % 5 == 0)
                        {
                            columnWidth = datagrid.Columns[i].Width = 50;
                            e.Graphics.DrawString(row.Cells[i].Value?.ToString() ?? string.Empty, new Font("Arial", 12, FontStyle.Regular), printBrush, xPosition, yPosition);
                            xPosition += columnWidth;
                        }
                        else
                        {
                            columnWidth = datagrid.Columns[i].Width = 150;
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

        private void delbtn_Click(object sender, EventArgs e)
        {
            string query = "DROP TABLE `order`";
            Mysql obj = new Mysql();
            obj.sql(query);

            // Create Another Table
            string query1 = @"CREATE TABLE `order` (`Id` INT NOT NULL AUTO_INCREMENT,`Ordername` VARCHAR(50) NOT NULL,`Quantity` INT NOT NULL,`Price` INT NOT NULL,`Total` INT NOT NULL,PRIMARY KEY (`id`))";
            obj.sql(query1);
            this.Close();
        }
        public void store(String address, String nphone)
        {
            MessageBox.Show(recievetext);
            string query = "UPDATE `details` SET `Phone` = '" + nphone + "', `Address` = '" + address + "'Where `username` = '" + recievetext + "'";
            Mysql obj = new Mysql();
            obj.sql(query);
        }

    }
}
public class Mysql : Form
{
    public void sql(String query)
    {
        if (true)
        {
            string mysqlconn = "server=127.0.0.1; user=root; database=anasarif; password=";
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        else
        {
            MessageBox.Show("Error in connection");
        }
    }
}
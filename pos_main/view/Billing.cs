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
using pos_main.BAL;
using pos_main.Properties;

namespace pos_main
{
    public partial class Billing : Form
    {
        UserBAL userBAL = new UserBAL();
        public string email { get; set; }
        public string tableName { get; set; }

        public Billing()
        {
            InitializeComponent();
        }
            public Billing(string tableName,string email)
        {
            InitializeComponent();
            this.email = email;
            this.tableName = tableName;
        }
        private void Billing_Load(object sender, EventArgs e)
        {
            userBAL.ShowingData(datagrid, tableName);
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            Product form = new Product(tableName, email);
            form.Show();
            this.Hide();
        }
        public double total { get; set; }
        int i = 0;
        private void cashbtn_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                total = userBAL.total(total, datagrid, label2);
                i++;
            }
            else
            {
                MessageBox.Show("Already Clicked");
            }
        }

        string name { get; set; }
        string phone { get; set; }
        string Address { get; set; }
        private void printbtn_Click(object sender, EventArgs e)
        {
            name = nametextbox.Text;
            phone = phonetextbox.Text;
            Address = adresstextbox.Text;
            if (string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Fill You Details");
            }
            else
            {
                if (phone.Length == 11 && phone.All(char.IsDigit))
                {
                    userBAL.Print(dataGrid2, tableName);
                    label8.Text = total + " Rs";
                    name2.Text = name;
                    phone2.Text = phone;
                    address2.Text = Address;
                    MessageBox.Show(email);
                    userBAL.Store(Address, phone, email);
                    printPreviewDialog1.Document = printDocument2;
                    printPreviewDialog1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Enter Correct Number");
                }
            }
        }
       
        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        string currentTime = DateTime.Now.ToString("HH:mm:ss");
        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            userBAL.PrintSlip(datagrid,e, name, phone,Address, total);
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            userBAL.Delete(tableName);
            this.Close();
        }
    }
}
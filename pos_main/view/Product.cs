using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using pos_main.BAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace pos_main
{
    public partial class Product : Form
    {
        public string email { get; set; }
        public string tableName { get; set; }
        public Product()
        {
            InitializeComponent();

        }
        UserBAL userBAL = new UserBAL();
        public Product(string tableName, string email)
        {
            this.tableName = tableName;
            this.email = email;
            InitializeComponent();

        }
        private void slanty2_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(sltext2.Text, "slanty(vegetable)", 50, DGV, tableName);
        }
        private void slanty1_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(sltext1.Text, "slanty(salt)", 50, DGV, tableName);
        }
        private void slanty3_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(sltext3.Text, "slanty(jalapeno)", 50, DGV, tableName);
        }
        private void cheetosbtn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(cheetostext.Text, "cheetos", 50, DGV, tableName);
        }
        private void kukurebtn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(kurkuretext.Text, "kurkure", 20, DGV, tableName);
        }
        private void slice1btn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(slicetext.Text, "Slice Juice 1 L", 152, DGV, tableName);
        }
        private void cocacolabtn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(cocacolatext.Text, "cola next 1.5 L", 115, DGV, tableName);
        }
        private void pakolabtn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(pakolatext.Text, "pakola 2.25 L", 170, DGV, tableName);
        }
        private void fizupbtn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(fizzuptext.Text, "fizup 345ml", 46, DGV, tableName);
        }
        private void pakolabtn1_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(pakola2text.Text, "pakola 500ml", 50, DGV, tableName);
        }
        private void slicebtn1_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(slice1text.Text, "Slice 200ml", 42, DGV, tableName);
        }
        private void redbullbtn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(redbulltext.Text, "red bull 250ml", 415, DGV, tableName);
        }
        private void marindadbtn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(marindatext.Text, "marinda 250ml", 70, DGV, tableName);
        }
        private void colanext2_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(cocacola1text.Text, "cola next 250ml", 90, DGV, tableName);
        }
        private void fizzupbtn2_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(fizup1text.Text, "fizup 250ml", 90, DGV, tableName);
        }
        private void novitabtn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(novitatext.Text, "novita wafers", 50, DGV, tableName);
        }
        private void flobtn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(flotext.Text, "flo cake", 10, DGV, tableName);
        }
        private void choclotobtn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(chocaltotext.Text, "chocalatto biscuit", 10, DGV, tableName);
        }
        private void goodgoodiesbtn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(goodgoodiestext.Text, "good goodies", 10, DGV, tableName);
        }
        private void kitkatbtn_Click(object sender, EventArgs e)
        {
            userBAL.Check_the_Stock(kitkattext.Text, "kitkat 41.5gm", 150, DGV, tableName);
        }

        private void detailbtn_Click(object sender, EventArgs e)
        {
            userBAL.Detail(DGV, tableName);
        }

        private void paybtn_Click(object sender, EventArgs e)
        {
            Billing fom = new Billing(tableName, email);
            fom.Show();
            this.Close();
        }
    }
}

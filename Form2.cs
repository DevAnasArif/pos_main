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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace pos_main
{
    public partial class Form2 : Form
    {
        public string receivetext { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string receivetext)
        {
            InitializeComponent();
            this.receivetext = receivetext;
        }
        public void Update(string Ordername, int Quanity, int Price)
        {
            string updateorderName = Ordername;
            int updatequantity = Quanity;
            int updateprice = Price;
            int updatetotal = updatequantity * updateprice;
            string mysqlconn = "server=127.0.0.1; user=root; database=anasarif; password=";
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            conn.Open();
            string query = "UPDATE `order` SET Quantity = Quantity + '" + updatequantity + "', Total = Total + '" + updatetotal + "' WHERE Ordername = '" + updateorderName + "';";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void conection(string Ordername, int Quanity, int Price)
        {
            string orderName = Ordername;
            int quantity = Quanity;
            int price = Price;
            int total = quantity * price;
            string mysqlconn = "server=127.0.0.1; user=root; database=anasarif; password=";
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            conn.Open();
            string query = "INSERT INTO `order` (`Ordername`, `Quantity`, `Price`, `Total`) VALUES ('" + orderName + "', '" + quantity + "', '" + price + "', '" + total + "')";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        private int quanmain1 = 0;
        private void slanty2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sltext2.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(sltext2.Text);
                    int currentQuantity = quanmain1;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain1 = quantity;
                            conection("slanty(vegetable)", quantity, 50);
                        }
                        else
                        {
                            quanmain1 += quantity;
                            Update("slanty(vegetable)", quantity, 50);
                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain2 = 0;
        private void slanty1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sltext1.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(sltext1.Text);
                    int currentQuantity = quanmain2;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain2 = quantity;
                            conection("slanty(salt)", quantity, 50);
                        }
                        else
                        {
                            quanmain2 += quantity;
                            Update("slanty(salt)", quantity, 50);
                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain3 = 0;
        private void slanty3_Click(object sender, EventArgs e)
        {
            try
            {

                if (sltext3.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(sltext3.Text);
                    int currentQuantity = quanmain3;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain3 = quantity;
                            conection("slanty(jalapeno)", quantity, 50);
                        }
                        else
                        {
                            quanmain3 += quantity;
                            Update("slanty(jalapeno)", quantity, 50);
                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain4 = 0;
        private void cheetosbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cheetostext.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(cheetostext.Text);
                    int currentQuantity = quanmain4;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain4 = quantity;
                            conection("cheetos", quantity, 50);
                        }
                        else
                        {
                            quanmain4 += quantity;
                            Update("cheetos", quantity, 50);
                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain5 = 0;
        private void kukurebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (kurkuretext.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(kurkuretext.Text);
                    int currentQuantity = quanmain5;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain5 = quantity;
                            conection("kurkure", quantity, 20);
                        }
                        else
                        {
                            quanmain5 += quantity;
                            Update("kurkure", quantity, 20);
                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain6 = 0;
        private void slice1btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (slicetext.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(slicetext.Text);
                    int currentQuantity = quanmain6;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain6 = quantity;
                            conection("Slice Juice 1 L", quantity, 152);
                        }
                        else
                        {
                            quanmain6 += quantity;
                            Update("Slice Juice 1 L", quantity, 152);
                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain7 = 0;
        private void cocacolabtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cocacolatext.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(cocacolatext.Text);
                    int currentQuantity = quanmain7;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain7 = quantity;
                            conection("cola next 1.5 L", quantity, 115);
                        }
                        else
                        {

                            quanmain7 += quantity;
                            Update("cola next 1.5 L", quantity, 115);
                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain8 = 0;
        private void pakolabtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (pakolatext.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(pakolatext.Text);
                    int currentQuantity = quanmain8;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain8 = quantity;
                            conection("pakola 2.25 L", quantity, 170);
                        }
                        else
                        {

                            quanmain8 += quantity;
                            Update("pakola 2.25 L", quantity, 170);

                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain9 = 0;
        private void fizupbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (fizzuptext.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(fizzuptext.Text);
                    int currentQuantity = quanmain9;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain9 = quantity;
                            conection("fizup 345ml", quantity, 46);
                        }
                        else
                        {
                            quanmain9 += quantity;
                            Update("fizup 345ml", quantity, 46);


                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain10 = 0;
        private void pakolabtn1_Click(object sender, EventArgs e)
        {
            try
            {
                if (pakola2text.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(pakola2text.Text);
                    int currentQuantity = quanmain10;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain10 = quantity;
                            conection("pakola 500ml", quantity, 50);
                        }
                        else
                        {
                            quanmain10 += quantity;
                            Update("pakola 500ml", quantity, 50);


                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain11 = 0;
        private void slicebtn1_Click(object sender, EventArgs e)
        {
            try
            {
                if (slice1text.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(slice1text.Text);
                    int currentQuantity = quanmain11;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain11 = quantity;
                            conection("Slice 200ml", quantity, 42);
                        }
                        else
                        {
                            quanmain11 += quantity;
                            Update("Slice 200ml", quantity, 42);


                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain12 = 0;
        private void redbullbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (redbulltext.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(redbulltext.Text);
                    int currentQuantity = quanmain12;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain12 = quantity;
                            conection("red bull 250ml", quantity, 415);
                        }
                        else
                        {
                            quanmain12 += quantity;
                            Update("red bull 250ml", quantity, 415);

                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain13 = 0;
        private void marindadbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (marindatext.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(marindatext.Text);
                    int currentQuantity = quanmain13;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain13 = quantity;
                            conection("marinda 250ml", quantity, 70);
                        }
                        else
                        {
                            quanmain13 += quantity;
                            Update("marinda 250ml", quantity, 70);

                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain14 = 0;
        private void colanext2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cocacola1text.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(cocacola1text.Text);
                    int currentQuantity = quanmain14;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain14 = quantity;
                            conection("cola next 250ml", quantity, 90);

                        }
                        else
                        {
                            quanmain14 += quantity;
                            Update("cola next 250ml", quantity, 90);
                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain15 = 0;
        private void fizzupbtn2_Click(object sender, EventArgs e)
        {
            try
            {
                if (fizup1text.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {

                    int quantity = int.Parse(fizup1text.Text);
                    int currentQuantity = quanmain15;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain15 = quantity;
                            conection("fizup 250ml", quantity, 90);

                        }
                        else
                        {
                            quanmain15 += quantity;
                            Update("fizup 250ml", quantity, 90);
                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain16 = 0;
        private void novitabtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (novitatext.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(novitatext.Text);
                    int currentQuantity = quanmain16;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain16 = quantity;
                            conection("novita wafers", quantity, 50);

                        }
                        else
                        {
                            quanmain16 += quantity;
                            Update("novita wafers", quantity, 50);
                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain17 = 0;
        private void flobtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (flotext.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(flotext.Text);
                    int currentQuantity = quanmain17;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain17 = quantity;
                            conection("flo cake", quantity, 10);
                        }
                        else
                        {
                            quanmain17 += quantity;
                            Update("flo cake", quantity, 10);

                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain18 = 0;
        private void choclotobtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (chocaltotext.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(chocaltotext.Text);
                    int currentQuantity = quanmain18;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain18 = quantity;
                            conection("chocalatto biscuit", quantity, 10);
                        }
                        else
                        {
                            quanmain18 += quantity;
                            Update("chocalatto biscuit", quantity, 10);

                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain19 = 0;
        private void goodgoodiesbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (goodgoodiestext.Text == "")
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(goodgoodiestext.Text);
                    int currentQuantity = quanmain19;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain19 = quantity;
                            conection("good goodies", quantity, 10);
                        }
                        else
                        {
                            quanmain19 += quantity;
                            Update("good goodies", quantity, 10);

                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        private int quanmain20 = 0;
        private void kitkatbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(kitkattext.Text))
                {
                    MessageBox.Show("Fill The Quantity");
                }
                else
                {
                    int quantity = int.Parse(kitkattext.Text);
                    int currentQuantity = quanmain20;

                    if (currentQuantity + quantity > 100)
                    {
                        MessageBox.Show("Out Of Stock & Will Available soon");
                    }
                    else
                    {
                        if (currentQuantity == 0)
                        {
                            quanmain20 = quantity;
                            conection("kitkat 41.5gm", quantity, 150);
                        }
                        else
                        {
                            quanmain20 += quantity;
                            Update("kitkat 41.5gm", quantity, 150);

                        }
                        random();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        public void random()
        {
            string mysqlconn = "server=127.0.0.1; user=root; database=anasarif; password=";
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            conn.Open();
            string query = "Select Ordername,Price,Quantity from `order`";
            MySqlDataAdapter command = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            command.Fill(dt);
            DGV.DataSource = dt;
            conn.Close();
        }
        private void button21_Click(object sender, EventArgs e)
        {
            random();
        }
        public string location { get; set; }
        private void button22_Click(object sender, EventArgs e)
        {
            Form4 fom = new Form4(receivetext);
            fom.Show();
            this.Close();
        }
    }
}

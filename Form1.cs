using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Org.BouncyCastle.Asn1.X509;
using pos_main.BAL;

namespace pos_main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public string recievettext { get; set; }
        public string user { get; set; }
        private string pass { get; set; }

        private void login_Click_1(object sender, EventArgs e)
        {
            user = usertext.Text.ToString();
            pass = passtext.Text.ToString();
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("No Empty Space Is Allowed");
            }
            else
            {
                UserBAL userBAL = new UserBAL();
                DataTable userTable = userBAL.UserLogin(user, pass);

                if (userTable.Rows.Count > 0)
                {
                    Form2 form = new Form2();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password!");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 anform = new Form3();
            anform.Show();
        }
    }
}

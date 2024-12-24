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
using pos_main.view;

namespace pos_main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string email { get; set; }
        private string pass { get; set; }

        private void login_Click_1(object sender, EventArgs e)
        {
            email = emailtext.Text.ToString();
            pass = passtext.Text.ToString();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("No Empty Space Is Allowed");
            }
            else
            {
                UserBAL userBAL = new UserBAL();

                string status = userBAL.UserLogin(email, pass);
                try
                {
                    if (status != null)
                    {
                        string Tablename = userBAL.UserDetail(email, pass);
                        if (status == "UnVerified")
                        {
                            MessageBox.Show($"User exists with status: UnVerified");
                        }
                        else if (status == "Verified")
                        {
                            Product pro = new Product(Tablename,email);
                            pro.Show();

                        }
                        else if (status=="Admin")
                        {
                            Admin admin = new Admin();
                            admin.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("User does not exist or incorrect credentials.");
                    }
                }
                catch(FormatException ex)
                {
                    MessageBox.Show("ERROR ACCURED "+ex);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup anform = new Signup();
            anform.Show();
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using pos_main.BAL;

namespace pos_main
{
    public partial class Form3 : Form
    {
        public Form3()
        {
         InitializeComponent(); 
        }


        public string username { get; set; }
        public string name { get; set; }
        private string password;
        private string cnpassword;


        private void register_Click(object sender, EventArgs e)
        {
            name = fullnametext.Text.ToString();
            username = usertext.Text.ToString();
            password = passtext.Text.ToString();
            cnpassword = cnpasstext.Text.ToString();
            if (cnpassword != password)
            {
                MessageBox.Show("Passwords do not match.");
            }
            else
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(cnpassword) || string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("No empty fields are allowed.");
                }
                else
                {
                    UserBAL userBAL = new UserBAL();
                    bool userT = userBAL.SignUp(username, name, password);

                    if (userT)
                    {
                        Form2 form = new Form2(username);
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sign-up failed or user already exists!");
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Initialization code, if needed
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using pos_main.BAL;

namespace pos_main
{
    public partial class Signup : Form
    {
        public Signup()
        {
         InitializeComponent(); 
        }


        public string username { get; set; }
        public string email { get; set; }
        private string password;
        private string cnpassword;

        private void register_Click(object sender, EventArgs e)
        {
            username = fullnametext.Text.ToString();
            email = emailtext.Text.ToString();
            password = passtext.Text.ToString();
            cnpassword = cnpasstext.Text.ToString();
            if (cnpassword != password)
            {
                MessageBox.Show("Passwords do not match.");
            }
            else
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(cnpassword) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("No empty fields are allowed.");
                }
                else
                {
                    UserBAL userBAL = new UserBAL();
                    int ordernumber=userBAL.Ordercheck();
                    int newordernumber = ordernumber+1;
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    string tableName = Convert.ToString("order-" + currentDate +"-"+ newordernumber);
                    bool userT = userBAL.SignUp(username, email, password,tableName,newordernumber);
                    if (userT)
                    {
                        userBAL.NewUser(tableName);
                        /*Form1 form = new Form1();*/
                        /*form.Show();*/
                        MessageBox.Show("Your Request has been send to the Admin");
                        this.Close();
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

    }
}

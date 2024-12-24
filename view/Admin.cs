using MySql.Data.MySqlClient;
using pos_main.BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pos_main.view
{
    public partial class Admin : Form
    {
        int index;
         UserBAL userBAL = new UserBAL();
        public Admin()
        {
            InitializeComponent();
            userBAL.admintable(AdminGV);
        }

        private void AdminGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            totalno.Text = "00";
            index = e.RowIndex;
            DataGridViewRow row = AdminGV.Rows[index];
            idtextbox.Text = row.Cells[0].Value.ToString();
            Usernametbx.Text = row.Cells[1].Value.ToString();
            Emailtbx.Text = row.Cells[2].Value.ToString();
            Status.Text = row.Cells[10].Value.ToString();
            ordertext.Text = row.Cells[11].Value.ToString();
        }


        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                totalno.Text = "00";
                if (string.IsNullOrEmpty(idtextbox.Text) || string.IsNullOrEmpty(ordertext.Text) || string.IsNullOrEmpty(Usernametbx.Text) || string.IsNullOrEmpty(Emailtbx.Text)|| string.IsNullOrEmpty(Status.Text))
                {
                    MessageBox.Show("Fill The Details");
                }
                else
                {
                    userBAL.admintable(AdminGV);
                    DataGridViewRow row = AdminGV.Rows[index];
                    row.Cells[0].Value = idtextbox.Text;
                    row.Cells[1].Value = Usernametbx.Text;
                    row.Cells[2].Value = Emailtbx.Text;
                    row.Cells[10].Value = Status.Text;
                    row.Cells[11].Value = ordertext.Text;
                    int id = Convert.ToInt32(idtextbox.Text);
                    string username = Convert.ToString(Usernametbx.Text);
                    string email = Convert.ToString(Emailtbx.Text);
                    string status = Convert.ToString(Status.Text);
                    string ordernumber = Convert.ToString(ordertext.Text);
                    userBAL.AdminUpdate(id, username, email, status);
                    MessageBox.Show("Updated Successfully");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("ERROR ACCOURED " + ex);
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            totalno.Text = "00";
            if (Usernametbx.Text=="Admin")
            {
                MessageBox.Show("Admin cannot be Deleted");
            }
            else if (string.IsNullOrEmpty(idtextbox.Text) || string.IsNullOrEmpty(Usernametbx.Text) || string.IsNullOrEmpty(Emailtbx.Text) || string.IsNullOrEmpty(Status.Text))
            {
                MessageBox.Show("Fill the Details");
            }
            else
            {
                DataGridViewRow row = AdminGV.Rows[index];
                idtextbox.Text = row.Cells[0].Value.ToString();
                int id = Convert.ToInt32(idtextbox.Text);
                string ordernumber = Convert.ToString(ordertext.Text);
                userBAL.DeleteRow(id, ordernumber);
                index = AdminGV.CurrentCell.RowIndex;
                AdminGV.Rows.RemoveAt(index);
                idtextbox.Text = String.Empty;
                Usernametbx.Text = String.Empty;
                Emailtbx.Text = String.Empty;
                Status.Text = String.Empty;
                ordertext.Text = String.Empty;
            }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {


            double total =0;
            double totalmain;
            totalno.Text = "00";
            string ordernumber = Convert.ToString(ordertext.Text);
            if (string.IsNullOrEmpty(ordertext.Text))
            {
                MessageBox.Show("Admin has no OrderNumber");
            }
            else if (!(string.IsNullOrEmpty(ordertext.Text)))
            {
                bool userT=userBAL.ShowingData(AdminGV, ordernumber);
                if (userT)
                {
                    totalmain = userBAL.total(total, AdminGV, totalno);
                }
            }
        }
        
        private void userbtn_Click(object sender, EventArgs e)
        {
            userBAL.admintable(AdminGV);
            totalno.Text= "00.00";
            totalno.Text = "00";
        }

        private void datewisebtn_Click(object sender, EventArgs e)
        {
            int recordCount = userBAL.tablesearch(AdminGV, dtFromDate.Value, dtToDate.Value);
            recordcount.Text = $"{recordCount}";
        }
    }
}


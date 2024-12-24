using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace pos_main.view
{

    public partial class Showinginterface : Form
    {
        // Default constructor loads Form1
        public Showinginterface()
        {
            InitializeComponent();
            loadform(new Form1()); // Loads Form1 by default
        }

        // Overloaded constructor accepts a form object to load
        public Showinginterface(object formToLoad)
        {
            InitializeComponent();
            loadform(formToLoad); // Loads the form passed as a parameter
        }

        // Method to load a form into the panel
        public void loadform(object formToLoad)
        {
            if (formToLoad == null)
            {
                MessageBox.Show("Form object cannot be null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form frm = formToLoad as Form;
            if (frm != null) // Check if the object is a valid Form
            {
                if (panelbody == null)
                {
                    MessageBox.Show("Panel is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                panelbody.Controls.Clear(); // Clear existing controls
                frm.TopLevel = false; // Make the form a non-top-level form
                frm.Dock = DockStyle.Fill; // Dock the form to fill the panel
                panelbody.Controls.Add(frm); // Add the form to the panel
                frm.BringToFront(); // Bring the form to the front
                frm.Show(); // Show the form
            }
            else
            {
                MessageBox.Show("Invalid form type. Please pass a valid form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            loadform(new Form1());
        }

        private void signupbtn_Click(object sender, EventArgs e)
        {
            loadform(new Signup());

        }

        private void productbtn_Click(object sender, EventArgs e)
        {
            loadform(new Product());

        }

        private void billingbtn_Click(object sender, EventArgs e)
        {
            loadform(new Billing());

        }
    }
}
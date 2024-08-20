namespace pos_main.view
{
    partial class Showinginterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelcontainer = new System.Windows.Forms.Panel();
            this.loginbtn = new Guna.UI2.WinForms.Guna2Button();
            this.billingbtn = new Guna.UI2.WinForms.Guna2Button();
            this.signupbtn = new Guna.UI2.WinForms.Guna2Button();
            this.productbtn = new Guna.UI2.WinForms.Guna2Button();
            this.panelbody = new System.Windows.Forms.Panel();
            this.header.SuspendLayout();
            this.panelcontainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.Green;
            this.header.Controls.Add(this.label1);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1456, 78);
            this.header.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(540, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 58);
            this.label1.TabIndex = 1;
            this.label1.Text = "POS System";
            // 
            // panelcontainer
            // 
            this.panelcontainer.BackColor = System.Drawing.Color.White;
            this.panelcontainer.Controls.Add(this.loginbtn);
            this.panelcontainer.Controls.Add(this.billingbtn);
            this.panelcontainer.Controls.Add(this.signupbtn);
            this.panelcontainer.Controls.Add(this.productbtn);
            this.panelcontainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelcontainer.Location = new System.Drawing.Point(0, 78);
            this.panelcontainer.Name = "panelcontainer";
            this.panelcontainer.Size = new System.Drawing.Size(1456, 51);
            this.panelcontainer.TabIndex = 1;
            // 
            // loginbtn
            // 
            this.loginbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.loginbtn.Checked = true;
            this.loginbtn.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.loginbtn.CheckedState.CustomBorderColor = System.Drawing.Color.Lime;
            this.loginbtn.CheckedState.FillColor = System.Drawing.Color.White;
            this.loginbtn.CustomBorderColor = System.Drawing.Color.White;
            this.loginbtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.loginbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.loginbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.loginbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.loginbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.loginbtn.FillColor = System.Drawing.Color.White;
            this.loginbtn.Font = new System.Drawing.Font("Britannic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbtn.ForeColor = System.Drawing.Color.Black;
            this.loginbtn.HoverState.CustomBorderColor = System.Drawing.Color.Lime;
            this.loginbtn.IndicateFocus = true;
            this.loginbtn.Location = new System.Drawing.Point(12, 2);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(180, 45);
            this.loginbtn.TabIndex = 3;
            this.loginbtn.Text = "Login";
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // billingbtn
            // 
            this.billingbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.billingbtn.CheckedState.CustomBorderColor = System.Drawing.Color.Lime;
            this.billingbtn.CheckedState.FillColor = System.Drawing.Color.White;
            this.billingbtn.CustomBorderColor = System.Drawing.Color.White;
            this.billingbtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.billingbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.billingbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.billingbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.billingbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.billingbtn.FillColor = System.Drawing.Color.White;
            this.billingbtn.Font = new System.Drawing.Font("Britannic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billingbtn.ForeColor = System.Drawing.Color.Black;
            this.billingbtn.HoverState.CustomBorderColor = System.Drawing.Color.Lime;
            this.billingbtn.IndicateFocus = true;
            this.billingbtn.Location = new System.Drawing.Point(570, 1);
            this.billingbtn.Name = "billingbtn";
            this.billingbtn.Size = new System.Drawing.Size(180, 45);
            this.billingbtn.TabIndex = 3;
            this.billingbtn.Text = "Billing";
            this.billingbtn.Click += new System.EventHandler(this.billingbtn_Click);
            // 
            // signupbtn
            // 
            this.signupbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.signupbtn.CheckedState.CustomBorderColor = System.Drawing.Color.Lime;
            this.signupbtn.CheckedState.FillColor = System.Drawing.Color.White;
            this.signupbtn.CustomBorderColor = System.Drawing.Color.White;
            this.signupbtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.signupbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.signupbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.signupbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.signupbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.signupbtn.FillColor = System.Drawing.Color.White;
            this.signupbtn.Font = new System.Drawing.Font("Britannic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupbtn.ForeColor = System.Drawing.Color.Black;
            this.signupbtn.HoverState.CustomBorderColor = System.Drawing.Color.Lime;
            this.signupbtn.IndicateFocus = true;
            this.signupbtn.Location = new System.Drawing.Point(198, 2);
            this.signupbtn.Name = "signupbtn";
            this.signupbtn.Size = new System.Drawing.Size(180, 45);
            this.signupbtn.TabIndex = 3;
            this.signupbtn.Text = "Signup";
            this.signupbtn.Click += new System.EventHandler(this.signupbtn_Click);
            // 
            // productbtn
            // 
            this.productbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.productbtn.CheckedState.CustomBorderColor = System.Drawing.Color.Lime;
            this.productbtn.CheckedState.FillColor = System.Drawing.Color.White;
            this.productbtn.CustomBorderColor = System.Drawing.Color.White;
            this.productbtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.productbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.productbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.productbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.productbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.productbtn.FillColor = System.Drawing.Color.White;
            this.productbtn.Font = new System.Drawing.Font("Britannic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productbtn.ForeColor = System.Drawing.Color.Black;
            this.productbtn.HoverState.CustomBorderColor = System.Drawing.Color.Lime;
            this.productbtn.IndicateFocus = true;
            this.productbtn.Location = new System.Drawing.Point(384, 1);
            this.productbtn.Name = "productbtn";
            this.productbtn.Size = new System.Drawing.Size(180, 45);
            this.productbtn.TabIndex = 3;
            this.productbtn.Text = "Product";
            this.productbtn.Click += new System.EventHandler(this.productbtn_Click);
            // 
            // panelbody
            // 
            this.panelbody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbody.Location = new System.Drawing.Point(0, 129);
            this.panelbody.Name = "panelbody";
            this.panelbody.Size = new System.Drawing.Size(1456, 685);
            this.panelbody.TabIndex = 2;
            // 
            // Showinginterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 814);
            this.Controls.Add(this.panelbody);
            this.Controls.Add(this.panelcontainer);
            this.Controls.Add(this.header);
            this.Name = "Showinginterface";
            this.Text = "Showinginterface";
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.panelcontainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelcontainer;
        private Guna.UI2.WinForms.Guna2Button loginbtn;
        private Guna.UI2.WinForms.Guna2Button signupbtn;
        private Guna.UI2.WinForms.Guna2Button productbtn;
        private Guna.UI2.WinForms.Guna2Button billingbtn;
        private System.Windows.Forms.Panel panelbody;
    }
}
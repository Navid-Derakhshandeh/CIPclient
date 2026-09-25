namespace CIPclient
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnlogin = new Button();
            btnsignup = new Button();
            label1 = new Label();
            label2 = new Label();
            txtuser = new TextBox();
            txtpass = new TextBox();
            SuspendLayout();
            // 
            // btnlogin
            // 
            btnlogin.Location = new Point(315, 219);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(75, 23);
            btnlogin.TabIndex = 0;
            btnlogin.Text = "Login";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnlogin_Click;
            // 
            // btnsignup
            // 
            btnsignup.Location = new Point(416, 219);
            btnsignup.Name = "btnsignup";
            btnsignup.Size = new Size(75, 23);
            btnsignup.TabIndex = 1;
            btnsignup.Text = "Signup";
            btnsignup.UseVisualStyleBackColor = true;
            btnsignup.Click += btnsignup_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(248, 136);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(248, 177);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // txtuser
            // 
            txtuser.Location = new Point(317, 133);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(174, 23);
            txtuser.TabIndex = 4;
            // 
            // txtpass
            // 
            txtpass.Location = new Point(315, 174);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(176, 23);
            txtpass.TabIndex = 5;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtpass);
            Controls.Add(txtuser);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnsignup);
            Controls.Add(btnlogin);
            Name = "Main";
            Text = "Form1";
            Load += Main_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnlogin;
        private Button btnsignup;
        private Label label1;
        private Label label2;
        private TextBox txtuser;
        private TextBox txtpass;
    }
}

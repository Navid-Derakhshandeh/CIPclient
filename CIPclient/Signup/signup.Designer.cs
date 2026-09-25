namespace CIPclient
{
    partial class signup
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
            btnregister = new Button();
            txtuser = new TextBox();
            txtpass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnregister
            // 
            btnregister.Location = new Point(365, 225);
            btnregister.Name = "btnregister";
            btnregister.Size = new Size(75, 23);
            btnregister.TabIndex = 0;
            btnregister.Text = "Register";
            btnregister.UseVisualStyleBackColor = true;
            btnregister.Click += btnregister_Click;
            // 
            // txtuser
            // 
            txtuser.Location = new Point(329, 167);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(146, 23);
            txtuser.TabIndex = 1;
            // 
            // txtpass
            // 
            txtpass.Location = new Point(329, 196);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(146, 23);
            txtpass.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(260, 170);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 3;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(263, 199);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Password:";
            // 
            // signup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtpass);
            Controls.Add(txtuser);
            Controls.Add(btnregister);
            Name = "signup";
            Text = "signup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnregister;
        private TextBox txtuser;
        private TextBox txtpass;
        private Label label1;
        private Label label2;
    }
}
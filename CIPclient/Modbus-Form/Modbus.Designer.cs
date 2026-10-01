namespace CIPclient
{
    partial class Modbus
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
            txtinput = new TextBox();
            label1 = new Label();
            btnsend = new Button();
            listoutput = new ListBox();
            SuspendLayout();
            // 
            // txtinput
            // 
            txtinput.Location = new Point(378, 80);
            txtinput.Name = "txtinput";
            txtinput.Size = new Size(120, 23);
            txtinput.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(329, 83);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "value:";
            // 
            // btnsend
            // 
            btnsend.Location = new Point(400, 109);
            btnsend.Name = "btnsend";
            btnsend.Size = new Size(75, 23);
            btnsend.TabIndex = 2;
            btnsend.Text = "Send";
            btnsend.UseVisualStyleBackColor = true;
            btnsend.Click += btnsend_Click;
            // 
            // listoutput
            // 
            listoutput.FormattingEnabled = true;
            listoutput.ItemHeight = 15;
            listoutput.Location = new Point(378, 138);
            listoutput.Name = "listoutput";
            listoutput.Size = new Size(120, 94);
            listoutput.TabIndex = 3;
            // 
            // Modbus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listoutput);
            Controls.Add(btnsend);
            Controls.Add(label1);
            Controls.Add(txtinput);
            Name = "Modbus";
            Text = "Modbus";
            Load += Modbus_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtinput;
        private Label label1;
        private Button btnsend;
        private ListBox listoutput;
    }
}
namespace DataTimeServerUDP
{
    partial class Form1
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
            lblTime = new Label();
            btnDisconnect = new Button();
            btnConnect = new Button();
            txtServerIp = new TextBox();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 35F);
            lblTime.Location = new Point(197, 145);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(161, 62);
            lblTime.TabIndex = 0;
            lblTime.Text = "--:--:--";
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(411, 70);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(172, 23);
            btnDisconnect.TabIndex = 1;
            btnDisconnect.Text = "Відєднатися від сервера";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 70);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(159, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Підключитися до сервера";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtServerIp
            // 
            txtServerIp.Location = new Point(177, 71);
            txtServerIp.Name = "txtServerIp";
            txtServerIp.Size = new Size(219, 23);
            txtServerIp.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 270);
            Controls.Add(txtServerIp);
            Controls.Add(btnConnect);
            Controls.Add(btnDisconnect);
            Controls.Add(lblTime);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTime;
        private Button btnDisconnect;
        private Button btnConnect;
        private TextBox txtServerIp;
    }
}

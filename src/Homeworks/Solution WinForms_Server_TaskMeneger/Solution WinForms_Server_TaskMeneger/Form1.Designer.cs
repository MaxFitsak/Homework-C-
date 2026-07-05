namespace Solution_WinForms_Server_TaskMeneger
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
            listBoxProcesses = new ListBox();
            txtProcessPath = new TextBox();
            btnConnect = new Button();
            btnKillProcess = new Button();
            btnCreateProcess = new Button();
            btnGetProcesses = new Button();
            txtIpAddress = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // listBoxProcesses
            // 
            listBoxProcesses.FormattingEnabled = true;
            listBoxProcesses.Location = new Point(12, 110);
            listBoxProcesses.Name = "listBoxProcesses";
            listBoxProcesses.Size = new Size(317, 289);
            listBoxProcesses.TabIndex = 0;
            // 
            // txtProcessPath
            // 
            txtProcessPath.Location = new Point(12, 406);
            txtProcessPath.Name = "txtProcessPath";
            txtProcessPath.Size = new Size(196, 23);
            txtProcessPath.TabIndex = 1;
            txtProcessPath.TextChanged += textBox1_TextChanged;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(195, 36);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(114, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "contect to server";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnKillProcess
            // 
            btnKillProcess.Location = new Point(195, 81);
            btnKillProcess.Name = "btnKillProcess";
            btnKillProcess.Size = new Size(131, 23);
            btnKillProcess.TabIndex = 3;
            btnKillProcess.Text = "Kill process";
            btnKillProcess.UseVisualStyleBackColor = true;
            btnKillProcess.Click += btnKillProcess_Click;
            // 
            // btnCreateProcess
            // 
            btnCreateProcess.Location = new Point(214, 406);
            btnCreateProcess.Name = "btnCreateProcess";
            btnCreateProcess.Size = new Size(112, 23);
            btnCreateProcess.TabIndex = 5;
            btnCreateProcess.Text = "New Process";
            btnCreateProcess.UseVisualStyleBackColor = true;
            btnCreateProcess.Click += btnCreateProcess_Click;
            // 
            // btnGetProcesses
            // 
            btnGetProcesses.Location = new Point(12, 81);
            btnGetProcesses.Name = "btnGetProcesses";
            btnGetProcesses.Size = new Size(117, 23);
            btnGetProcesses.TabIndex = 6;
            btnGetProcesses.Text = "Take list processes";
            btnGetProcesses.UseVisualStyleBackColor = true;
            btnGetProcesses.Click += btnGetProcesses_Click;
            // 
            // txtIpAddress
            // 
            txtIpAddress.Location = new Point(12, 36);
            txtIpAddress.Name = "txtIpAddress";
            txtIpAddress.Size = new Size(128, 23);
            txtIpAddress.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 8;
            label1.Text = "ip adress :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 441);
            Controls.Add(label1);
            Controls.Add(txtIpAddress);
            Controls.Add(btnGetProcesses);
            Controls.Add(btnCreateProcess);
            Controls.Add(btnKillProcess);
            Controls.Add(btnConnect);
            Controls.Add(txtProcessPath);
            Controls.Add(listBoxProcesses);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxProcesses;
        private TextBox textBox1;
        private Button btnConnect;
        private Button btnKillProcess;
        private Button btnCreateProcess;
        private Button btnGetProcesses;
        private TextBox txtIpAddress;
        private Label label1;
        private TextBox txtProcessPath;
    }
}

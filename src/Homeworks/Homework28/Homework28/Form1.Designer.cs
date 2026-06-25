namespace Homework28
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
            progressBar1 = new ProgressBar();
            chkStart1 = new CheckBox();
            progressBar3 = new ProgressBar();
            progressBar2 = new ProgressBar();
            chkPause1 = new CheckBox();
            chkStart2 = new CheckBox();
            chkPause2 = new CheckBox();
            chkStart3 = new CheckBox();
            chkPause3 = new CheckBox();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 12);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(421, 43);
            progressBar1.TabIndex = 0;
            // 
            // chkStart1
            // 
            chkStart1.AutoSize = true;
            chkStart1.Location = new Point(12, 61);
            chkStart1.Name = "chkStart1";
            chkStart1.Size = new Size(131, 19);
            chkStart1.TabIndex = 3;
            chkStart1.Text = "Запустити процесс";
            chkStart1.UseVisualStyleBackColor = true;
            chkStart1.CheckedChanged += chkStart_CheckedChanged;
            // 
            // progressBar3
            // 
            progressBar3.Location = new Point(12, 160);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(421, 43);
            progressBar3.TabIndex = 4;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(12, 86);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(421, 43);
            progressBar2.TabIndex = 5;
            // 
            // chkPause1
            // 
            chkPause1.AutoSize = true;
            chkPause1.Location = new Point(351, 61);
            chkPause1.Name = "chkPause1";
            chkPause1.Size = new Size(100, 19);
            chkPause1.TabIndex = 6;
            chkPause1.Text = "Призупинити";
            chkPause1.UseVisualStyleBackColor = true;
            chkPause1.CheckedChanged += chkPause_CheckedChanged;
            // 
            // chkStart2
            // 
            chkStart2.AutoSize = true;
            chkStart2.Location = new Point(12, 135);
            chkStart2.Name = "chkStart2";
            chkStart2.Size = new Size(131, 19);
            chkStart2.TabIndex = 7;
            chkStart2.Text = "Запустити процесс";
            chkStart2.UseVisualStyleBackColor = true;
            chkStart2.CheckedChanged += chkStart_CheckedChanged;
            // 
            // chkPause2
            // 
            chkPause2.AutoSize = true;
            chkPause2.Location = new Point(351, 135);
            chkPause2.Name = "chkPause2";
            chkPause2.Size = new Size(100, 19);
            chkPause2.TabIndex = 8;
            chkPause2.Text = "Призупинити";
            chkPause2.UseVisualStyleBackColor = true;
            chkPause2.CheckedChanged += chkPause_CheckedChanged;
            // 
            // chkStart3
            // 
            chkStart3.AutoSize = true;
            chkStart3.Location = new Point(12, 209);
            chkStart3.Name = "chkStart3";
            chkStart3.Size = new Size(131, 19);
            chkStart3.TabIndex = 9;
            chkStart3.Text = "Запустити процесс";
            chkStart3.UseVisualStyleBackColor = true;
            chkStart3.CheckedChanged += chkStart_CheckedChanged;
            // 
            // chkPause3
            // 
            chkPause3.AutoSize = true;
            chkPause3.Location = new Point(351, 209);
            chkPause3.Name = "chkPause3";
            chkPause3.Size = new Size(100, 19);
            chkPause3.TabIndex = 10;
            chkPause3.Text = "Призупинити";
            chkPause3.UseVisualStyleBackColor = true;
            chkPause3.CheckedChanged += chkPause_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 238);
            Controls.Add(chkPause3);
            Controls.Add(chkStart3);
            Controls.Add(chkPause2);
            Controls.Add(chkStart2);
            Controls.Add(chkPause1);
            Controls.Add(progressBar2);
            Controls.Add(progressBar3);
            Controls.Add(chkStart1);
            Controls.Add(progressBar1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Прогрез бари";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private CheckBox chkStart1;
        private ProgressBar progressBar3;
        private ProgressBar progressBar2;
        private CheckBox chkPause1;
        private CheckBox chkStart2;
        private CheckBox chkPause2;
        private CheckBox chkStart3;
        private CheckBox chkPause3;
    }
}

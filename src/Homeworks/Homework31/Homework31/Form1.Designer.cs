namespace Homework31
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
            button1 = new Button();
            label1 = new Label();
            rbEncrypt = new RadioButton();
            rbDecrypt = new RadioButton();
            button2 = new Button();
            button3 = new Button();
            txtFilePath = new TextBox();
            txtKey = new TextBox();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(38, 156);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(581, 23);
            progressBar1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(38, 66);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Файл...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 130);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 2;
            label1.Text = "Ключ:";
            // 
            // rbEncrypt
            // 
            rbEncrypt.AutoSize = true;
            rbEncrypt.Location = new Point(375, 131);
            rbEncrypt.Name = "rbEncrypt";
            rbEncrypt.Size = new Size(97, 19);
            rbEncrypt.TabIndex = 3;
            rbEncrypt.TabStop = true;
            rbEncrypt.Text = "Шифрування";
            rbEncrypt.UseVisualStyleBackColor = true;
            rbEncrypt.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // rbDecrypt
            // 
            rbDecrypt.AutoSize = true;
            rbDecrypt.Location = new Point(490, 131);
            rbDecrypt.Name = "rbDecrypt";
            rbDecrypt.Size = new Size(116, 19);
            rbDecrypt.TabIndex = 4;
            rbDecrypt.TabStop = true;
            rbDecrypt.Text = "Розшифрування";
            rbDecrypt.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(441, 185);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Пуск";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(531, 185);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 6;
            button3.Text = "Скасувати";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(133, 66);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(473, 23);
            txtFilePath.TabIndex = 7;
            // 
            // txtKey
            // 
            txtKey.Location = new Point(133, 127);
            txtKey.Name = "txtKey";
            txtKey.PasswordChar = '*';
            txtKey.Size = new Size(100, 23);
            txtKey.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 214);
            Controls.Add(txtKey);
            Controls.Add(txtFilePath);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(rbDecrypt);
            Controls.Add(rbEncrypt);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Name = "Form1";
            Text = "Алгоритим шифрування XOR ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Button button1;
        private Label label1;
        private RadioButton rbEncrypt;
        private RadioButton rbDecrypt;
        private Button button2;
        private Button button3;
        private TextBox txtFilePath;
        private TextBox txtKey;
    }
}

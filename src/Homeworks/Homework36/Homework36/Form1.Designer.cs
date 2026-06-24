namespace Homework36
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            txtProcessPath = new TextBox();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(205, 25);
            button1.Name = "button1";
            button1.Size = new Size(150, 23);
            button1.TabIndex = 0;
            button1.Text = "Видалити процесс";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnKill_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 25);
            button2.Name = "button2";
            button2.Size = new Size(151, 23);
            button2.TabIndex = 1;
            button2.Text = "Обновити список";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnRefresh_Click;
            // 
            // button3
            // 
            button3.Location = new Point(224, 415);
            button3.Name = "button3";
            button3.Size = new Size(131, 23);
            button3.TabIndex = 2;
            button3.Text = "Запустити процесс";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnStart_Click;
            // 
            // txtProcessPath
            // 
            txtProcessPath.Location = new Point(12, 415);
            txtProcessPath.Name = "txtProcessPath";
            txtProcessPath.Size = new Size(206, 23);
            txtProcessPath.TabIndex = 3;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 60);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(343, 349);
            listBox1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 450);
            Controls.Add(listBox1);
            Controls.Add(txtProcessPath);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Диспечер процесів";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox txtProcessPath;
        private ListBox listBox1;
    }
}

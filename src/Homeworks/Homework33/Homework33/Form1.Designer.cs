namespace Homework33
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnCreate = new Button();
            numericUpDown1 = new NumericUpDown();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            listBox3 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 9);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 3;
            label1.Text = "Працуючі потоки";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(235, 9);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 4;
            label2.Text = "Очікуючі потоки";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(416, 9);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 5;
            label3.Text = "Створені потоки";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 276);
            label4.Name = "label4";
            label4.Size = new Size(153, 15);
            label4.TabIndex = 6;
            label4.Text = "Кількість мість у семафорі";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(470, 292);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 7;
            btnCreate.Text = "Створити потік";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(25, 294);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 8;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 28);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(182, 244);
            listBox1.TabIndex = 9;
            listBox1.DoubleClick += listBox1_DoubleClick;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(200, 27);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(173, 244);
            listBox2.TabIndex = 10;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.Location = new Point(379, 28);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(166, 244);
            listBox3.TabIndex = 11;
            listBox3.DoubleClick += listBox3_DoubleClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 326);
            Controls.Add(listBox3);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(btnCreate);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Потоки";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnCreate;
        private NumericUpDown numericUpDown1;
        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox3;
    }
}

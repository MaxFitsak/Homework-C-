namespace Homework32
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
            label = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            btnStop = new Button();
            btnFind = new Button();
            btnPause = new Button();
            label1 = new Label();
            checkBox1 = new CheckBox();
            listView1 = new ListView();
            column1 = new ColumnHeader();
            column2 = new ColumnHeader();
            column3 = new ColumnHeader();
            column4 = new ColumnHeader();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(38, 30);
            label.Name = "label";
            label.Size = new Size(36, 15);
            label.TabIndex = 0;
            label.Text = "Файл";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(294, 59);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 30);
            label2.Name = "label2";
            label2.Size = new Size(151, 15);
            label2.TabIndex = 2;
            label2.Text = "Слово або фраза у файлы";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(131, 60);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(144, 23);
            textBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 30);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 5;
            label3.Text = "Диски";
            // 
            // btnStop
            // 
            btnStop.Location = new Point(550, 60);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 6;
            btnStop.Text = "Зупинити";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnFind
            // 
            btnFind.Location = new Point(454, 60);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(75, 23);
            btnFind.TabIndex = 7;
            btnFind.Text = "Знайти";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(631, 58);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(98, 23);
            btnPause.TabIndex = 8;
            btnPause.Text = "Призупинити";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 114);
            label1.Name = "label1";
            label1.Size = new Size(270, 15);
            label1.TabIndex = 9;
            label1.Text = "Результати пошуку: кількість знайдених файлів \r\n";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(454, 113);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(91, 19);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "підкаталоги";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { column1, column2, column3, column4 });
            listView1.Location = new Point(12, 132);
            listView1.Name = "listView1";
            listView1.Size = new Size(728, 447);
            listView1.TabIndex = 11;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // column1
            // 
            column1.Text = "Name";
            column1.Width = 182;
            // 
            // column2
            // 
            column2.Text = "Folder";
            column2.Width = 182;
            // 
            // column3
            // 
            column3.DisplayIndex = 3;
            column3.Text = "Size";
            column3.Width = 182;
            // 
            // column4
            // 
            column4.DisplayIndex = 2;
            column4.Text = "Modification date";
            column4.Width = 182;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 591);
            Controls.Add(listView1);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Controls.Add(btnPause);
            Controls.Add(btnFind);
            Controls.Add(btnStop);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Пошук файлів";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Button btnStop;
        private Button btnFind;
        private Button btnPause;
        private Label label1;
        private CheckBox checkBox1;
        private ListView listView1;
        private ColumnHeader column1;
        private ColumnHeader column2;
        private ColumnHeader column3;
        private ColumnHeader column4;
    }
}

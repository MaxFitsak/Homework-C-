namespace Lesson30
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
            listView1 = new ListView();
            checkCatalogs = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnSearch = new Button();
            btnStop = new Button();
            btnWait = new Button();
            textBoxFile = new TextBox();
            textBoxMask = new TextBox();
            comboBoxDisks = new ComboBox();
            labelSearch = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 117);
            listView1.Name = "listView1";
            listView1.Size = new Size(820, 302);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // checkCatalogs
            // 
            checkCatalogs.AutoSize = true;
            checkCatalogs.Location = new Point(521, 81);
            checkCatalogs.Name = "checkCatalogs";
            checkCatalogs.Size = new Size(93, 19);
            checkCatalogs.TabIndex = 1;
            checkCatalogs.Text = "Підкаталоги";
            checkCatalogs.UseVisualStyleBackColor = true;
            checkCatalogs.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 23);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 3;
            label2.Text = "Файл";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(173, 23);
            label3.Name = "label3";
            label3.Size = new Size(145, 15);
            label3.TabIndex = 4;
            label3.Text = "Слово або фраза у файлі";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(363, 23);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 5;
            label4.Text = "Диски";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(471, 41);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Знайти";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(572, 40);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 7;
            btnStop.Text = "Зупинити";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // btnWait
            // 
            btnWait.Location = new Point(666, 40);
            btnWait.Name = "btnWait";
            btnWait.Size = new Size(93, 23);
            btnWait.TabIndex = 8;
            btnWait.Text = "Призупинити";
            btnWait.UseVisualStyleBackColor = true;
            // 
            // textBoxFile
            // 
            textBoxFile.Location = new Point(51, 41);
            textBoxFile.Name = "textBoxFile";
            textBoxFile.Size = new Size(100, 23);
            textBoxFile.TabIndex = 9;
            textBoxFile.TextChanged += textBoxFile_TextChanged;
            // 
            // textBoxMask
            // 
            textBoxMask.Location = new Point(157, 41);
            textBoxMask.Name = "textBoxMask";
            textBoxMask.Size = new Size(161, 23);
            textBoxMask.TabIndex = 10;
            // 
            // comboBoxDisks
            // 
            comboBoxDisks.FormattingEnabled = true;
            comboBoxDisks.Location = new Point(324, 41);
            comboBoxDisks.Name = "comboBoxDisks";
            comboBoxDisks.Size = new Size(121, 23);
            comboBoxDisks.TabIndex = 11;
            comboBoxDisks.SelectedIndexChanged += comboBoxDisks_SelectedIndexChanged;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(140, 85);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(201, 15);
            labelSearch.TabIndex = 12;
            labelSearch.Text = "Результат пошуку знайдено файлів";
            labelSearch.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 431);
            Controls.Add(labelSearch);
            Controls.Add(comboBoxDisks);
            Controls.Add(textBoxMask);
            Controls.Add(textBoxFile);
            Controls.Add(btnWait);
            Controls.Add(btnStop);
            Controls.Add(btnSearch);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(checkCatalogs);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private CheckBox checkCatalogs;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnSearch;
        private Button btnStop;
        private Button btnWait;
        private TextBox textBoxFile;
        private TextBox textBoxMask;
        private ComboBox comboBoxDisks;
        private Label labelSearch;
    }
}

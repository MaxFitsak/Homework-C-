namespace Homework24
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
            dataGridView1 = new DataGridView();
            numericUpDown1 = new NumericUpDown();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtPosition = new TextBox();
            txtSearch = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(262, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(526, 396);
            dataGridView1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(12, 42);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(244, 23);
            numericUpDown1.TabIndex = 1;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(12, 71);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 2;
            txtFirstName.Text = "FirstName";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(118, 71);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 3;
            txtLastName.Text = "Last Name";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(12, 100);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(100, 23);
            txtPosition.TabIndex = 4;
            txtPosition.Text = "Position";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(118, 100);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 5;
            txtSearch.Text = "Search";
            // 
            // button1
            // 
            button1.Location = new Point(12, 129);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 6;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAdd_Click;
            // 
            // button2
            // 
            button2.Location = new Point(118, 129);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 8;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnDelete_Click;
            // 
            // button3
            // 
            button3.Location = new Point(118, 158);
            button3.Name = "button3";
            button3.Size = new Size(100, 23);
            button3.TabIndex = 9;
            button3.Text = "Search";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnSearch_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 158);
            button4.Name = "button4";
            button4.Size = new Size(100, 23);
            button4.TabIndex = 10;
            button4.Text = "Update";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnUpdate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtSearch);
            Controls.Add(txtPosition);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(numericUpDown1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private NumericUpDown numericUpDown1;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtPosition;
        private TextBox txtSearch;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}

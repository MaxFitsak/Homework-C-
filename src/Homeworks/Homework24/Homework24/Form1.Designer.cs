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
            dgvEmployees = new DataGridView();
            numSalary = new NumericUpDown();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            cmbPosition = new ComboBox();
            menuStrip1 = new MenuStrip();
            пошукToolStripMenuItem = new ToolStripMenuItem();
            заІменемToolStripMenuItem = new ToolStripMenuItem();
            заПрізвищемToolStripMenuItem = new ToolStripMenuItem();
            заПосадоюToolStripMenuItem = new ToolStripMenuItem();
            button3 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSalary).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(262, 42);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.Size = new Size(526, 396);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            // 
            // numSalary
            // 
            numSalary.Location = new Point(153, 165);
            numSalary.Name = "numSalary";
            numSalary.Size = new Size(100, 23);
            numSalary.TabIndex = 1;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(153, 102);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 2;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(153, 136);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(12, 219);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 6;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAdd_Click;
            // 
            // button2
            // 
            button2.Location = new Point(129, 249);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 8;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnDelete_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 249);
            button4.Name = "button4";
            button4.Size = new Size(100, 23);
            button4.TabIndex = 10;
            button4.Text = "Update";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 105);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 11;
            label1.Text = "Імя Співробітника";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 139);
            label3.Name = "label3";
            label3.Size = new Size(135, 15);
            label3.TabIndex = 13;
            label3.Text = "Прізвище спіробітника";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(89, 167);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 14;
            label2.Text = "Зарплата";
            // 
            // cmbPosition
            // 
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(118, 220);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(121, 23);
            cmbPosition.TabIndex = 15;
            cmbPosition.Text = "Посада";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { пошукToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 16;
            menuStrip1.Text = "menuStrip1";
            // 
            // пошукToolStripMenuItem
            // 
            пошукToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { заІменемToolStripMenuItem, заПрізвищемToolStripMenuItem, заПосадоюToolStripMenuItem });
            пошукToolStripMenuItem.Name = "пошукToolStripMenuItem";
            пошукToolStripMenuItem.Size = new Size(58, 20);
            пошукToolStripMenuItem.Text = "Пошук";
            // 
            // заІменемToolStripMenuItem
            // 
            заІменемToolStripMenuItem.Name = "заІменемToolStripMenuItem";
            заІменемToolStripMenuItem.Size = new Size(180, 22);
            заІменемToolStripMenuItem.Text = "За іменем";
            заІменемToolStripMenuItem.Click += searchByNameToolStripMenuItem_Click;
            // 
            // заПрізвищемToolStripMenuItem
            // 
            заПрізвищемToolStripMenuItem.Name = "заПрізвищемToolStripMenuItem";
            заПрізвищемToolStripMenuItem.Size = new Size(180, 22);
            заПрізвищемToolStripMenuItem.Text = "За прізвищем";
            заПрізвищемToolStripMenuItem.Click += searchByLastNameToolStripMenuItem_Click;
            // 
            // заПосадоюToolStripMenuItem
            // 
            заПосадоюToolStripMenuItem.Name = "заПосадоюToolStripMenuItem";
            заПосадоюToolStripMenuItem.Size = new Size(180, 22);
            заПосадоюToolStripMenuItem.Text = "За посадою";
            заПосадоюToolStripMenuItem.Click += searchByPositionToolStripMenuItem_Click;
            // 
            // button3
            // 
            button3.Location = new Point(210, 194);
            button3.Name = "button3";
            button3.Size = new Size(29, 23);
            button3.TabIndex = 17;
            button3.Text = "✏️ ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnEditPosition_Click;
            // 
            // button5
            // 
            button5.Location = new Point(186, 194);
            button5.Name = "button5";
            button5.Size = new Size(18, 23);
            button5.TabIndex = 18;
            button5.Text = "+";
            button5.UseVisualStyleBackColor = true;
            button5.Click += btnAddPosition_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(cmbPosition);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(numSalary);
            Controls.Add(dgvEmployees);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSalary).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmployees;
        private NumericUpDown numSalary;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Button button1;
        private Button button2;
        private Button button4;
        private Label label1;
        private Label label3;
        private Label label2;
        private ComboBox cmbPosition;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem пошукToolStripMenuItem;
        private ToolStripMenuItem заІменемToolStripMenuItem;
        private ToolStripMenuItem заПрізвищемToolStripMenuItem;
        private ToolStripMenuItem заПосадоюToolStripMenuItem;
        private Button button3;
        private Button button5;
    }
}

namespace Homework23
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
            listBox = new ListBox();
            dateTimePicker = new DateTimePicker();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtName = new TextBox();
            txtQuantity = new TextBox();
            txtPrice = new TextBox();
            dataGridView = new DataGridView();
            textSupllier = new TextBox();
            textProductType = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.Items.AddRange(new object[] { "Вся інформація про товар", "Всі типи товарів", "Всі типи постачальників", "Товару з мінімальною кількістю", "Товар з максимальною кількістю", "Товар з максимальною собівартістю", "Товар заданої категорії", "Товар заданого постачальника", "Найстаріщий товар на складі", "Средня кількість товарів за кожним типом товару" });
            listBox.Location = new Point(12, 269);
            listBox.Name = "listBox";
            listBox.Size = new Size(306, 169);
            listBox.TabIndex = 1;
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(12, 95);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(306, 23);
            dateTimePicker.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 124);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(128, 124);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Змінити";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(243, 124);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Добавити";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 66);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 6;
            txtName.Text = "Назва";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(118, 66);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 23);
            txtQuantity.TabIndex = 7;
            txtQuantity.Text = "Кількість";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(224, 66);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(94, 23);
            txtPrice.TabIndex = 8;
            txtPrice.Text = "Ціна";
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(324, 23);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(464, 415);
            dataGridView.TabIndex = 9;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // textSupllier
            // 
            textSupllier.Location = new Point(12, 37);
            textSupllier.Name = "textSupllier";
            textSupllier.Size = new Size(100, 23);
            textSupllier.TabIndex = 10;
            textSupllier.Text = "Постачальник";
            // 
            // textProductType
            // 
            textProductType.Location = new Point(118, 37);
            textProductType.Name = "textProductType";
            textProductType.Size = new Size(100, 23);
            textProductType.TabIndex = 11;
            textProductType.Text = "Тип товара";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textProductType);
            Controls.Add(textSupllier);
            Controls.Add(dataGridView);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(txtName);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(dateTimePicker);
            Controls.Add(listBox);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox;
        private DateTimePicker dateTimePicker;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private TextBox txtName;
        private TextBox txtQuantity;
        private TextBox txtPrice;
        private DataGridView dataGridView;
        private TextBox textSupllier;
        private TextBox textProductType;
    }
}

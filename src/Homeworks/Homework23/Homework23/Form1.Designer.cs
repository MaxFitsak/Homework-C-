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
            dateTimePicker = new DateTimePicker();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtName = new TextBox();
            txtQuantity = new TextBox();
            txtPrice = new TextBox();
            dataGridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            опціїToolStripMenuItem = new ToolStripMenuItem();
            продуктиToolStripMenuItem = new ToolStripMenuItem();
            menuAllProducts = new ToolStripMenuItem();
            menuOldestProduct = new ToolStripMenuItem();
            категоріїТаПостачальникиToolStripMenuItem = new ToolStripMenuItem();
            menuAllTypes = new ToolStripMenuItem();
            menuAllSuppliers = new ToolStripMenuItem();
            menuSelectedType = new ToolStripMenuItem();
            menuSelectedSupplier = new ToolStripMenuItem();
            статистикаToolStripMenuItem = new ToolStripMenuItem();
            menuMaxQty = new ToolStripMenuItem();
            menuMinQty = new ToolStripMenuItem();
            menuMinPrice = new ToolStripMenuItem();
            menuMaxPrice = new ToolStripMenuItem();
            menuAvgByType = new ToolStripMenuItem();
            cmbProductType = new ComboBox();
            cmbSupplier = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(12, 386);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(306, 23);
            dateTimePicker.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 415);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(132, 415);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Змінити";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(243, 415);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Добавити";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            txtName.Location = new Point(107, 229);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 6;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(107, 258);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 23);
            txtQuantity.TabIndex = 7;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(107, 287);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 8;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(324, 23);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(587, 415);
            dataGridView.TabIndex = 9;
            dataGridView.CellContentClick += dataGridView_CellClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { опціїToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(923, 24);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // опціїToolStripMenuItem
            // 
            опціїToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { продуктиToolStripMenuItem, категоріїТаПостачальникиToolStripMenuItem, статистикаToolStripMenuItem });
            опціїToolStripMenuItem.Name = "опціїToolStripMenuItem";
            опціїToolStripMenuItem.Size = new Size(48, 20);
            опціїToolStripMenuItem.Text = "Опції";
            // 
            // продуктиToolStripMenuItem
            // 
            продуктиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuAllProducts, menuOldestProduct });
            продуктиToolStripMenuItem.Name = "продуктиToolStripMenuItem";
            продуктиToolStripMenuItem.Size = new Size(224, 22);
            продуктиToolStripMenuItem.Text = "Продукти";
            // 
            // menuAllProducts
            // 
            menuAllProducts.Name = "menuAllProducts";
            menuAllProducts.Size = new Size(235, 22);
            menuAllProducts.Text = "Вся інформація про товар";
            menuAllProducts.Click += menuAllTypes_Click;
            // 
            // menuOldestProduct
            // 
            menuOldestProduct.Name = "menuOldestProduct";
            menuOldestProduct.Size = new Size(235, 22);
            menuOldestProduct.Text = "Найстаріщий товар на складі";
            menuOldestProduct.Click += menuOldestProduct_Click;
            // 
            // категоріїТаПостачальникиToolStripMenuItem
            // 
            категоріїТаПостачальникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuAllTypes, menuAllSuppliers, menuSelectedType, menuSelectedSupplier });
            категоріїТаПостачальникиToolStripMenuItem.Name = "категоріїТаПостачальникиToolStripMenuItem";
            категоріїТаПостачальникиToolStripMenuItem.Size = new Size(224, 22);
            категоріїТаПостачальникиToolStripMenuItem.Text = "Категорії та постачальники";
            // 
            // menuAllTypes
            // 
            menuAllTypes.Name = "menuAllTypes";
            menuAllTypes.Size = new Size(245, 22);
            menuAllTypes.Text = "Всі типи товарів";
            menuAllTypes.Click += menuAllTypes_Click;
            // 
            // menuAllSuppliers
            // 
            menuAllSuppliers.Name = "menuAllSuppliers";
            menuAllSuppliers.Size = new Size(245, 22);
            menuAllSuppliers.Text = "Всі типи постачальників";
            menuAllSuppliers.Click += menuAllSuppliers_Click;
            // 
            // menuSelectedType
            // 
            menuSelectedType.Name = "menuSelectedType";
            menuSelectedType.Size = new Size(245, 22);
            menuSelectedType.Text = "Товар заданої категорії";
            menuSelectedType.Click += menuSelectedType_Click;
            // 
            // menuSelectedSupplier
            // 
            menuSelectedSupplier.Name = "menuSelectedSupplier";
            menuSelectedSupplier.Size = new Size(245, 22);
            menuSelectedSupplier.Text = "Товар заданого постачальника";
            menuSelectedSupplier.Click += menuSelectedSupplier_Click;
            // 
            // статистикаToolStripMenuItem
            // 
            статистикаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuMaxQty, menuMinQty, menuMinPrice, menuMaxPrice, menuAvgByType });
            статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            статистикаToolStripMenuItem.Size = new Size(224, 22);
            статистикаToolStripMenuItem.Text = "Статистика";
            // 
            // menuMaxQty
            // 
            menuMaxQty.Name = "menuMaxQty";
            menuMaxQty.Size = new Size(314, 22);
            menuMaxQty.Text = "Товар з максимальною кількістю";
            menuMaxQty.Click += menuMaxQty_Click;
            // 
            // menuMinQty
            // 
            menuMinQty.Name = "menuMinQty";
            menuMinQty.Size = new Size(314, 22);
            menuMinQty.Text = "Товару з мінімальною кількістю";
            menuMinQty.Click += menuMinQty_Click;
            // 
            // menuMinPrice
            // 
            menuMinPrice.Name = "menuMinPrice";
            menuMinPrice.Size = new Size(314, 22);
            menuMinPrice.Text = "Товар з мінімальною собівартістю";
            menuMinPrice.Click += menuMinPrice_Click;
            // 
            // menuMaxPrice
            // 
            menuMaxPrice.Name = "menuMaxPrice";
            menuMaxPrice.Size = new Size(314, 22);
            menuMaxPrice.Text = "Товар з максимальною собівартістю";
            menuMaxPrice.Click += menuMaxPrice_Click;
            // 
            // menuAvgByType
            // 
            menuAvgByType.Name = "menuAvgByType";
            menuAvgByType.Size = new Size(314, 22);
            menuAvgByType.Text = "Середня кількість товарів за кожним типом";
            menuAvgByType.Click += menuAvgByType_Click;
            // 
            // cmbProductType
            // 
            cmbProductType.FormattingEnabled = true;
            cmbProductType.Location = new Point(197, 357);
            cmbProductType.Name = "cmbProductType";
            cmbProductType.Size = new Size(121, 23);
            cmbProductType.TabIndex = 13;
            cmbProductType.Text = "Тип товара";
            // 
            // cmbSupplier
            // 
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(15, 357);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(121, 23);
            cmbSupplier.TabIndex = 14;
            cmbSupplier.Text = "Постачальники";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 229);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 15;
            label1.Text = "Назва товару";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 261);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 16;
            label2.Text = "Кількість товару";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 295);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 17;
            label3.Text = "Ціна товару";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbSupplier);
            Controls.Add(cmbProductType);
            Controls.Add(dataGridView);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(txtName);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(dateTimePicker);
            Controls.Add(menuStrip1);
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "СКЛАД";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dateTimePicker;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private TextBox txtName;
        private TextBox txtQuantity;
        private TextBox txtPrice;
        private DataGridView dataGridView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem опціїToolStripMenuItem;
        private ToolStripMenuItem продуктиToolStripMenuItem;
        private ToolStripMenuItem menuAllProducts;
        private ToolStripMenuItem menuOldestProduct;
        private ToolStripMenuItem категоріїТаПостачальникиToolStripMenuItem;
        private ToolStripMenuItem menuAllTypes;
        private ToolStripMenuItem menuAllSuppliers;
        private ToolStripMenuItem menuSelectedType;
        private ToolStripMenuItem menuSelectedSupplier;
        private ToolStripMenuItem статистикаToolStripMenuItem;
        private ToolStripMenuItem menuMaxQty;
        private ToolStripMenuItem menuMinQty;
        private ToolStripMenuItem menuMinPrice;
        private ToolStripMenuItem menuMaxPrice;
        private ToolStripMenuItem menuAvgByType;
        private ComboBox cmbProductType;
        private ComboBox cmbSupplier;
        private Label label1;
        private Label label2;
        private Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

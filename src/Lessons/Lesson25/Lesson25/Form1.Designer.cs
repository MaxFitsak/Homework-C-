namespace Lesson25
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
        /// <summary>
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
            menuStrip1 = new MenuStrip();
            опціїToolStripMenuItem = new ToolStripMenuItem();
            checkBoxFilter = new CheckBox();
            comboBoxAuthors = new ComboBox();
            listBoxBooks = new ListBox();
            додатиАвтоToolStripMenuItem = new ToolStripMenuItem();
            додатиАвтораToolStripMenuItem = new ToolStripMenuItem();
            редагуватиАвтораToolStripMenuItem = new ToolStripMenuItem();
            додатиКнигуToolStripMenuItem = new ToolStripMenuItem();
            редагуватиКнигуToolStripMenuItem = new ToolStripMenuItem();
            видалитиКнигуToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { опціїToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // опціїToolStripMenuItem
            // 
            опціїToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { додатиАвтоToolStripMenuItem, додатиАвтораToolStripMenuItem, редагуватиАвтораToolStripMenuItem, додатиКнигуToolStripMenuItem, редагуватиКнигуToolStripMenuItem, видалитиКнигуToolStripMenuItem });
            опціїToolStripMenuItem.Name = "опціїToolStripMenuItem";
            опціїToolStripMenuItem.Size = new Size(48, 20);
            опціїToolStripMenuItem.Text = "Опції";
            // 
            // checkBoxFilter
            // 
            checkBoxFilter.AutoSize = true;
            checkBoxFilter.Location = new Point(338, 422);
            checkBoxFilter.Name = "checkBoxFilter";
            checkBoxFilter.Size = new Size(85, 19);
            checkBoxFilter.TabIndex = 1;
            checkBoxFilter.Text = "фільтрація";
            checkBoxFilter.UseVisualStyleBackColor = true;
            // 
            // comboBoxAuthors
            // 
            comboBoxAuthors.FormattingEnabled = true;
            comboBoxAuthors.Location = new Point(12, 27);
            comboBoxAuthors.Name = "comboBoxAuthors";
            comboBoxAuthors.Size = new Size(776, 23);
            comboBoxAuthors.TabIndex = 2;
            // 
            // listBoxBooks
            // 
            listBoxBooks.FormattingEnabled = true;
            listBoxBooks.Location = new Point(12, 56);
            listBoxBooks.Name = "listBoxBooks";
            listBoxBooks.Size = new Size(776, 349);
            listBoxBooks.TabIndex = 3;
            // 
            // додатиАвтоToolStripMenuItem
            // 
            додатиАвтоToolStripMenuItem.Name = "додатиАвтоToolStripMenuItem";
            додатиАвтоToolStripMenuItem.Size = new Size(180, 22);
            додатиАвтоToolStripMenuItem.Text = "Додати автора";
            додатиАвтоToolStripMenuItem.Click += menuAddAuthor_Click;
            // 
            // додатиАвтораToolStripMenuItem
            // 
            додатиАвтораToolStripMenuItem.Name = "додатиАвтораToolStripMenuItem";
            додатиАвтораToolStripMenuItem.Size = new Size(180, 22);
            додатиАвтораToolStripMenuItem.Text = "Видалити  автора";
            додатиАвтораToolStripMenuItem.Click += menuDeleteAuthor_Click;
            // 
            // редагуватиАвтораToolStripMenuItem
            // 
            редагуватиАвтораToolStripMenuItem.Name = "редагуватиАвтораToolStripMenuItem";
            редагуватиАвтораToolStripMenuItem.Size = new Size(180, 22);
            редагуватиАвтораToolStripMenuItem.Text = "Редагувати автора";
            редагуватиАвтораToolStripMenuItem.Click += menuEditAuthor_Click;
            // 
            // додатиКнигуToolStripMenuItem
            // 
            додатиКнигуToolStripMenuItem.Name = "додатиКнигуToolStripMenuItem";
            додатиКнигуToolStripMenuItem.Size = new Size(180, 22);
            додатиКнигуToolStripMenuItem.Text = "Додати книгу";
            додатиКнигуToolStripMenuItem.Click += menuAddBook_Click;
            // 
            // редагуватиКнигуToolStripMenuItem
            // 
            редагуватиКнигуToolStripMenuItem.Name = "редагуватиКнигуToolStripMenuItem";
            редагуватиКнигуToolStripMenuItem.Size = new Size(180, 22);
            редагуватиКнигуToolStripMenuItem.Text = "Редагувати книгу";
            редагуватиКнигуToolStripMenuItem.Click += menuEditBook_Click;
            // 
            // видалитиКнигуToolStripMenuItem
            // 
            видалитиКнигуToolStripMenuItem.Name = "видалитиКнигуToolStripMenuItem";
            видалитиКнигуToolStripMenuItem.Size = new Size(180, 22);
            видалитиКнигуToolStripMenuItem.Text = "Видалити книгу";
            видалитиКнигуToolStripMenuItem.Click += menuDeleteBook_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxBooks);
            Controls.Add(comboBoxAuthors);
            Controls.Add(checkBoxFilter);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Автори та книги";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem опціїToolStripMenuItem;
        private CheckBox checkBoxFilter;
        private ComboBox comboBoxAuthors;
        private ListBox listBoxBooks;
        private ToolStripMenuItem додатиАвтоToolStripMenuItem;
        private ToolStripMenuItem додатиАвтораToolStripMenuItem;
        private ToolStripMenuItem редагуватиАвтораToolStripMenuItem;
        private ToolStripMenuItem додатиКнигуToolStripMenuItem;
        private ToolStripMenuItem редагуватиКнигуToolStripMenuItem;
        private ToolStripMenuItem видалитиКнигуToolStripMenuItem;
    }
}
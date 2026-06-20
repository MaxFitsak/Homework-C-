namespace Homework27
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
            menuStrip1 = new MenuStrip();
            опціїToolStripMenuItem = new ToolStripMenuItem();
            відображенняВсіхПокупцівІзКонкретногоМістаToolStripMenuItem = new ToolStripMenuItem();
            відображенняВсіхПокупцівІзКонкретноїКраїниToolStripMenuItem = new ToolStripMenuItem();
            відображенняВсіхАкційДляКонкретноїКраїниToolStripMenuItem = new ToolStripMenuItem();
            відображенняСпискуМістКонкретноїКраїниToolStripMenuItem = new ToolStripMenuItem();
            відображенняСпискуРозділівКонкретногоПокупцяToolStripMenuItem = new ToolStripMenuItem();
            відображенняСпискуАкційнихТоварівКонкретногоРозділуToolStripMenuItem = new ToolStripMenuItem();
            показатиToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            показатиВсеToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(93, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(779, 407);
            dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { опціїToolStripMenuItem, показатиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // опціїToolStripMenuItem
            // 
            опціїToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { відображенняВсіхПокупцівІзКонкретногоМістаToolStripMenuItem, відображенняВсіхПокупцівІзКонкретноїКраїниToolStripMenuItem, відображенняВсіхАкційДляКонкретноїКраїниToolStripMenuItem, відображенняСпискуМістКонкретноїКраїниToolStripMenuItem, відображенняСпискуРозділівКонкретногоПокупцяToolStripMenuItem, відображенняСпискуАкційнихТоварівКонкретногоРозділуToolStripMenuItem });
            опціїToolStripMenuItem.Name = "опціїToolStripMenuItem";
            опціїToolStripMenuItem.Size = new Size(48, 20);
            опціїToolStripMenuItem.Text = "Опції";
            // 
            // відображенняВсіхПокупцівІзКонкретногоМістаToolStripMenuItem
            // 
            відображенняВсіхПокупцівІзКонкретногоМістаToolStripMenuItem.Name = "відображенняВсіхПокупцівІзКонкретногоМістаToolStripMenuItem";
            відображенняВсіхПокупцівІзКонкретногоМістаToolStripMenuItem.Size = new Size(404, 22);
            відображенняВсіхПокупцівІзКонкретногоМістаToolStripMenuItem.Text = "Відображення всіх покупців із конкретного міста";
            відображенняВсіхПокупцівІзКонкретногоМістаToolStripMenuItem.Click += OptionsMenu_DropDownItemClicked;
            // 
            // відображенняВсіхПокупцівІзКонкретноїКраїниToolStripMenuItem
            // 
            відображенняВсіхПокупцівІзКонкретноїКраїниToolStripMenuItem.Name = "відображенняВсіхПокупцівІзКонкретноїКраїниToolStripMenuItem";
            відображенняВсіхПокупцівІзКонкретноїКраїниToolStripMenuItem.Size = new Size(404, 22);
            відображенняВсіхПокупцівІзКонкретноїКраїниToolStripMenuItem.Text = "Відображення всіх покупців із конкретної країни";
            відображенняВсіхПокупцівІзКонкретноїКраїниToolStripMenuItem.Click += OptionsMenu_DropDownItemClicked;
            // 
            // відображенняВсіхАкційДляКонкретноїКраїниToolStripMenuItem
            // 
            відображенняВсіхАкційДляКонкретноїКраїниToolStripMenuItem.Name = "відображенняВсіхАкційДляКонкретноїКраїниToolStripMenuItem";
            відображенняВсіхАкційДляКонкретноїКраїниToolStripMenuItem.Size = new Size(404, 22);
            відображенняВсіхАкційДляКонкретноїКраїниToolStripMenuItem.Text = "Відображення всіх акцій для конкретної країни";
            відображенняВсіхАкційДляКонкретноїКраїниToolStripMenuItem.Click += OptionsMenu_DropDownItemClicked;
            // 
            // відображенняСпискуМістКонкретноїКраїниToolStripMenuItem
            // 
            відображенняСпискуМістКонкретноїКраїниToolStripMenuItem.Name = "відображенняСпискуМістКонкретноїКраїниToolStripMenuItem";
            відображенняСпискуМістКонкретноїКраїниToolStripMenuItem.Size = new Size(404, 22);
            відображенняСпискуМістКонкретноїКраїниToolStripMenuItem.Text = "Відображення списку міст конкретної країни";
            відображенняСпискуМістКонкретноїКраїниToolStripMenuItem.Click += OptionsMenu_DropDownItemClicked;
            // 
            // відображенняСпискуРозділівКонкретногоПокупцяToolStripMenuItem
            // 
            відображенняСпискуРозділівКонкретногоПокупцяToolStripMenuItem.Name = "відображенняСпискуРозділівКонкретногоПокупцяToolStripMenuItem";
            відображенняСпискуРозділівКонкретногоПокупцяToolStripMenuItem.Size = new Size(404, 22);
            відображенняСпискуРозділівКонкретногоПокупцяToolStripMenuItem.Text = "Відображення списку розділів конкретного покупця";
            відображенняСпискуРозділівКонкретногоПокупцяToolStripMenuItem.Click += OptionsMenu_DropDownItemClicked;
            // 
            // відображенняСпискуАкційнихТоварівКонкретногоРозділуToolStripMenuItem
            // 
            відображенняСпискуАкційнихТоварівКонкретногоРозділуToolStripMenuItem.Name = "відображенняСпискуАкційнихТоварівКонкретногоРозділуToolStripMenuItem";
            відображенняСпискуАкційнихТоварівКонкретногоРозділуToolStripMenuItem.Size = new Size(404, 22);
            відображенняСпискуАкційнихТоварівКонкретногоРозділуToolStripMenuItem.Text = "Відображення списку акційних товарів конкретного розділу";
            відображенняСпискуАкційнихТоварівКонкретногоРозділуToolStripMenuItem.Click += OptionsMenu_DropDownItemClicked;
            // 
            // показатиToolStripMenuItem
            // 
            показатиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { показатиВсеToolStripMenuItem });
            показатиToolStripMenuItem.Name = "показатиToolStripMenuItem";
            показатиToolStripMenuItem.Size = new Size(70, 20);
            показатиToolStripMenuItem.Text = "Показати";
            // 
            // button1
            // 
            button1.Location = new Point(12, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Видалити";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnDelete_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 386);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Обновити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnUpdate_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 357);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "Вставити";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnInsert_Click;
            // 
            // показатиВсеToolStripMenuItem
            // 
            показатиВсеToolStripMenuItem.Name = "показатиВсеToolStripMenuItem";
            показатиВсеToolStripMenuItem.Size = new Size(180, 22);
            показатиВсеToolStripMenuItem.Text = "Показати все";
            показатиВсеToolStripMenuItem.Click += показатиВсеToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem опціїToolStripMenuItem;
        private ToolStripMenuItem відображенняВсіхПокупцівІзКонкретногоМістаToolStripMenuItem;
        private ToolStripMenuItem відображенняВсіхПокупцівІзКонкретноїКраїниToolStripMenuItem;
        private ToolStripMenuItem відображенняВсіхАкційДляКонкретноїКраїниToolStripMenuItem;
        private ToolStripMenuItem відображенняСпискуМістКонкретноїКраїниToolStripMenuItem;
        private ToolStripMenuItem відображенняСпискуРозділівКонкретногоПокупцяToolStripMenuItem;
        private ToolStripMenuItem відображенняСпискуАкційнихТоварівКонкретногоРозділуToolStripMenuItem;
        private Button button1;
        private Button button2;
        private Button button3;
        private ToolStripMenuItem показатиToolStripMenuItem;
        private ToolStripMenuItem показатиВсеToolStripMenuItem;
    }
}

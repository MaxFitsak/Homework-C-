namespace Homework26
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
            dgvGames = new DataGridView();
            btnLoad = new Button();
            btnSeed = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGames).BeginInit();
            SuspendLayout();
            // 
            // dgvGames
            // 
            dgvGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGames.Location = new Point(296, 12);
            dgvGames.Name = "dgvGames";
            dgvGames.Size = new Size(492, 426);
            dgvGames.TabIndex = 0;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(12, 29);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Оновити";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSeed
            // 
            btnSeed.Location = new Point(136, 29);
            btnSeed.Name = "btnSeed";
            btnSeed.Size = new Size(154, 23);
            btnSeed.TabIndex = 2;
            btnSeed.Text = "Додати тестові ігри";
            btnSeed.UseVisualStyleBackColor = true;
            btnSeed.Click += btnSeed_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSeed);
            Controls.Add(btnLoad);
            Controls.Add(dgvGames);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvGames).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvGames;
        private Button btnLoad;
        private Button btnSeed;
    }
}

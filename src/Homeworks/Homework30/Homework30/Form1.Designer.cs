namespace Homework30
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
            progressBar1 = new ProgressBar();
            button1 = new Button();
            textBoxSource = new TextBox();
            textBoxDest = new TextBox();
            button2 = new Button();
            buttonCopy = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 55);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Дерело:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 117);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 1;
            label2.Text = "Приймач:";
            label2.Click += label2_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(25, 181);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(470, 23);
            progressBar1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(520, 55);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Файл..";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonFile_Click;
            // 
            // textBoxSource
            // 
            textBoxSource.Location = new Point(93, 55);
            textBoxSource.Name = "textBoxSource";
            textBoxSource.Size = new Size(402, 23);
            textBoxSource.TabIndex = 4;
            // 
            // textBoxDest
            // 
            textBoxDest.Location = new Point(93, 117);
            textBoxDest.Name = "textBoxDest";
            textBoxDest.Size = new Size(402, 23);
            textBoxDest.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(520, 117);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Папка..";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonFolder_Click;
            // 
            // buttonCopy
            // 
            buttonCopy.Location = new Point(520, 181);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(75, 23);
            buttonCopy.TabIndex = 7;
            buttonCopy.Text = "Копіювати";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 238);
            Controls.Add(buttonCopy);
            Controls.Add(button2);
            Controls.Add(textBoxDest);
            Controls.Add(textBoxSource);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Копіювання файлів";
            Load += buttonCopy_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ProgressBar progressBar1;
        private Button button1;
        private TextBox textBoxSource;
        private TextBox textBoxDest;
        private Button button2;
        private Button buttonCopy;
    }
}

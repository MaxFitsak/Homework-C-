namespace Homework30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Виберіть файл для копіювання",
                Filter = "Всі файли (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxSource.Text = openFileDialog.FileName;
            }

        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog fileBrowserDialog = new FolderBrowserDialog
            {
                Description = "Виберіть папку"
            };

            if (fileBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxDest.Text = fileBrowserDialog.SelectedPath;
            }

        }

        private async void buttonCopy_Click(object sender, EventArgs e)
        {
            string sourcePath = textBoxSource.Text.Trim();
            string destFolder = textBoxDest.Text.Trim();

            if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
            {
                MessageBox.Show("виберіть коректний файл-джерело.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(destFolder) || !Directory.Exists(destFolder))
            {
                MessageBox.Show("виберіть коректну папку призначення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fileName = Path.GetFileName(sourcePath);
            string destPath = Path.Combine(destFolder, fileName);

            buttonCopy.Enabled = false;
            progressBar1.Value = 0;

            var progress = new Progress<int>(value =>
            {
                progressBar1.Value = value;
            });

            try
            {
                await Task.Run(() => CopyFileWithProgress(sourcePath, destPath, progress));

                MessageBox.Show("Файл успішно скопійовано", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при копіюванні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonCopy.Enabled = true;
            }
        }

        private void CopyFileWithProgress(string source, string dest, IProgress<int> progress)
        {
            const int bufferSize = 4096;
            byte[] buffer = new byte[bufferSize];

            using FileStream sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read);
            using FileStream destStream = new FileStream(dest, FileMode.Create, FileAccess.Write);

            long totalBytes = sourceStream.Length;
            long totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                destStream.Write(buffer, 0, bytesRead);
                totalBytesRead += bytesRead;
                int progressPercentage = (int)((double)totalBytesRead / totalBytes * 100);

                progress.Report(progressPercentage);
            }
        }
    }
}

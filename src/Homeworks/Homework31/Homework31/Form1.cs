using System.Text;

namespace Homework31
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cts;

        public Form1()
        {
            InitializeComponent();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;
            string key = txtKey.Text;

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("виберіть коректний файл.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("введіть ключ шифрування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ToggleControls(false);
            progressBar1.Value = 0;

            cts = new CancellationTokenSource();

            var proggres = new Progress<int>(value =>
            {
                progressBar1.Value = value;
            });

            try
            {
                string extension = Path.GetExtension(filePath);
                string outFPath = Path.ChangeExtension(filePath, null) + "Copy" + extension;

                await ProcessFileAsync(filePath, outFPath, key, proggres, cts.Token);

                MessageBox.Show("Операцію завершено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar1.Value = 0;
            }
            catch(OperationCanceledException)
            {
                MessageBox.Show("Операція скасована", "Скасовано", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                progressBar1.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cts.Dispose();
                cts = null;
                ToggleControls(true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }

        private void ToggleControls(bool isEnabled)
        {
            button1.Enabled = isEnabled;
            txtKey.Enabled = isEnabled;
            rbEncrypt.Enabled = isEnabled;
            rbDecrypt.Enabled = isEnabled;
            button2.Enabled = isEnabled;

            button3.Enabled = !isEnabled;
        }

        private Task ProcessFileAsync(string filePath, string outputPath, string key, IProgress<int> progress, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                int keyLength = keyBytes.Length;

                using (FileStream fsIn = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (FileStream fsOut = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    long totalBytesRead = 0;
                    long totalLength = fsIn.Length;
                    int lastProgressReported = 0;

                    while ((bytesRead = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        for (int i = 0; i < bytesRead; i++)
                        {
                            buffer[i] = (byte)(buffer[i] ^ keyBytes[(totalBytesRead + i) % keyLength]);
                        }

                        fsOut.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;

                        if (totalLength > 0)
                        {
                            int currentProgress = (int)((double)totalBytesRead / totalLength * 100);

                            if (currentProgress > lastProgressReported)
                            {
                                lastProgressReported = currentProgress;
                                progress.Report(currentProgress);
                            }
                        }
                    }
                }
            }, cancellationToken);
        }
    }
}

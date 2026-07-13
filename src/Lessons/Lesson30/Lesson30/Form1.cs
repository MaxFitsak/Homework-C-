using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Lesson30
{
    public partial class Form1 : Form
    {
        private Thread searchThread;
        private int foundCount = 0;

        private bool isCancelled = false;
        private bool isPaused = false;
        private ManualResetEvent pauseEvent = new ManualResetEvent(true);

        public Form1()
        {
            InitializeComponent();
            FillDrives();
            SetupListView();

            btnStop.Enabled = false;
            btnPause.Enabled = false;
        }

        private void FillDrives()
        {
            string[] logicalDrives = Directory.GetLogicalDrives();
            comboBoxDisks.Items.Clear();
            foreach (string disk in logicalDrives)
            {
                comboBoxDisks.Items.Add(disk);
            }
        }

        private void SetupListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("Folder", 280);
            listView1.Columns.Add("Size", 90);
            listView1.Columns.Add("Modification date", 140);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxDisks.SelectedItem == null)
            {
                MessageBox.Show("Виберіть диск");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxFile.Text))
            {
                MessageBox.Show("Введіть маску файлу");
                return;
            }

            isCancelled = false;
            isPaused = false;
            pauseEvent.Set();

            listView1.Items.Clear();
            foundCount = 0;
            lblResultCount.Text = "Результати пошуку: кількість знайдених файлів - 0";

            string path = comboBoxDisks.SelectedItem.ToString();
            string userMask = textBoxFile.Text;
            string wordToFind = textBoxMask.Text;
            bool searchSubDirs = checkCatalogs.Checked;

            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                MessageBox.Show("Некоректний шлях");
                return;
            }

            string regexPattern = Regex.Escape(userMask).Replace(@"\*", ".*").Replace(@"\?", ".");
            Regex regMask = new Regex("^" + regexPattern + "$", RegexOptions.IgnoreCase);

            btnSearch.Enabled = false;
            btnStop.Enabled = true;
            btnPause.Enabled = true;

            searchThread = new Thread(() => StartSearchProcess(di, regMask, searchSubDirs, wordToFind));
            searchThread.IsBackground = true;
            searchThread.Start();
        }

        private void StartSearchProcess(DirectoryInfo rootDir, Regex mask, bool searchSubDirs, string wordToFind)
        {
            SearchFiles(rootDir, mask, searchSubDirs, wordToFind);

            this.Invoke(new Action(() =>
            {
                btnSearch.Enabled = true;
                btnStop.Enabled = false;
                btnPause.Enabled = false;
                btnPause.Text = "Призупинити";

                if (!isCancelled)
                {
                    MessageBox.Show($"Пошук завершено Знайдено файлів: {foundCount}");
                }
            }));
        }

        private void SearchFiles(DirectoryInfo currentDir, Regex mask, bool searchSubDirs, string wordToFind)
        {
            if (isCancelled) return;

            pauseEvent.WaitOne();

            FileInfo[] files = null;
            try
            {
                files = currentDir.GetFiles();
            }
            catch { return; }

            foreach (FileInfo f in files)
            {
                if (isCancelled) return;
                pauseEvent.WaitOne();

                if (mask.IsMatch(f.Name))
                {
                    if (!string.IsNullOrWhiteSpace(wordToFind))
                    {
                        try
                        {
                            string content = File.ReadAllText(f.FullName, Encoding.UTF8);
                            if (!content.Contains(wordToFind))
                                continue;
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    Interlocked.Increment(ref foundCount);

                    ListViewItem item = new ListViewItem(f.Name);
                    item.SubItems.Add(f.DirectoryName);
                    item.SubItems.Add(f.Length.ToString());
                    item.SubItems.Add(f.LastWriteTime.ToString("dd.MM.yyyy H:mm:ss"));

                    // Безпечне оновлення UI
                    this.Invoke(new Action(() =>
                    {
                        listView1.Items.Add(item);
                        lblResultCount.Text = $"Результати пошуку: кількість знайдених файлів - {foundCount}";
                    }));
                }
            }

            if (searchSubDirs)
            {
                DirectoryInfo[] subDirs = null;
                try
                {
                    subDirs = currentDir.GetDirectories();
                }
                catch { return; }

                foreach (DirectoryInfo dir in subDirs)
                {
                    SearchFiles(dir, mask, searchSubDirs, wordToFind);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isCancelled = true;
            pauseEvent.Set();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                isPaused = true;
                pauseEvent.Reset();
                btnPause.Text = "Продовжити";
            }
            else
            {
                isPaused = false;
                pauseEvent.Set();
                btnPause.Text = "Призупинити";
            }
        }
    }
}
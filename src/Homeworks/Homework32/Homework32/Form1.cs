using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homework32
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cts;
        private PauseTokenSource pts = new PauseTokenSource();

        public Form1()
        {
            InitializeComponent();
            LoadDrives();
        }

        private void LoadDrives()
        {
            comboBox1.Items.Clear();
            foreach (var drive in DriveInfo.GetDrives())
                if (drive.IsReady)
                    comboBox1.Items.Add(drive.Name);
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            label1.Text = "Результати пошуку: кількість знайдених файлів - 0";

            string mask = textBox1.Text.Trim();
            string keyword = textBox2.Text.Trim();
            string drive = comboBox1.SelectedItem?.ToString();
            bool subdirs = checkBox1.Checked;

            if (string.IsNullOrEmpty(mask)) mask = "*.*";
            if (string.IsNullOrEmpty(drive)) return;

            cts = new CancellationTokenSource();
            pts = new PauseTokenSource();

            btnFind.Enabled = false;
            btnStop.Enabled = true;
            btnPause.Enabled = true;

            await Task.Run(() => SearchFiles(drive, mask, keyword, subdirs, cts.Token, pts));

            btnFind.Enabled = true;
            btnStop.Enabled = false;
            btnPause.Enabled = false;
            btnPause.Text = "Призупинити";
        }

        private void SearchFiles(string root, string mask, string keyword,
            bool subdirs, CancellationToken token, PauseTokenSource pts)
        {
            int count = 0;

            void SearchDir(string dir)
            {
                if (token.IsCancellationRequested) return;

                try
                {
                    foreach (var file in Directory.EnumerateFiles(dir, mask))
                    {
                        if (token.IsCancellationRequested) return;

                        pts.Token.WaitWhilePaused();

                        if (!string.IsNullOrEmpty(keyword))
                        {
                            try
                            {
                                if (!File.ReadAllText(file).Contains(keyword))
                                    continue;
                            }
                            catch { continue; }
                        }

                        var info = new FileInfo(file);
                        count++;

                        listView1.Invoke((Action)(() =>
                        {
                            var item = new ListViewItem(info.Name);
                            item.SubItems.Add(info.DirectoryName);
                            item.SubItems.Add(info.Length.ToString());
                            item.SubItems.Add(info.LastWriteTime.ToString("dd.MM.yyyy H:mm:ss"));
                            listView1.Items.Add(item);
                        }));

                        label1.Invoke((Action)(() =>
                            label1.Text = $"Результати пошуку: кількість знайдених файлів - {count}"));
                    }
                }
                catch { }

                if (subdirs)
                {
                    try
                    {
                        foreach (var subDir in Directory.EnumerateDirectories(dir))
                        {
                            if (token.IsCancellationRequested) return;
                            SearchDir(subDir);
                        }
                    }
                    catch { }
                }
            }

            SearchDir(root);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
            pts.IsPaused = false;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            pts.IsPaused = !pts.IsPaused;
            btnPause.Text = pts.IsPaused ? "Відновити" : "Призупинити";
        }
    }

    public class PauseTokenSource
    {
        private ManualResetEventSlim mres = new ManualResetEventSlim(true);

        public bool IsPaused
        {
            get => !mres.IsSet;
            set
            {
                if (value) mres.Reset();
                else mres.Set();
            }
        }

        public PauseToken Token => new PauseToken(mres);
    }

    public class PauseToken
    {
        private readonly ManualResetEventSlim mres;
        public PauseToken(ManualResetEventSlim mres) => this.mres = mres;
        public void WaitWhilePaused() => mres.Wait();
    }
}

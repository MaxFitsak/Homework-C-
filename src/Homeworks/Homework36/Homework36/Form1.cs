using System.Diagnostics;

namespace Homework36
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            listBox1.Items.Clear();
            var processes = Process.GetProcesses();
            Array.Sort(processes, (a, b) => string.Compare(a.ProcessName, b.ProcessName));

            foreach (var proc in processes)
            {
                listBox1.Items.Add($"{proc.ProcessName}.exe - {proc.Id}");
            }
        }

        // Кнопка "Оновити список"
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        // Кнопка "Завершити процес"
        private void btnKill_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Виберіть процес зі списку!", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Парсимо PID з рядка "ProcessName.exe - 1234"
            string selected = listBox1.SelectedItem.ToString();
            string[] parts = selected.Split('-');

            if (parts.Length < 2 || !int.TryParse(parts[1].Trim(), out int pid))
            {
                MessageBox.Show("Не вдалося отримати PID процесу.", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Process proc = Process.GetProcessById(pid);
                string procName = proc.ProcessName;

                var result = MessageBox.Show(
                    $"Завершити процес {procName} (PID: {pid})?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    proc.Kill();
                    proc.WaitForExit(3000);
                    MessageBox.Show($"Процес {procName} завершено.", "Готово",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProcesses(); // Оновлюємо список
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Процес вже не існує.", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка "Запустити процес"
        private void btnStart_Click(object sender, EventArgs e)
        {
            string path = txtProcessPath.Text.Trim();

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Введіть шлях або ім'я процесу!", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Process.Start(path);
                LoadProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося запустити: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


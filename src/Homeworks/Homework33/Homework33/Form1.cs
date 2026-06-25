namespace Homework33
{
    public partial class Form1 : Form
    {
        private Semaphore semaphore;
        private int threadCount = 0;
        private int semaphoreCount = 3;
        private object lockObj = new object();

        public Form1()
        {
            InitializeComponent();
            semaphore = new Semaphore(semaphoreCount, semaphoreCount);
            numericUpDown1.Value = semaphoreCount;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
        }

        

        private void ThreadWork(int id)
        {
            string name = $"Потік {id}";

            listBox3.Invoke((Action)(() =>
                RemoveFromList(listBox3, name)));
            listBox2.Invoke((Action)(() =>
                listBox2.Items.Add($"{name} -> чекає")));

            semaphore.WaitOne();

            listBox2.Invoke((Action)(() =>
                RemoveFromList(listBox2, name)));

            int counter = 0;
            string workItem = $"{name} -> {counter}";

            listBox1.Invoke((Action)(() =>
                listBox1.Items.Add(workItem)));

            while (true)
            {
                Thread.Sleep(1000);
                counter++;

                listBox1.Invoke((Action)(() =>
                {
                    int idx = FindIndex(listBox1, name);
                    if (idx >= 0)
                        listBox1.Items[idx] = $"{name} -> {counter}";
                    else
                        return;
                }));

                bool stillRunning = false;
                listBox1.Invoke((Action)(() =>
                    stillRunning = FindIndex(listBox1, name) >= 0));

                if (!stillRunning) break;
            }

            semaphore.Release();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            lock (lockObj) threadCount++;
            int id = threadCount;
            string name = $"Потік {id}";

            listBox3.Items.Add($"{name} -> створений");
        }

        private void listBox3_DoubleClick(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem == null) return;

            string item = listBox3.SelectedItem.ToString();
            listBox3.Items.Remove(listBox3.SelectedItem);

            string name = item.Split('-')[0].Trim();
            int id = int.Parse(name.Split(' ')[1]);

            Thread t = new Thread(() => ThreadWork(id));
            t.IsBackground = true;
            t.Name = name;
            t.Start();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int newCount = (int)numericUpDown1.Value;

            if (newCount > semaphoreCount)
            {
                int diff = newCount - semaphoreCount;
                try
                {
                    semaphore.Release(diff);
                }
                catch { }
            }
            else if (newCount < semaphoreCount)
            {
                int diff = semaphoreCount - newCount;
                listBox1.Invoke((Action)(() =>
                {
                    for (int i = 0; i < diff && listBox1.Items.Count > 0; i++)
                        listBox1.Items.RemoveAt(0);
                }));
            }

            semaphore = new Semaphore(newCount, newCount);
            semaphoreCount = newCount;
        }

        private void RemoveFromList(ListBox lb, string name)
        {
            for (int i = lb.Items.Count - 1; i >= 0; i--)
                if (lb.Items[i].ToString().StartsWith(name))
                    lb.Items.RemoveAt(i);
        }

        private int FindIndex(ListBox lb, string name)
        {
            for (int i = 0; i < lb.Items.Count; i++)
                if (lb.Items[i].ToString().StartsWith(name))
                    return i;
            return -1;
        }
    }
}

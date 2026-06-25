namespace Homework28
{
    public partial class Form1 : Form
    {
        private Thread[] threads = new Thread[3];
        private ManualResetEventSlim[] pauseEvents = new ManualResetEventSlim[3];
        private bool[] running = new bool[3];
        private Random rnd = new Random();

        ProgressBar[] bars;
        CheckBox[] chkStart, chkPause;

        public Form1()
        {
            InitializeComponent();

            bars = new ProgressBar[] { progressBar1, progressBar2, progressBar3 };
            chkStart = new CheckBox[] { chkStart1, chkStart2, chkStart3 };
            chkPause = new CheckBox[] { chkPause1, chkPause2, chkPause3 };

            for(int i = 0; i < 3; i++)
            {
                pauseEvents[i] = new ManualResetEventSlim(true);
            }
        }

        private void chkStart_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            int idx = Array.IndexOf(chkStart, chk);

            if (chk.Checked)
            {
                StartThread(idx);
            }
            else
            {
                StopThread(idx);
            }
        }

        private void StartThread(int idx)
        {
            if (running[idx]) return;

            running[idx] = true;
            pauseEvents[idx].Set();

            int i = idx;
            threads[i] = new Thread(() =>
            {
                while (running[i])
                {
                    pauseEvents[i].Wait();

                    int val = rnd.Next(0, 101);

                    bars[i].Invoke((Action)(() => bars[i].Value = val));

                    Thread.Sleep(rnd.Next(100, 500));
                }

                bars[i].Invoke((Action)(() => bars[i].Value = 0));
            });

            threads[i].IsBackground = true;
            threads[i].Start();
        }

        private void StopThread(int idx)
        {
            running[idx] = false;
            pauseEvents[idx].Set();
        }

        private void chkPause_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            int idx = Array.IndexOf(chkPause, chk);

            if (chk.Checked)
            {
                pauseEvents[idx].Reset(); 
            }
            else
            {
                pauseEvents[idx].Set();  
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < 3; i++)
                StopThread(i);
        }
    }
}


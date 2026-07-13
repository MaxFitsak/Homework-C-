using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DataTimeServerUDP
{
    public partial class Form1 : Form
    {
        private UdpClient udpClient;
        private IPEndPoint serverEndPoint;
        private Thread receiveThread;
        private bool isConnected = false;
        private const int ServerPort = 5001;

        public Form1()
        {
            InitializeComponent();
            btnDisconnect.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (isConnected) return;

            try
            {
                string ipAddress = txtServerIp.Text.Trim();
                serverEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), ServerPort);

                udpClient = new UdpClient(0);

                byte[] data = Encoding.UTF8.GetBytes("CONNECT");
                udpClient.Send(data, data.Length, serverEndPoint);

                isConnected = true;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                txtServerIp.Enabled = false;

                receiveThread = new Thread(ReceiveTime);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка підключення: {ex.Message}");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectFromServer();
        }

        private void ReceiveTime()
        {
            while (isConnected)
            {
                try
                {
                    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedBytes = udpClient.Receive(ref remoteEP);
                    string serverTime = Encoding.UTF8.GetString(receivedBytes);

                    if (lblTime.InvokeRequired)
                    {
                        lblTime.Invoke(new MethodInvoker(delegate { lblTime.Text = serverTime; }));
                    }
                    else
                    {
                        lblTime.Text = serverTime;
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        private void DisconnectFromServer()
        {
            if (!isConnected) return;

            try
            {
                byte[] data = Encoding.UTF8.GetBytes("DISCONNECT");
                udpClient.Send(data, data.Length, serverEndPoint);
            }
            catch { }

            isConnected = false;
            udpClient?.Close();

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            txtServerIp.Enabled = true;
            lblTime.Text = "--:--:--";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DisconnectFromServer();
            base.OnFormClosing(e);
        }
    }
}
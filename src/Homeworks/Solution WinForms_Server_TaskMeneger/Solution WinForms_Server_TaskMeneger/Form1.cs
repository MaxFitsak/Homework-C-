using ClassLibrarySerialization;
using CLibraryMyCommand;        
using CLibraryMyProcess;
using System.Net;
using System.Net.Sockets;


namespace Solution_WinForms_Server_TaskMeneger
{
    public partial class Form1 : Form
    {
        private Socket clientSocket;
        private Serialization_Deserialization serializer = new Serialization_Deserialization();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientSocket != null && clientSocket.Connected) return;

                string ipAddress = txtIpAddress.Text.Trim();
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), 8888);

                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                await clientSocket.ConnectAsync(ipEndPoint);

                btnConnect.Text = "Підключено";
                btnConnect.BackColor = System.Drawing.Color.LightGreen;
                MessageBox.Show("Успішне підклчення");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка підключення " + ex.Message);
                clientSocket = null;
            }
        }

        private async void btnGetProcesses_Click(object sender, EventArgs e)
        {
            if (clientSocket == null || !clientSocket.Connected)
            {
                MessageBox.Show("Спочатку підклюітся до сервера");
                return;
            }

            try
            {
                CMyCommand command = new CMyCommand { NameOfCommand = "ListProcess" };
                byte[] requestBytes = serializer.SerializeObject<CMyCommand>(command);

                await clientSocket.SendAsync(new ArraySegment<byte>(requestBytes), SocketFlags.None);

                byte[] buffer = new byte[262144];
                int bytesRec = await clientSocket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);

                if (bytesRec > 0)
                {
                    List<CMyProcess> receivedProcesses = serializer.DeserializeObject<List<CMyProcess>>(buffer, bytesRec);
                    listBoxProcesses.Items.Clear();
                    foreach (var process in receivedProcesses)
                    {
                        listBoxProcesses.Items.Add($"{process.Name} (ID: {process.ProcessId})");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка обновлення: {ex.Message}");
            }
        }

        private async void btnKillProcess_Click(object sender, EventArgs e)
        {
            if (listBoxProcesses.SelectedItem == null)
            {
                MessageBox.Show("Виберіть процесс із списку");
                return;
            }

            if (clientSocket == null || !clientSocket.Connected)
            {
                MessageBox.Show("Спочатку підключіться до серверу");
                return;
            }

            try
            {
                string selectedItem = listBoxProcesses.SelectedItem.ToString();
                int idStart = selectedItem.IndexOf("ID: ") + 4;
                int idEnd = selectedItem.IndexOf(")");
                string idStr = selectedItem.Substring(idStart, idEnd - idStart);
                int processId = int.Parse(idStr);

                CMyCommand command = new CMyCommand
                {
                    NameOfCommand = "KillProcess",
                    IDProcess = processId
                };

                byte[] requestBytes = serializer.SerializeObject<CMyCommand>(command);
                await clientSocket.SendAsync(new ArraySegment<byte>(requestBytes), SocketFlags.None);

                // Никаких ReceiveAsync! Сервер просто убьет процесс у себя.
                MessageBox.Show($"Команда на процесса ID {processId} успішно відправлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCreateProcess_Click(object sender, EventArgs e)
        {
            if (clientSocket == null || !clientSocket.Connected) return;

            try
            {
                CMyCommand command = new CMyCommand
                {
                    NameOfCommand = "CreateProcess",
                    Path = txtProcessPath.Text.Trim()
                };

                byte[] requestBytes = serializer.SerializeObject<CMyCommand>(command);
                await clientSocket.SendAsync(new ArraySegment<byte>(requestBytes), SocketFlags.None);

                txtProcessPath.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;

namespace TimeServerConsole
{
    class Program
    {
        private const int Port = 5001;
        private static UdpClient udpServer;
        private static HashSet<IPEndPoint> connectedClients = new HashSet<IPEndPoint>();
        private static System.Timers.Timer timer;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            udpServer = new UdpClient(Port);
            Console.WriteLine($"[СЕРВЕР] Очікування клієнтів...");

            timer = new System.Timers.Timer(2000);
            timer.Elapsed += BroadcastTime;
            timer.Start();

            while (true)
            {
                try
                {
                    IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedBytes = udpServer.Receive(ref clientEndPoint);
                    string message = Encoding.UTF8.GetString(receivedBytes).Trim();

                    string dnsName = "Невідомо";
                    try { dnsName = Dns.GetHostEntry(clientEndPoint.Address).HostName; } catch { }

                    if (message == "CONNECT")
                    {
                        if (!connectedClients.Contains(clientEndPoint))
                        {
                            connectedClients.Add(clientEndPoint);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"[ПІДКЛЮЧЕННЯ] {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                            Console.WriteLine($"Клієнт: {clientEndPoint.Address}:{clientEndPoint.Port}");
                            Console.WriteLine($"ім'я кліента: {dnsName}");
                            Console.ResetColor();
                        }
                    }
                    else if (message == "DISCONNECT")
                    {
                        if (connectedClients.Contains(clientEndPoint))
                        {
                            connectedClients.Remove(clientEndPoint);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[ВІДКЛЮЧЕННЯ] {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                            Console.WriteLine($"Клієнт: {clientEndPoint.Address}:{clientEndPoint.Port}");
                            Console.WriteLine($"ім'я кліента: {dnsName}");
                            Console.ResetColor();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ПОМИЛКА] {ex.Message}");
                }
            }
        }

        private static void BroadcastTime(object sender, ElapsedEventArgs e)
        {
            if (connectedClients.Count == 0) return;

            string timeMessage = DateTime.Now.ToString("HH:mm:ss");
            byte[] data = Encoding.UTF8.GetBytes(timeMessage);
            data = Encoding.UTF8.GetBytes(timeMessage);

            lock (connectedClients)
            {
                var clients = new List<IPEndPoint>(connectedClients);
                foreach (var client in clients)
                {
                    try
                    {
                        udpServer.Send(data, data.Length, client);
                    }
                    catch
                    {
                        connectedClients.Remove(client);
                    }
                }
            }
        }
    }
}
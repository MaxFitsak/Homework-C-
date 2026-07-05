using ClassLibrarySerialization;
using CLibraryMyProcess;
using CLibraryMyCommand;
using System.Runtime.CompilerServices;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading.Tasks; 

public class MainClass
{
    public static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("-Server- Працує");

        MainClass server = new MainClass();
        server.Accept();
        await Task.Delay(-1);
    }
    public async Task Accept()
    {
        try
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 8888);
            Socket sListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            sListener.Bind(ipEndPoint);
            sListener.Listen(10);

            while (true)
            {
                Socket handler = await sListener.AcceptAsync();
                Console.WriteLine("-Server- Клиент підлючився");

                _ = Task.Run(() => HandleClientAsync(handler));
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ResetColor();
        }
    }

    private async Task HandleClientAsync(Socket handler)
    {
        var serialize = new Serialization_Deserialization();
        byte[] bytes = new byte[11654];

        try
        {
            while (true)
            {
                int bytesRec = await handler.ReceiveAsync(new ArraySegment<byte>(bytes), SocketFlags.None);

                if (bytesRec == 0)
                {
                    Console.WriteLine("-Server- Клиент розірвав зеднання");
                    break;
                }

                CMyCommand myCommand = serialize.DeserializeObject<CMyCommand>(bytes, bytesRec);
                Console.WriteLine($"-Server- Получена команда: {myCommand.NameOfCommand}");

                switch (myCommand.NameOfCommand)
                {
                    case "ListProcess":
                        Process[] winProcesses = Process.GetProcesses();
                        List<CMyProcess> processList = new List<CMyProcess>();
                        foreach (var p in winProcesses)
                        {
                            processList.Add(new CMyProcess { ProcessId = p.Id, Name = p.ProcessName });
                        }

                        byte[] responseBytes = serialize.SerializeObject(processList);
                        await handler.SendAsync(new ArraySegment<byte>(responseBytes), SocketFlags.None);
                        break;

                    case "CreateProcess":
                        try
                        {
                            Process.Start(myCommand.Path);
                            Console.WriteLine("-Server- Запущен процесс: " + myCommand.Path);
                        }
                        catch (Exception ex) { Console.WriteLine("-Server- Помилка запуска: " + ex.Message); }
                        break;

                    case "KillProcess":
                        try
                        {
                            Process processToKill = Process.GetProcessById(myCommand.IDProcess);
                            processToKill.Kill();
                            Console.WriteLine("-Server- процесс видаленно ID: " + myCommand.IDProcess);
                        }
                        catch (Exception ex) { Console.WriteLine("-Server- Помилка видалення: " + ex.Message); }
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-Server- помилка роботи з клієнтом " + ex.Message);
            Console.ResetColor();
        }
        finally
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            Console.WriteLine("-Server- Сокет клиента повнісью вивельно");
        }
    }
}
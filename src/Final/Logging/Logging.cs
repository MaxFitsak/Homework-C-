using System;
using System.IO;
using Interfaces;

namespace Logging;

public class ConsoleLog : ILog
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}

public class FileLog : ILog
{
    private string _logFilePath;

    public FileLog(string logFilePath = "log.txt")
    {
        _logFilePath = logFilePath;
    }

    public void Print(string text)
    {
        try
        {
            File.AppendAllText(_logFilePath, text + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка запису в лог-файл: {ex.Message}");
        }
    }
}
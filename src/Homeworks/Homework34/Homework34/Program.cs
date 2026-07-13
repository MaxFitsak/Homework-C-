using System;
using System.IO;
using System.Threading;

class Program
{
    private static readonly Mutex mutex1 = new Mutex();
    private static readonly Mutex mutex2 = new Mutex();

    static string file1 = "numbers.txt";
    static string file2 = "primes.txt";
    static string file3 = "primes_ending7.txt";

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Thread t1 = new Thread(Thread1_GenerateNumbers);
        Thread t2 = new Thread(Thread2_FilterPrimes);
        Thread t3 = new Thread(Thread3_FilterEnding7);

        t1.Start();
        Thread.Sleep(20);

        t2.Start();
        Thread.Sleep(20);

        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        mutex1.Dispose();
        mutex2.Dispose();

        Console.WriteLine("Всі потоки завершили роботу");
        Console.ReadKey();
    }

    static void Thread1_GenerateNumbers()
    {
        mutex1.WaitOne();
        try
        {
            Console.WriteLine("|Потік 1| Старт генерація чисел");
            Random rnd = new Random();
            int count = 50;

            using (StreamWriter sw = new StreamWriter(file1))
                for (int i = 0; i < count; i++)
                    sw.WriteLine(rnd.Next(1, 500));

            Console.WriteLine("|Потік 1| Завершено.");
        }
        finally
        {
            mutex1.ReleaseMutex();
        }
    }

    static void Thread2_FilterPrimes()
    {
        Console.WriteLine("|Потік 2| Очікування Потоку 1");

        mutex1.WaitOne();

        mutex2.WaitOne();

        try
        {
            Console.WriteLine("|Потік 2| Старт фільтрація простих чисел");
            var lines = File.ReadAllLines(file1);

            using (StreamWriter sw = new StreamWriter(file2))
                foreach (var line in lines)
                    if (int.TryParse(line.Trim(), out int num) && IsPrime(num))
                        sw.WriteLine(num);

            Console.WriteLine($"|Потік 2| Завершено.");
        }
        finally
        {
            mutex2.ReleaseMutex();
            mutex1.ReleaseMutex();
        }
    }

    static void Thread3_FilterEnding7()
    {
        Console.WriteLine("|Потік 3| Очікування Потоку 2");

        mutex2.WaitOne();

        try
        {
            Console.WriteLine("|Потік 3| Старт фільтрація чисел на 7");
            var lines = File.ReadAllLines(file2);

            using (StreamWriter sw = new StreamWriter(file3))
                foreach (var line in lines)
                    if (int.TryParse(line.Trim(), out int num) && num % 10 == 7)
                        sw.WriteLine(num);

            Console.WriteLine("|Потік 3| Завершено.");
        }
        finally
        {
            mutex2.ReleaseMutex();
        }
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
        for (int i = 3; i * i <= n; i += 2)
            if (n % i == 0) return false;
        return true;
    }
}
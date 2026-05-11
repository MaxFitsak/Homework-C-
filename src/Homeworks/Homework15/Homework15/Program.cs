using System.Text;

namespace Tamagochi;

class Tamogochi
{
    public delegate void TamagochiHeadler(string message);

    public event TamagochiHeadler OnAlarm;

    public int Healthy { get; set; }

    public Tamogochi()
    {
        Healthy = 100;
    }

    public void Eat()
    {
        Console.WriteLine("Покормити Тамогочі? Y-yes N-no");
        char select = char.Parse(Console.ReadLine());
        if (select == 'Y' || select == 'y')
        {
            if(Healthy < 100)
            {
                Healthy += 33;
            }
            OnAlarm?.Invoke("Тамогочі покормлено");
        }
        else if(select == 'N' || select == 'n')
        {
            Healthy -= 33;
            OnAlarm?.Invoke("Тамогочі голодний");
        }
    }

    public void Walk()
    {
        Console.WriteLine("Погуляти з Тамогочі? Y-yes N-no");
        char select = char.Parse(Console.ReadLine());
        if (select == 'Y' || select == 'y')
        {
            if (Healthy < 100)
            {
                Healthy += 33;
            }
            OnAlarm?.Invoke("Тамогочі Вигуляно");
        }
        else if (select == 'N' || select == 'n')
        {
            Healthy -= 33;
            OnAlarm?.Invoke("Тамогочі Хоче гуляти");
        }
    }

    public void Sleep()
    {
        Console.WriteLine("Покласти спати тамогочі? Y-yes N-no");
        char select = char.Parse(Console.ReadLine());
        if (select == 'Y' || select == 'y')
        {
            if (Healthy < 100)
            {
                Healthy += 33;
            }
            OnAlarm?.Invoke("Тамогочі виспався");
        }
        else if (select == 'N' || select == 'n')
        {
            Healthy -= 33;
            OnAlarm?.Invoke("Тамогочі сонний");
        }
    }

    public bool Treat()
    {
        Print();
        Console.WriteLine("Тамочогі Захворів полікувати? Y-yes N-no");
        char select = char.Parse(Console.ReadLine());
        if (select == 'Y' || select == 'y')
        {
                Healthy = 100;
            OnAlarm?.Invoke("Тамогочі виліковано");
            return false;
        }
        else if (select == 'N' || select == 'n')
        {
            Healthy = 0;
            OnAlarm?.Invoke("Тамогочі Вмер");
            Dead();
            return true;
        }
        return true;
    }

    public void Play()
    {
        Console.WriteLine("Погратися з тамогочі? Y-yes N-no");
        char select = char.Parse(Console.ReadLine());
        if (select == 'Y' || select == 'y')
        {
            if (Healthy < 100)
            {
                Healthy += 33;
            }
            OnAlarm?.Invoke("Тамогочі награвся");
        }
        else if (select == 'N' || select == 'n')
        {
            Healthy -= 33;
            OnAlarm?.Invoke("Тамогочі хоче гратися");
        }
    }

    private void PrintHappy()
    {
        Console.WriteLine(" .------.");
        Console.WriteLine(" / ^ ^ \\");
        Console.WriteLine("| (^ ^) |");
        Console.WriteLine("|  \\__/ |");
        Console.WriteLine(" \\ ~~~ /");
        Console.WriteLine("  /| |\\");
        Console.WriteLine(" / | | \\");

    }

    private void PrintNeutral()
    {
        Console.WriteLine(" .------.");
        Console.WriteLine(" / - - \\");
        Console.WriteLine("| (o o) |");
        Console.WriteLine("| ~~~~ |");
        Console.WriteLine("\\ ~~~~ /");
        Console.WriteLine("'------'");
        Console.WriteLine(" /| |\\");
        Console.WriteLine("/ | | \\");
    }

    private void PrintSad()
    {
        Console.WriteLine(".------.");
        Console.WriteLine(" / - - \\");
        Console.WriteLine("| (- -) |");
        Console.WriteLine(" | ___ |");
        Console.WriteLine(" \\ ~~~ /");
        Console.WriteLine("'------'");
        Console.WriteLine(" /| |\\");
        Console.WriteLine("/ | | \\");
    }

    private void Dead()
    {
        Console.WriteLine(".------.");
        Console.WriteLine(" / x x \\");
        Console.WriteLine("| (X X) |");
        Console.WriteLine(" | ___ |");
        Console.WriteLine("  \\ /");
        Console.WriteLine("'------'");
        Console.WriteLine("  | |");
        Console.WriteLine("  | |");
    }

    public void DrawStatus()
    {
        Console.Write("Здоровье: [");

        if (Healthy > 70) Console.ForegroundColor = ConsoleColor.Green;
        else if (Healthy > 34) Console.ForegroundColor = ConsoleColor.Yellow;
        else Console.ForegroundColor = ConsoleColor.Red;

        int filled = Healthy / 10;
        for (int i = 0; i < 10; i++)
        {
            Console.Write(i < filled ? "■" : " ");
        }

        Console.ResetColor();
        Console.WriteLine($"] {Healthy}%");
    }

    public void Print()
    {
        DrawStatus();
        if (Healthy > 67)
        {
            PrintHappy();            
        }
        else if(Healthy > 34)
        {
            PrintNeutral();
        }
        else if(Healthy > 0)
        {
            PrintSad();
        }

    }
}

class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Tamogochi tamagochi = new Tamogochi();
        Random select = new Random();
        int memory = 0;

        while (true)
        {
            Console.Clear();

            if (tamagochi.Healthy == 1)
            {
                bool IsDead = tamagochi.Treat();
                if (IsDead)
                {
                    return;
                }
            }

            int random = select.Next(1, 4);
            if(random != memory)
            {
                memory = random;
                switch (random)
                {
                    case 1:
                        tamagochi.Print();
                        tamagochi.Eat();
                        break;
                    case 2:
                        tamagochi.Print();
                        tamagochi.Walk();
                        break;
                    case 3:
                        tamagochi.Print();
                        tamagochi.Sleep();
                        break;
                    case 4:
                        tamagochi.Print();
                        tamagochi.Play();
                        break;

                }

                Thread.Sleep(3500);
            }

        }
    }
}
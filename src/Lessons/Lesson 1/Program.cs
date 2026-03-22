class Lesson
{
    static void Main()
    {
        // first task
        Console.WriteLine("Enter 5 numbers -> ");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());
        int num4 = int.Parse(Console.ReadLine());
        int num5 = int.Parse(Console.ReadLine());

        Console.WriteLine("Sum of numbers: " + (num1 + num2 + num3 + num4 + num5));
        int min = num1; 
        int max = num1;
        if (num2 < min)
        {
            min = num2;
        }
        if (num3 < min)
        {
            min = num3;
        }
        if (num4 < min)
        {
            min = num4;
        }
        if (num5 < min)
        {
            min = num5;
        }
        if (num2 > max)
        {
            max = num2;
        }
        if (num3 > max)
        {
            max = num3;
        }
        if (num4 > max)
        {
            max = num4;
        }
        if (num5 > max)
        {
            max = num5;
        }
        Console.WriteLine("Max -> " + max + " Min -> " + min);
        //second task
        Console.WriteLine("Enter number -> ");
        int number = int.Parse(Console.ReadLine());
        int result = 0;
        int memory = number;

        while (memory > 0)
        {
            int num = memory % 10;
            result = result * 10 + num;
            memory = memory / 10;
        }
        Console.WriteLine("Result ->" + result);
        //third task
        Console.WriteLine("Enter Lenght and vertical or horizontal");
        int Lenght = int.Parse(Console.ReadLine());
        string direction = Console.ReadLine();
        switch (direction)
        {
            case("Horizontal"):
            case("horizontal"):
                for (int i = 0; i < Lenght; i++)
                {
                    Console.Write("+");
                }
                break;
            case("Vertical"):
            case("vertical"):
                for (int i = 0; i < Lenght; i++)
                {
                    Console.WriteLine("+");
                }
                break;    
            default:
                Console.WriteLine("Error");
                break;
        }
    }
}

class Homework1_1
{
    static void Main()
    {   
        //first task    
        try
        {
        Console.Write("Enter your nubmer with 6 numbers -> ");
        string number = Console.ReadLine();

        if (number.Length != 6)
        {
            Console.WriteLine("Error: your number size isn't 6");
            return;
        }

        Console.WriteLine("Enter first and second number for switch -> ");
        
        int switchNumber1 = int.Parse(Console.ReadLine());
        int switchNumber2 = int.Parse(Console.ReadLine());

        string result = "";
        for (int i = 0; i < 6; i++)
        {
            if (i == switchNumber1 - 1)
            {
                result += number[switchNumber2 - 1];
            }
            else if (i == switchNumber2 - 1)
            {
                result += number[switchNumber1 - 1];
            }
            else
            {
                result += number[i];
            }   
        }
        Console.WriteLine(result);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        //second task
        try
        {
            Console.WriteLine("Enter number -> ");
            int number = int.Parse(Console.ReadLine());

            int sum = 0;

            if (number > 1)
            {
                sum = 1;

                for (int i = 2; i * i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        sum += i;
                        int mem = number / i;
                        if (mem != i)
                        {
                            sum += mem;
                        }
                    }
                }
            }

            if (number > 1 && sum == number)
            {
                Console.WriteLine("Is Perfect");
            }
            else
            {
                Console.WriteLine("Is not perfect");
            }
        }
        catch (Exception ex)
        {
            
            Console.WriteLine(ex.Message);
        }
        //third task
        try
        {
            Console.WriteLine("Enter number -> ");
            int numbeForThirdTask = int.Parse(Console.ReadLine());

            int reversedNumber = 0;
            int temp = numbeForThirdTask;

            while (temp > 0)
            {
                int lastDigit = temp % 10;
                reversedNumber = (reversedNumber * 10) + lastDigit;
                temp /= 10;
            }

            if (numbeForThirdTask == reversedNumber)
            {
                Console.WriteLine("Is Polindrome");
            }
            else
            {
                Console.WriteLine("Is not polindrome");
            }
        }
        catch (Exception ex)
        {
            
            Console.WriteLine(ex.Message);
        }
        Console.Read();
    }
}


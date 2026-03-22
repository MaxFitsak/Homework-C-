class Homework2
{
    static void Main()
    {
        //task 1
        try
        {
            Console.Write("Enter number -> ");
            string input = Console.ReadLine();
            int number = int.Parse(input);
            
            int length = input.Length; 
            int temp = number;         
            int sum = 0;         

            while (temp > 0)
            {
                int digit = temp % 10;
                sum += (int)Math.Pow(digit, length);
                temp /= 10;
            }

            if (sum == number)
            {
                Console.WriteLine("is Armstrong number");
            }
            else
            {
                Console.WriteLine("is not Armstrong number");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        // task 2
        try
        {
            int maxLen = 1;      
            int currentLen = 1; 
            int bestStart = 1;   
            int currentStart = 1;

            Console.WriteLine("Enter 15 numbers ->");

            int memory = int.Parse(Console.ReadLine());

            for (int i = 2; i <= 15; i++)
            {
                int current = int.Parse(Console.ReadLine());

                if (current >= memory)
                {
                    currentLen++;
                }
                else
                {
                    if (currentLen > maxLen)
                    {
                        maxLen = currentLen;
                        bestStart = currentStart;
                    }

                    currentLen = 1;
                    currentStart = i;
                }

                memory = current;
            }

            if (currentLen > maxLen)
            {
                maxLen = currentLen;
                bestStart = currentStart;
            }

            Console.WriteLine("Max len -> " + maxLen);
            Console.WriteLine("Start Number -> " + bestStart);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}

using System.Net.Security;

class Homework3
{
    static void Main()
    {
        //Task 1
        try
        {
            int[] arr = new int[10];
            Random r = new();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(0, 5);
            }

            Console.WriteLine("Start array:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine(); 

            Console.WriteLine("Second array:");
            int[] result = new int[10];
            int count = 0;
            int resultIndex = 0; 

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    count++;        
                }
                else
                {
                    result[resultIndex] = arr[i]; 
                    resultIndex++;
                }
            }

            if (count > 0)
            {
                for (int i = result.Length - count; i < result.Length; i++)
                {
                    result[i] = -1;
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
            Console.WriteLine();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        //task 2
        try
        {
            Console.Write("Введіть непарне число: ");
            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine("Це не парне число!");
                return;
            }

            int[,] matrix = new int[number, number];

            int row = number / 2;
            int col = row;
            int value = 1;
            matrix[row, col] = value++;

            int step = 1;

            while (value <= number * number)
            {
                // Верх
                for (int i = 0; i < step && value <= number * number; i++)
                {
                    row--;
                    matrix[row, col] = value++;
                }

                // Вліво
                for (int i = 0; i < step && value <= number * number; i++)
                {
                    col--;
                    matrix[row, col] = value++;
                }
                
                step++;

                // Вниз
                for (int i = 0; i < step && value <= number * number; i++)
                {
                    row++;
                    matrix[row, col] = value++;
                }

                // Впрво
                for (int i = 0; i < step && value <= number * number; i++)
                {
                    col++;
                    matrix[row, col] = value++;
                }
                
                step++;
            }

            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    Console.Write($"{matrix[i, j], 4}");
                }
                Console.WriteLine();
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }

        //task 3
        try
        {
            Console.WriteLine("Введіть кількість рядків: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть кількість стовпців: ");
            int m = int.Parse(Console.ReadLine());

            int[,] arr = new int[n,m];
            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i,j] = r.Next(0,100);
                    Console.Write($"{arr[i,j], 3}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Введіть кількість зсувів -> ");
            int shift = int.Parse(Console.ReadLine());
            Console.WriteLine("Напярмок (1 - вправо, 2 - вліво)");
            int direction = int.Parse(Console.ReadLine());

            int[,] result = new int[n,m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int newCol;
                    if(direction == 1)
                    {
                        newCol = (j + shift) % m;
                    }
                    else
                    {
                        newCol = (j - shift + m) % m;
                    }
                    result[i , newCol] = arr[i,j];
                }
            }

            Console.WriteLine("\nПісля зсуву ->");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{result[i,j],3}");
                }
                Console.WriteLine();
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
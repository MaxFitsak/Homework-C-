using System;

class Lesson
{
    static void Main()
    {
        //task 1
        try
        {
            int[] arr = new int[20];
            Random randomNumber = new();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randomNumber.Next(1, 21);
                Console.Write("{0,4}", arr[i]);
            }
            Console.WriteLine("");

            int odd = 0;
            int paired = 0;
            int unique = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0) paired++;
                else odd++;

                bool isUnique = true;
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique) unique++;
            }

            Console.WriteLine("Paired -> " + paired + " Odd -> " + odd + " Unique -> " + unique);
            Console.WriteLine("");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        //task 2
        try
        {
            int[] arrForTaskSecond = new int[20];
            Random randomNumber = new();
            int result = 0;

            for (int i = 0; i < arrForTaskSecond.Length; i++)
            {
                arrForTaskSecond[i] = randomNumber.Next(-30, 11);
                Console.Write("{0,4}", arrForTaskSecond[i]);
            }
            Console.WriteLine("");

            for (int i = 0; i < arrForTaskSecond.Length; i++)
            {
                if (arrForTaskSecond[i] <= 0)
                {
                    result += arrForTaskSecond[i];
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Result -> " + result);
            Console.WriteLine("");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        // завдання 3
        try
        {
            int[,] arr = new int[5, 5];
            Random randomNumber = new();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = randomNumber.Next(-10, 41);
                    Console.Write("{0,4}", arr[i, j]);
                }
                Console.WriteLine();
            }

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                int columnSum = 0;
                bool hasNegative = false;

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (arr[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                    columnSum += arr[i, j];
                }

                if (!hasNegative)
                {
                    Console.Write("{0,4}", columnSum);
                }
            }
            Console.WriteLine("\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
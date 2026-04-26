using System.Text;

namespace Task
{
    class Task1
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            try
            {
                Console.WriteLine("Введіть слово яке треба поміняти: ");
                string TextForChache = Console.ReadLine();

                Console.WriteLine("Ввеідть на яке слово треба поміняти?:");
                string text = Console.ReadLine();

                Console.WriteLine("Введіть шлях до файлу: ");
                string filename = Console.ReadLine();

                StreamReader sr = new StreamReader(filename, Encoding.Default);
                StreamWriter sw = new StreamWriter("Change.txt", true, Encoding.Default);

                string line;
                int result = 0;
                while((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string[] words = line.Split(' ');
                    for (int i = 0; i < words.Length; i++)
                    {
                        if(words[i] == TextForChache)
                        {
                            words[i] = text;
                            result++;
                        }

                    }
                    string write = string.Join(" ", words);
                    sw.WriteLine(write);
                    Thread.Sleep(200);
                }
                if (result == 0)
                {
                    Console.WriteLine("Не було слів щоб їх поміняти");
                }
                else
                {
                    Console.WriteLine("Було поміняно слів: {0}", result);
                }
                sw.Close();
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            //task 2
            try
            {
                Console.WriteLine("Введіть шлях до файду з словами для модерації: ");
                string fileModeration = Console.ReadLine();
                Console.WriteLine("Введіть щлях до файлу з текстом:");
                string fileText = Console.ReadLine();


                string rawModText = File.ReadAllText(fileModeration);

                string[] badWords = rawModText.Split(new char[]{' ', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                
                string mainText = File.ReadAllText(fileText);

                foreach (string badWord in badWords)
                {
                    string stars = new string('*', badWord.Length);
                    mainText = mainText.Replace(badWord, stars);
                }

                Console.WriteLine("Результат модерації");
                Console.WriteLine(mainText);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //task 3

            try
            {
                Console.WriteLine("Будь ласка введіть шлях до файлу: ");
                string file = Console.ReadLine();

                string result = File.ReadAllText(file);
                string writeFile = new string(result.Reverse().ToArray());


                File.WriteAllText("Reversed.txt", writeFile);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //task 4
            try
            {
                Console.WriteLine("Будь ласка введіть шлях до файлу: ");
                string file = Console.ReadLine();

                string openFile = File.ReadAllText(file);

                string[] tempStrings = openFile.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int[] numbers = new int[tempStrings.Length];

                for (int i = 0; i < tempStrings.Length; i++)
                {
                    numbers[i] = int.Parse(tempStrings[i]);
                }

                int fiveDigit = 0;
                int twoDigit = 0;
                int plus = 0;
                int minus = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (Math.Abs(numbers[i]) >= 10000 && Math.Abs(numbers[i]) <= 99999)
                    {
                        fiveDigit++;
                        File.AppendAllText("fiveDigit.txt", numbers[i].ToString() + " ");
                    }
                    if (Math.Abs(numbers[i]) >= 10 && Math.Abs(numbers[i]) <= 99)
                    {
                        twoDigit++;
                        File.AppendAllText("TwoDigit.txt", numbers[i].ToString() + " ");
                    }
                    if (numbers[i] >= 0)
                    {
                        plus++;
                        File.AppendAllText("Plus.txt", numbers[i].ToString() + " ");
                    }
                    else
                    {
                        minus++;
                        File.AppendAllText("Minus.txt", numbers[i].ToString() + " ");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
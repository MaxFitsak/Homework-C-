using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Task 1
        string path = "1.fitsak";

        try
        {
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(file))
            {
                while (true)
                {
                    Console.Write("Введіть число (або порожній рядок для завершення) -> ");
                    string input = Console.ReadLine();
                    
                    if (string.IsNullOrWhiteSpace(input))
                        break;

                    if (double.TryParse(input, out double mem))
                    {
                        writer.Write(mem);
                    }
                    else
                    {
                        Console.WriteLine("Помилка: введіть коректне число.");
                    }
                }
            } 
            
            Console.WriteLine("\n--- Читання з файлу ---");

            using (FileStream fileRead = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fileRead))
            {
                while (fileRead.Position < fileRead.Length)
                {
                    double val = reader.ReadDouble();
                    Console.WriteLine(val);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }

        //task 2
        string evenFile = "even.txt";
        string oddFile = "odd.txt";
        
        int evenCount = 0;
        int oddCount = 0;
        Random rnd = new Random();

        try
        {
            using (StreamWriter evenWriter = new StreamWriter(evenFile))
            using (StreamWriter oddWriter = new StreamWriter(oddFile))
            {
                for (int i = 0; i < 10000; i++)
                {
                    int number = rnd.Next(1, 100001);

                    if (number % 2 == 0)
                    {
                        evenWriter.WriteLine(number);
                        evenCount++;
                    }
                    else
                    {
                        oddWriter.WriteLine(number);
                        oddCount++;
                    }
                }
            }

            Console.WriteLine("=== Статистика обробки ===");
            Console.WriteLine($"Файл '{evenFile}': {evenCount} чисел");
            Console.WriteLine($"Файл '{oddFile}': {oddCount} чисел");
            Console.WriteLine("Усі дані успішно збережені.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        Console.Write("Введіть шлях до файлу (наприклад, text.txt): ");
        path = Console.ReadLine();

        if (!File.Exists(path))
        {
            Console.WriteLine("Помилка: Файл за вказаним шляхом не знайдено.");
            return;
        }

        int sentencesCount = 0;
        int wordsCount = 0;
        int upperCount = 0;
        int lowerCount = 0;
        int vowelsCount = 0;
        int consonantsCount = 0;

        string vowelsList = "аеєиіїоуюяaeiouy";

        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string text = reader.ReadToEnd();

                char[] separators = { ' ', '\r', '\n', '\t', '.', ',', ';', ':', '!', '?', '-', '"', '\'' };
                string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                wordsCount = words.Length;

                foreach (char c in text)
                {
                    if (c == '.' || c == '!' || c == '?')
                    {
                        sentencesCount++;
                    }

                    if (char.IsLetter(c))
                    {
                        if (char.IsUpper(c)) upperCount++;
                        if (char.IsLower(c)) lowerCount++;

                        char lowerC = char.ToLower(c); 
                        
                        if (vowelsList.Contains(lowerC))
                        {
                            vowelsCount++;
                        }
                        else
                        {
                            consonantsCount++;
                        }
                    }
                }
            }

            Console.WriteLine("\n___СТАТИСТИКА ФАЙЛУ___");
            Console.WriteLine($"Кількість речень: {sentencesCount}");
            Console.WriteLine($"Кількість слів: {wordsCount}");
            Console.WriteLine($"Великих літер: {upperCount}");
            Console.WriteLine($"Малих літер: {lowerCount}");
            Console.WriteLine($"Голосних букв: {vowelsCount}");
            Console.WriteLine($"Приголосних букв: {consonantsCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка при читанні файлу: {ex.Message}");
        }
    }
}


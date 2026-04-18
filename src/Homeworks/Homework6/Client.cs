namespace Task 
{
    class Program
        {
            static void Main()
            {
                try
                {
                    Date d1 = new Date(15, 8, 2023);
                    Date d2 = new Date(1, 1, 2024);

                    Console.Write("Дата 1: ");
                    d1.Print();
                    
                    Console.Write("Дата 2: ");
                    d2.Print();

                    Console.WriteLine($"\nДата 2 більша за Дату 1? {d2 > d1}");

                    int difference = d2 - d1;
                    Console.WriteLine($"Різниця між датами: {difference} днів");

                    Date d3 = d1 + 20;
                    Console.Write("Дата 1 + 20 днів: ");
                    d3.Print();

                    Console.WriteLine("\nСпробуємо створити неправильну дату (32 січня)...");
                    
                    Date wrongDate = new Date(32, 1, 2023); 
                    
                    Console.WriteLine("Цей текст не виведеться."); 
                }
                catch (ArgumentException ex) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ПОМИЛКА: {ex.Message}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Сталася непередбачена помилка: {ex.Message}");
                }
            }
        }
}
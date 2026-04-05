namespace Fiopl
{
    class Client
    {
        static void Main()
        {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            Console.WriteLine("--- Клас Дейт ---\n");

            Date date1 = new Date(4, 4, 2026);
            Date date2 = new Date(1, 1, 2026);

            Console.Write("Дата 1: "); date1.Print();
            Console.Write("Дата 2: "); date2.Print();

            int diff = date1 - date2;
            Console.WriteLine("\nРізница між датами: {0} дней.", diff);
            Console.WriteLine("Дата 1 > Дата 2 {0}", date1 > date2);
            Console.WriteLine("Дата 1 == Дата 2 {0}", date1 == date2);

            Console.WriteLine("Дату 1 на один день");
            date1++;
            date1.Print();
            Console.WriteLine("Прибавляємо 40 дней до Дати 2");
            Date futureDate = date2 + 40;
            futureDate.Print();
            Date endOfYear = new Date(31, 12, 2025);
            Console.Write("Кінец року: "); endOfYear.Print();
            Console.WriteLine("Добавляем 1 день");
            (endOfYear + 1).Print();

        }
        catch (Exception ex)
        {
            Console.WriteLine("[помилка]: {0}", ex.Message);
        }
    }
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("--- Створення Працівника ---");
        Employeer emp1 = new Employeer();
        
        Console.WriteLine("\nДанні працівника:");
        emp1.PrintFullClass();

        Console.WriteLine("\nЗбільшуємо зарплату на 500");
        emp1 += 500;
        Console.WriteLine($"Нова зарплата: {emp1.Solary}");

        Console.WriteLine("\n=== Работа з книгами ===");
        ReadBooks myLibrary = new ReadBooks();

        myLibrary += "Мастер та Маргарита";
        myLibrary += "Відбмаг";
        myLibrary += "Чистий код";

        myLibrary.Print();

        try 
        {
            Console.WriteLine($"\nКнига під номером 1: {myLibrary[1]}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        string searchBook = "Відьмаг";

        Console.WriteLine($"\nВидаляємо книгу 'Відьмаг'");
        myLibrary -= "Відьмаг";

        myLibrary.Print();

        Console.WriteLine("\nНажмите Enter, чтобы выйти...");
        Console.ReadLine();
    }
}
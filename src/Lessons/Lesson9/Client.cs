using System.Runtime.InteropServices;

namespace Task
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("___ТЕСТУВАННЯ ПАСПОРТІВ___\n");

            Passport ukrPassport = new Passport(
                firstName: "Іван", 
                lastName: "Шевченко", 
                documentNumber: "КВ123456", 
                birthDate: new DateTime(1990, 5, 15), 
                country: "Україна"
            );

            Console.WriteLine("--- Інформація про звичайний паспорт ---");
            ukrPassport.ShowInfo();
            Console.WriteLine();


            ForeignPassport travelPassport = new ForeignPassport(
                firstName: "Іван", 
                lastName: "Шевченко", 
                documentNumber: "КВ123456", 
                birthDate: new DateTime(1990, 5, 15), 
                country: "Україна",
                foreignNumber: "FT98765432"
            );

            travelPassport.AddVisa("Шенгенська віза (Польща)");
            travelPassport.AddVisa("Туристична віза (Єгипет)");
            travelPassport.AddVisa("Робоча віза (Канада)");

            Console.WriteLine("--- Інформація про закордонний паспорт ---");
            travelPassport.ShowInfo();

            Console.WriteLine("\n--- Тест ліміту віз ---");
            ForeignPassport limitedPassport = new ForeignPassport(
                "Анна", "Коваленко", "АА112233", new DateTime(1995, 8, 20), "Україна", "EX112233", 2);
            
            limitedPassport.AddVisa("Віза США");
            limitedPassport.AddVisa("Віза Британії");
            limitedPassport.AddVisa("Віза Японії");
            
            limitedPassport.ShowInfo();


            Console.WriteLine("___ПРОФЕСІЇ___");

            Builder bob = new Builder("Боб", 45, "Перфоратор");
            bob.Work();

            Sailor mem = new Sailor("Мем", 34, "Yaht");
            mem.Work();

            Pilot Vasily = new Pilot("Василий", 56, "Boing 777");
            Vasily.Work();
        }
    }
}

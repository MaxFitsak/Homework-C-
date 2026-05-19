using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        using (ApplicationContext db = new ApplicationContext())
        {
            db.Database.EnsureCreated();

            if (!db.Countries.Any())
            {
                var countries = new List<Country>
                {
                    new Country { Name = "Україна", Capital = "Київ", Population = 41000000, Area = 603628, Continent = "Європа" },
                    new Country { Name = "Франція", Capital = "Париж", Population = 67390000, Area = 551695, Continent = "Європа" },
                    new Country { Name = "Німеччина", Capital = "Берлін", Population = 83240000, Area = 357022, Continent = "Європа" },
                    new Country { Name = "Японія", Capital = "Токіо", Population = 125800000, Area = 377975, Continent = "Азія" },
                    new Country { Name = "Китай", Capital = "Пекін", Population = 1412000000, Area = 9597000, Continent = "Азія" },
                    new Country { Name = "Єгипет", Capital = "Каїр", Population = 104000000, Area = 1010408, Continent = "Африка" },
                    new Country { Name = "Канада", Capital = "Оттава", Population = 38000000, Area = 9984670, Continent = "Північна Америка" },
                    new Country { Name = "Аргентина", Capital = "Буенос-Айрес", Population = 45380000, Area = 2780400, Continent = "Південна Америка" },
                    new Country { Name = "Австралія", Capital = "Канберра", Population = 25690000, Area = 7692024, Continent = "Австралія" },
                    new Country { Name = "Італія", Capital = "Рим", Population = 59000000, Area = 301340, Continent = "Європа" }
                };

                db.Countries.AddRange(countries);
                db.SaveChanges();
            }
        }

        try
        {
            while (true)
            {
                Console.WriteLine("1. Показати всі країни");
                Console.WriteLine("2. Додати країну");
                Console.WriteLine("3. Редагувати країну");
                Console.WriteLine("4. Видалити країну");
                Console.WriteLine("0. Вихід");

                int result = int.Parse(Console.ReadLine());

                switch (result)
                {
                    case 1:
                        ShowAllCountries();
                        break;
                    case 2:
                        AddNewCountry();
                        break;
                    case 3:
                        EditCountry();
                        break;
                    case 4:
                        RemoveCountry();
                        break;
                    case 0:
                        return;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Сталася помилка: " + ex.Message);
            Console.ReadKey();
        }
    }

    static void ShowAllCountries()
    {
        Console.Clear();
        using (var db = new ApplicationContext())
        {
            var countries = db.Countries.ToList();
            if (!countries.Any())
            {
                Console.WriteLine("База даних порожня.");
            }
            else
            {
                int iter = 0;
                foreach (var c in countries)
                {
                    Console.WriteLine($"[{++iter}] {c.Name} (Столиця: {c.Capital}, Населення: {c.Population}, Площа: {c.Area})");
                }
            }
        }
    }

    static void AddNewCountry()
    {
        Console.Clear();

        Console.Write("Введіть назву країни: ");
        string name = Console.ReadLine();

        Console.Write("Введіть столицю: ");
        string capital = Console.ReadLine();

        Console.Write("Введіть кількість жителів: ");
        long population = long.Parse(Console.ReadLine());

        Console.Write("Введіть площу: ");
        double area = double.Parse(Console.ReadLine());

        Console.Write("Введіть частину світу (Європа, Азія.....): ");
        string continent = Console.ReadLine();

        using (var db = new ApplicationContext())
        {
            var newCountry = new Country
            {
                Name = name,
                Capital = capital,
                Population = population,
                Area = area,
                Continent = continent
            };
            db.Countries.Add(newCountry);
            db.SaveChanges();
        }
    }

    static void EditCountry()
    {
        Console.Clear();

        using (var db = new ApplicationContext())
        {
            var countries = db.Countries.ToList();
            int iter = 0;
            foreach (var c in countries)
            {
                Console.WriteLine($"[{++iter}] {c.Name}");
            }

            Console.Write("Введіть номер країни для редагування: ");
            int number = int.Parse(Console.ReadLine());

            if (number > 0 && number <= countries.Count)
            {
                var countryToEdit = countries[number - 1];


                Console.Write("Нова назва: ");
                string newName = Console.ReadLine();
                countryToEdit.Name = newName;

                Console.Write("Нова столиця: ");
                string newCapital = Console.ReadLine();
                countryToEdit.Capital = newCapital;

                Console.Write("Нова кількість жителів: ");
                long newPop = long.Parse(Console.ReadLine());
                countryToEdit.Population = newPop;

                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Невірний номер");
            }
        }
    }

    static void RemoveCountry()
    {
        Console.Clear();

        using (var db = new ApplicationContext())
        {
            var countries = db.Countries.ToList();
            int iter = 0;
            foreach (var c in countries)
            {
                Console.WriteLine($"[{++iter}] {c.Name}");
            }

            Console.Write("Введіть номер країни для видалення: ");
            int number = int.Parse(Console.ReadLine());

            if (number > 0 && number <= countries.Count)
            {
                var countryToDelete = countries[number - 1];
                db.Countries.Remove(countryToDelete);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Невірний номер");
            }
        }
    }
}
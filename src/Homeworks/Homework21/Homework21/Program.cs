class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        using (ApplicationContext db = new ApplicationContext())
        {
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

                db.SaveChanges();
            }


            var allCountries = db.Countries.ToList();
            foreach (var c in allCountries)
                Console.WriteLine("{0} Столиця: {1}, Населення: {2}, Площа: {3}, Континент: {4}", c.Name, c.Capital, c.Population, c.Area, c.Continent);

            Console.WriteLine("Назви країн:");
            var countryNames = db.Countries.Select(c => c.Name).ToList();
            Console.WriteLine(string.Join(", ", countryNames));

            Console.WriteLine("Назви столиць:");
            var capitalNames = db.Countries.Select(c => c.Capital).ToList();
            Console.WriteLine(string.Join(", ", capitalNames));

            Console.WriteLine("Європейські країни:");
            var europeanCountries = db.Countries.Where(c => c.Continent == "Європа").Select(c => c.Name).ToList();
            Console.WriteLine(string.Join(", ", europeanCountries));

            double targetArea = 1000000;
            Console.WriteLine("Країни з площею більшою за " +  targetArea);
            var largeAreaCountries = db.Countries.Where(c => c.Area > targetArea).Select(c => c.Name).ToList();
            Console.WriteLine(string.Join(", ", largeAreaCountries));

            Console.WriteLine("Країни, у назві яких є літери а та e:");
            var countriesWithAandE = db.Countries
                .Where(c => c.Name.ToLower().Contains("а") && c.Name.ToLower().Contains("е"))
                .ToList();
            foreach (var c in countriesWithAandE) Console.WriteLine(c.Name);

            Console.WriteLine("Країни, назва яких починається з літери А:");
            var countriesStartingWithA = db.Countries
                .Where(c => c.Name.ToLower().StartsWith("а"))
                .ToList();
            foreach (var c in countriesStartingWithA) Console.WriteLine(c.Name);

            double minArea = 300000;
            double maxArea = 600000;
            Console.WriteLine("Країни з площею від {0} до {1}:", minArea, maxArea);
            var areaInRangeNames = db.Countries
                .Where(c => c.Area >= minArea && c.Area <= maxArea)
                .Select(c => c.Name)
                .ToList();
            Console.WriteLine(string.Join(", ", areaInRangeNames));

            long targetPopulation = 50000000;
            Console.WriteLine("Країни з населенням понад " + targetPopulation);
            var popTargetNames = db.Countries
                .Where(c => c.Population > targetPopulation)
                .Select(c => c.Name)
                .ToList();
            Console.WriteLine(string.Join(", ", popTargetNames));
        }
    }
}
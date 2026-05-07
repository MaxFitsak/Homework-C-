namespace Task
{
    class Task
    {
        public class Good 
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public double Price { get; set; }
            public string Category { get; set; }
        }

        static public void NewTask(int n)
        {
            Console.WriteLine("---Task {0} ---", n);
        }

        static void Main()
        {
            List<Good> good1 = new List<Good>()
            {
                new Good()
                { Id= 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
                new Good()
                { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
                new Good()
                { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
                new Good()
                { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
                new Good()
                { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car"},
                new Good()
                { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
                new Good()
                { Id = 7, Title = "Auto Cleaner", Price = 3100, Category = "Car" },
                new Good()
                { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
                new Good()
                { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
                new Good()
                { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
            };

            NewTask(1);
            var result1 = from m in good1
                          where m.Category == "Mobile"
                          where m.Price >= 1000
                          select m;

            foreach (var mobile in result1)
            {
                Console.WriteLine($"{mobile.Title} - {mobile.Price}");
            }


            NewTask(2);
            var result2 = from notKitchen in good1
                          where notKitchen.Category != "Kitchen"
                          where notKitchen.Price >= 1000
                          select notKitchen;

            foreach (var item in result2)
            {
                Console.WriteLine($"{item.Title} - {item.Price} - {item.Category}");
            }

            NewTask(3);
            var result3 = good1.Average(p => p.Price);
            Console.WriteLine($"{result3}");

            NewTask(4);
            var result4 = good1.Select(c => c.Category).Distinct();
            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }

            NewTask(5);
            var result5 = good1.OrderBy(t => t.Title);
            foreach (var item in result5)
            {
                Console.WriteLine(item.Title);
            }

            NewTask(6);
            var result6 = from t in good1
                          where t.Category == "Mobile" || t.Category == "Car"
                          group t by t.Category into g
                          select new { Title = g.Key, Count = g.Count() };

            foreach (var item in result6)
            {
                Console.WriteLine($"{item.Title} - {item.Count}");
            }

            NewTask(7);
            var result7 = from p in good1
                                     group p by p.Category into g
                                     select new
                                     {
                                         Category = g.Key,
                                         Title = g.Count()
                                     };

            foreach (var item in result7)
            {
                Console.WriteLine($"{item.Category} — {item.Title}");
            }
            Console.ReadLine();
        }
    }
}
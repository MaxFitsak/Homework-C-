using System.Net.Cache;
namespace Task {
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
    public class Task
    {
        public static void Main()
        {
            List<Person> person = new List<Person>()
            {
                new Person(){ Name = "Andrey", Age = 24, City = "Kyiv"},
                new Person(){Name = "Lize", Age = 19, City = "Odesa"},
                new Person(){ Name = "Oleg", Age = 15, City = "London"},
                new Person(){ Name = "Sergey", Age = 55, City = "Kyiv"},
                new Person(){ Name = "Sergey", Age = 32, City = "Lviv"}
            };

            var result1 = person.Where(p => p.Age >= 25);

            result1 = from p in person
                      where p.Age >= 25
                      select p;

            Console.WriteLine("Task1------");
            foreach (var p in result1)
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }


            var result2 = person.Where(p => p.City != "London");

            result2 = from p in person
                      where p.City != "Lonodn"
                      select p;

            Console.WriteLine("Task2------");
            foreach (var p in result2)
            {
                Console.WriteLine($"{p.Name} - {p.City}");
            }

            var result3Methot = person.Where(p => p.City == "Kyiv").Select(p => p.Name);

            var result3Query = from p in person
                          where p.City == "Kyiv"
                          select p;

            Console.WriteLine("Task3------");
            foreach (var p in result3Methot)
            {
                Console.WriteLine($"{p}");
            }

            foreach(var p in result3Query)
            {
                Console.WriteLine($"{p.City} - {p.Name}");
            }


            var result4 = person.Where(p => p.Age > 35 && p.Name == "Sergey");

            result4 = from p in person
                          where p.Age > 35 && p.Name == "Sergey"
                          select p;

            Console.WriteLine("Task4------");
            foreach (var p in result4)
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }


            var result5 = person.Where(p => p.City == "Odesa");

            result5 = from p in person
                          where p.City == "Odesa"
                          select p;

            Console.WriteLine("Task5------");
            foreach (var p in result5)
            {
                Console.WriteLine($"{p.Name} - {p.City}");
            }

            Console.ReadKey();
        }
    }
}
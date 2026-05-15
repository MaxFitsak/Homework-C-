using System.Text;

class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int DepId { get; set; }
}

class Departament
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        List<Departament> departaments = new List<Departament>()
        {
            new Departament(){ Id = 1, Country = "Ukraine", City = "Lviv"},
            new Departament(){ Id = 2, Country = "Ukraine", City = "Kyiv"},
            new Departament(){ Id = 3, Country = "France", City = "Paris"},
            new Departament(){ Id = 4, Country = "Ukraine", City = "Odesa"}
        };

        List<Employee> employees = new List<Employee>()
        {
            new Employee()
            { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
            new Employee()
            { Id = 1, FirstName = "Nikita", LastName = "Larin", Age = 27, DepId = 2 },
            new Employee()
            { Id = 1, FirstName = "Alica", LastName = "Ivanova", Age = 26, DepId = 2 },
            new Employee()
            { Id = 1, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
            new Employee()
            { Id = 1, FirstName = "Lida", LastName = "Voron", Age = 29, DepId = 2 },
            new Employee()
            { Id = 1, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
            new Employee()
            { Id = 1, FirstName = "Nikita", LastName = "Krotov", Age = 29, DepId = 4 },
        };

        Console.WriteLine("1");

        var task1Method = employees
            .Join(departaments,
                  emp => emp.DepId,
                  dep => dep.Id,
                  (emp, dep) => new { Employee = emp, Departament = dep })
            .Where(x => x.Departament.Country == "Ukraine" && x.Departament.City != "Odesa")
            .Select(x => new { x.Employee.FirstName, x.Employee.LastName })
            .ToList();

        var task1Query = (from emp in employees
                          join dep in departaments on emp.DepId equals dep.Id
                          where dep.Country == "Ukraine" && dep.City != "Odesa"
                          select new { emp.FirstName, emp.LastName }).ToList();

        foreach (var item in task1Query)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }

        Console.WriteLine("2");

        var task2Method = departaments
            .Select(d => d.Country)
            .Distinct()
            .ToList();

        var task2Query = (from dep in departaments
                          select dep.Country).Distinct().ToList();

        foreach (var country in task2Query)
        {
            Console.WriteLine(country);
        }

        Console.WriteLine("3");
        var task3Method = employees
            .Where(e => e.Age > 25)
            .Take(3)
            .ToList();

        var task3Query = (from emp in employees
                          where emp.Age > 25
                          select emp).Take(3).ToList();

        foreach (var emp in task3Query)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName}, Age: {emp.Age}");
        }

        Console.WriteLine("4");

        var task4Method = employees
            .Join(departaments,
                  emp => emp.DepId,
                  dep => dep.Id,
                  (emp, dep) => new { Employee = emp, Departament = dep })
            .Where(x => x.Departament.City == "Odesa" && x.Employee.Age > 27)
            .Select(x => new { x.Employee.FirstName, x.Employee.LastName, x.Employee.Age })
            .ToList();

        var task4Query = (from emp in employees
                          join dep in departaments on emp.DepId equals dep.Id
                          where dep.City == "Odesa" && emp.Age > 27
                          select new { emp.FirstName, emp.LastName, emp.Age }).ToList();

        foreach (var item in task4Query)
        {
            Console.WriteLine($"{item.FirstName} {item.LastName}, Age: {item.Age}");
        }
    }
}
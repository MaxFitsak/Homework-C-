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
            { Id = 1, FirstName = "Nikita", LastName = "Larin", Age = 22, DepId = 2 },
            new Employee()
            { Id = 1, FirstName = "Alica", LastName = "Ivanova", Age = 22, DepId = 2 },
            new Employee()
            { Id = 1, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
            new Employee()
            { Id = 1, FirstName = "Lida", LastName = "Voron", Age = 22, DepId = 2 },
            new Employee()
            { Id = 1, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
            new Employee()
            { Id = 1, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4 },
        };

        Console.WriteLine("1");

        var ukrainianEmployees = employees
            .Join(departaments,
            emp => emp.DepId,   
            dep => dep.Id,         
            (emp, dep) => new { Employee = emp, Departament = dep }) 
            .Where(joined => joined.Departament.Country == "Ukraine")     
            .Select(joined => joined.Employee)                             
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList();

        
        foreach (var emp in ukrainianEmployees)
        {
            Console.WriteLine(emp.FirstName +  " " + emp.LastName);
        }

        Console.WriteLine("2");

        var sortedEmployees = employees
            .OrderByDescending(e => e.Age)
            .Select(e => new { e.Id, e.FirstName, e.LastName, e.Age })
            .ToList(); 

        foreach (var emp in sortedEmployees)
        {
            Console.WriteLine($"Id: {emp.Id}, Name: {emp.FirstName} {emp.LastName}, Age: {emp.Age}");
        }

        Console.WriteLine("3");

        var employeesByAge = employees
            .GroupBy(e => e.Age)
            .Select(group => new { Age = group.Key, Count = group.Count() })
            .ToList();

        foreach (var group in employeesByAge)
        {
            Console.WriteLine($"Age: {group.Age}, Count: {group.Count}");
        }
    }
}
using Car;
using ElectricCar;
using System.Text;

namespace Main;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Car.Car[] cars = new Car.Car[]
        {
            new Car.Car("BMW", "X5", 2021),
            new ElectricCar.ElectricCar("BMW", "Ix 5", 2024, 77),
            new Car.Car("Audi", "RSQ8", 2026)
        };

        Console.WriteLine("Машини");
        cars.ToList().ForEach(c => c.PrintInfo());
        Console.WriteLine();

        Console.WriteLine("Електрокари");
        var electrics = cars.OfType<ElectricCar.ElectricCar>();
        foreach (var e in electrics) e.PrintInfo();
        Console.WriteLine();

        Console.WriteLine("Сама нова Машина");
        var newest = cars.OrderByDescending(c => c.Year).FirstOrDefault();
        newest?.PrintInfo();
        Console.WriteLine();

        Console.WriteLine("Сама велика батарея");
        var maxBattery = cars.OfType<ElectricCar.ElectricCar>()
                             .OrderByDescending(e => e.BatteryCapacity)
                             .FirstOrDefault();
        maxBattery?.PrintInfo();

        Console.ReadKey();
    }
}
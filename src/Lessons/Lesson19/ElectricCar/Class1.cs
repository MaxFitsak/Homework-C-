using Car;
namespace ElectricCar;

public record ElectricCar(string Brand, string Model, int Year, int BatteryCapacity)
    : Car.Car(Brand, Model, Year)
{
    public override void PrintInfo()
    {
        Console.WriteLine("Електромобіль: {0} {1}, Рік: {2}, Батарея: {3} kw",
            Brand, Model, Year, BatteryCapacity);
    }
}
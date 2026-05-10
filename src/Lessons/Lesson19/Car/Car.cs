namespace Car;

public record Car(string Brand, string Model, int Year)
{
    public virtual void PrintInfo()
    {
        Console.WriteLine("Авто: {0} {1}, Рік: {2}", Brand, Model, Year);
    }
}
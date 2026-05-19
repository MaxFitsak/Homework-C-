public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Capital { get; set; }
    public long Population { get; set; } // Використовуємо long, оскільки населення може бути великим
    public double Area { get; set; }
    public string Continent { get; set; }
}
namespace CarrierOfInformation;

public abstract class MediaWriter
{
    public string NameManufacturer { get; set; }
    public string Model { get; set; }
    public string Naming { get; set; }
    public int Capacity { get; set; }
    public int Count { get; set; }

    protected MediaWriter()
    {

    }

    protected MediaWriter(string nameManufacturer, string model, string naming, int capacity, int count)
    {
        NameManufacturer = nameManufacturer;
        Model = model;
        Naming = naming;
        Capacity = capacity;
        Count = count;
    }

    public virtual string Report()
    {
        return $"Виробник: {NameManufacturer}, Модель: {Model}, Найменування: {Naming}, Місткість: {Capacity}, Кількість: {Count}";
    }
}
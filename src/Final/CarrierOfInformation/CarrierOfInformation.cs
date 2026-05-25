namespace CarrierOfInformation;

class MediaWriter
{
    public string NameManufacturer { get; set; }
    public string Model { get; set; }
    public string Naming { get; set; }
    public int Capacity { get; set; }
    public int Count { get; set; }

    public virtual void Report()
    {

    }

    public virtual void Load()
    {

    }

    public virtual void Save()
    {

    }
}
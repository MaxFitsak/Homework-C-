using CarrierOfInformation;

namespace Devices;

public class FlashMemory : MediaWriter
{
    public string UsbSpeed { get; set; } = string.Empty;

    public FlashMemory() : base() { }

    public FlashMemory(string nameManufacturer, string model, string naming, int capacity, int count, string usbSpeed)
        : base(nameManufacturer, model, naming, capacity, count)
    {
        UsbSpeed = usbSpeed;
    }

    public override string Report()
    {
        return $"[Flash-пам'ять] {base.Report()}, Швидкість USB: {UsbSpeed}";
    }
}

public class DvdDisk : MediaWriter
{
    public string WriteSpeed { get; set; } = string.Empty;

    public DvdDisk() : base() { }

    public DvdDisk(string nameManufacturer, string model, string naming, int capacity, int count, string writeSpeed)
        : base(nameManufacturer, model, naming, capacity, count)
    {
        WriteSpeed = writeSpeed;
    }

    public override string Report()
    {
        return $"[DVD-диск] {base.Report()}, Швидкість запису: {WriteSpeed}";
    }
}

public class Hdd : MediaWriter
{
    public int SpindleSpeed { get; set; }

    public Hdd() : base() { }

    public Hdd(string nameManufacturer, string model, string naming, int capacity, int count, int spindleSpeed)
        : base(nameManufacturer, model, naming, capacity, count)
    {
        SpindleSpeed = spindleSpeed;
    }

    public override string Report()
    {
        return $"[HDD-диск] {base.Report()}, Швидкість шпинделя: {SpindleSpeed} RPM";
    }
}
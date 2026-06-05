using System;
using System.Collections.Generic;
using System.Linq;
using CarrierOfInformation;
using Interfaces;

namespace PriceList;

public class PriceListManager
{
    private List<MediaWriter> _devices = new();

    public List<MediaWriter> AllDevices() => _devices.ToList();

    public void AddDevice(MediaWriter device)
    {
        if (device == null) throw new ArgumentNullException(nameof(device), "Пристрій не може бути null.");
        _devices.Add(device);
    }

    public bool RemoveDeviceByModel(string model)
    {
        var device = _devices.FirstOrDefault(d => d.Model.Equals(model, StringComparison.OrdinalIgnoreCase));
        if (device != null)
        {
            return _devices.Remove(device);
        }
        return false;
    }

    public void PrintList(ILog logger)
    {
        if (_devices.Count == 0)
        {
            logger.Print("Прайслист порожній. Немає носіїв для відображення.");
            return;
        }

        foreach (var device in _devices)
        {
            logger.Print(device.Report());
        }
    }

    public bool UpdateCountByModel(string model, int newCount)
    {
        var device = _devices.FirstOrDefault(d => d.Model.Equals(model, StringComparison.OrdinalIgnoreCase));
        if (device != null)
        {
            device.Count = newCount;
            return true;
        }
        return false;
    }

    public List<MediaWriter> SearchByManufacturer(string manufacturer)
    {
        return _devices
            .Where(d => d.NameManufacturer.Equals(manufacturer, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public void SaveToFile(ISerialize serializer, string filePath)
    {
        serializer.Save(_devices, filePath);
    }

    public void LoadFromFile(ISerialize serializer, string filePath)
    {
        var result = serializer.Load(filePath);

        if (result is List<MediaWriter> loadedList)
        {
            _devices.Clear();
            _devices.AddRange(loadedList);
        }
    }
}
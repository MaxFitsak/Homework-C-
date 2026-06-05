using CarrierOfInformation;
using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Serialization;

public class JSONSerialize : ISerialize
{
    public void Save(object data, string filePath)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Не вдалося зберегти файл: {ex.Message}");
        }
    }

    public object Load(string filePath)
    {
        try
        {
            if (!File.Exists(filePath)) return new List<MediaWriter>();
            string jsonString = File.ReadAllText(filePath);

            return jsonString;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Не вдалося завантажити файл: {ex.Message}");
            return null;
        }
    }
}

public class XMLSerialize : ISerialize
{
    public void Save(object data, string filePath)
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(data.GetType());
            using StreamWriter writer = new StreamWriter(filePath);
            serializer.Serialize(writer, data);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Не вдалося зберегти файл: {ex.Message}");
        }
    }

    public object Load(string filePath)
    {
        try
        {
            if (!File.Exists(filePath)) return null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<MediaWriter>));
            using StreamReader reader = new StreamReader(filePath);
            return serializer.Deserialize(reader);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Не вдалося завантажити файл: {ex.Message}");
            return null;
        }
    }
}
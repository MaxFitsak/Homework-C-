namespace Interfaces;

public interface ILog
{
    void Print(string text);
}

public interface ISerialize
{
    void Save(object data, string filePath);

    object Load(string filePath);
}
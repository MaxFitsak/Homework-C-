using System.IO;
using System.Runtime.Serialization.Json;

namespace ClassLibrarySerialization
{
    public class Serialization_Deserialization
    {
        public byte[] SerializeObject<T>(T obj)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return ms.ToArray();
            }
        }
        public T DeserializeObject<T>(byte[] jsonData, int byteRec)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(jsonData, 0, byteRec))
            {
                return (T)serializer.ReadObject(ms);
            }
        }
    }
}
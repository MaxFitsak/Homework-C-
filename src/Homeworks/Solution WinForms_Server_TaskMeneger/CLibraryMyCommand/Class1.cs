using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CLibraryMyCommand
{
    [Serializable]
    [DataContract]
    public class CMyCommand
    {
        [DataMember]
        public string NameOfCommand { get; set; }
        [DataMember]
        public int IDProcess { get; set; }
        [DataMember]
        public string Path { get; set; }

        public CMyCommand() { }
    }
}

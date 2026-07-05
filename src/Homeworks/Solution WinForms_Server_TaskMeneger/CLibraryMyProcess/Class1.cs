using System.Runtime.Serialization;

namespace CLibraryMyProcess
{
    [DataContract]
    public class CMyProcess
    {
        [DataMember]
        public int ProcessId { get; set; }
        [DataMember]
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public CMyProcess() { }
    }
}

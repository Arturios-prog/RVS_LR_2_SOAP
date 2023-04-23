using System.Runtime.Serialization;

namespace Soap.Shared.Models
{
    [DataContract]
    public class Currency
    {
        [DataMember]
        public int Code { get; set; }

        [DataMember]
        public string Alpha3 { get; set; } = string.Empty;

        [DataMember]
        public string Sign { get; set; } = string.Empty;

        [DataMember]
        public string Name { get; set; } = string.Empty;

        [DataMember]
        public int Accuracy { get; set; }

        public override string ToString() =>
            $"{nameof(Code)}: {Code}\n" +
            $"{nameof(Alpha3)}: {Alpha3}\n" +
            $"{nameof(Sign)}: {Sign}\n" +
            $"{nameof(Name)}: {Name}\n" +
            $"{nameof(Accuracy)}: {Accuracy}\n";
    }
}

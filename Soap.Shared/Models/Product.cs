using System.Runtime.Serialization;

namespace Soap.Shared.Models
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ProductName { get; set; } = string.Empty;

        [DataMember]
        public string Description { get; set; } = string.Empty;

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public Currency? Currency { get; set; }

        [DataMember]
        public bool InStock { get; set; }


        public override string ToString() =>
                $"{nameof(ProductId)}: {ProductId}\n" +
                $"{nameof(ProductName)}: {ProductName}\n" +
                $"{nameof(Description)}: {Description}\n" +
                $"{nameof(Price)}: {Price} {Currency.Sign}\n" +
                $"{nameof(InStock)}: {InStock}\n";
    }
}

using Soap.Shared.Models;
using System.ServiceModel;

namespace SoapServer.Services
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        Product? GetProductDetails(int productId);
    }
}

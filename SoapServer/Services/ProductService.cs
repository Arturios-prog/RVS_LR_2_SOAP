using Soap.Shared.Models;

namespace SoapServer.Services
{
    public class ProductService : IProductService
    {
        public Product? GetProductDetails(int productId)
        {
            return Data.ProductSet.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}

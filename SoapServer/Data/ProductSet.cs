using Soap.Shared.Models;

namespace SoapServer.Data
{
    public static class ProductSet
    {
        public static List<Product> Products { get; set; } = new List<Product>();
        public static List<Currency> Currencies { get; set; } = new List<Currency>();

        public static void InflateData()
        {
            Currencies.Add(new Currency
            {
                Accuracy = 2,
                Code = 840,
                Alpha3 = "USD",
                Sign = "$",
                Name = "US Dollar"
            });

            Currencies.Add(new Currency
            {
                Accuracy = 3,
                Code = 220,
                Alpha3 = "RUB",
                Sign = "RUB",
                Name = "Российский рубль"
            });

            Products.Add(new Product()
            {
                ProductId = 1,
                ProductName = "Стакан граненый",
                Description = "Стакан граненый 250 мл",
                Price = 9.95,
                Currency = Currencies.FirstOrDefault(c => c.Code == 840),
                InStock = true
            });

            Products.Add(new Product()
            {
                ProductId = 2,
                ProductName = "Перчатка зимняя",
                Description = "Зимняя перчатка из хлопка",
                Price = 250,
                Currency = Currencies.FirstOrDefault(c => c.Code == 220),
                InStock = true
            });

            Products.Add(new Product()
            {
                ProductId = 3,
                ProductName = "Бита",
                Description = "Бейсбольная бита",
                Price = 2405,
                Currency = Currencies.FirstOrDefault(c => c.Code == 220),
                InStock = true
            });

            Products.Add(new Product()
            {
                ProductId = 4,
                ProductName = "Клюшка",
                Description = "Клюшка для игры в гольф",
                Price = 20.5,
                Currency = Currencies.FirstOrDefault(c => c.Code == 840),
                InStock = false
            });
        }
    }
}

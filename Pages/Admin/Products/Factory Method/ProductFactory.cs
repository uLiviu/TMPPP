using Store.Models;

namespace Store.Pages.Admin.Products
{
    public class ProductFactory : IProductFactory
    {
        public Product CreateProduct(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.DigitalClock:
                    return new DigitalClockProductFactory().CreateProduct(productType);
                case ProductType.PortableRadio:
                    return new PortableRadioProductFactory().CreateProduct(productType);
                case ProductType.PocketCalculator:
                    return new PocketCalculatorProductFactory().CreateProduct(productType);
                default:
                    throw new ArgumentException("Invalid course type", nameof(productType));
            }
        }
    }

    public class DigitalClockProductFactory : IProductFactory
    {
        public Product CreateProduct(ProductType courseType)
        {
            if (courseType != ProductType.DigitalClock)
            {
                throw new ArgumentException("This factory can only create digital clocks.");
            }
            return new Product
            {
                ProductType = ProductType.DigitalClock,
                Name = "Digital Clock",
                Brand = "Samsung",
                Category = "Electronics",
                Price = 50,
                StockCount = 100,
                Warranty = 2,
                Description = "A high-quality digital clock.",
                ImageFileName = "DigitalClock.jpg",
                CreatedAt = DateTime.Now,
                LastUpdated = DateTime.Now
            };
        }
    }

    public class PortableRadioProductFactory : IProductFactory
    {
        public Product CreateProduct(ProductType courseType)
        {
            if (courseType != ProductType.PortableRadio)
            {
                throw new ArgumentException("This factory can only create portable radio.");
            }

            return new Product
            {
                ProductType = ProductType.PortableRadio,
                Name = "Portable Radio",
                Brand = "Xiaomi",
                Category = "Electronics",
                Price = 100,
                StockCount = 50,
                Warranty = 1,
                Description = "A portable radio for listening to music on the go.",
                ImageFileName = "PortableRadio.jpg",
                CreatedAt = DateTime.Now,
                LastUpdated = DateTime.Now
            };
        }
    }

    public class PocketCalculatorProductFactory : IProductFactory
    {
        public Product CreateProduct(ProductType courseType)
        {
            if (courseType != ProductType.PocketCalculator)
            {
                throw new ArgumentException("This factory can only create pocket calculator.");
            }

            return new Product
            {
                ProductType = ProductType.PocketCalculator,
                Name = "Pocket Calculator",
                Brand = "Innovera",
                Category = "Electronics",
                Price = 20,
                StockCount = 200,
                Warranty = 1,
                Description = "A pocket calculator for quick mathematical calculations.",
                ImageFileName = "PocketCalculator.jpg",
                CreatedAt = DateTime.Now,
                LastUpdated = DateTime.Now
            };
        }
    }
}

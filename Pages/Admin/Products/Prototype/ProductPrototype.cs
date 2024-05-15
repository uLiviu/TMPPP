using Store.Models;

namespace Store.Pages.Admin.Products.Prototype
{
    public class ProductPrototype
    {
        public Product CloneProduct(Product originalProduct)
        {
            return new Product
            {
                Id = 0,
                ProductType = originalProduct.ProductType,
                Name = originalProduct.Name,
                Brand = originalProduct.Brand,
                Category = originalProduct.Category,
                Price = originalProduct.Price,
                Warranty = originalProduct.Warranty,
                StockCount = originalProduct.StockCount,
                Description = originalProduct.Description,
                ImageFileName = originalProduct.ImageFileName,
                CreatedAt = originalProduct.CreatedAt,
                LastUpdated = originalProduct.LastUpdated
            };
        }
    }

}

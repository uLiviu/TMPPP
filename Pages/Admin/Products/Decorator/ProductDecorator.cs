using Store.Models;

namespace Store.Pages.Admin.Products.Decorator
{
    public abstract class ProductDecorator : Product
    {
        protected Product _product;

        public ProductDecorator(Product product)
        {
            _product = product;
        }

        public Product GetDecoratedProduct()
        {
            return _product;
        }
    }
}
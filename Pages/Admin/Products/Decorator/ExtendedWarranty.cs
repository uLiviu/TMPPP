using Store.Models;

namespace Store.Pages.Admin.Products.Decorator
{
    public class ExtendedWarranty : ProductDecorator
    {
        private int _warrantyYears;

        public ExtendedWarranty(Product product) : base(product)
        {
        }

        public override decimal Price
        {
            get
            {
                
                return _product.Price + 5;

            }
            set { _product.Price = value; }
        }
    }
}
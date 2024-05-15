using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Models;
using Store.Services;
using Store.Pages.Admin.Products;
using Store.Pages.Admin.Products.Prototype;
using Store.Pages.Admin.Products.Decorator;
using Microsoft.AspNetCore.Identity;

namespace Store.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;
        private readonly IProductFactory productFactory;
        private readonly ProductPrototype productPrototype;
        private readonly UserManager<User> _userManager;

        public List<Product> Products { get; set; } = new List<Product>();
        [BindProperty]
        public ProductType ProductType { get; set; }

        public IndexModel(ApplicationDbContext context, IProductFactory productFactory, ProductPrototype productPrototype, UserManager<User> userManager)
        {
            this.context = context;
            this.productFactory = productFactory;
            this.productPrototype = productPrototype;
            this._userManager = userManager;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Product newProduct;
                if (ProductType == ProductType.DigitalClock || ProductType == ProductType.PortableRadio || ProductType == ProductType.PocketCalculator)
                {
                    newProduct = productFactory.CreateProduct(ProductType);
                }
                else
                {
                    return RedirectToPage("/Admin/Products/Create");
                }

                context.Products.Add(newProduct);
                context.SaveChanges();
                return RedirectToPage("/Admin/Products/Index");
            }

            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }

        public IActionResult OnPostClone(int id)
        {
            var originalProduct = context.Products.Find(id);
            if (originalProduct == null)
            {
                return NotFound();
            }

            var clonedProduct = productPrototype.CloneProduct(originalProduct);
            context.Products.Add(clonedProduct);
            context.SaveChanges();

            return RedirectToPage("/Admin/Products/Index");
        }

        public IActionResult OnPostAddWarranty(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            if (product.Warranty + 1 > 5)
            {
                TempData["Message"] = "The warranty cannot exceed 5 years.";
                return RedirectToPage("/Admin/Products/Index");
            }

            var extendedProduct = new ExtendedWarranty(product);
            product.Price = extendedProduct.Price;
            product.Warranty += 1;

            context.SaveChanges();

            return RedirectToPage("/Admin/Products/Index");
        }

        public IActionResult OnPostReduceWarranty(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            if (product.Warranty - 1 < 0)
            {
                TempData["Message"] = "The warranty cannot be less than 0 years.";
                return RedirectToPage("/Admin/Products/Index");
            }

            var reducedProduct = new ReducedWarranty(product);
            product.Price = reducedProduct.Price;
            product.Warranty -= 1;

            context.SaveChanges();

            return RedirectToPage("/Admin/Products/Index");
        }

        public async Task<IActionResult> OnPostAddToFavoritesAsync(int id)
        {
            var product = await context.Products.FindAsync(id);
            var user = await _userManager.GetUserAsync(User);

            if (product == null || user == null)
            {
                return NotFound();
            }

            var userProduct = new UserProduct
            {
                UserId = user.Id,
                ProductId = product.Id,
                AddedToFavorites = DateTime.Now
            };

            context.UserProducts.Add(userProduct);
            await context.SaveChangesAsync();

            return RedirectToPage();
        }

        public void OnGet()
        {
            Products = context.Products.OrderByDescending(p => p.Id).ToList();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Store.Models;
using Store.Services;

namespace Store.Pages.Admin.Reviews
{
    public class AddReviewModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AddReviewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; }

        public IList<Product> Products { get; set; }

        public async Task OnGetAsync(int productId)
        {
            Products = await _context.Products.ToListAsync();
            Review = new Review { ProductId = productId };
        }

        public async Task<IActionResult> OnPostAsync(int productId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Review.ProductId = productId;
            Review.UserName = User.Identity.Name;
            Review.CreatedAt = DateTime.Now;
            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}

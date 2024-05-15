using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Store.Models;
using Store.Pages.Admin.Reviews.Strategy;
using Store.Services;

namespace Store.Pages.Admin.Reviews
{
    public class ReviewsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ReviewsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Review> Reviews { get; set; }

        public ISortStrategy SortStrategy { get; set; }
        public void SetSortStrategy(ISortStrategy sortStrategy)
        {
            SortStrategy = sortStrategy;
        }

        public async Task OnGetAsync(int? productId, string sortStrategy)
        {
            switch (sortStrategy)
            {
                case "nameAscending":
                    SetSortStrategy(new SortByProductNameAscending());
                    break;
                case "nameDescending":
                    SetSortStrategy(new SortByProductNameDescending());
                    break;
                case "usernameAscending":
                    SetSortStrategy(new SortByUsernameAscending());
                    break;
                case "usernameDescending":
                    SetSortStrategy(new SortByUsernameDescending());
                    break;
                case "ratingAscending":
                    SetSortStrategy(new SortByRatingAscending());
                    break;
                case "ratingDescending":
                    SetSortStrategy(new SortByRatingDescending());
                    break;
                case "dateAscending":
                    SetSortStrategy(new SortByCreationDateAscending());
                    break;
                case "dateDescending":
                    SetSortStrategy(new SortByCreationDateDescending());
                    break;
            }

            if (productId.HasValue)
            {
                Reviews = await _context.Reviews
                    .Where(r => r.ProductId == productId.Value)
                    .Include(r => r.Product)
                    .ToListAsync();
            }
            else
            {
                Reviews = await _context.Reviews
                    .Include(r => r.Product)
                    .ToListAsync();
            }

            if (SortStrategy != null)
            {
                Reviews = SortStrategy.Sort(Reviews);
            }
        }
    }
}

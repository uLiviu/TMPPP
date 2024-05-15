using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Models;
using Store.Pages.Admin.Reviews.Proxy;

namespace Store.Pages.Admin.Reviews
{
    public class EditModel : PageModel
    {
        private readonly IReviewService _reviewService;

        public EditModel(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [BindProperty]
        public Review Review { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = _reviewService.GetReview(id.Value);

            if (Review == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var originalReview = _reviewService.GetReview(Review.Id);
                originalReview.Rating = Review.Rating;
                originalReview.Comment = Review.Comment;
                _reviewService.UpdateReview(originalReview);
            }
            catch (NotAuthorException ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }

    }
}
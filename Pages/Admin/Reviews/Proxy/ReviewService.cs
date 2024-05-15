using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Models;
using Store.Services;
using System.Linq;

namespace Store.Pages.Admin.Reviews.Proxy
{
    public interface IReviewService
    {
        Review GetReview(int reviewId);
        void UpdateReview(Review review);
    }

    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.AsNoTracking().FirstOrDefault(r => r.Id == reviewId);
        }


        public void UpdateReview(Review review)
        {
            _context.Reviews.Attach(review);
            _context.Entry(review).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }

    public class NotAuthorException : Exception
    {
        public NotAuthorException(string username) : base($"Only {username} can modify the review.") { }
    }

    public class ReviewServiceProxy : IReviewService
    {
        private readonly IReviewService _reviewService;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReviewServiceProxy(IReviewService reviewService, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _reviewService = reviewService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public Review GetReview(int reviewId)
        {
            return _reviewService.GetReview(reviewId);
        }

        public void UpdateReview(Review review)
        {
            var user = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            var originalReview = _reviewService.GetReview(review.Id);

            if (originalReview.UserName == user.UserName)
            {
                _reviewService.UpdateReview(review);
            }
            else
            {
                throw new NotAuthorException(originalReview.UserName);
            }
        }
    }
}
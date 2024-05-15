using Store.Models;

namespace Store.Pages.Admin.Reviews.Strategy
{
    public interface ISortStrategy
    {
        IList<Review> Sort(IList<Review> reviews);
    }

    public class SortByProductNameAscending : ISortStrategy
    {
        public IList<Review> Sort(IList<Review> reviews)
        {
            return reviews.OrderBy(r => r.Product.Name).ToList();
        }
    }

    public class SortByProductNameDescending : ISortStrategy
    {
        public IList<Review> Sort(IList<Review> reviews)
        {
            return reviews.OrderByDescending(r => r.Product.Name).ToList();
        }
    }

    public class SortByUsernameAscending : ISortStrategy
    {
        public IList<Review> Sort(IList<Review> reviews)
        {
            return reviews.OrderBy(r => r.UserName).ToList();
        }
    }

    public class SortByUsernameDescending : ISortStrategy
    {
        public IList<Review> Sort(IList<Review> reviews)
        {
            return reviews.OrderByDescending(r => r.UserName).ToList();
        }
    }

    public class SortByRatingAscending : ISortStrategy
    {
        public IList<Review> Sort(IList<Review> reviews)
        {
            return reviews.OrderBy(r => r.Rating).ToList();
        }
    }

    public class SortByRatingDescending : ISortStrategy
    {
        public IList<Review> Sort(IList<Review> reviews)
        {
            return reviews.OrderByDescending(r => r.Rating).ToList();
        }
    }

    public class SortByCreationDateAscending : ISortStrategy
    {
        public IList<Review> Sort(IList<Review> reviews)
        {
            return reviews.OrderBy(r => r.CreatedAt).ToList();
        }
    }

    public class SortByCreationDateDescending : ISortStrategy
    {
        public IList<Review> Sort(IList<Review> reviews)
        {
            return reviews.OrderByDescending(r => r.CreatedAt).ToList();
        }
    }
}

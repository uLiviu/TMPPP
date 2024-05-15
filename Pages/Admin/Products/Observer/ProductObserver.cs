using Store.Models;
using Store.Services;

namespace Store.Pages.Admin.Products.Observer
{
    public interface IProductObserver
    {
        Task ProductDeleted(Product product);
        Task ProductUpdated(Product product);
    }

    public class UserNotificationService : IProductObserver
    {
        private readonly ApplicationDbContext _context;

        public UserNotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ProductDeleted(Product product)
        {
            var users = _context.UserProducts.Where(up => up.ProductId == product.Id).Select(up => up.User);

            foreach (var user in users)
            {
                var notification = new Notification
                {
                    UserId = user.Id,
                    Message = $"Produsul {product.Name} a fost șters.",
                    Timestamp = DateTime.Now
                };
                _context.Notifications.Add(notification);
            }

            await _context.SaveChangesAsync();
        }

        public async Task ProductUpdated(Product product)
        {
            var users = _context.UserProducts.Where(up => up.ProductId == product.Id).Select(up => up.User);

            foreach (var user in users)
            {
                var notification = new Notification
                {
                    UserId = user.Id,
                    Message = $"Produsul {product.Name} a fost actualizat.",
                    Timestamp = DateTime.Now
                };
                _context.Notifications.Add(notification);
            }

            await _context.SaveChangesAsync();
        }
    }

}

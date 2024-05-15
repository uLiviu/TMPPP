using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Store.Models;
using Store.Services;

namespace Store.Pages.Admin.FavoriteProducts
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public DeleteModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var userProduct = await _context.UserProducts
                .FirstOrDefaultAsync(up => up.UserId == user.Id && up.ProductId == id);

            if (userProduct == null)
            {
                return NotFound();
            }

            _context.UserProducts.Remove(userProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Store.Services;
using Store.Models;
using Store.Pages.Admin.Products.Observer;

namespace Store.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductObserver _productObserver;

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public EditModel(ApplicationDbContext context, IProductObserver productObserver)
        {
            _context = context;
            _productObserver = productObserver;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product.LastUpdated = DateTime.Now;

            if (ImageFile != null)
            {
                var fileName = ProcessUploadedFile();

                var old = Product.ImageFileName;

                Product.ImageFileName = fileName;

                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products", old);
                if (System.IO.File.Exists(oldFilePath))
                {
                    try
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to delete file: {ex.Message}");
                    }
                }
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                await _productObserver.ProductUpdated(Product);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private string ProcessUploadedFile()
        {
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products", uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                ImageFile.CopyTo(fileStream);
            }

            return uniqueFileName;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }

}

using FarmLink.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FarmLink.Controllers
{
    public class MarketplaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarketplaceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var products = _context.Products
                                   .Include(p => p.Farmer)
                                   .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p =>
                    p.ProductName.Contains(search) ||
                    p.Category.Contains(search));
            }

            ViewBag.Search = search;

            return View(products.ToList());
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products
                                  .Include(p => p.Farmer)
                                  .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
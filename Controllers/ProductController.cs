using FarmLink.Data;
using FarmLink.Models;
using Microsoft.AspNetCore.Mvc;
using FarmLink.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace FarmLink.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        // Display all products
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var products = _context.Products
                                   .Where(p => p.FarmerId == userId)
                                   .ToList();

            return View(products);
        }

        // Display Add Product page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string? fileName = null;

            if (model.ImageFile != null)
            {
                fileName = Guid.NewGuid().ToString() +
                           Path.GetExtension(model.ImageFile.FileName);

                string uploadFolder = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "images",
                    "products");

                string filePath = Path.Combine(uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }
            }

            var product = new Product
            {
                ProductName = model.ProductName,
                Category = model.Category,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity,
                Unit = model.Unit,
                FarmerId = HttpContext.Session.GetInt32("UserId") ?? 0,
                ImagePath = fileName
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        // Display Edit Product page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var product = _context.Products
                .FirstOrDefault(p => p.Id == id && p.FarmerId == userId);

            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductViewModel
            {
                ProductName = product.ProductName,
                Category = product.Category,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Unit = product.Unit
            };

            ViewBag.ProductId = product.Id;

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProductId = id;
                return View(model);
            }

            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var product = _context.Products
                .FirstOrDefault(p => p.Id == id && p.FarmerId == userId);

            if (product == null)
            {
                return NotFound();
            }

            // Update product details
            product.ProductName = model.ProductName;
            product.Category = model.Category;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Quantity = model.Quantity;
            product.Unit = model.Unit;

            // Update image if a new one was uploaded
            if (model.ImageFile != null)
            {
                string fileName = Guid.NewGuid().ToString() +
                                  Path.GetExtension(model.ImageFile.FileName);

                string uploadFolder = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "images",
                    "products");

                string filePath = Path.Combine(uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                product.ImagePath = fileName;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
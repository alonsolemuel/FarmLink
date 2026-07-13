using Microsoft.AspNetCore.Mvc;

namespace FarmLink.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
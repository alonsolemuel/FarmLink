using Microsoft.AspNetCore.Mvc;

namespace FarmLink.Controllers
{
    public class FarmerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
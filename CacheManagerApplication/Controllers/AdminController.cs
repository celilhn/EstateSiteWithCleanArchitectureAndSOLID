using Microsoft.AspNetCore.Mvc;

namespace CacheManagerApplication.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

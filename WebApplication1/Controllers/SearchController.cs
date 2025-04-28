using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Matches()
        {
            return View();
        }
        public IActionResult Players()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Players : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

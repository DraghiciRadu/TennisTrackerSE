using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Matches : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

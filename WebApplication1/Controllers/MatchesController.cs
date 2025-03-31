using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class MatchesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

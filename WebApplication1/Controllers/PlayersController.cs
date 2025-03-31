using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class PlayersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

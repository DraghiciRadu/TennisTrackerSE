﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

﻿namespace CameraBazaar.App.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using CameraBazaar.App.Models;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System.Diagnostics;
using gitnetcore.Models;
using Microsoft.AspNetCore.Mvc;

namespace gitnetcore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
public IActionResult product()
        {
            return View();
        }
        public IActionResult intro()
        {
            return View();
        }
        public IActionResult news()
        {
            return View();
        }
        
         
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

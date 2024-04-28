using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WELLTRACKSOFT.Models;

namespace WELLTRACKSOFT.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DashBoard()
        {
            return View();
        }


        public IActionResult Configuration()
        {
            return View();
        }


        public IActionResult MasterConfiguration()
        {
            return View();
        }

        public IActionResult billingmenu()
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

using BincomAssign2.Okwe.Implementation;
using BincomAssign2.Okwe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BincomAssign2.Okwe.Controllers
{
    public class HomeController : Controller
    {
        private readonly Calculator _calculator;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Calculator calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Skills()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult PAYECalculator()
        {
            return View(new PAYE());
        }

        [HttpPost]
        public IActionResult Calculate(PAYE model)
        {
            model.Tax = _calculator.CalculatePAYE(model.Income);
            ViewBag.CalculatedTax = model.Tax; 
            return View("PAYECalculator", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


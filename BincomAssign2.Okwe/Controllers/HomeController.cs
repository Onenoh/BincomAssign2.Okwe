using BincomAssign2.Okwe.Data;
using BincomAssign2.Okwe.Implementation;
using BincomAssign2.Okwe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList.Extensions;

namespace BincomAssign2.Okwe.Controllers
{
    public class HomeController : Controller
    {
        private readonly Calculator _calculator;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Calculator calculator, ApplicationDbContext context)
        {
            _logger = logger;
            _calculator = calculator;
            _context = context;
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

        public IActionResult PhotoGallery(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var photos = _context.Photos.OrderBy(p => p.Id).ToPagedList(pageNumber, pageSize);
            return View(photos);
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file, string title, string description)
        {
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);

                    var photo = new Photo
                    {
                        Title = title,
                        Description = description,
                        ImageMimeType = file.ContentType,
                        ImageData = memoryStream.ToArray() 
                    };

                    _context.Photos.Add(photo);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("PhotoGallery");
        }

        public IActionResult Details(int id)
        {
            var photo = _context.Photos.Find(id);
            return View(photo);
        }

        public IActionResult GetImage(int id)
        {
            var photo = _context.Photos.Find(id);
            if (photo != null)
            {
                return File(photo.ImageData, photo.ImageMimeType);
            }
            return null;
        }


        public IActionResult Delete(int id)
        {
            var photo = _context.Photos.Find(id);
            return View(photo);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            
            if (photo != null) 
            {
                _context.Photos.Remove(photo);
                _context.SaveChanges();
            }
                
            return RedirectToAction("PhotoGallery");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


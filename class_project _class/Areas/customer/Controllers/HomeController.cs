
using Microsoft.AspNetCore.Mvc;
using project_data.IRepositry;
using Project_model;
using System.Diagnostics;

namespace class_project__class.Areas.customer.Controllers
{
    [Area("customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Iunitofwork _unitofwork;

        public HomeController(ILogger<HomeController> logger, Iunitofwork unitofwork)
        {
            _logger = logger;
            _unitofwork = unitofwork;
        }

        public IActionResult Index()
        {
            var product = _unitofwork.Product.Getall(includeProperties: "Category,CoverType");
            return View(product);
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

using Microsoft.AspNetCore.Mvc;
using project_data.IRepositry;
using Project_model;
using Projrct_unite;
using System.Diagnostics;
using System.Security.Claims;

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
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var count = _unitofwork.ShoppingCart.Getall(sc => sc.ApplicationUserId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(SD.Ss_cartSessionCount, count);
            }
            var product = _unitofwork.Product.Getall(includeProperties: "Category,CoverType");
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var m = _unitofwork.Product.FirstOrDefoult(p => p.Id == id);
            if (m == null) return NoContent();
            var shpo = new ShoppingCart()
            {
                Product = m,
                ProductId = m.Id
            };


            return View(shpo);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Details(ShoppingCart shop)
        {
            shop.Id = 0;
            if (!ModelState.IsValid)
            {
                var clamsid = (ClaimsIdentity)User.Identity;
                var claim = clamsid.FindFirst(ClaimTypes.NameIdentifier);
                shop.ApplicationUserId = claim.Value;
                var shoopingcartdb = _unitofwork.ShoppingCart.FirstOrDefoult
                    (sc => sc.ApplicationUserId == claim.Value && sc.ProductId == shop.ProductId);
                if (shoopingcartdb == null) _unitofwork.ShoppingCart.Add(shop);
                else
                    shoopingcartdb.Count += shop.Count;
                _unitofwork.save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var m = _unitofwork.Product.FirstOrDefoult(p => p.Id == shop.Product.Id);
                if (m == null) return NoContent();
                var shpo = new ShoppingCart()
                {
                    Product = m,
                    ProductId = m.Id
                };

                return View(shpo);
            }
            //    var m = _unitofwork.Product.FirstOrDefoult(p => p.Id == id);
            //if (m == null) return NoContent();
            //var shpo = new ShoppingCart()
            //{
            //    Product = m,
            //    ProductId = m.Id
            //};


        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
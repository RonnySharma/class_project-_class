using Microsoft.AspNetCore.Mvc;
using project_data.IRepositry;
using project_data.Repository;
using Project_model;
using Project_model.ViewModels;
using Projrct_unite;
using System.Security.Claims;
using static NuGet.Packaging.PackagingConstants;

namespace class_project__class.Areas.customer.Controllers
{
    [Area("customer")]
    public class CartController : Controller
    {
        private readonly Iunitofwork _unitowork;
        public CartController(Iunitofwork unitofwork)
        {
            _unitowork = unitofwork;

        }
        public CardVM CardVM { get; set; }
        public IActionResult Index()
        {
            var claimsIdentiy = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentiy.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                CardVM = new CardVM()
                {
                    IsblogActive = false,
                    // isblogactivecheck = "Is blog active",
                    ListCart = new List<ShoppingCart>()
                };
                return View(CardVM);
            }

            CardVM = new CardVM()
            {
                ListCart = _unitowork.ShoppingCart.Getall(sc => sc.ApplicationUserId == claim.Value, includeProperties: "Product"),
                OrderHeader = new OrderHeader()
            };
            CardVM.OrderHeader.OrderTotal = 0;
            CardVM.OrderHeader.ApplicationUser = _unitowork.ApplicationUser.FirstOrDefoult(u => u.Id == claim.Value, includeProprties: "Company");
            foreach (var list in CardVM.ListCart)
            {
                list.Price = SD.GetPriceBasedOnQuantity(list.Count, list.Product.Price, list.Product.Price50, list.Product.Price100);
                CardVM.OrderHeader.OrderTotal += (list.Count * list.Price);

                if (list.Product.Description.Length > 100)
                {
                    list.Product.Description = list.Product.Description.Substring(0, 99) + "...";
                }
            }
            //if (!isEmailConfirm)
            //{
            //    ViewBag.EmailMassage = "Email HAs been";
            //    ViewBag.emailCss = "text-success";
            //    ViewBag.isEmailConfirm = false;

            //}
            //else
            //{
            //    ViewBag.EmailMassage = "Email HAs been";
            //    ViewBag.emailCss = "text-success";
            return View(CardVM);

        }



    }
}
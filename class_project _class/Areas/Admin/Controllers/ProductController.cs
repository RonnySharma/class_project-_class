using Microsoft.AspNetCore.Mvc;
using project_data.IRepositry;
using Project_model.ViewModels;

namespace class_project__class.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly Iunitofwork _unitofwork;
        public ProductController( Iunitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult upsert()
        { ProductVM productVM = new ProductVM();
            {
                //po
            };
            return View();
        }
    }
}

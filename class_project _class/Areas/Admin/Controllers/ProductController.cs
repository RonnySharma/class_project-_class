using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using project_data.IRepositry;
using Project_model;
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
        public IActionResult upsert(int? id)
        { ProductVM productVM = new ProductVM()
        {
            Product = new Product(),
            catalist = _unitofwork.Category.Getall().Select(cl => new SelectListItem()
            {
                Text = cl.Name,
                Value = cl.Id.ToString()
            }),
            covertypeList = _unitofwork.Covertype.Getall().Select(ct => new SelectListItem()
            {
                Text = ct.Name,
                Value = ct.Id.ToString()
            })

        };
            if (id == null) return View(productVM);
            productVM.Product=_unitofwork.Product.get(id.GetValueOrDefault());

            return View(productVM);
        }
    }
}

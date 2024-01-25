using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host.Mef;

using project_data.IRepositry;
using project_data.Repository;
using Project_model;
using Projrct_unite;

namespace projevt_class_ecom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly Iunitofwork _unitofwork;
        public CategoryController(Iunitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            var categoryList = _unitofwork.Category.Getall();
            return Json(new { data = categoryList });
        }
   

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var cat = _unitofwork.Category.get(id);

            if (cat == null) return Json(new
            {
                success = false,
                message = "Something went !!!"
            });
            _unitofwork.Category.Remove(cat);
            _unitofwork.save();
            return Json(new { success = true, message = "Data is Delete suceess!!!" });
        }
        #endregion
        public IActionResult upsert(int? id)
        {
            Category category = new Category();
            if (id == null) return View(category);
            category = _unitofwork.Category.get(id.GetValueOrDefault());
            if (category == null) return View(category);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult upsert(Category category)
        {
            if (category == null) return NotFound();
            if (!ModelState.IsValid) return View(category);
            if (category.Id == 0)
                _unitofwork.Category.Add(category);
            else
                _unitofwork.Category.update(category);
            _unitofwork.save();
            return RedirectToAction("Index");
        }


    }
}

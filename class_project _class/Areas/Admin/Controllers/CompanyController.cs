using Microsoft.AspNetCore.Mvc;
using project_data.IRepositry;
using project_data.Repository;
using Project_model;

namespace class_project__class.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly Iunitofwork _unitofwork;
        public CompanyController(Iunitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult upsert(int? id)
        {
            Company company = new Company();
            if (id == null) return View(company);
            company = _unitofwork.Company.get(id.GetValueOrDefault());
            if (company == null) return NotFound();


            return View(company);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult upsert(Company company)
        {
            if (company == null) return NotFound();
            if (!ModelState.IsValid) return View(company);
            if (company.Id == 0)
                _unitofwork.Company.Add(company);
            else
                _unitofwork.Company.update(company);
            _unitofwork.save();
            return RedirectToAction("Index");
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitofwork.Company.Getall() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var cat = _unitofwork.Company.get(id);

            if (cat == null) return Json(new
            {
                success = false,
                message = "Something went !!!"
            });
            _unitofwork.Company.Remove(cat);
            _unitofwork.save();
            return Json(new { success = true, message = "Data is Delete suceess!!!" });
        }
        #endregion
    }



}

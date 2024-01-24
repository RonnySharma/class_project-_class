using Dapper;
using Microsoft.AspNetCore.Mvc;
using project_data.IRepositry;

using project_data.Repository;
using Project_model;
using Projrct_unite;

namespace class_project__class.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CovertypeController : Controller
    {
        private readonly Iunitofwork _unitofwork;
        public CovertypeController(Iunitofwork unitofwork)
        {
            _unitofwork= unitofwork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult upsert(int? id)
        {
            Covertype covertype = new Covertype();
            if (id == null) return View(covertype);
            covertype = _unitofwork.Covertype.get(
                id.GetValueOrDefault());
            //var param.add("@id",id getvalu)
            if (covertype == null) return NotFound();
            return View(covertype);
        }
        public IActionResult upsert(Covertype covertype)
        { if (covertype == null) return NotFound();
        if(!ModelState.IsValid) return View(covertype);
            var ms = new DynamicParameters();
            ms.Add("Name",covertype.Name);
            if(covertype.Id==0)
            {
                _unitofwork.spcall.excecute(SD.proc_CreateCoverType, ms);
            }else
            {
                ms.Add("@id", covertype.Id);
                _unitofwork.spcall.excecute(SD.proc_updateCoverType, ms);
                _unitofwork.save();
            }
            return View(covertype);
        }
    }
}

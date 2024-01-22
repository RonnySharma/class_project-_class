using Microsoft.AspNetCore.Mvc;

namespace class_project__class.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CovertypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

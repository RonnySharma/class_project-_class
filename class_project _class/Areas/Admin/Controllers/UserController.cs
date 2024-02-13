using Microsoft.AspNetCore.Mvc;
using project_data;
using project_data.IRepositry;
using project_data.Repository;
using Project_model;
using Projrct_unite;

namespace class_project__class.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Iunitofwork _unitowork;
        public UserController(ApplicationDbContext context,Iunitofwork unitofwork)
        {
            
           _unitowork = unitofwork;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Api


        [HttpGet]
        public IActionResult Getall()
        {
            var userList = _context.ApplicationUsers.ToList();
            //aspNetUseers
            var roles = _context.Roles.ToList();
            //aspNetRoles
            var userRoles = _context.UserRoles.ToList();
            //aspnetuserRoles
            foreach (var user in userList)
            {
                var roleId = userRoles.FirstOrDefault(r => r.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(r => r.Id == roleId).Name;
                if (user.CompanyId != null)
                {
                    user.Company = new Company()
                    {
                        Name = _unitowork.Company.get(Convert.ToInt32(user.CompanyId)).Name
                    };
                }
                if (user.CompanyId == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }
            var adminUser = userList.FirstOrDefault(u => u.Role == SD.Role_Admin);
            userList.Remove(adminUser);
            return Json(new { data = userList });
        }
        #endregion
    }
}

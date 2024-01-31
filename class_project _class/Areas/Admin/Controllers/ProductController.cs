using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using project_data.IRepositry;
using project_data.Repository;
using Project_model;
using Project_model.ViewModels;

namespace class_project__class.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly Iunitofwork _unitofwork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController( Iunitofwork unitofwork, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
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
            CategoryList = _unitofwork.Category.Getall().Select(cl => new SelectListItem()
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
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult upsert(ProductVM productVM)
        {
            if(!ModelState.IsValid)
            {
                var mo = _webHostEnvironment.WebRootPath;
                var f = HttpContext.Request.Form.Files;
                if (f.Count() > 0)
                {
                    var filename = Guid.NewGuid().ToString();
                    var extension = Path.GetExtension(f[0].FileName);
                    var uploads = Path.Combine(mo, @"Image\Product");
                    if (productVM.Product.Id != 0)
                    {
                        var ImagerExists = _unitofwork.Product.get(productVM.Product.Id).ImgeUrl;
                        productVM.Product.ImgeUrl = ImagerExists;
                    }
                    if (productVM.Product.ImgeUrl != null)
                    {
                        var imagepath = Path.Combine(mo, productVM.Product.ImgeUrl.Trim('\\'));
                        if (System.IO.File.Exists(imagepath))
                        {
                            System.IO.File.Delete(imagepath);
                        }
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        f[0].CopyTo(filestream);
                    }
                    productVM.Product.ImgeUrl = @"\Image\Product\" + filename + extension;
                }
                else
                {
                    if (productVM.Product.Id != 0)
                    {
                        var imageexists = _unitofwork.Product.get(productVM.Product.Id).ImgeUrl;
                        productVM.Product.ImgeUrl = imageexists;
                    }
                }
                if(productVM.Product.Id==0)
                    _unitofwork.Product.Add(productVM.Product);
                else
                
                    _unitofwork.Product.update(productVM.Product);
                    _unitofwork.save();
                    return RedirectToAction("Index");
}
            else
            {


                productVM = new ProductVM()
                    {
                        Product = new Product(),
                        CategoryList = _unitofwork.Category.Getall().Select(cl => new SelectListItem()
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
                    if (productVM.Product.Id !=0)
                    productVM.Product = _unitofwork.Product.get(productVM.Product.Id);

                    return View(productVM);
                }
            }
         
        }
          

        

    
}

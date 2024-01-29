using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_model.ViewModels
{
      public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> catalist { get; set; }
        public IEnumerable<SelectListItem> covertypeList { get; set; }
    }
}

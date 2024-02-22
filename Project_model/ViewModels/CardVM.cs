using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_model.ViewModels
{
public class CardVM
    {
        public IEnumerable<ShoppingCart> ListCart { get; set; }
        public bool IsblogActive { get; set; }
        public string Isblogactivecheck { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_model
{
   public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
      
        public OrderHeader OrderHeader { get; set; }
        public int ProductId { get; set; }
    
        public Product Product { get; set; }
        public int Count { get; set; }
        public Double Price { get; set; }
    }
}

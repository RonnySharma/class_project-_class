using project_data.IRepositry;
using Project_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace project_data.Repository
{
   public class OrderDetailRepository:Repository<OrderDetail>,IOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailRepository(ApplicationDbContext context):base(context) { 
         _context = context;
        
        }

       
    }
}

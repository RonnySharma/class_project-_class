using project_data.IRepositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_data.Repository
{
    public class Unitofwork : Iunitofwork
    {
        private readonly ApplicationDbContext _context;

        public Unitofwork(ApplicationDbContext context)
        {

            _context = context;

            Category = new categoryRepostry(_context);

        }

        public IcategoryRepostry Category {  get;  private  set; }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}

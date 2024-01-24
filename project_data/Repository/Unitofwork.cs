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
            Covertype = new CovertyprRepository(_context);
            spcall = new spcall(_context);
        }

        public IcategoryRepostry Category {  get;  private  set; }
        public ICovertype Covertype { get; private set; }
        public Ispcall spcall { get; private set; }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}

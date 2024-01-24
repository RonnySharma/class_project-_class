using project_data.IRepositry;
using Project_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_data.Repository
{
   public class CovertyprRepository:Repository<Covertype>,ICovertype
    {
        private readonly ApplicationDbContext _context;
        public CovertyprRepository(ApplicationDbContext context):base(context) { _context = context; }
       
    }
}

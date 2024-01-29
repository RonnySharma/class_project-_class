using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_data.IRepositry
{
   public interface Iunitofwork

    {
        IcategoryRepostry Category { get; }
        ICovertype Covertype { get; }
        Ispcall spcall { get; } 
        IProductRepostry Product { get; }

        void save();
    }
}

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
        ICompany Company { get; }
        IOrderHeader OrderHeader { get; }
        IOrderDetailRepository OrderDetail { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IShoppingCartRepository ShoppingCart { get; }
        void save();
    }
}

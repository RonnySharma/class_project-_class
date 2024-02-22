using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projrct_unite
{
 public static class SD
    {
        public const string proc_getcovertypes = "getCoverTypes";
        public const string proc_getcovertype = "getCoverType";
        public const string proc_CreateCoverType = "covertytre";
        public const string proc_updateCoverType = "updateCoverType";
        public const string proc_DeleteCoverTypes = "DeleteCoverTypes";
        //rolles
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";
        public const string Role_Company = "company";
        public const string Role_Individual = "Individual";

        public const string Ss_cartSessionCount = "CartCountSession";
        public static double GetPriceBasedOnQuantity(double Quantity, double Price, double Price50, double Price100)
        {
            if (Quantity < 50)
            {
                return Price;
            }
            else if (Quantity < 100)
            {
                return Price50;
            }
            else
            {
                return Price100;
            }
        }
    }
}

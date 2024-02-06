﻿using project_data.IRepositry;
using Project_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_data.Repository
{
 public class ShoppingCartRepository: Repository<ShoppingCart>,IShoppingCartRepository
    {
         private readonly ApplicationDbContext _context;
        public ShoppingCartRepository(ApplicationDbContext context):base(context) {
        
        _context = context;
        }

        
    }
}

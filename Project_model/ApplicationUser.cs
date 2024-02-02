﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Project_model
{
public class ApplicationUser: IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Display(Name = "street Address")]
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        [Display(Name = "Postal code")]
        public string Postalcode { get; set; }
        [Display(Name = "company")]
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Sprint16.Models;
using System.ComponentModel.DataAnnotations;

namespace Sprint16.ViewModels
{
    public class CustomerViewModel
    {
        [MaxLength(50)]
        [Display(Name = "First name")]
        public string Fname { get; set; }
        [MaxLength(50)]
        [Display(Name = "Last name")]
        public string Lname { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        public Discount Discount { get; set; }
    }
}

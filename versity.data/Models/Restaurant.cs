﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace versity.data.Models
{
    public class Restaurant
    {
        public Restaurant()
        {
            Menus = new List<Menu>();
            Hours = new List<Hours>();
            Locations = new List<Location>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public virtual List<Hours> Hours { get; set; }

        public virtual List<Menu> Menus { get; set; }

        public virtual List<Location> Locations { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace versity.data.Models
{
    public class Menu
    {
        public Menu()
        {
            Items = new List<Item>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}

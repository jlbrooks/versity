using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace versity.data.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Menu")]
        public int MenuID { get; set; }

        public virtual Menu Menu { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public Category Category { get; set; }
    }

    public enum Category
    {
        Entrees=0,
        Appetizers=1,
        Desserts=2,
        Drinks=3
    }
}

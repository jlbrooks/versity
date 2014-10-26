using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace versity.data.Models
{
    public class Location
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
}

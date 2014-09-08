using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace versity.data.Models
{
    public class Hours
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        [Required]
        public DayOfWeek Day { get; set; }

        [Required]
        public TimeSpan Open { get; set; }

        [Required]
        public TimeSpan Closed { get; set; }
    }
}

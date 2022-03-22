using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleSignup_Mission12_.Models
{
    public class Times
    {
        [Key]
        [Required]
        public int TimeId { get; set; }
        public string TimeSlot { get; set; }

    }
}

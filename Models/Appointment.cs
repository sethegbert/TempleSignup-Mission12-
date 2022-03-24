using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleSignup_Mission12_.Models
{
    //This Model will keep track of days and will connect with a Time Model
    public class Appointment
    {

        [Key]
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int Slots { get; set; }
        public int TimeId { get; set; }
        public Times Time { get; set; }

    }
}

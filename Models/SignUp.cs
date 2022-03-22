using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleSignup_Mission12_.Models
{
    public class SignUp
    {
        [Key]
        [Required]
        public int SignUpId { get; set; }
        [Required]
        public int GroupSize { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}

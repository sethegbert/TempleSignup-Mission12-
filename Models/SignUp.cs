using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleSignup_Mission12_.Models
{
    //This keeps tracks of groups and assigns them to specific days
    public class SignUp
    {
        [Key]
        [Required]
        public int SignUpId { get; set; }
        [Required(ErrorMessage = "Please enter a group size")]
        [Range(0, 15)]
        public int GroupSize { get; set; }
        [Required(ErrorMessage = "Please enter a group name")]
        public string GroupName { get; set; }
        [Required(ErrorMessage = "Please enter an email")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}

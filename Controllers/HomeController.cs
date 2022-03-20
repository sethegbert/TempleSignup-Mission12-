using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempleSignup_Mission12_.Models;

namespace TempleSignup_Mission12_.Controllers
{
 
    // We reference the HomeController inherited from Controller so the program knows where to look
    public class HomeController : Controller
    {

        // Set up a reference to the AppointmentContext Model so the program can get and set info from it
        private AppointmentContext appointments { get; set; }
        
        public HomeController(AppointmentContext blah)
        {
            appointments = blah;
        }

        public IActionResult Index()
        {
            return View();
        }

        // This will return the SignUp page when we click the button to take us there (using asp controller)

        public IActionResult SignUp()
        {
            return View();
        }
    }
}

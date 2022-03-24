using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

            var Appointments = appointments.Appointments.Include(x => x.Time).OrderBy(x => x.Time.TimeSlot).ToList();
            // var Times = appointments.Times.Include(x => x.TimeId).ToList();
            
            List<String> futureDays = new List<String>();
            
            for (int i = 0; i < 89; i++)
            {
                futureDays.Add(DateTime.Now.AddDays(i).ToString("MM/dd/yyyy"));
            }
            ViewBag.Days = futureDays;
            return View(Appointments);
        }


        //Takes us to the Appointment page
        [HttpGet]
        public IActionResult AppointmentList()
        {
            var app = appointments.SignUps
                .Include(x => x.Appointment)
                .ThenInclude(x => x.Time)
                .OrderBy(x => x.Appointment.Date)
                .ToList();

            return View(app);
        }

        //This will allow the user to be rerouted to the GroupInfo form and make any desired changes

        [HttpGet]
        public IActionResult Edit()
        {
            ViewBag.SignUp = appointments.Appointments.ToList();
            //This grabs the signupId from the RouteData
            var signupId = Convert.ToInt32(RouteData.Values["id"]);
            var signup = appointments.SignUps.Single(x => x.SignUpId == signupId);
            ViewBag.App = signup.AppointmentId;

            return View("GroupInfo", signup);
        }

        //This is what will update an existing record when the user edits
        [HttpPost]
        public IActionResult Edit(SignUp su)
        {
            appointments.Update(su);
            appointments.SaveChanges();

            return RedirectToAction("AppointmentList");
        }


        //This will grab the signupid from RouteData and redirect to confirm delete page
        [HttpGet]
        public IActionResult Delete()
        {
            var signupid = Convert.ToInt32(RouteData.Values["id"]);

            ViewBag.SignUp = appointments.Appointments.ToList();

            var appointment = appointments.SignUps.Include(x => x.Appointment).ThenInclude(x => x.Time).Single(x => x.SignUpId == signupid);

            return View(appointment);
        }

        //This will delete the record
        [HttpPost]
        public IActionResult Delete(SignUp su)
        {
            appointments.SignUps.Remove(su);
            appointments.SaveChanges();

            return RedirectToAction("AppointmentList");
        }

        //This will show the form to add a group to an appointment
        [HttpGet]
        public IActionResult GroupInfo(int appId)
        {
            //int timeId = Convert.ToInt32(RouteData.Values["id"]);
            var app = appointments.Appointments.Single(x => x.AppointmentId == appId);

            var signup = new SignUp();
            signup.Appointment = app;
            signup.AppointmentId = appId;

            // ViewBag.App = appId;            

            return View();
        }

        //This is what will make a new SignUp record based off the form
        [HttpPost]
        public IActionResult GroupInfo(SignUp su)
        {
            ViewBag.SignUp = appointments.Appointments.ToList();

            if (ModelState.IsValid)
            {

                appointments.Add(su);
                appointments.SaveChanges();
            }
            else
            {
                ViewBag.SignUp = appointments.Appointments.ToList();

                ViewBag.App = su.AppointmentId;

                return View();
            }

            return RedirectToAction("Index");
        }

        //This shows appointments that are available 
        public IActionResult ChooseAppointment()
        {
            string date = RouteData.Values["id"].ToString();
            string newDate = date.Replace("%2F", "/");
            
            var currentApp = appointments.Appointments.Where(x => x.Date == newDate).Include(blah => blah.Time).OrderBy(x => x.Time.TimeSlot).ToList();
            

            List<Times> takenTimes = new List<Times>();
            foreach (var x in currentApp)
            {
                takenTimes.Add(x.Time);
            }

            //Make a list that has times that have not been taken
            var freeTimes = appointments.Times.ToList().Except(takenTimes);
            

            ViewBag.Times = freeTimes;

            ViewBag.Date = newDate;

            return View(currentApp);
        }

        //This will create an Appointment record when the user selects a time. This needs to be created before a SignUp record is created.
        [HttpPost]
        public IActionResult CreateAppointment(int timeId, string date)
        {
            appointments.Add(new Appointment { Date=date, Location="Layton Temple Visitors Center", Slots=10, TimeId=timeId });
            appointments.SaveChanges();
            var appointmentId = appointments.Appointments.Where(x => x.Date == date).Single(x => x.TimeId == timeId);

            int AppId = appointmentId.AppointmentId;

            ViewBag.App = AppId;

            return View("GroupInfo");
        }
    }
}

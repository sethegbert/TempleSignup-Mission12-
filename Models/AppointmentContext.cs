using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleSignup_Mission12_.Models
{

    // DbContext is part of the EntityFrameworkCore, and here we reference it so our model can inherit
    public class AppointmentContext : DbContext
    {
        public AppointmentContext (DbContextOptions<AppointmentContext> options) : base (options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<Times> Times { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Times>().HasData(
                new Times { TimeId = 1, TimeSlot = "8:00am-9:00am" },
                new Times { TimeId = 2, TimeSlot = "9:00am-10:00am" },
                new Times { TimeId = 3, TimeSlot = "10:00am-11:00am" },
                new Times { TimeId = 4, TimeSlot = "11:00am-12:00pm" },
                new Times { TimeId = 5, TimeSlot = "12:00pm-1:00pm" },
                new Times { TimeId = 6, TimeSlot = "1:00pm-2:00pm" },
                new Times { TimeId = 7, TimeSlot = "2:00pm-3:00pm" },
                new Times { TimeId = 8, TimeSlot = "3:00pm-4:00pm" },
                new Times { TimeId = 9, TimeSlot = "4:00pm-5:00pm" },
                new Times { TimeId = 10, TimeSlot = "5:00pm-6:00pm" },
                new Times { TimeId = 11, TimeSlot = "6:00pm-7:00pm" },
                new Times { TimeId = 12, TimeSlot = "7:00pm-8:00pm" }
                );

            mb.Entity<Appointment>().HasData(
                new Appointment
                {
                    AppointmentId = 1,
                    Date = "3/21/2022",
                    Location = "Layton Temple Visitors Center",
                    Slots = 10,
                    TimeId = 1
                },

                new Appointment
                {
                    AppointmentId = 2,
                    Date = "3/22/2022",
                    Location = "Layton Temple Visitors Center",
                    Slots = 10,
                    TimeId = 2
                },

                new Appointment
                {
                    AppointmentId = 3,
                    Date = "3/22/2022",
                    Location = "Layton Temple Visitors Center",
                    Slots = 20,
                    TimeId = 3
                }

            );
        }
    }
}

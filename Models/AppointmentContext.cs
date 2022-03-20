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
    }
}

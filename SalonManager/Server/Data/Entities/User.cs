using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManager.Entities
{
    public class User : IdentityUser<long>
    {
        public User() : base() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Appointment> Appointments { get; set; } = new();


    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Employee : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime FireDate { get; set; }
    }
}

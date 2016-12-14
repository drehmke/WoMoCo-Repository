using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WoMoCo.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string UserImage { get; set; }
        public string About { get; set; }
        public string CurrentJobTitle { get; set; }
        public string Employer { get; set; }

        //public ICollection<Message> Messages { get; set; }
    }
}

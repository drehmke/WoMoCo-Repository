using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WoMoCo.Models;

namespace WoMoCo.ViewModels.Account
{
    public class UserViewModel
    {
        public string PageCount { get; set; }

        public string UserName { get; set; }

        public Dictionary<string,string> Claims { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CurrentJobTitle { get; set; }

        public string Employer { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }
    }

}

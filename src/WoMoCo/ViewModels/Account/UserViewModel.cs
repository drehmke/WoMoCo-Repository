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

        //public ApplicationUser AppUser { get; set; }

        //public FullName UsersFullName { get; set; }

        //public FullName(string firstName, string lastName)
        //{
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //    return this.fullName = firstName + lastName;
        //}

        public string CurrentJobTitle { get; set; }

        public string Employer { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }
    }

    //class FullName
    //{
    //    public string FirstName { get; set; }

    //    public string LastName { get; set; }

    //    public FullName(string firstName, string lastName)
    //    {
    //        this.FirstName = firstName;
    //        this.LastName = lastName;
    //    }
    //}
}

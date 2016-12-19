using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class UserConnection
    {
        //public ApplicationUser CurrentUser { get; set; }

        //public ApplicationUser ConnectedUser { get; set; }

        public DateTime DateConnected { get; set; }

        public string ConnectedUserId { get; set; }

        public string CurrentUserId { get; set; }
    }
}

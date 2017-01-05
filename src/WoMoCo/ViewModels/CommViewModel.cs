using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Models;

namespace WoMoCo.ViewModels
{
    public class CommViewModel
    {
        public int Id { get; set; }
        public string RecId { get; set; }
        public string SendingUser { get; set; }
        // The point of this is to NOT sent all of the user's info
        //public ApplicationUser SendingUser { get; set; }
        public string Subject { get; set; }                
        public bool HasBeenViewed { get; set; }
        public DateTime DateSent { get; set; }
        public string Msg { get; set; }
        public string Status { get; set; }
        public string CommType { get; set; }
    }
}

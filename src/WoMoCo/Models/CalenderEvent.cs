using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class CalenderEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Location { get; set; }
        public string EventType { get; set; }
        public ApplicationUser EventOwner { get; set; }
        public ICollection<ApplicationUser> EventAlarms { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class CalenderEvent
    {
        public int Id { get; set; }
        // id will be auto-increment in the database
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        // createdDate will be set in the service
        public DateTime EventDateTime { get; set; }
        public string Location { get; set; }
        public string EventType { get; set; }
        // eventType - can be set in the client controller so that we can either hardcode or not
        public bool isActive { get; set; }
        // isActive set in the service - this will allow us to soft-delete the event
        public ICollection<ApplicationUser> EventOwner { get; set; }
        // eventUser will be set in the service or the controller
        public ICollection<ApplicationUser> EventAlarms { get; set; }
    }
}

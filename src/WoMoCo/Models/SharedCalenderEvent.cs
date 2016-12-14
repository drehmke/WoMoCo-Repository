using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class SharedCalendarEvent
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public CalendarEvent CalendarEvent { get; set; }
        public int CalendarEventId { get; set; }
    }
}

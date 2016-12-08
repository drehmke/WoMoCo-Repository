using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Models;

namespace WoMoCo.ViewModels.calendarEvents
{
    public class FullListCalendarEvents
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EventDateTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Location { get; set; }
        public string EventType { get; set; }
        public bool isActive { get; set; }
        public string OwnerName { get; set; }
        public ICollection<EventAlarm> EventAlarms { get; set; }
    }
}

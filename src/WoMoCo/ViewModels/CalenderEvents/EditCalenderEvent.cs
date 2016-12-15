using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Models;
using WoMoCo.ViewModels.EventAlarms;

namespace WoMoCo.ViewModels.calendarEvents
{
    public class EditCalendarEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Location { get; set; }
        public string EventType { get; set; }
        public bool isActive { get; set; }
        public string OwnerName { get; set; }
        public ICollection<EventAlarmForList> EventAlarms { get; set; }
    }
}

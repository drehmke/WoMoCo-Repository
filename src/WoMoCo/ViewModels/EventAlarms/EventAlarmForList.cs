using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.ViewModels.EventAlarms
{
    public class EventAlarmForList
    {
        public int Id { get; set; }
        public DateTime AlarmTime { get; set; }
        public string AlarmMethod { get; set; }
        public bool isActive { get; set; }
        public int CalendarEventId { get; set; }
        public string CalenderEventName { get; set; }
        public string OwnerUserName { get; set; }

    }
}

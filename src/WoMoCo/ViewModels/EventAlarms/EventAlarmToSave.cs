using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.ViewModels.EventAlarms
{
    public class EventAlarmToSave
    {
        public int Id { get; set; }
        public string AlarmMethod { get; set; }
        public DateTime AlarmTime { get; set; }
        public bool isActive { get; set; }
        public int OffsetTime { get; set; }
        public string OffsetPeriod { get; set; }
        public int CalenderEventId { get; set; }
        public string OwnerName { get; set; }
    }
}

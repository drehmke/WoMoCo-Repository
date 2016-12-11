using System;
using System.Collections.Generic;
using WoMoCo.Models;
using WoMoCo.ViewModels.EventAlarms;

namespace WoMoCo.Interfaces
{
    public interface IEventAlarmService
    {
        void DeleteEventAlarm(int id);
        IList<EventAlarm> GetAllAlarms();
        IList<EventAlarm> GetAllAlarmsByEvent(int id);
        IList<EventAlarm> GetAllAlarmsByUser(string uid);
        IList<EventAlarm> GetAllAlarmsForDateRange(DateTime dateRangeStart, DateTime dateRangeEnd);
        EventAlarm GetEventAlarmById(int id);
        void SaveEventAlarm(EventAlarmToSave eventAlarmToSave, string uid);
        void SoftDeleteEventAlarm(int id);
    }
}
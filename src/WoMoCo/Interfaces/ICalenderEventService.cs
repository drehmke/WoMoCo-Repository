using System;
using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Interfaces
{
    public interface ICalenderEventService
    {
        void DeleteCalenderEvent(int id);
        IList<CalenderEvent> GetAllEvents();
        CalenderEvent GetCalendarEventById(int id);
        IList<CalenderEvent> GetCalenderEventsByUser(string userId);
        IList<CalenderEvent> GetCalenederEventsForDateRange(DateTime dateRangeStart, DateTime dateRangeEnd);
        void SaveCalenderEvent(CalenderEvent calenderEventToSave, string uid);
        void SoftDeleteCalenderEvent(int id);
    }
}
using System;
using System.Collections.Generic;
using WoMoCo.Models;
using WoMoCo.ViewModels.CalenderEvents;

namespace WoMoCo.Interfaces
{
    public interface ICalenderEventService
    {
        void DeleteCalenderEvent(int id);
        //IList<CalenderEvent> GetAllEvents();
        IList<FullListCalenderEvents> GetAllEvents();
        EditCalenderEvent GetCalendarEventById(int id);
        IList<FullListCalenderEvents> GetCalenderEventsByUser(string userId);
        IList<CalenderEvent> GetCalenderEventsForDateRange(DateTime dateRangeStart, DateTime dateRangeEnd);
        void SaveCalenderEvent(CalenderEvent calenderEventToSave, string uid);
        void SoftDeleteCalenderEvent(int id);
    }
}
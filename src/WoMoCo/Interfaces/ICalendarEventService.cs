using System;
using System.Collections.Generic;
using WoMoCo.Models;
using WoMoCo.ViewModels.calendarEvents;

namespace WoMoCo.Interfaces
{
    public interface ICalendarEventService
    {
        void DeleteCalendarEvent(int id);
        IList<FullListCalendarEvents> GetAllEvents();
        EditCalendarEvent GetCalendarEventById(int id);
        IList<FullListCalendarEvents> GetCalendarEventsByUser(string userId);
        IList<FullListCalendarEvents> GetSharedCalendarEventsForUser(string uid);
        IList<CalendarEvent> GetCalendarEventsForDateRange(DateTime dateRangeStart, DateTime dateRangeEnd);
        void SaveCalendarEvent(CalendarEvent calendarEventToSave, string uid);
        void ShareCalenderEvent(SharedCalendarEvent calenderEventToShare);
        void SoftDeleteCalendarEvent(int id);
    }
}
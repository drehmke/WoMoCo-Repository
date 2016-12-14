using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.ViewModels.calendarEvents;
using WoMoCo.ViewModels.EventAlarms;


namespace WoMoCo.Services
{
    public class CalendarEventService : ICalendarEventService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;

        /// <summary>
        /// Converts the CalenderEvent object to a FullListCalenderEvent object so that we send back only
        /// the information we need and we can handle any infinite loops.
        /// </summary>
        /// <param name="calenderEventToConvert">The calender event to convert.</param>
        /// <returns></returns>
        private FullListCalendarEvents ConvertCalendarToListable(CalendarEvent calendarEventToConvert)
        {
            FullListCalendarEvents listableCalendarEvent = new FullListCalendarEvents();
            listableCalendarEvent.Id = calendarEventToConvert.Id;
            listableCalendarEvent.Name = calendarEventToConvert.Name;
            listableCalendarEvent.EventDateTime = calendarEventToConvert.EventDateTime;
            listableCalendarEvent.CreatedDate = calendarEventToConvert.CreatedDate;
            listableCalendarEvent.Location = calendarEventToConvert.Location;
            listableCalendarEvent.EventType = calendarEventToConvert.Location;
            listableCalendarEvent.isActive = calendarEventToConvert.isActive;
            if (calendarEventToConvert.EventOwner != null)
            { listableCalendarEvent.OwnerName = calendarEventToConvert.EventOwner.UserName; }
            // I did the assigning this way so that I could null-check the EventAlarms list
            if (calendarEventToConvert.EventAlarms != null)
            { listableCalendarEvent.AlarmCount = calendarEventToConvert.EventAlarms.Count(); }
            return listableCalendarEvent;
        }

        /// <summary>
        /// Converts the CalendarEvent object to an EditableCalendar object.
        /// This let's us control what is sent back and handle any possible infinite loops.
        /// </summary>
        /// <param name="calendarEventToConvert">The calendar event to convert.</param>
        /// <returns></returns>
        private EditCalendarEvent ConvertCalendarEventToEditable(CalendarEvent calendarEventToConvert)
        {
            EditCalendarEvent editablecalendarEvent = new EditCalendarEvent
            {
                Id = calendarEventToConvert.Id,
                Name = calendarEventToConvert.Name,
                CreatedDate = calendarEventToConvert.CreatedDate,
                Location = calendarEventToConvert.Location,
                EventType = calendarEventToConvert.EventType,
                isActive = calendarEventToConvert.isActive,
                OwnerName = calendarEventToConvert.EventOwner.UserName,
                EventDate = calendarEventToConvert.EventDateTime.Date.ToString("yyyy-MM-dd"),
                EventTime = calendarEventToConvert.EventDateTime.TimeOfDay.ToString()
            };
            return editablecalendarEvent;
        }
        // ---- Basic CRUD ----------------------------------------------------
        public IList<FullListCalendarEvents> GetAllEvents()
        {
            IList<CalendarEvent> calendarEvents = _repo.Query<CalendarEvent>().Include(c => c.EventOwner).Include(a => a.EventAlarms).ToList();
            IList<FullListCalendarEvents> calendarEventsWithOwnersName = new List<FullListCalendarEvents>();
            foreach (CalendarEvent calEvent in calendarEvents)
            {
                calendarEventsWithOwnersName.Add(this.ConvertCalendarToListable(calEvent));
            }
            
            return calendarEventsWithOwnersName;
        }

        public IList<FullListCalendarEvents> GetCalendarEventsByUser(string userId)
        {
            IList<CalendarEvent> allEvents = _repo.Query<CalendarEvent>().Include(c => c.EventOwner).ToList();
            IList<FullListCalendarEvents> calendarEventsList = new List<FullListCalendarEvents>();
            foreach( CalendarEvent calEvent in allEvents)
            {
                if( calEvent.EventOwner.Id == userId)
                {
                    calendarEventsList.Add(this.ConvertCalendarToListable(calEvent));
                }
            }
            return calendarEventsList;
        }

        public IList<FullListCalendarEvents> GetSharedCalendarEventsForUser(string userId)
        {
            // Get the user for userId
            ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.Id == userId).FirstOrDefault();
            // Get a list of all the events
            IList<SharedCalendarEvent> sharedEvents = _repo.Query<SharedCalendarEvent>().Where(s => s.UserId == userId).Include(e => e.CalendarEvent).Include( o => o.CalendarEvent.EventOwner).ToList();
            IList<FullListCalendarEvents> listableSharedEvents = new List<FullListCalendarEvents>();
            // Convert the shared events into something we can use and display
            foreach( SharedCalendarEvent shared in sharedEvents)
            {
                FullListCalendarEvents tempEvent = this.ConvertCalendarToListable(shared.CalendarEvent);
                tempEvent.OwnerName = shared.CalendarEvent.EventOwner.UserName;
                listableSharedEvents.Add(tempEvent);
            }
            
            return listableSharedEvents;
        }

        public IList<CalendarEvent> GetCalendarEventsForDateRange(DateTime dateRangeStart, DateTime dateRangeEnd)
        { // TODO: Fill out this method
            return _repo.Query<CalendarEvent>().ToList();
        }
        
        public EditCalendarEvent GetCalendarEventById(int id)
        {
            CalendarEvent originalCalendarEvent = _repo.Query<CalendarEvent>().Where(c => c.Id == id).Include( c => c.EventOwner).Include(a => a.EventAlarms).FirstOrDefault();

            EditCalendarEvent editablecalendarEvent = ConvertCalendarEventToEditable(originalCalendarEvent);
            IList<EventAlarmForList> listableAlarms = new List<EventAlarmForList>();
            foreach( EventAlarm alarm in originalCalendarEvent.EventAlarms )
            {
                EventAlarmForList listable = new EventAlarmForList
                {
                    Id = alarm.Id,
                    AlarmTime = alarm.AlarmTime,
                    AlarmMethod = alarm.AlarmMethod,
                    isActive = alarm.isActive,
                    CalendarEventId = originalCalendarEvent.Id,
                    CalenderEventName = originalCalendarEvent.Name,
                    OwnerUserName = alarm.Owner.UserName
                };
                listableAlarms.Add(listable);
            }
            editablecalendarEvent.EventAlarms = listableAlarms;

            return editablecalendarEvent;
        }
        
        public void SaveCalendarEvent(CalendarEvent calendarEventToSave, string uid)
        {
            calendarEventToSave.isActive = true;
            if( calendarEventToSave.Id == 0)
            {
                // get currently logged in user by uid to assign as eventOwner
                ApplicationUser currUser = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
                calendarEventToSave.EventOwner = currUser;
                calendarEventToSave.CreatedDate = DateTime.Now;
                calendarEventToSave.EventType = "playdate";
                _repo.Add(calendarEventToSave); // saves the new entry to the database

            } else
            {
                _repo.Update(calendarEventToSave);
            }
        }

        public void ShareCalenderEvent(SharedCalendarEvent calenderEventToShare)
        {
            ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.UserName == calenderEventToShare.UserId).FirstOrDefault();
            CalendarEvent calendarEvent = _repo.Query<CalendarEvent>().Where(e => e.Id == calenderEventToShare.CalendarEventId).FirstOrDefault();
            var newUsercalendarEvent = new SharedCalendarEvent
            {
                User = user,
                UserId = user.Id,
                CalendarEvent = calendarEvent,
                CalendarEventId = calendarEvent.Id
            };
            _repo.Add(newUsercalendarEvent);
            _repo.SaveChanges();
        }

        public void SoftDeleteCalendarEvent(int id)
        {
            CalendarEvent calendarEventToDelete = _repo.Query<CalendarEvent>().Where(c => c.Id == id).FirstOrDefault();
            calendarEventToDelete.isActive = false;
            _repo.Update(calendarEventToDelete);
        }
        public void DeleteCalendarEvent(int id)
        {
            CalendarEvent calendarEventToDelete = _repo.Query<CalendarEvent>().Where(c => c.Id == id).FirstOrDefault();
            _repo.Delete(calendarEventToDelete);
        }
        // ---- end Basic CRUD ------------------------------------------------

        public CalendarEventService(IGenericRepository repo, UserManager<ApplicationUser> manager)
        {
            this._repo = repo;
            this._manager = manager;
        }
    }
}

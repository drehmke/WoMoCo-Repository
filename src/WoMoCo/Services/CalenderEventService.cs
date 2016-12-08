using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.ViewModels.calendarEvents;

namespace WoMoCo.Services
{
    public class CalendarEventService : ICalendarEventService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;
        // ---- Basic CRUD ----------------------------------------------------
        public IList<FullListCalendarEvents> GetAllEvents()
        {
            //IList<calendarEvent> calendarEvents = _repo.Query<calendarEvent>().ToList();
            IList<CalendarEvent> calendarEvents = _repo.Query<CalendarEvent>().Include(c => c.EventOwner).ToList();
            IList<FullListCalendarEvents> calendarEventsWithOwnersName = new List<FullListCalendarEvents>();
            foreach (CalendarEvent calEvent in calendarEvents)
            {
                FullListCalendarEvents listableCalendarEvent = new FullListCalendarEvents
                {
                    Id = calEvent.Id,
                    Name = calEvent.Name,
                    EventDateTime = calEvent.EventDateTime,
                    CreatedDate = calEvent.CreatedDate,
                    Location = calEvent.Location,
                    EventType = calEvent.Location,
                    isActive = calEvent.isActive,
                    OwnerName = calEvent.EventOwner.UserName,
                    EventAlarms = calEvent.EventAlarms
                };
                calendarEventsWithOwnersName.Add(listableCalendarEvent);
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
                    FullListCalendarEvents listcalendarEvent = new FullListCalendarEvents
                    {
                        Id = calEvent.Id,
                        Name = calEvent.Name,
                        EventDateTime = calEvent.EventDateTime,
                        CreatedDate = calEvent.CreatedDate,
                        Location = calEvent.Location,
                        EventType = calEvent.EventType,
                        isActive = calEvent.isActive,
                        OwnerName = calEvent.EventOwner.UserName,
                        EventAlarms = calEvent.EventAlarms
                    };
                    calendarEventsList.Add(listcalendarEvent);
                }
            }
            return calendarEventsList;
        }

        public IList<CalendarEvent> GetCalendarEventsForDateRange(DateTime dateRangeStart, DateTime dateRangeEnd)
        { // TODO: Fill out this method
            return _repo.Query<CalendarEvent>().ToList();
        }
        
        public EditCalendarEvent GetCalendarEventById(int id)
        {
            CalendarEvent originalCalendarEvent = _repo.Query<CalendarEvent>().Where(c => c.Id == id).Include( c => c.EventOwner).FirstOrDefault();

            EditCalendarEvent editablecalendarEvent = new EditCalendarEvent();
            editablecalendarEvent.Id = originalCalendarEvent.Id;
            editablecalendarEvent.Name = originalCalendarEvent.Name;
            editablecalendarEvent.CreatedDate = originalCalendarEvent.CreatedDate;
            editablecalendarEvent.Location = originalCalendarEvent.Location;
            editablecalendarEvent.EventType = originalCalendarEvent.EventType;
            editablecalendarEvent.isActive = originalCalendarEvent.isActive;
            editablecalendarEvent.OwnerName = originalCalendarEvent.EventOwner.UserName;
            editablecalendarEvent.EventDate = originalCalendarEvent.EventDateTime.Date.ToString("yyyy-MM-dd");
            editablecalendarEvent.EventTime = originalCalendarEvent.EventDateTime.TimeOfDay.ToString();
            editablecalendarEvent.EventAlarms = originalCalendarEvent.EventAlarms;

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

                /* Use this when sharing
                // add the user and the event to the join table
                var newUsercalendarEvent = new SharedcalendarEvent
                {
                    User = currUser,
                    UserId = currUser.Id,
                    calendarEvent = calendarEventToSave,
                    calendarEventId = calendarEventToSave.Id
                };
                _repo.Add(newUsercalendarEvent);
                _repo.SaveChanges();
                */
            } else
            {
                _repo.Update(calendarEventToSave);
            }
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

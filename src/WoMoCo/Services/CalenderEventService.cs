using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Repositories;
using WoMoCo.ViewModels.CalenderEvents;

namespace WoMoCo.Services
{
    public class CalenderEventService : ICalenderEventService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;
        // ---- Basic CRUD ----------------------------------------------------
        public IList<FullListCalenderEvents> GetAllEvents()
        {
            //IList<CalenderEvent> calenderEvents = _repo.Query<CalenderEvent>().ToList();
            IList<CalenderEvent> calenderEvents = _repo.Query<CalenderEvent>().Include(c => c.EventOwner).ToList();
            IList<FullListCalenderEvents> calenderEventsWithOwnersName = new List<FullListCalenderEvents>();
            foreach (CalenderEvent calEvent in calenderEvents)
            {
                FullListCalenderEvents listableCalenderEvent = new FullListCalenderEvents
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
                calenderEventsWithOwnersName.Add(listableCalenderEvent);
            }
            
            return calenderEventsWithOwnersName;
        }
        public IList<CalenderEvent> GetCalenderEventsByUser(string userId)
        { // TODO: Fill out this method
            return _repo.Query<CalenderEvent>().ToList();
        }
        public IList<CalenderEvent> GetCalenederEventsForDateRange(DateTime dateRangeStart, DateTime dateRangeEnd)
        { // TODO: Fill out this method
            return _repo.Query<CalenderEvent>().ToList();
        }
        public CalenderEvent GetCalendarEventById(int id)
        {
            return _repo.Query<CalenderEvent>().Where(c => c.Id == id).FirstOrDefault();
        }
        public void SaveCalenderEvent(CalenderEvent calenderEventToSave, string uid)
        {
            calenderEventToSave.isActive = true;
            if( calenderEventToSave.Id == 0)
            {
                // get currently logged in user by uid to assign as eventOwner
                ApplicationUser currUser = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
                calenderEventToSave.EventOwner = currUser;
                calenderEventToSave.CreatedDate = DateTime.Now;
                calenderEventToSave.EventType = "playdate";
                _repo.Add(calenderEventToSave); // saves the new entry to the database

                /* Use this when sharing
                // add the user and the event to the join table
                var newUserCalenderEvent = new SharedCalenderEvent
                {
                    User = currUser,
                    UserId = currUser.Id,
                    CalenderEvent = calenderEventToSave,
                    CalenderEventId = calenderEventToSave.Id
                };
                _repo.Add(newUserCalenderEvent);
                _repo.SaveChanges();
                */
            } else
            {
                _repo.Update(calenderEventToSave);
            }
        }
        public void SoftDeleteCalenderEvent(int id)
        {
            CalenderEvent calenderEventToDelete = _repo.Query<CalenderEvent>().Where(c => c.Id == id).FirstOrDefault();
            calenderEventToDelete.isActive = false;
            _repo.Update(calenderEventToDelete);
        }
        public void DeleteCalenderEvent(int id)
        {
            CalenderEvent calenderEventToDelete = _repo.Query<CalenderEvent>().Where(c => c.Id == id).FirstOrDefault();
            _repo.Delete(calenderEventToDelete);
        }
        // ---- end Basic CRUD ------------------------------------------------

        public CalenderEventService(IGenericRepository repo, UserManager<ApplicationUser> manager)
        {
            this._repo = repo;
            this._manager = manager;
        }
    }
}

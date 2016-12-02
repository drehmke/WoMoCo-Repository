using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public class CalenderEventService : ICalenderEventService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;
        // ---- Basic CRUD ----------------------------------------------------
        public IList<CalenderEvent> GetAllEvents()
        {
            IList<CalenderEvent> calenderEvents = _repo.Query<CalenderEvent>().ToList();
            return calenderEvents;
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
                // TODO - set hardcoded variables: eventUser
                // get user by uid
                ApplicationUser currUser = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
                calenderEventToSave.EventOwner = currUser;
                calenderEventToSave.CreatedDate = DateTime.Now;
                calenderEventToSave.EventType = "playdate";
                _repo.Add(calenderEventToSave);
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

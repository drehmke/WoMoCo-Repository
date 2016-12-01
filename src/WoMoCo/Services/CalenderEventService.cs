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
        public void SaveCalenderEvent(CalenderEvent calenderEventToSave)
        {
            calenderEventToSave.isActive = true;
            if( calenderEventToSave.Id == 0)
            {
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

        public CalenderEventService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}

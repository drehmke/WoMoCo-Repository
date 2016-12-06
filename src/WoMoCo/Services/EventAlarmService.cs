using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public class EventAlarmService : IEventAlarmService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;

        // ---- Basic CRUD ----------------------------------------------------
        public IList<EventAlarm> GetAllAlarms()
        {
            IList<EventAlarm> allAlarms = _repo.Query<EventAlarm>().ToList();
            return allAlarms;
        }

        public IList<EventAlarm> GetAllAlarmsByUser(string uid)
        { // TODO: Fill out this method
            IList<EventAlarm> allAlarms = _repo.Query<EventAlarm>().ToList();
            return allAlarms;
        }

        public IList<EventAlarm> GetAllAlarmsByEvent()
        { // TODO: Fill out this method
            IList<EventAlarm> allAlarms = _repo.Query<EventAlarm>().ToList();
            return allAlarms;
        }

        public IList<EventAlarm> GetAllAlarmsForDateRange( DateTime dateRangeStart, DateTime dateRangeEnd)
        {
            IList<EventAlarm> allAlarms = _repo.Query<EventAlarm>().ToList();
            return allAlarms;
        }

        public EventAlarm GetEventAlarmById( int id)
        {
            return _repo.Query<EventAlarm>().Where(e => e.Id == id).FirstOrDefault();
        }

        public void SaveEventAlarm(EventAlarm eventAlarmToSave, string uid)
        {
            if( eventAlarmToSave.Id == 0)
            {
                _repo.Add(eventAlarmToSave);
            } else
            {
                _repo.Update(eventAlarmToSave);
            }
        }

        public void SoftDeleteEventAlarm(int id)
        {
            EventAlarm eventAlarmToDelete = _repo.Query<EventAlarm>().Where(e => e.Id == id).FirstOrDefault();
            eventAlarmToDelete.isActive = false;
            _repo.Update(eventAlarmToDelete);
        }

        public void DeleteEventAlarm(int id)
        {
            EventAlarm eventAlarmToDelete = _repo.Query<EventAlarm>().Where(e => e.Id == id).FirstOrDefault();
            _repo.Delete(eventAlarmToDelete);
        }
        // ---- end Basic CRUD ------------------------------------------------

        public EventAlarmService(IGenericRepository repo, UserManager<ApplicationUser> manager)
        {
            this._repo = repo;
            this._manager = manager;
        }
    }
}

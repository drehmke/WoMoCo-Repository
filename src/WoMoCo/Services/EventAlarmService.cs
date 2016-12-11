using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.ViewModels.EventAlarms;

namespace WoMoCo.Services
{
    public class EventAlarmService: IEventAlarmService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;

        // ---- Basic CRUD ----------------------------------------------------
        public IList<EventAlarmForList> GetAllAlarms()
        {
            IList<EventAlarm> allAlarms = _repo.Query<EventAlarm>().Include(o => o.Owner).Include(e => e.Event).ToList();
            IList<EventAlarmForList> listableAlarms = new List<EventAlarmForList>();
            foreach( EventAlarm alarm in allAlarms )
            {
                EventAlarmForList newAlarm = new EventAlarmForList
                {
                    Id = alarm.Id,
                    AlarmTime = alarm.AlarmTime,
                    AlarmMethod = alarm.AlarmMethod,
                    isActive = alarm.isActive,
                    CalendarEventId = alarm.Event.Id,
                    CalenderEventName = alarm.Event.Name,
                    OwnerUserName = alarm.Owner.UserName
                };
                listableAlarms.Add(newAlarm);
            }
            return listableAlarms;
        }

        public IList<EventAlarm> GetAllAlarmsByUser(string uid)
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

        public void SaveEventAlarm(EventAlarmToSave eventAlarmToSave, string uid)
        {
            ApplicationUser owner = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
            CalendarEvent calendarEvent = _repo.Query<CalendarEvent>().Where(c => c.Id == eventAlarmToSave.CalenderEventId).FirstOrDefault();
            DateTime alarmDate = DateTime.Now;

            // get the calender Event's time
            DateTime eventDateTime = calendarEvent.EventDateTime;
            // now we need to find out when the user wants the alarm set for ...
            int negOffsetTime = eventAlarmToSave.OffsetTime * -1;

            switch (eventAlarmToSave.OffsetPeriod)
            {
                case "minute":
                    alarmDate = eventDateTime.AddMinutes(negOffsetTime);
                    break;
                case "hour":
                    alarmDate = eventDateTime.AddHours(negOffsetTime);
                    break;
                case "day":
                    alarmDate = eventDateTime.AddDays(negOffsetTime);
                    break;
                case "week":
                    alarmDate = eventDateTime.AddDays(negOffsetTime * 7);
                    break;
            }
            // Convert to the eventAlarm model to save
            EventAlarm saveableAlarm = new EventAlarm
            {
                AlarmTime = alarmDate,
                AlarmMethod = eventAlarmToSave.AlarmMethod
            };
            if (saveableAlarm.Id == 0)
            {
                saveableAlarm.isActive = true;
                _repo.Add(saveableAlarm);
            } else
            {
                _repo.Update(saveableAlarm);
            }
            saveableAlarm.Owner = owner;
            saveableAlarm.Event = calendarEvent;
            _repo.SaveChanges();
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

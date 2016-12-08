using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Interfaces;
using Microsoft.AspNetCore.Identity;
using WoMoCo.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class EventAlarmsController : Controller
    {
        private IEventAlarmService _service;
        private UserManager<ApplicationUser> _manager;

        // GET: api/values
        [HttpGet]
        public IEnumerable<EventAlarm> Get()
        {
            return _service.GetAllAlarms();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetEventAlarmById(id));
        }

        [HttpGet("getMy/")]
        public IEnumerable<EventAlarm> GetMy()
        {
            string uid = _manager.GetUserId(User);
            return _service.GetAllAlarmsByUser(uid);
        }

        [HttpPost]
        public IActionResult Post([FromBody]EventAlarm eventAlarm)
        {
            string uid = _manager.GetUserId(User);
            _service.SaveEventAlarm(eventAlarm, uid);
            return Ok(eventAlarm);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteEventAlarm(id);
            return Ok();
        }

        // TODO: Get by calendarEvent
        // TODO: Get By Date Range
        // TODO: SoftDelete

        public EventAlarmsController(IEventAlarmService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }
    }
}

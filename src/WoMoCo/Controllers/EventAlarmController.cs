using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Interfaces;
using Microsoft.AspNetCore.Identity;
using WoMoCo.Models;
using WoMoCo.ViewModels.EventAlarms;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class EventAlarmController : Controller
    {
        IEventAlarmService _service;
        UserManager<ApplicationUser> _manager;

        // GET: api/values
        [HttpGet]
        public IEnumerable<EventAlarm> Get()
        {
            return _service.GetAllAlarms() ;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetEventAlarmById(id));
        }
        [HttpGet("/GetByEvent/{eventId}")]
        public IActionResult GetByEvent(int id)
        {
            return Ok(_service.GetAllAlarmsByEvent(id));
        }
        // TODO: Get Alarm by User
        // TODO: Get Alarm by Event
        // TODO: Get Alarm by Date Range

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]EventAlarmToSave eventAlarm)
        {
            string uid = _manager.GetUserId(User);
            _service.SaveEventAlarm(eventAlarm, uid);
            return Ok(eventAlarm);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteEventAlarm(id);
            return Ok();
        }

        public EventAlarmController(
            IEventAlarmService service,
            UserManager<ApplicationUser> manager
            ) {
            this._service = service;
            this._manager = manager;
        }
    }
}

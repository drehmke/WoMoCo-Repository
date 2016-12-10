using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using Microsoft.AspNetCore.Identity;
using WoMoCo.ViewModels.calendarEvents;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    
    [Route("api/[controller]")]
    public class CalendarEventsController : Controller
    {
        private ICalendarEventService _service;
        private UserManager<ApplicationUser> _manager;

        [HttpGet]
        public IEnumerable<FullListCalendarEvents> Get()
        {
            return _service.GetAllEvents();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            EditCalendarEvent calendarEvent = _service.GetCalendarEventById(id);
            return Ok(calendarEvent);
        }
        [HttpGet("getMy/")]
        public IEnumerable<FullListCalendarEvents> GetMy()
        {
            string uid = _manager.GetUserId(User);
            return _service.GetCalendarEventsByUser(uid);
        }
        [HttpPost]
        public IActionResult Post([FromBody]CalendarEvent calendarEvent)
        {
            string uid = _manager.GetUserId(User);
            _service.SaveCalendarEvent(calendarEvent, uid );
            return Ok(calendarEvent);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteCalendarEvent(id);
            return Ok();
        }

        // TODO: Get by User
        // TODO: Get By Date Range
        // TODO: SoftDelete
        public CalendarEventsController(ICalendarEventService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }
    }
}

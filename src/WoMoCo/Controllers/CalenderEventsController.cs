using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using Microsoft.AspNetCore.Identity;
using WoMoCo.ViewModels.calendarEvents;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    
    [Route("api/[controller]")]
    public class CalendarEventsController : Controller
    {
        private ICalendarEventService _service;
        private UserManager<ApplicationUser> _manager;

        [HttpGet]
        [Authorize]
        public IEnumerable<FullListCalendarEvents> Get()
        {
            return _service.GetAllEvents();
        }
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            EditCalendarEvent calendarEvent = _service.GetCalendarEventById(id);
            return Ok(calendarEvent);
        }
        [HttpGet("getMy/")]
        [Authorize]
        public IEnumerable<FullListCalendarEvents> GetMy()
        {
            string uid = _manager.GetUserId(User);
            return _service.GetCalendarEventsByUser(uid);
        }
        [HttpGet("getMyShared/")]
        [Authorize]
        public IEnumerable<FullListCalendarEvents> GetMyShared()
        {
            string uid = _manager.GetUserId(User);
            return _service.GetSharedCalendarEventsForUser(uid);
        }
        [HttpGet("GetAdminFirstFive/")]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<FullListCalendarEvents> GetAdminFirstFive()
        {
            return _service.GetAdminFirstFive();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]CalendarEvent calendarEvent)
        {
            string uid = _manager.GetUserId(User);
            _service.SaveCalendarEvent(calendarEvent, uid );
            return Ok(calendarEvent);
        }

        [HttpPost("ShareEvent")]
        [Authorize]
        //public IActionResult ShareEvent([FromBody]SharedCalendarEvent shareEvent)
        public IActionResult ShareEvent([FromBody] SharedCalendarEvent shareEvent)
        {
            _service.ShareCalenderEvent(shareEvent);
            return Ok(shareEvent);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _service.DeleteCalendarEvent(id);
            return Ok();
        }

        // TODO: Get By Date Range
        // TODO: SoftDelete
        public CalendarEventsController(ICalendarEventService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }
    }
}

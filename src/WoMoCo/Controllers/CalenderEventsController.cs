using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using Microsoft.AspNetCore.Identity;
using WoMoCo.ViewModels.CalenderEvents;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    
    [Route("api/[controller]")]
    public class CalenderEventsController : Controller
    {
        private ICalenderEventService _service;
        private UserManager<ApplicationUser> _manager;

        [HttpGet]
        public IEnumerable<FullListCalenderEvents> Get()
        {
            return _service.GetAllEvents();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetCalendarEventById(id));
        }
        [HttpGet("getMy/")]
        public IEnumerable<CalenderEvent> GetMy()
        {
            string uid = _manager.GetUserId(User);
            return _service.GetCalenderEventsByUser(uid);
        }
        [HttpPost]
        public IActionResult Post([FromBody]CalenderEvent calenderEvent)
        {
            string uid = _manager.GetUserId(User);
            _service.SaveCalenderEvent(calenderEvent, uid );
            return Ok(calenderEvent);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteCalenderEvent(id);
            return Ok();
        }

        // TODO: Get by User
        // TODO: Get By Date Range
        // TODO: SoftDelete
        public CalenderEventsController(ICalenderEventService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Interfaces;
using WoMoCo.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    
    [Route("api/[controller]")]
    public class CalenderEventsController : Controller
    {
        private ICalenderEventService _service;

        [HttpGet]
        public IEnumerable<CalenderEvent> Get()
        {
            return _service.GetAllEvents();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetCalendarEventById(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody]CalenderEvent calenderEvent)
        {
            _service.SaveCalenderEvent(calenderEvent);
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
        public CalenderEventsController(ICalenderEventService service)
        {
            this._service = service;
        }
    }
}

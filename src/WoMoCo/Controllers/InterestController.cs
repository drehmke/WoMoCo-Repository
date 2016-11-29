using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Services;
using WoMoCo.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class InterestController : Controller
    {
        private IInterestService _service;
        [HttpGet]
        public IEnumerable<Interest> Get()
        {
            return _service.GetAllInterests();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetInterestbyId(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody]Interest interest)
        {
            _service.SaveInterest(interest);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteInterest(id);
            return Ok();
        }

        public InterestController(IInterestService service)
        {
            this._service = service;
        }
    }
}

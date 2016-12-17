using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Services;
using WoMoCo.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class InterestController : Controller
    {
        private IInterestService _service;
        private UserManager<ApplicationUser> _manager;

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
        [HttpGet("GetMy/")]
        public IEnumerable<Interest> GetMy()
        {
            string uid = _manager.GetUserId(User);
            IList<Interest> listableInterests = _service.GetInterestsByUser(uid);
            return listableInterests;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Interest interest)
        {
            string uid = _manager.GetUserId(User);
            _service.SaveInterest(interest, uid);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteInterest(id);
            return Ok();
        }

        public InterestController(IInterestService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }
    }
}

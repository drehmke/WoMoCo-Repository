using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Services;
using WoMoCo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using WoMoCo.ViewModels.Interests;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class InterestController : Controller
    {
        private IInterestService _service;
        private UserManager<ApplicationUser> _manager;

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<InterestAdminView> Get()
        {
            return _service.GetAllInterests();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetInterestbyId(id));
        }
        [HttpGet("Admin/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminGet(int id)
        {
            return Ok(_service.GetAdminInterestById(id));
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
        [HttpPost("AdminSave")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminSave([FromBody]InterestAdminView interest)
        {
            _service.AdminUpdateInterest(interest);
            return Ok(interest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteInterest(id);
            return Ok();
        }
        [HttpDelete("Admin/{id}")]
        public IActionResult AdminDelete(int id)
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

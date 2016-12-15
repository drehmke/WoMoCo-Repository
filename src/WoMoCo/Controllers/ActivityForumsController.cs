using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using WoMoCo.Interfaces;
using WoMoCo.Services;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class ActivityForumsController : Controller
    {
        private IActivityForumService _service;
        private UserManager<ApplicationUser> _manager;
        // GET: api/values
        [HttpGet]
        public IEnumerable<ActivityForum> Get()
        {
            return _service.GetAllActivities();
        }

        // GET: api/activityForum/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetActivityById(id));
        }

        [HttpGet("GetActivityForum/")]
        public IList<ActivityForum> GetActivity()
        {
            var uid = _manager.GetUserId(User);
            return _service.GetByUsername(uid);
        }

        // POST: api/activityForum
        [HttpPost]

        public IActionResult ActivityForum([FromBody]ActivityForum activityForum)
        {
            string uid = _manager.GetUserId(User);
            _service.SaveActivity(uid, activityForum);
            return Ok(activityForum);
        }

        // DELETE: api/activityForum/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteActivityForum(id);
            return Ok();
        }

        public ActivityForumsController(IActivityForumService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }

        
        
    }
}

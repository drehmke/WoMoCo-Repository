using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using WoMoCo.Interfaces;
using WoMoCo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using WoMoCo.ViewModels.ActivityForum;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class ActivityForumsController : Controller
    {
        private IActivityForumService _service;
        private UserManager<ApplicationUser> _manager;

        // GET: api/values
        // this is the get activities for admin
        [HttpGet]
        [Authorize]
        public IEnumerable<ActivityForumAdminView> Get()
        {
            return _service.GetAllActivities();
        }
        // GET: api/getActivity
        // this is the get activities for currently logged in user
        [HttpGet("GetActivityForum/")]
        [Authorize]
        public IList<ActivityForum> GetActivity()
        {
            var uid = _manager.GetUserId(User);
            return _service.GetByUsername(uid);
        }


        // this is the admin version of getting the post by ID
        // GET: api/activityForums/AdminGet/:id
        [HttpGet("AdminGetId/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminGetId(int id)
        {
            return Ok(_service.GetActivityById(id));
        }
        // GET: api/activityForum/:id
        // this is for getting the post by ID for the activity
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetActivityById(id));
        }


        // this is the user's save method
        // POST: api/activityForum
        [HttpPost]
        [Authorize]
        public IActionResult ActivityForum([FromBody]ActivityForum activityForum)
        {
            string uid = _manager.GetUserId(User);
            _service.SaveActivity(uid, activityForum);
            return Ok(activityForum);
        }
        // this is the admin's save method
        // POST: api/activityForum/AdminSave
        [HttpPost("AdminSave")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminSave([FromBody]ActivityForumAdminView activityForumToSave)
        {
            // convert the ActivityForumAdminView back into ActivityForum, pulling out the UserId
            ActivityForum activityForum = new ActivityForum
            {
                Id = activityForumToSave.Id,
                Location = activityForumToSave.Location,
                Activity = activityForumToSave.Activity,
                Description = activityForumToSave.Description,
                UserName = activityForumToSave.UserName
            };
            string uid = activityForumToSave.UserId;
            _service.SaveActivity(uid, activityForum);
            return Ok(activityForum);
        }

        // this is the user's delete
        // DELETE: api/activityForum/:id
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _service.DeleteActivityForum(id);
            return Ok();
        }
        // this is the admin's delete
        [HttpDelete("AdminDelete/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminDelete(int id)
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

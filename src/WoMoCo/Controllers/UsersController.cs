using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using WoMoCo.Services;
using Microsoft.AspNetCore.Identity;
using WoMoCo.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _service;
        private UserManager<ApplicationUser> _manager;
        // GET: api/values
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_service.GetAllUsers());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public ApplicationUser Get(string username)
        {
            return _service.GetUserById(username);
        }

        //GET by userName
        [HttpGet("GetUser")]
        [Authorize]
        public ApplicationUser GetUser()
        {
            var uid = _manager.GetUserId(User);
            ApplicationUser user = _service.GetUserById(uid);
            return user;
        }

        [HttpGet("Admin/GetUser/{userName}")]
        [Authorize(Policy = "AdminOnly")]
        public ApplicationUser AdminGetUser(string userName)
        {
            ApplicationUser user = _service.GetByUsername(userName);
            return user;
        }
        // move to service

        //GET usersForPullDown
        [HttpGet("GetUsersForPullDown/")]
        [Authorize]
        public IEnumerable<UserForPullDown> GetUsersForPullDown()
        {
            return _service.GetAllUsersForPullDown();
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]ApplicationUser user)
        {
            _service.SaveUser(user);            
            return Ok(user);
        }
        [HttpPost("AdminUpdate")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminSave([FromBody]ApplicationUser user)
        {
            _service.SaveUser(user);
            return Ok(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            _service.DeleteUser(id);
            return Ok();
        }
        [HttpDelete("Admin/DeleteUser/{userName}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminDelete(string userName)
        {
            _service.DeleteUserByUserName(userName);
            return Ok();
        }

        public UsersController(IUserService service, UserManager<ApplicationUser> manager)
        {
            this._manager = manager;
            this._service = service;
        }
    }
}

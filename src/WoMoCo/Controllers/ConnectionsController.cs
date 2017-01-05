using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using WoMoCo.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using WoMoCo.ViewModels.Account;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class ConnectionsController : Controller
    {

        private IConnectionService _service;
        private readonly UserManager<ApplicationUser> _manager;

        // GET: api/values
        [HttpGet]
        [Authorize]
        public IEnumerable<UserConnection> Get()
        {
            return _service.GetAllFriends();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetFriendsId(string id)
        {
            return Ok(_service.GetFriendsId(id));
        }

        [HttpGet("GetConnections/")]
        [Authorize]
        public IActionResult GetConnections()
        {
            string uid = _manager.GetUserId(User);
            return Ok(_service.GetFriendsId(uid));
        }
        [HttpGet("GetConnectionsForPullDown/")]
        [Authorize]
        public IEnumerable<UserForPullDown> GetConnectionsForPullDown()
        {
            string uid = _manager.GetUserId(User);
            return _service.GetConnectedUsersForPullDown(uid);
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public void SavingFriends([FromBody]UserConnection user)
        {
            string currentUser = _manager.GetUserId(User);
            user.CurrentUserId = currentUser;
            _service.SavingFriends(user);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            string uid = _manager.GetUserId(User);
            _service.DeletingFriends(uid, id);
            return Ok();
        }

        public ConnectionsController(IConnectionService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }
    }
}

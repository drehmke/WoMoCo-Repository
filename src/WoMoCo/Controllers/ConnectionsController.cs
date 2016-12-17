using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using WoMoCo.Interfaces;
using Microsoft.AspNetCore.Identity;

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
        public IEnumerable<UserConnection> Get()
        {
            return _service.GetAllFriends();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetFriendsId(string id)
        {
            return Ok(_service.GetFriendsId(id));
        }

        // POST api/values
        [HttpPost]
        public void SavingFriends([FromBody]UserConnection user)
        {
            string currentUser = _manager.GetUserId(User);
            user.CurrentUserId = currentUser;
            _service.SavingFriends(user);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeletingFriends(string id)
        {
            _service.DeletingFriends(id);
         
        }

        public ConnectionsController(IConnectionService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }
    }
}


//// PUT api/values/5
//[HttpPut("{id}")]
//public void Put(int id, [FromBody]string value)
//{
//}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using Microsoft.AspNetCore.Identity;
using WoMoCo.Interfaces;
using WoMoCo.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class SearchesController : Controller
    {
        private ISearchesService _service;
        private UserManager<ApplicationUser> _manager;
        private ICommService _communication;
        public SearchesController(ISearchesService service, UserManager<ApplicationUser> manager, ICommService communication)
        {
            this._manager = manager;
            this._service = service;
            this._communication = communication;
        }
        // GET: api/values
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_service.GetAllUsersSearch());
        //}

        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            return _service.GetAllUsersSearch();
        }

        //Get all requests
        //[HttpGet("Requests")]
        //public IEnumerable<Comm> GetRequests(string userName)
        //{
            
        //}


        // GET api/values/5
        [HttpGet("{id}")]
        public ApplicationUser Get(string username)
        {
            return _service.GetUserByIds(username);
        }

        //GET by userName
        [HttpGet("GetUser/")]
        public ApplicationUser GetUser()
        {
            //var user = this.User;
            var uid = _manager.GetUserId(User);
            return _service.GetByUsernames(uid);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ApplicationUser user)
        {
            _service.SaveUsers(user);

            return Ok(user);
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _service.DeleteUsers(id);
            return Ok();
        }

    }

}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using Microsoft.AspNetCore.Identity;
using WoMoCo.Interfaces;
using WoMoCo.Services;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        [Authorize]
        public IEnumerable<ApplicationUser> Get()
        {
            return _service.GetAllUsersSearch();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public ApplicationUser Get(string username)
        {
            return _service.GetUserByIds(username);
        }

        //GET by userName
        [HttpGet("GetUser/")]
        [Authorize]
        public ApplicationUser GetUser()
        {
            //var user = this.User;
            var uid = _manager.GetUserId(User);
            return _service.GetByUsernames(uid);
        }


        //To Do on Second Iteration
        ////Making a user an admin
        //[HttpPost]
        //public IActionResult MakeAdminUpdate()
        //{
        //    var uid = _manager.GetUserId(User);
        //    _service.MakeAdminUpdate(uid);
        //    return Ok(uid);
        //}

    }

}

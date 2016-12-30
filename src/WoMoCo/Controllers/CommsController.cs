using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using WoMoCo.Interfaces;
using Microsoft.AspNetCore.Identity;
using WoMoCo.Services;
using Microsoft.AspNetCore.Authorization;
using WoMoCo.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class CommsController : Controller
    {
        private ICommService _service;
        private UserManager<ApplicationUser> _manager;

        // GET: api/values
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<Comm> Get()
        {
            return _service.GetAllComms();
        }

        // GET a comm by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetCommById(id));
        }
        [HttpGet("AdminGet/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminGet(int id)
        {
            return Ok(_service.GetCommById(id));
        }

        [HttpGet("GetUserNewMessageCount/")]
        public int GetUserNewMessageCount()
        {
            string uid = _manager.GetUserId(User);
            int count = _service.GetCountCurrentUserNewMessages(uid);
            return count;
        }
        [HttpGet("GetCommsByUserName")]
        public IEnumerable<CommViewModel> GetCommsByUserName()
        {
            string uid = _manager.GetUserName(User);
            IList<CommViewModel> commView = _service.GetCommsByUserName(uid);          
            return commView;
        }
        //POST api/values
       [HttpPost]
        public IActionResult Post([FromBody]Comm comm)
        {
            string uid = _manager.GetUserId(User);
            _service.SaveComm(comm, uid);
            return Ok(comm);
        }      

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteComm(id);
            return Ok();
        }
        [HttpDelete("AdminGet/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminDelete(int id)
        {
            _service.DeleteComm(id);
            return Ok();
        }
        public CommsController(ICommService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }
    }
}

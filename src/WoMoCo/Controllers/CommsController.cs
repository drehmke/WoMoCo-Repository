using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using WoMoCo.Services;
using Microsoft.AspNetCore.Identity;
using WoMoCo.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class CommsController : Controller
    {
        private ICommService _service;
        private readonly UserManager<ApplicationUser> _manager;

        // GET: api/values
        [HttpGet]
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

        //POST api/values
       [HttpPost]
        public IActionResult Post([FromBody]Comm comm)
        {
            string uid = _manager.GetUserId(User);
            _service.SaveComm(comm, uid);
            return Ok(comm);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteComm(id);
            return Ok();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommsController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="manager">The manager.</param>
        public CommsController(ICommService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }
    }
}

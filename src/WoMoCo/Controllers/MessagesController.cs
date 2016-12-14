using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Services;
using WoMoCo.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private UserManager<ApplicationUser> _manager;

        private IMessageService _service;

        // GET: api/values 
        [HttpGet]
        public IEnumerable<Message> Get()
        {

            return _service.GetAllMessages();



        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetMessageInfo(int id)
        {
            return Ok(_service.getMessageInfo(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Message msg)
        {
            string uid = _manager.GetUserId(User);
            _service.sendMessage(msg, uid);
            return Ok(msg);
        }

        //PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            return Ok();
        }
        public MessagesController(IMessageService service, UserManager<ApplicationUser> manager)
        {
            this._manager = manager;
            this._service = service;
        }
    }
}

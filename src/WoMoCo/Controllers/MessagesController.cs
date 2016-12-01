using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Services;
using WoMoCo.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private IMessageService _service;

        // GET: api/values
        [HttpGet]
        public IActionResult MsgsByUser(string id)
        {

            return Ok(_service.MsgsByUser(id));
           
           
            
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
            _service.sendMessage(msg);
            return Ok(msg);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody]Message message)
        //{
        //    _service.SaveMessage(int id);
        //    return Ok(message);
        //}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            return Ok();
        }
        public MessagesController(IMessageService service)
        {
            this._service = service;
        }
    }
}

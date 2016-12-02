using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using WoMoCo.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class ChatsController : Controller
    {
        private IChatService _service;

        //GET api/chats
        [HttpGet]
        public IEnumerable<Chat> Get()
        {
            return _service.GetAllChats();
        }

        //Get api/chats/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetChatById(id));
        }

        //POST api/chats
        [HttpPost]
        public IActionResult Post([FromBody]Chat chat)
        {
            _service.SaveChat(chat);
            return Ok(chat);
        }

        //DELETE api/chats/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteChat(id);
            return Ok();
        }

        public ChatsController(IChatService service)
        {
            this._service = service;
        }
    }
}

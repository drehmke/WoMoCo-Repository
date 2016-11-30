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
    public class LinkController : Controller
    {
        // GET: api/values
        private ILinkService _service;

        [HttpGet]
        public IEnumerable<Link> Get()
        {
            return _service.GetAllLinks();
        }
       
   
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetLinkById(id));
        }
       
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Link link)
        {
            _service.SaveLink(link);
            return Ok();
        }
       
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteList(id);
            return Ok();
        }
        public LinkController(ILinkService service)
        {
            this._service = service;
        }
    }
}

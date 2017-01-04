using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using WoMoCo.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class BabySitterLinkController : Controller
    {
        private IBabySitterService _service;

        // GET: api/values
        [HttpGet]
        public IEnumerable<BabySitterLink> Get()
        {
            return _service.GetAllBabySitterLinks();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        public BabySitterLinkController(IBabySitterService service)
        {
            this._service = service;
        }
    }
}

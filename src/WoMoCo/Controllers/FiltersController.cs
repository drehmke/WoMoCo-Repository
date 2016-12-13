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
    public class FiltersController : Controller
    {

        private IFilterService _service;

        private UserManager<ApplicationUser> _manager;

        public FiltersController(IFilterService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            return _service.GetAllUsers();
        }




    }
}



//// GET api/values/5
//[HttpGet("{id}")]
//public string Get(int id)
//{
//    return "value";
//}

//// POST api/values
//[HttpPost]
//public void Post([FromBody]string value)
//{
//}

//// PUT api/values/5
//[HttpPut("{id}")]
//public void Put(int id, [FromBody]string value)
//{
//}

//// DELETE api/values/5
//[HttpDelete("{id}")]
//public void Delete(int id)
//{
//}
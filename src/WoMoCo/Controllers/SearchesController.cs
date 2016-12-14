using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using Microsoft.AspNetCore.Identity;
using WoMoCo.Interfaces;
using WoMoCo.ViewModels.Account;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class SearchesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserManager<UserViewModel> _usersManager;

        private ISearchService _service;

        public SearchesController(ISearchService service, UserManager<ApplicationUser> userManager, UserManager<UserViewModel> usersManager)
        {
            this._service = service;
            this._userManager = userManager;
            this._usersManager = usersManager;
        }

        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            return _service.GetAllUsers();
        }

        /*
        // GET: api/values
        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return _service.GetAllUsersForSearch();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ApplicationUser Get(string userName)
        {
            return _service.GetUserByIdForSearch(userName);
        }



        //[HttpGet("TableFilter")]
        //public IActionResult TableFilter([FromBody]UserViewModel _data)
        //{
        //    return Ok();
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

    */
    }
}

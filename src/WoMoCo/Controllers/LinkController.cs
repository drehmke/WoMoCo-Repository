using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using WoMoCo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using WoMoCo.ViewModels.Links;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class LinkController : Controller
    {
       
        private ILinkService _service;
        private UserManager<ApplicationUser> _manager;
       
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<LinkForAdmin> Get()
        {
            return _service.GetAllLinks();
        }

        [HttpGet("GetMy/")]
        public IEnumerable<Link> GetMy()
        {
            string uid = _manager.GetUserId(User);
            IList<Link> listableLinks = _service.GetLinksByUser(uid);
            return listableLinks;
        }
               
        // Admin list of all links
        [HttpGet("GetAdminList/")]
        public IEnumerable<AdminLinkList> GetAdminList()
        {
            return _service.GetLinks();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetLinkById(id));
        }
        [HttpGet("Admin/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminGet(int id)
        {
            return Ok(_service.GetAdminLinkById(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody]Link link)
        {
            string uid = _manager.GetUserId(User);
            _service.SaveLink(link, uid);
         
            return Ok();
        }
        [HttpPost("AdminUpdate")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminUpdate([FromBody]LinkForAdmin link)
        {
            _service.AdminUpdate(link);
            return Ok(link);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteLink(id);
            return Ok();
        }
        [HttpDelete("Admin/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminDelete(int id)
        {
            _service.DeleteLink(id);
            return Ok();
        }

        public LinkController(ILinkService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
           
        }
    }
}

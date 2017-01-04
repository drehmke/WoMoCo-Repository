using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Services;
using WoMoCo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private IPostService _service;
        private UserManager<ApplicationUser> _manager;
        
        // GET: api/values
        [HttpGet]
        [Authorize]
        public IEnumerable<Post> Get()
        {
            return _service.GetAllPosts();
        }

        [HttpGet("AdminGet/")]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<Post> AdminGet()
        {
            return _service.GetAllPosts();
        }

        // GET api/values/
        [HttpGet("{id}")]
        [Authorize]
        public Post Get(int id)
        {
            return _service.GetPostById(id);
        }

        [HttpGet("AdminGetPost/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public Post AdminGet(int id)
        {
            return _service.GetPostById(id);
        }

        //for iteration 2
        //get first five posts
        //[HttpGet("GetAdPostFirstFive")]
        //[Authorize(Policy = "AdminOnly")]
        //public IEnumerable<Post> GetAdPostFirstFive()
        //{
        //    return _service.GetAdPostFirstFive();
        //}

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]Post post)
        {
            string uid = _manager.GetUserId(User);
            _service.SavePost(uid, post);
            return Ok(post);
        }
        [HttpPost("AdminPost/")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminPost([FromBody] Post post)
        {
            _service.SavePostAdmin(post);
            return Ok(post);
        }

        [HttpGet("GetPostByUser")]
        [Authorize]
        public IList<Post> GetPost()
        {
            /*var user = this.User*/;
            var uid = _manager.GetUserName(User);
            return _service.GetByUsername(uid);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _service.DeletePost(id);
            return Ok();
        }
        [HttpDelete("AdminGetPost/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminDelete(int id)
        { // TODO: Make sure admin deletes are going through here. Looks like the delete from the AdminPage is goign through the non-admin delete
            _service.DeletePost(id);
            return Ok();
        }

        public PostsController(IPostService service, UserManager<ApplicationUser> manager)
        {
            this._manager = manager;
            this._service = service;
        }
    }
}

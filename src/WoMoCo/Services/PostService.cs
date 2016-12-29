using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public class PostService : IPostService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;
        

        // Get all Posts
        public IList<Post> GetAllPosts()
        {
            var posts = _repo.Query<Post>().OrderByDescending(x => x.Id).ToList();
            return posts;
        }
        // Get single post by Id
        public Post GetPostById(int id)
        {
            return _repo.Query<Post>().Where(m => m.Id == id).FirstOrDefault();
        }
        //Get a post by username
        public IList<Post> GetByUsername(string username)
        {
            var getpostbyuser = _repo.Query<Post>().Where(m => m.UserName == username).ToList();
            return getpostbyuser;
        }

        ////save a single post to the database
        //public void SavePost(Post post)
        //{
        //    if(post.Id == 0)
        //    {
        //        _repo.Add(post);
        //    }
        //    else
        //    {
        //        _repo.Update(post);
        //    }
        //}

        //Delete single post from the database
        public void DeletePost(int id)
        {
            Post postToDelete = _repo.Query<Post>().Where(m => m.Id == id).FirstOrDefault();
            _repo.Delete(postToDelete);
        }

        public void SavePost(string user, Post post)
        {

            ApplicationUser AppUser = _repo.Query<ApplicationUser>().Where(u => u.Id == user).FirstOrDefault();
            var userId = AppUser.Id;
            post.UserName = AppUser.UserName;

            if (post.Id == 0)
            {
                _repo.Add(post); 
            }
            else 
            {
                _repo.Update(post);
            }
            //post.User.Add(AppUser);
            //_repo.SaveChanges();
        }

        public PostService(IGenericRepository repo, UserManager<ApplicationUser> manager)
        {
            this._manager = manager;
            this._repo = repo;
        }
    }
}

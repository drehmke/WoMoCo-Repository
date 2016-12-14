using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public interface IPostService
    {
        void DeletePost(int id);
        IList<Post> GetAllPosts();
        IList<Post> GetByUsername(string username);
        Post GetPostById(int id);
        void SavePost(string user, Post post);
    }
}
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Repositories;
using WoMoCo.ViewModels.Account;

namespace WoMoCo.Services
{
    public class SearchesService : ISearchesService
    {
        public IGenericRepository _repo;
        private UserManager<ApplicationUser> _userManager;

        public SearchesService(IGenericRepository repo, UserManager<ApplicationUser> userManager)
        {
            this._repo = repo;
            this._userManager = userManager;
        }

        //get all users

        public List<ApplicationUser> GetAllUsersSearch()
        {
            var users = _repo.Query<ApplicationUser>().ToList();
            return users;
        }

        //get single user by id
        public ApplicationUser GetUserByIds(string id)
        {
            return _repo.Query<ApplicationUser>().Where(m => m.Id == id).FirstOrDefault();
        }


        public ApplicationUser GetByUsernames(string uid)
        {
            return _repo.Query<ApplicationUser>().Where(m => m.Id == uid).FirstOrDefault();
        }


        //To Do on Second Iteration
        //Making a user an admin
        //public async Task<List<ApplicationUser>> MakeAdminUpdate(string uid)
        //{
        //    var user = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
        //    await user.AddClaim(new Claim("myCustomClaim", "value of claim"));



        //    //if (!user.HasClaim("IsAdmin", "true"))
        //    //{
        //    //    await userManager.AddClaimAsync(uid, new ApplicationUser("IsAdmin", "true"));
        //    //    _repo.Update(uid);
        //    //}
        //    //_repo.SaveChanges();
        //}


    }
}
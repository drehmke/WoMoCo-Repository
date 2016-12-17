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

        public SearchesService(IGenericRepository repo)
        {
            this._repo = repo;
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



    }
}
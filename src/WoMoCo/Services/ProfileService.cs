using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Repositories;

namespace WoMoCo.Services
{
    public class ProfileService : IProfileService
    {
        private IGenericRepository _repo;

        //get all users
        public IList<ApplicationUser> GetAllUsers()
        {
            return _repo.Query<ApplicationUser>().ToList();
        }

        //get a single user by id
        public ApplicationUser GetUserById(string id)
        {
            return _repo.Query<ApplicationUser>().Where(m => m.Id == id).FirstOrDefault();
        }

        //post a single user to the database
        public void SaveUser(ApplicationUser user)
        {
            if (user.Id == null)
            {
                _repo.Add(user);
            }
            else
            {
                _repo.Update(user);
            }
        }

        //delet a user from the database
        public void DeleteUser(string id)
        {
            ApplicationUser userToDelete = _repo.Query<ApplicationUser>().Where(m => m.Id == id).FirstOrDefault();
            _repo.Delete(userToDelete);
        }
        
        //get a user by username

        public ApplicationUser GetByUsername(string username)
        {
            return _repo.Query<ApplicationUser>().Where(m => m.UserName == username).FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.ViewModels.Account;


namespace WoMoCo.Services
{
    public class UserService : IUserService
    {
        public IGenericRepository _repo;

        //get all users
        
        public List<ApplicationUser> GetAllUsers()
        {
            var users = _repo.Query<ApplicationUser>().ToList();
            return users;
        }

        public IList<UserForPullDown> GetAllUsersForPullDown()
        { // we will need to modify or make another version to get friends only
            IList<ApplicationUser> allUsers = _repo.Query<ApplicationUser>().ToList();
            IList<UserForPullDown> allPullDownUsers = new List<UserForPullDown>();
            foreach(ApplicationUser user in allUsers )
            {
                UserForPullDown addUser = new UserForPullDown
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                allPullDownUsers.Add(addUser);
            }
            return allPullDownUsers;
        }
        //get single user by id
        public ApplicationUser GetUserById(string id)
        {
            return _repo.Query<ApplicationUser>().Where(m => m.Id == id).FirstOrDefault();
        }

        //post a single user to the database
        public void SaveUser(ApplicationUser user)
        {
            if(user.Id == null)
            {
                _repo.Add(user);
            }else
            {
                _repo.Update(user);
            }
        }

        //delete single User from the database

        public void DeleteUser(string id)
        {
            ApplicationUser userToDelete = _repo.Query<ApplicationUser>().Where(u => u.Id == id).FirstOrDefault();
            _repo.Delete(userToDelete);
        }

        public ApplicationUser GetByUsername(string uid)
        {
            return _repo.Query<ApplicationUser>().Where(m => m.Id == uid).FirstOrDefault();
        }

        public UserService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}

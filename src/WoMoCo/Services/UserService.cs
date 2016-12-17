using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.ViewModels.Account;
using System.Security.Cryptography;
using System.Text;

namespace WoMoCo.Services
{
    public class UserService : IUserService
    {
        public IGenericRepository _repo;

        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            // convert the input string to a byte array and compute the hash
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // create a new StringBuilder to collect the bytes and create a string
            StringBuilder sBuilder = new StringBuilder();
            // loop through each byte of the hashed data and format each one as a hexadecimal string
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // return the hexadecimal string
            return sBuilder.ToString();
        }

        private string CheckUserImage(string userImage, string email)
        {
            if( userImage == null)
            { // our userImage field is null, we need to generate the md5 hash string for gravatar
                MD5 md5Hash = MD5.Create();
                userImage = this.GetMd5Hash(md5Hash, email);
            }
            return userImage;
        }

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
            // not sure we need this here as user saving is handled by the userManager,
            // but just in case ...
            MD5 md5Hash = MD5.Create();
            user.UserImage = this.GetMd5Hash(md5Hash, user.Email);
            if (user.Id == null)
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

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.ViewModels.Account;

namespace WoMoCo.Services
{
    public class ConnectionService : IConnectionService
    {
        private IGenericRepository _repo;
        

        public IEnumerable<UserConnection> GetAllFriends()
        {
            return _repo.Query<UserConnection>().ToList();
        }
        
        public IList<ApplicationUser> GetFriendsId(string id)
        {
            IList<UserConnection> connectedUsersForCurrent = _repo.Query<UserConnection>().Where(u => u.CurrentUserId == id).ToList();
            IList<ApplicationUser> connectedUsers = new List<ApplicationUser>();
            foreach(UserConnection userConn in connectedUsersForCurrent)
            {
                ApplicationUser tempUser = _repo.Query<ApplicationUser>().Where(u => u.Id == userConn.ConnectedUserId).FirstOrDefault();
                ApplicationUser listable = new ApplicationUser
                {
                    Id = tempUser.Id,
                    UserName = tempUser.UserName,
                    UserImage = tempUser.UserImage,
                    FirstName = tempUser.FirstName,
                    LastName = tempUser.LastName
                };
                connectedUsers.Add(listable);
            }
            return connectedUsers;
        }
        public IList<UserForPullDown> GetConnectedUsersForPullDown(string uid)
        {
            IList<UserConnection> connectedUsersForCurrent = _repo.Query<UserConnection>().Where(u => u.CurrentUserId == uid).ToList();
            IList<UserForPullDown> connectedUsers = new List<UserForPullDown>();
            foreach (UserConnection userConn in connectedUsersForCurrent)
            {
                ApplicationUser tempUser = _repo.Query<ApplicationUser>().Where(u => u.Id == userConn.ConnectedUserId).FirstOrDefault();
                UserForPullDown listable = new UserForPullDown
                {
                    UserId = tempUser.Id,
                    UserName = tempUser.UserName,
                    FirstName = tempUser.FirstName,
                    LastName = tempUser.LastName
                };
                connectedUsers.Add(listable);
            }
            return connectedUsers;
            //IList<ApplicationUser> allUsers = _repo.Query<ApplicationUser>().ToList();
            //IList<UserForPullDown> allPullDownUsers = new List<UserForPullDown>();
            //foreach (ApplicationUser user in allUsers)
            //{
            //    UserForPullDown addUser = new UserForPullDown
            //    {
            //        UserId = user.Id,
            //        UserName = user.UserName,
            //        FirstName = user.FirstName,
            //        LastName = user.LastName
            //    };
            //    allPullDownUsers.Add(addUser);
            //}
            //return allPullDownUsers;
        }
        public void SavingFriends(UserConnection user)
        {
            ApplicationUser connectedUser = _repo.Query<ApplicationUser>().Where(u => u.UserName == user.ConnectedUserId).FirstOrDefault();
            user.ConnectedUserId = connectedUser.Id;
            user.DateConnected = DateTime.Now;
            if(user.ConnectedUserId != null)
            {
                _repo.Add(user);
                // Now make the same statement, only in reverse, so that the two users will see each other on their connections list
                UserConnection reversed = new UserConnection
                {
                    ConnectedUserId = user.CurrentUserId,
                    CurrentUserId = user.ConnectedUserId,
                    DateConnected = DateTime.Now
                };
                _repo.Add(reversed);
            }

        }

        public void DeletingFriends(string uid, string cid)
        {
            UserConnection connectionToDelete = _repo.Query<UserConnection>().Where(c => c.CurrentUserId == uid && c.ConnectedUserId == cid).FirstOrDefault();
            _repo.Delete(connectionToDelete);
            // delete the reverse statement as well
            UserConnection reverseToDelete = _repo.Query<UserConnection>().Where(c => c.ConnectedUserId == uid && c.CurrentUserId == cid).FirstOrDefault();
            _repo.Delete(reverseToDelete);
        }

        public ConnectionService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}

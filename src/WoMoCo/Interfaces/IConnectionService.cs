using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using WoMoCo.ViewModels.Account;

namespace WoMoCo.Interfaces
{
    public interface IConnectionService
    {
        void DeletingFriends(string uid, string cid);
        IEnumerable<UserConnection> GetAllFriends();
        IList<ApplicationUser> GetFriendsId(string id);
        void SavingFriends(UserConnection user);
        IList<UserForPullDown> GetConnectedUsersForPullDown(string uid);
    }
}
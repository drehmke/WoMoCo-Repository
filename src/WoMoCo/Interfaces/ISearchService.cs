using System.Collections.Generic;
using WoMoCo.Models;
using WoMoCo.ViewModels.Account;

namespace WoMoCo.Interfaces
{
    public interface ISearchService
    {
        IList<ApplicationUser> GetAllUsers();
        IList<UserViewModel> GetAllUsersForSearch();
        ApplicationUser GetUserByIdForSearch(string id);
        //List<ApplicationUser> UserByUsername(string searchTerm);
    }
}
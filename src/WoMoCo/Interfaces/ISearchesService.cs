using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Interfaces
{
    public interface ISearchesService
    {
        void DeleteUsers(string id);
        List<ApplicationUser> GetAllUsersSearch();
        ApplicationUser GetByUsernames(string uid);
        ApplicationUser GetUserByIds(string id);
        void SaveUsers(ApplicationUser user);
    }
}
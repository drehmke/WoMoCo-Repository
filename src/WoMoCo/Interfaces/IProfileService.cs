using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public interface IProfileService
    {
        void DeleteUser(string id);
        IList<ApplicationUser> GetAllUsers();
        ApplicationUser GetUserById(string id);
        void SaveUser(ApplicationUser user);
        ApplicationUser GetByUsername(string username);
    }
}
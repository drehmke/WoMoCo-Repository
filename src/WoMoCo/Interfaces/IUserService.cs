using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public interface IUserService
    {
        void DeleteUser(string id);
        IList<ApplicationUser> GetAllUsers();
        ApplicationUser GetByUsername(string username);
        ApplicationUser GetUserById(string id);
        void SaveUser(ApplicationUser user);
    }
}
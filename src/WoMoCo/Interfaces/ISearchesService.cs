using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Interfaces
{
    public interface ISearchesService
    {
      
        List<ApplicationUser> GetAllUsersSearch();
        ApplicationUser GetByUsernames(string uid);
        ApplicationUser GetUserByIds(string id);
     
    }
}
using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Interfaces
{
    public interface IFilterService
    {
        IList<ApplicationUser> GetAllUsers();
    }
}
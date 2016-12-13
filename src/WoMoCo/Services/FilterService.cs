using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public class FilterService : IFilterService
    {
        public IGenericRepository _repo;

        public FilterService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        public IList<ApplicationUser> GetAllUsers()
        {
            return _repo.Query<ApplicationUser>().ToList();
        }
    }
}

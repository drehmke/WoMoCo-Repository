using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Repositories;

namespace WoMoCo.Services
{
    public class InterestService :IInterestService
    {
        private IGenericRepository _repo;
        public IList<Interest> GetAllInterests()
        {
            return _repo.Query<Interest>().ToList();
        }

        public Interest GetInterestbyId(int id)
        {
            return _repo.Query<Interest>().Where(i => i.Id == id).FirstOrDefault();
        }
        public void SaveInterest(Interest interest)
        {
            if (interest.Id == 0)
            {
                _repo.Add(interest);
            }
            else
            {
                _repo.Update(interest);
            }
        }
        
        public List<Interest> SearchById(string searchTerm)
        {
            var Interests = _repo.Query<Interest>();
            return (from i in Interests
                    where i.Name == searchTerm
                    select new Interest
                    {
                        Name = i.Name,
                        Users = i.Users,
                    }).ToList();
        }
        public void DeleteInterest(int id)
        {
            Interest interestTODelete = _repo.Query<Interest>().Where(i => i.Id == id).FirstOrDefault();
            _repo.Delete(interestTODelete);
        }
        public InterestService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}

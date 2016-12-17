using Microsoft.EntityFrameworkCore;
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

        public IList<Interest> GetInterestsByUser(string uid)
        {
            ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
            IList<Interest> userInterests = _repo.Query<Interest>().Include(i => i.User).ToList();
            IList<Interest> listableInterests = new List<Interest>();
            foreach(Interest interest in userInterests)
            {
                Interest listable = new Interest
                {
                    Id = interest.Id,
                    Name = interest.Name,
                    BadgeImage = interest.BadgeImage
                };
                listableInterests.Add(listable);
            }
            return listableInterests;
        }

        public void SaveInterest(Interest interest, string uid)
        
        {
            if (interest.Id == 0)
            {
                _repo.Add(interest);
            }
            else
            {
                _repo.Update(interest);
            }
            ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
            interest.User = user;
            _repo.SaveChanges();
        }
        
        public List<Interest> SearchById(string searchTerm)
        {
            var Interests = _repo.Query<Interest>();
            return (from i in Interests
                    where i.Name == searchTerm
                    select new Interest
                    {
                        Name = i.Name,
                        User = i.User,
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

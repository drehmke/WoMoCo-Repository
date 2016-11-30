using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Data.Migrations;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Services;

namespace WoMoCo.Services
{
    public class LinkService : ILinkService
    {
        private IGenericRepository _repo;
        public IList<Link>GetAllLinks()
        {
            return _repo.Query<Link>().ToList();
        }

        public Link GetLinkById(int id)
        {
          return _repo.Query<Link>().Where(l => l.Id == id).FirstOrDefault();
        }
        public void SaveLink(Link link)
        {
            if (link.Id==0)
            {
                _repo.Add(link);
            }
            else
            {
                _repo.Update(link);
            }
        }

            public List<Link>  SearchByID(string searchTerm)
        {
            var Links = _repo.Query<Link>();
                return (from l in Links
                    where l.Name == searchTerm
                    select new Link
                    {
                        Name = l.Name,
                        Users = l.Users,
                    }).ToList();
        }
        public void DeleteList(int id)
        {
            Link linkTODelete = _repo.Query<Link>().Where(l => l.Id == id).FirstOrDefault();
            _repo.Delete(linkTODelete);
        }
        public LinkService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}

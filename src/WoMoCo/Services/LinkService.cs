using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Data.Migrations;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Services;
using WoMoCo.ViewModels.Links;

namespace WoMoCo.Services
{
    public class LinkService : ILinkService
    {
        private IGenericRepository _repo;
        public IList<Link>GetAllLinks()
        {
            return _repo.Query<Link>().ToList();
        }

        public IList<AdminLinkList> GetLinks()
        {
            IList<Link> allLinks = _repo.Query<Link>().Include(l => l.User).ToList();
            IList<AdminLinkList> listableLinks = new List<AdminLinkList>();
            foreach( Link link in allLinks)
            {
                AdminLinkList listable = new AdminLinkList
                {
                    Id = link.Id,
                    Name = link.Name,
                    Url = link.Url,
                    LinkType = link.LinkType,
                    OwnerName = link.User.UserName
                };
                listableLinks.Add(listable);
            }
            return listableLinks;
        }

        public Link GetLinkById(int id)
        {
          return _repo.Query<Link>().Where(l => l.Id == id).FirstOrDefault();
        }

        public IList<Link> GetLinksByUser(string uid)
        {
            ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
            IList<Link> userLinks = _repo.Query<Link>().Include(l => l.User).ToList();
            IList<Link> listableLinks = new List<Link>();
            foreach(Link link in userLinks)
            {
                Link listable = new Link
                {
                    Id = link.Id,
                    Name = link.Name,
                    Url = link.Url,
                    LinkType = link.LinkType
                };
                listableLinks.Add(listable);
            }
            return listableLinks;
        }

        public void SaveLink(Link link, string uid)
        {
            if (link.Id==0)
            {
                _repo.Add(link);
            }
            else
            {
                _repo.Update(link);
            }
            ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
            link.User = user;
            _repo.SaveChanges();
        }

        public List<Link>  SearchByID(string searchTerm)
        {
            var Links = _repo.Query<Link>();
                return (from l in Links
                    where l.Name == searchTerm
                    select new Link
                    {
                        Name = l.Name,
                        User = l.User,
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

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Data.Migrations;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Services;
using WoMoCo.ViewModels.Link;

namespace WoMoCo.Services
{
    public class LinkService : ILinkService
    {
        private IGenericRepository _repo;
        public IList<LinkForAdmin>GetAllLinks()
        {
            IList<Link> allLinks = _repo.Query<Link>().Include( l => l.User ).ToList();
            IList<LinkForAdmin> listableLinks = new List<LinkForAdmin>();
            foreach(Link link in allLinks)
            {
                LinkForAdmin listable = new LinkForAdmin
                {
                    Id = link.Id,
                    Name = link.Name,
                    Url = link.Url,
                    LinkType = link.LinkType,
                    UserName = link.User.UserName
                };
                listableLinks.Add(listable);
            }
            return listableLinks;
        }

        public Link GetLinkById(int id)
        {
          return _repo.Query<Link>().Where(l => l.Id == id).FirstOrDefault();
        }
        public LinkForAdmin GetAdminLinkById(int id)
        {
            Link link = _repo.Query<Link>().Where(l => l.Id == id).Include( l => l.User).FirstOrDefault();
            LinkForAdmin listable = new LinkForAdmin
            {
                Id = link.Id,
                Name = link.Name,
                Url = link.Url,
                LinkType = link.LinkType,
                UserName = link.User.UserName
            };
            return listable;
        }

        public IList<Link> GetLinksByUser(string uid)
        {
            ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
            IList<Link> userLinks = _repo.Query<Link>().Include(l => l.User).ToList();
            IList<Link> listableLinks = new List<Link>();
            foreach(Link link in userLinks)
            {
                if( link.User.Id == uid)
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
        public void AdminUpdate(LinkForAdmin link)
        {
            // Convert this back to a normal Link object for saving ...
            Link linkToSave = new Link
            {
                Id = link.Id,
                Name = link.Name,
                Url = link.Url,
                LinkType = link.LinkType
            };
            // pull the user info to keep that relationship
            ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.UserName == link.UserName).FirstOrDefault();
            linkToSave.User = user;
            _repo.Update(linkToSave);
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
        public void DeleteLink(int id)
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

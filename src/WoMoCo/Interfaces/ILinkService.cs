using System.Collections.Generic;
using WoMoCo.Models;
using WoMoCo.ViewModels.Links;

namespace WoMoCo.Services
{
    public interface ILinkService
    {
        void DeleteLink(int id);
        IList<LinkForAdmin> GetAllLinks();
        IList<AdminLinkList> GetLinks();
        Link GetLinkById(int id);
        void SaveLink(Link link, string uid);
        List<Link> SearchByID(string searchTerm);
        IList<Link> GetLinksByUser(string uid);
        void AdminUpdate(LinkForAdmin link);
        LinkForAdmin GetAdminLinkById(int id);
    }
}
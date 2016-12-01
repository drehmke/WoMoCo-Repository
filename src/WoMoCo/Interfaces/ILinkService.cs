using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public interface ILinkService
    {
        void DeleteList(int id);
        IList<Link> GetAllLinks();
        Link GetLinkById(int id);
        void SaveLink(Link link, string uid);
        List<Link> SearchByID(string searchTerm);
    }
}
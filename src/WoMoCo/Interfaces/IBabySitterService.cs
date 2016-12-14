using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public interface IBabySitterService
    {
        IList<BabySitterLink> GetAllBabySitterLinks();
        List<BabySitterLocation> GetBabySitterByLinkId(int linkId);
        BabySitterLink GetBabySitterLinkById(int id);
    }
}
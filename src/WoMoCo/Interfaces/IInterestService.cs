using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public interface IInterestService
    {
        void DeleteInterest(int id);
        IList<Interest> GetAllInterests();
        Interest GetInterestbyId(int id);
        void SaveInterest(Interest interest, string uid);
        List<Interest> SearchById(string searchTerm);
    }
}
using System.Collections.Generic;
using WoMoCo.Models;
using WoMoCo.ViewModels.Interests;

namespace WoMoCo.Services
{
    public interface IInterestService
    {
        void DeleteInterest(int id);
        IList<InterestAdminView> GetAllInterests();
        Interest GetInterestbyId(int id);
        void SaveInterest(Interest interest, string uid);
        List<Interest> SearchById(string searchTerm);

        IList<Interest> GetInterestsByUser(string uid);
        InterestAdminView GetAdminInterestById(int id);
        void AdminUpdateInterest(InterestAdminView interest);
    }
}
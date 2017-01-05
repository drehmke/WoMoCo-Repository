using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using WoMoCo.Models;
using WoMoCo.ViewModels.ActivityForum;

namespace WoMoCo.Interfaces
{
    public interface IActivityForumService
    {
        void DeleteActivityForum(int id);
        ActivityForumAdminView GetActivityById(int id);
        IList<ActivityForumAdminView> GetAllActivities();
        IList<ActivityForum> GetByUsername(string username);
        ApplicationUser GetUserByName(string userName);
        void SaveActivity(string user, ActivityForum activityForum);
        Task SaveActivityForum(IPrincipal user, ActivityForum activityForum);
        IList<ActivityForum> SearchByLocation(string searchTerm);
        //Iteration 2
        //IEnumerable<ActivityForum> GetAdFiveActivity();
    }
}
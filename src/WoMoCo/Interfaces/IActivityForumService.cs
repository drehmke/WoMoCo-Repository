using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using WoMoCo.Models;

namespace WoMoCo.Interfaces
{
    public interface IActivityForumService
    {
        void DeleteActivityForum(int id);
        ActivityForum GetActivityById(int id);
        IList<ActivityForum> GetAllActivities();
        IList<ActivityForum> GetByUsername(string username);
        ApplicationUser GetUserByName(string userName);
        void SaveActivity(string user, ActivityForum activityForum);
        Task SaveActivityForum(IPrincipal user, ActivityForum activityForum);
        IList<ActivityForum> SearchByLocation(string searchTerm);
    }
}
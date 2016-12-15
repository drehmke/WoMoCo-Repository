using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public class ActivityForumService : IActivityForumService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;
        public ActivityForumService(IGenericRepository repo, UserManager<ApplicationUser> manager)
        {
            _repo = repo;
            _manager = manager;
        }

        public IList<ActivityForum> GetAllActivities()
        {
            return _repo.Query<ActivityForum>().ToList();
        }
        public ActivityForum GetActivityById(int id)
        {
            return _repo.Query<ActivityForum>().Where(a => a.Id == id).FirstOrDefault();
        }
        public IList<ActivityForum> GetByUsername(string username)
        {
            var getpostbyuser = _repo.Query<ActivityForum>().Where(m => m.UserName == username).ToList();
            return getpostbyuser;
        }
        public void SaveActivity(string user, ActivityForum activityForum)
        {
            ApplicationUser AppUser = _repo.Query<ApplicationUser>().Where(u => u.Id == user).FirstOrDefault();
            var userId = AppUser.Id;
            activityForum.UserName = AppUser.UserName;

            if (activityForum.Id == 0)
            {
                _repo.Add(activityForum);
            }
            else
            {
                _repo.Update(activityForum);
            }
        }
        public async Task SaveActivityForum(IPrincipal user, ActivityForum activityForum)
        {
            var appUser = await _manager.FindByNameAsync(user.Identity.Name);
            activityForum.Location = appUser.Location;

            if (activityForum.Id == 0)
            {
                _repo.Add(activityForum);
            }
            else
            {
                _repo.Update(activityForum);
            }
        }
        public void DeleteActivityForum(int id)
        {
            ActivityForum activityToDelete = _repo.Query<ActivityForum>().Where(a => a.Id == id).FirstOrDefault();
            _repo.Delete(activityToDelete);
        }
        public IList<ActivityForum> SearchByLocation(string searchTerm)
        {
            var activityForum = _repo.Query<ActivityForum>();
            return (from a in activityForum
                    where a.Location == searchTerm
                    select new ActivityForum
                    {
                        Users = a.Users,
                        Location = a.Location,
                        Activity = a.Activity,
                        Description = a.Description
                    }).ToList();
        }
        public ActivityForumService(IGenericRepository repo)
        {
            this._repo = repo;
        }
        public ApplicationUser GetUserByName(string userName)
        {
            var data = _repo.Query<ApplicationUser>().Where(u => u.UserName == userName).FirstOrDefault();
            return data;
        }

        
    }
}

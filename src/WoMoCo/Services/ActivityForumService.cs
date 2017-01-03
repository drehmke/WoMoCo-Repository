using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.ViewModels.ActivityForum;

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

        public IList<ActivityForumAdminView> GetAllActivities()
        {
            IList<ActivityForum> allActivities = _repo.Query<ActivityForum>().ToList();
            IList<ActivityForumAdminView> listableActivities = new List<ActivityForumAdminView>();
            IList<ApplicationUser> allUsers = _repo.Query<ApplicationUser>().ToList();

            foreach (ActivityForum activity in allActivities)
            {
                ActivityForumAdminView listable = new ActivityForumAdminView();
                listable.Id = activity.Id;
                listable.Location = activity.Location;
                listable.Activity = activity.Activity;
                listable.Description = activity.Description;
                listable.UserName = activity.UserName;
                listable.Address = activity.Address;
                foreach (ApplicationUser user in allUsers)
                {
                    if (user.UserName == activity.UserName)
                    {
                        listable.UserId = user.Id;
                        listable.UserImage = user.UserImage;
                    }
                }
                listableActivities.Add(listable);
            }
            return listableActivities;
        }
        public ActivityForumAdminView GetActivityById(int id)
        {
            IList<ApplicationUser> allUsers = _repo.Query<ApplicationUser>().ToList();
            ActivityForum activity = _repo.Query<ActivityForum>().Where(a => a.Id == id).FirstOrDefault();
            ActivityForumAdminView viewableActivity = new ActivityForumAdminView();
            viewableActivity.Id = activity.Id;
            viewableActivity.Location = activity.Location;
            viewableActivity.Activity = activity.Activity;
            viewableActivity.Description = activity.Description;
            viewableActivity.UserName = activity.UserName;
            foreach (ApplicationUser user in allUsers)
            {
                if (user.UserName == activity.UserName)
                {
                    viewableActivity.UserId = user.Id;
                }
            }
            return viewableActivity;
        }

        public IList<ActivityForum> GetByUsername(string uid)
        {
            ApplicationUser user = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
            var getpostbyuser = _repo.Query<ActivityForum>().Where(m => m.UserName == user.UserName).ToList();
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
                        User = a.User,
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

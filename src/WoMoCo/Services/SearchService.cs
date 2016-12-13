using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.ViewModels.Account;

namespace WoMoCo.Services
{
    public class SearchService : ISearchService
    {

        public IGenericRepository _repo;

        public IList<ApplicationUser> GetAllUsers()
        {
            return _repo.Query<ApplicationUser>().ToList();
        }

        public IList<UserViewModel> GetAllUsersForSearch()
        {
            
            IList<ApplicationUser> appUser = _repo.Query<ApplicationUser>().ToList();
            List<UserViewModel> grUsers = new List<UserViewModel>();

            foreach(ApplicationUser aUser in appUser)
            {
                UserViewModel listUser = new UserViewModel
                {
                    UserName = aUser.UserName,
                    FirstName = aUser.FirstName,
                    LastName = aUser.LastName,
                    Email = aUser.Email,
                    Location = aUser.Location,
                    CurrentJobTitle = aUser.CurrentJobTitle,
                    Employer = aUser.Employer

                };

                grUsers.Add(listUser);
            }
            return grUsers;
        }

        public ApplicationUser GetUserByIdForSearch(string id)
        {
            return _repo.Query<ApplicationUser>().Where(u => u.Id == id).FirstOrDefault();
        }


        //public List<dynamic> TableFilter(UserViewModel _data)
        //{
        //    List<dynamic> data = new List<dynamic>();
        //    var id = _data.PageCount;
        //    string uNameFilter = _data.UserName ?? "";
        //    string fNameFilter = _data.FirstName + _data.LastName ?? "";
        //    string emailFilter = _data.Email ?? "";
        //    string locationFilter = _data.Location ?? "";
        //    string jobFilter = _data.CurrentJobTitle ?? "";
        //    string empFilter = _data.Employer ?? "";
        //    data.Add(_repo.Query<ApplicationUser>().Where(u => u.UserName.Contains(uNameFilter) && u.FirstName.Contains(fNameFilter) && u.LastName.Contains(fNameFilter) && u.Email.Contains(emailFilter) && u.Location.Contains(locationFilter) && u.CurrentJobTitle.Contains(jobFilter) && u.Employer.Contains(emailFilter)).Skip(5).Take(5).Select(u => new
        //    {
        //        id = u.Id,
        //        UserName = u.UserName,
        //        FirstName = u.FirstName,
        //        LastName = u.LastName,
        //        Email = u.Email,
        //        Location = u.Location,
        //        CurrentJobTitle = u.CurrentJobTitle,
        //        Employer = u.Employer
        //    }).ToList());
        //    return data;
        //}

        //public List<ApplicationUser> UserByUsername(string searchTerm)
        //{
        //    var userU = _repo.Query<ApplicationUser>();
        //    return (from u in userU
        //            where u.UserName == searchTerm
        //            select new ApplicationUser
        //            {
        //                UserName = u.UserName,
        //                FirstName = u.FirstName,
        //                LastName = u.LastName,
        //                Email = u.Email,
        //                Location = u.Location,
        //                CurrentJobTitle = u.CurrentJobTitle,
        //                Employer = u.Employer
        //            }).ToList();

        //}

        public SearchService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}

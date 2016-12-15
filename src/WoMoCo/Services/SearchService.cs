using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Repositories;
using WoMoCo.ViewModels.Account;

namespace WoMoCo.Services
{
    public class SearchesService : ISearchesService
    {
        public IGenericRepository _repo;

        public SearchesService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        //get all users

        public List<ApplicationUser> GetAllUsersSearch()
        {
            var users = _repo.Query<ApplicationUser>().ToList();
            return users;
        }



        //get single user by id
        public ApplicationUser GetUserByIds(string id)
        {
            return _repo.Query<ApplicationUser>().Where(m => m.Id == id).FirstOrDefault();
        }

        //post a single user to the database
        public void SaveUsers(ApplicationUser user)
        {
            if (user.Id == null)
            {
                _repo.Add(user);
            }
            else
            {
                _repo.Update(user);
            }
        }

        //delete single movie from the database

        public void DeleteUsers(string id)
        {
            ApplicationUser userToDelete = _repo.Query<ApplicationUser>().Where(u => u.Id == id).FirstOrDefault();
            _repo.Delete(userToDelete);
        }

        public ApplicationUser GetByUsernames(string uid)
        {
            return _repo.Query<ApplicationUser>().Where(m => m.Id == uid).FirstOrDefault();
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


    }
}
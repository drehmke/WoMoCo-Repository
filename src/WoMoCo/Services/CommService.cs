using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Repositories;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace WoMoCo.Services
{
    public class CommService : ICommService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;

        //Get all Comms
        public IList<Comm> GetAllComms()
        {
            return _repo.Query<Comm>().ToList();
            
        }
        public Comm GetCommById(int id)
        {

            return _repo.Query<Comm>().Where(c => c.Id == id).FirstOrDefault();
        }

        public void SaveComm(Comm comm, string uid)      

        {
            // get currently logged in user by uid to assign as SendingUser
            ApplicationUser currUser = _repo.Query<ApplicationUser>().Where(a => a.Id == uid).FirstOrDefault();
            //get the RecievingUser
            ApplicationUser recUser = _repo.Query<ApplicationUser>().Where(u => u.UserName == comm.RecId).FirstOrDefault();
            comm.SendingUser = currUser;
            comm.RecId = recUser.UserName;
            comm.ReceivingUser = recUser;
            comm.DateSent = DateTime.Now;
            if(comm.Id == 0)
            {
                _repo.Add(comm);
            }
            else
            {
                _repo.Update(comm);
            }
        }


        public void DeleteComm(int id)
        {
            Comm commToDelete = _repo.Query<Comm>().Where(c => c.Id == id).FirstOrDefault();
            _repo.Delete(commToDelete);
        }


        public int GetCountCurrentUserNewMessages(string uid)
        {
            ApplicationUser currUser = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
            IList<Comm> userComms = _repo.Query<Comm>().Where(c => c.ReceivingUser.Id == uid).ToList();
            int newMessageCount = 0;
            foreach(Comm comm in userComms)
            {
                if(comm.HasBeenViewed != true) { newMessageCount++; }
            }
            return newMessageCount;
        }
        public IList<Comm> GetCommsByUserName(string uid)
        {

            //IList<Comm> userComms = _repo.Query<Comm>().Where(c => c.ReceivingUser.Id == uid).ToList();
            IList<Comm> userComms = _repo.Query<Comm>().Where(c => c.RecId == uid).ToList();
            return userComms;

        }

        public CommService(IGenericRepository repo, UserManager<ApplicationUser> manager)
        {
            _repo = repo;
            _manager = manager;
        }
    }
}

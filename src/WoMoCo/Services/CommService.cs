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
using WoMoCo.ViewModels;

namespace WoMoCo.Services
{
    public class CommService : ICommService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;

        //Get all Comms
        public IList<CommViewModel> GetAllComms()
        {
            IList<Comm> allComms = _repo.Query<Comm>().Include(c => c.SendingUser).ToList();
            IList<CommViewModel> listableComms = new List<CommViewModel>();
            foreach( Comm comm in allComms )
            {
                CommViewModel listable = new CommViewModel
                {
                    Id = comm.Id,
                    RecId = comm.RecId,
                    SendingUser = comm.SendingUser.UserName,
                    Subject = comm.Subject,
                    HasBeenViewed = comm.HasBeenViewed,
                    DateSent = comm.DateSent,
                    Msg = comm.Msg,
                    Status = comm.Status,
                    CommType = comm.CommType
                };
                listableComms.Add(listable);
            }

            return listableComms;
        }

        public IEnumerable<CommViewModel> GetAdminFirstFive()
        {
            IEnumerable<Comm> firstFive = _repo.Query<Comm>().Include(c => c.SendingUser).ToList().Take(5);
            IList<CommViewModel> listableFive = new List<CommViewModel>();
            foreach(Comm comm in firstFive)
            {
                CommViewModel listable = new CommViewModel
                {
                    Id = comm.Id,
                    RecId = comm.RecId,
                    SendingUser = comm.SendingUser.UserName,
                    Subject = comm.Subject,
                    DateSent = comm.DateSent,
                    Msg = comm.Msg,
                    Status = comm.Status,
                    CommType = comm.CommType
                };
                listableFive.Add(listable);
            }

            return listableFive;
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
        public IList<CommViewModel> GetCommsByUserName(string uid)
        {

           
            IList<Comm> userComms = _repo.Query<Comm>().Where(c => c.RecId == uid).Include(c => c.SendingUser).ToList();
            IList<CommViewModel> commView = new List<CommViewModel>();
            foreach(Comm comm in userComms)
            {
                CommViewModel commViews = new CommViewModel
                {
                    Id = comm.Id,
                    RecId = comm.RecId,
                    SendingUser = comm.SendingUser.UserName,
                    Subject = comm.Subject,
                    HasBeenViewed = comm.HasBeenViewed,
                    DateSent = comm.DateSent,
                    Msg = comm.Msg,
                    Status = comm.Status,
                    CommType = comm.CommType
                };
                commView.Add(commViews);
            }
            return commView;
            
           

        }

        public CommService(IGenericRepository repo, UserManager<ApplicationUser> manager)
        {
            _repo = repo;
            _manager = manager;
        }
    }
}

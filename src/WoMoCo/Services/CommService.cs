using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Repositories;
using System.Security.Claims;
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
        public void sendComm(Comm comm, string senderId)
        {
            var receivingUser = _repo.Query<ApplicationUser>().Where(a => a.Id == comm.RecId).FirstOrDefault();
            var sendingUser = _repo.Query<ApplicationUser>().Where(s => s.Id == senderId).FirstOrDefault();

            comm.DateSent = DateTime.Now;
            _repo.Add(comm);
            //associate users with message
            comm.SendingUser = sendingUser;
            comm.ReceivingUser = receivingUser;
            _repo.SaveChanges();



        }
        public void SaveComm(Comm comm)
        {
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

        //public string GetUserId(ClaimsPrincipal user)
        //{
        //    throw new NotImplementedException();
        //}

        public CommService(IGenericRepository repo, UserManager<ApplicationUser> manager)
        {
            _repo = repo;
            _manager = manager;
        }
    }
}

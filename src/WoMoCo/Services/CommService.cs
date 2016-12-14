﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Repositories;

namespace WoMoCo.Services
{
    public class CommService : ICommService
    {
        private IGenericRepository _repo;

        //Get all Comms
        public IList<Comm> GetAllComms()
        {
            return _repo.Query<Comm>().ToList();
            
        }
        public Comm GetCommById(int id)
        {
            return _repo.Query<Comm>().Where(c => c.Id == id).FirstOrDefault();
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
        public CommService(IGenericRepository repo)
        {
            _repo = repo;
        }
    }
}

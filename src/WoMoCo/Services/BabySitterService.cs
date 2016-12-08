using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Data.Migrations;
using WoMoCo.Interfaces;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public class BabySitterService : IBabySitterService

    {
        private IGenericRepository _repo;
        public IList<BabySitterLink> GetAllBabySitterLinks()
        {
            return _repo.Query<BabySitterLink>().ToList();
        }
        public BabySitterLink GetBabySitterLinkById(int id)
        {
            return _repo.Query<BabySitterLink>().Where(s => s.Id == id).FirstOrDefault();
        }
        public BabySitterLink GetBabySitterLinkByName(string name)
        {
            return _repo.Query<BabySitterLink>().Where(s => s.Name == name).FirstOrDefault();
        }
        public List<BabySitterLocation> GetBabySitterByLinkId(int linkId)
        {
            var data = _repo.Query<BabySitterLocation>().Where(s => s.BabySitterLink.Id == linkId).ToList();
            return data;
        }
        public BabySitterService(IGenericRepository repo)

        {
            this._repo = repo;
        }
    }
}

   


           


       

using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public interface ICommService
    {
        void DeleteComm(int id);
        IList<Comm> GetAllComms();
        Comm GetCommById(int id);
        void SaveComm(Comm comm, string uid);
    }
}
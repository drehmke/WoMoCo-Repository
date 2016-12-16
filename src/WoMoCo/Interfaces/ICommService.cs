using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Interfaces
{
    public interface ICommService
    {
        IList<Comm> GetAllComms();
        Comm GetCommById(int id);
        void SaveComm(Comm comm, string uid);
        void DeleteComm(int id);
    }
}
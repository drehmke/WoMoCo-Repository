using System.Collections.Generic;
using System.Security.Claims;
using WoMoCo.Models;

namespace WoMoCo.Interfaces
{
    public interface ICommService
    {
        IList<Comm> GetAllComms();
        Comm GetCommById(int id);
        void SaveComm(Comm comm, string uid);             
        void DeleteComm(int id);
        int GetCountCurrentUserNewMessages(string uid);
    }
}
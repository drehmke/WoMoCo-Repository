using System.Collections.Generic;
using System.Security.Claims;
using WoMoCo.Models;

namespace WoMoCo.Interfaces

{
    public interface ICommService
    {
        void DeleteComm(int id);
        IList<Comm> GetAllComms();
        Comm GetCommById(int id);
        void SaveComm(Comm comm);
        void sendComm(Comm comm, string senderId);
        //string GetUserId(ClaimsPrincipal user);
    }
}
using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public interface ICommService
    {
        IList<Comm> GetAllComms();
        Comm GetCommById(int id);
        void SaveComm(Comm comm);
        void DeleteComm(int id);
    }
}
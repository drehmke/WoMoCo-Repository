using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public interface IMessageService
    {
        void DeleteMessage(int id);
        IList<Message> GetAllMessages();
        Message GetMessageById(int id);
        void SaveMessage(Message message);
        List<Message> SearchByUserEmail(string searchTerm);
    }
}
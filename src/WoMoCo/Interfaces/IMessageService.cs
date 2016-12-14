using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public interface IMessageService
    {
        void DeleteMessage(int id);
        object getMessageInfo(int id);
        void sendMessage(Message message, string senderId);
        IList<Message> GetAllMessages();
    }
}
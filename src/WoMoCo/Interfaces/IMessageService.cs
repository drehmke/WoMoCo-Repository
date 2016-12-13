using WoMoCo.Models;

namespace WoMoCo.Services
{
    public interface IMessageService
    {
        void DeleteMessage(int id);
        object getMessageInfo(int id);
        object MsgsByUser(string id);
        void sendMessage(Message msg);
    }
}
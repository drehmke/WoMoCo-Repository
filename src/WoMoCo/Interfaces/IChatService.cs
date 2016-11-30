using System.Collections.Generic;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public interface IChatService
    {
        void DeleteChat(int id);
        IList<Chat> GetAllChats();
        Chat GetChatById(int id);
        void SaveChat(Chat chat);
        IList<Chat> SerachByUser(ICollection<ApplicationUser> searchTerm);
    }
}
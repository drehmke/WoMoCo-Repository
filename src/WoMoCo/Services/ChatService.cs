using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public class ChatService : IChatService
    {
        private IGenericRepository _repo;

        public IList<Chat> GetAllChats()
        {
            return _repo.Query<Chat>().ToList();
        }

        public Chat GetChatById(int id)
        {
            return _repo.Query<Chat>().Where(c => c.Id == id).FirstOrDefault();
        }

        public void SaveChat(Chat chat)
        {
            if(chat.Id == 0)
            {
                _repo.Add(chat);
            }
            else
            {
                _repo.Update(chat);
            }
        }

        public void DeleteChat(int id)
        {
            Chat chatToDelete = _repo.Query<Chat>().Where(c => c.Id == id).FirstOrDefault();
            _repo.Delete(chatToDelete);
        }

        public IList<Chat> SerachByUser(ICollection<ApplicationUser> searchTerm)
        {
            var chats = _repo.Query<Chat>();
            return (from c in chats
                    where c.Users == searchTerm
                    select new Chat
                    {
                        Users = c.Users,
                        Message = c.Message,
                    }).ToList();
        }

        public ChatService(IGenericRepository repo)
        {
            this._repo = repo;
        }
    }
}

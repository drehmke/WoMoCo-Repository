using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;

namespace WoMoCo.Services
{
    public class InboxService
    {
        private IGenericRepository _repo;

        // Get all Messages (Called by controller Get())
        public IList<Message> GetAllMessages()
        {
            return _repo.Query<Message>().ToList();
        }

        //Get a Single Message by Id (Called by Get["{id}](message))
        public Message GetMessageById(int id)
        {
            return _repo.Query<Message>().Where(m => m.Id == id).FirstOrDefault();
        }

        //Post a single message to the database and to selected Users
        public void SaveMessage(Message message)
        {
            if (message.Id == 0)
            {
                _repo.Add(message);
            }
            else
            {
                _repo.Update(message);
            }
        }
        //Delete a single message from the user account
        public void DeleteMessage(int id)
        {
            Message messageToDelete = _repo.Query<Message>().Where(m => m.Id == id).FirstOrDefault();
            _repo.Delete(messageToDelete);
        }

        public List<Message> SearchByUserEmail(string searchTerm)
        {
            var messages = _repo.Query<Message>();
            return (from m in messages
                    where m.UserName == searchTerm
                    select new Message
                    {
                        Id = m.Id,
                        UserName = m.UserName,
                    }).ToList();
        }
        public InboxService(IGenericRepository repo)
        {
            _repo = repo;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMoCo.Interfaces;
using WoMoCo.Models;
using WoMoCo.Repositories;

namespace WoMoCo.Services
{
    public class MessageService : IMessageService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;
        public MessageService(IGenericRepository repo, UserManager<ApplicationUser> manager)
        {
            _repo = repo;
            _manager = manager;
        }

        //Get all Messages

        public IList<Message>GetAllMessages()
        {
            return _repo.Query<Message>().ToList();
        }

        //get messages by user
        //public object MsgsByUser(string id)
        //{
        //    var messages = new List<Message>();
        //    var msg2 = _repo.Query<ApplicationUser>().Where(a => a.Id == id).Select(m => new
        //    {
        //        messages = m.Message
        //    }).FirstOrDefault();
        //    var msg = _repo.Query<ApplicationUser>().Where(a => a.Id == id).FirstOrDefault();

        //    var msgList = msg.messages;

        //    foreach (var singleMessage in messages)
        //    {
        //        singleMessage.HasBeenViewed = true;
        //        _repo.Update(singleMessage);

        //    }

        //    var msgList = messages;

        //    _repo.SaveChanges();


        //    //messages = msg.Messages.ToList();
        //    //return msg;
        //    return msg2;

        //}
        //get message info by id
        public object getMessageInfo(int id)
        {
            var _data = _repo.Query<Message>().Where(m => m.Id == id).Select(m => new
            {
                Id = m.Id,
                Subject = m.Subject,
                Message = m.Msg,
                SendingUser = m.SendingUser,
                DateSent = m.DateSent

            }).FirstOrDefault();
            return _data;
        }
        //save Message

        public void sendMessage(Message message, string senderId)
        {
            var receivingUser = _repo.Query<ApplicationUser>().Where(a => a.Id == message.RecId).FirstOrDefault();
            var sendingUser = _repo.Query<ApplicationUser>().Where(s => s.Id == senderId).FirstOrDefault();
            
            message.DateSent = DateTime.Now;
            _repo.Add(message);
            //associate users with message
            message.SendingUser = sendingUser;
            message.ReceivingUser = receivingUser;
            _repo.SaveChanges();



        }


        //delete Message

        public void DeleteMessage(int id)
        {
            var messageToDelete = _repo.Query<Message>().Where(m => m.Id == id).FirstOrDefault();
            _repo.Delete(messageToDelete);

        }

      
    }

}


    
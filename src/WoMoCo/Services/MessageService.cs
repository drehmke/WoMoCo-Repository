using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        //get messages by user
        public object MsgsByUser(string id)
        {
            //var messages = new List<Messages>();
            var msg2 = _repo.Query<ApplicationUser>().Where(a => a.Id == id).Include(m => m.Messages).Select(m => new
            {
                messages = m.Messages
            }).FirstOrDefault();
            var msg = _repo.Query<ApplicationUser>().Where(a => a.Id == id).Include(m => m.Messages).FirstOrDefault();

            var msgList = msg.Messages;

            foreach (var singleMessage in msgList)
            {
                singleMessage.HasBeenViewed = true;
                _repo.Update(singleMessage);

            }

            //var msgList = messages;

            _repo.SaveChanges();


            //messages = msg.Messages.ToList();
            //return msg;
            return msg2;

        }
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

        public void sendMessage(Message msg)
        {
            var appUser = _repo.Query<ApplicationUser>().Where(a => a.Id == msg.RecId).Include(m => m.Messages).FirstOrDefault();
            msg.DateSent = DateTime.Now;
            appUser.Messages.Add(msg);

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


    
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class Inbox
    {
        public int Id { get; set; }
        
        //public ICollection<FriendRequest> FriendRequests { get; set; }


       

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        //public ICollection<Message> Messages { get; set; }
        public ICollection<Comm> Comms { get; set; }

        public string RecId { get; set; }
        public ApplicationUser SendingUser { get; set; }
        public string Subject { get; set; }
        public ApplicationUser ReceivingUser { get; set; }
        public bool HasBeenViewed { get; set; }
        public DateTime DateSent { get; set; }
        public string Msg { get; set; }

    }
}

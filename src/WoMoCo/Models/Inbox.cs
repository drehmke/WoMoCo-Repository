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


        public ApplicationUser User { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}

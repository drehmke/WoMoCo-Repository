using System;   
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class Message
    {
        public int Id { get; set; }
     
        public string RecId { get; set; }
        public ApplicationUser SendingUser { get; set; }
        public string Subject { get; set; }
        public ApplicationUser ReceivingUser { get; set; }
        public bool HasBeenViewed { get; set; }
        public DateTime DateSent { get; set; }
        public string Msg { get; set; }
        
        public string Status { get; set; }
        public Message()
        {
           HasBeenViewed = false;
        }



    }
}

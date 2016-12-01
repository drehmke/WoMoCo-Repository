using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string RecId { get; set; }
        public string SendingUser { get; set; }
        public string Subject { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public bool HasBeenViewed { get; set; }
        public DateTime DateSent { get; set; }     
      
        public string Status { get; set; }
        public Message()
        {
            HasBeenViewed = false;
        }



    }
}

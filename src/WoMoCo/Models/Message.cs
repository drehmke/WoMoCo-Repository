using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string UserComment { get; set; }
        public string UserResponse { get; set; }
        public ApplicationUser ApplicationUsers { get; set; }
        public string CreateDate { get; set; }
        public string SendDate { get; set; }
        public string ResponseDate { get; set; }
        public string Status { get; set; }

    }
}

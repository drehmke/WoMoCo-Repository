using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public string Message { get; set; }
    }
}

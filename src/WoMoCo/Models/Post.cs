using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public ICollection<ApplicationUser> User { get; set; }
        public string UserName { get; set; }

    }
}

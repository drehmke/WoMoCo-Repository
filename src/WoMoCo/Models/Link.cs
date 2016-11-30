using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }  
        public string LinkType { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}

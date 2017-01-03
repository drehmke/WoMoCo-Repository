using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class ActivityForum
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Location { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
    }
}

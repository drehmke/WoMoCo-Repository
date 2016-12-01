using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
        public string BadgeImage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class BabySitterLocation
    {
        public int Id { get; set; }
        public string LinkLocation { get; set; }
        public BabySitterLink BabySitterLink { get; set; }
    }
}

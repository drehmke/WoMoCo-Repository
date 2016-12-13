using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class BabySitterLink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LinkBase { get; set; }
        public string Image { get; set; }
        public IList<BabySitterLocation> LinkLocation { get; set; }
    }
}

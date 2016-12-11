using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.Models
{
    public class SharedCalenderEvent
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public CalenderEvent CalenderEvent { get; set; }
        public int CalenderEventId { get; set; }
    }
}

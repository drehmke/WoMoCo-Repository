using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.ViewModels.Links
{
    public class LinkForAdmin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string LinkType { get; set; }
        public string UserName { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoMoCo.ViewModels.ActivityForum
{
    public class ActivityForumAdminView
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
    }
}

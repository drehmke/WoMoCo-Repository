using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WoMoCo.Models;

namespace WoMoCo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ActivityForum> ActivityForums { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<BabySitterLocation> BabySitterLocations { get; set; }
        public DbSet<BabySitterLink> BabySitterLinks { get; set; }
        public DbSet<EventAlarm> EventAlarms { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Inbox> Inboxes { get; set; }
        public DbSet<Comm> Comms { get; set; }        
        public DbSet<SharedCalendarEvent> SharedCalenderEvents { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SharedCalendarEvent>().HasKey(x => new { x.UserId, x.CalendarEventId });
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

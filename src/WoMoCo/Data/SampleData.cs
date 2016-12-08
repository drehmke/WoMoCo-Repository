using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using WoMoCo.Models;

namespace WoMoCo.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }

            //var babySitterLink1 = new BabySitterLink
            //{
            //    Name = "SitterCity",
            //    LinkBase = "https://www.sittercity.com/babysitters/"
            //};

            //var babySitterLink2 = new BabySitterLink
            //{
            //    Name = "Urbansitter",
            //    LinkBase = "https://www.urbansitter.com/find-babysitters/"
            //};
            //var babySitterLink3 = new BabySitterLink
            //{
            //    Name = "Care",
            //    LinkBase = "https://www.care.com/babysitters/"
            //};
            //var babySitterLink4 = new BabySitterLink
            //{
            //    Name = "Collegenanniesandtutors",
            //    LinkBase = "https://www.collegenanniesandtutors.com/offices/zip/"
            //};
            
            //if(!context.BabySitterLinks.GetBabySitterLinkByName())
            //{
            //    context.BabySitterLinks.Add(babySitterLink1);
            //    context.SaveChanges();
            //}
            
        }

    }
}

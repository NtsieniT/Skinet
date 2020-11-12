using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Ntsieni",
                    Email = "Tshikhakhisan@Gmail.com",
                    UserName = "Tshikhakhisan@Gmail.com",
                    Address = new Address
                    {
                        FirstName = "Ntsieni",
                        LastName = "Tshikhakhisa",
                        Street = "154 Justice Mahomed street",
                        City = "Pretoria",
                        State = "Gauteng",
                        Zipcode = "0002"
                    }
                };

                await userManager.CreateAsync(user, "Password@1");
            }
        }
    }
}

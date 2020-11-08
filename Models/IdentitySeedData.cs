using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class IdentitySeedData
    {
        public static void CreateAdminEntries(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            CreateAdminAccountAndRole(serviceProvider, configuration).Wait();
        }
        /// <summary>
        /// Creates an admin user and role from config file data
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static async Task CreateAdminAccountAndRole(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            serviceProvider = serviceProvider.CreateScope().ServiceProvider;
            UserManager<Customer> userManager = serviceProvider.GetRequiredService<UserManager<Customer>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //Get admin details from config file
            string userName = configuration["SeedIdentity:Admin:UserName"] ?? "tanvir14012@gmail.com";
            string email = configuration["SeedIdentity:Admin:Email"] ?? "tanvir14012@gmail.com";
            string password = configuration["SeedIdentity:Admin:Password"] ?? "TaNvIr14012!@#";
            string adminRole = configuration["SeedIdentity:Admin:Role"] ?? "Admin";

            if(await userManager.FindByNameAsync(userName) == null)
            {
                var user = new Customer
                {
                    UserName = userName,
                    Email = email,
                    EmailConfirmed = true
                };
                var createResult = await userManager.CreateAsync(user, password);
                if(createResult.Succeeded)
                {
                    if(await roleManager.FindByNameAsync(adminRole) == null)
                    {
                        var roleCreateResult = await roleManager.CreateAsync(new IdentityRole(adminRole));
                        if(roleCreateResult.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, adminRole);
                        }
                    }
                }

            }
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RouteDev.Ecommerc.Domain.Contracts.PresistenceRepos;
using RouteDev.Ecommerc.Domain.Entites.IDentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presistance.Identity
{
    public class StorIdetityDbIntializer(StoreIdentityDbContext _context, UserManager<ApplicationUser> _userManager) : IStorIdentityDbInitalizer
    {
        public async Task InitializeAsync()
        {
            var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                await _context.Database.MigrateAsync();

            }

        }

        public async Task SeedDataAsync()
        {
            if (!_userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {

                    DisplayName = "mohamed gamal",
                    Email = "mohamed@gmail.com",
                    PhoneNumber = "12324324324",
                    UserName = "mohamed.gamal",
                };
                await _userManager.CreateAsync(user, "Pa$$w0rd");
            }

        }
    }
}

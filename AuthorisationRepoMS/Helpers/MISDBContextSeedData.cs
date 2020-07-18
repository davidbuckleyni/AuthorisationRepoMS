using AuthorisationRepoMS.Dal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MISSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISSystem.Web.Helpers {
    public class MISDBContextSeedData {
        private ApplicationDBContext _context;

        public MISDBContextSeedData(ApplicationDBContext context) {
            _context = context;
        }

        public async void SeedAdminUser() {
            var user = new ApplicationUser {
                UserName = "davidbuckleyweb@outlook.com",
                NormalizedUserName = "davidbuckleyweb@outlook.com",
                Email = "davidbuckleyweb@outlook.com",
                NormalizedEmail = "davidbuckleyweb@outlook.com",
                FirstName="David",
                LastName="Buckley",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "admin" || r.Name=="manager" || r.Name=="agent")) {
                await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
                await roleStore.CreateAsync(new IdentityRole { Name = "manager", NormalizedName = "manager" });
                await roleStore.CreateAsync(new IdentityRole { Name = "agent", NormalizedName = "agent" });
            }

            if (!_context.Users.Any(u => u.UserName == user.UserName)) {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "Test12345!");
                user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(_context);
                await userStore.CreateAsync(user);
                 userStore.AddToRoleAsync(user, "admin");
            }

            await _context.SaveChangesAsync();
        }

    }
}

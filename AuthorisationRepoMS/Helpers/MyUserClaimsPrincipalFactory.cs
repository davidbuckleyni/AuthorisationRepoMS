using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MISSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MISSystem.Web.Helpers {
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser> {
        public MyUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            IOptions<IdentityOptions> optionsAccessor)
                : base(userManager, optionsAccessor) {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user) {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FullName", user.FirstName + " " + user.LastName ?? "[Click to edit profile]"));
            return identity;
        }
    }
}

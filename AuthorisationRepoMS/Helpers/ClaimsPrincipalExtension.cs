using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MISSystem.Web.Helpers {
    public static class ClaimsPrincipalExtension {
        public static string GetFullName(this ClaimsPrincipal principal) {
            var fullName = principal.Claims.FirstOrDefault(c => c.Type == "FullName");
            return fullName?.Value;
        }
    }
}



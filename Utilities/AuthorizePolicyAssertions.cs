using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Digital_Services_BD.Utilities
{
    public static class AuthorizePolicyAssertions
    {
        public static bool AdminFullAccess (AuthorizationHandlerContext context, IConfiguration configuration)
        {
            var role = configuration["SeedIdentity:Admin:Role"] ?? "Admin";
            return context.User.IsInRole(role);
        }
    }
}

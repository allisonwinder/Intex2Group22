using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Intex2Group22.Core
{
    public static class RoleConstants
    {
        public static class Roles
        {
            public const string Administrator = "Administrator";

            public const string User = "User";
        }

        public static class Policies
        {
            public const string RequireAdmin = "RequireAdmin";
            public const string RequireManager = "RequireManager";
        }
    }
}

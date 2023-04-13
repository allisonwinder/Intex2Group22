using Intex2Group22.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Intex2Group22.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}

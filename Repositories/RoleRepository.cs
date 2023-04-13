using Intex2Group22.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Intex2Group22.Repositories
{

    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
    
}

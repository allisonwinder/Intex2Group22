using Intex2Group22.Areas.Identity.Data;

namespace Intex2Group22.Core.Repositories
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(string id);
        ApplicationUser UpdateUser(ApplicationUser user);

    }
}

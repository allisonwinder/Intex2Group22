using Intex2Group22.Repositories;

namespace Intex2Group22.Core.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }

    }
}

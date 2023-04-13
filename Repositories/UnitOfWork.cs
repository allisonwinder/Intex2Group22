using Intex2Group22.Core.Repositories;

namespace Intex2Group22.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }
        public UnitOfWork(IUserRepository user, IRoleRepository role) 
        {
            User = user;
            Role = role;
        }
    }
}

namespace Intex2Group22.Models
{
    public interface IMummiesRepository
    {
        IQueryable<Burialmain> Burialmains { get; } 
    }
}

namespace Intex2Group22.Models
{
    public class EFMummiesRepository : IMummiesRepository
    {
        private intexmummiesContext context { get; set; }
        public EFMummiesRepository (intexmummiesContext temp)
        {
            context = temp;
        }
        public IQueryable<Burialmain> Burialmains => context.Burialmains;
    }
}

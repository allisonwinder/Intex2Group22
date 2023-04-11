namespace Intex2Group22.Models
{
    public class EFMummiesRepository : IMummiesRepository
    {   
        private mummiesContext context { get; set; }
        public EFMummiesRepository(mummiesContext temp)
        {
            context = temp;
        }
        public IQueryable<Burialmain> Burialmains => context.Burialmains;
   }
}

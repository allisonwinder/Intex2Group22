namespace Intex2Group22.Models.ViewModels
{
    public class FilterViewModel
    {
        public IEnumerable<string> HairColor { get; set; }
        public IEnumerable<string> Sex { get; set; }
        public IEnumerable<string> Depth { get; set; }
        public IEnumerable<string> HeadDirection { get; set; }
        public IEnumerable<string> AgeAtDeath { get; set; }
        public IEnumerable<string> SquareNorthSouth { get; set; }
        public IEnumerable<string> NorthSouth { get; set; }
        public IEnumerable<string> SquareEastWest { get; set; }
        public IEnumerable<string> EastWest { get; set; }
        public IEnumerable<string> Area { get; set; }
        public IEnumerable<string> BurialNumber { get; set; }

        public IEnumerable<string> BurialId { get; set; }

    }
}
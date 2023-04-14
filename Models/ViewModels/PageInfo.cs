namespace Intex2Group22.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumMummies { get; set; }   
        public int MummiesPerPage { get; set; }
        public int CurrentPage { get; set; }

        public string Sex { get; set; }
        public string Haircolor { get; set; }
        public string Depth { get; set; }
        public string HeadDirection { get; set; }
        public string AgeAtDeath { get; set; }
        public string SquareNorthSouth { get; set; }
        public string NorthSouth { get; set; }
        public string SquareEastWest { get; set; }
        public string EastWest { get; set; }
        public string Area { get; set; }
        public string BurialNumber { get; set; }
        public string BurialId { get; set; }

        //figure out how many mummies there are
        public int TotalPages => (int)Math.Ceiling((double)TotalNumMummies / MummiesPerPage);

    }
}

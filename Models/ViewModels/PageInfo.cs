namespace Intex2Group22.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumMummies { get; set; }   
        public int MummiesPerPage { get; set; }
        public int CurrentPage { get; set; }

        //figure out how many mummies there are
        public int TotalPages => (int) Math.Ceiling((double) TotalNumMummies / MummiesPerPage); 

    }
}

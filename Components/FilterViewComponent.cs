using Intex2Group22.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2Group22.Components
{
    public class FilterViewComponent : ViewComponent
    {
        private intexmummiesContext repo { get; set; }
        public FilterViewComponent(intexmummiesContext temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            var hairColors = repo.Burialmains
                .Select(x => x.Haircolor)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            var sexes = repo.Burialmains
                .Select(x => x.Sex)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            var depths = repo.Burialmains
                .Select(x => x.Depth)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            var headDirections = repo.Burialmains
                .Select(x => x.Headdirection)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            var agesAtDeath = repo.Burialmains
                .Select(x => x.Ageatdeath)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            var squaresNorthSouth = repo.Burialmains
                .Select(x => x.Squarenorthsouth)
                .Distinct() 
                .OrderBy (x => x)
                .ToList();
            var northSouth = repo.Burialmains
                .Select(x => x.Northsouth)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            var squaresEeastWest = repo.Burialmains
                .Select(x => x.Squareeastwest)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            var eastWest = repo.Burialmains
                .Select(x => x.Eastwest)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            var areas = repo.Burialmains
                .Select(x => x.Area)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            var burialNumbers = repo.Burialmains
                .Select(x => x.Burialnumber)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            ViewBag.HairColors = hairColors;
            ViewBag.Sexes = sexes;
            ViewBag.Depths = depths;
            ViewBag.HeadDirections = headDirections;
            ViewBag.AgesAtDeath = agesAtDeath;
            ViewBag.SquaresNorthSouth = squaresNorthSouth;
            ViewBag.NorthSouth = northSouth;
            ViewBag.SquaresEastWest = squaresEeastWest;
            ViewBag.EastWest = eastWest;
            ViewBag.Areas = areas;
            ViewBag.BurialNumbers = burialNumbers;


            return View();

        }
    }
}

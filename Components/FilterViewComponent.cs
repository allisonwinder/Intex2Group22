using Intex2Group22.Models;
using Intex2Group22.Models.ViewModels;
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
            var hairColor = repo.Burialmains
                .Where(x => x.Haircolor != null && x.Haircolor != "")
                .Select(x => x.Haircolor)
                .Distinct();
                

            var sex = repo.Burialmains
                .Where(x => x.Sex != null && x.Sex != "")
                .Select(x => x.Sex)
                .Distinct();

            var depth = repo.Burialmains
                .Where(x => x.Depth != null && x.Depth != "")
                .Select(x => x.Depth)
                .Distinct();

            var headDirection = repo.Burialmains
                .Where(x => x.Headdirection != null && x.Headdirection != "")
                .Select(x => x.Headdirection)
                .Distinct();

            var ageAtDeath = repo.Burialmains
                .Where(x => x.Ageatdeath != null && x.Ageatdeath != "")
                .Select(x => x.Ageatdeath)
                .Distinct();

            var squareNorthSouth = repo.Burialmains
                .Where(x => x.Squarenorthsouth != null && x.Squarenorthsouth != "")
                .Select(x => x.Squarenorthsouth)
                .Distinct();

            var northSouth = repo.Burialmains
                .Where(x => x.Northsouth != null && x.Northsouth != "")
                .Select(x => x.Northsouth)
                .Distinct();

            var squareEeastWest = repo.Burialmains
                .Where(x => x.Squareeastwest != null && x.Squareeastwest != "")
                .Select(x => x.Squareeastwest)
                .Distinct();

            var eastWest = repo.Burialmains
                .Where(x => x.Eastwest != null && x.Eastwest != "")
                .Select(x => x.Eastwest)
                .Distinct();

            var area = repo.Burialmains
                .Where(x => x.Area != null && x.Area != "")
                .Select(x => x.Area)
                .Distinct();

            var burialNumber = repo.Burialmains
                .Where(x => x.Burialnumber != null && x.Burialnumber != "")
                .Select(x => x.Burialnumber)
                .Distinct();

            var model = new FilterViewModel
            {
                HairColor = hairColor,
                Sex = sex,
                Depth = depth,
                HeadDirection = headDirection,
                AgeAtDeath = ageAtDeath,
                SquareNorthSouth = squareNorthSouth,
                NorthSouth = northSouth,
                SquareEastWest = squareEeastWest,
                EastWest = eastWest,
                Area = area,
                BurialNumber = burialNumber
            };
            


            return View(model);

        }
    }
}

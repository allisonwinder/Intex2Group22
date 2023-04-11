using Intex2Group22.Models;
using Intex2Group22.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Intex2Group22.Controllers
{
    public class HomeController : Controller
    {
        private IMummiesRepository repo;

        public HomeController (IMummiesRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult allMummies(int pageNum)
        {
            int pageSize = 10;
            var x = new MummiesViewModel
            {
                Burialmains = repo.Burialmains
                    .Skip((pageSize-1 )* pageNum)
                    .Take(pageSize)
                    .ToList();
            }

            return View(blah);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Intex2Group22.Models;
using Intex2Group22.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;

namespace Intex2Group22.Controllers
{
    public class HomeController : Controller
    {
        private IMummiesRepository repo;

        public HomeController(IMummiesRepository temp)
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

        public IActionResult allMummies(int pageNum = 1)
        {
            int pageSize = 10;
            var x = new MummiesViewModel
            {
                Burialmains = repo.Burialmains
                .OrderBy(b => b.Id)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumMummies = repo.Burialmains.Count(),
                    MummiesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
       
            return View(x);
        }
           

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
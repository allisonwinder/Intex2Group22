using Intex2Group22.Models;
using Intex2Group22.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Intex2Group22.Controllers
{
    public class HomeController : Controller
    {
        private intexmummiesContext repo { get; set; }

        public HomeController(intexmummiesContext temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UnsupervisedModel()
        {
            return View();
        }

        public IActionResult SupervisedModel()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddForm()
        {
            //ViewBag.Categories = repo.Categories.ToList()
            ;
            return View();
                }

        [HttpPost]
        public IActionResult AddForm(Burialmain bm)
        {
            if (ModelState.IsValid)
            {
                repo.Add(bm);
                repo.SaveChanges();
                return View("Confirmation", bm);
            }
            else
            {
                //ViewBag.Categories = repo.Categories.ToList();
                return View(bm);
            }
        }

        [HttpGet]
        public IActionResult Edit(int formid)
        {
            //ViewBag.Majors but change = repo.ToList();
            var form = repo.Burialmains.Single(x => x.Id == formid);
            return View("AddForm", form);
        }

        [HttpPost]
        public IActionResult Edit(Burialmain bm)
        {
            repo.Update(bm);
            repo.SaveChanges();
            return RedirectToAction("allMummies");
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
                .Take(pageSize).ToList(),

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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ids = repo.Burialmains.Single(x => x.Id == id);
            return View(ids);
        }

        [HttpPost]
        public IActionResult Delete(Burialmain bm)
        {
            
            repo.Burialmains.Remove(bm);
            repo.SaveChanges();

            return RedirectToAction("allMummies");
        }

    }

}
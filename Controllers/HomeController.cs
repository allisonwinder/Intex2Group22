﻿using Intex2Group22.Models;
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
        public IActionResult Edit(long formid)
        {
            //ViewBag.Majors but change = repo.ToList();
            var form = repo.Burialmains.Single(x => x.Id == formid);
            return View("EditForm", form);
        }

        [HttpPost]
        public IActionResult Edit(Burialmain bm)
        {
            repo.Burialmains.Update(bm);
            repo.SaveChanges();

            return RedirectToAction("allMummies");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult allMummies(string haircolor, string sex, string depth, int pageNum = 1)
        {
            int pageSize = 10;
            var x = new MummiesViewModel
            {
                Burialmains = repo.Burialmains
                    .Where(b => (b.Haircolor == haircolor || string.IsNullOrEmpty(haircolor)) && (b.Sex == sex || string.IsNullOrEmpty(sex)) && (b.Depth == depth || string.IsNullOrEmpty(depth)))
                    .OrderBy(b => b.Id)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),
                PageInfo = new PageInfo
                {
                    TotalNumMummies = repo.Burialmains.Count(),
                    MummiesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            ViewBag.SelectedHairColor = haircolor;
            ViewBag.SelectedSex = sex;
            return View(x);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Delete(long formid)
        {
            var forms = repo.Burialmains.Single(x => x.Id == formid);
            return View("Delete", forms);
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
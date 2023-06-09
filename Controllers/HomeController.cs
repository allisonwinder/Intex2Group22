﻿using Intex2Group22.Models;
using Intex2Group22.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;


using Microsoft.EntityFrameworkCore;
using Intex2Group22.Core;
using Microsoft.Data.SqlClient.Server;

namespace Intex2Group22.Controllers
{
    public class HomeController : Controller
    {
        private intexmummiesContext repo { get; set; }

        public HomeController(intexmummiesContext temp)
        {
            repo = temp;
        }
        int visits = 0;
        public IActionResult Index()
        {
            //// update the visits counter
            //var visitString = Request.Cookies["visits"];
            
            //int.TryParse(visitString, out visits);
            //visits++;

            //Response.Cookies.Append("visits", visits.ToString());

            //ViewBag.visits = visits;

            ////CookieOptions options = new CookieOptions();
            ////options.Expires = DateTime.Now.AddDays(365);
            ////Respo
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
        [Authorize(Roles = RoleConstants.Roles.Administrator)]
        public IActionResult AddForm()
        {
            return View();
                }

        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.Roles.Administrator}")]

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
        [Authorize(Roles = $"{RoleConstants.Roles.Administrator}")]
        public IActionResult Edit(long formid)
        {
            var form = repo.Burialmains.Single(x => x.Id == formid);
            return View("EditForm", form);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.Roles.Administrator}")] //limit certain actions to the Administrators
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

        [HttpGet]
        public IActionResult allMummies(int pageNum = 1)
        {
            int pageSize = 50;
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

        [HttpPost]
        public IActionResult allMummies(string HairColor, string BurialId, string Sex, string Depth, string HeadDirection, string AgeAtDeath, string SquareNorthSouth, string NorthSouth, string SquareEastWest, string EastWest, string Area, string BurialNumber, int pageNum = 1)
        {
            int pageSize = 50;
            var x = new MummiesViewModel
            {
                Burialmains = repo.Burialmains
                    .Where(b => (Sex == null || b.Sex == Sex) && (HairColor == null || b.Haircolor == HairColor) &&
                                (Depth == null || b.Depth == Depth) &&
                                (HeadDirection == null || b.Headdirection == HeadDirection) &&
                                (AgeAtDeath == null || b.Ageatdeath == AgeAtDeath) &&
                                (SquareNorthSouth == null || b.Squarenorthsouth == SquareNorthSouth) &&
                                (NorthSouth == null || b.Northsouth == NorthSouth) &&
                                (SquareEastWest == null || b.Squareeastwest == SquareEastWest) &&
                                (EastWest == null || b.Eastwest == EastWest) &&
                                (Area == null || b.Area == Area) &&
                                (BurialNumber == null || b.Burialnumber == BurialNumber) &&
                                (BurialId == null || b.Burialid == BurialId))
                    .OrderBy(b => b.Id)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumMummies = repo.Burialmains.Count(b => (Sex == null || b.Sex == Sex) && (HairColor == null || b.Haircolor == HairColor) &&
                                                              (Depth == null || b.Depth == Depth) &&
                                                              (HeadDirection == null || b.Headdirection == HeadDirection) &&
                                                              (AgeAtDeath == null || b.Ageatdeath == AgeAtDeath) &&
                                                              (SquareNorthSouth == null || b.Squarenorthsouth == SquareNorthSouth) &&
                                                              (NorthSouth == null || b.Northsouth == NorthSouth) &&
                                                              (SquareEastWest == null || b.Squareeastwest == SquareEastWest) &&
                                                              (EastWest == null || b.Eastwest == EastWest) &&
                                                              (Area == null || b.Area == Area) &&
                                                              (BurialNumber == null || b.Burialnumber == BurialNumber) &&
                                                              (BurialId == null || b.Burialid == BurialId)),
                    MummiesPerPage = pageSize,
                    CurrentPage = pageNum,
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
        [Authorize(Roles = $"{RoleConstants.Roles.Administrator}")]
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


        
        public IActionResult Details(long formid)
        {

            Burialmain burial = (from b in repo.Burialmains
                                 where b.Id == formid
                                 select b).SingleOrDefault() ?? new Burialmain();


            List<Color> colors = (from c in repo.Colors
                                  join ct in repo.ColorTextiles on c.Id equals ct.MainColorid
                                  join t in repo.Textiles on ct.MainTextileid equals t.Id
                                  join bt in repo.BurialmainTextiles on t.Id equals bt.MainTextileid into bt_temp
                                  from bt in bt_temp.DefaultIfEmpty()
                                  join b in repo.Burialmains on bt.MainBurialmainid equals b.Id into b_temp
                                  from b in b_temp.DefaultIfEmpty()
                                  where b.Id == formid
                                  select c ?? new Color()).Distinct().ToList();


            List<Textile> textiles = (from bt in repo.BurialmainTextiles
                                      join t_join in repo.Textiles on bt.MainTextileid equals t_join.Id into t_temp
                                      from t in t_temp.DefaultIfEmpty()
                                      where bt.MainBurialmainid == formid
                                      select t ?? new Textile()).ToList();


            List<ColorTextile> coltexts = (from ct in repo.ColorTextiles
                                           join t in repo.Textiles on ct.MainTextileid equals t.Id
                                           join bt in repo.BurialmainTextiles on t.Id equals bt.MainTextileid into bt_temp
                                           from bt in bt_temp.DefaultIfEmpty()
                                           join b in repo.Burialmains on bt.MainBurialmainid equals b.Id into b_temp
                                           from b in b_temp.DefaultIfEmpty()
                                           where b.Id == formid
                                           select ct ?? new ColorTextile()).Distinct().ToList();

            List<TextilefunctionTextile> functstexts = (from tft in repo.TextilefunctionTextiles
                                                        join t in repo.Textiles on tft.MainTextileid equals t.Id
                                                        join bt in repo.BurialmainTextiles on t.Id equals bt.MainTextileid into bt_temp
                                                        from bt in bt_temp.DefaultIfEmpty()
                                                        join b in repo.Burialmains on bt.MainBurialmainid equals b.Id into b_temp
                                                        from b in b_temp.DefaultIfEmpty()
                                                        where b.Id == formid
                                                        select tft ?? new TextilefunctionTextile()).Distinct().ToList();

            List<Textilefunction> textilefunctions = (from tf in repo.Textilefunctions
                                                      join tft in repo.TextilefunctionTextiles on tf.Id equals tft.MainTextilefunctionid
                                                      join t in repo.Textiles on tft.MainTextileid equals t.Id
                                                      join bt in repo.BurialmainTextiles on t.Id equals bt.MainTextileid into bt_temp
                                                      from bt in bt_temp.DefaultIfEmpty()
                                                      join b in repo.Burialmains on bt.MainBurialmainid equals b.Id into b_temp
                                                      from b in b_temp.DefaultIfEmpty()
                                                      where b.Id == formid
                                                      select tf ?? new Textilefunction()).Distinct().ToList();
            List<Structure> structures = (from s in repo.Structures
                                          join st in repo.StructureTextiles on s.Id equals st.MainStructureid
                                          join t in repo.Textiles on st.MainTextileid equals t.Id
                                          join bt in repo.BurialmainTextiles on t.Id equals bt.MainTextileid into bt_temp
                                          from bt in bt_temp.DefaultIfEmpty()
                                          join b in repo.Burialmains on bt.MainBurialmainid equals b.Id into b_temp
                                          from b in b_temp.DefaultIfEmpty()
                                          where b.Id == formid
                                          select s ?? new Structure()).Distinct().ToList();

            List<StructureTextile> structexts = (from st in repo.StructureTextiles
                                                 join t in repo.Textiles on st.MainTextileid equals t.Id
                                                 join bt in repo.BurialmainTextiles on t.Id equals bt.MainTextileid into bt_temp
                                                 from bt in bt_temp.DefaultIfEmpty()
                                                 join b in repo.Burialmains on bt.MainBurialmainid equals b.Id into b_temp
                                                 from b in b_temp.DefaultIfEmpty()
                                                 where b.Id == formid
                                                 select st ?? new StructureTextile()).Distinct().ToList();

            List<Bodyanalysischart> charts = (from bac in repo.Bodyanalysischarts
                                              join b in repo.Burialmains on bac.Burialid equals b.Burialid into b_temp
                                              from b in b_temp.DefaultIfEmpty()
                                              where b.Id == formid
                                              select bac ?? new Bodyanalysischart()).Distinct().ToList();

            DetailsViewModel data = new DetailsViewModel(burial, textiles, colors, coltexts,
                structexts, structures, functstexts, textilefunctions, charts);

            return View(data);
        }

        [HttpGet]
        public IActionResult EditColor(long colorid)
        {
            ViewBag.Colors = repo.Colors;
            var form = repo.Colors.Single(x => x.Id == colorid);
            return View("EditColor", form);
        }


        [HttpPost]

        public IActionResult EditColor(Color c)
        {

            repo.Colors.Update(c);
            repo.SaveChanges();

            return RedirectToAction("allMummies");
        }

        [HttpGet]
        public IActionResult EditTextile (long textileid)
        {
            var form = repo.Textiles.Single(x => x.Id == textileid);
            return View("EditTextile", form);
        }


        [HttpPost]

        public IActionResult EditTextile(Textile t)
        {

            repo.Textiles.Update(t);
            repo.SaveChanges();

            return RedirectToAction("allMummies");

        }

        [HttpGet]
        public IActionResult EditStructure(long structureid)
        {
            var form = repo.Structures.Single(x => x.Id == structureid);
            return View("EditStructure", form);
        }


        [HttpPost]

        public IActionResult EditStructure(Structure s)
        {

            repo.Structures.Update(s);
            repo.SaveChanges();

            return RedirectToAction("allMummies");

        }

        [HttpGet]
        public IActionResult EditFunction(long functionid)
        {
            var form = repo.Textilefunctions.Single(x => x.Id == functionid);
            return View("EditFunction", form);
        }


        [HttpPost]

        public IActionResult EditFunction(Textilefunction tf)
        {

            repo.Textilefunctions.Update(tf);
            repo.SaveChanges();

            return RedirectToAction("allMummies");

        }

        [HttpGet]
        public IActionResult EditBodyChart(string chartid)
        {
            var form = repo.Bodyanalysischarts.Single(x => x.Burialid == chartid);
            return View("EditBodyChart", form);
        }


        [HttpPost]

        public IActionResult EditBodyChart(Bodyanalysischart bac)
        {

            repo.Bodyanalysischarts.Update(bac);
            repo.SaveChanges();

            return RedirectToAction("allMummies");

        }

        //[HttpGet]
        //public IActionResult AddTextile(long mummyid)
        //{
        //    var burial = repo.Burialmains.Single(x => x.Id == mummyid);
        //    if (burial == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = new AddTextileViewModel
        //    {
        //        Id = mummyid,
        //        Textile = new Textile()
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult AddTextile(AddTextileViewModel model)
        //{
        //    var burial = repo.Burialmains.Find(model.Id);
        //    if (burial == null)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var textile = new Textile
        //        {
        //            Description = model.Textile.Description,
        //            Locale = model.Textile.Locale,
        //            Direction = model.Textile.Direction,
        //            Sampledate = model.Textile.Sampledate,
        //            Estimatedperiod = model.Textile.Estimatedperiod
        //        };
        //        repo.Textiles.Add(textile);

        //        var burialTextile = new BurialmainTextile
        //        {
        //            MainBurialmainid = model.Id,
        //            MainTextileid = textile.Id
        //        };
        //        repo.BurialmainTextiles.Add(burialTextile);

        //        repo.SaveChanges();

        //        return RedirectToAction("Details", model.Id);
        //    }

        //    return View(model);
        //}






    }

}

// 19140298416325769
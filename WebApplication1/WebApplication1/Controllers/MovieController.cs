using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        MovieDBContext mc = new MovieDBContext();
         
        public ActionResult Index()
        {
            return View(mc.movies.ToList());
        }

        public ActionResult Searching(string search)
        {
           
            var result = mc.movies.Where(x => x.RDate.Year.ToString().Contains(search) || search == null).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movies movie)
        {
            mc.movies.Add(movie);
            mc.SaveChanges();
            return RedirectToAction("Index");
            TempData["Message"] = "Record Created Successfully...";
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Movies movies = mc.movies.Find(id);
            return View(movies);    
        }

        [HttpPost]
        public ActionResult Edit(Movies movie)
        {
            Movies movies = mc.movies.Find(movie.id);
            movies.Name = movie.Name;
            movies.RDate = movie.RDate;
            mc.SaveChanges();
            TempData["Message"] = "Record Updated Successfully...";
            return RedirectToAction("Index");
            
        }

        public ActionResult Delete(int id)
        {
            Movies movies = mc.movies.Find(id);
            mc.movies.Remove(movies);
            mc.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
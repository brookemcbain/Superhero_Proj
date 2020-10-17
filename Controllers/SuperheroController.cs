using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Superhero.Data;
using Superhero.Models; 

namespace Superhero.Controllers
{
    public class SuperheroController : Controller
    {
        // GET: SuperheroController
        private ApplicationDbContext _db;
        
        public SuperheroController( ApplicationDbContext db)
        {
            _db = db; 
        }
        public ActionResult Index()
        {
            
            var superheroes = _db.Superheroes.ToList();
            return View(superheroes); 
        }

        // GET: SuperheroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SuperheroController/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: SuperheroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superhero)
        {
            try
            {
    
                _db.Superheroes.Add(superhero);
                _db.SaveChanges(); 

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Edit/5
        public ActionResult Edit(int id)
        {
            SuperHero editSuperHero = _db.Superheroes.Find(id);
            return View(editSuperHero);
            
        }

        // POST: SuperheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuperHero superhero)
        {
            try
            {
                _db.Superheroes.Update(superhero);
                _db.SaveChanges(); 

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Delete/5
        public ActionResult Delete(int id)
        {
            SuperHero deleteSuperhero = _db.Superheroes.Find(id);
            return View(deleteSuperhero);

        }

        // POST: SuperheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSuperhero(int id)
        {
            try
            {
                SuperHero deleteSuperhero = _db.Superheroes.Find(id);
                _db.Superheroes.Remove(deleteSuperhero);
                _db.SaveChanges(); 

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

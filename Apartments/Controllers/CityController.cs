using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace Apartments.Controllers
{
    public class CityController : Controller
    {
        private readonly ModelContainer db = new ModelContainer();


        ~CityController()
        {
            db.Dispose();
        }


        private SelectList GetCountries()
        {
            var countreis = db.Countries.ToList();
            return new SelectList(countreis, "IDCountry", "Name");
        }
        // GET: City
        public ActionResult Index()
        {
            var cities = db.Cities.Include(c => c.Country).ToList();
            return View(cities);
        }

      

        // GET: City/Create
        public ActionResult Create()
        {
            ViewBag.CountryList = GetCountries();
            return View();
        }

        // GET: City/Details/5
        public ActionResult Details(int? id)
        {
            return CommandAction(id);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int? id)
        {
            return CommandAction(id);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int? id)
        {
            return CommandAction(id);
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(City City)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(City);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }



        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(int id)
        {
            var city = db.Cities.Find(id);
            if (TryUpdateModel(city, "", new string[]
            {
                nameof(City.Name),
                nameof(City.CountryIDCountry),
            }))
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }



        // POST: City/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            db.Cities.Remove(db.Cities.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        private ActionResult CommandAction(int? id)
        {
            ViewBag.CountryList = GetCountries();

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var city = db.Cities
                .SingleOrDefault(a => a.IDCity == id);

            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }
    }
}

using System.Web.Mvc;
using System.Data.Entity;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;

namespace Apartments.Controllers
{
    public class ApartmentController : Controller
    {
        // GET: Apartment

        private readonly ModelContainer db = new ModelContainer();

        ~ApartmentController()
        {
            db.Dispose();
        }
        public ActionResult Index()
        {
            return View(db.Apartments);
        }

        // GET: Apartment/Details/5
        public ActionResult Details(int? id)
        {
            return CommandAction(id);
        }

        private ActionResult CommandAction(int? id)
        {
            if (id==null)
            {

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var apartman = db.Apartments
                .Include(a=>a.UploadedFiles)
                .SingleOrDefault(a=> a.IDApartment== id);

            if (apartman==null)
            {
                return HttpNotFound();
            }

            return View(apartman);
        }

        // GET: Apartment/Create
       


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                apartment.UploadedFiles = new List<UploadedFile>();
                db.Apartments.Add(apartment);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Apartment/Edit/5
        public ActionResult Edit(int? id)
        {
            return CommandAction(id);

        }

        // POST: Apartment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id)
        {
            var apartment = db.Apartments.Find(id); 
            if (TryUpdateModel(apartment,"",new string[]
            {
                nameof(Apartment.Address),
            }))
            {
                db.Entry(apartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(apartment);
        }

        // GET: Apartment/Delete/5
        public ActionResult Delete(int? id)
        {
            return CommandAction(id);

        }

        // POST: Apartment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            db.UploadedFiles.RemoveRange(db.UploadedFiles.Where(f=>f.ApartmentIDApartment==id));
            db.Apartments.Remove(db.Apartments.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

using System.Web.Mvc;
using System.Data.Entity;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Diagnostics;

namespace Apartments.Controllers
{
    public class ApartmentController : Controller
    {
        // GET: Apartment

        private readonly ModelContainer db = new ModelContainer();

        private SelectList GetCities()
        {
            var cities = db.Cities.ToList();
            return new SelectList(cities, "IDCity", "Name");
        }
        private SelectList GetUsers()
        {
            var users = db.Users.ToList();
            return new SelectList(users, "IDUser", "FullName");
        }

        ~ApartmentController()
        {
            db.Dispose();
        }
        public ActionResult Index()
        {
            var app = db.Apartments.Include(c => c.City).Include(c => c.User).ToList();
            return View(app);

        }


        // GET: Apartment/Create

        public ActionResult Create()
        {
            ViewBag.CitiesList = GetCities();
            ViewBag.UsersList = GetUsers();
            return View();
        }

        // GET: Apartment/Details/5
        public ActionResult Details(int? id)
        {
            return CommandAction(id);
        }

        // GET: Apartment/Delete/5
        public ActionResult Delete(int? id)
        {
            return CommandAction(id);

        }





        [HttpPost]
        public ActionResult Create(Apartment apartment, IEnumerable<HttpPostedFileBase> files)
        {

            Debug.WriteLine(files);
            if (ModelState.IsValid)
            {
                apartment.UploadedFiles = new List<UploadedFile>();
                AddFiles(apartment, files);
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
        public ActionResult Edit(int id, IEnumerable<HttpPostedFileBase> files)
        {
            var apartment = db.Apartments.Find(id);
            if (TryUpdateModel(apartment, "", new string[]
            {
                nameof(Apartment.Address),
                nameof(Apartment.UserIDUser),
                nameof(Apartment.CityIDCity),

            }))
            {
                AddFiles(apartment, files);

                db.Entry(apartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(apartment);
        }


        // POST: Apartment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            db.UploadedFiles.RemoveRange(db.UploadedFiles.Where(f => f.ApartmentIDApartment == id));
            db.Apartments.Remove(db.Apartments.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private ActionResult CommandAction(int? id)
        {

            ViewBag.CitiesList = GetCities();
            ViewBag.UsersList = GetUsers();

            if (id == null)
            {

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var apartman = db.Apartments
                .Include(a => a.UploadedFiles)
                .SingleOrDefault(a => a.IDApartment == id);

            if (apartman == null)
            {
                return HttpNotFound();
            }

            return View(apartman);
        }



        private static void AddFiles(Apartment apartment, IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {   
                    var picture = new UploadedFile
                    {
                        Name = file.FileName,
                        ContentType = file.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(file.InputStream))
                    {
                        picture.Content = reader.ReadBytes(file.ContentLength);
                    }
                    apartment.UploadedFiles.Add(picture);
                }
            }
        }
    }
}

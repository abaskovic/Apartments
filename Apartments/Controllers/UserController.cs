﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apartments.Controllers
{
    public class UserController : Controller
    {
        private readonly ModelContainer db = new ModelContainer();

        ~UserController()
        {
            db.Dispose();
        }
        // GET: User
        public ActionResult Index()
        {
            return View(db.Users);
        }


        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            return CommandAction(id);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            return CommandAction(id);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            return CommandAction(id);
        }


        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User  user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id)
        {
            var user = db.Users.Find(id);
            if (TryUpdateModel(user, "", new string[]
            {
            }))
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
            

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            db.Apartments.RemoveRange(db.Apartments.Where(f => f.UserIDUser == id));
            db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private ActionResult CommandAction(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var user = db.Users
                .SingleOrDefault(a => a.IDUser == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PersonsController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Persons
        public ActionResult Index()
        {
            var persons = from p in db.PersonAccounts.OrderBy(p => p.surname) select p;
            return View(persons.ToList());
        }

        // GET: Persons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonAccount personAccount = db.PersonAccounts.Find(id);
            if (personAccount == null)
            {
                return HttpNotFound();
            }
            return View(personAccount);
        }

        // GET: Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_number,account_number,surname,name")] PersonAccount personAccount)
        {
            if (ModelState.IsValid)
            {
                db.PersonAccounts.Add(personAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personAccount);
        }

        // GET: Persons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonAccount personAccount = db.PersonAccounts.Find(id);
            if (personAccount == null)
            {
                return HttpNotFound();
            }
            return View(personAccount);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_number,account_number,surname,name")] PersonAccount personAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personAccount);
        }

        // GET: Persons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonAccount personAccount = db.PersonAccounts.Find(id);
            if (personAccount == null)
            {
                return HttpNotFound();
            }
            return View(personAccount);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PersonAccount personAccount = db.PersonAccounts.Find(id);
            db.PersonAccounts.Remove(personAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

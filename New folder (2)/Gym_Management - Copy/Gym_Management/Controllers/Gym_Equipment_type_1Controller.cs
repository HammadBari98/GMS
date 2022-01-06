using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gym_Management.Models;

namespace Gym_Management.Controllers
{
    public class Gym_Equipment_type_1Controller : Controller
    {
        private Gym_Management_SystemEntities11 db = new Gym_Management_SystemEntities11();

        // GET: Gym_Equipment_type_1
        public ActionResult Gym_Equipment_typeIndex()
        {
            return View(db.Gym_Equipment_type_1.ToList());
        }

        // GET: Gym_Equipment_type_1/Details/5
        public ActionResult Gym_Equipment_typeDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym_Equipment_type_1 gym_Equipment_type_1 = db.Gym_Equipment_type_1.Find(id);
            if (gym_Equipment_type_1 == null)
            {
                return HttpNotFound();
            }
            return View(gym_Equipment_type_1);
        }

        // GET: Gym_Equipment_type_1/Create
        public ActionResult Gym_Equipment_typeCreate()
        {
            return View();
        }

        // POST: Gym_Equipment_type_1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Gym_Equipment_typeCreate([Bind(Include = "Et_id,Eq_type")] Gym_Equipment_type_1 gym_Equipment_type_1)
        {
            if (ModelState.IsValid)
            {
                db.Gym_Equipment_type_1.Add(gym_Equipment_type_1);
                db.SaveChanges();
                return RedirectToAction("Gym_Equipment_typeIndex");
            }

            return View(gym_Equipment_type_1);
        }

        // GET: Gym_Equipment_type_1/Edit/5
        public ActionResult Gym_Equipment_typeEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym_Equipment_type_1 gym_Equipment_type_1 = db.Gym_Equipment_type_1.Find(id);
            if (gym_Equipment_type_1 == null)
            {
                return HttpNotFound();
            }
            return View(gym_Equipment_type_1);
        }

        // POST: Gym_Equipment_type_1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Gym_Equipment_typeEdit([Bind(Include = "Et_id,Eq_type")] Gym_Equipment_type_1 gym_Equipment_type_1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gym_Equipment_type_1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Gym_Equipment_typeIndex");
            }
            return View(gym_Equipment_type_1);
        }

        // GET: Gym_Equipment_type_1/Delete/5
        public ActionResult Gym_Equipment_typeDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym_Equipment_type_1 gym_Equipment_type_1 = db.Gym_Equipment_type_1.Find(id);
            if (gym_Equipment_type_1 == null)
            {
                return HttpNotFound();
            }
            return View(gym_Equipment_type_1);
        }

        // POST: Gym_Equipment_type_1/Delete/5
        [HttpPost, ActionName("Gym_Equipment_typeDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult Gym_Equipment_typeDeleteConfirmed(int id)
        {
            Gym_Equipment_type_1 gym_Equipment_type_1 = db.Gym_Equipment_type_1.Find(id);
            db.Gym_Equipment_type_1.Remove(gym_Equipment_type_1);
            db.SaveChanges();
            return RedirectToAction("Gym_Equipment_typeIndex");
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

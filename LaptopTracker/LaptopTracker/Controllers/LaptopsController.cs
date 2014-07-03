using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaptopTracker.Models;

namespace LaptopTracker.Controllers
{
    public class LaptopsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Laptops
        public ActionResult Index()
        {
            var laptops = db.Laptops.Include(l => l.Owner);
            return View(laptops.ToList());
        }

        // GET: Laptops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // GET: Laptops/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LaptopId,Lid,Name,Type,Description,EmployeeId")] Laptop laptop)
        {
            if (laptop != null)
            {
                if (ModelState.IsValid)
                {
                    db.Laptops.Add(laptop);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", laptop.EmployeeId);
                return View(laptop); 
            }
            return View();
        }

        // GET: Laptops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", laptop.EmployeeId);
            return View(laptop);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LaptopId,Lid,Name,Type,Description,EmployeeId")] Laptop laptop)
        {
            if (laptop != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(laptop).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", laptop.EmployeeId);
                return View(laptop); 
            }
            return View();
        }

        // GET: Laptops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laptop laptop = db.Laptops.Find(id);
            db.Laptops.Remove(laptop);
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

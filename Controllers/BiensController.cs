using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcExampleM1GlGroupe2.Models;
using PagedList;

namespace MvcExampleM1GlGroupe2.Controllers
{
    public class BiensController : Controller
    {
        private BdtripAdvisorContext db = new BdtripAdvisorContext();
        const int pagesize = 2;

        // GET: Biens
        public ActionResult Index(string Designation, string region, int? page)
        {
            ViewBag.Designation = Designation !=null ? Designation : string.Empty;
            ViewBag.Region = region != null ? region : string.Empty;

            page = page ?? 1;
            var liste = db.biens.ToList();
            if (!string.IsNullOrEmpty(Designation))
            {
                liste = liste.Where(a => a.LibelleBien.ToLower().Contains(Designation.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(region))
            {
                liste = liste.Where(a => a.RegionBien.ToLower().Contains(region.ToLower())).ToList();
            }
            int pageNumber = (int)page;
            return View(liste.ToPagedList(pageNumber,pagesize));
        }

        // GET: Biens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bien bien = db.biens.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // GET: Biens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Biens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBien,LibelleBien,DescriptionBien,Prix_Journalier,RegionBien,Pays,Latitude,Longitude,NbreChambre,NbreLit,NbreSalleEaux,TypeBien")] Bien bien)
        {
            if (ModelState.IsValid)
            {
                db.biens.Add(bien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bien);
        }

        // GET: Biens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bien bien = db.biens.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // POST: Biens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBien,LibelleBien,DescriptionBien,Prix_Journalier,RegionBien,Pays,Latitude,Longitude,NbreChambre,NbreLit,NbreSalleEaux,TypeBien")] Bien bien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bien);
        }

        // GET: Biens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bien bien = db.biens.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // POST: Biens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bien bien = db.biens.Find(id);
            db.biens.Remove(bien);
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

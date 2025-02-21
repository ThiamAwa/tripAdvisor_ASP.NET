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
    public class AnnoncesController : Controller
    {
        private BdtripAdvisorContext db = new BdtripAdvisorContext();

        // GET: Annonces
        public ActionResult Index(DateTime? dateDebut, DateTime? dateFin, int? page)
        {
            ViewBag.DateDebut = dateDebut.HasValue ? dateDebut.Value.ToString("yyyy-MM-dd") : string.Empty;
            ViewBag.DateFin = dateFin.HasValue ? dateFin.Value.ToString("yyyy-MM-dd") : string.Empty;

            page = page ?? 1;
            var annonces = db.annonces.Include(a => a.Bien).ToList();

            if (dateDebut.HasValue)
            {
                annonces = annonces.Where(a => a.DateDebut >= dateDebut.Value).ToList();
            }
            if (dateFin.HasValue)
            {
                annonces = annonces.Where(a => a.DateFin <= dateFin.Value).ToList();
            }

            int pageNumber = (int)page;
            int pageSize = 10; // Taille de la pagination
            return View(annonces.ToPagedList(pageNumber, pageSize));
        }


        // GET: Annonces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annonce annonce = db.annonces.Find(id);
            if (annonce == null)
            {
                return HttpNotFound();
            }
            return View(annonce);
        }

        // GET: Annonces/Create
        public ActionResult Create()
        {
            ViewBag.IdBien = new SelectList(db.biens, "IdBien", "LibelleBien");
            return View();
        }

        // POST: Annonces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAnnonce,DateDebut,DateFin,Statut_Annonce,IdBien")] Annonce annonce)
        {
            if (ModelState.IsValid)
            {
                db.annonces.Add(annonce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBien = new SelectList(db.biens, "IdBien", "LibelleBien", annonce.IdBien);
            return View(annonce);
        }

        // GET: Annonces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annonce annonce = db.annonces.Find(id);
            if (annonce == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBien = new SelectList(db.biens, "IdBien", "LibelleBien", annonce.IdBien);
            return View(annonce);
        }

        // POST: Annonces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAnnonce,DateDebut,DateFin,Statut_Annonce,IdBien")] Annonce annonce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(annonce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBien = new SelectList(db.biens, "IdBien", "LibelleBien", annonce.IdBien);
            return View(annonce);
        }

        // GET: Annonces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annonce annonce = db.annonces.Find(id);
            if (annonce == null)
            {
                return HttpNotFound();
            }
            return View(annonce);
        }

        // POST: Annonces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Annonce annonce = db.annonces.Find(id);
            db.annonces.Remove(annonce);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RRHH.Models;

namespace RRHH.Controllers
{
    public class CapacitacionsController : Controller
    {
        private RecursosHumanosEntities db = new RecursosHumanosEntities();

        // GET: Capacitacions
        public ActionResult Index()
        {
            var capacitacions = db.Capacitacions.Include(c => c.Idioma);
            return View(capacitacions.ToList());
        }

        // GET: Capacitacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capacitacion capacitacion = db.Capacitacions.Find(id);
            if (capacitacion == null)
            {
                return HttpNotFound();
            }
            return View(capacitacion);
        }

        // GET: Capacitacions/Create
        public ActionResult Create()
        {
            ViewBag.IdIdioma = new SelectList(db.Idiomas, "IdIdioma", "Nombre");
            return View();
        }

        // POST: Capacitacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCapacitacion,Descripcion,Nivel,FechaDesde,FechaHasta,Institucion,IdIdioma")] Capacitacion capacitacion)
        {
            if (ModelState.IsValid)
            {
                db.Capacitacions.Add(capacitacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdIdioma = new SelectList(db.Idiomas, "IdIdioma", "Nombre", capacitacion.IdIdioma);
            return View(capacitacion);
        }

        // GET: Capacitacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capacitacion capacitacion = db.Capacitacions.Find(id);
            if (capacitacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdIdioma = new SelectList(db.Idiomas, "IdIdioma", "Nombre", capacitacion.IdIdioma);
            return View(capacitacion);
        }

        // POST: Capacitacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCapacitacion,Descripcion,Nivel,FechaDesde,FechaHasta,Institucion,IdIdioma")] Capacitacion capacitacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capacitacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdIdioma = new SelectList(db.Idiomas, "IdIdioma", "Nombre", capacitacion.IdIdioma);
            return View(capacitacion);
        }

        // GET: Capacitacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capacitacion capacitacion = db.Capacitacions.Find(id);
            if (capacitacion == null)
            {
                return HttpNotFound();
            }
            return View(capacitacion);
        }

        // POST: Capacitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Capacitacion capacitacion = db.Capacitacions.Find(id);
            db.Capacitacions.Remove(capacitacion);
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

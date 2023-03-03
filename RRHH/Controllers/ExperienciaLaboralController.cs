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
    public class ExperienciaLaboralController : Controller
    {
        private RecursosHumanosEntities db = new RecursosHumanosEntities();

        // GET: ExperienciaLaboral
        public ActionResult Index()
        {
            var experienciaLaborals = db.ExperienciaLaborals.Include(e => e.Puesto);
            return View(experienciaLaborals.ToList());
        }

        // GET: ExperienciaLaboral/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExperienciaLaboral experienciaLaboral = db.ExperienciaLaborals.Find(id);
            if (experienciaLaboral == null)
            {
                return HttpNotFound();
            }
            return View(experienciaLaboral);
        }

        // GET: ExperienciaLaboral/Create
        public ActionResult Create()
        {
            ViewBag.IdPuesto = new SelectList(db.Puestoes, "IdPuesto", "Nombre");
            return View();
        }

        // POST: ExperienciaLaboral/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdExperienciaLaboral,Empresa,IdPuesto,FechaDesde,FechaHasta,Salario")] ExperienciaLaboral experienciaLaboral)
        {
            if (ModelState.IsValid)
            {
                db.ExperienciaLaborals.Add(experienciaLaboral);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPuesto = new SelectList(db.Puestoes, "IdPuesto", "Nombre", experienciaLaboral.IdPuesto);
            return View(experienciaLaboral);
        }

        // GET: ExperienciaLaboral/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExperienciaLaboral experienciaLaboral = db.ExperienciaLaborals.Find(id);
            if (experienciaLaboral == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPuesto = new SelectList(db.Puestoes, "IdPuesto", "Nombre", experienciaLaboral.IdPuesto);
            return View(experienciaLaboral);
        }

        // POST: ExperienciaLaboral/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdExperienciaLaboral,Empresa,IdPuesto,FechaDesde,FechaHasta,Salario")] ExperienciaLaboral experienciaLaboral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experienciaLaboral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPuesto = new SelectList(db.Puestoes, "IdPuesto", "Nombre", experienciaLaboral.IdPuesto);
            return View(experienciaLaboral);
        }

        // GET: ExperienciaLaboral/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExperienciaLaboral experienciaLaboral = db.ExperienciaLaborals.Find(id);
            if (experienciaLaboral == null)
            {
                return HttpNotFound();
            }
            return View(experienciaLaboral);
        }

        // POST: ExperienciaLaboral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExperienciaLaboral experienciaLaboral = db.ExperienciaLaborals.Find(id);
            db.ExperienciaLaborals.Remove(experienciaLaboral);
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

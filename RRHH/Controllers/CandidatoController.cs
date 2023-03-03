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
    public class CandidatoController : Controller
    {
        private RecursosHumanosEntities db = new RecursosHumanosEntities();

        // GET: Candidato
        public ActionResult Index()
        {
            var candidatoes = db.Candidatoes.Include(c => c.Capacitacion).Include(c => c.Competencia).Include(c => c.Departamento1).Include(c => c.ExperienciaLaboral);
            return View(candidatoes.ToList());
        }

        // GET: Candidato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidatoes.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // GET: Candidato/Create
        public ActionResult Create()
        {
            ViewBag.IdCapacitacion = new SelectList(db.Capacitacions, "IdCapacitacion", "Descripcion");
            ViewBag.IdCompetencia = new SelectList(db.Competencias, "IdCompetencia", "DescripcionCompetencia");
            ViewBag.IdDepartamento = new SelectList(db.Departamentoes, "IdDepartamento", "Nombre");
            ViewBag.IdExperienciaLaboral = new SelectList(db.ExperienciaLaborals, "IdExperienciaLaboral", "Empresa");
            return View();
        }

        // POST: Candidato/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCandidato,Cedula,Nombre,PuestoAspirado,Departamento,SalarioApirado,IdCompetencia,IdCapacitacion,IdDepartamento,IdExperienciaLaboral,RecomendadoPor")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                db.Candidatoes.Add(candidato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCapacitacion = new SelectList(db.Capacitacions, "IdCapacitacion", "Descripcion", candidato.IdCapacitacion);
            ViewBag.IdCompetencia = new SelectList(db.Competencias, "IdCompetencia", "DescripcionCompetencia", candidato.IdCompetencia);
            ViewBag.IdDepartamento = new SelectList(db.Departamentoes, "IdDepartamento", "Nombre", candidato.IdDepartamento);
            ViewBag.IdExperienciaLaboral = new SelectList(db.ExperienciaLaborals, "IdExperienciaLaboral", "Empresa", candidato.IdExperienciaLaboral);
            return View(candidato);
        }

        // GET: Candidato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidatoes.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCapacitacion = new SelectList(db.Capacitacions, "IdCapacitacion", "Descripcion", candidato.IdCapacitacion);
            ViewBag.IdCompetencia = new SelectList(db.Competencias, "IdCompetencia", "DescripcionCompetencia", candidato.IdCompetencia);
            ViewBag.IdDepartamento = new SelectList(db.Departamentoes, "IdDepartamento", "Nombre", candidato.IdDepartamento);
            ViewBag.IdExperienciaLaboral = new SelectList(db.ExperienciaLaborals, "IdExperienciaLaboral", "Empresa", candidato.IdExperienciaLaboral);
            return View(candidato);
        }

        // POST: Candidato/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCandidato,Cedula,Nombre,PuestoAspirado,Departamento,SalarioApirado,IdCompetencia,IdCapacitacion,IdDepartamento,IdExperienciaLaboral,RecomendadoPor")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCapacitacion = new SelectList(db.Capacitacions, "IdCapacitacion", "Descripcion", candidato.IdCapacitacion);
            ViewBag.IdCompetencia = new SelectList(db.Competencias, "IdCompetencia", "DescripcionCompetencia", candidato.IdCompetencia);
            ViewBag.IdDepartamento = new SelectList(db.Departamentoes, "IdDepartamento", "Nombre", candidato.IdDepartamento);
            ViewBag.IdExperienciaLaboral = new SelectList(db.ExperienciaLaborals, "IdExperienciaLaboral", "Empresa", candidato.IdExperienciaLaboral);
            return View(candidato);
        }

        // GET: Candidato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidatoes.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // POST: Candidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidato candidato = db.Candidatoes.Find(id);
            db.Candidatoes.Remove(candidato);
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

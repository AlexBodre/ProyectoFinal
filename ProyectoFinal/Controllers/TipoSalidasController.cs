using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class TipoSalidasController : Controller
    {
        private FINALContext db = new FINALContext();

        // GET: TipoSalidas
        public ActionResult Index()
        {
            return View(db.TipoSalida.ToList());
        }

        // GET: TipoSalidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSalida tipoSalida = db.TipoSalida.Find(id);
            if (tipoSalida == null)
            {
                return HttpNotFound();
            }
            return View(tipoSalida);
        }

        // GET: TipoSalidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoSalidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] TipoSalida tipoSalida)
        {
            if (ModelState.IsValid)
            {
                db.TipoSalida.Add(tipoSalida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoSalida);
        }

        // GET: TipoSalidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSalida tipoSalida = db.TipoSalida.Find(id);
            if (tipoSalida == null)
            {
                return HttpNotFound();
            }
            return View(tipoSalida);
        }

        // POST: TipoSalidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] TipoSalida tipoSalida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoSalida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoSalida);
        }

        // GET: TipoSalidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSalida tipoSalida = db.TipoSalida.Find(id);
            if (tipoSalida == null)
            {
                return HttpNotFound();
            }
            return View(tipoSalida);
        }

        // POST: TipoSalidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoSalida tipoSalida = db.TipoSalida.Find(id);
            db.TipoSalida.Remove(tipoSalida);
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

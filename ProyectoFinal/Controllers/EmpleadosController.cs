﻿using System;
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
    public class EmpleadosController : Controller
    {
        private FINALContext db = new FINALContext();


        public ActionResult Inactivos()
        {
            var n = from s in db.Empleados where (s.Estatus == "Inactivo") select s;

            return View(n.ToList());
        }


        public ActionResult Entradas(string fecha)
        {
            var empleados = db.Empleados.Include(e => e.cargo).Include(e => e.departamento);

            if (!String.IsNullOrEmpty(fecha))
            {
                string klk = $"{fecha}-01-1900";
                DateTime kitipun = DateTime.ParseExact(klk, "MM-dd-yyyy", null);
                empleados = empleados.Where(a => a.FechaIngreso.Month == kitipun.Month);
            }

            return View(empleados.ToList());
        }

        // GET: Empleados
        public ActionResult Index(string no, string de)
        {
            var empleados = db.Empleados.Include(e => e.cargo).Include(e => e.departamento);

            var n = from s in db.Empleados where (s.Estatus == "Activo") select s;

            if (!String.IsNullOrEmpty(de) && !String.IsNullOrEmpty(no))
            {
                empleados = empleados.Where(s => s.Estatus == "Activo" && s.Nombre.Contains(no) && s.departamento.Nombre == de);

                return View(empleados.ToList());
            }


            if (!String.IsNullOrEmpty(no) && String.IsNullOrEmpty(de))
            {
                empleados = empleados.Where(s =>s.Estatus=="Activo" && s.Nombre.Contains(no));

                return View(empleados.ToList());
            }
             if (!String.IsNullOrEmpty(de) && String.IsNullOrEmpty(no))
            {
                empleados= empleados.Where(s =>s.departamento.Nombre.Contains(de) && s.Estatus=="Activo");
                return View(empleados.ToList());
            }



              return View(empleados.ToList());
          }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.IdCargo = new SelectList(db.Cargos, "Id", "Cargo");
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "Id", "Nombre");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoEmpleado,Nombre,Apellido,Telefono,FechaIngreso,Salario,Estatus,IdDepartamento,IdCargo")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCargo = new SelectList(db.Cargos, "Id", "Cargo", empleados.IdCargo);
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "Id", "Nombre", empleados.IdDepartamento);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCargo = new SelectList(db.Cargos, "Id", "Cargo", empleados.IdCargo);
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "Id", "Nombre", empleados.IdDepartamento);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoEmpleado,Nombre,Apellido,Telefono,FechaIngreso,Salario,Estatus,IdDepartamento,IdCargo")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCargo = new SelectList(db.Cargos, "Id", "Cargo", empleados.IdCargo);
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "Id", "Nombre", empleados.IdDepartamento);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
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

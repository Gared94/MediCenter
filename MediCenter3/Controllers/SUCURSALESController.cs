using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediCenter3.Models;

namespace MediCenter3.Controllers
{
    public class SUCURSALESController : Controller
    {
        private MCEntities db = new MCEntities();

        // GET: SUCURSALES
        public ActionResult Index()
        {
            return View(db.SUCURSALES.ToList());
        }

        // GET: SUCURSALES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCURSALES sUCURSALES = db.SUCURSALES.Find(id);
            if (sUCURSALES == null)
            {
                return HttpNotFound();
            }
            return View(sUCURSALES);
        }

        // GET: SUCURSALES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SUCURSALES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SUCURSAL,SUCURSAL,DIRECCION,TELEFONO")] SUCURSALES sUCURSALES)
        {
            if (ModelState.IsValid)
            {
                db.SUCURSALES.Add(sUCURSALES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sUCURSALES);
        }

        // GET: SUCURSALES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCURSALES sUCURSALES = db.SUCURSALES.Find(id);
            if (sUCURSALES == null)
            {
                return HttpNotFound();
            }
            return View(sUCURSALES);
        }

        // POST: SUCURSALES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SUCURSAL,SUCURSAL,DIRECCION,TELEFONO")] SUCURSALES sUCURSALES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUCURSALES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sUCURSALES);
        }

        // GET: SUCURSALES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCURSALES sUCURSALES = db.SUCURSALES.Find(id);
            if (sUCURSALES == null)
            {
                return HttpNotFound();
            }
            return View(sUCURSALES);
        }

        // POST: SUCURSALES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUCURSALES sUCURSALES = db.SUCURSALES.Find(id);
            db.SUCURSALES.Remove(sUCURSALES);
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

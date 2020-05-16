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
    public class CATEGORIASController : Controller
    {
        private MCEntities db = new MCEntities();

        // GET: CATEGORIAS
        public ActionResult Index()
        {
            return View(db.CATEGORIAS.ToList());
        }

        // GET: CATEGORIAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIAS cATEGORIAS = db.CATEGORIAS.Find(id);
            if (cATEGORIAS == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIAS);
        }

        // GET: CATEGORIAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATEGORIAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CATEGORIA,CATEGORIA")] CATEGORIAS cATEGORIAS)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIAS.Add(cATEGORIAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATEGORIAS);
        }

        // GET: CATEGORIAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIAS cATEGORIAS = db.CATEGORIAS.Find(id);
            if (cATEGORIAS == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIAS);
        }

        // POST: CATEGORIAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CATEGORIA,CATEGORIA")] CATEGORIAS cATEGORIAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORIAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATEGORIAS);
        }

        // GET: CATEGORIAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIAS cATEGORIAS = db.CATEGORIAS.Find(id);
            if (cATEGORIAS == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIAS);
        }

        // POST: CATEGORIAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORIAS cATEGORIAS = db.CATEGORIAS.Find(id);
            db.CATEGORIAS.Remove(cATEGORIAS);
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

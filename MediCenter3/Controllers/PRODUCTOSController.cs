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
    public class PRODUCTOSController : Controller
    {
        private MCEntities db = new MCEntities();

        // GET: PRODUCTOS
        public ActionResult Index()
        {
            var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIAS).Include(p => p.PROVEEDORES).Include(p => p.SUCURSALES);
            return View(pRODUCTOS.ToList());
        }

        // GET: PRODUCTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Create
        public ActionResult Create()
        {
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIAS, "ID_CATEGORIA", "CATEGORIA");
            ViewBag.ID_PROVEEDOR = new SelectList(db.PROVEEDORES, "ID_PROVEEDOR", "PROVEEDOR");
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSALES, "ID_SUCURSAL", "SUCURSAL");
            return View();
        }

        // POST: PRODUCTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRODUCTO,ID_CATEGORIA,ID_PROVEEDOR,ID_SUCURSAL,NOMBRE,PRECIO,EXISTENCIA,FECHA_INGRESO,FECHA_VENCI,NOTAS")] PRODUCTOS pRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTOS.Add(pRODUCTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIAS, "ID_CATEGORIA", "CATEGORIA", pRODUCTOS.ID_CATEGORIA);
            ViewBag.ID_PROVEEDOR = new SelectList(db.PROVEEDORES, "ID_PROVEEDOR", "PROVEEDOR", pRODUCTOS.ID_PROVEEDOR);
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSALES, "ID_SUCURSAL", "SUCURSAL", pRODUCTOS.ID_SUCURSAL);
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIAS, "ID_CATEGORIA", "CATEGORIA", pRODUCTOS.ID_CATEGORIA);
            ViewBag.ID_PROVEEDOR = new SelectList(db.PROVEEDORES, "ID_PROVEEDOR", "PROVEEDOR", pRODUCTOS.ID_PROVEEDOR);
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSALES, "ID_SUCURSAL", "SUCURSAL", pRODUCTOS.ID_SUCURSAL);
            return View(pRODUCTOS);
        }

        // POST: PRODUCTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRODUCTO,ID_CATEGORIA,ID_PROVEEDOR,ID_SUCURSAL,NOMBRE,PRECIO,EXISTENCIA,FECHA_INGRESO,FECHA_VENCI,NOTAS")] PRODUCTOS pRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIAS, "ID_CATEGORIA", "CATEGORIA", pRODUCTOS.ID_CATEGORIA);
            ViewBag.ID_PROVEEDOR = new SelectList(db.PROVEEDORES, "ID_PROVEEDOR", "PROVEEDOR", pRODUCTOS.ID_PROVEEDOR);
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSALES, "ID_SUCURSAL", "SUCURSAL", pRODUCTOS.ID_SUCURSAL);
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // POST: PRODUCTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            db.PRODUCTOS.Remove(pRODUCTOS);
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

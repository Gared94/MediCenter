using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediCenter3.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.USUARIOS objUser)
        {
            if (ModelState.IsValid)
            {
                using (Models.MCEntities db = new Models.MCEntities())
                {
                    var obj = db.USUARIOS.Where(a => a.USUARIO.Equals(objUser.USUARIO) && a.CONTRASENIA.Equals(objUser.CONTRASENIA)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["ID_USUARIOS"] = obj.ID_USUARIOS.ToString();
                        Session["USUARIO"] = obj.USUARIO.ToString();
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
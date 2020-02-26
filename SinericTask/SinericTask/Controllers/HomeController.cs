using DocumentFormat.OpenXml.Drawing.Diagrams;
using SinericTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinericTask.Controllers
{
    public class HomeController : Controller
    {
        ShopContext db = new ShopContext();

        public ActionResult Index()
        {
            var shops = db.Shops;
            return View(shops);
        }
        ////Добавление / удаление
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(Shop s)
        //{
        //    db.Entry(s).State = EntityState.Added;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        ////Удаление
        //[HttpGet]
        //public ActionResult DeleteShop(int id)
        //{
        //    Shop s = db.Shops.Find(id);
        //    if (s == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(s);
        //}
        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Shop s = db.Shops.Find(id);
        //    if (s == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    db.Shops.Remove(s);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public ActionResult EditShop(int? id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    Shop shop = db.Shops.Find(id);
        //    if (shop != null)
        //    {
        //        return View(shop);
        //    }
        //    return HttpNotFound();
        //}

        //[HttpPost]
        //public ActionResult EditShop(Shop s)
        //{
        //    db.Entry(s).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LightPointTask.Models;
using System.Data.Entity;

namespace LightPointTask.Controllers
{
    public class HomeController : Controller
    {
        ShopContext db = new ShopContext();
        public ActionResult Index()
        {
            return View(db.Shops.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            SelectList goods = new SelectList(db.Goodss);
            ViewBag.Teams = goods;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Goods goo)
        {
            db.Goodss.Add(goo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult CreateShop()
        {
            SelectList shops = new SelectList(db.Shops);
            ViewBag.Teams = shops;
            return View();
        }

        [HttpPost]
        public ActionResult CreateShop(Shop shops)
        {
            db.Shops.Add(shops);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Goods goods = db.Goodss.Find(id);
            if (goods != null)
            {
                SelectList teams = new SelectList(db.Goodss,goods.Id);
                ViewBag.Teams = teams;
                return View(goods);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Goods goods)
        {
            db.Entry(goods).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Goods b = db.Goodss.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Goods b = db.Goodss.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Goodss.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GoodsDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            IEnumerable<Goods> goods = new List<Goods>();
            goods = db.Goodss.Where(z => z.ShopId == id).ToList(); ;
            if (goods == null)
            {
                return HttpNotFound();
            }
            return PartialView(goods);

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
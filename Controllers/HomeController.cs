using AssignmentOnResCrud10feb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentOnResCrud10feb.Controllers
{
    public class HomeController : Controller
    {
        WFA3DotNetEntities db = new WFA3DotNetEntities();
        public ActionResult Index(string search="")
        {
            ViewBag.Search = search;

            var res = db.Restaurants.Where(e => e.RName.Contains(search)).ToList();
            return View(res);
        }
        public ActionResult Details(int id)
        {
            var res = db.Restaurants.Where(e => e.RId == id).FirstOrDefault();

            return View(res);

        }

        public ActionResult Create()
        {
            ViewBag.Cusine = db.Restaurants.ToList();

            return View();
        }

        [HttpPost]  
        public ActionResult Create(Restaurant r)
        {
            db.Restaurants.Add(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var restoUpdate = db.Restaurants.Where(e => e.RId == id).FirstOrDefault();
            return View(restoUpdate);
        }
        [HttpPost]
        public ActionResult Edit(Restaurant r)
        {
            var updatedRes = db.Restaurants.Where(e => e.RId == r.RId).FirstOrDefault();
            updatedRes.RName = r.RName;
            updatedRes.CusineType = r.CusineType;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var deleteRes = db.Restaurants.Where(e => e.RId == id).FirstOrDefault();

            return View(deleteRes);
        }
        [HttpPost]
        public ActionResult Delete(int id, Restaurant r)
        {
            var deleteRes = db.Restaurants.Where(e => e.RId == id).FirstOrDefault();
            db.Restaurants.Remove(deleteRes);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
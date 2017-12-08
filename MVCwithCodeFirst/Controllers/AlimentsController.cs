using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCwithCodeFirst;

namespace MVCwithCodeFirst.Controllers
{
    public class AlimentsController : Controller
    {
        private SaladesEntities db = new SaladesEntities();

        // GET: Aliments
        public ActionResult Index()
        {
            return View(db.Aliments.ToList());
        }

        // GET: Aliments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aliment aliment = db.Aliments.Find(id);
            if (aliment == null)
            {
                return HttpNotFound();
            }
            return View(aliment);
        }

        // GET: Aliments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aliments/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom")] Aliment aliment)
        {
            if (ModelState.IsValid)
            {
                db.Aliments.Add(aliment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aliment);
        }

        // GET: Aliments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aliment aliment = db.Aliments.Find(id);
            if (aliment == null)
            {
                return HttpNotFound();
            }
            return View(aliment);
        }

        // POST: Aliments/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom")] Aliment aliment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aliment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aliment);
        }

        // GET: Aliments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aliment aliment = db.Aliments.Find(id);
            if (aliment == null)
            {
                return HttpNotFound();
            }
            return View(aliment);
        }

        // POST: Aliments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aliment aliment = db.Aliments.Find(id);
            db.Aliments.Remove(aliment);
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

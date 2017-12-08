using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCwithCodeFirst;
using MVCwithCodeFirst.ViewModel;

namespace MVCwithCodeFirst.Controllers
{
    public class SaladesController : Controller
    {
        private SaladesEntities db = new SaladesEntities();

        // GET: Salades
        public ActionResult Index()
        {
            var salades = db.Salades.Include(s => s.Fabricant);
            return View(salades.ToList());
        }

        // GET: Salades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salade salade = db.Salades.Find(id);
            if (salade == null)
            {
                return HttpNotFound();
            }
            return View(salade);
        }

        // GET: Salades/Create
        public ActionResult Create()
        {
            ViewBag.Fabricant_ID = new SelectList(db.Fabricants, "ID", "Nom");
            return View();
        }

        // POST: Salades/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Description,Fabricant_ID")] Salade salade)
        {
            if (ModelState.IsValid)
            {
                db.Salades.Add(salade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fabricant_ID = new SelectList(db.Fabricants, "ID", "Nom", salade.Fabricant_ID);
            return View(salade);
        }

        // GET: Salades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salade salade = db.Salades.Find(id);

            if (salade == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fabricant_ID = new SelectList(db.Fabricants, "ID", "Nom", salade.Fabricant_ID);
            return View(salade);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //var saladeViewModel = new SaladeViewModel
            //{
            //    Salade = db.Salades.Include(i => i.Aliments).First(i => i.ID == id),
            //};

            //if (saladeViewModel.Salade == null)
            //    return HttpNotFound();

            //var allJobTagsList = db.Aliments.ToList();
            //saladeViewModel.AllAliments = allJobTagsList.Select(o => new SelectListItem
            //{
            //    Text = o.Nom,
            //    //Value = o.ID.ToString();
            //});
            
            //ViewBag.Fabricant_ID = new SelectList(db.Fabricants, "ID", "Nom", saladeViewModel.Salade.Fabricant_ID);

            //return View(saladeViewModel);
        }

        // POST: Salades/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Description,Fabricant_ID")] Salade salade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fabricant_ID = new SelectList(db.Fabricants, "ID", "Nom", salade.Fabricant_ID);
            return View(salade);
        }

        // GET: Salades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salade salade = db.Salades.Find(id);
            if (salade == null)
            {
                return HttpNotFound();
            }
            return View(salade);
        }

        // POST: Salades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salade salade = db.Salades.Find(id);
            db.Salades.Remove(salade);
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

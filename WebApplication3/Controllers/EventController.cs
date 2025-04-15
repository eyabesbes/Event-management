using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        private  GestionEventEntities _db = new GestionEventEntities();
        public ActionResult Index()
        {
            return View(_db.Event.ToList());
        }

        // GET: Event/Details/5
        public ActionResult Detail(int id)
        {
            var data = _db.Event.Where(x => x.IdEvent == id).FirstOrDefault();
            return View(data);
        }
        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] Event EventToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
            _db.Event.Add(EventToCreate);
            _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _db.Event.Where(x => x.IdEvent == id).FirstOrDefault();
            return View(data);
        }
        // POST: Event/Edit/5

        [HttpPost]
        public ActionResult Edit(Event Model)
        {
            var data = _db.Event.Where(x => x.IdEvent == Model.IdEvent).FirstOrDefault();
            if (data != null)
            {
                data.nomEvent = Model.nomEvent;
                data.Date = Model.Date;
                data.lieu = Model.lieu;
                data.cible = Model.cible;
                data.Type = Model.Type;
                _db.SaveChanges();

            }
            return RedirectToAction("index");
        }
        // GET: Event/Delete/5

        public ActionResult Delete(int id)
        {
            var data = _db.Event.Where(x => x.IdEvent == id).FirstOrDefault();
            _db.Event.Remove(data);
            _db.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}

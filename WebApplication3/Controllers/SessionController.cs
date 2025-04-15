using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        private GestionEventEntities5 _db = new GestionEventEntities5();
        public ActionResult Index()
        {
            return View(_db.Session.ToList());
        }

        // GET: Session/Details/5
        public ActionResult Detail(int id)
        {
            var data = _db.Session.Where(x => x.IdSession == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] Session SessionToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _db.Session.Add(SessionToCreate);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _db.Session.Where(x => x.IdSession == id).FirstOrDefault();
            return View(data);
        }
        // POST: Event/Edit/5

        [HttpPost]
        public ActionResult Edit(Session Model)
        {
            var data = _db.Session.Where(x => x.IdSession == Model.IdSession).FirstOrDefault();
            if (data != null)
            {
                data.IdSpeaker = Model.IdSpeaker;
                data.sujet = Model.sujet;
                data.IdEvent = Model.IdEvent;
                data.horaire = Model.horaire;
                
                _db.SaveChanges();

            }
            return RedirectToAction("index");
        }

        // GET: Session/Delete/5

        public ActionResult Delete(int id)
        {
            var data = _db.Session.Where(x => x.IdSession == id).FirstOrDefault();
            _db.Session.Remove(data);
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

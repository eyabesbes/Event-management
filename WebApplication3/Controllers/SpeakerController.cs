using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class SpeakerController : Controller
    {
        // GET: Speaker
        private GestionEventEntities2 _db = new GestionEventEntities2();
        public ActionResult Index()
        {
            return View(_db.Speaker.ToList());
        }

        // GET: Speaker/Details/5
        public ActionResult Detail(int id)
        {
            var data = _db.Speaker.Where(x => x.IdSpeaker == id).FirstOrDefault();
            return View(data);
        }

        // GET: Speaker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Speaker/Create
        // POST: Organisateur/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] Speaker SpeakerToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _db.Speaker.Add(SpeakerToCreate);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Speaker/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _db.Speaker.Where(x => x.IdSpeaker == id).FirstOrDefault();
            return View(data);
        }
        // POST: Event/Edit/5

        [HttpPost]
        public ActionResult Edit(Speaker Model)
        {
            var data = _db.Speaker.Where(x => x.IdSpeaker == Model.IdSpeaker).FirstOrDefault();
            if (data != null)
            {
                data.nomSpeaker = Model.nomSpeaker;
                data.numTel = Model.numTel;
                data.adresse = Model.adresse;
                data.mail = Model.mail;
                _db.SaveChanges();

            }
            return RedirectToAction("index");
        }

        // GET: Speaker/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _db.Speaker.Where(x => x.IdSpeaker == id).FirstOrDefault();
            _db.Speaker.Remove(data);
            _db.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }

        // POST: Speaker/Delete/5
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

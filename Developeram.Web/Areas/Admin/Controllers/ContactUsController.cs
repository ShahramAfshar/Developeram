using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Developeram.Data;
using Developeram.Data.DatabaseContext;
using Developeram.DomainModel.Models;

namespace Developeram.Web.Areas.Admin.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

        // GET: Admin/ContactUs
        public ActionResult Index()
        {
            return View(db.ContactUsRepository.GetAll());
        }

        // GET: Admin/ContactUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUs contactUs = db.ContactUsRepository.GetById(id);
            if (contactUs == null)
            {
                return HttpNotFound();
            }
            return View(contactUs);
        }

        // GET: Admin/ContactUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ContactUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactUsId,Name,Email,Question,CreateDate")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                db.ContactUsRepository.Insert(contactUs);
                db.Commit();

                return RedirectToAction("Index");
            }

            return View(contactUs);
        }

        // GET: Admin/ContactUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUs contactUs = db.ContactUsRepository.GetById(id);
            if (contactUs == null)
            {
                return HttpNotFound();
            }
            return View(contactUs);
        }

        // POST: Admin/ContactUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactUsId,Name,Email,Question,CreateDate")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                db.ContactUsRepository.Update(contactUs);
                db.Commit();

                return RedirectToAction("Index");
            }
            return View(contactUs);
        }

        // GET: Admin/ContactUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUs contactUs = db.ContactUsRepository.GetById(id);
            if (contactUs == null)
            {
                return HttpNotFound();
            }
            return View(contactUs);
        }

        // POST: Admin/ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactUs contactUs = db.ContactUsRepository.GetById(id);
            db.ContactUsRepository.Delete(contactUs);
            db.Commit();

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

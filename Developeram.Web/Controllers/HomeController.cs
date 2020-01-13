using Developeram.Data;
using Developeram.Data.DatabaseContext;
using Developeram.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developeram.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();
        public ActionResult Index()
        {
        

            return View(db.GroupRepository.GetAll());
        }

        public ActionResult Category()
        {
            ViewBag.Articles = db.ArticleRepository.GetAll();
            return PartialView("_PartialCategory", db.GroupRepository.GetAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Slider()
        {
            return PartialView("_PartialSlider", db.SliderRepository.GetValid());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                contactUs.CreateDate = DateTime.Now;
                db.ContactUsRepository.Insert(contactUs);
                db.Commit();

                return RedirectToAction("Index");
            }
            return View(contactUs);

        }

        public ActionResult Menu()
        {
            return PartialView("_MenuPartial", db.GroupRepository.GetAll());
        }
    }
}
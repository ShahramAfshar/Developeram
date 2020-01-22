using Developeram.Data;
using Developeram.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developeram.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();
        // GET: Search
        public ActionResult Index(string q)
        {
                ViewBag.search = q;
                return View(db.ArticleRepository.Search(q));
         
        }
    }
}
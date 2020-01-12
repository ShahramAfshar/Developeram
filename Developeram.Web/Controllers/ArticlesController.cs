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
    public class ArticlesController : Controller
    {

        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

        [Route("Article/{course}/{title}")]
        public ActionResult ShowCategory(string course,string title)
        {
            Group group = db.GroupRepository.GetByTitleUrl(course);
            ViewBag.Articles = db.ArticleRepository.GetMany(a => a.GroupId == group.GroupId);

            return View(group);
        }


        [Route("{course}/{id}/{title}")]
        public ActionResult ShowArticle(string title, int id)
        {
            Article article = db.ArticleRepository.GetById(id);
            return View(article);
        }
    }
}
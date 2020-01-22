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

        //[Route("group/{course}/{title}")]
        //public ActionResult ShowCategory(string course,string title)
        //{
        //    Group group = db.GroupRepository.GetByTitleUrl(course);
        //    ViewBag.Articles = db.ArticleRepository.GetMany(a => a.GroupId == group.GroupId);

        //    return View(group);
        //}


        [Route("Article/{id}/{title}")]
        public ActionResult ShowArticle(string title, int id)
        {
            Article article = db.ArticleRepository.GetById(id);
            article.Visit = article.Visit + 1;
            db.ArticleRepository.Update(article);
            db.Commit();

            return View(article);
        }


        public ActionResult ShowComments(int id)
        {
            return PartialView(db.CommentRepository.GetForArticle(id));
        }

        public ActionResult CreateComment(int id)
        {
            return PartialView(new Comment()
            {
                ArticleId = id
            });
        }

        [HttpPost]
        public ActionResult CreateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CreateDate = DateTime.Now;
                db.CommentRepository.Insert(comment);
                db.Commit();

                return PartialView("ShowComments", db.CommentRepository.GetForArticle(comment.ArticleId));

            }
            return PartialView(comment);
        }

 

    }
}
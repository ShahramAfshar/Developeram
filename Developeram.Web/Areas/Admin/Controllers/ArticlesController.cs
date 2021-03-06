﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Developeram.Data;
using Developeram.Data.DatabaseContext;
using Developeram.DomainModel.Models;

namespace Developeram.Web.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

        // GET: Admin/Articles
        public ActionResult Index()
        {

            return View(db.ArticleRepository.GetAll());
        }

        // GET: Admin/Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.ArticleRepository.GetById(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Admin/Articles/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.GroupRepository.GetAll(), "GroupId", "Title");
            return View();
        }

        // POST: Admin/Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleId,Title,ShortText,FullText,CreateDate,ImageName,GroupId,MetaAuthor,MetaKeywords,MetaOwner,TitleUrl")] Article article, HttpPostedFileBase imgup, string tags)
        {
            if (ModelState.IsValid)
            {

                if (imgup != null)
                {
                    article.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);
                    imgup.SaveAs(Server.MapPath("/Images/Articles/" + article.ImageName));

                }
                else
                    article.ImageName = "images.jpg";

                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tag = tags.Split('-');
                    foreach (string t in tag)
                    {
                        db.TagArticleRepository.Insert(new TagArticle()
                        {
                            ArticleId = article.ArticleId,
                            Title = t.Trim()
                        });
                    }
                }


                article.CreateDate = DateTime.Now;
                article.ShortLink = GenerateShortKey();

                db.ArticleRepository.Insert(article);
                db.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.GroupRepository.GetAll(), "GroupId", "Title", article.GroupId);
            return View(article);
        }

        // GET: Admin/Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.ArticleRepository.GetById(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.GroupRepository.GetAll(), "GroupId", "Title", article.GroupId);


            ViewBag.Tags = string.Join("-", article.TagArticles.Select(t => t.Title).ToList());
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleId,Title,ShortText,FullText,CreateDate,ImageName,GroupId,MetaAuthor,MetaKeywords,MetaOwner,TitleUrl")] Article article, HttpPostedFileBase imgup, string tags)
        {
            if (ModelState.IsValid)
            {

                if (imgup != null)
                {
                    if (article.ImageName != "images.jpg")
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/Articles/" + article.ImageName));
                    }

                    article.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);
                    imgup.SaveAs(Server.MapPath("/Images/Articles/" + article.ImageName));
                }



                //start tags
                db.TagArticleRepository.GetMany(t => t.ArticleId == article.ArticleId).ToList().ForEach(t => db.TagArticleRepository.Delete(t));


                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tag = tags.Split('-');
                    foreach (string t in tag)
                    {
                        db.TagArticleRepository.Insert(new TagArticle()
                        {
                            ArticleId = article.ArticleId,
                            Title = t.Trim()
                        });
                    }
                }
                //end tags

                db.ArticleRepository.Update(article);
                db.Commit();

                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.GroupRepository.GetAll(), "GroupId", "Title", article.GroupId);

            ViewBag.Tags = string.Join("-", article.TagArticles.Select(t => t.Title).ToList());
            return View(article);
        }

        // GET: Admin/Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.ArticleRepository.GetById(id);
            if (article == null)
            {
                return HttpNotFound();
            }


            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.ArticleRepository.GetById(id);

            if (article.ImageName != "images.jpg")
            {
                System.IO.File.Delete(Server.MapPath("/Images/Articles/" + article.ImageName));
            }

            db.TagArticleRepository.Delete(t => t.ArticleId == article.ArticleId);

            db.ArticleRepository.Delete(article);
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

        private string GenerateShortKey(int lenght = 4)
        {
            string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, lenght);

            while (db.ArticleRepository.ExistKey(key))
            {
                key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, lenght);
            }

            return key;
        }
    }
}

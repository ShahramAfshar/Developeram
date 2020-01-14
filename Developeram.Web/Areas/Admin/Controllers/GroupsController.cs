using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Developeram.Data.DatabaseContext;
using Developeram.DomainModel.Models;
using Developeram.Data;


namespace Developeram.Web.Areas.Admin.Controllers
{
    public class GroupsController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

        // GET: Admin/Groups
        public ActionResult Index()
        {
            return View(db.GroupRepository.GetAll());
        }

        // GET: Admin/Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.GroupRepository.GetById(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Admin/Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,Title,TitleUrl,ShortText,FullText,CreateTime,MetaAuthor,MetaDescription,MetaKeywords,MetaOwner")] Group group, HttpPostedFileBase imgup, string tags)
        {
            if (ModelState.IsValid)
            {
              
                if (imgup != null)
                {
                    group.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);
                    imgup.SaveAs(Server.MapPath("/Images/Groups/" + group.ImageName));

                }
                else
                    group.ImageName = "images.jpg";


                group.CreateTime = DateTime.Now;
                group.ShortLink = GenerateShortKey();

                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tag = tags.Split('-');
                    foreach (string t in tag)
                    {
                        db.TagRepository.Insert(new Tag()
                        {
                            GroupId = group.GroupId,
                            Title = t.Trim()
                        });
                    }
                }


                db.GroupRepository.Insert(group);
                db.Commit();

                return RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: Admin/Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.GroupRepository.GetById(id);
            if (group == null)
            {
                return HttpNotFound();
            }

            ViewBag.Tags = string.Join(",", group.Tags.Select(t => t.Title).ToList());
            return View(group);
        }

        // POST: Admin/Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,Title,TitleUrl,ShortText,FullText,CreateTime,ImageName,MetaAuthor,MetaDescription,MetaKeywords,MetaOwner")] Group group, HttpPostedFileBase imgup, string tags)
        {
            if (ModelState.IsValid)
            {

                if (imgup != null)
                {
                    if (group.ImageName != "images.jpg")
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/Groups/" + group.ImageName));
                    }

                    group.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);
                    imgup.SaveAs(Server.MapPath("/Images/Groups/" + group.ImageName));
                }


                //start tags
                db.TagRepository.GetMany(t => t.GroupId == group.GroupId).ToList().ForEach(t => db.TagRepository.Delete(t));


                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tag = tags.Split('-');
                    foreach (string t in tag)
                    {
                        db.TagRepository.Insert(new Tag()
                        {
                            GroupId = group.GroupId,
                            Title = t.Trim()
                        });
                    }
                }
                //end tags

                // group.ImageName = "images.jpg";

                db.GroupRepository.Update(group);
                db.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.Tags = tags;
            return View(group);
        }

        // GET: Admin/Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.GroupRepository.GetById(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Admin/Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.GroupRepository.GetById(id);

            if (group.ImageName != "images.jpg")
            {
                System.IO.File.Delete(Server.MapPath("/Images/Groups/" + group.ImageName));
            }

            db.GroupRepository.Delete(group);
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

            while (db.GroupRepository.ExistKey(key))
            {
                key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, lenght);
            }

            return key;
        }

    }
}

using Developeram.Data;
using Developeram.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Developeram.Web.Controllers
{
    public class ShortLinkController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

       // string urlSite = "https://localhost:44368";
        string urlSite = "http://developeram.ir/";

        // GET: ShortLink
        [Route("a/{key}")]
        public ActionResult ShortKeyRedirectToArticle(string key)
        {
            var article = db.ArticleRepository.Get(p => p.ShortLink == key);

            if (article == null)
            {
                return HttpNotFound();
            }
          //  / @Model.TitleUrl / @item.ArticleId / @item.TitleUrl.Replace(" ", "-")
            Uri uri = new Uri(urlSite + "/" +article.ArticleId+"/"+ article.TitleUrl.Replace(" ","-"));
            return Redirect(uri.AbsoluteUri);
        }

        //[Route("g/{key}")]
        //public ActionResult ShortKeyRedirectToGroup(string key)
        //{
        //    var group = db.GroupRepository.Get(p => p.ShortLink == key);

        //    if (group == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ///Article/@item.TitleUrl/@item.Title.Replace(" ","-")
        //    Uri uri = new Uri(urlSite + "/Group/" + group.TitleUrl + "/" + group.Title.Replace(" ","-"));

        //    return Redirect(uri.AbsoluteUri);
        //}
    }
}
﻿using Developeram.Data.DatabaseContext;
using Developeram.DomainModel.Models;
using Developeram.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developeram.DomainModel.ViewModels;

namespace Developeram.Data.Repositories
{
     
    public interface IArticleRepository : IRepository<Article>
    {
        //------Definition Private Functions Model -------------//
        IEnumerable<Article> Search(string q);
        bool ExistKey(string key);


    }

    public class ArticleRepository : Repository<Article>, IArticleRepository
    {

        private readonly DbContext db;
        public ArticleRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }

        public bool ExistKey(string key)
        {
          return  GetAll().Any(a => a.ShortLink == key);
        }



        public IEnumerable<Article> Search(string q)
        {
            return GetAll().Where(a => a.FullText.Contains(q) || a.ShortText.Contains(q) || a.Title.Contains(q) || a.TitleUrl.Contains(q));

        }



        //public IEnumerable<Product> Search(string q)
        //{
        //    var Tags = GetAll().Where(t => t.Title == q).Select(t => t.Product).ToList();
        //    return Tags;
        //}





    }
}

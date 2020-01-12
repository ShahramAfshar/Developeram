using Developeram.Data.DatabaseContext;
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


    }

    public class ArticleRepository : Repository<Article>, IArticleRepository
    {

        private readonly DbContext db;
        public ArticleRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }



        //public IEnumerable<Product> Search(string q)
        //{
        //    var Tags = GetAll().Where(t => t.Title == q).Select(t => t.Product).ToList();
        //    return Tags;
        //}





    }
}

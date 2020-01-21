using Developeram.Data.DatabaseContext;
using Developeram.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developeram.Data.Repositories
{
    
    public interface ITagArticleRepository : IRepository<TagArticle>
    {
        //------Definition Private Functions Model -------------//


    }

    public class TagArticleRepository : Repository<TagArticle>, ITagArticleRepository
    {

        private readonly DbContext db;
        public TagArticleRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }







    }
}

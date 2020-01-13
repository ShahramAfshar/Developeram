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
 

        public interface ICommentRepository : IRepository<Comment>
        {
        //------Definition Private Functions Model -------------//
        IEnumerable<Comment> GetForArticle(int articleId);

    }

        public class CommentRepository : Repository<Comment>, ICommentRepository
    {

            private readonly DbContext db;
            public CommentRepository(DbContext dbContext) : base(dbContext)
            {
                this.db = (this.db ?? (MyDbContext)db);
            }

        public IEnumerable<Comment> GetForArticle(int articleId)
        {
            return GetAll().Where(c => c.ArticleId == articleId)
                           .Where(c=>c.IsShow==true);
        }

        //public IList<User> GetActiveUsers()
        //{
        //    var users = GetAll().Where(u => u.IsActive)
        //        .ToList();
        //    return users;
        //}




    }
}

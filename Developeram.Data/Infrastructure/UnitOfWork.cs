using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Developeram.Data.Repositories;

namespace ECommerce.Data
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()

    {

        #region Fileds
        protected readonly DbContext db;

        #endregion

        #region Ctor
        public UnitOfWork()
        {
            db = new TContext();
        }

        #endregion

        #region Implement

        public void Commit()
        {
            db.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return db.SaveChangesAsync();
        }

        #endregion

        #region Repositories

        private GroupRepository groupRepository;
        public GroupRepository GroupRepository
        {
            get
            {
                if (groupRepository == null)
                {
                    groupRepository = new GroupRepository(db);
                }

                return groupRepository;
            }
        }

        private ArticleRepository articleRepository;
        public ArticleRepository ArticleRepository
        {
            get
            {
                if (articleRepository == null)
                {
                    articleRepository = new ArticleRepository(db);
                }

                return articleRepository;
            }
        }


        #endregion

        #region Dispose

        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion

    }
}

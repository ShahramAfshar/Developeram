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
     
    public interface ITagRepository : IRepository<Tag>
    {
        //------Definition Private Functions Model -------------//
  

    }

    public class TagRepository : Repository<Tag>, ITagRepository
    {

        private readonly DbContext db;
        public TagRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }







    }
}

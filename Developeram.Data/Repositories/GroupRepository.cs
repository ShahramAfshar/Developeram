using Developeram.Data.DatabaseContext;
using Developeram.DomainModel.Models;
using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developeram.Data.Repositories
{
     
    public interface IGroupRepository : IRepository<Group>
    {
        //------Definition Private Functions Model -------------//
      //  IEnumerable<Product> Search(string q);

    }

    public class GroupRepository : Repository<Group>, IGroupRepository
    {

        private readonly DbContext db;
        public GroupRepository(DbContext dbContext) : base(dbContext)
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

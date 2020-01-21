using Developeram.Data.DatabaseContext;
using Developeram.DomainModel.Models;
using Developeram.DomainModel.ViewModels;
using Developeram.Data;
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

        //Group GetByTitleUrl(string groupTitleUrl);
        //bool ExistKey(string key);
    }

    public class GroupRepository : Repository<Group>, IGroupRepository
    {

        private readonly DbContext db;
        public GroupRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }

        //public bool ExistKey(string key)
        //{
        //    return GetAll().Any(a => a.ShortLink == key);
        //}

        //public Group GetByTitleUrl(string groupTitleUrl)
        //{
        //    MyDbContext mydb = new MyDbContext();
        // return  mydb.Groups.Where(g => g.TitleUrl.Trim() == groupTitleUrl.Trim()).SingleOrDefault();
        //}
    }
}

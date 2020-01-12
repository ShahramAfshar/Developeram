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
     
    public interface IContactUsRepository : IRepository<ContactUs>
    {

    }

    public class ContactUsRepository : Repository<ContactUs>, IContactUsRepository
    {

        private readonly DbContext db;
        public ContactUsRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }




    }
}

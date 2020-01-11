using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Developeram.Data.DatabaseContext
{
   public class MyDbContext : IdentityDbContext
    {
        public MyDbContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Developeram.DomainModel.Models.Group> Groups { get; set; }

        //static MyDbContext()
        //{
        //    Database.SetInitializer(new
        //       MigrateDatabaseToLatestVersion<MyDbContext, Migrations.Configuration>());
        //}


    }
}

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

        public System.Data.Entity.DbSet<Developeram.DomainModel.Models.Article> Articles { get; set; }

     
        public System.Data.Entity.DbSet<Developeram.DomainModel.Models.Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<Developeram.DomainModel.Models.ContactUs>  ContactUs { get; set; }
        public System.Data.Entity.DbSet<Developeram.DomainModel.Models.Slider>  Sliders { get; set; }

        //static MyDbContext()
        //{
        //    Database.SetInitializer(new
        //       MigrateDatabaseToLatestVersion<MyDbContext, Migrations.Configuration>());
        //}


    }
}

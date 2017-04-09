
using System.Data.Entity.ModelConfiguration.Conventions;
using App.Data.Entities;

namespace App.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyContext : DbContext
    {
        // Your context has been configured to use a 'Model' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApplication1.Data.Model' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model' 
        // connection string in the application configuration file.
        public MyContext()
            : base("name=MyConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, SchoolDataLayer.Migrations.Configuration>("MyConnection"));
            Database.SetInitializer<MyContext>(null);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled= false;

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Request>().
            HasRequired<DocType>(s => s.RequestDocType)
           .WithMany(p => p.RequestRequests)
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>().
            HasRequired<DocType>(s => s.ReceiveDocType)
           .WithMany(p => p.ReceiveRequests)
           .WillCascadeOnDelete(false);

           /*modelBuilder.Types<Request>()
               .Configure(c => c.Ignore(p => p.State));

            modelBuilder.Types<Request>()
                .Configure(c => c.Ignore(p => p.Division));

            modelBuilder.Types<Request>()
                .Configure(c => c.Ignore(p => p.Department));*/


        }

        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<Status> RequestStatus { get; set; }

        public virtual DbSet<StateView> States { get; set; }
        public virtual DbSet<CountryView> Countries { get; set; }

        public virtual DbSet<DivisionView> Divisions { get; set; }
        public virtual DbSet<DepartmentView> Departments { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExploreCalifornia.Models {
    public class MyDbContext : DbContext {
        //public MyDbContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;
        //                              AttachDbFilename=E:\EVS ASPNET\EVS_WEB Projs\ExploreCalifornia\Web API of California\ExploreCalifornia\App_Data\ExploreCaliforniaDB.mdf;
        //                              Integrated Security=True;Connect Timeout=30") { }
        public MyDbContext():base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Dealova4Eva_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
                
        }
        public DbSet<Tour> Tours { get; set; }

    }
}
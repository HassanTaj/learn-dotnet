using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExploreCalifornia.Models {
    public class MyDbContext : DbContext {
        public MyDbContext() : base(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=E:\EVS ASPNET\EVS_WEB Projs\ExploreCalifornia\Real time singnalR\ExploreCalifornia\App_Data\ExploreCaliforniaDB.mdf;Integrated Security = True; Connect Timeout = 30") { }
        public DbSet<Tour> Tours { get; set; }
    }
}
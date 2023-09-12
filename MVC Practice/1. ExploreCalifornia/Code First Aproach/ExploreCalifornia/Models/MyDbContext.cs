using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExploreCalifornia.Models {
    public class MyDbContext : DbContext {
        public MyDbContext() : base("ExploreCaliforniaDB") { }
        public DbSet<Tour> Tours { get; set; }

    }
}
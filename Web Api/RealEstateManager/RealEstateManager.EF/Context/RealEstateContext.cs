using Microsoft.EntityFrameworkCore;
using RealEstateManager.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.EF.Context {
    public class RealEstateContext : DbContext {

        public RealEstateContext(DbContextOptions<RealEstateContext> opts): base(opts) {

        }
        // dbsets

        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}

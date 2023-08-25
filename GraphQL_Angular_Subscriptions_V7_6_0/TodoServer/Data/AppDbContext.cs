using Microsoft.EntityFrameworkCore;
using TodoServer.Models;

namespace TodoServer.Data
{
    public class AppDbContext : DbContext {

        public DbSet<Todo> Todos { get; set; }

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=todos_db.sqlite", options => {
                //options.EnableRetryOnFailure();
            });
            base.OnConfiguring(optionsBuilder);
        }
        #endregion
    }
}

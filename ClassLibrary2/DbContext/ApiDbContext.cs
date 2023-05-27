using Api.Logs;
using Api.Productos;
using Microsoft.EntityFrameworkCore;

namespace Api.EntityFrameWork {
    public class ApiDbContext : DbContext {

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options) {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Producto>()
                .Property(b => b.Precio).HasPrecision(14, 2).HasColumnType("decimal(18,2)");
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Api.EntityFrameWork {
    public class DbContextFactory : IDesignTimeDbContextFactory<ApiDbContext> {
        public DbContextFactory() {
        
        }

        private readonly IConfiguration Configuration;
        public DbContextFactory(IConfiguration configuration) {
            Configuration = configuration;
        }

        public ApiDbContext CreateDbContext(string[] args) {

            string filePath = @"";

            IConfiguration Configuration = new ConfigurationBuilder()
               .SetBasePath(Path.GetDirectoryName(filePath))
               .AddJsonFile("appSettings.json")
               .Build();

            
            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"));

            return new ApiDbContext(optionsBuilder.Options);
        }

    }
}

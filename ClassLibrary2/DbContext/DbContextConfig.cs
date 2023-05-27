using Api.Logs;
using Api.Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Api.EntityFrameWork {
    public static class ISserviceCollectionExtension {
        public static IServiceCollection ConfigureServices(this IServiceCollection service, IConfiguration Configuration) {
            //access the appsetting json file in your WebApplication File

            string filePath = @"";

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Path.GetDirectoryName(filePath))
               .AddJsonFile("appSettings.json")
               .Build();

            service.AddDbContext<ApiDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));

            service.AddScoped<ILogRepository, LogRepository>();
            service.AddScoped<IProductoRepository, ProductoRepository>();

            return service;
        }
    }
}

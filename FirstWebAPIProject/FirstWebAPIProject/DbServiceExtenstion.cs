using Microsoft.EntityFrameworkCore;

namespace FirstWebAPIProject
{
    public static class DbServiceExtenstion
    {
        public static void AddDServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Db.CodeFirstDemoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}

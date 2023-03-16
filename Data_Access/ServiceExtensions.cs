using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data_Access
{
    public static class ServiceExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void AddDbContext(this IServiceCollection services, string connStr)
        {
            services.AddDbContext<StandOfGloryDbContext>(opt => opt.UseSqlServer(connStr));
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<StandOfGloryDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}

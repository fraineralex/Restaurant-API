using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Domain.Settings;
using RestaurantAPI.Infrastructure.Identity.Context;
using RestaurantAPI.Infrastructure.Identity.Entities;
using RestaurantAPI.Infrastructure.Identity.Services;

namespace RestaurantAPI.Infrastructure.Identity
{
    //Main reason for creating this class is to follow the Single responsability
    public static class ServiceRegistration
    {
        // Extension methods | "Decorator"
        // This allows us to extend and create new functionallity following "Open-Closed Principle"
        public static void AddIdentityInfrastructure(this IServiceCollection service, IConfiguration config)
        {
            #region context
            if (config.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<IdentityContext>(options => options.UseInMemoryDatabase("IdentityDb"));
            }
            else
            {
                service.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("IdentityConnection"),
                    m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));
            }
            #endregion

            #region 'Identity'

            service.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            service.ConfigureApplicationCookie(opts => 
            {
                opts.LoginPath = "/User";
                opts.AccessDeniedPath = "/User/AccessDenied";
            });

            service.Configure<JWTSettings>(config.GetSection("JWTSettings"));

            service.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            #endregion

            #region 'Services'
            service.AddTransient<IAccountService, AccountService>();
            #endregion
        }
    }
}

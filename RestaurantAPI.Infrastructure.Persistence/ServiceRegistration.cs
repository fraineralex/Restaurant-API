using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Infrastructure.Persistence.Context;
using RestaurantAPI.Infrastructure.Persistence.Repositories;


namespace RestaurantAPI.Infrastructure.Persistence
{
    //Main reason for creating this class is to follow the Single responsability
    public static class ServiceRegistration
    {
        // Extension methods | "Decorator"
        // This allows us to extend and create new functionallity following "Open-Closed Principle"
        public static void AddPersistanceInfrastructure(this IServiceCollection service, IConfiguration config)
        {
            if (config.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                service.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }

            #region 'repositories'

            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IIngredientRepository, IngredientRepository>();
            service.AddTransient<IPlateRepository, PlateRepository>();
            service.AddTransient<IPlateCategoryRepository, PlateCategoryRepository>();
            service.AddTransient<ITableStatusRepository, TableStatusRepository>();
            service.AddTransient<ITableRepository, TableRepository>();
            service.AddTransient<IOrderStatusRepository, OrderStatusRepository>();
            service.AddTransient<IOrderRepository, OrderRepository>();
            service.AddTransient<IPlateIngredientRepository, PlateIngredientRepository>();






            #endregion
        }
    }
}

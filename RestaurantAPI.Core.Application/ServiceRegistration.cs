using Microsoft.Extensions.DependencyInjection;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.Services;
using System.Reflection;

namespace RestaurantAPI.Core.Application
{
    //Extension Methods - application of this design pattern Decorator
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services

            service.AddTransient<IOrderService, OrderService>();
            service.AddTransient<IIngredientService, IngredientService>();
            service.AddTransient<IPlateService, PlateService>();
            service.AddTransient<ITableService, TableService>();
            service.AddTransient<IPlateIngredientService, PlateIngredientService>();



            #endregion
        }
    }
}

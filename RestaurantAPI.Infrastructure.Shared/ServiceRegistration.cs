
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Shared
{
    //Extension Methods - application of this design pattern Decorator
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection service, IConfiguration config)
        {
            //service.AddTransient<IEmailService, EmailService>();
            //service.AddTransient<IUploadFileService, UploadFileService>();
        }
    }
}


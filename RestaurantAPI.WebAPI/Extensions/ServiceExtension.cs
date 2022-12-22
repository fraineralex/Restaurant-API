using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RestaurantAPI.Extensions
{
    public static class ServiceExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection svc)
        {
            svc.AddSwaggerGen(opt =>
            {
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => opt.IncludeXmlComments(xmlFile));

                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Restaurant API",
                    Description = "Restaurant API is a restful api that allows us to manage the general functionalities of a restaurant.",
                    Contact = new OpenApiContact
                    {
                        Name = "Frainer Encarnación",
                        Email = "frainerdeveloper@gmail.com",
                        Url = new Uri("https://github.com/Fraineralex")
                    }
                });

                opt.DescribeAllParametersInCamelCase();


            });
        }

        public static void AddApiVersioningExtension(this IServiceCollection svc)
        {
            svc.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;            });

        }
    }
}

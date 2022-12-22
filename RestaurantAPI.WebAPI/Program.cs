using Microsoft.AspNetCore.Identity;
using RestaurantAPI.Core.Application;
using RestaurantAPI.Infrastructure.Identity.Entities;
using RestaurantAPI.Infrastructure.Identity.Seeds;
using RestaurantAPI.Infrastructure.Identity;
using RestaurantAPI.Infrastructure.Persistence;
using RestaurantAPI.Infrastructure.Shared;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Infrastructure.Persistence.Seeds.Category;
using RestaurantAPI.Infrastructure.Persistence.Seeds.Order;
using RestaurantAPI.Infrastructure.Persistence.Seeds.TableStatuses;
using System.Configuration;
using RestaurantAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddPersistanceInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer();

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerExtension();
builder.Services.AddApiVersioningExtension();
builder.Services.AddDistributedMemoryCache();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {

        var plateCategory = services.GetRequiredService<IPlateCategoryRepository>();
        var orderStatus = services.GetRequiredService<IOrderStatusRepository>();
        var tableStatus = services.GetRequiredService<ITableStatusRepository>();

        await DefaultEntryCategory.SeedAsync(plateCategory);
        await DefaultMainCourseCategory.SeedAsync(plateCategory);
        await DefaultDrinkCategory.SeedAsync(plateCategory);
        await DefaultDessertCategory.SeedAsync(plateCategory);

        await DefaultDoneOrderStatus.SeedAsync(orderStatus);
        await DefaultInProcessOrderStatus.SeedAsync(orderStatus);

        await DefaultAttendedStatus.SeedAsync(tableStatus);
        await DefaultAttendedStatus.SeedAsync(tableStatus);
        await DefaultInProccessStatus.SeedAsync(tableStatus);

    }
    catch (Exception ex)
    {
        //Console.WriteLine(ex);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseSwaggerExtension();
app.UseHealthChecks("/health");
app.Run();

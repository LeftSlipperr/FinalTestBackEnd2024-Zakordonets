    using BankSystemApp.Interfaces;
    using BankSystemApp.Services;
    using BuildingSystem.Data;
    using BuildingSystem.Data.Storage;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OpenApi.Models;

    var builder = WebApplication.CreateBuilder(args);

    var connectionString = builder.Configuration.GetConnectionString("BuildingSystemDb");

    builder.Services.AddDbContext<BuildingSystemDbContext>(options =>
        options.UseNpgsql(connectionString).LogTo(Console.WriteLine, LogLevel.Information));  // Логирование подключения к БД

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    /*builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IBuildingService, BuildingService>();
    builder.Services.AddScoped<ISensorService, SensorService>();
    builder.Services.AddScoped<ISensorDataService, SensorDataService>();
    builder.Services.AddScoped<INotificationService, NotificationService>();*/

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
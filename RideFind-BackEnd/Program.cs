using Microsoft.EntityFrameworkCore;
using RideFind_BackEnd.Orders.Application.Internal.CommandServices;
using RideFind_BackEnd.Orders.Application.Internal.QueryServices;
using RideFind_BackEnd.Orders.Domain.Repositories;
using RideFind_BackEnd.Orders.Domain.Services;
using RideFind_BackEnd.Orders.Infrastructure.Repositories;
using RideFind_BackEnd.Shared.Domain.Repositories;
using RideFind_BackEnd.Shared.Infrastructure.Interfaces.ASP.Configuration;
using RideFind_BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration;
using RideFind_BackEnd.Shared.Infrastructure.Persistence.EFC.Repositories;
using RideFind_BackEnd.UserProfile.Application.Internal.CommandService;
using RideFind_BackEnd.UserProfile.Application.Internal.QueryService;
using RideFind_BackEnd.UserProfile.Domain.Repositories;
using RideFind_BackEnd.UserProfile.Domain.Services;
using RideFind_BackEnd.UserProfile.Infrastructure.Repositories;
using RideFind_BackEnd.Vehicle.Application.Internal.CommandService;
using RideFind_BackEnd.Vehicle.Application.Internal.QueryService;
using RideFind_BackEnd.Vehicle.Domain.Repositories;
using RideFind_BackEnd.Vehicle.Domain.Services;
using RideFind_BackEnd.Vehicle.Infrastructure.Repositories;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure LowerCase Urls
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

/////////////////////////Begin Database Configuration/////////////////////////

//Add DataBase Context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify Database Connection string
if (connectionString is null)
    throw new Exception("Database connection string is not set");

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        });


// Configure Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Bounded Context  Vehicles Injection Configuration for Business
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IVehicleSourceRepository, VehicleSourceRepository>();
builder.Services.AddScoped<IVehicleSourceCommandService, VehicleSourceCommandService>();
builder.Services.AddScoped<IVehicleSourceQueryService, VehicleSourceQueryService>();

//USER
builder.Services.AddScoped<IUserSourceRepository, UserSourceRepository>();
builder.Services.AddScoped<IUserSourceCommandService, UserSourceCommandService>();
builder.Services.AddScoped<IUserSourceQueryService, UserSourceQueryService>();

//Order
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();

//agregar cada entidad y arquetipo

/////////////////////////End Database Configuration/////////////////////////
var app = builder.Build();
//Verify DataBase object are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
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

app.Run();

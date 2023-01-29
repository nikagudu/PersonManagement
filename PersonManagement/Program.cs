using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using PersonManagement.Application.Contracts;
using PersonManagement.Application.Interfaces;
using PersonManagement.Application.Services;
using PersonManagement.Infrastructure.DataBaseContext;
using PersonManagement.Infrastructure.Repositories;
using PersonManagement.Infrastructure.UnitOfWork;
using PersonManagement.WebApi.FIlters;
using PersonManagement.WebApi.Middleware;
using PersonManagement.WebApi.Validations;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLocalization();
builder.Services.AddFluentValidation(s => 
{ 
    s.RegisterValidatorsFromAssemblyContaining<CreatePersonModelValidator>();
    s.RegisterValidatorsFromAssemblyContaining<UpdatePersonModelValidator>();
    s.RegisterValidatorsFromAssemblyContaining<PhoneValidator>();
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add<RequestValidationFilter>();

}).AddDataAnnotationsLocalization();
var connectionString = builder.Configuration.GetConnectionString("PersonsDbConnectionString");
builder.Services.AddDbContext<PersonsDbContext>(s => s.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRelationService, PersonRelationService>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonRelationRepository, PersonRelationRepository>();


builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(builder.Configuration)
                    .Enrich.FromLogContext();
});


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseRequestLocalization(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
    };
    options.DefaultRequestCulture = new RequestCulture("ka-Ge");
    options.SupportedCultures= supportedCultures;
});

app.UseHttpsRedirection();
    
app.UseAuthorization();
app.UseMiddleware<ExceptionLoggingMiddleware>();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PersonsDbContext>();
    DbInitializer.Initialize(context);
}

try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host was not run");
}
finally
{
    Log.CloseAndFlush();
}
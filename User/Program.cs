using MassTransit;
using MassTransit.Logging;
using MediatR;
using System.Reflection;
using FluentValidation;
using User;
using User.Application;
using User.Application.Contracts;
using User.Infrastructure;
using User.Infrastructure.Persistence;
using User.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
//builder.Services.AddRazorPages();
MongoDbPersistence.Configure();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 
//builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddWebApiServices(builder.Configuration);
builder.Services.AddScoped<IRepository<User.Domain.Entities.User>, Repository<User.Domain.Entities.User>>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthorization();

app.MapControllers();

app.Run();

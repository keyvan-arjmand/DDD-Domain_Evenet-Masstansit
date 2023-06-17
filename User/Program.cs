using MassTransit;
using MassTransit.Logging;
using User.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.UsingAmazonSqs((context, cfg) =>
    {
        cfg.Host("eu-west-2", _ => { });
    });
});
builder.Services.AddHostedService<UserPublisher>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

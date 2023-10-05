using log4net.Config;
using log4net.Core;
using log4net;
using Microsoft.EntityFrameworkCore;
using ReactApp;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.Certificate;
using ReactApp.Helper;
using ReactApp.Context;
using ReactApp.Middleware;
using Microsoft.AspNetCore.Server.IISIntegration;
using ReactApp.Utilities.log4net;
using System.Net;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
var settingsSection = builder.Configuration.GetSection("ApplicationSettings");
//namapuje na objekt
builder.Services.Configure<AppSettings>(settingsSection);
builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);


// Konfigurace pøipojení k databázím
string configDbConnectionString = builder.Configuration.GetConnectionString("ConfigDbConnection");
string dataDbConnectionString = builder.Configuration.GetConnectionString("DataDbConnection");

builder.Services.AddCors(options =>
{
    //options.AddPolicy("AllowAll",
    //    builder =>
    //    {
    //        builder.WithOrigins("https://localhost:44418")
    //               .AllowAnyMethod()
    //               .AllowAnyHeader().AllowCredentials();
    //    });
});
builder.Services.AddControllers();
// Pøidání služby kontextu pro config databázi
builder.Services.AddDbContext<ConfigDbContext>(options =>
    options.UseSqlServer(configDbConnectionString)
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)); // Nastavení AsNoTracking()
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DatingApp", Version = "v1" });
});
builder.Services.AddDbContext<DataDbContext>(
    options =>
    options.UseSqlServer(dataDbConnectionString)
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    );

builder.Services.AddSingleton<DbContextDictionary>();
builder.Services.AddScoped<ApplicationContext>();
//builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);
builder.Services.AddSingleton<LogService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tutorial API V1");
});
app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseCors(builder => builder
//      .WithOrigins("https://localhost:44418")
//      .AllowAnyMethod()
//      .AllowAnyHeader()
//      .AllowCredentials()
//  );
// Registrovat vlastní middleware pro manipulaci s preflight požadavky
//app.UseMiddleware<CorsOptionsMiddleware>();
app.UseRouting();
//app.UseCors("AllowAll");
app.UseCors();
app.UseAuthentication();
app.UseMiddleware<ReactMiddleware>();
app.UseEndpoints(end =>
{
    end.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

//app.MapFallbackToFile("index.html"); ;

app.Run();

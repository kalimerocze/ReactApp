using log4net;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReactApp.Helper;
using ReactApp.Context;
using ReactApp.Controllers;
using ReactApp.Helper;
using ReactApp.Utilities.log4net;

namespace ReactApp.Middleware
{
    public class ReactMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILog _log;

        public ReactMiddleware(RequestDelegate next, LogService logService)
        {
            _next = next;
            _log = logService.GetLogger(typeof(ReactMiddleware));
        }

        public async Task Invoke(
            HttpContext context,
            ApplicationContext appContext,
            DataDbContext dataDbContext,
            ConfigDbContext configDbContext,
            IHttpContextAccessor accessor,
   LogService logger,
            IConfiguration configuration,
            IWebHostEnvironment environment,
            IOptions<AppSettings> appsettings)
        {
          //  _log.Info($"VueMiddleware.Invoke{dataDbContext} , {configDbContext}...");

            string? path = context.Request.Path.Value;


            _log.Debug("Toto je debugovací zpráva");
            _log.Warn("Toto je varovná zpráva");
            _log.Error("Toto je chybová zpráva");
            _log.Fatal("Toto je fatální zpráva");

            //inicializujeme instance
            appContext.Init(context,
             appContext,
           dataDbContext,
             configDbContext,
             accessor, 
             logger,
             configuration,
             environment, 
             appsettings.Value);

            if (context.Request.Path.StartsWithSegments("/app"))
            {
                //await context.Response.WriteAsync("<!DOCTYPE html><html><head><title>VUE APP</title></head><body><div id='app'></div><script src='/js/app.js'></script></body></html>");
            }
            else
            {
                //await _next.Invoke(context);
                await _next(context);
            }
        }
    }
}
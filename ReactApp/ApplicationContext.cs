using log4net;
using Microsoft.EntityFrameworkCore;
using ReactApp.Context;
using ReactApp.Helper;
using ReactApp.Utilities.log4net;
using System.Runtime.InteropServices;

namespace ReactApp
{
    public class ApplicationContext
    {
        public ApplicationContext()
        {
        }
        public AppSettings Settings { get; private set; }
        public UserProfile UserProfile { get; private set; }
        public ClientContext ClientContext { get; private set; }
        public DbContextDictionary DbContexts { get; private set; } = new DbContextDictionary();
        public ILog log { get; private set; }


        public void Init(HttpContext context,
            ApplicationContext appContext,
            DataDbContext dataDbContext,
            ConfigDbContext configDbContext,
            IHttpContextAccessor accessor,
            LogService logger,
            IConfiguration configuration,
            IWebHostEnvironment environment,
            AppSettings appSettings)
        {
            var dbContexts = new DbContextDictionary();
            log = logger.GetLogger(typeof(ApplicationContext));



            // Přidání databázového kontextu do slovníku
            DbContexts.AddDbContext("DataDb", dataDbContext);
            DbContexts.AddDbContext("ConfigDb", configDbContext);

            Settings = appSettings;


            if (environment.WebRootPath != null)
            {
                if (environment.WebRootPath.Contains("IIS", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Aplikace je hostována v IIS.");
                }
                else if (environment.ApplicationName.Contains("Kestrel", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Aplikace je hostována v Kestrel.");
                }
                else
                {
                    Console.WriteLine("Aplikace je hostována na jiném serverovém prostředí.");
                }
            }
            else
            {
                Console.WriteLine("Nelze zjistit hostovací prostředí.");
            }

            string osPlatform = RuntimeInformation.OSDescription;
            string osArchitecture = RuntimeInformation.OSArchitecture.ToString();
            string frameworkDescription = RuntimeInformation.FrameworkDescription;

            string username = "Anonymní uživatel";
            //ClientContext = new(this);
            if (accessor.HttpContext.User.Identities.FirstOrDefault().IsAuthenticated) {
                username = accessor.HttpContext.User.Identity.Name;
            }
            UserProfile = new UserProfile(this, username);
        }
    }
    public class DbContextDictionary
    {
        private readonly Dictionary<string, DbContext> _dbContexts = new Dictionary<string, DbContext>();

        public void AddDbContext<TContext>(string dbName, TContext dbContext) where TContext : DbContext
        {
            _dbContexts[dbName] = dbContext;
        }

        public TContext GetDbContext<TContext>(string dbName) where TContext : DbContext
        {
            if (_dbContexts.TryGetValue(dbName, out var dbContext) && dbContext is TContext context)
            {
                return context;
            }

            throw new ArgumentException($"Databázový kontext '{dbName}' nebyl nalezen nebo není typu '{typeof(TContext).Name}'.");
        }
    }
}

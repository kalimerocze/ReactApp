using log4net;
using log4net.Config;
using log4net.Core;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml;

namespace ReactApp
{
    public static class Logger {

        /// <summary>
        /// Metoda logující chybu v apliakci
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
            _logger.Error(message);
        }

        /// <summary>
        /// Metoda logující Informaci
        /// </summary>
        /// <param name="message"></param>
        public static void LogInfo(string message)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
            _logger.Info(message);
        }

        /// <summary>
        /// Metoda logující informaci pro debug prostředí
        /// </summary>
        /// <param name="message"></param>
        public static void LogDebug(string message)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
            _logger.Debug(message);
        }

    }

}

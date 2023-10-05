    using global::log4net;
    using global::log4net.Config;
    using Microsoft.Extensions.Configuration;
    using System.IO;
namespace ReactApp.Utilities.log4net
{

    /// <summary>
    /// Slouží k načtení konfigurace log4net z konfiguračního souboru a nakonfigurování log4net pro použití ve vaší aplikaci.  
    /// </summary>
    public static class LoggerConfigurator
    {
        public static void Configure(string configFile)
        {
            var logConfig = new FileInfo(configFile);
            //umožní dynamickou změnu konfigurace bez nutnosti resetování apliakce 
            //pomaha k inciializaci pouze 1x v apliakci aby byla dostupná všude
            XmlConfigurator.ConfigureAndWatch(logConfig);
        }
    }
    /// <summary>
    /// Toto je vlastní služba, která slouží k poskytování instancí logovacího objektu (ILog) pro různé části aplikace.
    /// </summary>
    public class LogService
    {
        //vraci instanci ILog pro konkrétní typ - je registrováno jako singleton!!!bude 1x v apliakci do jeho killu
        public ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }
    }
}
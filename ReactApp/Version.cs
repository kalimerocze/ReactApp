using System.Reflection;

namespace ReactApp
{
    /// <summary>
    /// Metoda zjistuje pomocí reflexe zjistí Verzi projektu
    /// </summary>
    public static class Version
    {
        /// <summary>
        /// Vrátí aktuální verzi
        /// </summary>
        /// <returns></returns>
        public static VersionInfo GetVerze() { 
        //reflexe zjistíme aktuální 
        var assembly = Assembly.GetExecutingAssembly().GetName();
            var version = assembly.Version;
            return new VersionInfo(assembly.Name, $"{version.Major}.{version.Minor}.{version.Revision}");
        }

    }
    //třída která definuje property verze
    public class VersionInfo {
        public VersionInfo(string name, string version)
        {
            Name = name;
            Version = version;
        }
        //nazev projektu
        public string Name { get; }
        //verze projektu
        public string Version { get; }
       
    }
}

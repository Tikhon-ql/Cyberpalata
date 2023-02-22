using Microsoft.Extensions.Configuration;

namespace Cyberpalata.Common
{
    public class ConfigurationHandler
    {
        private static readonly IConfiguration _configuration;

        public static IConfigurationSection GetSection(string section)
        {
            return _configuration.GetSection(section);
        }
    }
}

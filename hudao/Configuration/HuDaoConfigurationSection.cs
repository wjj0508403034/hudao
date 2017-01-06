using System.Configuration;

namespace hudao.Configuration
{
    public class HuDaoConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("service")]
        public ServiceConfigurationElement Service
        {
            get { return (ServiceConfigurationElement)this["service"]; }
        }
    }
}

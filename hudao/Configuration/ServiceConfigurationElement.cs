using System.Configuration;

namespace hudao.Configuration
{
    public class ServiceConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get
            {
                return this["url"] as string;
            }
        }
    }
}

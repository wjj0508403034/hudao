using System.Configuration;
using hudao.Configuration;
using hudao.Utils;

namespace hudao.Services
{
    public abstract class BaseService
    {
        //private const string BaseUrl = "http://localhost/";
        //protected readonly RestClient httpClient = new RestClient(BaseUrl);

        private static HuDaoConfigurationSection HuDaoConfig
        {
            get { return (HuDaoConfigurationSection) ConfigurationManager.GetSection("hudao"); }
        }

        private string rootUrl;
        protected string RootUrl
        {
            get
            {
                if(StringUtils.IsEmpty(rootUrl))
                {
                    this.rootUrl = HuDaoConfig.Service.Url;
                }

                return this.rootUrl;
            }
        }
    }
}

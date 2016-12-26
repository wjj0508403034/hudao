using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace hudao.Services
{
    public abstract class BaseService
    {
        private const string BaseUrl = "http://localhost/";
        protected readonly RestClient httpClient = new RestClient(BaseUrl);
    }
}

using System.Net.Http;
using System.Threading.Tasks; 
using DevOpsStats.Api.Models;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Services
{
    public abstract class BaseService
    {
        private readonly IHttpClientFactory _clientFactory;
 
        private const string HttpClientName = "devOpsHttpClient";

        protected BaseService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        
        private async Task<string> GetResponse(string resourceUrl)
        {
            var client = _clientFactory.CreateClient(HttpClientName);
            var response = client.GetAsync(resourceUrl).Result;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public virtual async Task<object> Item(string resourceUrl)
        {
            var response = await GetResponse(resourceUrl);
            return JsonConvert.DeserializeObject<object>(response);
        }

        public virtual async Task<ListCount> Count(string resourceUrl)
        {
            var response = await GetResponse(resourceUrl);
            return JsonConvert.DeserializeObject<ListCount>(response);
        }

        public virtual async Task<RootObject> List(string resourceUrl)
        {
            var response = await GetResponse(resourceUrl);
            return JsonConvert.DeserializeObject<RootObject>(response);
        }
    }
}

using System.Net.Http;
using System.Threading.Tasks;
using DevOpsStats.Api.Extensions;
using DevOpsStats.Api.Models;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Services.Item
{
    public class ItemService : IItemService//<T> : IItemService<T> where T : ListObject
    {
        private readonly IHttpClientFactory _clientFactory;

        public ItemService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        private async Task<string> GetResponse(string resourceUrl)
        {
            var client = _clientFactory.CreateClient("devOpsHttpClient");
            var response = client.GetAsyncWithApiVersion(resourceUrl);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        public async Task<ListObject> Item(string resourceUrl)
        {
            var response = await GetResponse(resourceUrl);
            var result = JsonConvert.DeserializeObject<ListObject>(response);

            return result;
        }

        public async Task<ListCount> Count(string resourceUrl)
        {
            var response = await GetResponse(resourceUrl);
            var result = JsonConvert.DeserializeObject<ListCount>(response);

            return result;
        }

        public async Task<ListObject> List(string resourceUrl)
        {
            var response = await GetResponse(resourceUrl);
            var result = JsonConvert.DeserializeObject<ListObject>(response);

            return result;
        }
    }
}

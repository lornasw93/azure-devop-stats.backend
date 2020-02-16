using System.Net.Http;
using System.Threading.Tasks;
using DevOpsStats.Api.Extensions;
using DevOpsStats.Api.Models;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Services.Item
{
    public class ItemService<T> : IItemService<T> where T : ListObject
    {
        private readonly IHttpClientFactory _clientFactory;

        public ItemService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<ListObject> Item(string resourceUrl)
        {
            var client = _clientFactory.CreateClient("devOpsHttpClient");
            var response = client.GetAsyncWithApiVersion(resourceUrl);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ListObject>(responseBody);

            return result;
        }
    }
}

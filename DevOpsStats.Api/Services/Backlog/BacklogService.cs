using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Services.BackLog
{
    public class BacklogService : IBacklogService
    {
        private static string HttpClientName => "devOps";

        private readonly IHttpClientFactory _clientFactory;

        public BacklogService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<object> GetItems(string project, string team)
        {
            var client = _clientFactory.CreateClient(HttpClientName);
            var response = client.GetAsync($"{project}/{team}/_apis/work/backlogs?api-version=5.1-preview.1").Result;

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            return result;
        }
    }
}

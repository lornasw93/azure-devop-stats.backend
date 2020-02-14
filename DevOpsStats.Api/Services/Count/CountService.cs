using System.Net.Http;
using System.Threading.Tasks;
using DevOpsStats.Api.Extensions;
using DevOpsStats.Api.Models.DevOps;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Services.Count
{
    public class CountService<T> : ICountService<T> where T : ListCount
    {
        public async Task<ListCount> Count(string resourceUrl)
        {
            var client = new HttpClient();
            var response = client.GetAsyncWithApiVersion(resourceUrl);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ListCount>(responseBody);

            return result;
        }
    }
}

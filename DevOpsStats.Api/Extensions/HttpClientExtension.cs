using System.Net.Http;

namespace DevOpsStats.Api.Extensions
{
    public static class HttpClientExtension
    {
        private static string ApiVersion => "?api-version=5.1";

        public static HttpResponseMessage GetAsyncWithApiVersion(this HttpClient httpClient, string resourceUrl)
        {
            //return httpClient.GetAsync($"{resourceUrl}{ApiVersion}").Result;
            return httpClient.GetAsync($"{resourceUrl}").Result;
        }
    }
}

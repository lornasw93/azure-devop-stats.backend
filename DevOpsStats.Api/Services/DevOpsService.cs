using System;
using System.Net.Http;
using System.Threading.Tasks;
using DevOpsStats.Api.Extensions;
using DevOpsStats.Api.Models.Build;
using DevOpsStats.Api.Models.Release;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Services
{
    public class DevOpsService : IDevOpsService
    {
        private static string ApiVersion => "?api-version=5.1";
        private static string HttpClientName => "devOpsHttpClient";

        private readonly HttpClient _httpClient;

        public DevOpsService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient(HttpClientName);
        }
         
        public async Task<object> GetWiki(string project)
        {
            var response = _httpClient.GetAsync($"{project}/_apis/wiki/wikis").Result;

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<object>(responseBody);

            return result;
        }
     
        public async Task<object> GetIterations(string project)
        {
            var response = _httpClient.GetAsync($"{project}/_apis/work/teamsettings/iterations{ApiVersion}").Result;

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<object>(responseBody);

            return result;
        }
        public async Task<object> GetGitRepos(string project)
        {

            var response = _httpClient.GetAsync($"{project}/_apis/git/repositories{ApiVersion}").Result;

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            return result;
        }
        public async Task<object> GetPullRequestsByProject(string project)
        {
            var response = _httpClient.GetAsync($"{project}/_apis/git/pullrequests{ApiVersion}").Result;

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            return result;
        }
        public async Task<object> GetPullRequestsByRepo(string project, Guid repoId)
        {
            var response = _httpClient.GetAsync($"{project}/_apis/git/repositories/{repoId}/pullrequests{ApiVersion}").Result;

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            return result;
        }

        public async Task<Build> GetBuild(string project, int buildId)
        {
            var response = _httpClient.GetAsyncWithApiVersion($"{project}/_apis/build/builds/{buildId}");

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Build>(responseBody);

            return result;
        }
        public async Task<Release> GetRelease(string project, int releaseId)
        {
            var response = _httpClient.GetAsync($"{project}/_apis/release/releases/{releaseId}{ApiVersion}").Result;

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Release>(responseBody);

            return result;
        }
        public async Task<object> GetGitRepo(string project, Guid repoId)
        {
            var response = _httpClient.GetAsync($"{project}/_apis/git/repositories/{repoId}{ApiVersion}").Result;

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DevOpsStats.Api.Models.DevOps;
using DevOpsStats.Api.Models.DevOps.TestPlan;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Services.TestPlan
{
    public class TestPlanService : ITestPlanService
    {
        private static string ApiVersion => "?api-version=5.1";
        private static string HttpClientName => "devOps";

        private readonly IHttpClientFactory _clientFactory;

        public TestPlanService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<TestPlanList> GetTestRuns(string project)
        {
            var client = _clientFactory.CreateClient(HttpClientName);
            var response = client.GetAsync($"{project}/_apis/test/runs").Result;

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TestPlanList>(responseBody);

            return result;
        }

        public async Task<object> GetTestRunStats(string project, int runId)
        {
            var client = _clientFactory.CreateClient(HttpClientName);
            var response = client.GetAsync($"{project}/_apis/test/runs/{runId}/Statistics").Result;

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<object>(responseBody);

            return result;
        }

        public async Task<object> GetTestRunById(string project, int runId)
        {
            var client = _clientFactory.CreateClient(HttpClientName);
            var response = client.GetAsync($"{project}/_apis/test/runs/{runId}").Result;

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<object>(responseBody);

            return result;
        }
         
        public async Task<ListCount> GetTestRunsCount(string project)
        {
            var client = _clientFactory.CreateClient(HttpClientName);
            var response = client.GetAsync($"{project}/_apis/test/runs").Result;

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ListCount>(responseBody);

            return result;
        } 
    }
}

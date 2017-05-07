using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MobileCenterClient.Models.Exceptions;
using MobileCenterClient.Models.MobileCenter.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace MobileCenterClient.Models
{
    public class MobileCenterApi
    {
        public string Url { get; } = "https://api.mobile.azure.com";

        private readonly HttpClient _client;
        public JsonSerializerSettings SnakeCaseSerializerSettings { get; }
        public JsonSerializerSettings PascalCaseSerializerSettings { get; }

#if DEBUG
        private ITraceWriter traceWriter = new MemoryTraceWriter();
#endif

        public MobileCenterApi()
        {
            _client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000,
                BaseAddress = new Uri(Url),
                DefaultRequestHeaders = { {"X-API-Token", Settings.ApiToken} }
            };

            SnakeCaseSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new SnakeCasePropertyNamesContractResolver()
#if DEBUG
                ,TraceWriter = traceWriter
#endif
            };

            PascalCaseSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new PascalCasePropertyNamesContractResolver()
#if DEBUG
                ,
                TraceWriter = traceWriter
#endif
            };
        }

        public async Task<UserProfile> GetUserProfile()
        {
            return await GetResource<UserProfile>("/v0.1/user", SnakeCaseSerializerSettings);
        }

        public async Task<List<App>> GetApps()
        {
            return await GetResource<List<App>>("/v0.1/apps", SnakeCaseSerializerSettings);
        }

        public async Task<List<BranchStatus>> GetBranches(string ownerName, string appName)
        {
            var branches = await GetResource<List<BranchStatus>>($"/v0.1/apps/{ownerName}/{appName}/branches",
                PascalCaseSerializerSettings);

            // Retrieve full commit info for each branch
            Parallel.ForEach(branches, async branch =>
            {
                if (branch.Branch.Commit.Commit == null)
                    branch.Branch.Commit = await GetCommitDetails(ownerName, appName, branch.Branch.Commit.Sha);
            });

            return branches;
        }

        public async Task<CommitDetails> GetCommitDetails(string ownerName, string appName, string shaHash)
        {
            var commitDetailsList = await GetResource<List<CommitDetails>>(
                $"/v0.1/apps/{ownerName}/{appName}/commits/batch?hashes={shaHash}",
                PascalCaseSerializerSettings);
            return commitDetailsList.FirstOrDefault();
        }

        private async Task<T> GetResource<T>(string endpoint, JsonSerializerSettings serializerSettings)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync(endpoint);
            }
            catch (HttpRequestException)
            {
                throw new FailedHttpRequestException(endpoint);
            }

            if (!response.IsSuccessStatusCode)
                throw new FailedHttpResponseException(response);

            var content = await response.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<T>(content, serializerSettings);

#if DEBUG
            Debug.WriteLine(traceWriter);
#endif

            return deserialized;
        }
    }
}

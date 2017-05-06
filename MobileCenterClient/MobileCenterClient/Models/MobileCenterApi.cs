using System;
using System.Collections.Generic;
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
        private string Token { get; } = Secrets.MobileCenterApiKey;

        private readonly HttpClient _client;
        private readonly JsonSerializerSettings _jsonSerializerSettings;


        public MobileCenterApi()
        {
            _client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000,
                BaseAddress = new Uri(Url),
                DefaultRequestHeaders = { {"X-API-Token", Token} }
            };

            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new SnakeCasePropertyNamesContractResolver()
            };
        }

        public async Task<UserProfile> GetUserProfile()
        {
            return await GetResource<UserProfile>("/v0.1/user");
        }

        public async Task<List<App>> GetApps()
        {
            return await GetResource<List<App>>("/v0.1/apps");
        }

        public async Task<List<BranchStatus>> GetBranches(string ownerName, string appName)
        {
            return await GetResource<List<BranchStatus>>($"/v0.1/apps/{ownerName}/{appName}/branches");
        }

        private async Task<T> GetResource<T>(string endpoint)
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

            return JsonConvert.DeserializeObject<T>(content, _jsonSerializerSettings);
        }
    }
}

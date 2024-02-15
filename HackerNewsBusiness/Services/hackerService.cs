using Microsoft.Extensions.Configuration;
using NLog;
using hackerNewsBusiness.Interface;
using hackerNewsBusiness.Models;

using Newtonsoft.Json;

/// <summary>
///		Bamboo-card WebApi Project
/// </summary>
/// <Version>
///		Author					Date			ChangeHistory
///		Zarmeen Zahid 			FEB 15,2024	    Creation
namespace hackerNewsBusiness.Services
{
    public class hackerService : IhackerService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _nLogger;
        public string _beststoryIDsAPI;
        
        public hackerService(IConfiguration configuration)
        {
            _nLogger = LogManager.GetCurrentClassLogger();
            _configuration = configuration;
            _beststoryIDsAPI = _configuration["BaseURL:beststoryAPI"] ?? "";
           
        }

        public async Task<IEnumerable<int>> GetBestStoryIdsAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync(_beststoryIDsAPI);
            return JsonConvert.DeserializeObject<IEnumerable<int>>(response);
        }

        public async Task<IEnumerable<Storymodel>> GetBestStoriesAsync(IEnumerable<int> storyIds)
        {
            var tasks = storyIds.Select(id => GetStoryDetailsAsync(id));
            return await Task.WhenAll(tasks);
        }

        public async Task<Storymodel> GetStoryDetailsAsync(int storyId)
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync($"https://hacker-news.firebaseio.com/v0/item/{storyId}.json");
            return JsonConvert.DeserializeObject<Storymodel>(response);
        }




    }
}

using hackerNewsBusiness.Models;


/// <summary>
///		Bamboo-card WebApi Project
/// </summary>
/// <Version>
///		Author					Date			ChangeHistory
///		Zarmeen Zahid 			FEB 15,2024	    Creation
namespace hackerNewsBusiness.Interface
{
    public interface IhackerService
    {
        public  Task<IEnumerable<int>> GetBestStoryIdsAsync();
        public Task<IEnumerable<Storymodel>> GetBestStoriesAsync(IEnumerable<int> storyIds);
        public Task<Storymodel> GetStoryDetailsAsync(int storyId);

    }
}

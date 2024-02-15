using Microsoft.AspNetCore.Mvc;
using NLog;
using hackerNewsBusiness.Interface;
using ILogger = NLog.ILogger;

/// <summary>
///		Bamboo-card WebApi Project
/// </summary>
/// <Version>
///		Author					Date			ChangeHistory
///		Zarmeen Zahid 			FEB 15,2024	    Creation
namespace TE_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class hackerController : ControllerBase
    {
        private readonly ILogger _nLogger = LogManager.GetCurrentClassLogger();
        private readonly IhackerService _hackerService ;


        public hackerController(IhackerService heckerServices)
        {
            _hackerService = heckerServices;
        }
        [HttpPost]
        [Route("GetBestStory")]
        public async Task<IActionResult> GetBestStories()
        {
            _nLogger.Info("#### START ---- GetBestStories { ---- #####");

            try
            {
                var bestStoryIds = await _hackerService.GetBestStoryIdsAsync();

                // Get the details of all the best stories
                var bestStories = await _hackerService.GetBestStoriesAsync(bestStoryIds);

                // Order the stories by score in descending order
                bestStories = bestStories.OrderByDescending(story => story.score);

                return Ok(bestStories);
            }
            catch (HttpRequestException ex)
            {
                // Handle the exception, log, or return an error response
                _nLogger.Error("#### ERROR ---- GetBestStories ---- #####" + ex);
                throw;
            }

        }

        

    }
}

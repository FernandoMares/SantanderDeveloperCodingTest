using FGMHackerNewsAPI.DTOs;
using FGMHackerNewsAPI.Models;
using FGMHackerNewsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FGMHackerNewsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly HackerNewsService _hackerNewsService;

        public StoriesController(HackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoryDto>>> GetBestStories([FromQuery] int count = 10)
        {
            //Return badRequest if count is less than zero
            if (count <= 0)
            {
                return BadRequest("Count must be greater than 0.");
            }

            var stories = await _hackerNewsService.GetBestStoriesAsync(count);
            //Pass the retrieved information according the expected response body
            var storyDtos = stories.Select(story => new StoryDto
            {
                Title = story.Title,
                Uri = story.Uri,
                PostedBy = story.PostedBy,
                Time = story.Time,
                Score = story.Score,
                CommentCount = story.CommentCount
            });

            return Ok(storyDtos);
        }
    }
}

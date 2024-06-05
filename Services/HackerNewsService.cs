using FGMHackerNewsAPI.Models;

namespace FGMHackerNewsAPI.Services
{
    public class HackerNewsService
    {
        private readonly HttpClient _httpClient;

        public HackerNewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Method that returns a List of the best stories using a parameter.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<Story>> GetBestStoriesAsync(int count)
        {
            var bestStoriesIds = await _httpClient.GetFromJsonAsync<List<int>>(Common.GlobalConstants.bestStoriesURL);

            var tasks = bestStoriesIds.Take(count).Select(id => GetStoryByIdAsync(id)).ToList(); // Fetch top count values from stories for efficiency
            var stories = await Task.WhenAll(tasks);

            return stories.Where(story => story != null)
                          .OrderByDescending(story => story.Score)
                          .Take(count)
                          .ToList();
        }

        /// <summary>
        /// Method that returns a Task with individual detail using story ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<Story> GetStoryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(Common.GlobalConstants.urlItemDetail + $"{id}.json");
            if (response.IsSuccessStatusCode)
            {
                var story = await response.Content.ReadFromJsonAsync<Story>();
                return story;
            }
            return null;
        }
    }
}

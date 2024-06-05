using System.Text.Json.Serialization;

namespace FGMHackerNewsAPI.Models
{
    public class Story
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public string Uri { get; set; }

        [JsonPropertyName("by")]
        public string PostedBy { get; set; }

        [JsonPropertyName("time")]
        public long UnixTime { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("descendants")]
        public int CommentCount { get; set; }

        [JsonIgnore]
        public string Time => DateTimeOffset.FromUnixTimeSeconds(UnixTime).ToString("yyyy-MM-ddTHH:mm:ss+00:00");

    }
}

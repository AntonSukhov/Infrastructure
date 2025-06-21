using System.Text.Json.Serialization;

namespace Infrastructure.Networks.Tests.HttpClientExtensionTests.Models
{
    public class PostDataModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Body { get; set; }
        public int UserId { get; set; }
    }
}

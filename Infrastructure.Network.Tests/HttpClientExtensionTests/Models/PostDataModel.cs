namespace Infrastructure.Network.Tests.HttpClientExtensionTests.Models
{
    public class PostDataModel
    {
        public required string Title { get; set; }
        public required string Body { get; set; }
        public int UserId { get; set; }
    }
}

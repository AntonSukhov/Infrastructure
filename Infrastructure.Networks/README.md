About

The package contains services, helpers, models, etc. general purpose for .NET of applications.

How to Use

    //A custom class. Given as an example.
    public class PostDataModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Body { get; set; }
        public int UserId { get; set; }
    }
    
    var message = string.Empty;
    var url = "https://jsonplaceholder.typicode.com/posts"; //Public API. I use the POST method for verification.
    var inputObject = new PostDataModel { Title = "foo", Body = "bar", UserId = 1 };
    var httpClient = HttpClientService.CreateDefaultHttpClient();
    var mediaTypeAsString = MediaType.Json.ToMediaTypeString();

    var outputObject = await httpClient.PostAsync<PostDataModel, PostDataModel>(url, inputObject, JsonSerializerOptions.Default, MediaType.Json);

    if (outputObject != null &&
        outputObject.Body == inputObject.Body &&
        outputObject.Title== inputObject.Title &&
        outputObject.UserId == inputObject.UserId &&
        outputObject.Id > 0)
    {
        message = "The serialization and deserialization was successful!";
    }
    else
    {
        message = "The serialization and deserialization was unsuccessful!";
    }

    Console.WriteLine(message);
    
    Console.WriteLine(mediaTypeAsString);
 
Main Types

The main types provided by this library are:

    Infrastructure.Networks.Services.HttpClientService
    Infrastructure.Networks.Enums.MediaType
    Infrastructure.Networks.Extensions.HttpClientExtension
    Infrastructure.Networks.Extensions.MediaTypeExtension


Feedback & Contributing

Infrastructure.Networks is released as open source under the MIT license. Bug reports and contributions are welcome at the GitHub repository.

About

The package contains services, helpers, models, etc. general purpose for .NET of applications.

How to Use

    IJsonSerializationService jsonSerializationService = new JsonSerializationService();

    var pageOptions = new PageOptionsModel
    {
        PageNumber = 1,
        PageSize = 10
    };

    var message = string.Empty;

    var pageOptionsSerialized = await jsonSerializationService.SerializeAsync(pageOptions, JsonSerializerOptions.Default);
    var pageOptionsDeserialized = await jsonSerializationService.DeserializeAsync<PageOptionsModel>(pageOptionsSerialized, JsonSerializerOptions.Default);


    if (pageOptionsDeserialized.PageNumber == pageOptions.PageNumber &&
        pageOptionsDeserialized.PageSize == pageOptions.PageSize)
    {
        message = "The serialization and deserialization was successful!";
    }
    else
    {
        message = "The serialization and deserialization was unsuccessful!";
    }

    Console.WriteLine(message);
    
 
Main Types

The main types provided by this library are:

    Infrastructure.Common.Services.IJsonSerializationService
    Infrastructure.Common.Services.JsonSerializationService
    Infrastructure.Common.Helpers.ConstantsHelper
    Infrastructure.Common.Models.PageOptionsModel


Feedback & Contributing

Infrastructure.Caching is released as open source under the MIT license. Bug reports and contributions are welcome at the GitHub repository.
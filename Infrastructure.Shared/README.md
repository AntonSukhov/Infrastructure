About

The package contains services, helpers, models, etc. general purpose for .NET of applications.

How to Use

    var pageOptions = new Shared.Models.PageOptionsModel
    {
        PageNumber = 1,
        PageSize = 10
    };

    var message = string.Empty;

    var pageOptionsSerialized = await JsonSerializationService.SerializeAsync(pageOptions);
    var pageOptionsDeserialized = await JsonSerializationService.DeserializeAsync<Shared.Models.PageOptionsModel>(pageOptionsSerialized);


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

    var secret = ConfigurationHelper.GetSecret("SK:ServiceApiKey", "705078df-8a7d-41c8-b13a-d9f26020eff8");
    
 
Main Types

The main types provided by this library are:

    Infrastructure.Shared.Services.JsonSerializationService
    Infrastructure.Shared.Helpers.ConstantsHelper
    Infrastructure.Shared.Helpers.ConfigurationHelper
    Infrastructure.Shared.Models.PageOptionsModel


Feedback & Contributing

Infrastructure.Shared is released as open source under the MIT license. Bug reports and contributions are welcome at the GitHub repository.

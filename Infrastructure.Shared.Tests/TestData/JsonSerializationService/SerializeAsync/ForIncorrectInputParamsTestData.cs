using System.Text.Json;
using Infrastructure.Shared.Services;
using Infrastructure.Shared.Tests.JsonSerializationServiceTests.Models;

namespace Infrastructure.Shared.Tests.TestData.JsonSerializationService.SerializeAsync;

/// <summary>
/// Тестовые данные проверки метода асинхронной сериализации объект в строку формата JSON
/// для некорректных входных параметров.
/// </summary>

public static class ForIncorrectInputParamsTestData
{ 
    #region Методы

    public static TheoryData<EmployeeModel?, IJsonSerializationOptions<JsonSerializerOptions>?, CancellationToken> GetTestData()
    {
        var jsonSerializationOptions = new JsonSerializationOptions(JsonSerializerOptions.Default);

        return new TheoryData<EmployeeModel?, IJsonSerializationOptions<JsonSerializerOptions>?, CancellationToken>
        {
            {null, jsonSerializationOptions, default},
        };
    }

    #endregion
}

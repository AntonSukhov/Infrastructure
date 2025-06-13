using System.Text.Json;
using Infrastructure.Shared.Helpers;
using Infrastructure.Shared.Services;

namespace Infrastructure.Shared.Tests.TestData.JsonSerializationService.DeserializeAsync;

/// <summary>
/// Тестовые данные проверки метода асинхронной десериализации строки формата JSON в объект
/// для некорректных входных параметров.
/// </summary>

public static class ForIncorrectInputParamsTestData
{ 
    #region Методы

    public static TheoryData<string, IJsonSerializationOptions<JsonSerializerOptions>?, CancellationToken> GetTestData()
    {
        var employeeWithUndefinedGender= "{\"Id\":6,\"Fio\":\"Лебедева Ольга Васильевна\",\"Gender\":null,\"Birthdate\":\"1992-04-12T00:00:00\",\"Salary\":80000.0}";

        var jsonSerializationOptions = new JsonSerializationOptions(JsonSerializerOptions.Default);

        return new TheoryData<string, IJsonSerializationOptions<JsonSerializerOptions>?, CancellationToken>
        {
            { string.Empty, jsonSerializationOptions, default },
            { ConstantsHelper.Space, jsonSerializationOptions, default },
            { ConstantsHelper.DoubleSpace, jsonSerializationOptions, default },
            { employeeWithUndefinedGender, jsonSerializationOptions, default },
            { employeeWithUndefinedGender, null, default }
        };
    }

    #endregion
}

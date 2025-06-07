using System.Text.Json;
using Infrastructure.Common.Services;

namespace Infrastructure.Common.Tests.TestData.JsonSerializationService.DeserializeAsync;

/// <summary>
/// Тестовые данные проверки метода асинхронной десериализации строки формата JSON в объект
/// для некорректных входных параметров.
/// </summary>

public static class ForIncorrectInputParamsTestData
{ 
    #region Методы

    public static TheoryData<string, JsonSerializerOptions?, CancellationToken> GetTestData()
    {
        var employeeWithUndefinedGender= "{\"Id\":6,\"Fio\":\"Лебедева Ольга Васильевна\",\"Gender\":null,\"Birthdate\":\"1992-04-12T00:00:00\",\"Salary\":80000.0}";

        return new TheoryData<string, JsonSerializerOptions?, CancellationToken>
        {
            { string.Empty, JsonSerializerOptions.Default, default },
            { ConstantsService.Space, JsonSerializerOptions.Default, default },
            { ConstantsService.DoubleSpace, JsonSerializerOptions.Default, default },
            { employeeWithUndefinedGender, JsonSerializerOptions.Default, default },
            { employeeWithUndefinedGender, null, default }
        };
    }

    #endregion
}

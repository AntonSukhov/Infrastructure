using System.Text.Json;
using Infrastructure.Shared.Tests.JsonSerializationServiceTests.Models;

namespace Infrastructure.Shared.Tests.TestData.JsonSerializationService.SerializeAsync;

/// <summary>
/// Тестовые данные проверки метода асинхронной сериализации объект в строку формата JSON
/// для некорректных входных параметров.
/// </summary>

public static class ForIncorrectInputParamsTestData
{ 
    #region Методы

    public static TheoryData<EmployeeModel?, JsonSerializerOptions?, CancellationToken> GetTestData()
    {
        return new TheoryData<EmployeeModel?, JsonSerializerOptions?, CancellationToken>
        {
            {null, JsonSerializerOptions.Default, default},    
        };
    }

    #endregion
}

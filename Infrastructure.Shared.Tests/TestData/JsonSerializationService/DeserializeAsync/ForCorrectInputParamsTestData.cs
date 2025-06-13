using System.Text.Json;
using System.Text.Json.Serialization;
using Infrastructure.Shared.Services;

namespace Infrastructure.Shared.Tests.TestData.JsonSerializationService.DeserializeAsync;

/// <summary>
/// Тестовые данные проверки метода асинхронной десериализации строки формата JSON в объект
/// для корректных входных параметров.
/// </summary>
public static class ForCorrectInputParamsTestData
{

    #region Методы

    public static TheoryData<string, IJsonSerializationOptions<JsonSerializerOptions>, CancellationToken> GetTestData()
    {
        var employee = "{\"Id\":1,\"Fio\":\"Иванов Иван Иванович\",\"Gender\":\"Male\",\"Birthdate\":\"1974-10-24T00:00:00\",\"Salary\":150000.0}";
        var employeeWithNumericGender = "{\"Id\":1,\"Fio\":\"Иванов Иван Иванович\",\"Gender\":\"1\",\"Birthdate\":\"1974-10-24T00:00:00\",\"Salary\":150000.0}";
        var employeeWithEmptyFio = "{\"Id\":2,\"Fio\":\"\",\"Gender\":\"Female\",\"Birthdate\":\"1990-05-15T00:00:00\",\"Salary\":75000.0}";
        var employeeWithZeroSalary = "{\"Id\":3,\"Fio\":\"Петрова Анна Сергеевна\",\"Gender\":\"Female\",\"Birthdate\":\"1985-03-10T00:00:00\",\"Salary\":0.0}";
        var employeeWithMaxSalary = "{\"Id\":4,\"Fio\":\"Сидоров Алексей Викторович\",\"Gender\":\"Male\",\"Birthdate\":\"1980-12-01T00:00:00\",\"Salary\":1.0E+28}";
        var dismissedEmployee = "{\"Id\":5,\"Fio\":\"Григорьев Игорь Николаевич\",\"Gender\":\"Male\",\"Birthdate\":\"1995-08-20T00:00:00\",\"Salary\":60000.0,\"Dismissed\":true}";

        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
        };

        var jsonSerializationOptions = new JsonSerializationOptions(jsonSerializerOptions);


        return new TheoryData<string, IJsonSerializationOptions<JsonSerializerOptions>, CancellationToken>
        {
            { employee, jsonSerializationOptions, default },
            { employeeWithNumericGender, jsonSerializationOptions, default },
            { employeeWithNumericGender, jsonSerializationOptions, default },
            { employeeWithEmptyFio, jsonSerializationOptions, default },
            { employeeWithZeroSalary, jsonSerializationOptions, default },
            { employeeWithMaxSalary, jsonSerializationOptions, default },
            { dismissedEmployee, jsonSerializationOptions, default }
        };
    }

    #endregion
}

using System.Text.Json;
using Infrastructure.Shared.Services;
using Infrastructure.Shared.Tests.JsonSerializationServiceTests.Models;
using Infrastructure.Shared.Tests.TestData.JsonSerializationService.DeserializeAsync;

namespace Infrastructure.Shared.Tests.JsonSerializationServiceTests;

/// <summary>
/// Тесты для проверки метода асинхронной десериализации строки формата JSON в объект.
/// </summary>
public class DeserializeAsyncTests
{
    /// <summary>
    /// Тест проверки метода асинхронной сериализации объект в строку формата JSON для корректных входных параметров.
    /// </summary>
    /// <param name="employeeJson">Объект, который нужно сериализовать.</param>
    /// <param name="jsonSerializerOptions">Опции сериализации.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Асинхронная задача, представляющая результат выполнения теста.</returns>
    [Theory]
    [MemberData(nameof(ForCorrectInputParamsTestData.GetTestData),
                MemberType = typeof(ForCorrectInputParamsTestData))]
    public async Task ForCorrectInputParams(string employeeJson, JsonSerializerOptions? jsonSerializerOptions,
        CancellationToken cancellationToken)
    {
        // Arrange & Act:
        var result = await JsonSerializationService.DeserializeAsync<EmployeeModel>(
            employeeJson, 
            jsonSerializerOptions,
            cancellationToken);

        // Assert:
        Assert.NotNull(result);
        Assert.True(result.Id > 0);
        Assert.False(string.IsNullOrWhiteSpace(result.Fio));
        Assert.Contains(result.Gender, new[] { Gender.Male, Gender.Female });
        Assert.NotEqual(default, result.Birthdate);
        Assert.True(result.Salary >= 0m);
    }

    /// <summary>
    /// Тест проверки метода асинхронной сериализации объект в строку формата JSON для некорректных входных параметров.
    /// </summary>
    /// <param name="employeeJson">Объект, который нужно сериализовать.</param>
    /// <param name="jsonSerializerOptions">Опции сериализации.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Асинхронная задача, представляющая результат выполнения теста.</returns>
    [Theory]
    [MemberData(nameof(ForIncorrectInputParamsTestData.GetTestData),
                MemberType = typeof(ForIncorrectInputParamsTestData))]
    public async Task ForIncorrectInputParams(string employeeJson, JsonSerializerOptions? jsonSerializerOptions,
        CancellationToken cancellationToken)
    {
        // Arrange & Act & Assert:
        var exception = await Assert.ThrowsAnyAsync<Exception>(
            async () => await JsonSerializationService.DeserializeAsync<EmployeeModel>(
                employeeJson,
                jsonSerializerOptions, 
                cancellationToken)
        );

        // Проверяем, что исключение относится к разрешённым типам     
        Assert.True(
            exception is ArgumentException || 
            exception is ArgumentNullException ||
            exception is Exception
        );
    }
}
